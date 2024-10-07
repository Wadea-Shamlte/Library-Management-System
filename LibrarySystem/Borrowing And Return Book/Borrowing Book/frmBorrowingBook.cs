using LibrarySystem.People;
using LibrarySystem_Buisness;
using LibrarySystem_Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.Borrowing_And_Return_Book.Borrowing_Book
{
    public partial class frmBorrowingBook : Form
    {
        clsBLManagePeople _clsPeople;

        public frmBorrowingBook()
        {
            InitializeComponent();
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



        private void frmBorrowingBook_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            dateTimePickerDueDate.Value = dateTimePickerBorrowingDate.Value.AddDays(Convert.ToDouble(clsBLSetting.GetDefaultBorrowDays()));
        }




        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                if (!clsBLManagePeople.IsExist(int.Parse(txtFilter.Text.Trim())))
                {
                    MessageBox.Show("Error: The person is not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (clsBLManageBorrowingAndReturn.CheckBorrowingNumber(int.Parse(txtFilter.Text.Trim())) < 3)
                {
                    _LoadPersonData(int.Parse(txtFilter.Text.Trim()));
                    btnNext.Enabled = true;
                }
                else
                    MessageBox.Show("This person has 3 book Borrowing  and cannot get a 4th Borrowing .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!clsBLManagePeople.IsExist(txtFilter.Text.Trim()))
                {
                    MessageBox.Show("Error: The person is not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (clsBLManageBorrowingAndReturn.CheckBorrowingNumber(clsBLManagePeople.Find(txtFilter.Text.Trim()).PersonID) < 3)
                {
                    _LoadPersonData(txtFilter.Text.Trim());
                    btnNext.Enabled = true;
                }
                else
                    MessageBox.Show("This person has 3 book Borrowing  and cannot get a 4th Borrowing .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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


        private void btnNext_Click(object sender, EventArgs e)
        {
            tcInfo.SelectedIndex = 1;
            btnSave.Enabled = true;
        }


        private void btnGetCopyID_Click(object sender, EventArgs e)
        {
            frmListAvailableBook frm = new frmListAvailableBook();
            frm.DataBack += DataBackEventCopyID;

            frm.ShowDialog();
        }
        private void DataBackEventCopyID(object sender, int CopyID)
        {
            txtCopyID.Text = CopyID.ToString();
        }


        private void llShowNationalCardImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbPresonalID.Text == "N/A")
                return;

            Form frm = new frmShowNationalCardImage(_clsPeople.NationalCardImagePath);
            frm.ShowDialog();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Reset all fields?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                txtCopyID.Text = "";
                dateTimePickerBorrowingDate.Value = DateTime.Now;
                dateTimePickerDueDate.Value = dateTimePickerBorrowingDate.Value.AddDays(Convert.ToDouble(clsBLSetting.GetDefaultBorrowDays()));
                chkCustomize.Checked = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsBLManageBorrowingAndReturn _clsBLManageBorrowingAndReturn = new clsBLManageBorrowingAndReturn();

            if(string.IsNullOrEmpty(txtCopyID.Text.Trim())) 
            {
                MessageBox.Show("Warning: Copy ID cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!clsBLManageBookCopies.IsExist(int.Parse(txtCopyID.Text.Trim())))
            {
                MessageBox.Show("Error: The Copy ID you are trying to enter does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _clsBLManageBorrowingAndReturn.PersonID = int.Parse(lbPresonalID.Text.Trim());
            _clsBLManageBorrowingAndReturn.CopyID = int.Parse(txtCopyID.Text.Trim());
            _clsBLManageBorrowingAndReturn.BorrowingDate = dateTimePickerBorrowingDate.Value;
            _clsBLManageBorrowingAndReturn.DueDate = dateTimePickerDueDate.Value;
            _clsBLManageBorrowingAndReturn.ActualReturnDate = null;

            if(_clsBLManageBorrowingAndReturn.BorrowingRecord())
            {
                clsBLManageBookCopies clsCopy = clsBLManageBookCopies.Find(int.Parse(txtCopyID.Text.Trim()));
                if (clsCopy.UpdateCopyStatus(false))
                {
                    if (MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        this.Close();
                }else
                    MessageBox.Show("Error: Update copy status is not word.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (cbFilter.SelectedIndex == 0)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void txtCopyID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void chkCustomize_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerDueDate.Enabled = chkCustomize.Checked;
        }

        private void dateTimePickerBorrowingDate_ValueChanged(object sender, EventArgs e)
        {
            if (chkCustomize.Checked)
                return;
            dateTimePickerDueDate.Value = dateTimePickerBorrowingDate.Value.AddDays(Convert.ToDouble(clsBLSetting.GetDefaultBorrowDays()));
        }




    }
}
