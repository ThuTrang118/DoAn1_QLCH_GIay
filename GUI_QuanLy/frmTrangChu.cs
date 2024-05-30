using BUS_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GUI_QuanLy
{
    public partial class frmTrangChu : Form
    {
        private string TK;
        private string Quyen;
        BUS_TrangChu trangchu = new BUS_TrangChu();
        public frmTrangChu(string TK, string Quyen)
        {
            InitializeComponent();
            this.TK = TK;
            this.Quyen = Quyen;
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnQLSP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLySanPham());
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyKhachHang());
        }
        private void btnQLNV_Click(object sender, EventArgs e)
        {
            if (trangchu.IsAdmin(TK)) // Check if the current user is an admin
            {
                OpenChildForm(new frmQuanLyNhanVien());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQLNCC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyNhaCungCap());
        }

        private void btnHDN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyHoaDonNhap());
        }

        private void btnHDB_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyHoaDonBan());
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (trangchu.IsAdmin(TK)) // Check if the current user is an admin
            {
                OpenChildForm(new frmThongKe(TK, true));
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDX_Click(object sender, EventArgs e)
        {

            frmDangNhap dn = new frmDangNhap();
            dn.Show();
            this.Hide();
        }
    }
}
