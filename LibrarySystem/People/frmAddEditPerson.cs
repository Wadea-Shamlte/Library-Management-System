using LibrarySystem.Properties;
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
    public partial class frmAddEditPerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        int _PersonID;
        string _ImagePath;
        clsBLManagePeople _clsPeople;

        public frmAddEditPerson()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
        }

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            Mode = enMode.Update;
            _PersonID = PersonID;
        }

        private void _LoadData()
        {
            if (Mode == enMode.AddNew)
            {
                lbTitlePag.Text = "Add Person";
                _clsPeople = new clsBLManagePeople();
                return;
            }

            if(!clsBLManagePeople.IsExist(_PersonID))
            {
                MessageBox.Show("Error: This person's data is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _clsPeople = clsBLManagePeople.Find(_PersonID);

            txtFName.Text = _clsPeople.FName;
            txtSName.Text = _clsPeople.SName;
            txtThName.Text = _clsPeople.ThName;
            txtLName.Text = _clsPeople.LName;

            txtNationalNo.Text = _clsPeople.NationalNo;
            if (_clsPeople.Gender == 0)
            {
                rbMale.Checked = true;
                rbFemale.Checked = false;
            }
            else
            {
                rbFemale.Checked = true;
                rbMale.Checked = false;
            }

            txtPhone.Text = _clsPeople.Phone;
            if (_clsPeople.NationalCardImagePath == null || _clsPeople.NationalCardImagePath == "")
            {
                if (rbMale.Checked) { pbNationalCardImage.Image = Resources.Male_512; }
                else
                    pbNationalCardImage.Image = Resources.Female_512;
                _ImagePath = null;
            }
            else
            {
                _ImagePath = _clsPeople.NationalCardImagePath;
                pbNationalCardImage.Load(_ImagePath);
            }

            llRemoveImage.Visible = (_ImagePath != null);

            btnReset.Enabled = false;
        }

        private void _ResetData()
        {
            txtFName.Text = "";
            txtSName.Text = "";
            txtThName.Text = "";
            txtLName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            rbFemale.Checked = false;
            txtPhone.Text = "";
            pbNationalCardImage.Image = Resources.Male_512;
            _ImagePath = null;
            llRemoveImage.Visible = false;
        }

        private void _SetError(TextBox textBox)
        {
            errorProvider1.SetError(textBox, "This field is required!.");
        }
            
        private bool _Validate()
        {
            if (string.IsNullOrEmpty(txtFName.Text))
            {
                _SetError(txtFName);
                return false;
            }
            else if(string.IsNullOrEmpty(txtSName.Text))
            {
                _SetError(txtSName);
                return false;
            }
            else if (string.IsNullOrEmpty(txtLName.Text))
            {
                _SetError(txtLName);
                return false;
            }
            else if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                _SetError(txtNationalNo);
                return false;
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                _SetError(txtPhone);
                return false;
            }
            else
            {
                errorProvider1.Clear();
                return true;
            }
        }

   


        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (_ImagePath == null || _ImagePath == "")
                pbNationalCardImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (_ImagePath == null || _ImagePath == "")
                pbNationalCardImage.Image = Resources.Female_512;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _ImagePath = openFileDialog1.FileName;
                pbNationalCardImage.Load(_ImagePath);
                llRemoveImage.Visible = true;
            }
            _clsPeople.NationalCardImagePath = _ImagePath;
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _clsPeople.NationalCardImagePath = null;

            if (rbMale.Checked)
                pbNationalCardImage.Image = Resources.Male_512;
            else
                pbNationalCardImage.Image = Resources.Female_512;

            llRemoveImage.Visible = false;
            _ImagePath = null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _ResetData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!_Validate())
            {
                MessageBox.Show("Error: Some filed are not valid!, put the mouse over the red icon(s) to see the error.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _clsPeople.FName = txtFName.Text.Trim();
            _clsPeople.SName = txtSName.Text.Trim();
            _clsPeople.ThName  = txtThName.Text.Trim();
            _clsPeople.LName = txtLName.Text.Trim();
            _clsPeople.NationalNo = txtNationalNo.Text.Trim();
            _clsPeople.Gender = rbMale.Checked ? 0 : 1;
            _clsPeople.Phone = txtPhone.Text.Trim();
            
            if(_clsPeople.Save())
            {
                MessageBox.Show("The save process is Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetData();
                DataBack?.Invoke(this, _clsPeople.PersonID);
            }
            else
                MessageBox.Show("Error: The save process is failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
