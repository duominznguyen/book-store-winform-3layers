using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entities;

namespace GUI
{
    public partial class GUI_Order : Form
    {
        private BLL_Order _bllOrder;
        public GUI_Order()
        {
            InitializeComponent();
            _bllOrder = new BLL_Order();
        }

        private void GUI_Order_Load(object sender, EventArgs e)
        {
            LoadDGV();
            LoadSearchOptionsCbb();
        }

        private void LoadDGV()
        {
            dgv_DonBan.DataSource = _bllOrder.GetAllOrder();
            dgv_DonBan.Columns["OrderID"].HeaderText = "Mã Đơn Bán";
            dgv_DonBan.Columns["OrderDate"].HeaderText = "Ngày Bán";
            dgv_DonBan.Columns["EmployeeID"].HeaderText = "Mã Nhân Viên";
            dgv_DonBan.Columns["CustomerID"].HeaderText = "Mã Khách Hàng";
        }

        private void LoadSearchOptionsCbb()
        {
            cbb_SearchOptions.DataSource = new List<string> { "Mã Đơn Bán", "Ngày Bán", "Mã Nhân Viên", "Mã Khách Hàng" };
            cbb_SearchOptions.SelectedIndex = 0;
        }

        private void dgv_DonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_DonBan.Rows[e.RowIndex];
                txt_MaDH.Text = row.Cells["OrderID"].Value.ToString();
                dtp_NgayLap.Value = DateTime.Parse(row.Cells["OrderDate"].Value.ToString());
                txt_MaNV.Text = row.Cells["EmployeeID"].Value.ToString();
                txt_MaKH.Text = row.Cells["CustomerID"].Value.ToString();
            }
        }


        private void ClearInputFields()
        {
            txt_MaDH.Clear();
            txt_MaNV.Clear();
            txt_MaKH.Clear();
            dtp_NgayLap.Value = DateTime.Now;
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }


        private bool IsValidInputForAdd()
        {
            if (string.IsNullOrWhiteSpace(txt_MaDH.Text) ||
                string.IsNullOrWhiteSpace(txt_MaNV.Text) ||
                string.IsNullOrWhiteSpace(txt_MaKH.Text) ||
                string.IsNullOrWhiteSpace(dtp_NgayLap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }

            if (!int.TryParse(txt_MaDH.Text, out _) ||
                !int.TryParse(txt_MaNV.Text, out _) ||
                !int.TryParse(txt_MaKH.Text, out _))
            {
                MessageBox.Show("Mã phải là số nguyên.");
                return false;
            }

            if (dtp_NgayLap.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày lập không được lớn hơn ngày hiện tại.");
                return false;
            }
            return true;
        }

        private bool IsValidInputForUpdate()
        {
            if (string.IsNullOrWhiteSpace(txt_MaDH.Text) ||
                string.IsNullOrWhiteSpace(txt_MaNV.Text) ||
                string.IsNullOrWhiteSpace(txt_MaKH.Text) ||
                string.IsNullOrWhiteSpace(dtp_NgayLap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }
            if (!int.TryParse(txt_MaDH.Text, out _) ||
                !int.TryParse(txt_MaNV.Text, out _) ||
                !int.TryParse(txt_MaKH.Text, out _))
            {
                MessageBox.Show("Mã phải là số nguyên.");
                return false;
            }
            if (dtp_NgayLap.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày lập không được lớn hơn ngày hiện tại.");
                return false;
            }
            return true;
        }

        private bool IsValidInputForDelete()
        {
            if (string.IsNullOrWhiteSpace(txt_MaDH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã đơn bán cần xóa.");
                return false;
            }
            if (!int.TryParse(txt_MaDH.Text, out _))
            {
                MessageBox.Show("Mã phải là số nguyên.");
                return false;
            }
            return true;
        }


        private void AddOrder()
        {
            try
            {
                if (IsValidInputForAdd())
                {
                    Order order = new Order
                    {
                        OrderID = int.Parse(txt_MaDH.Text),
                        OrderDate = dtp_NgayLap.Value,
                        EmployeeID = int.Parse(txt_MaNV.Text),
                        CustomerID = int.Parse(txt_MaKH.Text)
                    };
                    if (_bllOrder.AddOrder(order))
                    {
                        MessageBox.Show("Thêm đơn bán thành công.");
                        LoadDGV();

                        GUI_OrderDetail gUI_OrderDetail = new GUI_OrderDetail(order.OrderID);
                        gUI_OrderDetail.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Thêm đơn bán thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                LoadDGV();
            }

        }
        private void UpdateOrder()
        {
            try
            {
                if (IsValidInputForUpdate())
                {
                    Order order = new Order
                    {
                        OrderID = int.Parse(txt_MaDH.Text),
                        OrderDate = dtp_NgayLap.Value,
                        EmployeeID = int.Parse(txt_MaNV.Text),
                        CustomerID = int.Parse(txt_MaKH.Text)
                    };
                    if (_bllOrder.UpdateOrder(order))
                    {
                        MessageBox.Show("Cập nhật đơn bán thành công.");
                        LoadDGV();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đơn bán thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                LoadDGV();
            }
        }
        private void DeleteOrder()
        {
            try
            {
                if (IsValidInputForDelete())
                {
                    int orderId = int.Parse(txt_MaDH.Text);
                    if (_bllOrder.DeleteOrder(orderId))
                    {
                        MessageBox.Show("Xóa đơn bán thành công.");
                        LoadDGV();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đơn bán thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                LoadDGV();
            }
        }

        private void SearchOrder()
        {
            if (cbb_SearchOptions.Text == "Mã Đơn Bán")
            {
                if (string.IsNullOrWhiteSpace(txt_MaDH.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã đơn bán để tìm kiếm.");
                    return;
                }
                if (!int.TryParse(txt_MaDH.Text, out _))
                {
                    MessageBox.Show("Mã đơn bán phải là số nguyên.");
                    return;
                }
                dgv_DonBan.DataSource = _bllOrder.SearchOrder("Mã Đơn Bán", txt_MaDH.Text);
            }
            else if (cbb_SearchOptions.Text == "Ngày Bán")
            {
                if (string.IsNullOrWhiteSpace(dtp_NgayLap.Text))
                {
                    MessageBox.Show("Vui lòng nhập ngày bán để tìm kiếm.");
                    return;
                }
                dgv_DonBan.DataSource = _bllOrder.SearchOrder("Ngày Bán", dtp_NgayLap.Value.ToString("yyyy-MM-dd"));
            }
            else if (cbb_SearchOptions.Text == "Mã Nhân Viên")
            {
                if (string.IsNullOrWhiteSpace(txt_MaNV.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên để tìm kiếm.");
                    return;
                }
                if (!int.TryParse(txt_MaNV.Text, out _))
                {
                    MessageBox.Show("Mã nhân viên phải là số nguyên.");
                    return;
                }
                dgv_DonBan.DataSource = _bllOrder.SearchOrder("Mã Nhân Viên", txt_MaNV.Text);
            }
            else if (cbb_SearchOptions.Text == "Mã Khách Hàng")
            {
                if (string.IsNullOrWhiteSpace(txt_MaKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã khách hàng để tìm kiếm.");
                    return;
                }
                if (!int.TryParse(txt_MaKH.Text, out _))
                {
                    MessageBox.Show("Mã khách hàng phải là số nguyên.");
                    return;
                }
                dgv_DonBan.DataSource = _bllOrder.SearchOrder("Mã Khách Hàng", txt_MaKH.Text);
            }
        }

        private void btn_HuyTimKiem_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadDGV();
        }

        private void btn_ThucThi_Click(object sender, EventArgs e)
        {
            if (rad_Them.Checked)
            {
                AddOrder();
            }
            else if (rad_Sua.Checked)
            {
                UpdateOrder();
            }
            else if (rad_Xoa.Checked)
            {
                DeleteOrder();
            }
            else if (rad_TimKiem.Checked)
            {
                SearchOrder();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thao tác.");
            }

        }

        private void btn_ChiTietHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaDH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã đơn bán để xem chi tiết.");
                return;
            }
            if (!int.TryParse(txt_MaDH.Text, out _))
            {
                MessageBox.Show("Mã đơn bán phải là số nguyên không dấu.");
                return;
            }

            int orderId = int.Parse(txt_MaDH.Text);

            if (_bllOrder.GetOrderById(orderId).Rows.Count == 0)
            {
                MessageBox.Show("Đơn hàng không tồn tại.");
                return;
            }

            GUI_OrderDetail gUI_OrderDetail = new GUI_OrderDetail(orderId);
            gUI_OrderDetail.ShowDialog();

        }


    }
}
