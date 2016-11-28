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
    public partial class SmartLabelUC : UserControl
    {
        bool canRemove;
        public int itemId;
        public string firstWord;
        public string secondWord;
        public SmartLabelUC()
        {
            InitializeComponent();
            canRemove = false;
            itemId = -1;
        }
        public SmartLabelUC(string _firstWord, bool _canRemove = false,int _idOfSmth=-1,string _secondWord="",int  maxWidth=-1)
        {
            InitializeComponent();
            canRemove = _canRemove;
            firstWord = _firstWord;
            secondWord = _secondWord;
            linkLabel1.Text = firstWord;
            if (secondWord!="")
                linkLabel2.Text = "("+secondWord+")";
            else
                linkLabel2.Text = "";

            linkLabel1.AutoSize = true;
            itemId = _idOfSmth;
            if (maxWidth != -1)
                linkLabel1.MaximumSize = new Size(maxWidth,0) ;
        }

        public void setSize(Size size)
        {
            Size = size;
        }
        private void IngridientUC_Load(object sender, EventArgs e)
        {

        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (canRemove)
            {
                Parent.Controls.Remove(this);

            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (canRemove)
            {
                Parent.Controls.Remove(this);
            }
        }
    }
}
