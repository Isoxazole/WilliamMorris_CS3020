using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaManager
{
    public partial class MultiURLs : Form
    {
        public List<string> urls = new List<string>();
        public MultiURLs()
        {
            InitializeComponent();
        }

        private void MultiURLs_Load(object sender, EventArgs e)
        {
            TextBoxURLs.ScrollBars = ScrollBars.Both;
            TextBoxURLs.WordWrap = false;
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TextBoxURLs.Lines.Length; i++)
            {
                urls.Add(TextBoxURLs.Lines[i]);
            }
            Close();
            
        }
    }
}
