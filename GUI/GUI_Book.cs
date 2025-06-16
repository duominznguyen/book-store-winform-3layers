using BLL;
using System;
using System.Windows.Forms;
using Entities;
using System.Data;
namespace GUI
{
    public partial class GUI_Book : Form
    {
        private BLL_Book _bllBook;
        private BLL_BookCategory _bllBookCategory;
        public GUI_Book()
        {
            InitializeComponent();
            _bllBook = new BLL_Book();
            _bllBookCategory = new BLL_BookCategory();
        }

        private void GUI_Book_Load(object sender, EventArgs e)
        {
            LoadDGV();
            LoadCbb_TheLoai();
            LoadCbb_LuaChonTimKiem();
        }

        private void LoadDGV()
        {
            dgv_Sach.DataSource = _bllBook.GetAllBooks();
            dgv_Sach.Columns["Price"].DefaultCellStyle.Format = "N0";
        }

        private void LoadCbb_TheLoai()
        {
            cbb_TheLoai.DataSource = _bllBookCategory.GetAllBookCategories();
            cbb_TheLoai.DisplayMember = "CategoryName";
            cbb_TheLoai.ValueMember = "CategoryID";
        }

        private void LoadCbb_LuaChonTimKiem()
        {
            cbb_LuaChonTimKiem.Items.Add("Tìm theo tên sách");
            cbb_LuaChonTimKiem.Items.Add("Tìm theo tên tác giả");
            cbb_LuaChonTimKiem.Items.Add("Tìm theo nhà xuất bản");
            cbb_LuaChonTimKiem.Items.Add("Tìm theo thể loại");
            cbb_LuaChonTimKiem.Items.Add("Tìm theo ID");
            cbb_LuaChonTimKiem.SelectedIndex = 0;
        }

        private void dgv_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_Id.Text = dgv_Sach.Rows[e.RowIndex].Cells["BookID"].Value.ToString();
                txt_TieuDe.Text = dgv_Sach.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                txt_TacGia.Text = dgv_Sach.Rows[e.RowIndex].Cells["Author"].Value.ToString();
                txt_NhaXB.Text = dgv_Sach.Rows[e.RowIndex].Cells["Publisher"].Value.ToString();
                txt_Gia.Text = dgv_Sach.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                rtxt_MoTa.Text = dgv_Sach.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                var selectedCategory = dgv_Sach.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();
                if (selectedCategory != "")
                {
                    cbb_TheLoai.SelectedValue = dgv_Sach.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();
                }
                else
                {
                    cbb_TheLoai.SelectedIndex = -1;
                }
                txt_TonKho.Text = dgv_Sach.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btn_ThucThi_Click(object sender, EventArgs e)
        {
            if (rad_Them.Checked)
            {
                AddBook();
            }
            else if (rad_Sua.Checked)
            {
                UpdateBook();
            }
            else if (rad_Xoa.Checked)
            {
                DeleteBook();
            }
            else if (rad_TimKiem.Checked)
            {
                SearchBook();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chức năng!");
            }
        }

        private void AddBook()
        {
            if (CheckInputForAdd())
            {
                try
                {
                    Book book = new Book();
                    book.Title = txt_TieuDe.Text;           
                    book.Author = txt_TacGia.Text;
                    book.Publisher = txt_NhaXB.Text;
                    book.Price = float.Parse(txt_Gia.Text);
                    book.Description = rtxt_MoTa.Text;
                    book.Quantity = int.Parse(txt_TonKho.Text);
                    book.CategoryID = cbb_TheLoai.SelectedValue.ToString();
                    if (_bllBook.AddBook(book))
                    {
                        MessageBox.Show("Thêm sách thành công!");
                        LoadDGV();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sách thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    LoadDGV() ;
                }
            }
        }
        private void UpdateBook()
        {

            if (CheckInputForUpdate())
            {
                try
                {
                    Book book = new Book();
                    book.BookID = txt_Id.Text;
                    book.Title = txt_TieuDe.Text;
                    book.Author = txt_TacGia.Text;
                    book.Publisher = txt_NhaXB.Text;
                    book.Price = float.Parse(txt_Gia.Text);
                    book.Description = rtxt_MoTa.Text;
                    book.Quantity = int.Parse(txt_TonKho.Text);
                    book.CategoryID = cbb_TheLoai.SelectedValue.ToString();
                    if (_bllBook.UpdateBook(book))
                    {
                        MessageBox.Show("Cập nhật sách thành công!");
                        LoadDGV();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sách thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    LoadDGV();
                }

            }
        }
        private void DeleteBook()
        {
            if (CheckInputForDelete())
            {
                try
                {
                    string bookID = txt_Id.Text;
                    if (_bllBook.DeleteBook(bookID))
                    {
                        MessageBox.Show("Xóa sách thành công!");
                        LoadDGV();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sách thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    LoadDGV();
                }
            }
        }
        private void SearchBook()
        {
            if (cbb_LuaChonTimKiem.Text == "Tìm theo tên sách")
            {
                string title = txt_TieuDe.Text;
                dgv_Sach.DataSource = _bllBook.GetAllBooks().Select("Title LIKE '%" + title + "%'").CopyToDataTable();
            }
            else if (cbb_LuaChonTimKiem.Text == "Tìm theo tên tác giả")
            {
                string author = txt_TacGia.Text;
                dgv_Sach.DataSource = _bllBook.GetAllBooks().Select("Author LIKE '%" + author + "%'").CopyToDataTable();
            }
            else if (cbb_LuaChonTimKiem.Text == "Tìm theo nhà xuất bản")
            {
                string publisher = txt_NhaXB.Text;
                dgv_Sach.DataSource = _bllBook.GetAllBooks().Select("Publisher LIKE '%" + publisher + "%'").CopyToDataTable();
            }
            else if (cbb_LuaChonTimKiem.Text == "Tìm theo thể loại")
            {
                string categoryID = cbb_TheLoai.SelectedValue.ToString();
                dgv_Sach.DataSource = _bllBook.GetAllBooks().Select("CategoryID='" + categoryID + "'").CopyToDataTable();
            }
            else if (cbb_LuaChonTimKiem.Text == "Tìm theo ID")
            {
                string bookID = txt_Id.Text;
                dgv_Sach.DataSource = _bllBook.GetAllBooks().Select("BookID='" + bookID + "'").CopyToDataTable();
            }

        }

        private void btn_HuyTimKiem_Click(object sender, EventArgs e)
        {
            LoadDGV();
            LamMoi();
        }

        private void LamMoi()
        {
            txt_Id.Clear();
            txt_TieuDe.Clear();
            txt_TacGia.Clear();
            txt_NhaXB.Clear();
            txt_Gia.Clear();
            rtxt_MoTa.Clear();
            cbb_TheLoai.SelectedIndex = -1;
            txt_TonKho.Clear();
        }

        private bool CheckInputForAdd()
        {
            if (string.IsNullOrWhiteSpace(txt_Id.Text) || string.IsNullOrWhiteSpace(txt_TieuDe.Text) ||
                string.IsNullOrWhiteSpace(txt_TacGia.Text) || string.IsNullOrWhiteSpace(txt_NhaXB.Text) ||
                string.IsNullOrWhiteSpace(txt_Gia.Text) || string.IsNullOrWhiteSpace(rtxt_MoTa.Text) ||
                cbb_TheLoai.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txt_TonKho.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return false;
            }
            return true;
        }

        private bool CheckInputForUpdate()
        {
            if (string.IsNullOrWhiteSpace(txt_Id.Text) || string.IsNullOrWhiteSpace(txt_TieuDe.Text) ||
                string.IsNullOrWhiteSpace(txt_TacGia.Text) || string.IsNullOrWhiteSpace(txt_NhaXB.Text) ||
                string.IsNullOrWhiteSpace(txt_Gia.Text) || string.IsNullOrWhiteSpace(rtxt_MoTa.Text) ||
                cbb_TheLoai.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txt_TonKho.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return false;
            }
            return true;
        }

        private bool CheckInputForDelete()
        {
            if (string.IsNullOrWhiteSpace(txt_Id.Text))
            {
                MessageBox.Show("Vui lòng chọn sách để xóa!");
                return false;
            }
            return true;
        }

        private void GUI_Book_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        private void txt_Gia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

    }
}
