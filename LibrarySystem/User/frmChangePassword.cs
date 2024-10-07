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

namespace LibrarySystem.User
{
    public partial class frmChangePassword : Form
    {
        int _UserID;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            };

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some filed are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsBLManageUsers.ChangePassword(_UserID, txtNewPassword.Text))
            {
                if (MessageBox.Show("Password has been changed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    this.Close();
            }
            else
                MessageBox.Show("Error: Password has not been changed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPass, "Password cannot be blank");
                return;
            };

            if (txtPass.Text != clsBLManageUsers.FindByByUserID(_UserID).Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPass, "Current Password is not correct.");
                return;
            };

            errorProvider1.SetError(txtPass, null);
        }

    }
}
