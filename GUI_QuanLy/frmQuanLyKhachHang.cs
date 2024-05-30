using BUS_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class frmQuanLyKhachHang : Form
    {
        private BUS_QuanLyKhachHang kh = new BUS_QuanLyKhachHang();
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
        }
        private void UpdateKhachHangDataGrid()
        {
            DataTable dt = kh.ShowKhachHang();
            dgKH.DataSource = dt;
            foreach (DataGridViewColumn column in dgKH.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgKH.Refresh();
        }

        private void btnMoi_Click_1(object sender, EventArgs e)
        {
            this.txtMaKH.Clear();
            this.txtTenKH.Clear();
            this.txtGioiTinh.Clear();
            this.txtSDT.Clear();
            this.txtEmail.Clear();
            this.txtDiaChi.Clear();
        }
        private bool IsPhoneNumberValid(string phoneNumber)
        {
            if (phoneNumber.Length != 10)
            {
                return false;
            }
            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaKH = this.txtMaKH.Text.Trim();

            if (string.IsNullOrEmpty(MaKH))
            {
                MessageBox.Show("Vui lòng điền mã khách hàng");
            }
            else
            {
                if (kh.KiemTraMaKhachHangTonTai(MaKH))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng chọn mã khác.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(this.txtTenKH.Text))
                {
                    MessageBox.Show("Tên khách hàng không được để trống!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(this.txtGioiTinh.Text))
                {
                    MessageBox.Show("Giới tính không được để trống!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.txtDiaChi.Text))
                {
                    MessageBox.Show("Địa chỉ không được để trống!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(this.txtSDT.Text) || !IsPhoneNumberValid(this.txtSDT.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(this.txtEmail.Text) || !IsEmailValid(this.txtEmail.Text))
                {
                    MessageBox.Show("Email không hợp lệ!");
                    return;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn thêm khách hàng có mã " + this.txtMaKH.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        kh.InsertKhachHang(this.txtMaKH.Text, this.txtTenKH.Text, this.txtGioiTinh.Text, this.txtDiaChi.Text, this.txtSDT.Text, this.txtEmail.Text);
                        MessageBox.Show("Đã thêm khách hàng có mã " + this.txtMaKH.Text + " thành công");
                        UpdateKhachHangDataGrid();
                    }
                }
            }
        }
        private void ShowQuanLyKhachHangForm()
        {
            frmQuanLyKhachHang quanLyKhachHangForm = new frmQuanLyKhachHang();
            quanLyKhachHangForm.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string makh = this.txtMaKH.Text.Trim();

            if (this.txtMaKH.TextLength == 0)
            {
                MessageBox.Show("Vui lòng chọn mã khách hàng bạn muốn sửa!");
            }
            if (string.IsNullOrWhiteSpace(this.txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtGioiTinh.Text))
            {
                MessageBox.Show("Giới tính không được để trống!");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtSDT.Text) || !IsPhoneNumberValid(this.txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtEmail.Text) || !IsEmailValid(this.txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin khách hàng này không?", "Sửa thông tin khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    kh.UpdateKhachHang(this.txtMaKH.Text, this.txtTenKH.Text, this.txtGioiTinh.Text, this.txtDiaChi.Text, this.txtSDT.Text, this.txtEmail.Text);
                    MessageBox.Show("Đã sửa khách hàng có mã " + this.txtMaKH.Text + " thành công");
                    UpdateKhachHangDataGrid();
                }
            }
        }

        private bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.txtMaKH.TextLength == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng bạn muốn xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xóa khách hàng có mã " + this.txtMaKH.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    kh.DeleteKhachHang(txtMaKH.Text);
                    MessageBox.Show("Đã xóa khách hàng có mã " + this.txtMaKH.Text + " thành công");
                    UpdateKhachHangDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (this.txtTimKiem.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm");
                return;
            }
            else
            {
                DataTable dt = kh.LookKhachHang(this.txtTimKiem.Text);
                dgKH.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng");
                }
            }
        }



        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            UpdateKhachHangDataGrid();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTimKiem.TextLength == 0)
            {
                UpdateKhachHangDataGrid();
            }
        }

        private void dgKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dgKH.CurrentCell.RowIndex;
                if (dgKH.Rows[dong].Cells["MaKH"].Value != null)
                {
                    txtMaKH.Text = dgKH.Rows[dong].Cells["MaKH"].Value.ToString();
                }
                if (dgKH.Rows[dong].Cells["TenKH"].Value != null)
                {
                    txtTenKH.Text = dgKH.Rows[dong].Cells["TenKH"].Value.ToString();
                }
                if (dgKH.Rows[dong].Cells["GioiTinh"].Value != null)
                {
                    txtGioiTinh.Text = dgKH.Rows[dong].Cells["GioiTinh"].Value.ToString();
                }
                if (dgKH.Rows[dong].Cells["DiaChi"].Value != null)
                {
                    txtDiaChi.Text = dgKH.Rows[dong].Cells["DiaChi"].Value.ToString();
                }
                if (dgKH.Rows[dong].Cells["SDT"].Value != null)
                {
                    txtSDT.Text = dgKH.Rows[dong].Cells["SDT"].Value.ToString();
                }
                if (dgKH.Rows[dong].Cells["Email"].Value != null)
                {
                    txtEmail.Text = dgKH.Rows[dong].Cells["Email"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
