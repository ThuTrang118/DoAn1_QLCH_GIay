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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI_QuanLy
{
    public partial class frmQuenMatKhau : Form
    {
        BUS_QuenMatKhau dn = new BUS_QuenMatKhau();
        public frmQuenMatKhau()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string tenDN = txtTenDN.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tenDN))
            {
                MessageBox.Show("Vui lòng nhập Tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = dn.checkEmail(email, tenDN);

            if (dt.Rows.Count > 0)
            {
                string matKhau = dt.Rows[0]["MK"].ToString();
                lblKetQua.Text = $"Mật khẩu của bạn là: {matKhau}";
            }
            else
            {
                MessageBox.Show("Email hoặc tên đăng nhập không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtTenDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            lblKetQua.Text = "";
        }

        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {
            lblKetQua.Text = "";
        }

        private void btnDangNhap_MouseEnter(object sender, EventArgs e)
        {
            btnDangNhap.BackColor = Color.SaddleBrown;
        }

        private void btnDangNhap_MouseLeave(object sender, EventArgs e)
        {
            btnDangNhap.BackColor = Color.Coral;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
