using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BUS_QuanLy;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static GUI_QuanLy.frmLenHoaDonNhap;
using System.Globalization;

namespace GUI_QuanLy
{

    public partial class frmLenHoaDonBan : Form
    {
        private string maHDB;
        private List<frmLenHoaDonBan.Product> products = new List<Product>();
        private bool isInvoiceCreated = false;
        public class Product
        {
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public float GiaBan { get; set; }
            public int SoLuong { get; set; }
            public float ThanhTien { get; set; }

        }
        public frmLenHoaDonBan(string maHDB = null)
        {
            InitializeComponent();
            this.maHDB = maHDB;
            if (!string.IsNullOrEmpty(maHDB))
            {
                LoadHoaDonBan(maHDB);
            }
        }
        BUS_QuanLyHoaDonBan hdb = new BUS_QuanLyHoaDonBan();
        public event EventHandler HoaDonBanAdded;
        private void LoadHoaDonBan(string maHDB)
        {
            DataTable dt = hdb.ShowHoaDonBan();
            DataRow[] rows = dt.Select("MaHDB = '" + maHDB + "'");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                txtMaHDB.Text = row["MaHDB"].ToString();
                cboMaNV.Text = row["MaNV"].ToString();
                cboTenNV.Text = row["TenNV"].ToString();
                cboMaKH.Text = row["MaNCC"].ToString();
                txtTenKH.Text = row["TenNCC"].ToString();
                txtGioiTinh.Text = row["GioiTinh"].ToString();
                txtDiaChi.Text = row["DiaChi"].ToString();
                txtSDT.Text = row["SDT"].ToString();
                txtEmail.Text = row["Email"].ToString();
                cboMaSP.Text = row["MaSP"].ToString();
                txtTenSP.Text = row["TenSP"].ToString();
                txtSoLuong.Text = row["SoLuong"].ToString();
                txtGiaBan.Text = row["GiaBan"].ToString();
                dtNgayMua.Text = DateTime.Parse(row["NgayMua"].ToString()).ToString("dd/MM/yyyy");
                txtThanhTien.Text = row["TongThanhTien"].ToString();
                txtKhachTra.Text = row["KhachTra"].ToString();
                txtTienThua.Text = row["TienThua"].ToString() ;
            }
        }

        private void btnLenDon_Click(object sender, EventArgs e)
        {
            string MaHDB = this.txtMaHDB.Text.Trim();
            string TenNV = this.cboTenNV.Text.Trim();
            string TenKH = this.txtTenKH.Text.Trim();
            string TenSP = this.txtTenSP.Text.Trim();
            string SoLuong = this.txtSoLuong.Text.Trim();   
            string KhachTra = this.txtKhachTra.Text.Trim();
            BUS_QuanLyHoaDonBan busQuanLyHoaDonBan = new BUS_QuanLyHoaDonBan();
            if (string.IsNullOrEmpty(MaHDB))
            {
                lbTBHD.Text = "Mã hóa đơn không được để trống!";
            }
            else
            {
                if (hdb.KiemTraMaHoaDonBanTonTai(MaHDB))
                {
                    lbTBHD.Text = "Mã hóa đơn bán đã tồn tại. Vui lòng nhập mã khác!";
                    return;
                }
                else if (string.IsNullOrEmpty(TenNV))
                {
                    lbTBHD.Text = "Không được để trống thông tin nhân viên bán hàng!";
                }
                else if (string.IsNullOrEmpty(TenKH))
                {
                    lbTBHD.Text = "Không được để trống thông tin khách hàng!";
                }
                else if (string.IsNullOrEmpty(TenSP))
                {
                    lbTBHD.Text = "Không được để trống thông tin sản phẩm!";
                }
                else if (string.IsNullOrEmpty(SoLuong))
                {
                    lbTBHD.Text = "Chưa nhập số lượng sản phẩm!";
                }
                else if (lwSP.Items.Count == 0)
                {
                    lbTBHD.Text = "Vui lòng thêm sản phẩm vào danh sách!";
                    return;
                }
                else if (string.IsNullOrEmpty(KhachTra))
                {
                    lbTBHD.Text = "Chưa nhập số tiền khách trả!";
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn thêm khách hàng có mã " + this.txtMaHDB.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DateTime ngayMua = DateTime.ParseExact(dtNgayMua.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        hdb.InsertHoaDonBan(MaHDB, this.cboMaNV.Text, this.cboTenNV.Text, this.cboMaKH.Text, this.txtTenKH.Text, this.txtGioiTinh.Text, this.txtDiaChi.Text, this.txtSDT.Text, this.txtEmail.Text, ngayMua, float.Parse(this.txtThanhTien.Text), float.Parse(this.txtKhachTra.Text), float.Parse(this.txtTienThua.Text));
                        // Insert ChiTietHoaDonNhap
                        foreach (Product product in products)
                        {
                            string MaCTHDB = GenerateMaCTHDB();
                            hdb.InsertChiTietHoaDonBan(MaCTHDB, MaHDB, product.MaSP, product.TenSP, product.SoLuong, product.GiaBan);
                        }

                        MessageBox.Show("Hóa đơn bán đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnHoaDonBanAdded(EventArgs.Empty);
                        isInvoiceCreated = true;
                    }
                }
            }
        }
        protected virtual void OnHoaDonBanAdded(EventArgs e)
        {
            if(HoaDonBanAdded != null)
            {
                HoaDonBanAdded(this, e);
            }
        }

        private void frmLenHoaDonBan_Load(object sender, EventArgs e)
        {
            BUS_QuanLyHoaDonBan laydanhsach = new BUS_QuanLyHoaDonBan();
            DataTable NV = laydanhsach.LayDanhSachMaNV();
            if (NV.Rows.Count > 0)
            {
                cboMaNV.DataSource = NV;
                cboMaNV.DisplayMember = "MaNV";
                cboMaNV.ValueMember = "MaNV";

            }
            DataTable kh = laydanhsach.LayDanhSachMaKH();
            if (kh.Rows.Count > 0)
            {
                cboMaKH.DataSource = kh;
                cboMaKH.DisplayMember = "MaKH";
                cboMaKH.ValueMember = "MaKH";
            }
            DataTable sp = laydanhsach.LayDanhSachMaSP();
            if (sp.Rows.Count > 0)
            {
                cboMaSP.DataSource = sp;
                cboMaSP.DisplayMember = "MaSP";
                cboMaSP.ValueMember = "MaSP";
            }
            dtNgayMua.Format = DateTimePickerFormat.Custom;
            dtNgayMua.CustomFormat = "dd/MM/yyyy";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang kh = new frmQuanLyKhachHang();
            kh.Show();
        }

        private void btnLenSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()) || txtSoLuong.Text.Trim() == "0")
            {
                lbTBHD.Text = "Vui lòng nhập số lượng!";
                return;
            }
            string maSP = cboMaSP.Text;
            string tenSP = txtTenSP.Text;
            int soLuongBan = int.Parse(txtSoLuong.Text);
            float giaBan = float.Parse(txtGiaBan.Text);

            products.Add(new Product
            {
                MaSP = maSP,
                TenSP = tenSP,
                SoLuong = soLuongBan,
                GiaBan = giaBan
            });
            ListViewItem item = new ListViewItem(maSP);
            item.SubItems.Add(tenSP);
            item.SubItems.Add(soLuongBan.ToString());
            item.SubItems.Add(giaBan.ToString("N0"));
            item.SubItems.Add(DateTime.Now.ToString("dd/MM/yyyy"));
            lwSP.Items.Add(item);

            float thanhTien = float.Parse(txtThanhTien.Text);
            thanhTien += (soLuongBan * giaBan);
            txtThanhTien.Text = thanhTien.ToString();

            // Kiểm tra số lượng tồn kho của sản phẩm vừa chọn
            DataTable dt = hdb.TimKiemSanPham(maSP);
            if (dt != null && dt.Rows.Count > 0)
            {
                int soLuongTonKho = int.Parse(dt.Rows[0]["SL"].ToString());
                if (soLuongTonKho < soLuongBan)
                {
                    MessageBox.Show("Sản phẩm " + tenSP + " chỉ còn " + soLuongTonKho + " sản phẩm trong kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            // Cập nhật số lượng đã bán của sản phẩm và giảm số lượng tồn kho
            hdb.UpdateSanPham(maSP, soLuongBan, soLuongBan);


            UpdateListViewWithProductInformation();
            float total = products.Sum(p => p.SoLuong * p.GiaBan);
            txtThanhTien.Text = total.ToString();
        }
        private void UpdateListViewWithProductInformation()
        {
            // Xóa toàn bộ các item cũ trên ListView
            lwSP.Items.Clear();

            // Duyệt qua danh sách sản phẩm và cập nhật lại ListView
            foreach (Product product in products)
            {
                ListViewItem item = new ListViewItem(product.MaSP);
                item.SubItems.Add(product.TenSP);
                item.SubItems.Add(product.SoLuong.ToString());
                item.SubItems.Add(product.GiaBan.ToString("N0")); 
                lwSP.Items.Add(item);
            }
        }
        private string GenerateMaCTHDB()
        {
            int count = hdb.GetChiTietHoaDonBanCount() + 1;
            return "CTHDB" + count.ToString();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtMaHDB.Clear();
            this.cboMaNV.Text = " ";
            this.cboTenNV.Text = "";
            this.cboMaKH.Text = "";
            this.txtTenKH.Clear();
            this.txtGioiTinh.Clear();
            this.txtDiaChi.Clear();
            this.txtSDT.Clear();
            this.txtEmail.Clear();
            this.cboMaSP.Text = "";
            this.txtTenSP.Clear();
            this.txtSoLuong.Clear();
            this.txtGiaBan.Clear();
            this.txtThanhTien.Clear();
            this.txtKhachTra.Clear();
            this.txtTienThua.Clear();
            lwSP.Items.Clear();
            products.Clear();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (!isInvoiceCreated)
            {
                MessageBox.Show("Vui lòng lên hóa đơn trước khi in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string MaHDN = txtMaHDB.Text;
            string NgayMua = dtNgayMua.Text;
            string TenNV = cboTenNV.Text;
            string TenKH = txtTenKH.Text;
            string SDT = txtSDT.Text;
            string DiaChi = txtDiaChi.Text;
            float khachTra = float.Parse(txtKhachTra.Text);
            float tienThua = float.Parse(txtTienThua.Text);

            // Truyền danh sách sản phẩm và các thông tin khác vào form in
            frmInHoaDonBan frmInHoaDonBan = new frmInHoaDonBan(MaHDN, NgayMua, TenNV, TenKH, SDT, DiaChi, products, khachTra, tienThua);
            frmInHoaDonBan.Show();
            this.Hide();
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maKH = cboMaKH.SelectedValue.ToString();
            DataTable nccInfo = hdb.TimKiemKhachHang(maKH);
            if (nccInfo != null && nccInfo.Rows.Count > 0)
            {
                string tenKH = nccInfo.Rows[0]["TenKH"].ToString();
                string gioiTinh = nccInfo.Rows[0]["GioiTinh"].ToString();
                string diaChi = nccInfo.Rows[0]["DiaChi"].ToString();
                string sdt = nccInfo.Rows[0]["SDT"].ToString();
                string email = nccInfo.Rows[0]["Email"].ToString();
                txtTenKH.Text = tenKH;
                txtGioiTinh.Text = gioiTinh;
                txtDiaChi.Text = diaChi;
                txtSDT.Text = sdt;
                txtEmail.Text = email;
            }
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maSP = cboMaSP.SelectedValue.ToString();
            DataTable spInfo = hdb.TimKiemSanPham(maSP);
            if (spInfo != null && spInfo.Rows.Count > 0)
            {
                string tenSP = spInfo.Rows[0]["TenSP"].ToString();
                string giaBan = spInfo.Rows[0]["GiaBan"].ToString();
                txtTenSP.Text = tenSP;
                txtGiaBan.Text = giaBan;

                // Kiểm tra số lượng tồn kho của sản phẩm và số lượng bán
                int soLuongTonKho;
                int soLuongBan;
                if (int.TryParse(spInfo.Rows[0]["SL"].ToString(), out soLuongTonKho))
                {
                    if (soLuongTonKho == 0)
                    {
                        MessageBox.Show("Sản phẩm này đã hết hàng trong kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Xóa các thông tin về sản phẩm và không cho phép chọn sản phẩm
                        txtTenSP.Text = string.Empty;
                        txtGiaBan.Text = string.Empty;
                        txtSoLuong.Text = string.Empty;
                        return; // Kết thúc sớm để không tiếp tục xử lý
                    }
                    else if (int.TryParse(txtSoLuong.Text, out soLuongBan))
                    {
                        if (soLuongTonKho < soLuongBan)
                        {
                            MessageBox.Show("Sản phẩm này chỉ còn " + soLuongTonKho + " sản phẩm trong kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    // Xử lý trường hợp không thể chuyển đổi chuỗi thành số
                    MessageBox.Show("Dữ liệu số lượng tồn kho không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNV = cboMaNV.SelectedValue.ToString();
            DataTable nvInfo = hdb.TimKiemNhanVien(maNV);
            if (nvInfo != null && nvInfo.Rows.Count > 0)
            {
                string TenNV = nvInfo.Rows[0]["TenNV"].ToString();
                cboTenNV.Text = TenNV;
            }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenKH.Text.Trim();

            // Gọi phương thức tìm kiếm khách hàng từ CSDL
            DataTable dt = hdb.TimKiemKhachHang(input);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Có thông tin khách hàng khớp, hiển thị gợi ý và điền tự động
                string tenkh = dt.Rows[0]["TenKH"].ToString();
                string gioitinh = dt.Rows[0]["GioiTinh"].ToString();
                string diachi = dt.Rows[0]["DiaChi"].ToString();
                string sdt = dt.Rows[0]["SDT"].ToString();
                string email = dt.Rows[0]["Email"].ToString();

                txtTenKH.Text = tenkh;
                txtGioiTinh.Text = gioitinh;
                txtDiaChi.Text = diachi;
                txtSDT.Text = sdt;
                txtEmail.Text = email;
            }
            else
            {
                // Không có thông tin khách hàng khớp, reset các TextBox thông tin còn lại

                txtTenKH.Text = "";
                txtGioiTinh.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtEmail.Text = "";
            }
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenSP.Text.Trim();

            // Gọi phương thức tìm kiếm khách hàng từ CSDL
            DataTable dt = hdb.TimKiemSanPham(input);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Có thông tin khách hàng khớp, hiển thị gợi ý và điền tự động
                string tensp = dt.Rows[0]["TenSP"].ToString();
                string giaban = dt.Rows[0]["GiaBan"].ToString();

                txtTenSP.Text = tensp;
                txtGiaBan.Text = giaban;
            }
            else
            {
                // Không có thông tin khách hàng khớp, reset các TextBox thông tin còn lại
                txtTenSP.Text = "";
                txtGiaBan.Text = "";
            }
        }

        private void txtKhachTra_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(txtKhachTra.Text, out float khachTra))
            {
                // Tính toán giá trị của txtTienThua
                if (float.TryParse(txtThanhTien.Text, out float thanhTien))
                {
                    float tienThua = khachTra - thanhTien; // Tính tiền thừa
                    txtTienThua.Text = tienThua.ToString("N0");
                }
            }
            txtKhachTra.Text = khachTra.ToString("N0");
            txtKhachTra.SelectionStart = txtKhachTra.Text.Length;
        }

        private void lwSP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListViewItem item = lwSP.GetItemAt(e.X, e.Y);

                if (item != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string maSP = item.Text;
                        lwSP.Items.Remove(item);
                        RemoveProductByMaSP(maSP);
                        UpdateTotal();
                    }
                }
            }
        }
        private void UpdateTotal()
        {
            float total = products.Sum(p => p.ThanhTien);
            txtThanhTien.Text = total.ToString();
        }
        private void RemoveProductByMaSP(string maSP)
        {
            var productToRemove = products.FirstOrDefault(p => p.MaSP == maSP);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(txtThanhTien.Text, out float value))
            {
                txtThanhTien.Text = value.ToString("N0");
                txtThanhTien.SelectionStart = txtThanhTien.Text.Length;
            }
        }
    }
}
