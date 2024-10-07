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

namespace LibrarySystem.Borrowing_And_Return_Book.Borrowing_Book
{
    public partial class frmBorrowingDetails : Form
    {
        int _BorrowingID;

        public frmBorrowingDetails(int BorrowingID)
        {
            InitializeComponent();

            _BorrowingID = BorrowingID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBorrowingDetails_Load(object sender, EventArgs e)
        {
            clsBLManageBorrowingAndReturn _clsBorrowing = clsBLManageBorrowingAndReturn._Find(_BorrowingID);

            if (_clsBorrowing != null)
            {
                lbBorrowingID.Text = _clsBorrowing.BorrowingRecordID.ToString();
                lbCopyID.Text = _clsBorrowing.CopyID.ToString();
                lbPersonID.Text = _clsBorrowing.PersonID.ToString() ;
                lbPersonName.Text = clsBLManagePeople.Find(_clsBorrowing.PersonID).FullName;
                lbBorrowingDate.Text = _clsBorrowing.BorrowingDate.ToString("yyyy/MM/dd");
                lbDueDate.Text = _clsBorrowing.DueDate.ToString("yyyy/MM/dd");
                lbActualReturnDate.Text = _clsBorrowing.ActualReturnDate != null ? _clsBorrowing.ActualReturnDate.ToString() : "Not returned yet.";

            }
            else
                MessageBox.Show("Error: Not found any details for this item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
