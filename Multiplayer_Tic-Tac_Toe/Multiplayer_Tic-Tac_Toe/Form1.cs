using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiplayer_Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        Button[] buttons;
        PlayGame newGame;
        public Form1()
        {
            
            InitializeComponent();
            buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            for (int i = 0; i < 9; i++)
            {
                int x = i;
                buttons[i].Text = "";
                buttons[i].Click += (o, e) => ButtonClick(x);

            }
            label1.Text = "Find an opponent to start!";
            button10.Text = "Find new Opponent";

             newGame = new PlayGame(buttons, label1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Connection newForm = new Connection();
            newForm.ShowDialog();
            newGame.Start(newForm.player, newForm.connection);
        }

        public void ButtonClick(int i)
        {
            try
            {
                if (newGame.playerTurn == 1 && buttons[i].Text == "")
                {
                    newGame.markButton(i);
                    newGame.senderTurn(i);
                }
            }
            catch (ArgumentNullException ex)
            {
                label1.Text = "Error, please find opponent first";
            }

        }
    }
}
