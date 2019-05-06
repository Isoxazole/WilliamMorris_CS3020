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
        public Form1()
        {
            InitializeComponent();
            Button[] buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button button in buttons)
            {
                button.Text = "";

            }
            label1.Text = "Find an opponent to start!";
            button10.Text = "Find new Opponent";

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
