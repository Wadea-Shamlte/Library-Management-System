using LibrarySystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.Borrowing_And_Return_Book.Borrowing_Book
{
    public partial class frmListAvailableBook : Form
    {
        public delegate void DataBackEventHandler(object sender, int CopyID);

        public event DataBackEventHandler DataBack;

        clsBLManageBooks _clsBooks;
        clsBLManageBookCopies _clsCopy;

        public frmListAvailableBook()
        {
            InitializeComponent();
        }


        private void _Refresh()
        {
            dgvListBooks.DataSource = clsBLManageBooks.getAvailableBookData();

            lbNumOfRecord.Text = dgvListBooks.RowCount.ToString();
        }

        private void _LoadData(int BookID)
        {
            
            _clsCopy = new clsBLManageBookCopies();

            if(!_clsCopy.GetCopyIdForAvailableCopy(BookID))
            {
                MessageBox.Show("This book has no copies available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            _clsBooks = clsBLManageBooks.Find(BookID);

            lbBookID.Text = _clsBooks.BookID.ToString();
            lbBookTitle.Text = _clsBooks.Title;
            lbISBN.Text = _clsBooks.ISBN;
            lbGenre.Text = _clsBooks.Genre;
            lbCopyID.Text = _clsCopy.CopyID.ToString();
            
        }




        private void frmListAvailableBook_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            btnSelect.Enabled = false;
            _Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListBooks_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _LoadData((int)dgvListBooks.CurrentRow.Cells[0].Value);

            btnSelect.Enabled = true;
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


            if (FilterColumn == "BookID" || FilterColumn == "AvailableCopies")
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
            if (cbFilter.Text == "Book ID" || cbFilter.Text == "Available Copies")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _clsCopy.CopyID);
            this.Close();
        }
    }
}
