using DiscordRPC;
using NAudio.Wave;
using OMI.Formats.Pck;
using PckStudio.Controls;
using PckStudio.Core.Extensions;
using PckStudio.Core.FileFormats;
using PckStudio.External.API.Miles;
using PckStudio.Forms.Additional_Popups;
using PckStudio.Interfaces;
using PckStudio.Internal.App;
using PckStudio.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

// Audio Editor by MayNL and Miku-666

namespace PckStudio.Forms.Editor
{
	public partial class AudioEditor : EditorForm<PckAudioFile>
	{
		public string defaultType = "yes";

        private static readonly List<string> TrackLists = new List<string>
		{
			"Overworld",
			"Nether",
			"End",
			"Creative",
			"Menu/Loading",
			"Battle",
			"Tumble",
			"Glide",
			"Build Off (Unused)"

			/* If the SetMusicID function within the game is ever set to 0x9,
			 * it actually plays a tracklist for MG04, with all of the Creative 
			 * Tracks and the "MG04_01.binka" file in it. The 9th track list ID is MG04 - May
			 */
		};

        public AudioEditor(PckAudioFile audioFile, ISaveContext<PckAudioFile> saveContext)
			: base(audioFile, saveContext)
        {
            InitializeComponent();
            saveToolStripMenuItem1.Visible = !saveContext.AutoSave;
            SetUpTree();
        }

        private string GetTrackListFromId(PckAudioFile.AudioTrackList.EAudioType trackListID)
			=> trackListID >= PckAudioFile.AudioTrackList.EAudioType.Overworld &&
				trackListID <= PckAudioFile.AudioTrackList.EAudioType.BuildOff
				? TrackLists[(int)trackListID]
				: "Not valid";

		private PckAudioFile.AudioTrackList.EAudioType GetTrackListId(string trackList)
		{
			return (PckAudioFile.AudioTrackList.EAudioType)TrackLists.IndexOf(trackList);
		}

		public void SetUpTree()
		{
			trackListTreeView.BeginUpdate();
			trackListTreeView.Nodes.Clear();

			foreach (PckAudioFile.AudioTrackList trackList in EditorValue.TrackLists)
			{
				// fix tracks with directories using backslash instead of forward slash
				// Tracks with a backslash instead of a forward slash would not play in RPCS3
				foreach (string trackName in trackList.TrackNames.FindAll(s => s.Contains('\\')))
					trackList.TrackNames[trackList.TrackNames.IndexOf(trackName)] = trackName.Replace('\\', '/');

				if (trackList.AudioType == PckAudioFile.AudioTrackList.EAudioType.Creative)
				{
					if (trackList.Name == "include_overworld" &&
                        EditorValue.TryGetTrackList(PckAudioFile.AudioTrackList.EAudioType.Overworld, out PckAudioFile.AudioTrackList overworldTrackList))
					{
						foreach (var name in trackList.TrackNames.ToList())
						{
							if (overworldTrackList.TrackNames.Contains(name))
								trackList.TrackNames.Remove(name);
						}
						playOverworldInCreative.Checked = true;
					}
					playOverworldInCreative.Visible = true;
				}

				TreeNode treeNode = new TreeNode(GetTrackListFromId(trackList.AudioType), (int)trackList.AudioType, (int)trackList.AudioType);
				treeNode.Tag = trackList;
				trackListTreeView.Nodes.Add(treeNode);
			}
			playOverworldInCreative.Enabled = EditorValue.HasTrackList(PckAudioFile.AudioTrackList.EAudioType.Creative);
			trackListTreeView.EndUpdate();
		}

		private void trackListTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			trackTreeView.Nodes.Clear();
			if (e.Node.Tag is PckAudioFile.AudioTrackList trackList)
			{
				foreach (var name in trackList.TrackNames)
				{
					trackTreeView.Nodes.Add(name);
				}
			}
			if (trackTreeView.Nodes.Count > 0)
				trackTreeView.SelectedNode = trackTreeView.Nodes[0];
		}

		private void addTrackListStripMenuItem_Click(object sender, EventArgs e)
		{
			string[] available = TrackLists.FindAll(str => !EditorValue.HasTrackList(GetTrackListId(str))).ToArray(); // array needed for popup form down below
			if (available.Length == 0)
			{
				MessageBox.Show(this, "There are no more track lists that could be added", "All possible track lists are used");
			}
			
			using ItemSelectionPopUp add = new ItemSelectionPopUp(available);
			if (add.ShowDialog(this) != DialogResult.OK)
				return;

			EditorValue.AddTrackList(GetTrackListId(add.SelectedItem));
            PckAudioFile.AudioTrackList trackList = EditorValue.GetTrackList(GetTrackListId(add.SelectedItem));

			if (GetTrackListId(add.SelectedItem) == PckAudioFile.AudioTrackList.EAudioType.Creative)
			{
				playOverworldInCreative.Visible = true;
				playOverworldInCreative.Checked = false;
			}

			TreeNode treeNode = new TreeNode(GetTrackListFromId(trackList.AudioType), (int)trackList.AudioType, (int)trackList.AudioType);
			treeNode.Tag = trackList;
			trackListTreeView.Nodes.Add(treeNode);

			SetUpTree();
		}

		private void addTrack(PckAudioFile.AudioTrackList trackList, String trackname)
		{
            trackList.TrackNames.Add(trackname);
            trackTreeView.Nodes.Add(trackname);
        }

		private void addEntryMenuItem_Click(object sender, EventArgs e)
		{
			if (trackListTreeView.SelectedNode is TreeNode t && t.Tag is PckAudioFile.AudioTrackList trackList)
			{
				TextPrompt audioEntry = new TextPrompt();
				audioEntry.contextLabel.Text = "Please enter the relative file path without an extension. (i.e; \"music/track\" => \"DLC/{Pack}/Data/music/track.binka\")";
				audioEntry.LabelText = "Path";
				audioEntry.OKButtonText = "Add";
                if (audioEntry.ShowDialog() == DialogResult.OK)
				{
					addTrack(trackList, audioEntry.NewText);
				}
			}
		}

        private void editEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackListTreeView.SelectedNode is TreeNode t && t.Tag is PckAudioFile.AudioTrackList trackList && trackTreeView.SelectedNode is TreeNode track)
            {
                TextPrompt audioEntry = new TextPrompt(track.Text);
                audioEntry.contextLabel.Text = "Please enter the relative file path without an extension. (i.e; \"music/track\" => \"DLC/{Pack}/Data/music/track.binka\")";
                audioEntry.LabelText = "Path";
                audioEntry.OKButtonText = "Save";
                if (audioEntry.ShowDialog() == DialogResult.OK)
                {
                    int index = trackList.TrackNames.IndexOf(track.Text);
                    if (index != -1) // Check if the item was found
                    {
                        track.Text = trackList.TrackNames[index] = audioEntry.NewText;
                    }
                }
            }
        }

        private void removeTrackListStripMenuItem_Click(object sender, EventArgs e)
		{
			if (trackListTreeView.SelectedNode is TreeNode main &&
				EditorValue.RemoveTrackList(GetTrackListId(trackListTreeView.SelectedNode.Text)))
			{
				if(GetTrackListId(trackListTreeView.SelectedNode.Text) == PckAudioFile.AudioTrackList.EAudioType.Creative)
				{
					playOverworldInCreative.Visible = false;
					playOverworldInCreative.Checked = false;
				}
				trackTreeView.Nodes.Clear();
				main.Remove();
			}
		}

		private void trackListTreeView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
				removeTrackListStripMenuItem_Click(sender, e);
		}

		public void trackTreeView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
				removeEntryMenuItem_Click(sender, e);
		}

		private void removeEntryMenuItem_Click(object sender, EventArgs e)
		{
			if (trackTreeView.SelectedNode != null && trackListTreeView.SelectedNode.Tag is PckAudioFile.AudioTrackList trackList)
			{
				trackList.TrackNames.Remove(trackTreeView.SelectedNode.Text);
				trackTreeView.SelectedNode.Remove();
			}
		}

		private void Binka_DragDrop(object sender, DragEventArgs e)
		{
			if (trackListTreeView.SelectedNode is TreeNode t && t.Tag is PckAudioFile.AudioTrackList trackList)
			{
				foreach(String s in (string[])e.Data.GetData(DataFormats.FileDrop, false))
				{
                    addTrack(trackList, Path.GetFileNameWithoutExtension(s));
                }
			}
		}

		private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (!EditorValue.HasTrackList(PckAudioFile.AudioTrackList.EAudioType.Overworld) ||
			   !EditorValue.HasTrackList(PckAudioFile.AudioTrackList.EAudioType.Nether) ||
			   !EditorValue.HasTrackList(PckAudioFile.AudioTrackList.EAudioType.End))
			{
				MessageBox.Show(this, "Your changes were not saved. The game will crash when loading your pack if an Overworld, Nether and End track list don't all exist with at least one valid track.", "Mandatory Track Lists Missing");
				return;
			}

			PckAudioFile.AudioTrackList overworldTrackList = EditorValue.GetTrackList(PckAudioFile.AudioTrackList.EAudioType.Overworld);

			foreach (PckAudioFile.AudioTrackList trackList in EditorValue.TrackLists)
			{
				if (trackList.TrackNames.Count < 1)
				{
					MessageBox.Show(this, "The game will crash upon loading your pack if any of the track lists are empty. Please remove or occupy the track list.", "Empty Track List");
					return;
				}

				trackList.Name = "";
				if (playOverworldInCreative.Checked && trackList.AudioType == PckAudioFile.AudioTrackList.EAudioType.Creative)
				{
					foreach (var name in overworldTrackList.TrackNames)
					{
						if (!trackList.TrackNames.Contains(name))
						{
							trackList.TrackNames.Add(name);
							Console.WriteLine(name);
						}
					}
					trackList.Name = "include_overworld";
				}
			}

			Save();
			DialogResult = DialogResult.OK;
		}

		private void treeView2_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

        private void setTrackListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!(trackListTreeView.SelectedNode is TreeNode t && t.Tag is PckAudioFile.AudioTrackList trackList))
				return;

			string[] available = TrackLists.FindAll(str => !EditorValue.HasTrackList(GetTrackListId(str))).ToArray();
			if (available.Length > 0)
			{
				using ItemSelectionPopUp add = new ItemSelectionPopUp(available);
				add.ButtonText = "Save";
				if (add.ShowDialog(this) != DialogResult.OK)
					return;

				EditorValue.RemoveTrackList(trackList.AudioType);

				EditorValue.AddTrackList(trackList.parameterType, GetTrackListId(add.SelectedItem), trackList.AudioType == PckAudioFile.AudioTrackList.EAudioType.Overworld && playOverworldInCreative.Checked ? "include_overworld" : "");

                PckAudioFile.AudioTrackList newTrackList = EditorValue.GetTrackList(GetTrackListId(add.SelectedItem));

				trackList.TrackNames.ForEach(c => newTrackList.TrackNames.Add(c));

				SetUpTree();
			}
			else
			{
				MessageBox.Show(this, "There are no track lists that aren't already used", "All possible track lists are used");
			}
		}

        private void AudioEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (Settings.Default.AutoSaveChanges)
			{
				saveToolStripMenuItem1_Click(sender, EventArgs.Empty);
			}
        }

        private void trackTreeView_DoubleClick(object sender, EventArgs e) => editEntryToolStripMenuItem_Click(sender, e);

        private void bulkEditTracksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackListTreeView.SelectedNode is TreeNode t && t.Tag is PckAudioFile.AudioTrackList trackList)
            {
                using (var input = new MultiTextPrompt(trackList.TrackNames))
                {
                    if (input.ShowDialog(this) == DialogResult.OK)
                    {
                        trackTreeView.Nodes.Clear();
						trackList.TrackNames.Clear();

						foreach (String trackName in input.TextOutput)
						{
							addTrack(trackList, trackName);
						}
                    }
                }
            }
        }
    }
}
