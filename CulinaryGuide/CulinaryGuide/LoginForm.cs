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
    public partial class LoginForm : Form
    {
        public MainForm main_form;
        public LoginForm()
        {
            InitializeComponent();
        }
        public LoginForm(MainForm _mf)
        {
            InitializeComponent();
            main_form = _mf;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string login = loginTxt.Text;
            string password = passwordTxt.Text;

            UserClass new_user = main_form.db.GetUserByLoginPassword(login, password);
            if (new_user!=null)
            {
                main_form.user = new_user;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин/пароль");
            }
        }

        private void registrationBtn_Click(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm(this);
            Hide();
            rf.ShowDialog();
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
