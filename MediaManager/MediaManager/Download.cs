using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace MediaManager
{

    class Download
    {
        Label displayMessage;
        SemaphoreSlim ThreadsAvailable;
        List<string> urls;
        string path;
        public Download(Label messageBox, List<string> urls, string path)
        {
            this.urls = urls.Distinct().ToList();
            displayMessage = messageBox;
            this.path = path;
            Directory.CreateDirectory(path);
            ThreadsAvailable = new SemaphoreSlim(5);


        }//Download

        public void SetUpDownload(Label messageBox)
        {
            messageBox.Text = "Now downloading your " + urls.Count.ToString() + " songs . . .";
            List<string> videoIds = new List<string>();
            for (int i = 0; i < urls.Count; i ++)
            {
                try
                {
                    string id = YoutubeClient.ParseVideoId(urls[i]);
                    videoIds.Add(id);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error: The YouTube URL you have entered, " + urls[i].ToString() + ", is not valid, please enter a valid URL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    MessageBox.Show("Error: Please Check your Internet Connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            urls.Clear();       // Clear the URSL list
            Task.Run(async () => await downloadVideo(videoIds)).Wait();
            messageBox.Text = "Finished Downloading!";

        }
        private async Task downloadVideo(List<string> ids)
        {
            List<Task> trackedTasks = new List<Task>();
            Regex pattern = new Regex("[\\/:*?\"<>|]");
            foreach(string id in ids)
            {
                await ThreadsAvailable.WaitAsync();
                trackedTasks.Add(Task.Run( async() =>
                    {
                        var client = new YoutubeClient();
                        var video = await client.GetVideoAsync(id);
                        string title = pattern.Replace(video.Title,"♫");        // Regex to replace 
                        var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);
                        var streamInfo = streamInfoSet.Audio.WithHighestBitrate();
                        await client.DownloadMediaStreamAsync(streamInfo, Path.Combine(path, title + ".mp3"));
                        
                    }));
                ThreadsAvailable.Release();
            }
            await Task.WhenAll(trackedTasks);

        }// async method to download the youtube music

    }
}
