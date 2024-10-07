using LibrarySystem.BookCopy;
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

namespace LibrarySystem.Books
{
    public partial class frmManageBooks : Form
    {
        public frmManageBooks()
        {
            InitializeComponent();
        }

        private void _Refresh()
        {
            dgvListBooks.DataSource = clsBLManageBooks.getAllDataBooks();

            lbNumOfRecord.Text = dgvListBooks.RowCount.ToString();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmManageBooks_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _Refresh();
        }


        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilter.Text)
            {
                case "Book ID":
                    FilterColumn = "BookID";
                    break;

                case "Title":
                    FilterColumn = "Title";
                    break;

                case "Genre":
                    FilterColumn = "Genre";
                    break;

                case "Available Copies":
                    FilterColumn = "AvailableCopies";
                    break;

                case "Full Copies":
                    FilterColumn = "FullCopies";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                (dgvListBooks.DataSource as DataTable).DefaultView.RowFilter = "";
                lbNumOfRecord.Text = dgvListBooks.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "BookID" || FilterColumn == "AvailableCopies" || FilterColumn == "FullCopies")
                (dgvListBooks.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                (dgvListBooks.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lbNumOfRecord.Text = dgvListBooks.Rows.Count.ToString();
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

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Book ID" || cbFilter.Text == "Available Copies" || cbFilter.Text == "Full Copies")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddEditBook frm = new frmAddEditBook();

            frm.ShowDialog();

            _Refresh();
        }


        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditBook addBook = new frmAddEditBook();

            addBook.ShowDialog();

            _Refresh();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditBook addBook = new frmAddEditBook((int)dgvListBooks.CurrentRow.Cells[0].Value);

            addBook.ShowDialog();

            _Refresh();
        }

        private void callPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCopy addBook = new frmAddCopy((int)dgvListBooks.CurrentRow.Cells[0].Value);

            addBook.ShowDialog();

            _Refresh();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Book [ " + dgvListBooks.CurrentRow.Cells[0].Value + " ]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsBLManageBooks.Delete((int)dgvListBooks.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Book Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Refresh();
                }

                else
                    MessageBox.Show("Error: Book was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPersonDetaileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowBookDetails frm = new frmShowBookDetails((int)dgvListBooks.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }
    }
}
