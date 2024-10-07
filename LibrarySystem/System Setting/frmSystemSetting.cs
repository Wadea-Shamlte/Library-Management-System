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

namespace LibrarySystem.System_Setting
{
    public partial class frmSystemSetting : Form
    {
        public frmSystemSetting()
        {
            InitializeComponent();
        }

        private void frmSystemSetting_Load(object sender, EventArgs e)
        {
            txtDefaultBorrowDays.Text = clsBLSetting.GetDefaultBorrowDays().ToString();
            txtDefaultFinePerDay.Text = clsBLSetting.GetDefaultFinePerDay().ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(clsBLSetting.UpdateDefaultBorrowDays(decimal.Parse(txtDefaultBorrowDays.Text)))
            {
                if (clsBLSetting._UpdateDefaultFinePerDay(decimal.Parse(txtDefaultFinePerDay.Text)))
                    MessageBox.Show("The save process has been successfully." , "Information", MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
