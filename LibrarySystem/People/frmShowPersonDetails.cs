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
    public partial class frmShowPersonDetails : Form
    {
        int _PersonID;
        clsBLManagePeople _clsPerson;

        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }


        private void _LoadData()
        {
            _clsPerson = clsBLManagePeople.Find(_PersonID);

            lbPresonalID.Text = _clsPerson.PersonID.ToString();
            lbName.Text = _clsPerson.FullName;
            lbNationalNo.Text = _clsPerson.NationalNo;
            lbGender.Text = _clsPerson.Gender == 0 ? "Male" : "Female";
            lbPhone.Text = _clsPerson.Phone;

        }



        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void llShowNationalCardImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowNationalCardImage(_clsPerson.NationalCardImagePath);
            frm.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
