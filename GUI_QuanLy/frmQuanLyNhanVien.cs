using BUS_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI_QuanLy
{
    public partial class frmQuanLyNhanVien : Form
    {
        private readonly string ThuTrang;
        private readonly bool QuanTriVien;
        BUS_QuanLyNhanVien nhanvien = new BUS_QuanLyNhanVien();
        BUS_QuanLyLuong luong = new BUS_QuanLyLuong();
        public frmQuanLyNhanVien(string username, bool isAdmin)
        {
            InitializeComponent();
            ThuTrang = username;
            QuanTriVien = isAdmin;
            CheckAccessPermission();
            LoadDanhSachNhanVien();
            LoadDanhSachLuong();
            dgNV.CellFormatting += new DataGridViewCellFormattingEventHandler(dgNV_CellFormatting);
        }
        private void CheckAccessPermission()
        {
            if (!QuanTriVien)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
            LoadDanhSachNhanVien();
            LoadDanhSachLuong();
        }
        private void LoadDanhSachNhanVien()
        {
            try
            {
                DataTable dt = nhanvien.ShowNhanVien();
                dgNV.DataSource = dt;

                foreach (DataGridViewColumn column in dgNV.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                dgNV.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message);
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string MaNV = this.txtMaNV.Text.Trim();

            if (string.IsNullOrEmpty(MaNV))
            {
                MessageBox.Show("Mã nhân viên không được bỏ trống");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtGioiTinh.Text))
            {
                MessageBox.Show("Giới tính không được để trống!");
                return;
            }
            if (!DateTime.TryParseExact(this.dtNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ!");
                return;
            }
            // Kiểm tra xem đã đủ 18 tuổi chưa
            DateTime today = DateTime.Today;
            int age = today.Year - ngaySinh.Year;

            if (ngaySinh.Date > today.AddYears(-age)) age--;

            if (age < 18)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi.");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtSDT.Text) || !int.TryParse(this.txtSDT.Text, out int sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Số điện thoại phải là số nguyên.");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtEmail.Text) || !IsEmailValid(this.txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtMatKhau.Text) || !int.TryParse(this.txtMatKhau.Text, out int matKhau))
            {
                MessageBox.Show("Mật khẩu không hợp lệ! Mật khẩu phải là số nguyên.");
                return;
            }
            if (nhanvien.KiemTraMaNhanVienTonTai(MaNV))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng chọn mã khác.");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm mã nhân viên " + MaNV + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    nhanvien.InsertNhanVien(MaNV, this.txtTenNV.Text, ngaySinh, this.txtGioiTinh.Text, this.txtDiaChi.Text, this.txtEmail.Text, sdt, this.txtTaiKhoan.Text, this.txtMatKhau.Text);
                    MessageBox.Show("Nhân viên đã được thêm thành công.");
                    LoadDanhSachNhanVien();
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
        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtGioiTinh.Text = "";
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtGioiTinh.Text))
            {
                MessageBox.Show("Giới tính không được để trống!");
                return;
            }
            if (!DateTime.TryParseExact(this.dtNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Định dạng phải là dd/MM/yyyy.");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtSDT.Text) || !int.TryParse(this.txtSDT.Text, out int sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Số điện thoại phải là số nguyên.");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtEmail.Text) || !IsEmailValid(this.txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtMatKhau.Text) || !int.TryParse(this.txtMatKhau.Text, out int matKhau))
            {
                MessageBox.Show("Mật khẩu không hợp lệ! Mật khẩu phải là số nguyên.");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                nhanvien.UpdateNhanVien(this.txtMaNV.Text, this.txtTenNV.Text, ngaySinh, this.txtGioiTinh.Text, this.txtDiaChi.Text, this.txtEmail.Text, sdt, this.txtTaiKhoan.Text, this.txtMatKhau.Text);
                MessageBox.Show("Đã cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachNhanVien();
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (this.txtMaNV.TextLength == 0)
            {
                MessageBox.Show("Chọn mã nhân viên để xóa.");
            }
            else
            {
                // Hiển thị hộp thoại xác nhận xóa nhân viên
                DialogResult result = MessageBox.Show("Bạn có muốn xóa nhân viên có mã " + txtMaNV.Text + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra nếu người dùng chọn Yes thì mới thực hiện xóa
                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa nhân viên từ cơ sở dữ liệu
                    nhanvien.DeleteNhanVien(txtMaNV.Text);

                    // Hiển thị thông báo xóa thành công
                    MessageBox.Show("Đã xóa nhân viên có mã " + txtMaNV.Text + " thành công.");

                    // Tải lại dữ liệu sau khi xóa
                    LoadDanhSachNhanVien();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (this.txtTimKiem.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm");
            }
            else
            {
                DataTable dt = nhanvien.LookNhanVien(this.txtTimKiem.Text);
                dgNV.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên");
                }
            }
        }

        private void dgNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dgNV.CurrentCell.RowIndex;
                if (dgNV.Rows[dong].Cells["MaNV"].Value != null)
                {
                    txtMaNV.Text = dgNV.Rows[dong].Cells["MaNV"].Value.ToString();
                }
                if (dgNV.Rows[dong].Cells["TenNV"].Value != null)
                {
                    txtTenNV.Text = dgNV.Rows[dong].Cells["TenNV"].Value.ToString();
                }
                if (dgNV.Rows[dong].Cells["NgaySinh"].Value != null)
                {
                    dtNgaySinh.Text = dgNV.Rows[dong].Cells["NgaySinh"].Value.ToString();
                }
                if (dgNV.Rows[dong].Cells["GioiTinh"].Value != null)
                {
                    txtGioiTinh.Text = dgNV.Rows[dong].Cells["GioiTinh"].Value.ToString();
                }
                if (dgNV.Rows[dong].Cells["SDT"].Value != null)
                {
                    txtSDT.Text = dgNV.Rows[dong].Cells["SDT"].Value.ToString();
                }
                if (dgNV.Rows[dong].Cells["DiaChi"].Value != null)
                {
                    txtDiaChi.Text = dgNV.Rows[dong].Cells["DiaChi"].Value.ToString();
                }
                if (dgNV.Rows[dong].Cells["Email"].Value != null)
                {
                    txtEmail.Text = dgNV.Rows[dong].Cells["Email"].Value.ToString();
                }
                if (dgNV.Rows[dong].Cells["TK"].Value != null)
                {
                    txtTaiKhoan.Text = dgNV.Rows[dong].Cells["TK"].Value.ToString();
                }
                if (dgNV.Rows[dong].Cells["MK"].Value != null)
                {
                    txtMatKhau.Text = dgNV.Rows[dong].Cells["MK"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTimKiem.TextLength == 0)
            {
                LoadDanhSachNhanVien();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = nhanvien.ShowNhanVien();
            dgNV.DataSource = dt;
            foreach (DataGridViewColumn column in dgNV.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        /// <summary>
        /// LƯƠNG 
        /// </summary>

        private void LoadDanhSachLuong()
        {
            try
            {
                DataTable dt = luong.ShowLuong();
                foreach (DataRow row in dt.Rows)
                {
                    string maNV = row["MaNV"].ToString();
                    int doanhSo = luong.GetDoanhSoByMaNV(maNV);
                    row["DoanhSo"] = doanhSo;
                    float luongCB = float.Parse(row["LuongCB"].ToString());
                    float thuong = CalculateThuong(doanhSo);
                    float thucLinh = luongCB + thuong;
                    row["Thuong"] = thuong;
                    row["ThucLinh"] = thucLinh;
                }
                dgLuong.DataSource = dt;
                foreach (DataGridViewColumn column in dgLuong.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lương: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaNV = this.cboMaNV.Text.Trim();
            string MaLuong = this.txtMaLuong.Text.Trim();
            string LuongCBText = this.txtLuongCB.Text.Trim();
            if (string.IsNullOrEmpty(MaNV) || string.IsNullOrEmpty(MaLuong) || string.IsNullOrEmpty(LuongCBText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin lương nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (luong.KiemTraMaLuongTonTai(MaNV))
            {
                MessageBox.Show("Nhân viên này đã có thông tin về lương. Vui lòng chọn mã nhân viên khác.");
                return;
            }
            
            DialogResult result = MessageBox.Show("Bạn có muốn thêm lương nhân viên có mã là " + MaNV + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                float luongCB = float.Parse(this.txtLuongCB.Text);
                int doanhSo = luong.GetDoanhSoByMaNV(MaNV);
                float thuong = CalculateThuong(doanhSo);
                float thucLinh = luongCB + thuong;

                // Thêm lương nhân viên
                luong.InsertLuong(this.txtMaLuong.Text, MaNV, luongCB, doanhSo, thuong, thucLinh);

                MessageBox.Show("Nhân viên đã được thêm lương thành công.");
                LoadDanhSachLuong();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        { 
            string maNV = this.cboMaNV.Text.Trim();
            string maLuong = this.txtMaLuong.Text.Trim();
            string luongCBText = this.txtLuongCB.Text.Trim();

            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(maLuong))
            {
                MessageBox.Show("Vui lòng chọn nhân viên và nhập mã lương để cập nhật thông tin lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin lương  nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                float luongCB = float.Parse(this.txtLuongCB.Text);
                int doanhSo = luong.GetDoanhSoByMaNV(maNV);
                float thuong = CalculateThuong(doanhSo);
                float thucLinh = luongCB + thuong;

                // Cập nhật lương nhân viên
                luong.UpdateLuong(this.txtMaLuong.Text, maNV, luongCB, doanhSo,thuong, thucLinh);

                LoadDanhSachLuong();
            }
        }
        private float CalculateThuong(int doanhSo)
        {
            float thuong = 0;
            if (doanhSo == 0)
            {
                thuong = -100000;
            }
            else if (doanhSo < 5)
            {
                thuong = 100000;
            }
            else if (doanhSo >= 5 && doanhSo < 20)
            {
                thuong = 200000;
            }
            else if (doanhSo >= 20 && doanhSo < 30)
            {
                thuong = 300000;
            }
            else if (doanhSo >= 30)
            {
                thuong = 400000;
            }

            return thuong;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.txtMaLuong.TextLength == 0)
            {
                MessageBox.Show("Chọn mã lương để xóa lương!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa lương nhân viên có mã " + txtMaNV.Text + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    luong.DeleteLuong(txtMaLuong.Text);
                    MessageBox.Show("Đã xóa lương nhân viên có mã " + txtMaNV.Text + " thành công.");
                    LoadDanhSachLuong();
                }
            }
        }

        private void dgLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dgLuong.CurrentCell.RowIndex;
                if (dgLuong.Rows[dong].Cells["MaLuong"].Value != null)
                {
                    txtMaLuong.Text = dgLuong.Rows[dong].Cells["MaLuong"].Value.ToString();
                }
                if (dgLuong.Rows[dong].Cells["MaNV"].Value != null)
                {
                    cboMaNV.Text = dgLuong.Rows[dong].Cells["MaNV"].Value.ToString();
                }
                if (dgLuong.Rows[dong].Cells["LuongCB"].Value != null)
                {
                    txtLuongCB.Text = dgLuong.Rows[dong].Cells["LuongCB"].Value.ToString();
                }
                if (dgLuong.Rows[dong].Cells["DoanhSo"].Value != null)
                {
                    txtDoanhSo.Text = dgLuong.Rows[dong].Cells["DoanhSo"].Value.ToString();
                }
                if (dgLuong.Rows[dong].Cells["Thuong"].Value != null)
                {
                    txtThuong.Text = dgLuong.Rows[dong].Cells["Thuong"].Value.ToString();
                }
                if (dgLuong.Rows[dong].Cells["ThucLinh"].Value != null)
                {
                    txtThucLinh.Text = dgLuong.Rows[dong].Cells["ThucLinh"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message);
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            LoadDanhSachLuong();
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = luong.ShowLuong();
            dgLuong.DataSource = dt;
            foreach (DataGridViewColumn column in dgLuong.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            BUS_QuanLyLuong luong = new BUS_QuanLyLuong();
            DataTable dtMaNV = luong.LayDanhSachMaNV();
            if (dtMaNV.Rows.Count > 0)
            {
                cboMaNV.DataSource = dtMaNV;
                cboMaNV.DisplayMember = "MaNV";
                cboMaNV.ValueMember = "MaNV";
            }
        }
        private void txtDoanhSo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string maNV = this.cboMaNV.Text;
                if (!string.IsNullOrEmpty(maNV))
                {
                    int doanhSo = luong.GetDoanhSoByMaNV(maNV);
                    this.txtDoanhSo.Text = doanhSo.ToString();

                    float luongCB = 0;
                    float.TryParse(this.txtLuongCB.Text, out luongCB);

                    float thuong = CalculateThuong(doanhSo);
                    float thucLinh = luongCB + thuong;

                    this.txtThuong.Text = thuong.ToString();
                    this.txtThucLinh.Text = thucLinh.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính toán: " + ex.Message);
            }

        }

        private void dgLuong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgLuong.Columns[e.ColumnIndex].Name == "LuongCB" ||
                dgLuong.Columns[e.ColumnIndex].Name == "Thuong" ||
                dgLuong.Columns[e.ColumnIndex].Name == "ThucLinh")
            {
                if (e.Value != null)
                {
                    // Định dạng giá trị tiền tệ
                    e.Value = string.Format("{0:N0}", e.Value);
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgNV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgNV.Columns[e.ColumnIndex].Name == "NgaySinh" && e.Value != null)
            {
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }
        }
    }
}
