using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CulinaryGuide
{
    public partial class RTBUC : UserControl
    {
        public RTBUC()
        {
            InitializeComponent();
            Width = Width;
            Height = (richTextBox.GetLineFromCharIndex(richTextBox.Text.Length) + 2) *
                        richTextBox.Font.Height + richTextBox.Margin.Vertical;
        }
        public RTBUC(int width, string text = "")
        {
            InitializeComponent();
            

        }
       
        public string getText()
        {
            return richTextBox.Text;
        }
        public void setText(string str)
        {
            richTextBox.Text = str;
        }

        private void richTextBox_TextChanged_1(object sender, EventArgs e)
        {
            Height = (richTextBox.GetLineFromCharIndex(richTextBox.Text.Length) + 2) *
                       richTextBox.Font.Height + richTextBox.Margin.Vertical;
        }
    }
}
