namespace Bank_Project
{
    partial class ShowCLientInfo
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
            this.ctrlPersoncard1 = new Bank_Project.ctrlPersoncard();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlPersoncard1
            // 
            this.ctrlPersoncard1.Location = new System.Drawing.Point(10, 6);
            this.ctrlPersoncard1.Name = "ctrlPersoncard1";
            this.ctrlPersoncard1.PersonID = 0;
            this.ctrlPersoncard1.Size = new System.Drawing.Size(849, 287);
            this.ctrlPersoncard1.TabIndex = 0;
            this.ctrlPersoncard1.userID = 0;
            this.ctrlPersoncard1.Load += new System.EventHandler(this.ctrlPersoncard1_Load);
            // 
            // button1
            // 
            this.button1.Image = global::Bank_Project.Properties.Resources.close_4210923;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(681, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowCLientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 276);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlPersoncard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowCLientInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowCLientInfo";
            this.Load += new System.EventHandler(this.ShowCLientInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersoncard ctrlPersoncard1;
        private System.Windows.Forms.Button button1;
    }
}