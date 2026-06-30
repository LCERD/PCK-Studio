using System;
using System.Collections.Generic;
using System.Linq;
using OMI.Formats.Languages;

namespace PckStudio.Core.FileFormats
{
    public class PckAudioFile
    {
		public class InvalidTrackListException : Exception
        {
			public InvalidTrackListException(string message) : base(message)
			{ }
		}

		public readonly int type = 1;

        public AudioTrackList[] TrackLists => Array.FindAll(_trackLists, c => c is not null);
        private AudioTrackList[] _trackLists { get; } = new AudioTrackList[9];

		public Dictionary<string, string> Credits { get; } = new Dictionary<string, string>();

		public class AudioTrackList
        {
			public enum EAudioType : int
			{
				Overworld,
				Nether,
				End,
				Creative,
				Menu,
				Battle,
				Tumble,
				Glide,
				BuildOff,
			}

			public enum EAudioParameterType : int
			{
				unk0, // dimension music
				unk1, // unused music ?
			}

			public string Name { get; set; } = string.Empty;
			public EAudioType AudioType { get; }
			public List<string> TrackNames { get;  } = new List<string>();
            public EAudioParameterType parameterType { get; }

			public AudioTrackList(string name, EAudioParameterType parameterType, EAudioType audioType)
			{
				this.Name = name;
				this.parameterType = parameterType;
				this.AudioType = audioType;
			}
		}

		public string[] GetCredits() => Credits.Values.ToArray();
		public string GetCreditsString() => string.Join("\n", Credits.Values.ToArray());

		public void AddCredits(params string[] credits)
        {
			foreach (var credit in credits)
            {
				AddCredit(credit);
			}
        }

		/// <summary>
		/// Applies internal Credits to loc file
		/// </summary>
		public void ApplyCredits(LOCFile locFile)
        {
            foreach (KeyValuePair<string, string> credit in Credits)
            {
				locFile.SetLocEntry(credit.Key, credit.Value);
            }
        }

		/// <summary>
		/// Clears and sets the new supplied <paramref name="credits"/>
		/// </summary>
		public void SetCredits(params string[] credits)
        {
			Credits.Clear();
			AddCredits(credits);
        }

		public bool SetCredit(string creditId, string s)
        {
			if (!Credits.ContainsKey(creditId))
				return false;
			Credits[creditId] = s;
			return true;
		}

		public void AddCredit(string credit)
		{
			Credits.Add($"IDS_CREDIT{(Credits.Count > 0 ? $"_{Credits.Count+1}" : string.Empty)}", credit);
		}

		public void AddCreditId(string creditId) => Credits.Add(creditId, string.Empty);


		/// <exception cref="InvalidTrackListException"></exception>
		public bool HasTrackList(AudioTrackList.EAudioType trackList) => GetTrackList(trackList) is AudioTrackList;

		/// <exception cref="InvalidTrackListException"></exception>
		public AudioTrackList GetTrackList(AudioTrackList.EAudioType trackList)
		{
			if (trackList < AudioTrackList.EAudioType.Overworld ||
				trackList > AudioTrackList.EAudioType.BuildOff)
				throw new InvalidTrackListException(nameof(trackList));
			return _trackLists[(int)trackList];
		}

		/// <exception cref="InvalidTrackListException"></exception>
		public bool TryGetTrackList(AudioTrackList.EAudioType trackList, out AudioTrackList audioTrackList)
        {
			if (GetTrackList(trackList) is AudioTrackList a)
            {
				audioTrackList = a;
				return true;
            }
			audioTrackList = null;
			return false;
        }

		/// <returns>True when track list was created, otherwise false</returns>
		/// <exception cref="InvalidTrackListException"></exception>
		public bool AddTrackList(AudioTrackList.EAudioParameterType parameterType, AudioTrackList.EAudioType trackList, string name = "")
		{
			if (trackList < AudioTrackList.EAudioType.Overworld ||
				trackList > AudioTrackList.EAudioType.BuildOff)
				throw new InvalidTrackListException(nameof(trackList));
			bool exists = HasTrackList(trackList);
			if (!exists)
				_trackLists[(int)trackList] = new AudioTrackList(name, parameterType, trackList);
			return !exists;
		}

		/// <returns>True when track list was created, otherwise false</returns>
		/// <exception cref="InvalidTrackListException"></exception>
		public bool AddTrackList(AudioTrackList.EAudioType trackList)
			=> AddTrackList(AudioTrackList.EAudioParameterType.unk0, trackList);

		/// <returns>True when track list was removed, otherwise false</returns>
		/// <exception cref="InvalidTrackListException"></exception>
		public bool RemoveTrackList(AudioTrackList.EAudioType trackList)
        {
			bool exists = HasTrackList(trackList);
			if (exists)
				_trackLists[(int)trackList] = null;
			return exists;
		}

	}
}
