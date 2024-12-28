namespace Bank_Project
{
    partial class frmProfile
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
            this.LLChangeMyPassword = new System.Windows.Forms.LinkLabel();
            this.ctrlPersoncard1 = new Bank_Project.ctrlPersoncard();
            this.GBPermetions.SuspendLayout();
            this.SuspendLayout();
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
            this.GBPermetions.Location = new System.Drawing.Point(899, 12);
            this.GBPermetions.Name = "GBPermetions";
            this.GBPermetions.Size = new System.Drawing.Size(202, 295);
            this.GBPermetions.TabIndex = 18;
            this.GBPermetions.TabStop = false;
            this.GBPermetions.Text = "Permetions";
            this.GBPermetions.Enter += new System.EventHandler(this.GBPermetions_Enter);
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
            // LLChangeMyPassword
            // 
            this.LLChangeMyPassword.AutoSize = true;
            this.LLChangeMyPassword.Location = new System.Drawing.Point(36, 249);
            this.LLChangeMyPassword.Name = "LLChangeMyPassword";
            this.LLChangeMyPassword.Size = new System.Drawing.Size(161, 19);
            this.LLChangeMyPassword.TabIndex = 19;
            this.LLChangeMyPassword.TabStop = true;
            this.LLChangeMyPassword.Text = "Change my Password";
            this.LLChangeMyPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLChangeMyPassword_LinkClicked);
            // 
            // ctrlPersoncard1
            // 
            this.ctrlPersoncard1.Location = new System.Drawing.Point(13, 10);
            this.ctrlPersoncard1.Name = "ctrlPersoncard1";
            this.ctrlPersoncard1.PersonID = 0;
            this.ctrlPersoncard1.Size = new System.Drawing.Size(845, 236);
            this.ctrlPersoncard1.TabIndex = 0;
            this.ctrlPersoncard1.userID = 0;
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 343);
            this.Controls.Add(this.LLChangeMyPassword);
            this.Controls.Add(this.GBPermetions);
            this.Controls.Add(this.ctrlPersoncard1);
            this.Name = "frmProfile";
            this.Text = "frmProfile";
            this.Load += new System.EventHandler(this.frmProfile_Load);
            this.GBPermetions.ResumeLayout(false);
            this.GBPermetions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersoncard ctrlPersoncard1;
        private System.Windows.Forms.GroupBox GBPermetions;
        private System.Windows.Forms.CheckBox pListClients;
        private System.Windows.Forms.CheckBox pManageUsers;
        private System.Windows.Forms.CheckBox pUpdateClients;
        private System.Windows.Forms.CheckBox pAddNewClient;
        private System.Windows.Forms.CheckBox eAll;
        private System.Windows.Forms.CheckBox PLogs;
        private System.Windows.Forms.CheckBox pPeopleList;
        private System.Windows.Forms.CheckBox PDeleteClient;
        private System.Windows.Forms.CheckBox pTransactions;
        private System.Windows.Forms.LinkLabel LLChangeMyPassword;
    }
}