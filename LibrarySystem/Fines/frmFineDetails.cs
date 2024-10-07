using LibrarySystem.Properties;
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

namespace LibrarySystem.Fines
{
    public partial class frmFineDetails : Form
    {
        int _FineID;

        public frmFineDetails(int FineID)
        {
            InitializeComponent();

            _FineID = FineID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFineDetails_Load(object sender, EventArgs e)
        {
            clsBLManageFines clsFine = clsBLManageFines.Find(_FineID);

            if (clsFine != null)
            {
                lbFineID.Text = clsFine.FineID.ToString();
                lbBorrowingID.Text = clsFine.BorrowingRecordID.ToString();
                lbPersonID.Text = clsFine.PersonID.ToString();
                lbPersonName.Text = clsBLManagePeople.Find(clsFine.PersonID).FullName;
                lbNumberOfLateDays.Text = clsFine.NumberOfLateDays.ToString();
                lbFineAmount.Text = clsFine.FineAmount.ToString();
                if(clsFine.PaymentStatus)
                {
                    lbPaymentStatus.Text = "Paid";
                    pbPaymentStatus.Image = Resources.Passed;
                }
                else
                    pbPaymentStatus.Image = Resources.Question_32;
            }
            else
                MessageBox.Show("Error: Not found any details for this item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
