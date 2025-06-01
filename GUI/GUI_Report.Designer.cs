namespace GUI
{
    partial class GUI_Report
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
            this.crv_Report = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crv_Report
            // 
            this.crv_Report.ActiveViewIndex = -1;
            this.crv_Report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_Report.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv_Report.Location = new System.Drawing.Point(0, 0);
            this.crv_Report.Name = "crv_Report";
            this.crv_Report.Size = new System.Drawing.Size(800, 450);
            this.crv_Report.TabIndex = 0;
            // 
            // GUI_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crv_Report);
            this.Name = "GUI_Report";
            this.Text = "In hóa đơn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crv_Report;
    }
}