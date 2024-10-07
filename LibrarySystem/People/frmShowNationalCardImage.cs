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
    public partial class frmShowNationalCardImage : Form
    {
        string _Image;

        public frmShowNationalCardImage(string ImagePath)
        {
            InitializeComponent();

            _Image = ImagePath;
        }

        private void frmShowNationalCardImage_Load(object sender, EventArgs e)
        {
            if(_Image != null && _Image != "")
            {
                lbNotFound.Visible = false;
                pbNationalCard.Load(_Image);
            }
            else
            {
                pbNationalCard.Visible = false;
                lbNotFound.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
