using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entities;

namespace GUI
{
    public partial class GUI_LogIn : Form
    {
        private BLL_Account _bllAccount;
        private BLL_Employee _bllEmployee;

        public GUI_LogIn()
        {
            InitializeComponent();
            _bllAccount = new BLL_Account();
            _bllEmployee = new BLL_Employee();
        }

        private void btn_logIn_Click(object sender, EventArgs e)
        {
            string userName = txt_username.Text;
            string password = txt_password.Text;

            if (ValidateFormat())
            {
                Account account = _bllAccount.GetAccount(userName, password);

                if (account != null)
                {
                    MessageBox.Show("Đăng nhập thành công!");


                    GUI_Main mainForm = new GUI_Main(account);
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không tồn tại!");
                }
            }

        }

        private bool ValidateFormat()
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text))
            {
                MessageBox.Show("Please enter a username.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageBox.Show("Please enter a password.");
                return false;
            }
            return true;
        }


    }
}
