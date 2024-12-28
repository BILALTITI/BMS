namespace Bank_Project
{
    partial class frmTransactionList
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cLientInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DGVDepoist = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDepoist)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLientInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 36);
            // 
            // cLientInfoToolStripMenuItem
            // 
            this.cLientInfoToolStripMenuItem.Image = global::Bank_Project.Properties.Resources.PersonDetails_32;
            this.cLientInfoToolStripMenuItem.Name = "cLientInfoToolStripMenuItem";
            this.cLientInfoToolStripMenuItem.Size = new System.Drawing.Size(177, 32);
            this.cLientInfoToolStripMenuItem.Text = "CLient Info";
            this.cLientInfoToolStripMenuItem.Click += new System.EventHandler(this.cLientInfoToolStripMenuItem_Click);
            // 
            // DGVDepoist
            // 
            this.DGVDepoist.AllowUserToAddRows = false;
            this.DGVDepoist.AllowUserToDeleteRows = false;
            this.DGVDepoist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDepoist.Location = new System.Drawing.Point(12, 12);
            this.DGVDepoist.Name = "DGVDepoist";
            this.DGVDepoist.ReadOnly = true;
            this.DGVDepoist.RowHeadersWidth = 62;
            this.DGVDepoist.RowTemplate.Height = 29;
            this.DGVDepoist.Size = new System.Drawing.Size(854, 424);
            this.DGVDepoist.TabIndex = 1;
            // 
            // frmTransactionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 497);
            this.Controls.Add(this.DGVDepoist);
            this.Name = "frmTransactionList";
            this.Text = "frmTransactionList";
            this.Load += new System.EventHandler(this.frmTransactionList_Load);
            this.Resize += new System.EventHandler(this.frmTransactionList_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDepoist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cLientInfoToolStripMenuItem;
        private System.Windows.Forms.DataGridView DGVDepoist;
    }
}