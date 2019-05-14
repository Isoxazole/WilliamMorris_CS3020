using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace MediaManager
{

    class Download
    {
        Label displayMessage;
        Semaphore ThreadsAvailable;
        List<string> urls;
        string path;
        bool isDone;
        public Download(Label messageBox, List<string> urls, string path)
        {
            this.urls = urls;
            urls = urls.Distinct().ToList();
            displayMessage = messageBox;
            this.path = path;
            Directory.CreateDirectory(path);
            ThreadsAvailable = new Semaphore(5, 5);
            isDone = false;


        }//Download

        public void StartDownload(Label messageBox)
        {
            messageBox.Text = "Now downloading your " + urls.Count.ToString() + " songs";
            while (urls.Count > 0)
            {
                ThreadsAvailable.WaitOne();
                string url = urls[0];
                urls.RemoveAt(0);
                ThreadPool.QueueUserWorkItem(o => SetUpDownload(url));
            }
            int threadCount = 5;
            while (threadCount > 0)
            {
                ThreadsAvailable.WaitOne();
                --threadCount;
            }
            if (threadCount < 1)
            {
                messageBox.Text = "Finished downloading";
                isDone = true;
            }
        }

        public bool CheckDownload()
        {
            return isDone;
        }
        private void SetUpDownload(string url)
        {
            try
            {
                string id = YoutubeClient.ParseVideoId(url);
                //displayMessage.Text = "Now Downloading. . .";
                Task.Run(async () => await downloadVideo(id)).GetAwaiter().GetResult();
                ThreadsAvailable.Release();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: The YouTube URL you have entered is not valid, please enter a valid URL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                MessageBox.Show("Error: Please Check your Internet Connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async Task downloadVideo(string id)
        {
            var client = new YoutubeClient();
            var video = await client.GetVideoAsync(id);
            string title = video.Title;
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);
            var streamInfo = streamInfoSet.Audio.WithHighestBitrate();
            await client.DownloadMediaStreamAsync(streamInfo, Path.Combine(path,title + ".mp3"));
            return;
        }

    }
}
