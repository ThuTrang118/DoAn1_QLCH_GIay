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
    public partial class frmQuanLyNhaCungCap : Form
    {
        public frmQuanLyNhaCungCap()
        {
            InitializeComponent();
        }
        BUS_QuanLyNhaCungCap ncc = new BUS_QuanLyNhaCungCap();
        private void UpdateNhaCungCapDataGrid()
        {
            DataTable dt = ncc.ShowNhaCungCap();
            dgNCC.DataSource = dt;
            foreach (DataGridViewColumn column in dgNCC.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgNCC.Refresh();
        }
        private void frmQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ncc.ShowNhaCungCap();
            dgNCC.DataSource = dt;
            foreach (DataGridViewColumn column in dgNCC.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            UpdateNhaCungCapDataGrid();
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

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            string MaNCC = this.txtMaNCC.Text.Trim(); 
            if (string.IsNullOrEmpty(MaNCC))
            {
                MessageBox.Show("Vui lòng không bỏ trống mã nhà cung cấp");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtTenNCC.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!");
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
                if (ncc.KiemTraMaNhaCungCapTonTai(MaNCC))
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại. Vui lòng chọn mã khác.");
                    return;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn thêm nhà cung cấp có mã " + MaNCC + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ncc.InsertNhaCungCap(MaNCC, this.txtTenNCC.Text, this.txtGioiTinh.Text, this.txtDiaChi.Text, this.txtSDT.Text, this.txtEmail.Text);
                        MessageBox.Show("Đã thêm nhà cung cấp có mã " + MaNCC + " thành công");
                        frmQuanLyNhaCungCap_Load(sender, e);
                        UpdateNhaCungCapDataGrid();
                    }
                }
            }

        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtMaNCC.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống!");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtTenNCC.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!");
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
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ncc.Updatenhacc(this.txtMaNCC.Text, this.txtTenNCC.Text, this.txtGioiTinh.Text, this.txtDiaChi.Text, this.txtSDT.Text, this.txtEmail.Text);
                MessageBox.Show("Đã cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmQuanLyNhaCungCap_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            if (this.txtMaNCC.TextLength == 0)
            {
                MessageBox.Show("Vui lòng chọn thông tin nhà cung cấp bạn muốn xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xóa nhà cung cấp có mã: " + txtMaNCC.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    ncc.Deletenhacc(txtMaNCC.Text);
                    MessageBox.Show("Đã xóa nhà cung cấp có mã: " + txtMaNCC.Text + " thành công");
                    frmQuanLyNhaCungCap_Load(sender, e); 
                    UpdateNhaCungCapDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message);
                }
            }
        }

        private void btnTimKiemNCC_Click(object sender, EventArgs e)
        {
            if (this.txtTimKiem.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập thông tin nhà cung cấp cần tìm kiếm");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = ncc.LookNhaCungCap(this.txtTimKiem.Text);
                dgNCC.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin về nhà cung cấp");
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTimKiem.TextLength == 0)
            {
                frmQuanLyNhaCungCap_Load(sender, e);
            }
        }

        private void dgNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dgNCC.CurrentCell.RowIndex;
                if (dgNCC.Rows[dong].Cells["MaNCC"].Value != null)
                {
                    txtMaNCC.Text = dgNCC.Rows[dong].Cells["MaNCC"].Value.ToString();
                }
                if (dgNCC.Rows[dong].Cells["TenNCC"].Value != null)
                {
                    txtTenNCC.Text = dgNCC.Rows[dong].Cells["TenNCC"].Value.ToString();
                }
                if (dgNCC.Rows[dong].Cells["GioiTinh"].Value != null)
                {
                    txtGioiTinh.Text = dgNCC.Rows[dong].Cells["GioiTinh"].Value.ToString();
                }
                if (dgNCC.Rows[dong].Cells["DiaChiNCC"].Value != null)
                {
                    txtDiaChi.Text = dgNCC.Rows[dong].Cells["DiaChiNCC"].Value.ToString();
                }
                if (dgNCC.Rows[dong].Cells["SDTNCC"].Value != null)
                {
                    txtSDT.Text = dgNCC.Rows[dong].Cells["SDTNCC"].Value.ToString();
                }
                if (dgNCC.Rows[dong].Cells["Email"].Value != null)
                {
                    txtEmail.Text = dgNCC.Rows[dong].Cells["Email"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public event EventHandler NhaCungCapAdded;

        protected virtual void OnNhaCungCapAdded(EventArgs e)
        {
            NhaCungCapAdded?.Invoke(this, e);
        }

    }
}
