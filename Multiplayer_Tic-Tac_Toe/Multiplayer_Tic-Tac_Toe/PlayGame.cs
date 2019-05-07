using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Multiplayer_Tic_Tac_Toe
{
    class PlayGame
    {
        Button[,] table = new Button[3, 3];
        Label label;
        TcpClient connection;
        bool gameOver;
        public int userChoice = 0;
        public int playerTurn = 1;
        string symbol = "";
        string opponentSymbol = "";
        public PlayGame(Button[] buttons, Label messageBox)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j< 3; j++)
                {
                    table[i, j] = buttons[i * 3 + j];
                }
            }
            label = messageBox;
        }
        public void Start(int playerNumber, TcpClient connection)
        {
            this.connection = connection;
            Task.Factory.StartNew(() => ListenForPacket());
            if (playerNumber == 1)
            {
                setMessage("It's your turn");
                symbol = "X";
                opponentSymbol = "O";
            }
            else
            {
                setMessage("It's your opponent's turn");
                symbol = "O";
                opponentSymbol = "X";
            }
             gameOver = false;

            
        }

        private void setMessage(string message)
        {
            label.Text = message;
        }

        public void senderTurn(int num)
        {
            try
            {
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(num.ToString());
                connection.GetStream().Write(bytesToSend, 0, bytesToSend.Length);
            }
            catch (System.NullReferenceException)
            {
                setMessage("Error, please connect to opponent!");
            }

        }

        public void markButton(int i)
        {
            int x = i / 3;
            int y = i - x * 3;
            table[x, y].Text = symbol;
            if (checkEndGame(x, y))
            {
                gameOver = true;
                announceWinner("you");
            }
            playerTurn = 2;
            setMessage("It's your opponent's turn");
        }

        private void markButtonOpponent(int i)
        {
            int x = i / 3;
            int y = i - x * 3;
            table[x, y].Text = opponentSymbol;
            playerTurn = 1;
            if (checkEndGame(x, y))
            {
                gameOver = true;
                announceWinner("your Opponent");
            }
            setMessage("It's your turn");
        }

        private void ListenForPacket()
        {
            try
            {
                NetworkStream stream = connection.GetStream();
                while (true)
                {
                    byte[] bytesToRead = new byte[connection.ReceiveBufferSize];
                    int bytesRead = stream.Read(bytesToRead, 0, connection.ReceiveBufferSize);
                    string result = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                    if (result != "")
                    {
                        markButtonOpponent(int.Parse(result));
                    }
                }
            }
            catch (SocketException)
            {
                setMessage("Error with connection has occred");
            }

        }

        private void announceWinner(string winner)
        {
            setMessage("The winner is " + winner + " !");
            playerTurn = 2;
            
        }

        private bool checkEndGame(int x, int y)
        {
            //check row
            for (int i = 0; i < 3; i++)
            {
                if (table[i, y].Text != symbol)
                {
                    break;
                }
                if (i == 2)
                {
                    return true;
                }
            }

            //check column
            
            for (int i = 0; i < 3; i ++)
            {
                if (table[x,i].Text != symbol)
                {
                    break;
                }
                if (i == 2)
                {
                    return true;
                }
            }

            //check diagonal
            if (x == y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (table[i,i].Text != symbol)
                    {
                        break;
                    }
                    if (i == 2)
                    {
                        return true;
                    }
                }
            }

            //check other diagonal
            if (x + y == 2)
            {
                for (int i = 0; i < 3; i ++)
                {
                    if (table[i, 2-i].Text != symbol)
                    {
                        break;
                    }
                    if (i == 2)
                    {
                        return true;
                    }
                }
            }

            //check if draw
            bool notFinished = true;
            foreach(Button button in table)
            {
                if (button.Text == "")
                {
                    notFinished = false;
                }
            }
            if (notFinished)
            {
                gameOver = true;
                announceWinner("a Tie");
            }
            return false;

        }

    }
}