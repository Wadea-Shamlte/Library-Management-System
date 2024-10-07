using LibrarySystem.People;
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

namespace LibrarySystem.User
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }


        private void _Refresh()
        {
            dgvListUsers.DataSource = clsBLManageUsers.GetAllData();

            lbNumOfRecord.Text = dgvListUsers.RowCount.ToString();

            dgvListUsers.Columns[2].Width = 250;

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "Is Active",
                Name = "IsActive",
                TrueValue = true,
                FalseValue = false
            };

            int columnIndex = dgvListUsers.Columns["IsActive"].Index;
            dgvListUsers.Columns.RemoveAt(columnIndex);
            dgvListUsers.Columns.Insert(columnIndex, checkBoxColumn);
        }


        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            cbFilter.Focus();
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

                case "Name":
                    FilterColumn = "FullName";
                    break;

                case "User ID":
                    FilterColumn = "UserID";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                (dgvListUsers.DataSource as DataTable).DefaultView.RowFilter = "";
                lbNumOfRecord.Text = dgvListUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID" || FilterColumn == "UserID")
                (dgvListUsers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                (dgvListUsers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lbNumOfRecord.Text = dgvListUsers.Rows.Count.ToString();
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
            if(cbFilter.Text == "Person ID" || cbFilter.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvListUsers_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonDetails((int)dgvListUsers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void dgvListUsers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvListUsers.IsCurrentCellDirty)
                dgvListUsers.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvListUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListUsers.Columns["IsActive"].Index && e.RowIndex >= 0)
            {
                clsBLManageUsers _clsBLUser = clsBLManageUsers.FindByByUserID((int)dgvListUsers.Rows[e.RowIndex].Cells["UserID"].Value);
                _clsBLUser.IsActive = (bool)dgvListUsers.Rows[e.RowIndex].Cells["IsActive"].Value;



                _clsBLUser.Update();
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditUser();
            frm.ShowDialog();

            _Refresh();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditUser((int)dgvListUsers.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _Refresh();

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditUser();

            frm.ShowDialog();

            _Refresh();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [ " + dgvListUsers.CurrentRow.Cells[0].Value + " ]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsBLManageUsers.Delete((int)dgvListUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Refresh();
                }

                else
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void callPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This service is not activated yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvListUsers.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _Refresh();
        }
    }
}
