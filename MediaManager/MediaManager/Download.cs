using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;
using YoutubeExtractor;
using System.IO;
using System.Windows.Forms;

namespace MediaManager
{
    class Download
    {
        Label displayMessage;
        public Download(Label messageBox)
        {
            displayMessage = messageBox;
            string url = "https://stackoverflow.com/questions/37218330/await-task-not-returning-after-completion";
            try
            {
                string id = YoutubeClient.ParseVideoId(url);
                displayMessage.Text = "Now Downloading. . .";
                displayMessage.Text = Task.Run(async () => await downloadVideo(id)).GetAwaiter().GetResult();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: The YouTube URL you have entered is not valid, please enter a valid URL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<string> downloadVideo(string id)
        {
            var client = new YoutubeClient();
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);
            var streamInfo = streamInfoSet.Audio.WithHighestBitrate();
            await client.DownloadMediaStreamAsync(streamInfo, "downloaded_video.mp3");
            return "Finished Downloading!";
        }

    }
}
