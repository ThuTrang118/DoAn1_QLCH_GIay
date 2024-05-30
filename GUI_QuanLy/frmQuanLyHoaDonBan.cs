using BUS_QuanLy;
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

namespace GUI_QuanLy
{
    public partial class frmQuanLyHoaDonBan : Form
    {
        public frmQuanLyHoaDonBan()
        {
            InitializeComponent();
            frmLenHoaDonBan lendonban = new frmLenHoaDonBan();
            lendonban.HoaDonBanAdded += FrmLenHoaDonBan_HoaDonBanAdded;
            dgHD.CellClick += dgHD_CellClick;
            dgHD.CellFormatting += new DataGridViewCellFormattingEventHandler(dgHD_CellFormatting);
            dgCTHDB.CellFormatting += new DataGridViewCellFormattingEventHandler(dgCTHDB_CellFormatting);
        }
        BUS_QuanLyHoaDonBan hdb = new BUS_QuanLyHoaDonBan();
        private void FrmLenHoaDonBan_HoaDonBanAdded(object sender, EventArgs e)
        {
            // Load lại danh sách hóa đơn nhập từ cơ sở dữ liệu và cập nhật vào DataGridView dgHD
            LoadDanhSachHoaDonBan();
        }
        private void btnThemHDN_Click(object sender, EventArgs e)
        {
            frmLenHoaDonBan lendonban = new frmLenHoaDonBan();
            lendonban.Show();
        }

        private void frmQuanLyHoaDonBan_Load(object sender, EventArgs e)
        {
            LoadDanhSachHoaDonBan();
        }
        private void LoadDanhSachHoaDonBan()
        {
            DataTable dt = hdb.ShowHoaDonBan();
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

            // Kiểm tra xem từ khóa tìm kiếm có rỗng hay không
            if (!string.IsNullOrEmpty(keyword))
            {
                // Gọi phương thức tìm kiếm từ lớp BUS và nhận kết quả trả về
                DataTable dt = hdb.LookHoaDonBan(keyword);

                // Kiểm tra xem có kết quả từ tìm kiếm hay không
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Hiển thị kết quả tìm kiếm trên DataGridView
                    dgHD.DataSource = dt;
                }
                else
                {
                    // Nếu không có kết quả, thông báo cho người dùng
                    MessageBox.Show("Không tìm thấy thông tin hóa đơn nhập!");
                    // Xóa dữ liệu hiển thị trên DataGridView
                    dgHD.DataSource = null;
                }
            }
            else
            {
                // Nếu TextBox tìm kiếm trống, hiển thị lại toàn bộ dữ liệu hóa đơn nhập
                LoadDanhSachHoaDonBan();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                DataTable dt = new DataTable();
                dt = hdb.LookHoaDonBan(searchText);
                dgHD.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin hóa đơn");
                }

            }
            else
            {
                // Nếu textbox rỗng, bạn có thể hiển thị lại dữ liệu ban đầu
                frmQuanLyHoaDonBan_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hóa đơn được chọn trong DataGridView hay không
            if (dgHD.SelectedRows.Count > 0)
            {
                // Lấy mã hóa đơn nhập từ dòng được chọn trong DataGridView
                string maHDB = dgHD.SelectedRows[0].Cells["MaHDB"].Value.ToString();

                // Xóa chi tiết hóa đơn nhập của hóa đơn đó
                BUS_QuanLyHoaDonBan bus = new BUS_QuanLyHoaDonBan();
                bus.DeleteChiTietHoaDonBan(maHDB);

                // Xóa hóa đơn nhập
                bus.DeleteHoaDonBan(maHDB);

                // Hiển thị thông báo
                MessageBox.Show("Đã xóa hóa đơn nhập và chi tiết hóa đơn nhập tương ứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh DataGridView để hiển thị dữ liệu mới
                dgHD.DataSource = bus.ShowHoaDonBan();
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
                // Lấy mã hóa đơn từ ô "MaHDN" của hàng được chọn
                string maHDB = dgHD.Rows[e.RowIndex].Cells["MaHDB"].Value.ToString();

                // Gọi phương thức để lấy chi tiết hóa đơn từ BUS
                DataTable dtCTHDB = hdb.GetChiTietHoaDonBan(maHDB);

                // Kiểm tra xem có dữ liệu chi tiết hóa đơn không
                if (dtCTHDB != null && dtCTHDB.Rows.Count > 0)
                {
                    // Hiển thị dữ liệu chi tiết hóa đơn trong dgCTHD
                    dgCTHDB.DataSource = dtCTHDB;
                }
                else
                {
                    // Nếu không có dữ liệu, bạn có thể hiển thị thông báo hoặc xóa dữ liệu hiển thị trước đó.
                    dgCTHDB.DataSource = null;
                    MessageBox.Show("Không có chi tiết hóa đơn cho hóa đơn này.");
                }
            }
        }

        private void dgHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgHD.Columns[e.ColumnIndex].Name == "TongThanhTien" || dgHD.Columns[e.ColumnIndex].Name == "KhachTra" || dgHD.Columns[e.ColumnIndex].Name == "TienThua")
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

        private void dgCTHDB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgCTHDB.Columns[e.ColumnIndex].Name == "ThanhTien" || dgCTHDB.Columns[e.ColumnIndex].Name == "GiaBan")
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
            else if (dgCTHDB.Columns[e.ColumnIndex].Name == "NgayMua")
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
