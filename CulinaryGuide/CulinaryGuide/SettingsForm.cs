using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CulinaryGuide
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SettingsClass sc = new SettingsClass();
            sc.windowHeight = Int32.Parse(heightCB.Text);
            sc.windowWidth = Int32.Parse(widthCB.Text);
            sc.Rewrite();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            SettingsClass sc = new SettingsClass();
            heightCB.SelectedIndex = 0;
            widthCB.SelectedIndex = 0;
        }
    }
}
