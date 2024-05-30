using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI_QuanLy
{
    public partial class frmInHoaDonBan : Form
    {
        private string maHoaDon;
        private string ngayMua;
        private string tenNhanVien;
        private string tenKhachHang;
        private string sdtKhachHang;
        private string diachiKhachHang;
        private float khachTra;
        private float tienThua;
        private List<frmLenHoaDonBan.Product> products;

        public frmInHoaDonBan(string maHDN, string ngayMua, string tenNV, string tenKH, string sdt, string diaChi, List<frmLenHoaDonBan.Product> products, float khachTra, float tienThua)
        {
            InitializeComponent();
            this.maHoaDon = maHDN;
            this.ngayMua = ngayMua;
            this.tenNhanVien = tenNV;
            this.tenKhachHang = tenKH;
            this.sdtKhachHang = sdt;
            this.diachiKhachHang = diaChi;
            this.products = products;
            this.khachTra = khachTra;
            this.tienThua = tienThua;
            foreach (var product in this.products)
            {
                product.ThanhTien = product.SoLuong * product.GiaBan;
            }
        }

        private void frmInHoaDonBan_Load(object sender, EventArgs e)
        {
            // Tạo label Cửa hàng
            Label lblStoreName = new Label();
            lblStoreName.Text = "Cửa hàng giày cao gót Thu Trang";
            lblStoreName.Font = new Font(lblStoreName.Font.FontFamily, 10, FontStyle.Bold);
            lblStoreName.AutoSize = true;
            this.Controls.Add(lblStoreName);
            lblStoreName.Location = new Point(50, 30);

            Label lblDiaChi = new Label();
            lblDiaChi.Text = "Địa chỉ: Đôị 5, thôn Đào Đặng, xã Trung Nghĩa, TP Hưng Yên, tỉnh Hưng Yên ";
            lblDiaChi.Font = new Font(lblDiaChi.Font.FontFamily, 8);
            lblDiaChi.AutoSize = true;
            this.Controls.Add(lblDiaChi);
            lblDiaChi.Location = new Point(50, lblStoreName.Bottom + 5);

            Label lblSDTTT = new Label();
            lblSDTTT.Text = "SDT: 035.969.5488 - 036.924.5488";
            lblSDTTT.Font = new Font(lblSDTTT.Font.FontFamily, 8);
            lblSDTTT.AutoSize = true;
            this.Controls.Add(lblSDTTT);
            lblSDTTT.Location = new Point(50, lblDiaChi.Bottom + 5);

            Label lblHeader = new Label();
            lblHeader.Text = "HÓA ĐƠN BÁN HÀNG";
            lblHeader.Font = new Font(lblHeader.Font.FontFamily, 20, FontStyle.Bold);
            lblHeader.AutoSize = true;
            this.Controls.Add(lblHeader);
            lblHeader.Location = new Point((this.ClientSize.Width - lblHeader.Width) / 2, lblSDTTT.Bottom + 20);

            Label lblMaHoaDon = new Label();
            lblMaHoaDon.Text = "Mã hóa đơn: " + maHoaDon;
            lblMaHoaDon.AutoSize = true;
            this.Controls.Add(lblMaHoaDon);
            lblMaHoaDon.Location = new Point(50, lblHeader.Bottom + 5);

            Label lblNgayMua = new Label();
            lblNgayMua.Text = "Ngày mua: " + ngayMua;
            lblNgayMua.AutoSize = true;
            this.Controls.Add(lblNgayMua);
            lblNgayMua.Location = new Point(lblMaHoaDon.Right + 390, lblMaHoaDon.Top);

            Label lblNhanVien = new Label();
            lblNhanVien.Text = "Tên nhân viên: " + tenNhanVien;
            lblNhanVien.AutoSize = true;
            this.Controls.Add(lblNhanVien);
            lblNhanVien.Location = new Point(50, lblMaHoaDon.Bottom + 5);

            Label lblKH = new Label();
            lblKH.Text = "Tên khách hàng: " + tenKhachHang;
            lblKH.AutoSize = true;
            this.Controls.Add(lblKH);
            lblKH.Location = new Point(50, lblNhanVien.Bottom + 5);

            Label lblSDT = new Label();
            lblSDT.Text = "SĐT: " + sdtKhachHang;
            lblSDT.AutoSize = true;
            this.Controls.Add(lblSDT);
            lblSDT.Location = new Point(50, lblKH.Bottom + 5);

            Label lblDiaChiKH = new Label();
            lblDiaChiKH.Text = "Email: " + diachiKhachHang;
            lblDiaChiKH.AutoSize = true;
            this.Controls.Add(lblDiaChiKH);
            lblDiaChiKH.Location = new Point(50, lblSDT.Bottom + 5);

            DataGridView dgvProducts = new DataGridView();
            dgvProducts.Location = new Point(50, 250);
            dgvProducts.Size = new Size(600, 200);
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font(dgvProducts.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Create columns for DataGridView
            DataGridViewTextBoxColumn colMaSP = new DataGridViewTextBoxColumn();
            colMaSP.HeaderText = "Mã sản phẩm";
            colMaSP.DataPropertyName = "MaSP";
            dgvProducts.Columns.Add(colMaSP);

            DataGridViewTextBoxColumn colTenSP = new DataGridViewTextBoxColumn();
            colTenSP.HeaderText = "Tên sản phẩm";
            colTenSP.DataPropertyName = "TenSP";
            dgvProducts.Columns.Add(colTenSP);

            DataGridViewTextBoxColumn colGiaBan = new DataGridViewTextBoxColumn();
            colGiaBan.HeaderText = "Giá bán";
            colGiaBan.DataPropertyName = "GiaBan";
            colGiaBan.DefaultCellStyle.Format = "N0";
            dgvProducts.Columns.Add(colGiaBan);

            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.DataPropertyName = "SoLuong";
            dgvProducts.Columns.Add(colSoLuong);

            DataGridViewTextBoxColumn colThanhTien = new DataGridViewTextBoxColumn();
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.DataPropertyName = "ThanhTien";
            colThanhTien.DefaultCellStyle.Format = "N0";
            dgvProducts.Columns.Add(colThanhTien);

            dgvProducts.DataSource = products;
            this.Controls.Add(dgvProducts);

            float total = products.Sum(p => p.ThanhTien);
            Label lblTotal = new Label();
            lblTotal.Text = "Tổng tiền: " + total.ToString("N0");
            lblTotal.AutoSize = true;
            this.Controls.Add(lblTotal);
            lblTotal.Location = new Point(500, dgvProducts.Bottom + 5);

            // Text below total
            Label lblKhachTra = new Label();
            lblKhachTra.Text = "Khách trả: " + khachTra.ToString("N0");
            lblKhachTra.AutoSize = true;
            this.Controls.Add(lblKhachTra);
            lblKhachTra.Location = new Point(500, lblTotal.Bottom + 5);

            Label lblTienThua = new Label();
            lblTienThua.Text = "Tiền thừa: " + tienThua.ToString("N0");
            lblTienThua.AutoSize = true;
            this.Controls.Add(lblTienThua);
            lblTienThua.Location = new Point(500, lblKhachTra.Bottom + 5);

            Label lblThankYou = new Label();
            lblThankYou.Text = "Cảm ơn quý khách đã mua hàng. Rất hân hạnh được phục vụ quý khách!!!";
            lblThankYou.Font = new Font(lblThankYou.Font, FontStyle.Italic);
            lblThankYou.AutoSize = true;
            this.Controls.Add(lblThankYou);
            lblThankYou.Location = new Point((this.ClientSize.Width - lblThankYou.Width) / 2, lblTienThua.Bottom + 20);
        }

        private int CenterHorizontally(int elementWidth)
        {
            return (this.ClientSize.Width - elementWidth) / 2;
        }

        private void DrawBillTable()
        {
            int numProducts = products.Count;
            int numCols = 5;
            int columnWidth = 120;

            int numRows = numProducts + 1;



            int startX = (this.ClientSize.Width - (columnWidth * numCols)) / 2;
            int startY = 380;
            int rowHeight = 30;
            int tableWidth = columnWidth * numCols;
            int tableHeight = rowHeight * numRows;

            string[] columnNames = { "Mã sản phẩm", "Tên sản phẩm", "Giá Bán", "Số lượng", "Thành tiền" };
            for (int i = 0; i < numCols; i++)
            {
                Label headerLabel = new Label();
                headerLabel.Text = columnNames[i];
                headerLabel.Font = new Font(headerLabel.Font, FontStyle.Bold);
                headerLabel.TextAlign = ContentAlignment.MiddleCenter;
                headerLabel.Size = new Size(columnWidth, rowHeight);
                headerLabel.Location = new Point(startX + i * columnWidth, startY);
                this.Controls.Add(headerLabel);
            }


            for (int i = 0; i < numProducts; i++)
            {
                var product = products[i];

                Label lblMaSP = new Label();
                lblMaSP.Text = product.MaSP;
                lblMaSP.TextAlign = ContentAlignment.MiddleCenter;
                lblMaSP.Size = new Size(columnWidth, rowHeight);
                lblMaSP.Location = new Point(startX, startY + (i + 1) * rowHeight);
                this.Controls.Add(lblMaSP);

                Label lblTenSP = new Label();
                lblTenSP.Text = product.TenSP;
                lblTenSP.TextAlign = ContentAlignment.MiddleCenter;
                lblTenSP.Size = new Size(columnWidth, rowHeight);
                lblTenSP.Location = new Point(startX + columnWidth, startY + (i + 1) * rowHeight);
                this.Controls.Add(lblTenSP);

                Label lblGiaBan = new Label();
                lblGiaBan.Text = product.GiaBan.ToString("N0");
                lblGiaBan.TextAlign = ContentAlignment.MiddleCenter;
                lblGiaBan.Size = new Size(columnWidth, rowHeight);
                lblGiaBan.Location = new Point(startX + 2 * columnWidth, startY + (i + 1) * rowHeight);
                this.Controls.Add(lblGiaBan);

                Label lblSoLuong = new Label();
                lblSoLuong.Text = product.SoLuong.ToString();
                lblSoLuong.TextAlign = ContentAlignment.MiddleCenter;
                lblSoLuong.Size = new Size(columnWidth, rowHeight);
                lblSoLuong.Location = new Point(startX + 3 * columnWidth, startY + (i + 1) * rowHeight);
                this.Controls.Add(lblSoLuong);

                Label lblThanhTien = new Label();
                lblThanhTien.Text = product.ThanhTien.ToString("N0");
                lblThanhTien.TextAlign = ContentAlignment.MiddleCenter;
                lblThanhTien.Size = new Size(columnWidth, rowHeight);
                lblThanhTien.Location = new Point(startX + 4 * columnWidth, startY + (i + 1) * rowHeight);
                this.Controls.Add(lblThanhTien);
            }
        }
    }
    
    
}
