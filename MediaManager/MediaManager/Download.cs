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
using YoutubeExplode.Converter;

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
            ThreadsAvailable = new SemaphoreSlim(3);


        }//Download


        //Set up the youtube download by getting all the video ids and putting them in a list.
        //Also check for any invalid urls.
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

        }//SetUpDownload

        //Asyncronously downloads all the youtube videos and saves them to the path based on the directory selected earlier and the name of song.
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
                        var converter = new YoutubeConverter(client);
                        var video = await client.GetVideoAsync(id);
                        string title = pattern.Replace(video.Title,"♫");        // Regex to replace 
                        var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);
                        var streamInfo = streamInfoSet.Audio.WithHighestBitrate();
                        var ext = streamInfo.Container.GetFileExtension();
                        //await client.DownloadMediaStreamAsync(streamInfo, Path.Combine(path, $"{title}.{ext}"));
                        await converter.DownloadVideoAsync(id, Path.Combine(path,  $"{title}.mp3"));
                    }));
                ThreadsAvailable.Release();
            }
            await Task.WhenAll(trackedTasks);

        }// async method to download youtube music

    }//class Download
}
