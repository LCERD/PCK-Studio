using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Octokit;
using MetroFramework.Controls;
using System.Drawing;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using PckStudio.Internal;
using System.Drawing.Imaging;
using PckStudio.Internal.App;

namespace PckStudio.ToolboxItems
{
    public partial class GithubUserPanel : MetroUserControl
    {
        private Author _contributor;

        public GithubUserPanel()
        {
            InitializeComponent();
        }

        public GithubUserPanel(Author contributor) : this()
        {
            _contributor = contributor;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            Visible = false;
            Task.Run(LoadAuthor);
        }

        private void LoadAuthor()
        {
            // This should fix avatars not updating when changed on GitHub :3
            // Cache by stable user id, not by URL
            string cacheKey = $"gh-avatar-{_contributor.Id}";
            string cachedPath = ApplicationScope.DataCacher.GetCachedFilepath(cacheKey);

            // Refresh avatars periodically
            bool needsRefresh = true;
            if (ApplicationScope.DataCacher.HasFileCached(cacheKey))
            {
                try
                {
                    var age = DateTime.UtcNow - File.GetLastWriteTimeUtc(cachedPath);
                    needsRefresh = age > TimeSpan.FromDays(1); // refresh daily
                }
                catch
                {
                    needsRefresh = true;
                }
            }
            if (needsRefresh)
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
                    webClient.Headers.Add(HttpRequestHeader.Pragma, "no-cache");
                    webClient.Headers.Add(HttpRequestHeader.UserAgent, "PckStudio");

                    string url = _contributor.AvatarUrl;
                    string sep = url.Contains("?") ? "&" : "?";
                    string fetchUrl = url + sep + "cb=" + DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                    byte[] bytes = webClient.DownloadData(fetchUrl);
                    ApplicationScope.DataCacher.Cache(bytes, cacheKey);
                    cachedPath = ApplicationScope.DataCacher.GetCachedFilepath(cacheKey);
                }
            }

            // Load without locking the file on disk
            Image avatarUserImg;
            using (var fs = new FileStream(cachedPath, System.IO.FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var temp = Image.FromStream(fs))
            {
                avatarUserImg = (Image)temp.Clone();
            }

            Action setUiElements = () =>
            {
                userPictureBox.Image = avatarUserImg;
                userNameLabel.Text = _contributor.Login;
                aboutButton.Text = "Github profile";
                aboutButton.Click += (s, e) => Process.Start(_contributor.HtmlUrl);
                Visible = true;
            };

            if (InvokeRequired)
            {
                Invoke(setUiElements);
                return;
            }
            setUiElements();
        }
    }
}
