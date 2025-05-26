using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;

namespace GUI
{
    public partial class GUI_Statistical : Form
    {
        private BLL_Order _bllOrder;
        public GUI_Statistical()
        {
            InitializeComponent();
            _bllOrder = new BLL_Order();
            LoadData();

        }

        private void LoadData()
        {
            try
            {
                DateTime now = DateTime.Now;
                dtp_OrderDate.Value = now;
                nud_MonthChart__Year.Value = now.Year;
                nud_MonthChart__Month.Value = now.Month;
                nud_YearChart__Year.Value = now.Year;

                LoadDayOrdersChart(dtp_OrderDate.Value);
                LoadMonthOrdersChart((int)nud_MonthChart__Year.Value, (int)nud_MonthChart__Month.Value);
                LoadYearOrdersChart((int)nud_YearChart__Year.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void LoadDayOrdersChart(DateTime orderDate)
        {
            try
            {
                DataTable data = _bllOrder.GetDayOrdersChartData(orderDate);

                chart_DayOrders.Series.Clear();
                chart_DayOrders.ChartAreas.Clear();

                chart_DayOrders.ChartAreas.Add("MainArea");

                Series series = new Series
                {
                    Name = "Đơn bán",
                    Color = Color.Blue,
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true

                };
                foreach (DataRow row in data.Rows)
                {
                    series.Points.AddXY(row["Order_hour"].ToString(), Convert.ToInt32(row["OrderCount"]));
                }

                chart_DayOrders.Series.Add(series);
                chart_DayOrders.ChartAreas["MainArea"].AxisX.Title = "Giờ trong ngày";
                chart_DayOrders.ChartAreas["MainArea"].AxisY.Title = "Số lượng đơn hàng";
                chart_DayOrders.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
                chart_DayOrders.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;
                chart_DayOrders.ChartAreas["MainArea"].AxisX.Interval = 1;
                chart_DayOrders.ChartAreas["MainArea"].AxisY.Minimum = 0;
                chart_DayOrders.Titles.Clear();
                chart_DayOrders.Titles.Add("Biểu đồ số lượng đơn hàng theo giờ trong ngày " + dtp_OrderDate.Value.ToString("dd/MM/yyyy"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LoadMonthOrdersChart(int year, int month)
        {
            try
            {
                DataTable data = _bllOrder.GetMonthOrdersChartData(year, month);
                chart_MonthOrders.Series.Clear();
                chart_MonthOrders.ChartAreas.Clear();
                chart_MonthOrders.ChartAreas.Add("MainArea");
                Series series = new Series
                {
                    Name = "Đơn bán",
                    Color = Color.Blue,
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };
                foreach (DataRow row in data.Rows)
                {
                    series.Points.AddXY(row["Order_day"].ToString(), Convert.ToInt32(row["OrderCount"]));
                }
                chart_MonthOrders.Series.Add(series);
                chart_MonthOrders.ChartAreas["MainArea"].AxisX.Title = "Ngày trong tháng";
                chart_MonthOrders.ChartAreas["MainArea"].AxisY.Title = "Số lượng đơn hàng";
                chart_MonthOrders.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
                chart_MonthOrders.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;
                chart_MonthOrders.ChartAreas["MainArea"].AxisX.Interval = 1;
                chart_MonthOrders.ChartAreas["MainArea"].AxisY.Minimum = 0;
                chart_MonthOrders.Titles.Clear();
                chart_MonthOrders.Titles.Add("Biểu đồ số lượng đơn hàng theo ngày trong tháng " + month + "/" + year);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LoadYearOrdersChart(int year)
        {
            try
            {
                DataTable data = _bllOrder.GetYearOrdersChartData(year);
                chart_YearOrders.Series.Clear();
                chart_YearOrders.ChartAreas.Clear();
                chart_YearOrders.ChartAreas.Add("MainArea");
                Series series = new Series
                {
                    Name = "Đơn bán",
                    Color = Color.Blue,
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };
                foreach (DataRow row in data.Rows)
                {
                    series.Points.AddXY(row["Order_month"].ToString(), Convert.ToInt32(row["OrderCount"]));
                }
                chart_YearOrders.Series.Add(series);
                chart_YearOrders.ChartAreas["MainArea"].AxisX.Title = "Tháng trong năm";
                chart_YearOrders.ChartAreas["MainArea"].AxisY.Title = "Số lượng đơn hàng";
                chart_YearOrders.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
                chart_YearOrders.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;
                chart_YearOrders.ChartAreas["MainArea"].AxisX.Interval = 1;
                chart_YearOrders.ChartAreas["MainArea"].AxisY.Minimum = 0;
                chart_YearOrders.Titles.Clear();
                chart_YearOrders.Titles.Add("Biểu đồ số lượng đơn hàng theo tháng trong năm " + year);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtp_OrderDate_ValueChanged(object sender, EventArgs e)
        {
            LoadDayOrdersChart(dtp_OrderDate.Value);
        }

        private void nud_MonthChart__Month_ValueChanged(object sender, EventArgs e)
        {
            LoadMonthOrdersChart((int)nud_MonthChart__Year.Value, (int)nud_MonthChart__Month.Value);
        }

        private void nud_MonthChart__Year_ValueChanged(object sender, EventArgs e)
        {
            LoadMonthOrdersChart((int)nud_MonthChart__Year.Value, (int)nud_MonthChart__Month.Value);
        }

        private void nud_YearChart__Year_ValueChanged(object sender, EventArgs e)
        {
            LoadYearOrdersChart((int)nud_YearChart__Year.Value);
        }
    }
}
