using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Purchase : Form
    {
        private BLL_Purchase _bllPurchase;
        public GUI_Purchase()
        {
            InitializeComponent();
            _bllPurchase = new BLL_Purchase();
        }

        private void GUI_Purchase_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadSearchOptionsCombobox();
        }

        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = _bllPurchase.GetAllPurchases();
                dgv_Purchases.DataSource = dt;
                dgv_Purchases.Columns["PurchaseID"].HeaderText = "Mã đơn hàng";
                dgv_Purchases.Columns["PurchaseID"].Width = 100;
                dgv_Purchases.Columns["PurchaseDate"].HeaderText = "Ngày đặt hàng";
                dgv_Purchases.Columns["PurchaseDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv_Purchases.Columns["SupplierID"].HeaderText = "Mã nhà cung cấp";
                dgv_Purchases.Columns["SupplierName"].HeaderText = "Tên nhà cung cấp";
                dgv_Purchases.Columns["EmployeeID"].HeaderText = "Mã nhân viên";
                dgv_Purchases.Columns["EmployeeName"].HeaderText = "Tên nhân viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadSearchOptionsCombobox()
        {
            try
            {
                Dictionary<string, string> searchOptions = new Dictionary<string, string>()
                {
                    {"PurchaseID", "Mã đơn hàng"},
                    {"PurchaseDate", "Ngày đặt hàng"},
                    {"SupplierID", "Mã nhà cung cấp"},
                    {"SupplierName", "Tên nhà cung cấp"},
                    {"EmployeeID", "Mã nhân viên"},
                    {"EmployeeName", "Tên nhân viên"},
                    {"General", "Tìm kiếm tổng quát"}
                };

                cbb_SearchOptions.DataSource = new BindingSource(searchOptions, null);
                cbb_SearchOptions.DisplayMember = "Value";
                cbb_SearchOptions.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgv_Purchases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Purchases.Rows[e.RowIndex];
                txt_PurchaseID.Text = row.Cells["PurchaseID"].Value.ToString();
                dtp_PurchaseDate.Value = Convert.ToDateTime(row.Cells["PurchaseDate"].Value);
                txt_SupplierID.Text = row.Cells["SupplierID"].Value.ToString();
                txt_SupplierName.Text = row.Cells["SupplierName"].Value.ToString();
                txt_EmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
                txt_EmployeeName.Text = row.Cells["EmployeeName"].Value.ToString();
            }
        }

        private void btn_HuyTimKiem_Click(object sender, EventArgs e)
        {
            txt_SearchTerm.Clear();
            LoadDataGridView();
        }

        private void ClearInputFields()
        {
            txt_PurchaseID.Clear();
            txt_SupplierID.Clear();
            txt_EmployeeID.Clear();
            dtp_PurchaseDate.Value = DateTime.Now;
            txt_SupplierName.Clear();
            txt_EmployeeName.Clear();
        }
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private Result IsFormatValidForAddingPurchase()
        {
            if (string.IsNullOrEmpty(txt_PurchaseID.Text))
            {
                return new Result(false, "Mã đơn hàng không được để trống");
            }
            if (int.TryParse(txt_PurchaseID.Text, out int purchaseId) == false)
            {
                return new Result(false, "Mã đơn hàng phải là số nguyên không dấu");
            }

            if (string.IsNullOrEmpty(txt_SupplierID.Text))
            {
                return new Result(false, "Mã nhà cung cấp không được để trống");
            }
            if (int.TryParse(txt_SupplierID.Text, out int supplierId) == false)
            {
                return new Result(false, "Mã nhà cung cấp phải là số nguyên không dấu");
            }
            if (string.IsNullOrEmpty(txt_EmployeeID.Text))
            {
                return new Result(false, "Mã nhân viên không được để trống");
            }
            if (int.TryParse(txt_EmployeeID.Text, out int employeeId) == false)
            {
                return new Result(false, "Mã nhân viên phải là số nguyên không dấu");
            }
            if (dtp_PurchaseDate.Value > DateTime.Now)
            {
                return new Result(false, "Ngày đặt hàng không được lớn hơn ngày hiện tại");
            }
            return new Result(true, "");
        }

        private void AddPurchase()
        {
            try
            {
                Result validationResult = IsFormatValidForAddingPurchase();
                if (validationResult.IsSuccess)
                {
                    Purchase purchase = new Purchase(
                        int.Parse(txt_PurchaseID.Text),
                        dtp_PurchaseDate.Value,
                        int.Parse(txt_SupplierID.Text),
                        int.Parse(txt_EmployeeID.Text)
                    );
                    Result result = _bllPurchase.AddPurchase(purchase);
                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Thêm đơn hàng thành công");
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show(validationResult.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                LoadDataGridView();
            }
        }

        private Result IsFormatValidForUpdatingPurchase()
        {
            return IsFormatValidForAddingPurchase();
        }

        private void UpdatePurchase()
        {
            try
            {
                Result validationResult = IsFormatValidForUpdatingPurchase();
                if (validationResult.IsSuccess)
                {
                    Purchase purchase = new Purchase(
                        int.Parse(txt_PurchaseID.Text),
                        dtp_PurchaseDate.Value,
                        int.Parse(txt_SupplierID.Text),
                        int.Parse(txt_EmployeeID.Text)
                    );
                    Result result = _bllPurchase.UpdatePurchase(purchase);
                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Cập nhật đơn hàng thành công");
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show(validationResult.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                LoadDataGridView();
            }
        }


        private Result IsFormatValidForDeletingPurchase()
        {
            if (string.IsNullOrEmpty(txt_PurchaseID.Text))
            {
                return new Result(false, "Mã đơn hàng không được để trống");
            }
            if (int.TryParse(txt_PurchaseID.Text, out int purchaseId) == false)
            {
                return new Result(false, "Mã đơn hàng phải là số nguyên không dấu");
            }
            return new Result(true, "");
        }

        private void DeletePurchase()
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa đơn hàng này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Result validationResult = IsFormatValidForDeletingPurchase();
                    if (validationResult.IsSuccess)
                    {
                        int purchaseId = int.Parse(txt_PurchaseID.Text);
                        Result result = _bllPurchase.DeletePurchase(purchaseId);
                        if (result.IsSuccess)
                        {
                            MessageBox.Show("Xóa đơn hàng thành công");
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show(result.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show(validationResult.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                LoadDataGridView();
            }
        }

        private Result IsFormatValidForSearchingPurchase()
        {
            if (string.IsNullOrEmpty(txt_SearchTerm.Text))
            {
                return new Result(false, "Vui lòng nhập từ khóa tìm kiếm");
            }

            if (cbb_SearchOptions.SelectedValue == null)
            {
                return new Result(false, "Vui lòng chọn tùy chọn tìm kiếm");
            }

            return new Result(true, "");
        }

        private void SearchPurchases()
        {
            try
            {
                Result validationResult = IsFormatValidForSearchingPurchase();
                if (validationResult.IsSuccess)
                {
                    string searchOption = cbb_SearchOptions.SelectedValue.ToString();
                    string searchValue = txt_SearchTerm.Text.Trim();
                    DataTable dt = _bllPurchase.SearchPurchases(searchOption, searchValue);
                    dgv_Purchases.DataSource = dt;
                }
                else
                {
                    MessageBox.Show(validationResult.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void btn_ThucThi_Click(object sender, EventArgs e)
        {
            if (rad_Them.Checked)
            {
                AddPurchase();
            }
            else if (rad_Sua.Checked)
            {
                UpdatePurchase();
            }
            else if (rad_Xoa.Checked)
            {
                DeletePurchase();
            }
            else if (rad_TimKiem.Checked)
            {
                SearchPurchases();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chức năng");
            }
        }

        private void btn_PurchaseDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_PurchaseID.Text))
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết");
                return;
            }
            if (!int.TryParse(txt_PurchaseID.Text, out int l_purchaseId) && l_purchaseId > 0)
            {
                MessageBox.Show("Mã đơn hàng không hợp lệ");
                return;
            }


            int purchaseId = int.Parse(txt_PurchaseID.Text);
            try
            {
                if (_bllPurchase.GetPurchaseByID(purchaseId).Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng với mã " + purchaseId);
                }
                else
                {
                    GUI_PurchaseDetail purchaseDetailForm = new GUI_PurchaseDetail(purchaseId);
                    purchaseDetailForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
