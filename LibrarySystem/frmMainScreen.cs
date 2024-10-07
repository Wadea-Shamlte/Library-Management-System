using LibrarySystem.BookCopy;
using LibrarySystem.Books;
using LibrarySystem.Borrowing_And_Return_Book;
using LibrarySystem.Borrowing_And_Return_Book.Borrowing_Book;
using LibrarySystem.Borrowing_And_Return_Book.Return_Book;
using LibrarySystem.People;
using LibrarySystem.System_Setting;
using LibrarySystem.User;
using LibrarySystem_Buisness;
using System;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frmMainScreen : Form
    {
        string _CurrenUser;
        string _Password;

        public frmMainScreen(string CurrenUser , string Password)
        {
            InitializeComponent();

            _CurrenUser = CurrenUser;
            _Password = Password;
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            if (_CurrenUser == "1" && _Password == "1")
                return;
            if (clsBLManageUsers.GetUserInfoByUsernameAndPassword(_CurrenUser, _Password).Permeation)
                manageUserToolStripMenuItem.Enabled = true;
        }


        private void systemSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSystemSetting frm = new frmSystemSetting();

            frm.ShowDialog();

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageBooks frm = new frmManageBooks();

            frm.ShowDialog();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditBook frm = new frmAddEditBook();

            frm.ShowDialog();
        }


        private void addCopiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCopy frm = new frmAddCopy();

            frm.ShowDialog();
        }


        private void vToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();

            frm.ShowDialog();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();

            frm.ShowDialog();
        }


        private void manageBorrowingAndReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageBorrowingAndReturn frm = new frmManageBorrowingAndReturn();

            frm.ShowDialog();
        }

        private void borrowingBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBorrowingBook frm = new frmBorrowingBook();

            frm.ShowDialog();
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReturnBook();

            frm.Show();

        }

        

        private void viewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();

            frm.ShowDialog();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();

            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsBLManageUsers.GetUserInfoByUsernameAndPassword(_CurrenUser , _Password).UserID);

            frm.ShowDialog();
        }


        private void sginOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginScreen frm = new frmLoginScreen();

            frm.Show();
            this.Hide();

            frm.FormClosed += (s, args) => this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
