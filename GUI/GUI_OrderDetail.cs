using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace GUI
{
    public partial class GUI_OrderDetail : Form
    {
        private BLL_OrderDetail _bllOrderDetail;
        private BLL_Book _bllBook;
        private int _orderId;
        public GUI_OrderDetail()
        {
            InitializeComponent();

        }

        public GUI_OrderDetail(int orderId)
        {
            InitializeComponent();
            _bllOrderDetail = new BLL_OrderDetail();
            _bllBook = new BLL_Book();
            _orderId = orderId;

        }

        private void GUI_OrderDetail_Load(object sender, EventArgs e)
        {
            txt_MaDH.Text = _orderId.ToString();
            LoadOrderDetailDGV();
            LoadBookDGV();
            LoadSearchOptionsCbb();
        }

        private void FormatDSHHDGV()
        {
            if (dgv_DanhSachHangHoa == null || dgv_DanhSachHangHoa.Columns.Count == 0)
            {
                return;
            }
            
            dgv_DanhSachHangHoa.Columns["OrderDetailID"].Visible = false;
            dgv_DanhSachHangHoa.Columns["BookID"].HeaderText = "Mã sách";
            dgv_DanhSachHangHoa.Columns["Title"].HeaderText = "Tên sách";
            dgv_DanhSachHangHoa.Columns["Quantity"].HeaderText = "Số lượng bán";
            dgv_DanhSachHangHoa.Columns["SellPrice"].HeaderText = "Giá bán";
        }

        private DataTable GetOrderDetail_Book()
        {
            try
            {
                return _bllOrderDetail.GetOrderDetail_BookByOrderID(_orderId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chi tiết đơn hàng: " + ex.Message);
                return null;
            }
        }

        private void LoadOrderDetailDGV()
        {
            dgv_DanhSachHangHoa.DataSource = GetOrderDetail_Book();
            FormatDSHHDGV();
        }

        private void LoadBookDGV()
        {
            dgv_Sach.DataSource = _bllBook.GetAllBooks_BookCategories();
            dgv_Sach.Columns["BookID"].HeaderText = "Mã sách";
            dgv_Sach.Columns["Title"].HeaderText = "Tên sách";
            dgv_Sach.Columns["Author"].HeaderText = "Tác giả";
            dgv_Sach.Columns["Publisher"].HeaderText = "Nhà xuất bản";
            dgv_Sach.Columns["Description"].Visible = false;
            dgv_Sach.Columns["Price"].HeaderText = "Giá bán";
            dgv_Sach.Columns["CategoryID"].Visible = false;
            dgv_Sach.Columns["CategoryName"].HeaderText = "Thể loại";

        }

        private void LoadSearchOptionsCbb()
        {
            try
            {
                Dictionary<string, string> searchOptions = new Dictionary<string, string>
                {
                    {"Title", "Tên sách" },
                    { "Author", "Tác giả" },
                    { "Publisher", "Nhà xuất bản" },
                    { "CategoryName", "Tên thể loại" },
                    { "General", "Tìm kiếm tổng quát" }
                };

                cbb_SearchOptions.DataSource = new BindingSource(searchOptions, null);
                cbb_SearchOptions.DisplayMember = "Value";
                cbb_SearchOptions.ValueMember = "Key";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tùy chọn tìm kiếm: " + ex.Message);
            }
        }

        private void dgv_DanhSachHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_DanhSachHangHoa.Rows[e.RowIndex];
                txt_MaCTDH.Text = row.Cells["OrderDetailID"].Value.ToString();

                DataRow book = _bllBook.GetBookByID(row.Cells["BookID"].Value.ToString()).Rows[0];
                txt_MaSach.Text = book["BookID"].ToString();
                txt_TieuDe.Text = book["Title"].ToString();

                txt_GiaBan.Text = row.Cells["SellPrice"].Value.ToString();
                txt_SoLuongBan.Text = row.Cells["Quantity"].Value.ToString();

            }
        }

        private void dgv_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Sach.Rows[e.RowIndex];
                txt_MaSach.Text = row.Cells["BookID"].Value.ToString();
                txt_TieuDe.Text = row.Cells["Title"].Value.ToString();
                txt_GiaBan.Text = row.Cells["Price"].Value.ToString();
            }
        }

        private Result IsFormatValidForAddingOrderDetail()
        {
            if (string.IsNullOrEmpty(txt_MaSach.Text))
            {
                return new Result(false, "Mã sách trống, vui lòng chọn sách.");
            }
            if (string.IsNullOrEmpty(txt_SoLuongBan.Text))
            {
                return new Result(false, "Vui lòng nhập số lượng bán.");
            }
            if (string.IsNullOrEmpty(txt_GiaBan.Text))
            {
                return new Result(false, "Vui lòng nhập giá bán.");
            }
            if (!int.TryParse(txt_SoLuongBan.Text, out int quantity) || quantity <= 0)
            {
                return new Result(false, "Số lượng bán phải là một số nguyên dương.");
            }
            if (!decimal.TryParse(txt_GiaBan.Text, out decimal price) || price <= 0)
            {
                return new Result(false, "Giá bán phải là một số dương.");
            }
            return new Result(true, "");
        }


        private void AddOrderDetail()
        {
            try
            {
                Result isValid = IsFormatValidForAddingOrderDetail();
                if (isValid.IsSuccess)
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderId = _orderId,
                        BookId = int.Parse(txt_MaSach.Text),
                        Quantity = int.Parse(txt_SoLuongBan.Text),
                        SellPrice = decimal.Parse(txt_GiaBan.Text)
                    };

                    Result result = new Result(true, "");

                    DataRow existOrderDetail = GetOrderDetail_Book().Select($"BookID = {orderDetail.BookId}").FirstOrDefault();

                    if (existOrderDetail != null)
                    {
                        if (MessageBox.Show("Sách đã tồn tại trong đơn hàng. Bạn có muốn cập nhật thêm vào số lượng hiện có không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }

                        orderDetail.OrderDetailId = int.Parse(existOrderDetail["OrderDetailID"].ToString());
                        orderDetail.Quantity += int.Parse(existOrderDetail["Quantity"].ToString());
                        result = _bllOrderDetail.UpdateOrderDetail(orderDetail);
                    }
                    else
                    {
                        result = _bllOrderDetail.AddOrderDetail(orderDetail);
                    }

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Thêm chi tiết đơn hàng thành công.");
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show(isValid.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết đơn hàng: " + ex.Message);
            }
            finally
            {
                LoadOrderDetailDGV();
                LoadBookDGV();
            }
        }

       

        private void UpdateOrderDetail()
        {
            try
            {
                Result isValid = IsFormatValidForAddingOrderDetail();
                if (isValid.IsSuccess)
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderDetailId = int.Parse(txt_MaCTDH.Text),
                        BookId = int.Parse(txt_MaSach.Text),
                        Quantity = int.Parse(txt_SoLuongBan.Text),
                        SellPrice = decimal.Parse(txt_GiaBan.Text)
                    };
                    Result result = _bllOrderDetail.UpdateOrderDetail(orderDetail);
                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Cập nhật chi tiết đơn hàng thành công.");
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show(isValid.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết đơn hàng: " + ex.Message);
            }
            finally
            {
                LoadOrderDetailDGV();
                LoadBookDGV();
            }
        }

        private void DeleteOrderDetail()
        {
            try
            {
                if (string.IsNullOrEmpty(txt_MaCTDH.Text))
                {
                    MessageBox.Show("Vui lòng chọn chi tiết đơn hàng để xóa.");
                    return;
                }
                int orderDetailId = int.Parse(txt_MaCTDH.Text);
                Result result = _bllOrderDetail.DeleteOrderDetail(orderDetailId);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Xóa chi tiết đơn hàng thành công.");
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết đơn hàng: " + ex.Message);
            }
            finally
            {
                LoadOrderDetailDGV();
                LoadBookDGV();
            }
        }


        private void SearchBook()
        {
            string searchOption = cbb_SearchOptions.SelectedValue.ToString();
            string searchTerm = txt_SearchTerm.Text.Trim();

            DataTable dt = null;

            dt = _bllBook.SearchBooks(searchOption, searchTerm);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgv_Sach.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sách nào.");
            }
        }



        private void btn_SachThucThi_Click(object sender, EventArgs e)
        {
            if(rad_Them.Checked)
            {
                AddOrderDetail();
            }
            else if (rad_Sua.Checked)
            {
                UpdateOrderDetail();
            }
            else if (rad_Xoa.Checked)
            {
                DeleteOrderDetail();
            }
            else if (rad_TimKiem.Checked)
            {
                SearchBook();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chức năng.");
            }
        }

        private void ClearInputFields()
        {
            txt_MaCTDH.Clear();
            txt_MaSach.Clear();
            txt_TieuDe.Clear();
            txt_GiaBan.Clear();
            txt_SoLuongBan.Clear();
            txt_SearchTerm.Clear();
        }

        private void btn_HuyTimKiem_Click(object sender, EventArgs e)
        {
            txt_SearchTerm.Clear();
            LoadBookDGV();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }


        private void btn_PrintOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = _bllOrderDetail.GetOrderPrint(_orderId);

                rpt_Order rpt_Order = new rpt_Order();
                rpt_Order.SetDataSource(data);

                GUI_Report report = new GUI_Report();
                report.crv_Report.ReportSource = rpt_Order;
                report.crv_Report.Refresh();
                report.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in đơn hàng: " + ex.Message);

            }
        }
    }
}
