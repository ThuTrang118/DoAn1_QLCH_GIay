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
using static System.Net.Mime.MediaTypeNames;

namespace GUI_QuanLy
{
    public partial class frmDangNhap : Form
    {
        BUS_DangNhap dn = new BUS_DangNhap();
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = dn.checkTaiKhoan(this.txtTenDN.Text, this.txtMK.Text);
            if (string.IsNullOrEmpty(txtTenDN.Text) || string.IsNullOrEmpty(txtMK.Text))
            {
                lblThongBao.Text = "Vui lòng điền đầy đủ tên đăng nhập và mật khẩu"; 
                return; // Dừng lại nếu có trường đang trống
            }
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmTrangChu tc = new frmTrangChu(this.txtTenDN.Text, "Quyen"); // Truyền thông tin cần thiết
                tc.Show();
            }
            
            else
            {
                lblThongBao.Text = "Vui lòng điền đúng tên đăng nhập và mật khẩu";
            }
        }
        private void txtTenDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMK.Focus();
            }
        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void txtTenDN_MouseEnter(object sender, EventArgs e)
        {
            btnDangNhap.BackColor = Color.SaddleBrown;
        }

        private void txtTenDN_MouseLeave(object sender, EventArgs e)
        {
            btnDangNhap.BackColor = Color.Coral;
        }

        private void linkLabelQuenMatKhau_MouseEnter(object sender, EventArgs e)
        {
            linkLabelQuenMatKhau.LinkColor = Color.Green;
        }

        private void linkLabelQuenMatKhau_MouseLeave(object sender, EventArgs e)
        {
            linkLabelQuenMatKhau.LinkColor = Color.Blue;
        }

        private void linkLabelQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMatKhau qmk = new frmQuenMatKhau();
            qmk.ShowDialog();
        }

        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPass.Checked == true)
            {
                txtMK.UseSystemPasswordChar = false;
            }
            else
            {

                txtMK.UseSystemPasswordChar = true;
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
