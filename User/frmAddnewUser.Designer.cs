namespace Bank_Project
{
    partial class frmAddnewUser
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlPersonWithFiltter1 = new Bank_Project.ctrlPersonWithFiltter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GBPermetions = new System.Windows.Forms.GroupBox();
            this.pListClients = new System.Windows.Forms.CheckBox();
            this.pManageUsers = new System.Windows.Forms.CheckBox();
            this.pUpdateClients = new System.Windows.Forms.CheckBox();
            this.pAddNewClient = new System.Windows.Forms.CheckBox();
            this.eAll = new System.Windows.Forms.CheckBox();
            this.PLogs = new System.Windows.Forms.CheckBox();
            this.pPeopleList = new System.Windows.Forms.CheckBox();
            this.PDeleteClient = new System.Windows.Forms.CheckBox();
            this.pTransactions = new System.Windows.Forms.CheckBox();
            this.CHKIsActive = new System.Windows.Forms.CheckBox();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lbConfirmPassword = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.LbUserID2 = new System.Windows.Forms.Label();
            this.LBUserID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbAddnewUser = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.GBPermetions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(837, 392);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlPersonWithFiltter1);
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(829, 360);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User Info ";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // ctrlPersonWithFiltter1
            // 
            this.ctrlPersonWithFiltter1._PersonID = 0;
            this.ctrlPersonWithFiltter1.FilterEnabled = false;
            this.ctrlPersonWithFiltter1.Location = new System.Drawing.Point(14, 0);
            this.ctrlPersonWithFiltter1.Name = "ctrlPersonWithFiltter1";
            this.ctrlPersonWithFiltter1.Size = new System.Drawing.Size(812, 282);
            this.ctrlPersonWithFiltter1.TabIndex = 2;
            this.ctrlPersonWithFiltter1.Load += new System.EventHandler(this.ctrlPersonWithFiltter1_Load);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::Bank_Project.Properties.Resources.arrow_right_7242705__1_;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(675, 315);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(145, 37);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GBPermetions);
            this.tabPage2.Controls.Add(this.CHKIsActive);
            this.tabPage2.Controls.Add(this.tbConfirmPassword);
            this.tabPage2.Controls.Add(this.tbPassword);
            this.tabPage2.Controls.Add(this.tbUserName);
            this.tabPage2.Controls.Add(this.lbConfirmPassword);
            this.tabPage2.Controls.Add(this.lbPassword);
            this.tabPage2.Controls.Add(this.lbUserName);
            this.tabPage2.Controls.Add(this.LbUserID2);
            this.tabPage2.Controls.Add(this.LBUserID);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(829, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User Permetion";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GBPermetions
            // 
            this.GBPermetions.Controls.Add(this.pListClients);
            this.GBPermetions.Controls.Add(this.pManageUsers);
            this.GBPermetions.Controls.Add(this.pUpdateClients);
            this.GBPermetions.Controls.Add(this.pAddNewClient);
            this.GBPermetions.Controls.Add(this.eAll);
            this.GBPermetions.Controls.Add(this.PLogs);
            this.GBPermetions.Controls.Add(this.pPeopleList);
            this.GBPermetions.Controls.Add(this.PDeleteClient);
            this.GBPermetions.Controls.Add(this.pTransactions);
            this.GBPermetions.Location = new System.Drawing.Point(575, 35);
            this.GBPermetions.Name = "GBPermetions";
            this.GBPermetions.Size = new System.Drawing.Size(185, 304);
            this.GBPermetions.TabIndex = 17;
            this.GBPermetions.TabStop = false;
            this.GBPermetions.Text = "Permetions";
            // 
            // pListClients
            // 
            this.pListClients.AutoSize = true;
            this.pListClients.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pListClients.Location = new System.Drawing.Point(6, 23);
            this.pListClients.Name = "pListClients";
            this.pListClients.Size = new System.Drawing.Size(139, 28);
            this.pListClients.TabIndex = 18;
            this.pListClients.Tag = "1";
            this.pListClients.Text = " List Clients";
            this.pListClients.UseVisualStyleBackColor = true;
            // 
            // pManageUsers
            // 
            this.pManageUsers.AutoSize = true;
            this.pManageUsers.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pManageUsers.Location = new System.Drawing.Point(6, 208);
            this.pManageUsers.Name = "pManageUsers";
            this.pManageUsers.Size = new System.Drawing.Size(167, 28);
            this.pManageUsers.TabIndex = 19;
            this.pManageUsers.Tag = "64";
            this.pManageUsers.Text = " Manage Users";
            this.pManageUsers.UseVisualStyleBackColor = true;
            // 
            // pUpdateClients
            // 
            this.pUpdateClients.AutoSize = true;
            this.pUpdateClients.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pUpdateClients.Location = new System.Drawing.Point(6, 116);
            this.pUpdateClients.Name = "pUpdateClients";
            this.pUpdateClients.Size = new System.Drawing.Size(172, 28);
            this.pUpdateClients.TabIndex = 20;
            this.pUpdateClients.Tag = "8";
            this.pUpdateClients.Text = " Update Clients";
            this.pUpdateClients.UseVisualStyleBackColor = true;
            // 
            // pAddNewClient
            // 
            this.pAddNewClient.AutoSize = true;
            this.pAddNewClient.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pAddNewClient.Location = new System.Drawing.Point(6, 52);
            this.pAddNewClient.Name = "pAddNewClient";
            this.pAddNewClient.Size = new System.Drawing.Size(178, 28);
            this.pAddNewClient.TabIndex = 21;
            this.pAddNewClient.Tag = "2";
            this.pAddNewClient.Text = " Add New Client";
            this.pAddNewClient.UseVisualStyleBackColor = true;
            // 
            // eAll
            // 
            this.eAll.AutoSize = true;
            this.eAll.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eAll.Location = new System.Drawing.Point(6, 269);
            this.eAll.Name = "eAll";
            this.eAll.Size = new System.Drawing.Size(58, 28);
            this.eAll.TabIndex = 22;
            this.eAll.Tag = "-1";
            this.eAll.Text = "All";
            this.eAll.UseVisualStyleBackColor = true;
            this.eAll.CheckedChanged += new System.EventHandler(this.eAll_CheckedChanged);
            // 
            // PLogs
            // 
            this.PLogs.AutoSize = true;
            this.PLogs.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLogs.Location = new System.Drawing.Point(6, 237);
            this.PLogs.Name = "PLogs";
            this.PLogs.Size = new System.Drawing.Size(83, 28);
            this.PLogs.TabIndex = 22;
            this.PLogs.Tag = "128";
            this.PLogs.Text = " Logs";
            this.PLogs.UseVisualStyleBackColor = true;
            // 
            // pPeopleList
            // 
            this.pPeopleList.AutoSize = true;
            this.pPeopleList.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pPeopleList.Location = new System.Drawing.Point(6, 145);
            this.pPeopleList.Name = "pPeopleList";
            this.pPeopleList.Size = new System.Drawing.Size(133, 28);
            this.pPeopleList.TabIndex = 23;
            this.pPeopleList.Tag = "16";
            this.pPeopleList.Text = "People List";
            this.pPeopleList.UseVisualStyleBackColor = true;
            // 
            // PDeleteClient
            // 
            this.PDeleteClient.AutoSize = true;
            this.PDeleteClient.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PDeleteClient.Location = new System.Drawing.Point(6, 87);
            this.PDeleteClient.Name = "PDeleteClient";
            this.PDeleteClient.Size = new System.Drawing.Size(158, 28);
            this.PDeleteClient.TabIndex = 24;
            this.PDeleteClient.Tag = "4";
            this.PDeleteClient.Text = " Delete Client";
            this.PDeleteClient.UseVisualStyleBackColor = true;
            // 
            // pTransactions
            // 
            this.pTransactions.AutoSize = true;
            this.pTransactions.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pTransactions.Location = new System.Drawing.Point(6, 180);
            this.pTransactions.Name = "pTransactions";
            this.pTransactions.Size = new System.Drawing.Size(155, 28);
            this.pTransactions.TabIndex = 25;
            this.pTransactions.Tag = "32";
            this.pTransactions.Text = " Transactions";
            this.pTransactions.UseVisualStyleBackColor = true;
            // 
            // CHKIsActive
            // 
            this.CHKIsActive.AutoSize = true;
            this.CHKIsActive.Location = new System.Drawing.Point(216, 309);
            this.CHKIsActive.Name = "CHKIsActive";
            this.CHKIsActive.Size = new System.Drawing.Size(96, 23);
            this.CHKIsActive.TabIndex = 16;
            this.CHKIsActive.Text = "Is Active";
            this.CHKIsActive.UseVisualStyleBackColor = true;
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(199, 247);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(240, 27);
            this.tbConfirmPassword.TabIndex = 13;
            this.tbConfirmPassword.UseSystemPasswordChar = true;
            this.tbConfirmPassword.TextChanged += new System.EventHandler(this.tbConfirmPassword_TextChanged_1);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(199, 178);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(240, 27);
            this.tbPassword.TabIndex = 14;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(199, 111);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(240, 27);
            this.tbUserName.TabIndex = 15;
            // 
            // lbConfirmPassword
            // 
            this.lbConfirmPassword.AutoSize = true;
            this.lbConfirmPassword.Location = new System.Drawing.Point(3, 247);
            this.lbConfirmPassword.Name = "lbConfirmPassword";
            this.lbConfirmPassword.Size = new System.Drawing.Size(138, 19);
            this.lbConfirmPassword.TabIndex = 4;
            this.lbConfirmPassword.Text = "Confirm Password";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(59, 178);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(76, 19);
            this.lbPassword.TabIndex = 5;
            this.lbPassword.Text = "Password";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(54, 113);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(82, 19);
            this.lbUserName.TabIndex = 6;
            this.lbUserName.Text = "UserName";
            // 
            // LbUserID2
            // 
            this.LbUserID2.AutoSize = true;
            this.LbUserID2.Location = new System.Drawing.Point(212, 57);
            this.LbUserID2.Name = "LbUserID2";
            this.LbUserID2.Size = new System.Drawing.Size(33, 19);
            this.LbUserID2.TabIndex = 7;
            this.LbUserID2.Text = "???";
            // 
            // LBUserID
            // 
            this.LBUserID.AutoSize = true;
            this.LBUserID.Location = new System.Drawing.Point(78, 60);
            this.LBUserID.Name = "LBUserID";
            this.LBUserID.Size = new System.Drawing.Size(58, 19);
            this.LBUserID.TabIndex = 8;
            this.LBUserID.Text = "UserID";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Bank_Project.Properties.Resources.login;
            this.pictureBox4.Location = new System.Drawing.Point(159, 247);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Bank_Project.Properties.Resources.login;
            this.pictureBox3.Location = new System.Drawing.Point(159, 178);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Bank_Project.Properties.Resources.Person_32;
            this.pictureBox2.Location = new System.Drawing.Point(159, 113);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank_Project.Properties.Resources.administrator__3_;
            this.pictureBox1.Location = new System.Drawing.Point(159, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // lbAddnewUser
            // 
            this.lbAddnewUser.AutoSize = true;
            this.lbAddnewUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddnewUser.ForeColor = System.Drawing.Color.Red;
            this.lbAddnewUser.Location = new System.Drawing.Point(296, 17);
            this.lbAddnewUser.Name = "lbAddnewUser";
            this.lbAddnewUser.Size = new System.Drawing.Size(181, 29);
            this.lbAddnewUser.TabIndex = 2;
            this.lbAddnewUser.Text = "Add New User";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button2
            // 
            this.button2.Image = global::Bank_Project.Properties.Resources.close_4210923;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(550, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Bank_Project.Properties.Resources.save_file_10057635;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(679, 429);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 50);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddnewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 489);
            this.Controls.Add(this.lbAddnewUser);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddnewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddnewUser";
            this.Load += new System.EventHandler(this.frmAddnewUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.GBPermetions.ResumeLayout(false);
            this.GBPermetions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbAddnewUser;
        private System.Windows.Forms.CheckBox CHKIsActive;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lbConfirmPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label LbUserID2;
        private System.Windows.Forms.Label LBUserID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNext;
        private ctrlPersonWithFiltter ctrlPersonWithFiltter1;
        private System.Windows.Forms.GroupBox GBPermetions;
        private System.Windows.Forms.CheckBox pListClients;
        private System.Windows.Forms.CheckBox pManageUsers;
        private System.Windows.Forms.CheckBox pUpdateClients;
        private System.Windows.Forms.CheckBox pAddNewClient;
        private System.Windows.Forms.CheckBox PLogs;
        private System.Windows.Forms.CheckBox pPeopleList;
        private System.Windows.Forms.CheckBox PDeleteClient;
        private System.Windows.Forms.CheckBox pTransactions;
        private System.Windows.Forms.CheckBox eAll;
    }
}