using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS_QuanLy;
using System.Windows.Forms;
using Microsoft.Office.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace GUI_QuanLy
{
    public partial class frmLenHoaDonNhap : Form
    {
        private string maHDN;
        private List<Product> products = new List<Product>();
        private bool isInvoiceCreated = false;
        public class Product
        {
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public int SoLuong { get; set; }
            public float GiaNhap { get; set; }
            public float ThanhTien => SoLuong * GiaNhap;
            public string MaNCC { get; set; }
        }
        public frmLenHoaDonNhap(string maHDN = null)
        {
            InitializeComponent();
            this.maHDN = maHDN;
            if (!string.IsNullOrEmpty(maHDN))
            {
                LoadHoaDonNhap(maHDN);
            }
        }

        BUS_QuanLyHoaDonNhap hdn = new BUS_QuanLyHoaDonNhap();
        public event EventHandler HoaDonNhapAdded;
        private void LoadHoaDonNhap(string maHDN)
        {
            DataTable dt = hdn.ShowHoaDonNhap();
            DataRow[] rows = dt.Select("MaHDN = '" + maHDN + "'");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                txtMaHDN.Text = row["MaHDN"].ToString();
                cboMaNV.Text = row["MaNV"].ToString();
                cboTenNV.Text = row["TenNV"].ToString();
                cboMaNCC.Text = row["MaNCC"].ToString();
                txtTenNCC.Text = row["TenNCC"].ToString();
                txtGioiTinh.Text = row["GioiTinh"].ToString();
                txtDiaChi.Text = row["DiaChi"].ToString();
                txtSDT.Text = row["SDT"].ToString();
                txtEmail.Text = row["Email"].ToString();
                cboMaSP.Text = row["MaSP"].ToString();
                txtTenSP.Text = row["TenSP"].ToString();
                txtSoLuong.Text = row["SoLuong"].ToString();
                txtGiaNhap.Text = row["GiaNhap"].ToString();
                dtNgayMua.Text = DateTime.Parse(row["NgayMua"].ToString()).ToString("dd/MM/yyyy");

                txtThanhTien.Text = row["ThanhTien"].ToString();
            }
        }
        private void btnLenDon_Click(object sender, EventArgs e)
        {
            string MaHDN = this.txtMaHDN.Text.Trim();
            string TenNV = this.cboTenNV.Text.Trim();
            string TenNCC = this.txtTenNCC.Text.Trim();
            string TenSP = this.txtTenSP.Text.Trim();
            string SoLuong = this.txtSoLuong.Text.Trim();
            BUS_QuanLyHoaDonNhap busHoaDonNhap = new BUS_QuanLyHoaDonNhap();
            if (string.IsNullOrEmpty(MaHDN))
            {
                lbTBHD.Text = "Mã hóa đơn không được để trống!";
            }
            else
            {
                if (hdn.KiemTraMaHoaDonNhapTonTai(MaHDN))
                {
                    lbTBHD.Text = "Mã hóa đơn nhập đã tồn tại. Vui lòng nhập mã khác!";
                    return;
                }
                else if (string.IsNullOrEmpty(TenNV))
                {
                    lbTBHD.Text = "Không được để trống thông tin nhân viên bán hàng!";
                }
                else if (string.IsNullOrEmpty(TenNCC))
                {
                    lbTBHD.Text = "Không được để trống thông tin nhà cung cấp!";
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
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn thêm khách hàng có mã " + this.txtMaHDN.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        float tongThanhTien = products.Sum(p => p.ThanhTien);
                        DateTime ngayMua = DateTime.ParseExact(dtNgayMua.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        hdn.InsertHoaDonNhap(MaHDN, cboMaNV.SelectedValue?.ToString(), cboTenNV.Text, cboMaNCC.SelectedValue?.ToString(), txtTenNCC.Text, txtGioiTinh.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, ngayMua, tongThanhTien);
                        foreach (Product product in products)
                        {
                            string MaCTHDN = GenerateMaCTHDN();
                            hdn.InsertChiTietHoaDonNhap(MaCTHDN, MaHDN, product.MaSP, product.TenSP, product.SoLuong, product.GiaNhap, product.ThanhTien);
                        }
                        MessageBox.Show("Hóa đơn nhập đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnHoaDonNhapAdded(EventArgs.Empty);
                        isInvoiceCreated = true;
                    }
                }
            }
        }
                
        protected virtual void OnHoaDonNhapAdded(EventArgs e)
        {
            if (HoaDonNhapAdded != null)
            {
                HoaDonNhapAdded(this, e);
            }
        }
        private void frmLenHoaDonNhap_Load(object sender, EventArgs e)
        {
            BUS_QuanLyHoaDonNhap laydanhsach = new BUS_QuanLyHoaDonNhap();
            DataTable NV = laydanhsach.LayDanhSachMaNV();
            if (NV.Rows.Count > 0)
            {
                cboMaNV.DataSource = NV;
                cboMaNV.DisplayMember = "MaNV";
                cboMaNV.ValueMember = "MaNV";

            }
            DataTable NCC = laydanhsach.LayDanhSachMaNCC();
            if (NCC.Rows.Count > 0)
            {
                cboMaNCC.DataSource = NCC;
                cboMaNCC.DisplayMember = "MaNCC";
                cboMaNCC.ValueMember = "MaNCC";

            }
            DataTable SP = laydanhsach.LayDanhSachMaSP();
            if (SP.Rows.Count > 0)
            {
                cboMaSP.DataSource = SP;
                cboMaSP.DisplayMember = "MaSP";
                cboMaSP.ValueMember = "MaSP";

            }
            dtNgayMua.Format = DateTimePickerFormat.Custom;
            dtNgayMua.CustomFormat = "dd/MM/yyyy";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmQuanLyNhaCungCap ncc = new frmQuanLyNhaCungCap();
            ncc.Show();
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
            int soLuong = int.Parse(txtSoLuong.Text);
            float giaNhap = float.Parse(txtGiaNhap.Text);
            string maNCC = cboMaNCC.SelectedValue?.ToString();
            var existingProduct = products.FirstOrDefault(p => p.MaSP == maSP);
            if (existingProduct != null)
            {
                existingProduct.SoLuong += soLuong;
                existingProduct.GiaNhap = giaNhap;
                existingProduct.MaNCC = maNCC;
            }
            else
            {
                products.Add(new Product
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    SoLuong = soLuong,
                    GiaNhap = giaNhap,
                    MaNCC = maNCC
                });
                ListViewItem item = new ListViewItem(maSP);
                item.SubItems.Add(tenSP);
                item.SubItems.Add(soLuong.ToString());
                item.SubItems.Add(giaNhap.ToString("N0"));
                item.SubItems.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                lwSP.Items.Add(item);
            }
            UpdateTotal();
            hdn.UpdateSanPham(maSP, soLuong);
        }
        private string GenerateMaCTHDN()
        {
            int count = hdn.GetChiTietHoaDonNhapCount() + 1;
            return "CTHDN" + count.ToString();
        }

        private void UpdateListViewWithProductInformation()
        {
            lwSP.Items.Clear();
            string value1 = cboMaSP.Text;
            string value2 = txtTenSP.Text;
            string value3 = txtSoLuong.Text;
            string value4 = txtGiaNhap.Text;
            ListViewItem newItem = new ListViewItem(value1);
            newItem.SubItems.Add(value2);
            newItem.SubItems.Add(value3);
            newItem.SubItems.Add(value4);
            lwSP.Items.Add(newItem);
        }


        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmQuanLySanPham sp = new frmQuanLySanPham();
            sp.Show();
        }

        private void LoadDataForComboBoxes()
        {
            // Tải lại danh sách nhà cung cấp
            DataTable NCC = hdn.LayDanhSachMaNCC();
            if (NCC.Rows.Count > 0)
            {
                cboMaNCC.DataSource = NCC;
                cboMaNCC.DisplayMember = "MaNCC";
                cboMaNCC.ValueMember = "MaNCC";
            }

            // Tải lại danh sách sản phẩm
            DataTable SP = hdn.LayDanhSachMaSP();
            if (SP.Rows.Count > 0)
            {
                cboMaSP.DataSource = SP;
                cboMaSP.DisplayMember = "MaSP";
                cboMaSP.ValueMember = "MaSP";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtMaHDN.Clear();
            this.cboMaNV.Text= "";
            this.cboTenNV.Text = "";
            this.cboMaNCC.Text = "";
            this.txtTenNCC.Clear();
            this.txtGioiTinh.Clear();
            this.txtDiaChi.Clear();
            this.txtSDT.Clear();
            this.txtEmail.Clear();
            this.cboMaSP.Text = "";
            this.txtTenSP.Clear();
            this.txtSoLuong.Clear();
            this.txtGiaNhap.Clear();
            this.txtThanhTien.Clear();
            lwSP.Items.Clear();
            products.Clear();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!isInvoiceCreated)
            {
                MessageBox.Show("Vui lòng lên hóa đơn trước khi in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string MaHDN = txtMaHDN.Text;
            string NgayMua = dtNgayMua.Text;
            string TenNV = cboTenNV.Text;
            string TenNCC = txtTenNCC.Text;
            string SDT = txtSDT.Text;
            string Email = txtEmail.Text;

            // Truyền danh sách sản phẩm vào frmInHoaDon
            frmInHoaDon frmInHoaDon = new frmInHoaDon(MaHDN, NgayMua, TenNV, TenNCC, SDT, Email, products);
            frmInHoaDon.Show();
            this.Hide();
        }
        private void FilterProductsBySupplier(string maNCC)
        {
            DataTable sp = hdn.LayDanhSachSanPhamTheoNhaCungCap(maNCC);
            if (sp.Rows.Count > 0)
            {
                cboMaSP.DataSource = sp;
                cboMaSP.DisplayMember = "MaSP"; // Hiển thị tên sản phẩm
                cboMaSP.ValueMember = "MaSP"; // Giá trị là mã sản phẩm
            }
            else
            {
                cboMaSP.DataSource = null;
            }
        }
        private void cboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNCC.SelectedValue == null)
                return;

            string maNCC = cboMaNCC.SelectedValue.ToString();
            DataTable nccInfo = hdn.TimKiemNhaCungCap(maNCC);
            if (nccInfo != null && nccInfo.Rows.Count > 0)
            {
                string tenNCC = nccInfo.Rows[0]["TenNCC"].ToString();
                string gioiTinh = nccInfo.Rows[0]["GioiTinh"].ToString();
                string diaChi = nccInfo.Rows[0]["DiaChiNCC"].ToString();
                string sdt = nccInfo.Rows[0]["SDTNCC"].ToString();
                string email = nccInfo.Rows[0]["Email"].ToString();

                txtTenNCC.Text = tenNCC;
                txtGioiTinh.Text = gioiTinh;
                txtDiaChi.Text = diaChi;
                txtSDT.Text = sdt;
                txtEmail.Text = email;
                FilterProductsBySupplier(maNCC);
            }

        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSP.SelectedValue == null)
                return;

            string maSP = cboMaSP.SelectedValue.ToString();
            DataTable spInfo = hdn.TimKiemSanPham(maSP);
            if (spInfo != null && spInfo.Rows.Count > 0)
            {
                string tenSP = spInfo.Rows[0]["TenSP"].ToString();
                string giaNhap = spInfo.Rows[0]["GiaNhap"].ToString();
                string maNCC = spInfo.Rows[0]["MaNCC"].ToString(); // Lấy mã nhà cung cấp của sản phẩm

                txtTenSP.Text = tenSP;
                txtGiaNhap.Text = giaNhap;

                // Chọn mã nhà cung cấp tương ứng trong ComboBox
                cboMaNCC.SelectedValue = maNCC;
            }

        }


        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedValue == null)
                return;

            string maNV = cboMaNV.SelectedValue.ToString();
            DataTable nvInfo = hdn.TimKiemNhanVien(maNV);
            if (nvInfo != null && nvInfo.Rows.Count > 0)
            {
                string tenNV = nvInfo.Rows[0]["TenNV"].ToString();
                cboTenNV.Text = tenNV;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenNCC_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenNCC.Text.Trim();
            DataTable dt = hdn.TimKiemNhaCungCap(input);

            if (dt != null && dt.Rows.Count > 0)
            {
                string tenncc = dt.Rows[0]["TenNCC"].ToString();
                string gioitinh = dt.Rows[0]["GioiTinh"].ToString();
                string diachi = dt.Rows[0]["DiaChiNCC"].ToString();
                string sdt = dt.Rows[0]["SDTNCC"].ToString();
                string email = dt.Rows[0]["Email"].ToString();

                txtTenNCC.Text = tenncc;
                txtGioiTinh.Text = gioitinh;
                txtDiaChi.Text = diachi;
                txtSDT.Text = sdt;
                txtEmail.Text = email;
            }
            else
            {
                txtTenNCC.Text = "";
                txtGioiTinh.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtEmail.Text = "";
            }
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenSP.Text.Trim();
            DataTable dt = hdn.TimKiemSanPham(input);

            if (dt != null && dt.Rows.Count > 0)
            {
                string tensp = dt.Rows[0]["TenSP"].ToString();
                string gianhap = dt.Rows[0]["GiaNhap"].ToString();

                txtTenSP.Text = tensp;
                txtGiaNhap.Text = gianhap;
            }
            else
            {
                txtTenSP.Text = "";
                txtGiaNhap.Text = "";
            }
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
