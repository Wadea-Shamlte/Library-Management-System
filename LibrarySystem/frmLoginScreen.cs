using LibrarySystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }



        private void txtUsername_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text.Trim() == "Username")
                txtUsername.Clear();
        }

        private void txtPassword_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text.Trim() == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '*' ;
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsBLManageUsers _clsUser = clsBLManageUsers.GetUserInfoByUsernameAndPassword(txtUsername.Text, txtPassword.Text);

            if (_clsUser != null)
            {
                clsSetting.CurrantUser = txtUsername.Text;
                frmMainScreen frm = new frmMainScreen(txtUsername.Text , txtPassword.Text);

                frm.Show();
                this.Hide();

                frm.FormClosed += (s, args) => this.Close();
            }
            else
                MessageBox.Show("Error: Invalid Username / Password !", "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
                
        }

        private void btnVisitor_Click(object sender, EventArgs e)
        {
            frmMainScreen frm = new frmMainScreen("1" , "1");

            frm.Show();
            this.Hide();

            frm.FormClosed += (s, args) => this.Close();
        }
    }
}
