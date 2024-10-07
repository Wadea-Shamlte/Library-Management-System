using LibrarySystem.Books;
using LibrarySystem.Borrowing_And_Return_Book.Borrowing_Book;
using LibrarySystem.Borrowing_And_Return_Book.Return_Book;
using LibrarySystem.Fines;
using LibrarySystem.People;
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

namespace LibrarySystem.Borrowing_And_Return_Book
{
    public partial class frmManageBorrowingAndReturn : Form
    {
        public frmManageBorrowingAndReturn()
        {
            InitializeComponent();
        }


        private void _Refresh()
        {
            dgvListRecords.DataSource = clsBLManageBorrowingAndReturn.GetAllRecord();

            dgvListRecords.Columns[0].HeaderText = "Borrowing Record ID";
            dgvListRecords.Columns[0].Width = 140;

            dgvListRecords.Columns[1].HeaderText = "Name";
            dgvListRecords.Columns[1].Width = 200;

            dgvListRecords.Columns[2].HeaderText = "Book Title";
            dgvListRecords.Columns[2].Width = 150;

            dgvListRecords.Columns[3].HeaderText = "Borrowing Date";
            dgvListRecords.Columns[3].Width = 120;


            dgvListRecords.Columns[4].HeaderText = "Due Date";
            dgvListRecords.Columns[4].Width = 120;

            dgvListRecords.Columns[5].HeaderText = "Actual Return Date";
            dgvListRecords.Columns[5].Width = 120;

            dgvListRecords.Columns[6].HeaderText = "Fine Amount";
            dgvListRecords.Columns[6].Width = 110;

            lbNumOfRecord.Text = dgvListRecords.RowCount.ToString();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageBorrowingAndReturn_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _Refresh();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilter.Text)
            {
                case "Borrowing Record ID":
                    FilterColumn = "BorrowingRecordID";
                    break;

                case "Name":
                    FilterColumn = "FullName";
                    break;

                case "Title":
                    FilterColumn = "Title";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                (dgvListRecords.DataSource as DataTable).DefaultView.RowFilter = "";
                lbNumOfRecord.Text = dgvListRecords.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "BorrowingRecordID")
                (dgvListRecords.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                (dgvListRecords.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lbNumOfRecord.Text = dgvListRecords.Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Borrowing Record ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFilter.Text != "None");

            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmBorrowingBook frm = new frmBorrowingBook();

            frm.ShowDialog();

            _Refresh();
        }

        private void personDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmShowPersonDetails frm = new frmShowPersonDetails(clsBLManageBorrowingAndReturn._Find((int)dgvListRecords.CurrentRow.Cells[0].Value).PersonID);

            frm.ShowDialog();
        }

        private void bookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBLManageBookCopies _clsCopy = clsBLManageBookCopies.Find(clsBLManageBorrowingAndReturn._Find((int)dgvListRecords.CurrentRow.Cells[0].Value).CopyID);

            frmShowBookDetails frm = new frmShowBookDetails(_clsCopy.BookID);

            frm.ShowDialog();
        }

        private void borrowingDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBorrowingDetails frm = new frmBorrowingDetails((int)dgvListRecords.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            frmReturnBook frm = new frmReturnBook();

            frm.Show();

            _Refresh();
        }

        private void fineDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBLManageFines clsFine = clsBLManageFines.FindByBorrowingID((int)dgvListRecords.CurrentRow.Cells[0].Value);

            if (clsFine == null)
            {
                MessageBox.Show("Not found any fine on this record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmFineDetails frm = new frmFineDetails(clsFine.FineID);

            frm.ShowDialog();

            _Refresh();
        }
    }
}
