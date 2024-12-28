namespace Bank_Project
{
    partial class ctrlUserInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlPersoncard1 = new Bank_Project.ctrlPersoncard();
            this.LoginInfo = new System.Windows.Forms.GroupBox();
            this.lbIsActive2 = new System.Windows.Forms.Label();
            this.lbIsActive = new System.Windows.Forms.Label();
            this.lbUserName2 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbUserID2 = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.LoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersoncard1
            // 
            this.ctrlPersoncard1.Location = new System.Drawing.Point(3, 12);
            this.ctrlPersoncard1.Name = "ctrlPersoncard1";
            this.ctrlPersoncard1.PersonID = 0;
            this.ctrlPersoncard1.Size = new System.Drawing.Size(812, 202);
            this.ctrlPersoncard1.TabIndex = 0;
            this.ctrlPersoncard1.userID = 0;
            // 
            // LoginInfo
            // 
            this.LoginInfo.Controls.Add(this.lbIsActive2);
            this.LoginInfo.Controls.Add(this.lbIsActive);
            this.LoginInfo.Controls.Add(this.lbUserName2);
            this.LoginInfo.Controls.Add(this.lbUserName);
            this.LoginInfo.Controls.Add(this.lbUserID2);
            this.LoginInfo.Controls.Add(this.lbUserID);
            this.LoginInfo.Location = new System.Drawing.Point(3, 208);
            this.LoginInfo.Name = "LoginInfo";
            this.LoginInfo.Size = new System.Drawing.Size(815, 56);
            this.LoginInfo.TabIndex = 3;
            this.LoginInfo.TabStop = false;
            this.LoginInfo.Text = "Login Information";
            // 
            // lbIsActive2
            // 
            this.lbIsActive2.AutoSize = true;
            this.lbIsActive2.Location = new System.Drawing.Point(674, 23);
            this.lbIsActive2.Name = "lbIsActive2";
            this.lbIsActive2.Size = new System.Drawing.Size(49, 19);
            this.lbIsActive2.TabIndex = 0;
            this.lbIsActive2.Text = "?????";
            // 
            // lbIsActive
            // 
            this.lbIsActive.AutoSize = true;
            this.lbIsActive.Location = new System.Drawing.Point(551, 24);
            this.lbIsActive.Name = "lbIsActive";
            this.lbIsActive.Size = new System.Drawing.Size(81, 19);
            this.lbIsActive.TabIndex = 0;
            this.lbIsActive.Text = "Is Active :";
            // 
            // lbUserName2
            // 
            this.lbUserName2.AutoSize = true;
            this.lbUserName2.Location = new System.Drawing.Point(384, 23);
            this.lbUserName2.Name = "lbUserName2";
            this.lbUserName2.Size = new System.Drawing.Size(49, 19);
            this.lbUserName2.TabIndex = 0;
            this.lbUserName2.Text = "?????";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(280, 24);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(98, 19);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "User Name :";
            // 
            // lbUserID2
            // 
            this.lbUserID2.AutoSize = true;
            this.lbUserID2.Location = new System.Drawing.Point(106, 24);
            this.lbUserID2.Name = "lbUserID2";
            this.lbUserID2.Size = new System.Drawing.Size(49, 19);
            this.lbUserID2.TabIndex = 0;
            this.lbUserID2.Text = "?????";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Location = new System.Drawing.Point(6, 24);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(74, 19);
            this.lbUserID.TabIndex = 0;
            this.lbUserID.Text = "User ID :";
            // 
            // ctrlUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoginInfo);
            this.Controls.Add(this.ctrlPersoncard1);
            this.Name = "ctrlUserInfo";
            this.Size = new System.Drawing.Size(818, 267);
            this.Load += new System.EventHandler(this.ctrlUserInfo_Load);
            this.LoginInfo.ResumeLayout(false);
            this.LoginInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersoncard ctrlPersoncard1;
        private System.Windows.Forms.GroupBox LoginInfo;
        private System.Windows.Forms.Label lbIsActive2;
        private System.Windows.Forms.Label lbIsActive;
        private System.Windows.Forms.Label lbUserName2;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbUserID2;
        private System.Windows.Forms.Label lbUserID;
    }
}
