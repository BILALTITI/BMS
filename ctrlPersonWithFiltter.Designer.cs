namespace Bank_Project
{
    partial class ctrlPersonWithFiltter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PBAddnewPerson = new System.Windows.Forms.PictureBox();
            this.PBSearch = new System.Windows.Forms.PictureBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.CBFilter = new System.Windows.Forms.ComboBox();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.ctrlPersoncard1 = new Bank_Project.ctrlPersoncard();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBAddnewPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PBAddnewPerson);
            this.groupBox1.Controls.Add(this.PBSearch);
            this.groupBox1.Controls.Add(this.lbFilter);
            this.groupBox1.Controls.Add(this.CBFilter);
            this.groupBox1.Controls.Add(this.tbFilter);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 66);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // PBAddnewPerson
            // 
            this.PBAddnewPerson.Image = global::Bank_Project.Properties.Resources.person_boy__5_;
            this.PBAddnewPerson.Location = new System.Drawing.Point(667, 14);
            this.PBAddnewPerson.Name = "PBAddnewPerson";
            this.PBAddnewPerson.Size = new System.Drawing.Size(40, 40);
            this.PBAddnewPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBAddnewPerson.TabIndex = 13;
            this.PBAddnewPerson.TabStop = false;
            this.PBAddnewPerson.Click += new System.EventHandler(this.PBAddnewPerson_Click);
            // 
            // PBSearch
            // 
            this.PBSearch.Image = global::Bank_Project.Properties.Resources.focus_group__2_;
            this.PBSearch.Location = new System.Drawing.Point(626, 14);
            this.PBSearch.Name = "PBSearch";
            this.PBSearch.Size = new System.Drawing.Size(35, 40);
            this.PBSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBSearch.TabIndex = 13;
            this.PBSearch.TabStop = false;
            this.PBSearch.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilter.Location = new System.Drawing.Point(2, 16);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(114, 24);
            this.lbFilter.TabIndex = 12;
            this.lbFilter.Text = "Filter By : ";
            // 
            // CBFilter
            // 
            this.CBFilter.FormattingEnabled = true;
            this.CBFilter.Items.AddRange(new object[] {
            "PersonID",
            "NationalNo"});
            this.CBFilter.Location = new System.Drawing.Point(124, 16);
            this.CBFilter.Name = "CBFilter";
            this.CBFilter.Size = new System.Drawing.Size(196, 27);
            this.CBFilter.TabIndex = 11;
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(336, 17);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(284, 27);
            this.tbFilter.TabIndex = 10;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            // 
            // ctrlPersoncard1
            // 
            this.ctrlPersoncard1.Location = new System.Drawing.Point(6, 70);
            this.ctrlPersoncard1.Name = "ctrlPersoncard1";
            this.ctrlPersoncard1.PersonID = 0;
            this.ctrlPersoncard1.Size = new System.Drawing.Size(826, 210);
            this.ctrlPersoncard1.TabIndex = 16;
            this.ctrlPersoncard1.userID = 0;
            this.ctrlPersoncard1.Load += new System.EventHandler(this.ctrlPersoncard1_Load);
            // 
            // ctrlPersonWithFiltter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersoncard1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlPersonWithFiltter";
            this.Size = new System.Drawing.Size(853, 283);
            this.Load += new System.EventHandler(this.ctrlPersonWithFiltter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBAddnewPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox PBAddnewPerson;
        private System.Windows.Forms.PictureBox PBSearch;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.ComboBox CBFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private ctrlPersoncard ctrlPersoncard1;
    }
}
