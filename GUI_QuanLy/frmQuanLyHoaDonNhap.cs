using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;

namespace GUI_QuanLy
{
    public partial class frmQuanLyHoaDonNhap : Form
    {
        public frmQuanLyHoaDonNhap()
        {
            InitializeComponent();
            frmLenHoaDonNhap lendonnhap = new frmLenHoaDonNhap();
            lendonnhap.HoaDonNhapAdded += FrmLenHoaDonNhap_HoaDonNhapAdded;
            dgHD.CellClick += dgHD_CellClick;
            dgHD.CellFormatting += dgHD_CellFormatting;
            dgCTHD.CellFormatting += dgHD_CellFormatting;
        }
        BUS_QuanLyHoaDonNhap hdn = new BUS_QuanLyHoaDonNhap();
        private void FrmLenHoaDonNhap_HoaDonNhapAdded(object sender, EventArgs e)
        {
            LoadDanhSachHoaDonNhap();
        }

        private void btnThemHDN_Click(object sender, EventArgs e)
        {
            frmLenHoaDonNhap lendonnhap = new frmLenHoaDonNhap();
            lendonnhap.Show();
        }

        private void frmQuanLyHoaDonNhap_Load(object sender, EventArgs e)
        {
            LoadDanhSachHoaDonNhap();
        }
        private void LoadDanhSachHoaDonNhap()
        {
            DataTable dt = hdn.ShowHoaDonNhap();
            dgHD.DataSource = dt;
            foreach (DataGridViewColumn column in dgHD.Columns)
            {
                dgHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            dgHD.Refresh();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                DataTable dt = hdn.LookHoaDonNhap(keyword);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgHD.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin hóa đơn nhập!");
                    dgHD.DataSource = null;
                }
            }
            else
            {
                LoadDanhSachHoaDonNhap();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                DataTable dt = new DataTable();
                dt = hdn.LookHoaDonNhap(searchText);
                dgHD.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin hóa đơn");
                }
                
            }
            else
            {
                frmQuanLyHoaDonNhap_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgHD.SelectedRows.Count > 0)
            {
                string maHDN = dgHD.SelectedRows[0].Cells["MaHDN"].Value.ToString();
                BUS_QuanLyHoaDonNhap bus = new BUS_QuanLyHoaDonNhap();
                bus.DeleteChiTietHoaDonNhap(maHDN);
                bus.DeleteHoaDonNhap(maHDN);
                MessageBox.Show("Đã xóa hóa đơn nhập và chi tiết hóa đơn nhập tương ứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgHD.DataSource = bus.ShowHoaDonNhap();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maHDN = dgHD.Rows[e.RowIndex].Cells["MaHDN"].Value.ToString();
                DataTable dtCTHD = hdn.GetChiTietHoaDonNhap(maHDN);
                if (dtCTHD != null && dtCTHD.Rows.Count > 0)
                {
                    dgCTHD.DataSource = dtCTHD;
                }
                else
                {
                    dgCTHD.DataSource = null;
                    MessageBox.Show("Không có chi tiết hóa đơn cho hóa đơn này.");
                }
            }
        }

        private void dgHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgHD.Columns[e.ColumnIndex].Name == "ThanhTien")
            {
                if (e.Value != null)
                {
                    // Định dạng giá trị thành chuỗi định dạng số có dấu phẩy
                    try
                    {
                        e.Value = string.Format("{0:N0}", e.Value);
                        e.FormattingApplied = true;
                    }
                    catch (FormatException)
                    {
                        e.FormattingApplied = false;
                    }
                }
            }
            else if (dgHD.Columns[e.ColumnIndex].Name == "NgayMua")
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    // Định dạng giá trị ngày thành chuỗi định dạng dd/MM/yyyy
                    try
                    {
                        e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                        e.FormattingApplied = true;
                    }
                    catch (FormatException)
                    {
                        e.FormattingApplied = false;
                    }
                }
            }
        }

        private void dgCTHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgCTHD.Columns[e.ColumnIndex].Name == "ThanhTien" || dgCTHD.Columns[e.ColumnIndex].Name == "GiaNhap")
            {
                if (e.Value != null)
                {
                    // Định dạng giá trị thành chuỗi định dạng số có dấu phẩy
                    try
                    {
                        e.Value = string.Format("{0:N0}", e.Value);
                        e.FormattingApplied = true;
                    }
                    catch (FormatException)
                    {
                        e.FormattingApplied = false;
                    }
                }
            }
            else if (dgCTHD.Columns[e.ColumnIndex].Name == "NgayMua")
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    // Định dạng giá trị ngày thành chuỗi định dạng dd/MM/yyyy
                    try
                    {
                        e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                        e.FormattingApplied = true;
                    }
                    catch (FormatException)
                    {
                        e.FormattingApplied = false;
                    }
                }
            }
        }
    }
}
