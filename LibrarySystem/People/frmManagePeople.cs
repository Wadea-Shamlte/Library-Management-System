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

namespace LibrarySystem.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _Refresh()
        {
            dgvListPeople.DataSource = clsBLManagePeople.GetAllData();

            lbNumOfRecord.Text = dgvListPeople.RowCount.ToString();
        }



        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _Refresh();
        }


        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                (dgvListPeople.DataSource as DataTable).DefaultView.RowFilter = "";
                lbNumOfRecord.Text = dgvListPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                (dgvListPeople.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                (dgvListPeople.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lbNumOfRecord.Text = dgvListPeople.Rows.Count.ToString();
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
            if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void dgvListPeople_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonDetails((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditPerson();
            frm.ShowDialog();

            _Refresh();
        }


        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditPerson();
            frm.ShowDialog();

            _Refresh();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditPerson((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _Refresh();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvListPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsBLManagePeople.Delete((int)dgvListPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Refresh();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void callPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This service is not activated yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonDetails((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _Refresh();
        }
    }
}
