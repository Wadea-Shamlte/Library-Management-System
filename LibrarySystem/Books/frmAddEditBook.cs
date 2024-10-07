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
    public partial class frmAddEditBook : Form
    {
        int _BookID;

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode;

        clsBLManageBooks _clsBook;


        public frmAddEditBook()
        {
            InitializeComponent();
            Mode = enMode.AddNew;

        }

        public frmAddEditBook(int BookID)
        {
            InitializeComponent();

            _BookID = BookID;
            Mode = enMode.Update;
        }


        private void _LoadData()
        {
            if (Mode == enMode.AddNew)
            {
                lbPagetitle.Text = "Add New User";

                _clsBook = new clsBLManageBooks();
                return;
            }

            if (!clsBLManageBooks.IsExist(_BookID))
            {
                MessageBox.Show("Error: This Book data is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _clsBook = clsBLManageBooks.Find(_BookID);

            lbBookID.Text = _clsBook.BookID.ToString();
            txtTitle.Text = _clsBook.Title;
            txtISBN.Text = _clsBook.ISBN;
            dateTimePickerPublicationDate.Value = _clsBook.PublicationDate;
            txtGenre.Text = _clsBook.Genre;
            txtDetails.Text = _clsBook.AdditionalDetails;

            btnReset.Enabled = false;
        }

        private bool IsValidate()
        {
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtISBN.Text) || string.IsNullOrEmpty(txtGenre.Text))
            { return false; }
            else
                return true;
        }


        private void frmAddEditBook_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtISBN.Text = "";
            txtGenre.Text = "";
            txtDetails.Text = "";
            dateTimePickerPublicationDate.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!IsValidate())
            {
                MessageBox.Show("Some filed are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _clsBook.Title = txtTitle.Text;
            _clsBook.ISBN = txtISBN.Text;
            _clsBook.PublicationDate = dateTimePickerPublicationDate.Value;
            _clsBook.Genre = txtGenre.Text;
            _clsBook.AdditionalDetails = txtDetails.Text;


            if(_clsBook.Save())
            {
                if (MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    this.Close();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
