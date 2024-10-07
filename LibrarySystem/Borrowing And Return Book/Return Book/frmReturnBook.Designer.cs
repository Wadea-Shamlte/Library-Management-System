namespace LibrarySystem.Borrowing_And_Return_Book.Return_Book
{
    partial class frmReturnBook
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tcInfo = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.llShowNationalCardImage = new System.Windows.Forms.LinkLabel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lb1 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.lb5 = new System.Windows.Forms.Label();
            this.lbPresonalID = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lb7 = new System.Windows.Forms.Label();
            this.lbNationalNo = new System.Windows.Forms.Label();
            this.lbGender = new System.Windows.Forms.Label();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tpBookInfo = new System.Windows.Forms.TabPage();
            this.btnPayment = new System.Windows.Forms.Button();
            this.lbBookTitle = new System.Windows.Forms.Label();
            this.llShowFineDetails = new System.Windows.Forms.LinkLabel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.dgvListBorrowingBook = new System.Windows.Forms.DataGridView();
            this.dateTimePickerActualReturnDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBorrowingDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lbTitlePag = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.tcInfo.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tpBookInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBorrowingBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.tcInfo);
            this.panel1.Controls.Add(this.lbTitlePag);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 485);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::LibrarySystem.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(678, 446);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 28);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tcInfo
            // 
            this.tcInfo.Controls.Add(this.tpPersonInfo);
            this.tcInfo.Controls.Add(this.tpBookInfo);
            this.tcInfo.Location = new System.Drawing.Point(5, 128);
            this.tcInfo.Name = "tcInfo";
            this.tcInfo.SelectedIndex = 0;
            this.tcInfo.Size = new System.Drawing.Size(776, 312);
            this.tcInfo.TabIndex = 47;
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.Controls.Add(this.btnNext);
            this.tpPersonInfo.Controls.Add(this.groupBox1);
            this.tpPersonInfo.Controls.Add(this.gbFilter);
            this.tpPersonInfo.Controls.Add(this.pictureBox1);
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonInfo.Size = new System.Drawing.Size(768, 286);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Personal Info";
            this.tpPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.Enabled = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::LibrarySystem.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(678, 255);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(84, 25);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPhone);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.llShowNationalCardImage);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.lb1);
            this.groupBox1.Controls.Add(this.lb2);
            this.groupBox1.Controls.Add(this.lb3);
            this.groupBox1.Controls.Add(this.lb5);
            this.groupBox1.Controls.Add(this.lbPresonalID);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.lb7);
            this.groupBox1.Controls.Add(this.lbNationalNo);
            this.groupBox1.Controls.Add(this.lbGender);
            this.groupBox1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(215, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 167);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Person Info";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.BackColor = System.Drawing.Color.White;
            this.lbPhone.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.Color.Black;
            this.lbPhone.Location = new System.Drawing.Point(435, 103);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(50, 17);
            this.lbPhone.TabIndex = 72;
            this.lbPhone.Text = "[ ???? ]";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = global::LibrarySystem.Properties.Resources.id__1_;
            this.pictureBox5.Location = new System.Drawing.Point(123, 98);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(27, 22);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 71;
            this.pictureBox5.TabStop = false;
            // 
            // llShowNationalCardImage
            // 
            this.llShowNationalCardImage.AutoSize = true;
            this.llShowNationalCardImage.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNationalCardImage.Location = new System.Drawing.Point(342, 136);
            this.llShowNationalCardImage.Name = "llShowNationalCardImage";
            this.llShowNationalCardImage.Size = new System.Drawing.Size(172, 17);
            this.llShowNationalCardImage.TabIndex = 70;
            this.llShowNationalCardImage.TabStop = true;
            this.llShowNationalCardImage.Text = "Show National Card Image";
            this.llShowNationalCardImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowNationalCardImage_LinkClicked);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            this.pictureBox6.Image = global::LibrarySystem.Properties.Resources.Phone_32;
            this.pictureBox6.Location = new System.Drawing.Point(402, 98);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(27, 22);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 69;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Image = global::LibrarySystem.Properties.Resources.Person_32;
            this.pictureBox4.Location = new System.Drawing.Point(123, 135);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(27, 22);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 68;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = global::LibrarySystem.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(123, 24);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 67;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.White;
            this.pictureBox9.Image = global::LibrarySystem.Properties.Resources.Person_32;
            this.pictureBox9.Location = new System.Drawing.Point(123, 61);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(27, 22);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 66;
            this.pictureBox9.TabStop = false;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.BackColor = System.Drawing.Color.White;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.ForeColor = System.Drawing.Color.Black;
            this.lb1.Location = new System.Drawing.Point(22, 30);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(100, 16);
            this.lb1.TabIndex = 57;
            this.lb1.Text = "Personal ID : ";
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.BackColor = System.Drawing.Color.White;
            this.lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2.ForeColor = System.Drawing.Color.Black;
            this.lb2.Location = new System.Drawing.Point(37, 65);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(85, 16);
            this.lb2.TabIndex = 58;
            this.lb2.Text = "FullName : ";
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.BackColor = System.Drawing.Color.White;
            this.lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb3.ForeColor = System.Drawing.Color.Black;
            this.lb3.Location = new System.Drawing.Point(21, 100);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(101, 16);
            this.lb3.TabIndex = 59;
            this.lb3.Text = "National No : ";
            // 
            // lb5
            // 
            this.lb5.AutoSize = true;
            this.lb5.BackColor = System.Drawing.Color.White;
            this.lb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb5.ForeColor = System.Drawing.Color.Black;
            this.lb5.Location = new System.Drawing.Point(52, 135);
            this.lb5.Name = "lb5";
            this.lb5.Size = new System.Drawing.Size(70, 16);
            this.lb5.TabIndex = 60;
            this.lb5.Text = "Gender : ";
            // 
            // lbPresonalID
            // 
            this.lbPresonalID.AutoSize = true;
            this.lbPresonalID.BackColor = System.Drawing.Color.White;
            this.lbPresonalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPresonalID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbPresonalID.Location = new System.Drawing.Point(160, 30);
            this.lbPresonalID.Name = "lbPresonalID";
            this.lbPresonalID.Size = new System.Drawing.Size(33, 16);
            this.lbPresonalID.TabIndex = 65;
            this.lbPresonalID.Text = "N/A";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.White;
            this.lbName.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbName.Location = new System.Drawing.Point(160, 65);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(57, 20);
            this.lbName.TabIndex = 64;
            this.lbName.Text = "[ ???? ]";
            // 
            // lb7
            // 
            this.lb7.AutoSize = true;
            this.lb7.BackColor = System.Drawing.Color.White;
            this.lb7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb7.ForeColor = System.Drawing.Color.Black;
            this.lb7.Location = new System.Drawing.Point(342, 99);
            this.lb7.Name = "lb7";
            this.lb7.Size = new System.Drawing.Size(63, 16);
            this.lb7.TabIndex = 61;
            this.lb7.Text = "Phone : ";
            // 
            // lbNationalNo
            // 
            this.lbNationalNo.AutoSize = true;
            this.lbNationalNo.BackColor = System.Drawing.Color.White;
            this.lbNationalNo.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNationalNo.ForeColor = System.Drawing.Color.Black;
            this.lbNationalNo.Location = new System.Drawing.Point(160, 104);
            this.lbNationalNo.Name = "lbNationalNo";
            this.lbNationalNo.Size = new System.Drawing.Size(50, 17);
            this.lbNationalNo.TabIndex = 63;
            this.lbNationalNo.Text = "[ ???? ]";
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.BackColor = System.Drawing.Color.White;
            this.lbGender.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGender.ForeColor = System.Drawing.Color.Black;
            this.lbGender.Location = new System.Drawing.Point(160, 140);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(50, 17);
            this.lbGender.TabIndex = 62;
            this.lbGender.Text = "[ ???? ]";
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnGetData);
            this.gbFilter.Controls.Add(this.btnAddNewPerson);
            this.gbFilter.Controls.Add(this.cbFilter);
            this.gbFilter.Controls.Add(this.pictureBox2);
            this.gbFilter.Controls.Add(this.txtFilter);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(215, 6);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(547, 70);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnGetData
            // 
            this.btnGetData.BackgroundImage = global::LibrarySystem.Properties.Resources.SearchPerson;
            this.btnGetData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGetData.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGetData.Enabled = false;
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetData.Location = new System.Drawing.Point(471, 27);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(31, 34);
            this.btnGetData.TabIndex = 3;
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackgroundImage = global::LibrarySystem.Properties.Resources.Add_Person_40;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPerson.Location = new System.Drawing.Point(510, 27);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(31, 34);
            this.btnAddNewPerson.TabIndex = 4;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "Person ID",
            "National No."});
            this.cbFilter.Location = new System.Drawing.Point(127, 36);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(159, 23);
            this.cbFilter.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LibrarySystem.Properties.Resources.Person_32;
            this.pictureBox2.Location = new System.Drawing.Point(91, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(292, 39);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(173, 20);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter By:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibrarySystem.Properties.Resources.man;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tpBookInfo
            // 
            this.tpBookInfo.Controls.Add(this.btnPayment);
            this.tpBookInfo.Controls.Add(this.lbBookTitle);
            this.tpBookInfo.Controls.Add(this.llShowFineDetails);
            this.tpBookInfo.Controls.Add(this.btnReturn);
            this.tpBookInfo.Controls.Add(this.dgvListBorrowingBook);
            this.tpBookInfo.Controls.Add(this.dateTimePickerActualReturnDate);
            this.tpBookInfo.Controls.Add(this.dateTimePickerBorrowingDate);
            this.tpBookInfo.Controls.Add(this.label5);
            this.tpBookInfo.Controls.Add(this.label4);
            this.tpBookInfo.Controls.Add(this.label3);
            this.tpBookInfo.Controls.Add(this.pictureBox8);
            this.tpBookInfo.Location = new System.Drawing.Point(4, 22);
            this.tpBookInfo.Name = "tpBookInfo";
            this.tpBookInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpBookInfo.Size = new System.Drawing.Size(768, 286);
            this.tpBookInfo.TabIndex = 1;
            this.tpBookInfo.Text = "Book Info :";
            this.tpBookInfo.UseVisualStyleBackColor = true;
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnPayment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.Black;
            this.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayment.Location = new System.Drawing.Point(638, 218);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(110, 28);
            this.btnPayment.TabIndex = 84;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Visible = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // lbBookTitle
            // 
            this.lbBookTitle.AutoSize = true;
            this.lbBookTitle.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookTitle.Location = new System.Drawing.Point(463, 169);
            this.lbBookTitle.Name = "lbBookTitle";
            this.lbBookTitle.Size = new System.Drawing.Size(58, 21);
            this.lbBookTitle.TabIndex = 83;
            this.lbBookTitle.Text = "[ ???? ]";
            // 
            // llShowFineDetails
            // 
            this.llShowFineDetails.AutoSize = true;
            this.llShowFineDetails.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowFineDetails.LinkColor = System.Drawing.Color.MediumOrchid;
            this.llShowFineDetails.Location = new System.Drawing.Point(627, 249);
            this.llShowFineDetails.Name = "llShowFineDetails";
            this.llShowFineDetails.Size = new System.Drawing.Size(145, 21);
            this.llShowFineDetails.TabIndex = 8;
            this.llShowFineDetails.TabStop = true;
            this.llShowFineDetails.Text = "Show Fine Details";
            this.llShowFineDetails.Visible = false;
            this.llShowFineDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowFineDetails_LinkClicked);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReturn.Enabled = false;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.Black;
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(638, 169);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(110, 28);
            this.btnReturn.TabIndex = 7;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // dgvListBorrowingBook
            // 
            this.dgvListBorrowingBook.AllowUserToAddRows = false;
            this.dgvListBorrowingBook.AllowUserToDeleteRows = false;
            this.dgvListBorrowingBook.BackgroundColor = System.Drawing.Color.MediumOrchid;
            this.dgvListBorrowingBook.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvListBorrowingBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListBorrowingBook.Location = new System.Drawing.Point(292, 6);
            this.dgvListBorrowingBook.Name = "dgvListBorrowingBook";
            this.dgvListBorrowingBook.ReadOnly = true;
            this.dgvListBorrowingBook.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvListBorrowingBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListBorrowingBook.Size = new System.Drawing.Size(470, 150);
            this.dgvListBorrowingBook.TabIndex = 82;
            this.dgvListBorrowingBook.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListBorrowingBook_CellMouseDoubleClick);
            // 
            // dateTimePickerActualReturnDate
            // 
            this.dateTimePickerActualReturnDate.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerActualReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerActualReturnDate.Location = new System.Drawing.Point(463, 227);
            this.dateTimePickerActualReturnDate.Name = "dateTimePickerActualReturnDate";
            this.dateTimePickerActualReturnDate.Size = new System.Drawing.Size(145, 22);
            this.dateTimePickerActualReturnDate.TabIndex = 6;
            // 
            // dateTimePickerBorrowingDate
            // 
            this.dateTimePickerBorrowingDate.Enabled = false;
            this.dateTimePickerBorrowingDate.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerBorrowingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBorrowingDate.Location = new System.Drawing.Point(463, 198);
            this.dateTimePickerBorrowingDate.Name = "dateTimePickerBorrowingDate";
            this.dateTimePickerBorrowingDate.Size = new System.Drawing.Size(145, 22);
            this.dateTimePickerBorrowingDate.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(319, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 21);
            this.label5.TabIndex = 78;
            this.label5.Text = "Borrowing Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(295, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 21);
            this.label4.TabIndex = 77;
            this.label4.Text = "Actual Return Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(362, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 21);
            this.label3.TabIndex = 74;
            this.label3.Text = "Book Title :";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            this.pictureBox8.Image = global::LibrarySystem.Properties.Resources.IssueBookss;
            this.pictureBox8.Location = new System.Drawing.Point(-4, 0);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(290, 290);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 1;
            this.pictureBox8.TabStop = false;
            // 
            // lbTitlePag
            // 
            this.lbTitlePag.AutoSize = true;
            this.lbTitlePag.Font = new System.Drawing.Font("Ebrima", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitlePag.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbTitlePag.Location = new System.Drawing.Point(368, 43);
            this.lbTitlePag.Name = "lbTitlePag";
            this.lbTitlePag.Size = new System.Drawing.Size(190, 40);
            this.lbTitlePag.TabIndex = 45;
            this.lbTitlePag.Text = "Return Book";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::LibrarySystem.Properties.Resources.image_processing20191025_19942_14gi0n7;
            this.pictureBox7.Location = new System.Drawing.Point(254, 3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(115, 119);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 46;
            this.pictureBox7.TabStop = false;
            // 
            // frmReturnBook
            // 
            this.AcceptButton = this.btnGetData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReturnBook";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Book";
            this.Load += new System.EventHandler(this.frmReturnBook_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tcInfo.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tpBookInfo.ResumeLayout(false);
            this.tpBookInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBorrowingBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tcInfo;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.LinkLabel llShowNationalCardImage;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Label lb5;
        private System.Windows.Forms.Label lbPresonalID;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lb7;
        private System.Windows.Forms.Label lbNationalNo;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tpBookInfo;
        private System.Windows.Forms.DateTimePicker dateTimePickerActualReturnDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerBorrowingDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lbTitlePag;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.DataGridView dgvListBorrowingBook;
        private System.Windows.Forms.LinkLabel llShowFineDetails;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lbBookTitle;
        private System.Windows.Forms.Button btnPayment;
    }
}