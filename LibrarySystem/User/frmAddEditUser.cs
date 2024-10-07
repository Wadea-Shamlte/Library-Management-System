using LibrarySystem.People;
using LibrarySystem.Properties;
using LibrarySystem_Buisness;
using LibrarySystem_Business;
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
    public partial class frmAddEditUser : Form
    {
        int _UserID;

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode;

        clsBLManageUsers _clsUser;
        clsBLManagePeople _clsPeople;

        public frmAddEditUser()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
        }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            Mode = enMode.Update;

        }


        private void _LoadPersonData(int PersonID)
        {
            _clsPeople = clsBLManagePeople.Find(PersonID);

            lbPresonalID.Text = _clsPeople.PersonID.ToString();
            lbName.Text = _clsPeople.FullName;
            lbNationalNo.Text = _clsPeople.NationalNo;
            lbGender.Text = _clsPeople.Gender == 0 ? "Male" : "Female";
            lbPhone.Text = _clsPeople.Phone;
        }

        private void _LoadPersonData(string NationalNo)
        {
            _clsPeople = clsBLManagePeople.Find(NationalNo);

            lbPresonalID.Text = _clsPeople.PersonID.ToString();
            lbName.Text = _clsPeople.FullName;
            lbNationalNo.Text = _clsPeople.NationalNo;
            lbGender.Text = _clsPeople.Gender == 0 ? "Male" : "Female";
            lbPhone.Text = _clsPeople.Phone;
        }

        private void _LoadData()
        {
            if (Mode == enMode.AddNew)
            {
                lbTitlePag.Text = "Add New User";
                this.Text = "Add New User";

                cbFilter.SelectedIndex = 0;
                cbPermeation.SelectedIndex = 1;

                _clsUser = new clsBLManageUsers();
                return;
            }

            if (!clsBLManagePeople.IsExist(_UserID))
            {
                MessageBox.Show("Error: This User's data is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gbFilter.Enabled = false;
            btnReset.Enabled = false;
            btnSave.Enabled = true;

            this.Text = "Edit User Info";

            _clsUser = clsBLManageUsers.FindByByUserID(_UserID);

            lbUserID.Text = _clsUser.UserID.ToString();
            txtUserName.Text = _clsUser.UserName;
            cbPermeation.SelectedIndex = _clsUser.Permeation ? 0 : 1;
            txtPassword.Text = _clsUser.Password;
            txtConfirmPassword.Text = _clsUser.Password;
            chkIsActive.Checked = _clsUser.IsActive;

            _LoadPersonData(_clsUser.PersonID);

        }


        

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            
            _LoadData();
        }


        private void llShowNationalCardImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(lbPresonalID.Text != "N/A")
            {
                Form frm = new frmShowNationalCardImage(_clsPeople.NationalCardImagePath);
                frm.ShowDialog();
            }
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            tcInfo.SelectedIndex = 1;
            btnSave.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to Reset all fields?" , "Question", MessageBoxButtons.OKCancel , MessageBoxIcon.Question) == DialogResult.OK)
            {
                tcInfo.SelectedIndex = 0;
                cbFilter.SelectedIndex = 0;
                txtFilter.Text = "";
                btnGetData.Enabled = false;
                lbPresonalID.Text = "N/A";
                lbNationalNo.Text = "[ ???? ]";
                lbName.Text = "[ ???? ]";
                lbGender.Text = "[ ???? ]";
                lbPhone.Text = "[ ???? ]";
                btnNext.Enabled = false;
                txtUserName.Text = "";
                cbPermeation.SelectedIndex = 1;
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                chkIsActive.Checked = false;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some filed are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _clsUser.PersonID = int.Parse(lbPresonalID.Text);
            _clsUser.UserName = txtUserName.Text;
            _clsUser.Permeation = cbPermeation.SelectedIndex == 0 ? true : false;
            _clsUser.Password = txtPassword.Text;
            _clsUser.IsActive = chkIsActive.Checked;

            if(_clsUser.Save())
            {
                if (MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    this.Close();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }


        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            };


            if (Mode == enMode.AddNew)
            {

                if (clsBLManageUsers.IsExistByUserName(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                };
            }
            else
            {
                if (_clsUser.UserName != txtUserName.Text.Trim())
                {
                    if (clsBLManageUsers.IsExistByUserName(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    };
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilter.Text.Trim()))
            {
                btnGetData.Enabled = true;
            }
            else
                { btnGetData.Enabled = false; }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilter.SelectedIndex == 0)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }


        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                if(!clsBLManagePeople.IsExist(int.Parse(txtFilter.Text.Trim())))
                {
                    MessageBox.Show("Error: The person is not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!clsBLManageUsers.IsExistByPersonID(int.Parse(txtFilter.Text.Trim())))
                {
                    _LoadPersonData(int.Parse(txtFilter.Text.Trim()));
                    btnNext.Enabled = true;
                }
                else
                    MessageBox.Show("The person you are trying to add is already a user. Try another person.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!clsBLManagePeople.IsExist(txtFilter.Text.Trim()))
                {
                    MessageBox.Show("Error: The person is not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!clsBLManageUsers.IsExistByPersonID(clsBLManagePeople.Find(txtFilter.Text.Trim()).PersonID))
                {
                    _LoadPersonData(txtFilter.Text.Trim());
                    btnNext.Enabled = true;
                }
                else
                    MessageBox.Show("The person you are trying to add is already a user. Try another person.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text )
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }



        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.DataBack += DataBackEvent; 

            frm.ShowDialog();
        }
        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilter.SelectedIndex = 0;
            txtFilter.Text = PersonID.ToString();

            _LoadPersonData(PersonID);
            btnNext.Enabled = true;
        }
    }
}
