namespace GUI
{
    partial class GUI_OrderRepot
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rpv_OrderReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 450);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // rpv_OrderReportViewer
            // 
            this.rpv_OrderReportViewer.ActiveViewIndex = -1;
            this.rpv_OrderReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpv_OrderReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpv_OrderReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpv_OrderReportViewer.Location = new System.Drawing.Point(0, 0);
            this.rpv_OrderReportViewer.Name = "rpv_OrderReportViewer";
            this.rpv_OrderReportViewer.Size = new System.Drawing.Size(800, 450);
            this.rpv_OrderReportViewer.TabIndex = 1;
            // 
            // GUI_OrderRepot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpv_OrderReportViewer);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "GUI_OrderRepot";
            this.Text = "GUI_OrderRepot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer rpv_OrderReportViewer;
    }
}