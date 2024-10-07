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

namespace LibrarySystem.BookCopy
{
    public partial class frmAddCopy : Form
    {
        int _BookID;

        public enum enMode { AddFromOut = 0, AddFromInSide = 1 };
        public enMode Mode;

        clsBLManageBookCopies _clsBookCopies = new clsBLManageBookCopies();

        public frmAddCopy()
        {
            InitializeComponent();

            Mode = enMode.AddFromOut;
        }

        public frmAddCopy(int BookID)
        {
            InitializeComponent();

            _BookID = BookID;
            Mode = enMode.AddFromInSide;

        }

        private void _Load()
        {
            if (Mode == enMode.AddFromOut)
            {
                return;
            }

            if (!clsBLManageBooks.IsExist(_BookID))
            {
                MessageBox.Show("Error: This Book data is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            txtBookID.Text = _BookID.ToString();
            txtBookID.Enabled = false;
        }



        private void frmAddCopies_Load(object sender, EventArgs e)
        {
            cbAvailableStatus.SelectedIndex = 1;

            _Load();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBookID.Enabled = true;
            txtBookID.Text = "";
            txtNumberOfCopuies.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some filed are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _clsBookCopies.BookID = int.Parse(txtBookID.Text);
            _clsBookCopies.AvailabilityStatus = cbAvailableStatus.SelectedIndex == 1 ? true : false;

            if (_clsBookCopies.AddCopies(int.Parse(txtNumberOfCopuies.Text.Trim())))
            {
                if (MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    this.Close();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void txtBookID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtNumberOfCopuies_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void txtBookID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBookID, "Book ID cannot be blank");
                return;
            }
            else if (!clsBLManageBooks.IsExist(int.Parse(txtBookID.Text.Trim())))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBookID, "This Book is not Exist.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtBookID, null);
            };
        }

        private void txtNumberOfCopuies_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumberOfCopuies.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNumberOfCopuies, "Number Of Copies cannot be blank");
                return;
            }
            else if (int.Parse(txtNumberOfCopuies.Text) < 1)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNumberOfCopuies, "Invalid value . Should be addition at least 1 copy.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNumberOfCopuies, null);
            };
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
