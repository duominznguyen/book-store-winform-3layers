namespace GUI
{
    partial class GUI_Statistical
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend16 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend17 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend18 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chart_YearOrders = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_MonthOrders = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_DayOrders = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nud_YearChart__Year = new System.Windows.Forms.NumericUpDown();
            this.nud_MonthChart__Year = new System.Windows.Forms.NumericUpDown();
            this.nud_MonthChart__Month = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_OrderDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_YearOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_MonthOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_DayOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_YearChart__Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MonthChart__Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MonthChart__Month)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Salmon;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2094, 90);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2094, 90);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO - THỐNG KÊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 90);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2094, 1274);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.chart_YearOrders);
            this.tabPage1.Controls.Add(this.chart_MonthOrders);
            this.tabPage1.Controls.Add(this.chart_DayOrders);
            this.tabPage1.Controls.Add(this.nud_YearChart__Year);
            this.tabPage1.Controls.Add(this.nud_MonthChart__Year);
            this.tabPage1.Controls.Add(this.nud_MonthChart__Month);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.dtp_OrderDate);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2086, 1235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bán hàng";
            // 
            // chart_YearOrders
            // 
            this.chart_YearOrders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            chartArea16.Name = "ChartArea1";
            this.chart_YearOrders.ChartAreas.Add(chartArea16);
            legend16.Name = "Legend1";
            this.chart_YearOrders.Legends.Add(legend16);
            this.chart_YearOrders.Location = new System.Drawing.Point(49, 904);
            this.chart_YearOrders.Name = "chart_YearOrders";
            series16.ChartArea = "ChartArea1";
            series16.Legend = "Legend1";
            series16.Name = "Series1";
            this.chart_YearOrders.Series.Add(series16);
            this.chart_YearOrders.Size = new System.Drawing.Size(1969, 318);
            this.chart_YearOrders.TabIndex = 11;
            this.chart_YearOrders.Text = "chart3";
            // 
            // chart_MonthOrders
            // 
            this.chart_MonthOrders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            chartArea17.Name = "ChartArea1";
            this.chart_MonthOrders.ChartAreas.Add(chartArea17);
            legend17.Name = "Legend1";
            this.chart_MonthOrders.Legends.Add(legend17);
            this.chart_MonthOrders.Location = new System.Drawing.Point(49, 507);
            this.chart_MonthOrders.Name = "chart_MonthOrders";
            series17.ChartArea = "ChartArea1";
            series17.Legend = "Legend1";
            series17.Name = "Series1";
            this.chart_MonthOrders.Series.Add(series17);
            this.chart_MonthOrders.Size = new System.Drawing.Size(1969, 318);
            this.chart_MonthOrders.TabIndex = 10;
            this.chart_MonthOrders.Text = "chart2";
            // 
            // chart_DayOrders
            // 
            this.chart_DayOrders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            chartArea18.Name = "ChartArea1";
            this.chart_DayOrders.ChartAreas.Add(chartArea18);
            legend18.Name = "Legend1";
            this.chart_DayOrders.Legends.Add(legend18);
            this.chart_DayOrders.Location = new System.Drawing.Point(49, 110);
            this.chart_DayOrders.Name = "chart_DayOrders";
            series18.ChartArea = "ChartArea1";
            series18.Legend = "Legend1";
            series18.Name = "Series1";
            this.chart_DayOrders.Series.Add(series18);
            this.chart_DayOrders.Size = new System.Drawing.Size(1969, 318);
            this.chart_DayOrders.TabIndex = 9;
            this.chart_DayOrders.Text = "chart1";
            // 
            // nud_YearChart__Year
            // 
            this.nud_YearChart__Year.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nud_YearChart__Year.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_YearChart__Year.Location = new System.Drawing.Point(126, 859);
            this.nud_YearChart__Year.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nud_YearChart__Year.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.nud_YearChart__Year.Name = "nud_YearChart__Year";
            this.nud_YearChart__Year.Size = new System.Drawing.Size(122, 39);
            this.nud_YearChart__Year.TabIndex = 8;
            this.nud_YearChart__Year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_YearChart__Year.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            this.nud_YearChart__Year.ValueChanged += new System.EventHandler(this.nud_YearChart__Year_ValueChanged);
            // 
            // nud_MonthChart__Year
            // 
            this.nud_MonthChart__Year.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nud_MonthChart__Year.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_MonthChart__Year.Location = new System.Drawing.Point(303, 461);
            this.nud_MonthChart__Year.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nud_MonthChart__Year.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.nud_MonthChart__Year.Name = "nud_MonthChart__Year";
            this.nud_MonthChart__Year.Size = new System.Drawing.Size(122, 39);
            this.nud_MonthChart__Year.TabIndex = 7;
            this.nud_MonthChart__Year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_MonthChart__Year.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            this.nud_MonthChart__Year.ValueChanged += new System.EventHandler(this.nud_MonthChart__Year_ValueChanged);
            // 
            // nud_MonthChart__Month
            // 
            this.nud_MonthChart__Month.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nud_MonthChart__Month.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_MonthChart__Month.Location = new System.Drawing.Point(137, 461);
            this.nud_MonthChart__Month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nud_MonthChart__Month.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_MonthChart__Month.Name = "nud_MonthChart__Month";
            this.nud_MonthChart__Month.Size = new System.Drawing.Size(76, 39);
            this.nud_MonthChart__Month.TabIndex = 6;
            this.nud_MonthChart__Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_MonthChart__Month.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_MonthChart__Month.ValueChanged += new System.EventHandler(this.nud_MonthChart__Month_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 861);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Năm ";
            // 
            // dtp_OrderDate
            // 
            this.dtp_OrderDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp_OrderDate.CustomFormat = "dd/MM/yyyy";
            this.dtp_OrderDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_OrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_OrderDate.Location = new System.Drawing.Point(146, 62);
            this.dtp_OrderDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp_OrderDate.Name = "dtp_OrderDate";
            this.dtp_OrderDate.Size = new System.Drawing.Size(257, 39);
            this.dtp_OrderDate.TabIndex = 4;
            this.dtp_OrderDate.ValueChanged += new System.EventHandler(this.dtp_OrderDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(224, 463);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "Năm ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 463);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tháng";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "Theo dõi đơn hàng";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(2086, 1235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Khách hàng";
            // 
            // GUI_Statistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(2094, 1364);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "GUI_Statistical";
            this.Text = "GUI_Statistical";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_YearOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_MonthOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_DayOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_YearChart__Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MonthChart__Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MonthChart__Month)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_OrderDate;
        private System.Windows.Forms.NumericUpDown nud_MonthChart__Month;
        private System.Windows.Forms.NumericUpDown nud_MonthChart__Year;
        private System.Windows.Forms.NumericUpDown nud_YearChart__Year;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_YearOrders;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_MonthOrders;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_DayOrders;
    }
}