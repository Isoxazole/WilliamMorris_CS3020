using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Multiplayer_Tic_Tac_Toe
{
    public partial class Connection : Form
    {
        public TcpClient connection;
        public int player = 0;
        public Connection()
        {
            InitializeComponent();
        }

        private void Connection_Load(object sender, EventArgs e)
        {
            string publicIP = new WebClient().DownloadString("http://ipv4.icanhazip.com"); 
            string localIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
            label2.Text = "Public IP: " + publicIP + "\n" + "Local IP: " + localIP;
        }
        //private void AddToMessageBox(string s)
        //{
        //    //Must invoke as delegate due to cross thread work
        //    this.Invoke(new MethodInvoker(delegate
        //    {
        //        TextBoxDisplayInfo.AppendText(s + "\n");
        //    }));
        //}

            private void ListenForPacket(TcpClient singleConnection)
            {
            try
            {
                NetworkStream stream = singleConnection.GetStream();
                while (true)
                {
                    byte[] bytesToRead = new byte[singleConnection.ReceiveBufferSize];
                    int bytesRead = stream.Read(bytesToRead, 0, singleConnection.ReceiveBufferSize);
                    string result = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                    if (result == "Connected")
                    {
                        TextBoxDisplayInfo.AppendText("Game found, connection successful, enjoy your game!");
                        player = 1;
                        System.Threading.Thread.Sleep(2000);
                        Close();
                    }
                    else if (result != "")
                    {
                        TextBoxDisplayInfo.AppendText(result);
                    }
                }
            }
            catch (SocketException)
            {
                TextBoxDisplayInfo.AppendText("Error has occured with connection");

            }
                

            }

        private async void Button_OpenConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    textBox1.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
                }
                connection = new TcpClient(textBox1.Text, 5555);
                TextBoxDisplayInfo.AppendText("Sending Ping Connection");
                player = 2;
            }
            catch
            {
                TextBoxDisplayInfo.AppendText("No listener found, opening listener.");
                TcpListener listener = new TcpListener(Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork), 5555);
                listener.Start();
                connection = await listener.AcceptTcpClientAsync();
                await Task.Factory.StartNew(() => ListenForPacket(connection));
                listener.Stop();
                return;
            }
            TextBoxDisplayInfo.AppendText("Game found, connection successful, enjoy your game!");
            SendMessage(connection, "Connected");
            System.Threading.Thread.Sleep(2000);
            Close();
            return;
            //await Task.Factory.StartNew(() => ListenForPacket(connection));
        }
        private void SendMessage(TcpClient singleConnection, string s)
        {
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(s);
            singleConnection.GetStream().Write(bytesToSend, 0, bytesToSend.Length);
        }
    }
}
