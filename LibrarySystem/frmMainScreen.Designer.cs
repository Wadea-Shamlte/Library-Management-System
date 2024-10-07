namespace LibrarySystem
{
    partial class frmMainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addCopiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.addPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBorrowingAndReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.borrowingBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sginOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Wheat;
            this.menuStrip1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.manageOperationToolStripMenuItem,
            this.systemSettingToolStripMenuItem,
            this.accountSettingToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1070, 72);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managBookToolStripMenuItem,
            this.toolStripSeparator2,
            this.addCopiesToolStripMenuItem});
            this.bookToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.icons8_books_50;
            this.bookToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(107, 68);
            this.bookToolStripMenuItem.Text = "Books";
            // 
            // managBookToolStripMenuItem
            // 
            this.managBookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.addBookToolStripMenuItem});
            this.managBookToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.icons8_view_50;
            this.managBookToolStripMenuItem.Name = "managBookToolStripMenuItem";
            this.managBookToolStripMenuItem.Size = new System.Drawing.Size(169, 38);
            this.managBookToolStripMenuItem.Text = "Manag Book";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.icons8_address_book_100;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(157, 38);
            this.viewToolStripMenuItem.Text = "View Book";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // addBookToolStripMenuItem
            // 
            this.addBookToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.add_row;
            this.addBookToolStripMenuItem.Name = "addBookToolStripMenuItem";
            this.addBookToolStripMenuItem.Size = new System.Drawing.Size(157, 38);
            this.addBookToolStripMenuItem.Text = "Add Book";
            this.addBookToolStripMenuItem.Click += new System.EventHandler(this.addBookToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // addCopiesToolStripMenuItem
            // 
            this.addCopiesToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.icons8_add_book_48;
            this.addCopiesToolStripMenuItem.Name = "addCopiesToolStripMenuItem";
            this.addCopiesToolStripMenuItem.Size = new System.Drawing.Size(169, 38);
            this.addCopiesToolStripMenuItem.Text = "Add Copies";
            this.addCopiesToolStripMenuItem.Click += new System.EventHandler(this.addCopiesToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.BackColor = System.Drawing.Color.OldLace;
            this.peopleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vToolStripMenuItem,
            this.toolStripSeparator3,
            this.addPersonToolStripMenuItem});
            this.peopleToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.people;
            this.peopleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(102, 68);
            this.peopleToolStripMenuItem.Text = "People";
            // 
            // vToolStripMenuItem
            // 
            this.vToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.view;
            this.vToolStripMenuItem.Name = "vToolStripMenuItem";
            this.vToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.vToolStripMenuItem.Text = "View People";
            this.vToolStripMenuItem.Click += new System.EventHandler(this.vToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // addPersonToolStripMenuItem
            // 
            this.addPersonToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.addPerson;
            this.addPersonToolStripMenuItem.Name = "addPersonToolStripMenuItem";
            this.addPersonToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.addPersonToolStripMenuItem.Text = "Add Person";
            this.addPersonToolStripMenuItem.Click += new System.EventHandler(this.addPersonToolStripMenuItem_Click);
            // 
            // manageOperationToolStripMenuItem
            // 
            this.manageOperationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageBorrowingAndReturnToolStripMenuItem,
            this.toolStripSeparator1,
            this.borrowingBookToolStripMenuItem,
            this.returnBookToolStripMenuItem});
            this.manageOperationToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.ManadeOperation;
            this.manageOperationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageOperationToolStripMenuItem.Name = "manageOperationToolStripMenuItem";
            this.manageOperationToolStripMenuItem.Size = new System.Drawing.Size(187, 68);
            this.manageOperationToolStripMenuItem.Text = "Manage Operation ";
            // 
            // manageBorrowingAndReturnToolStripMenuItem
            // 
            this.manageBorrowingAndReturnToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.view_book_gif1;
            this.manageBorrowingAndReturnToolStripMenuItem.Name = "manageBorrowingAndReturnToolStripMenuItem";
            this.manageBorrowingAndReturnToolStripMenuItem.Size = new System.Drawing.Size(285, 38);
            this.manageBorrowingAndReturnToolStripMenuItem.Text = "Manage Borrowing and Return ";
            this.manageBorrowingAndReturnToolStripMenuItem.Click += new System.EventHandler(this.manageBorrowingAndReturnToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(282, 6);
            // 
            // borrowingBookToolStripMenuItem
            // 
            this.borrowingBookToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.icons8_book_philosophy_50;
            this.borrowingBookToolStripMenuItem.Name = "borrowingBookToolStripMenuItem";
            this.borrowingBookToolStripMenuItem.Size = new System.Drawing.Size(285, 38);
            this.borrowingBookToolStripMenuItem.Text = "Borrowing Book";
            this.borrowingBookToolStripMenuItem.Click += new System.EventHandler(this.borrowingBookToolStripMenuItem_Click);
            // 
            // returnBookToolStripMenuItem
            // 
            this.returnBookToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.icons8_return_book_50;
            this.returnBookToolStripMenuItem.Name = "returnBookToolStripMenuItem";
            this.returnBookToolStripMenuItem.Size = new System.Drawing.Size(285, 38);
            this.returnBookToolStripMenuItem.Text = "Return Book";
            this.returnBookToolStripMenuItem.Click += new System.EventHandler(this.returnBookToolStripMenuItem_Click);
            // 
            // systemSettingToolStripMenuItem
            // 
            this.systemSettingToolStripMenuItem.BackColor = System.Drawing.Color.OldLace;
            this.systemSettingToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.system_setting;
            this.systemSettingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.systemSettingToolStripMenuItem.Name = "systemSettingToolStripMenuItem";
            this.systemSettingToolStripMenuItem.Size = new System.Drawing.Size(176, 68);
            this.systemSettingToolStripMenuItem.Text = "System Setting";
            this.systemSettingToolStripMenuItem.Click += new System.EventHandler(this.systemSettingToolStripMenuItem_Click);
            // 
            // accountSettingToolStripMenuItem
            // 
            this.accountSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageUserToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator4,
            this.sginOutToolStripMenuItem});
            this.accountSettingToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.account_settings_64;
            this.accountSettingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accountSettingToolStripMenuItem.Name = "accountSettingToolStripMenuItem";
            this.accountSettingToolStripMenuItem.Size = new System.Drawing.Size(182, 68);
            this.accountSettingToolStripMenuItem.Text = "Account Setting";
            // 
            // manageUserToolStripMenuItem
            // 
            this.manageUserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewUserToolStripMenuItem,
            this.toolStripSeparator5,
            this.addUserToolStripMenuItem});
            this.manageUserToolStripMenuItem.Enabled = false;
            this.manageUserToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.ManageUser;
            this.manageUserToolStripMenuItem.Name = "manageUserToolStripMenuItem";
            this.manageUserToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.manageUserToolStripMenuItem.Text = "Manage User";
            // 
            // viewUserToolStripMenuItem
            // 
            this.viewUserToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.view;
            this.viewUserToolStripMenuItem.Name = "viewUserToolStripMenuItem";
            this.viewUserToolStripMenuItem.Size = new System.Drawing.Size(153, 38);
            this.viewUserToolStripMenuItem.Text = "View User";
            this.viewUserToolStripMenuItem.Click += new System.EventHandler(this.viewUserToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(150, 6);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.AddUser;
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(153, 38);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.Password;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(197, 6);
            // 
            // sginOutToolStripMenuItem
            // 
            this.sginOutToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.sign_out_32__2;
            this.sginOutToolStripMenuItem.Name = "sginOutToolStripMenuItem";
            this.sginOutToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.sginOutToolStripMenuItem.Text = "Sign Out";
            this.sginOutToolStripMenuItem.Click += new System.EventHandler(this.sginOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.OldLace;
            this.exitToolStripMenuItem.Image = global::LibrarySystem.Properties.Resources.icons8_exit_sign_50;
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 68);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibrarySystem.Properties.Resources.books_library_shelves_138556_1920x1080;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1070, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCopiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageBorrowingAndReturnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrowingBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem systemSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sginOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}