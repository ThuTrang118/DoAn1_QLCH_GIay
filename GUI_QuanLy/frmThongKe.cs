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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_QuanLy
{
    public partial class frmThongKe : Form
    {
        BUS_ThongKe busThongKe = new BUS_ThongKe();
        private readonly string ThuTrang; // Tên người dùng hiện tại
        private readonly bool QuanTriVien;
        public frmThongKe(string username, bool isAdmin)
        {
            InitializeComponent();
            ThuTrang = username;
            QuanTriVien = isAdmin;
            busThongKe = new BUS_ThongKe();
            CheckAccessPermission();
        }
        private void CheckAccessPermission()
        {
            if (!QuanTriVien)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        BUS_QuanLyHoaDonNhap hdn = new BUS_QuanLyHoaDonNhap();
        BUS_QuanLyHoaDonBan hdb = new BUS_QuanLyHoaDonBan();

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtSP = busThongKe.ThongKeSanPhamBanChay(tuNgay, denNgay);
            dgSP.DataSource = dtSP;

            DataTable dtNV = busThongKe.ThongKeNhanVienBanHang(tuNgay, denNgay);
            dgNV.DataSource = dtNV;

            DataTable dtTonKho = busThongKe.ThongKeSanPhamTonKho(tuNgay, denNgay);
            dgTonKho.DataSource = dtTonKho;

            // Tính tổng số lượng tồn
            int tongSoLuongTon = dtTonKho.AsEnumerable().Sum(row => Convert.ToInt32(row["SoLuongTon"]));
            lblTongSoLuongTon.Text = "Tổng sản phẩm tồn: " + tongSoLuongTon.ToString();

            // Tính tổng tiền tồn
            double tongTienTonTatCaSanPham = dtTonKho.AsEnumerable().Sum(row => Convert.ToDouble(row["TongTienTon"]));
            lblTongTienTon.Text = "Tổng tiền tồn: " + tongTienTonTatCaSanPham.ToString("N0");

            DataTable dtHD = busThongKe.ThongKeHoaDon(tuNgay, denNgay);
            dgHD.DataSource = dtHD;

            // Tính tổng chi phí và lợi nhuận
            DataTable dtChiPhiVaLoiNhuan = busThongKe.ThongKeTongChiPhiVaLoiNhuan(tuNgay, denNgay);
            double tongChiPhi = dtChiPhiVaLoiNhuan.AsEnumerable().Sum(row => Convert.ToDouble(row["TongChiPhi"]));
            double tongDoanhThu = dtChiPhiVaLoiNhuan.AsEnumerable().Sum(row => Convert.ToDouble(row["TongTienBan"]));
            double loiNhuan = tongDoanhThu - tongChiPhi;

            // Hiển thị kết quả trên label
            lblDoanhThu.Text = "Doanh thu: " + tongDoanhThu.ToString("N0");
            lblLoiNhuan.Text = "Lợi nhuận: " + loiNhuan.ToString("N0");
            if (dtSP.Rows.Count == 0 && dtNV.Rows.Count == 0 && dtTonKho.Rows.Count == 0 && dtHD.Rows.Count == 0 && dtChiPhiVaLoiNhuan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để thống kê trong khoảng thời gian đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private float CalculateTotalTienTon(DataTable dt)
        {
            float totalTienTon = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalTienTon += Convert.ToSingle(row["TongTienTon"]);
            }
            return totalTienTon;
        }

        private void dgTonKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgTonKho.Columns[e.ColumnIndex].Name == "TongTienTon" && e.Value != null)
            {
                double tongTien = Convert.ToDouble(e.Value);
                e.Value = tongTien.ToString("N0");
                e.FormattingApplied = true;
            }
        }


        private void frmThongKe_Load(object sender, EventArgs e)
        {
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dgTonKho.CellFormatting += dgTonKho_CellFormatting;
            dgHD.CellFormatting += dgHD_CellFormatting;
            dgHD.CellFormatting += dgHD_CellFormattingDate;
        }

        private void dgHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgHD.Columns[e.ColumnIndex].Name == "TongTien")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    double tongTien = Convert.ToDouble(e.Value);
                    e.Value = tongTien.ToString("N0");
                    e.FormattingApplied = true;
                }
                if (dgHD.Columns[e.ColumnIndex].Name == "NgayHD" && e.Value != null)
                {
                    DateTime dateValue = Convert.ToDateTime(e.Value);
                    e.Value = dateValue.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = "0";
                    e.FormattingApplied = true;
                }
            }
        }
        private void dgHD_CellFormattingDate(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgHD.Columns[e.ColumnIndex].Name == "NgayHD" && e.Value != null)
            {
                DateTime dateValue = Convert.ToDateTime(e.Value);
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }
        }

    }
}
