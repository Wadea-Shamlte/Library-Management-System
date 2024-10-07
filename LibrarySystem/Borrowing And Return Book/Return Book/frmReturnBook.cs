using LibrarySystem.Fines;
using LibrarySystem.People;
using LibrarySystem_Buisness;
using LibrarySystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.Borrowing_And_Return_Book.Return_Book
{
    public partial class frmReturnBook : Form
    {
        clsBLManagePeople _clsPeople;
        clsBLManageFines _clsFines;

        public frmReturnBook()
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

        private void _Refresh()
        {
            dgvListBorrowingBook.DataSource = clsBLManageBooks.GetBookBy(_clsPeople.PersonID);
        }

        private void _Reset()
        {
            lbBookTitle.Text = "[ ???? ]";
            dateTimePickerBorrowingDate.Value = DateTime.Now;
            dateTimePickerActualReturnDate.Value = DateTime.Now;
            btnReturn.Enabled = false;
            btnPayment.Visible = false;
            llShowFineDetails.Visible = false;
        }

        private void _Save()
        {
            clsBLManageBorrowingAndReturn _clsBorrowingRecord = clsBLManageBorrowingAndReturn._FindByCopyID((int)dgvListBorrowingBook.CurrentRow.Cells[1].Value);

            if (clsBLManageBookCopies.Find((int)dgvListBorrowingBook.CurrentRow.Cells[1].Value).UpdateCopyStatus(true))
            {
                _clsBorrowingRecord.ActualReturnDate = dateTimePickerActualReturnDate.Value;
                if (_clsBorrowingRecord.ReturnRecord())
                {
                    _Refresh();
                    if (MessageBox.Show("The return process was completed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        _Reset();
                }
                else
                    MessageBox.Show("Error: in ReturnRecord() function .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Error: in UpdateCopyStatus() function .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void frmReturnBook_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
        }


        


        private void btnGetData_Click(object sender, EventArgs e)
        {

            try
            {
                if (cbFilter.SelectedIndex == 0)
                {
                    if (!clsBLManagePeople.IsExist(int.Parse(txtFilter.Text.Trim())))
                    {
                        MessageBox.Show("Error: The person is not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (clsBLManageBorrowingAndReturn.CheckBorrowingNumber(int.Parse(txtFilter.Text.Trim())) >= 1)
                    {
                        _LoadPersonData(int.Parse(txtFilter.Text.Trim()));
                        _Refresh();
                        btnNext.Enabled = true;
                    }
                    else
                        MessageBox.Show("This person did not borrow any book.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!clsBLManagePeople.IsExist(txtFilter.Text.Trim()))
                    {
                        MessageBox.Show("Error: The person is not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (clsBLManageBorrowingAndReturn.CheckBorrowingNumber(clsBLManagePeople.Find(txtFilter.Text.Trim()).PersonID) >= 1)
                    {
                        _LoadPersonData(txtFilter.Text.Trim());
                        _Refresh();
                        btnNext.Enabled = true;
                    }
                    else
                        MessageBox.Show("This person did not borrow any book.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        
        private void llShowNationalCardImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbPresonalID.Text == "N/A")
                return;

            Form frm = new frmShowNationalCardImage(_clsPeople.NationalCardImagePath);
            frm.ShowDialog();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            tcInfo.SelectedIndex = 1;
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


        private void dgvListBorrowingBook_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {   
            lbBookTitle.Text = clsBLManageBooks.Find((int)dgvListBorrowingBook.CurrentRow.Cells[0].Value).Title;
            dateTimePickerBorrowingDate.Value = clsBLManageBorrowingAndReturn._FindByCopyID((int)dgvListBorrowingBook.CurrentRow.Cells[1].Value).BorrowingDate;
            btnReturn.Enabled = true;
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (clsBLManageBorrowingAndReturn._FindByCopyID((int)dgvListBorrowingBook.CurrentRow.Cells[1].Value).DueDate > dateTimePickerActualReturnDate.Value)
            {
                _Save();
            }
            else
            {
                MessageBox.Show("There is a fine on this book.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                int numberOfLateDays = Math.Max(0, dateTimePickerActualReturnDate.Value
                .Subtract(clsBLManageBorrowingAndReturn._FindByCopyID((int)dgvListBorrowingBook.CurrentRow.Cells[1].Value).DueDate).Days);
                
                _clsFines = new clsBLManageFines();

                _clsFines.PersonID = _clsPeople.PersonID;
                _clsFines.BorrowingRecordID = clsBLManageBorrowingAndReturn._FindByCopyID((int)dgvListBorrowingBook.CurrentRow.Cells[1].Value).BorrowingRecordID;
                _clsFines.NumberOfLateDays = (short)numberOfLateDays;
                _clsFines.FineAmount = numberOfLateDays * clsBLSetting.GetDefaultFinePerDay();
                _clsFines.PaymentStatus = false;

                if(_clsFines.AddFine())
                {
                    llShowFineDetails.Visible = true;
                    btnPayment.Visible = true;
                    btnReturn.Enabled = false;

                    frmFineDetails frm = new frmFineDetails(_clsFines.FineID);

                    frm.ShowDialog();

                }
            }
        }


        private void llShowFineDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFineDetails frm = new frmFineDetails(_clsFines.FineID);

            frm.ShowDialog();

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            clsBLManageFines _clsFine = clsBLManageFines.Find(_clsFines.FineID);
            if (_clsFine.UpdatePaymentStatus(true))
            {
                MessageBox.Show("The fine payment process was completed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Save();
            }
            else
                MessageBox.Show("Error in the fine payment process .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
