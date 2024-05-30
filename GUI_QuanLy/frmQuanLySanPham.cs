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
    public partial class frmQuanLySanPham : Form
    {
        public event EventHandler FormClosedEvent;
        public frmQuanLySanPham()
        {
            InitializeComponent();
        }
        BUS_QuanLySanPham sanpham = new BUS_QuanLySanPham();
    private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = sanpham.ShowSanPham();
            dgSP.DataSource = dt;
            BindingSource bindingSource = new BindingSource();
            dgSP.DataSource = bindingSource;
            bindingSource.DataSource = dt;
            dgSP.CellFormatting += new DataGridViewCellFormattingEventHandler(dgSP_CellFormatting);
            BUS_QuanLySanPham dalQLSP = new BUS_QuanLySanPham();
            DataTable dtMaNCC = dalQLSP.LayDanhSachMaNCC();
            if (dtMaNCC.Rows.Count > 0)
            {
                cboMaNCC.DataSource = dtMaNCC;
                cboMaNCC.DisplayMember = "MaNCC";
                cboMaNCC.ValueMember = "MaNCC";
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            this.txtMaSP.Clear();
            this.txtTenSP.Clear();
            this.txtSize.Clear();
            this.txtMau.Clear();
            this.txtGiaNhap.Clear();
            this.txtGiaBan.Clear();
            this.txtSoLuong.Clear();
            this.txtSoLuongBan.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            lbTBSP.Text = "";
            string MaSP = this.txtMaSP.Text.Trim();
            if (string.IsNullOrEmpty(MaSP))
            {
                lbTBSP.Text = "Vui lòng nhập mã sản phẩm!";
            }
            if (string.IsNullOrWhiteSpace(this.txtTenSP.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return;
            }

            if (!int.TryParse(this.txtSize.Text, out int size) || size <= 0)
            {
                MessageBox.Show("Size sản phẩm phải là một số nguyên dương!");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtMau.Text))
            {
                MessageBox.Show("Màu sản phẩm không được để trống!");
                return;
            }

            if (string.IsNullOrWhiteSpace(cboMaNCC.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống!");
                return;
            }

            if (!float.TryParse(this.txtGiaNhap.Text, out float giaNhap) || giaNhap <= 0)
            {
                MessageBox.Show("Giá nhập phải là một số dương!");
                return;
            }

            if (!float.TryParse(this.txtGiaBan.Text, out float giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán phải là một số dương!");
                return;
            }

            if (!int.TryParse(this.txtSoLuong.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là một số nguyên không âm!");
                return;
            }

            if (!int.TryParse(this.txtSoLuongBan.Text, out int soLuongBan) || soLuongBan < 0)
            {
                MessageBox.Show("Số lượng bán phải là một số nguyên không âm!");
                return;
            }
            else
            {
                if (sanpham.KiemTraMaSanPhamTonTai(MaSP))
                {
                    lbTBSP.Text = "Mã sản phẩm đã tồn tại.Vui lòng nhập mã khác!";
                }
                else
                {
                    sanpham.InsertSanPham(this.txtMaSP.Text, this.txtTenSP.Text, int.Parse(this.txtSize.Text), this.txtMau.Text, this.cboMaNCC.Text, float.Parse(this.txtGiaNhap.Text), float.Parse(this.txtGiaBan.Text), int.Parse(this.txtSoLuong.Text), int.Parse(this.txtSoLuongBan.Text));
                    MessageBox.Show("Đã thêm vào sản phẩm " + this.txtMaSP.Text + " thành công");
                    frmQuanLySanPham_Load(sender, e);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lbTBSP.Text = "";
            if (this.txtMaSP.TextLength == 0)
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm bạn muốn sửa!");
            }
            if (string.IsNullOrWhiteSpace(this.txtTenSP.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return;
            }

            if (!int.TryParse(this.txtSize.Text, out int size) || size <= 0)
            {
                MessageBox.Show("Size sản phẩm phải là một số nguyên dương!");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtMau.Text))
            {
                MessageBox.Show("Màu sản phẩm không được để trống!");
                return;
            }

            if (string.IsNullOrWhiteSpace(cboMaNCC.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống!");
                return;
            }

            if (!float.TryParse(this.txtGiaNhap.Text, out float giaNhap) || giaNhap <= 0)
            {
                MessageBox.Show("Giá nhập phải là một số dương!");
                return;
            }

            if (!float.TryParse(this.txtGiaBan.Text, out float giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán phải là một số dương!");
                return;
            }

            if (!int.TryParse(this.txtSoLuong.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là một số nguyên không âm!");
                return;
            }

            if (!int.TryParse(this.txtSoLuongBan.Text, out int soLuongBan) || soLuongBan < 0)
            {
                MessageBox.Show("Số lượng bán phải là một số nguyên không âm!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn sửa sản phẩm giày này không?", "Sửa sản phẩm ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sanpham.UpdateSanPham(this.txtMaSP.Text, this.txtTenSP.Text, int.Parse(this.txtSize.Text), this.txtMau.Text, cboMaNCC.Text, float.Parse(this.txtGiaNhap.Text), float.Parse(this.txtGiaBan.Text), int.Parse(this.txtSoLuong.Text), int.Parse(this.txtSoLuongBan.Text));
                MessageBox.Show("Đã cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmQuanLySanPham_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.txtMaSP.TextLength == 0)
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm bạn muốn xóa!");
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm giày này không?", "Xóa sản phẩm ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sanpham.DeleteSanPham(txtMaSP.Text);
                    MessageBox.Show(" Xóa sản phẩm giày có mã " + this.txtMaSP.Text + " thành công");
                    frmQuanLySanPham_Load(sender, e);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (this.txtTimKiem.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập thông tin sản phẩm giày cần tìm kiếm");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = sanpham.LookSanPham(this.txtTimKiem.Text);
                dgSP.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin về sản phẩm giày có mã là " + this.txtTimKiem.Text + " trong danh sách sản phẩm của cửa hàng!");
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTimKiem.TextLength == 0)
            {
                frmQuanLySanPham_Load(sender, e);
            }
        }

        private void dgSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dgSP.CurrentCell.RowIndex;
                if (dgSP.Rows[dong].Cells["MaSP"].Value != null)
                {
                    txtMaSP.Text = dgSP.Rows[dong].Cells["MaSP"].Value.ToString();
                }
                if (dgSP.Rows[dong].Cells["TenSP"].Value != null)
                {
                    txtTenSP.Text = dgSP.Rows[dong].Cells["TenSP"].Value.ToString();
                }
                if (dgSP.Rows[dong].Cells["Size"].Value != null)
                {
                    txtSize.Text = dgSP.Rows[dong].Cells["Size"].Value.ToString();
                }
                if (dgSP.Rows[dong].Cells["MauSac"].Value != null)
                {
                    txtMau.Text = dgSP.Rows[dong].Cells["MauSac"].Value.ToString();
                }
                if (dgSP.Rows[dong].Cells["MaNCC"].Value != null)
                {
                    cboMaNCC.Text = dgSP.Rows[dong].Cells["MaNCC"].Value.ToString();
                }
                if (dgSP.Rows[dong].Cells["GiaNhap"].Value != null)
                {
                    txtGiaNhap.Text = dgSP.Rows[dong].Cells["GiaNhap"].Value.ToString();
                }
                if (dgSP.Rows[dong].Cells["GiaBan"].Value != null)
                {
                    txtGiaBan.Text = dgSP.Rows[dong].Cells["GiaBan"].Value.ToString();
                }
                if (dgSP.Rows[dong].Cells["SL"].Value != null)
                {
                    txtSoLuong.Text = dgSP.Rows[dong].Cells["SL"].Value.ToString();
                }
                if (dgSP.Rows[dong].Cells["SLDaBan"].Value != null)
                {
                    txtSoLuongBan.Text = dgSP.Rows[dong].Cells["SLDaBan"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgSP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgSP.Columns[e.ColumnIndex].Name == "GiaNhap" || dgSP.Columns[e.ColumnIndex].Name == "GiaBan")
            {
                if (e.Value != null)
                {
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
        }

        private void frmQuanLySanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);

        }
    }
}
