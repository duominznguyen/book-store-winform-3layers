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
                SellingTabPreload();
                RevenueTabPreload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void SellingTabPreload()
        {
            try
            {
                LoadDayOrdersChart(dtp_OrderDate.Value);
                LoadMonthOrdersChart((int)nud_MonthChart__Year.Value, (int)nud_MonthChart__Month.Value);
                LoadYearOrdersChart((int)nud_YearChart__Year.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bán hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RevenueTabPreload()
        {
            try
            {
                DateTime now = DateTime.Now;
                LoadRevenueTextbox(now);

                foreach (Control ctrl in panel_dailyRevenue_moreOption.Controls)
                {
                    ctrl.Visible = false;
                }
                DateTime firstDayOfCurrentMonth = new DateTime(now.Year, now.Month, 1);
                DateTime lastDayOfCurrentMonth = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
                LoadDailyRevenueChart(firstDayOfCurrentMonth, lastDayOfCurrentMonth);
                LoadMonthlyRevenueChart(now.Year);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        

        private void LoadRevenueTextbox(DateTime date)
        {
            txt_DayRevenue.Text = _bllOrder.GetRevenueByDate(date).Rows[0]["TotalRevenue"].ToString();
        }


        private void LoadDailyRevenueChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable data = _bllOrder.GetDailyRevenueChartData(startDate, endDate);
                chart_DailyRevenue.Series.Clear();
                chart_DailyRevenue.ChartAreas.Clear();
                chart_DailyRevenue.ChartAreas.Add("MainArea");
                Series series = new Series
                {
                    Name = "Doanh thu",
                    Color = Color.LightSkyBlue,
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };
                foreach (DataRow row in data.Rows)
                {
                    series.Points.AddXY(row["Order_date"].ToString(), Convert.ToDecimal(row["TotalRevenue"]));
                }
                chart_DailyRevenue.Series.Add(series);
                chart_DailyRevenue.ChartAreas["MainArea"].AxisX.Title = "Ngày";
                chart_DailyRevenue.ChartAreas["MainArea"].AxisY.Title = "Doanh thu";
                chart_DailyRevenue.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
                chart_DailyRevenue.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;
                chart_DailyRevenue.ChartAreas["MainArea"].AxisX.Interval = 1;
                chart_DailyRevenue.ChartAreas["MainArea"].AxisY.Minimum = 0;
                chart_DailyRevenue.Titles.Clear();
                chart_DailyRevenue.Titles.Add("Biểu đồ doanh thu hàng ngày từ " + startDate.ToString("dd/MM/yyyy") + " đến " + endDate.ToString("dd/MM/yyyy"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadMonthlyRevenueChart(int year)
        {
            try
            {
                DataTable data = _bllOrder.GetMonthlyRevenueChartData(year);
                chart_MonthlyRevenue.Series.Clear();
                chart_MonthlyRevenue.ChartAreas.Clear();
                chart_MonthlyRevenue.ChartAreas.Add("MainArea");
                Series series = new Series
                {
                    Name = "Doanh thu",
                    Color = Color.LightSkyBlue,
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };
                foreach (DataRow row in data.Rows)
                {
                    series.Points.AddXY(row["Order_month"].ToString(), Convert.ToDecimal(row["TotalRevenue"]));
                }
                chart_MonthlyRevenue.Series.Add(series);
                chart_MonthlyRevenue.ChartAreas["MainArea"].AxisX.Title = "Ngày trong tháng";
                chart_MonthlyRevenue.ChartAreas["MainArea"].AxisY.Title = "Doanh thu";
                chart_MonthlyRevenue.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
                chart_MonthlyRevenue.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;
                chart_MonthlyRevenue.ChartAreas["MainArea"].AxisX.Interval = 1;
                chart_MonthlyRevenue.ChartAreas["MainArea"].AxisY.Minimum = 0;
                chart_MonthlyRevenue.Titles.Clear();
                chart_MonthlyRevenue.Titles.Add("Biểu đồ doanh thu theo tháng trong năm " + year);
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

        private void btn_dailyRevenue_moreOption_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in panel_dailyRevenue_moreOption.Controls)
            {
                ctrl.Visible = !ctrl.Visible;
            }
            foreach (Control ctrl in panel_dailyRevenue_defaultOption.Controls)
            {
                ctrl.Enabled = !ctrl.Enabled;
            }


        }

        private void btn_cancelMoreOption_Click(object sender, EventArgs e)
        {
        }

        private void dtp_DayRevenue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRevenueTextbox(dtp_DayRevenue.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nup_dailychart_month_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime firstDayOfMonth = new DateTime((int)nup_dailychart_year.Value, (int)nup_dailychart_month.Value, 1);
                DateTime lastDayOfMonth = new DateTime((int)nup_dailychart_year.Value, (int)nup_dailychart_month.Value, DateTime.DaysInMonth((int)nup_dailychart_year.Value, (int)nup_dailychart_month.Value));
                LoadDailyRevenueChart(firstDayOfMonth, lastDayOfMonth);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nup_dailychart_year_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime firstDayOfMonth = new DateTime((int)nup_dailychart_year.Value, (int)nup_dailychart_month.Value, 1);
                DateTime lastDayOfMonth = new DateTime((int)nup_dailychart_year.Value, (int)nup_dailychart_month.Value, DateTime.DaysInMonth((int)nup_dailychart_year.Value, (int)nup_dailychart_month.Value));
                LoadDailyRevenueChart(firstDayOfMonth, lastDayOfMonth);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_confirm_Click_1(object sender, EventArgs e)
        {
            if (dtp_startDate.Value > dtp_endDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DateTime startDate = dtp_startDate.Value;
                DateTime endDate = dtp_endDate.Value;
                LoadDailyRevenueChart(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nup_monthlychart_year_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadMonthlyRevenueChart((int)nup_monthlychart_year.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
