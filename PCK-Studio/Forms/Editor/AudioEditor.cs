using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Diagnostics;
using NAudio.Wave;
using PckStudio.Forms.Additional_Popups;
using PckStudio.Properties;
using PckStudio.External.API.Miles;
using PckStudio.Core.Extensions;
using PckStudio.Internal.App;
using PckStudio.Controls;
using PckStudio.Interfaces;
using PckStudio.Core.FileFormats;

// Audio Editor by MayNL and Miku-666

namespace PckStudio.Forms.Editor
{
	public partial class AudioEditor : EditorForm<PckAudioFile>
	{
		public string defaultType = "yes";
        MainForm parent = null;

        private static readonly List<string> Categories = new List<string>
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
			 * Tracks and the "MG04_01.binka" file in it. The 9th category is MG04 - May
			 */
		};

        public AudioEditor(PckAudioFile audioFile, ISaveContext<PckAudioFile> saveContext)
			: base(audioFile, saveContext)
        {
            InitializeComponent();
            saveToolStripMenuItem1.Visible = !saveContext.AutoSave;
            SetUpTree();
        }

        private string GetCategoryFromId(PckAudioFile.AudioCategory.EAudioType categoryId)
			=> categoryId >= PckAudioFile.AudioCategory.EAudioType.Overworld &&
				categoryId <= PckAudioFile.AudioCategory.EAudioType.BuildOff
				? Categories[(int)categoryId]
				: "Not valid";

		private PckAudioFile.AudioCategory.EAudioType GetCategoryId(string category)
		{
			return (PckAudioFile.AudioCategory.EAudioType)Categories.IndexOf(category);
		}

		public void SetUpTree()
		{
			treeView1.BeginUpdate();
			treeView1.Nodes.Clear();

			foreach (PckAudioFile.AudioCategory category in EditorValue.Categories)
			{
				// fix songs with directories using backslash instead of forward slash
				// Songs with a backslash instead of a forward slash would not play in RPCS3
				foreach (string songname in category.SongNames.FindAll(s => s.Contains('\\')))
					category.SongNames[category.SongNames.IndexOf(songname)] = songname.Replace('\\', '/');

				if (category.AudioType == PckAudioFile.AudioCategory.EAudioType.Creative)
				{
					if (category.Name == "include_overworld" &&
                        EditorValue.TryGetCategory(PckAudioFile.AudioCategory.EAudioType.Overworld, out PckAudioFile.AudioCategory overworldCategory))
					{
						foreach (var name in category.SongNames.ToList())
						{
							if (overworldCategory.SongNames.Contains(name))
								category.SongNames.Remove(name);
						}
						playOverworldInCreative.Checked = true;
					}
					playOverworldInCreative.Visible = true;
				}

				TreeNode treeNode = new TreeNode(GetCategoryFromId(category.AudioType), (int)category.AudioType, (int)category.AudioType);
				treeNode.Tag = category;
				treeView1.Nodes.Add(treeNode);
			}
			playOverworldInCreative.Enabled = EditorValue.HasCategory(PckAudioFile.AudioCategory.EAudioType.Creative);
			treeView1.EndUpdate();
		}

		private void verifyFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/*
			if (treeView1.SelectedNode == null || treeView2.SelectedNode == null)
				return;
            TreeNode entry = treeView2.SelectedNode;

			string fileName = Path.Combine(parent., entry.Text + ".binka");

			if (File.Exists(fileName))
				MessageBox.Show(this, $"\"{entry.Text}.binka\" exists in the \"Data\" folder", "File found");
			else
				MessageBox.Show(this, $"\"{entry.Text}.binka\" does not exist in the \"Data\" folder. The game will crash when attempting to load this track.", "File missing");
			*/

			// Disabling this for now until location stuff is fixed
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			treeView2.Nodes.Clear();
			if (e.Node.Tag is PckAudioFile.AudioCategory category)
			{
				foreach (var name in category.SongNames)
				{
					treeView2.Nodes.Add(name);
				}
			}
			if (treeView2.Nodes.Count > 0)
				treeView2.SelectedNode = treeView2.Nodes[0];
		}

		private void addCategoryStripMenuItem_Click(object sender, EventArgs e)
		{
			string[] available = Categories.FindAll(str => !EditorValue.HasCategory(GetCategoryId(str))).ToArray();
			if (available.Length == 0)
			{
				MessageBox.Show(this, "There are no more categories that could be added", "All possible categories are used");
			}
			
			using ItemSelectionPopUp add = new ItemSelectionPopUp(available);
			if (add.ShowDialog(this) != DialogResult.OK)
				return;

			EditorValue.AddCategory(GetCategoryId(add.SelectedItem));
            PckAudioFile.AudioCategory category = EditorValue.GetCategory(GetCategoryId(add.SelectedItem));

			if (GetCategoryId(add.SelectedItem) == PckAudioFile.AudioCategory.EAudioType.Creative)
			{
				playOverworldInCreative.Visible = true;
				playOverworldInCreative.Checked = false;
			}

			TreeNode treeNode = new TreeNode(GetCategoryFromId(category.AudioType), (int)category.AudioType, (int)category.AudioType);
			treeNode.Tag = category;
			treeView1.Nodes.Add(treeNode);

			SetUpTree();
		}

		private void addTrack(PckAudioFile.AudioCategory category, String trackname)
		{
            category.SongNames.Add(trackname);
            treeView2.Nodes.Add(trackname);
        }

		private void addEntryMenuItem_Click(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode is TreeNode t && t.Tag is PckAudioFile.AudioCategory category)
			{
				TextPrompt audioEntry = new TextPrompt();
				audioEntry.contextLabel.Text = "Please enter the relative file path without an extension. (i.e; \"music/song\" => \"DLC/{Pack}/Data/music/song.binka\")";
				audioEntry.LabelText = "Path";
				audioEntry.OKButtonText = "Add";
                if (audioEntry.ShowDialog() == DialogResult.OK)
				{
					addTrack(category, audioEntry.NewText);
				}
			}
		}

        private void editEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode is TreeNode t && t.Tag is PckAudioFile.AudioCategory category && treeView2.SelectedNode is TreeNode track)
            {
                TextPrompt audioEntry = new TextPrompt(track.Text);
                audioEntry.contextLabel.Text = "Please enter the relative file path without an extension. (i.e; \"music/song\" => \"DLC/{Pack}/Data/music/song.binka\")";
                audioEntry.LabelText = "Path";
                audioEntry.OKButtonText = "Save";
                if (audioEntry.ShowDialog() == DialogResult.OK)
                {
                    int index = category.SongNames.IndexOf(track.Text);
                    if (index != -1) // Check if the item was found
                    {
                        track.Text = category.SongNames[index] = audioEntry.NewText;
                    }
                }
            }
        }

        private void removeCategoryStripMenuItem_Click(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode is TreeNode main &&
				EditorValue.RemoveCategory(GetCategoryId(treeView1.SelectedNode.Text)))
			{
				if(GetCategoryId(treeView1.SelectedNode.Text) == PckAudioFile.AudioCategory.EAudioType.Creative)
				{
					playOverworldInCreative.Visible = false;
					playOverworldInCreative.Checked = false;
				}
				treeView2.Nodes.Clear();
				main.Remove();
			}
		}

		private void treeView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
				removeCategoryStripMenuItem_Click(sender, e);
		}

		public void treeView2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
				removeEntryMenuItem_Click(sender, e);
		}

		private void removeEntryMenuItem_Click(object sender, EventArgs e)
		{
			if (treeView2.SelectedNode != null && treeView1.SelectedNode.Tag is PckAudioFile.AudioCategory category)
			{
				category.SongNames.Remove(treeView2.SelectedNode.Text);
				treeView2.SelectedNode.Remove();
			}
		}

		private void Binka_DragDrop(object sender, DragEventArgs e)
		{
			if (treeView1.SelectedNode is TreeNode t && t.Tag is PckAudioFile.AudioCategory category)
			{
				foreach(String s in (string[])e.Data.GetData(DataFormats.FileDrop, false))
				{
                    addTrack(category, Path.GetFileNameWithoutExtension(s));
                }
			}
		}

		private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (!EditorValue.HasCategory(PckAudioFile.AudioCategory.EAudioType.Overworld) ||
			   !EditorValue.HasCategory(PckAudioFile.AudioCategory.EAudioType.Nether) ||
			   !EditorValue.HasCategory(PckAudioFile.AudioCategory.EAudioType.End))
			{
				MessageBox.Show(this, "Your changes were not saved. The game will crash when loading your pack if the Overworld, Nether and End categories don't all exist with at least one valid song.", "Mandatory Categories Missing");
				return;
			}

			PckAudioFile.AudioCategory overworldCategory = EditorValue.GetCategory(PckAudioFile.AudioCategory.EAudioType.Overworld);

			bool songs_missing = false;
			foreach (PckAudioFile.AudioCategory category in EditorValue.Categories)
			{
				if (category.SongNames.Count < 1)
				{
					MessageBox.Show(this, "The game will crash upon loading your pack if any of the categories are empty. Please remove or occupy the category.", "Empty Category");
					return;
				}

				category.Name = "";
				if (playOverworldInCreative.Checked && category.AudioType == PckAudioFile.AudioCategory.EAudioType.Creative)
				{
					foreach (var name in overworldCategory.SongNames)
					{
						if (!category.SongNames.Contains(name))
						{
							category.SongNames.Add(name);
							Console.WriteLine(name);
						}
					}
					category.Name = "include_overworld";
				}
			}

			if (songs_missing)
			{
				MessageBox.Show(this, "Failed to save AudioData file because there are missing song entries", "Error");
				return;
			}

			Save();
			DialogResult = DialogResult.OK;
		}

		private void treeView2_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		private void AudioEditor_Shown(object sender, EventArgs e)
		{
			if (Owner.Owner is MainForm p)
				parent = p;
			else
				Close();
		}

		private void convertToWAVToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (treeView2.SelectedNode != null && treeView1.SelectedNode.Tag is PckAudioFile.AudioCategory)
			{
				//Binka.ToWav(Path.Combine(parent.GetDataPath(), treeView2.SelectedNode.Text + ".binka"), Path.Combine(parent.GetDataPath()));
			}
		}

		private void setCategoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!(treeView1.SelectedNode is TreeNode t && t.Tag is PckAudioFile.AudioCategory category))
				return;

			string[] available = Categories.FindAll(str => !EditorValue.HasCategory(GetCategoryId(str))).ToArray();
			if (available.Length > 0)
			{
				using ItemSelectionPopUp add = new ItemSelectionPopUp(available);
				add.ButtonText = "Save";
				if (add.ShowDialog(this) != DialogResult.OK)
					return;

				EditorValue.RemoveCategory(category.AudioType);

				EditorValue.AddCategory(category.parameterType, GetCategoryId(add.SelectedItem), category.AudioType == PckAudioFile.AudioCategory.EAudioType.Overworld && playOverworldInCreative.Checked ? "include_overworld" : "");

                PckAudioFile.AudioCategory newCategory = EditorValue.GetCategory(GetCategoryId(add.SelectedItem));

				category.SongNames.ForEach(c => newCategory.SongNames.Add(c));

				SetUpTree();
			}
			else
			{
				MessageBox.Show(this, "There are no categories that aren't already used", "All possible categories are used");
			}
		}

        private void AudioEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (Settings.Default.AutoSaveChanges)
			{
				saveToolStripMenuItem1_Click(sender, EventArgs.Empty);
			}
        }
    }
}
