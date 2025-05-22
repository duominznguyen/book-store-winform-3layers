using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BLL;
using System.ComponentModel.Design;

namespace GUI
{
    public partial class GUI_PurchaseDetail : Form
    {
        private BLL_PurchaseDetail _bllPurchaseDetail;
        private BLL_Book _bllBook;
        private int purchaseID;
        public GUI_PurchaseDetail(int purchaseID)
        {
            InitializeComponent();
            _bllPurchaseDetail = new BLL_PurchaseDetail();
            _bllBook = new BLL_Book();
            this.purchaseID = purchaseID;
        }

        private void GUI_PurchaseDetail_Load(object sender, EventArgs e)
        {
            txt_PurchaseID.Text = purchaseID.ToString();
            LoadPurchaseDetailsDataGridView();
            LoadBooksDataGridView();
            LoadSearchOptionsConboBox();
        }

        private DataTable GetPurchaseDetailsDataGridView()
        {
            try
            {
                DataTable data = _bllPurchaseDetail.GetPurchaseDetailsByPurchaseId(purchaseID);
                dgv_PurchaseDetails.DataSource = data;
                dgv_PurchaseDetails.Columns["PurchaseDetailID"].Visible = false;
                dgv_PurchaseDetails.Columns["PurchaseID"].Visible = false;
                dgv_PurchaseDetails.Columns["BookID"].HeaderText = "Mã sách";
                dgv_PurchaseDetails.Columns["Title"].HeaderText = "Tên sách";
                dgv_PurchaseDetails.Columns["Quantity"].HeaderText = "Số lượng nhập";
                dgv_PurchaseDetails.Columns["PurchasePrice"].HeaderText = "Giá nhập";

                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void LoadPurchaseDetailsDataGridView()
        {
            try
            {
                GetPurchaseDetailsDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSearchOptionsConboBox()
        {
            try
            {
                Dictionary<string, string> searchOptions = new Dictionary<string, string>
                {                
                    { "Title", "Tên sách" },
                    { "Author", "Tác giả" },
                    { "Publisher", "Nhà xuất bản" },
                    { "CategoryName", "Thể loại" },
                    {"BookID", "Mã sách" },
                    {"General", "Tìm kiếm tổng quát" }
                };
                cbb_SearchOptions.DataSource = new BindingSource(searchOptions, null);
                cbb_SearchOptions.DisplayMember = "Value";
                cbb_SearchOptions.ValueMember = "Key";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadBooksDataGridView()
        {
            try
            {
                dgv_Books.DataSource = GetBooksDataTableView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetBooksDataTableView()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = _bllBook.GetAllBooks_BookCategories();
                dgv_Books.DataSource = dataTable;
                dgv_Books.Columns["BookID"].HeaderText = "Mã sách";
                dgv_Books.Columns["Title"].HeaderText = "Tên sách";
                dgv_Books.Columns["Author"].HeaderText = "Tác giả";
                dgv_Books.Columns["Publisher"].HeaderText = "Nhà xuất bản";
                dgv_Books.Columns["Description"].Visible = false;
                dgv_Books.Columns["Price"].HeaderText = "Giá niêm yết";
                dgv_Books.Columns["Quantity"].HeaderText = "Số lượng tồn";
                dgv_Books.Columns["CategoryID"].Visible = false;
                dgv_Books.Columns["CategoryName"].HeaderText = "Thể loại";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        private void dgv_PurchaseDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_PurchaseDetails.Rows[e.RowIndex];
                txt_PurchaseDetailID.Text = row.Cells["PurchaseDetailID"].Value.ToString();

                txt_BookID.Text = row.Cells["BookID"].Value.ToString();
                txt_Title.Text = row.Cells["Title"].Value.ToString();
                txt_PurchaseQuantity.Text = row.Cells["Quantity"].Value.ToString();
                txt_PurchasePrice.Text = row.Cells["PurchasePrice"].Value.ToString();

            }
        }

        private void dgv_Books_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Books.Rows[e.RowIndex];
                txt_BookID.Text = row.Cells["BookID"].Value.ToString();
                txt_Title.Text = row.Cells["Title"].Value.ToString();
                txt_PurchasePrice.Text = row.Cells["Price"].Value.ToString();
            }
        }

        private void btn_HuyTimKiem_Click(object sender, EventArgs e)
        {
            txt_SearchValue.Clear();
            LoadBooksDataGridView();

        }


        private void ClearInputFields()
        {
            txt_BookID.Clear();
            txt_Title.Clear();
            txt_PurchaseQuantity.Clear();
            txt_PurchasePrice.Clear();
        }
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }


        private Result IsFormatValidForAdding()
        {
            if (string.IsNullOrEmpty(txt_BookID.Text))
            {
                return new Result(false, "Vui lòng nhập mã sách.");
            }
            if (string.IsNullOrEmpty(txt_PurchaseQuantity.Text))
            {
                return new Result(false, "Vui lòng nhập số lượng.");
            }
            if (string.IsNullOrEmpty(txt_PurchasePrice.Text))
            {
                return new Result(false, "Vui lòng nhập giá nhập.");
            }
            if (!int.TryParse(txt_PurchaseQuantity.Text, out int a))
            {
                if (a <= 0) { return new Result(false, "Số lượng phải là số nguyên dương."); }

                return new Result(false, "Số lượng phải là số nguyên.");
            }
            if (!decimal.TryParse(txt_PurchasePrice.Text, out decimal b))
            {
                if (b <= 0) { return new Result(false, "Giá nhập phải là số dương."); }

                return new Result(false, "Giá nhập phải là số.");
            }
            return new Result(true, "");

        }

        private void AddPurchaseDetail()
        {
            try
            {
                Result isValid = IsFormatValidForAdding();
                if (isValid.IsSuccess)
                {
                    PurchaseDetail purchaseDetail = new PurchaseDetail
                    {
                        PurchaseID = purchaseID,
                        BookID = int.Parse(txt_BookID.Text),
                        Quantity = int.Parse(txt_PurchaseQuantity.Text),
                        PurchasePrice = decimal.Parse(txt_PurchasePrice.Text)
                    };

                    Result result = new Result(true, "");

                    DataRow[] existBooks = GetPurchaseDetailsDataGridView().Select($"BookID = {purchaseDetail.BookID}");

                    if (existBooks.Length > 0)
                    {
                        if(MessageBox.Show("Sách đã có trong đơn hàng, bạn có muốn thêm số lượng hiện tại vào số lượng hiện có không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            purchaseDetail.Quantity += Convert.ToInt32(existBooks[0]["Quantity"]);
                            purchaseDetail.PurchaseDetailID = Convert.ToInt32(existBooks[0]["PurchaseDetailID"]);

                            result = _bllPurchaseDetail.UpdatePurchaseDetail(purchaseDetail);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        result = _bllPurchaseDetail.AddPurchaseDetail(purchaseDetail);
                    }
                    if (result.IsSuccess)
                    {
                        MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show(isValid.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadBooksDataGridView();
                LoadPurchaseDetailsDataGridView();
            }
        }



        private Result IsFormatValidForUpdating()
        {
            if (string.IsNullOrEmpty(txt_PurchaseDetailID.Text))
            {
                return new Result(false, "Vui lòng chọn chi tiết đơn hàng để cập nhật.");
            }
            if (string.IsNullOrEmpty(txt_BookID.Text))
            {
                return new Result(false, "Vui lòng nhập mã sách.");
            }
            if (string.IsNullOrEmpty(txt_PurchaseQuantity.Text))
            {
                return new Result(false, "Vui lòng nhập số lượng.");
            }
            if (string.IsNullOrEmpty(txt_PurchasePrice.Text))
            {
                return new Result(false, "Vui lòng nhập giá nhập.");
            }
            if (!int.TryParse(txt_PurchaseQuantity.Text, out int a))
            {
                if (a <= 0) { return new Result(false, "Số lượng phải là số nguyên dương."); }
                return new Result(false, "Số lượng phải là số nguyên.");
            }
            if (!decimal.TryParse(txt_PurchasePrice.Text, out decimal b))
            {
                if (b <= 0) { return new Result(false, "Giá nhập phải là số dương."); }
                return new Result(false, "Giá nhập phải là số.");
            }
            return new Result(true, "");
        }

        private void UpdatePurchaseDetail()
        {
            try
            {
                Result isValid = IsFormatValidForUpdating();
                if (isValid.IsSuccess)
                {
                    PurchaseDetail purchaseDetail = new PurchaseDetail
                    {
                        PurchaseDetailID = int.Parse(txt_PurchaseDetailID.Text),
                        BookID = int.Parse(txt_BookID.Text),
                        Quantity = int.Parse(txt_PurchaseQuantity.Text),
                        PurchasePrice = decimal.Parse(txt_PurchasePrice.Text)
                    };
                    Result result = _bllPurchaseDetail.UpdatePurchaseDetail(purchaseDetail);
                    if (result.IsSuccess)
                    {
                        MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(isValid.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadBooksDataGridView();
                LoadPurchaseDetailsDataGridView();
            }
        }


        private Result IsFormatValidForDeleting()
        {
            if (string.IsNullOrEmpty(txt_PurchaseDetailID.Text))
            {
                return new Result(false, "Vui lòng chọn chi tiết đơn hàng để xóa.");
            }
            return new Result(true, "");
        }

        private void DeletePurchaseDetail()
        {
            try
            {
                Result isValid = IsFormatValidForDeleting();
                if (isValid.IsSuccess)
                {
                    int purchaseDetailID = int.Parse(txt_PurchaseDetailID.Text);
                    Result result = _bllPurchaseDetail.DeletePurchaseDetail(purchaseDetailID);
                    if (result.IsSuccess)
                    {
                        MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(isValid.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadBooksDataGridView();
                LoadPurchaseDetailsDataGridView();
            }
        }


        private Result IsFormatValidForSearching()
        {
            if (string.IsNullOrEmpty(txt_SearchValue.Text))
            {
                return new Result(false, "Vui lòng nhập giá trị tìm kiếm.");
            }
            if (cbb_SearchOptions.SelectedValue == null)
            {
                return new Result(false, "Vui lòng chọn tùy chọn tìm kiếm.");
            }
            return new Result(true, "");
        }

        private DataTable FilterBook(string searchOption, string searchTerm)
        {
            try
            {
                DataTable data = GetBooksDataTableView();
                DataView dv = data.DefaultView;

                switch (searchOption)
                {
                    case "BookID":
                        dv.RowFilter = $"Convert(BookID, 'System.String') LIKE '%{searchTerm}%'"; 
                        break;
                    case "Title":
                        dv.RowFilter = $"Title LIKE '%{searchTerm}%'";
                        break;
                    case "Author":
                        dv.RowFilter = $"Author LIKE '%{searchTerm}%'";
                        break;
                    case "Publisher":
                        dv.RowFilter = $"Publisher LIKE '%{searchTerm}%'";
                        break;
                    case "CategoryName":
                        dv.RowFilter = $"CategoryName LIKE '%{searchTerm}%'";
                        break;
                    case "General":
                        dv.RowFilter = $"Title LIKE '%{searchTerm}%' OR Author LIKE '%{searchTerm}%' OR Publisher LIKE '%{searchTerm}%' OR CategoryName LIKE '%{searchTerm}%' OR Convert(BookID, 'System.String') LIKE '%{searchTerm}%'";
                        break;
                    default:
                        dv.RowFilter = string.Empty;
                        break;
                }
                return dv.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void SearchBooks()
        {
            try
            {
                Result isValid = IsFormatValidForSearching();
                if (isValid.IsSuccess)
                {
                    string searchOption = cbb_SearchOptions.SelectedValue.ToString();
                    string searchTerm = txt_SearchValue.Text.Trim();

                    DataTable data = FilterBook(searchOption, searchTerm);
                    dgv_Books.DataSource = data;
                }
                else
                {
                    MessageBox.Show(isValid.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_SachThucThi_Click(object sender, EventArgs e)
        {
            if (rad_Them.Checked)
            {
                AddPurchaseDetail();
            }
            else if (rad_Sua.Checked)
            {
                UpdatePurchaseDetail();
            }
            else if (rad_Xoa.Checked)
            {
                DeletePurchaseDetail();
            }
            else if (rad_TimKiem.Checked)
            {
                SearchBooks();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hành động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
