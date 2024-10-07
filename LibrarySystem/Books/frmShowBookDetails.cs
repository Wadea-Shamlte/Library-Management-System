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

namespace LibrarySystem.Books
{
    public partial class frmShowBookDetails : Form
    {
        int _BookID;

        public frmShowBookDetails(int BookID)
        {
            InitializeComponent();

            _BookID = BookID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowBookDetails_Load(object sender, EventArgs e)
        {
            clsBLManageBooks _clsBook = clsBLManageBooks.Find(_BookID);

            if (_clsBook != null)
            {
                lbBookID.Text = _BookID.ToString();
                lbTitle.Text = _clsBook.Title;
                lbISBN.Text = _clsBook.ISBN;
                lbPublicationDate.Text = _clsBook.PublicationDate.ToString("yyyy/MM/dd");
                lbGenre.Text = _clsBook.Genre;
                lbAdditionalDetails.Text = _clsBook.AdditionalDetails == "" || _clsBook.AdditionalDetails == null ? "There are no additional details." : _clsBook.AdditionalDetails;
            }
            else
                MessageBox.Show("Error: Not found any details for this item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
