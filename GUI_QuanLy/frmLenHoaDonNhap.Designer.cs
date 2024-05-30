namespace GUI_QuanLy
{
    partial class frmLenHoaDonNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader dongia;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLenHoaDonNhap));
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtNgayMua = new System.Windows.Forms.DateTimePicker();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lwSP = new System.Windows.Forms.ListView();
            this.masp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tensp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soluong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboMaSP = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnLenSP = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboMaNCC = new System.Windows.Forms.ComboBox();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaHDN = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbTBHD = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnLenDon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTenNV = new System.Windows.Forms.ComboBox();
            dongia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dongia
            // 
            dongia.Text = "Giá nhập";
            dongia.Width = 113;
            // 
            // cboMaNV
            // 
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(142, 58);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(138, 30);
            this.cboMaNV.TabIndex = 56;
            this.cboMaNV.SelectedIndexChanged += new System.EventHandler(this.cboMaNV_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 62);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 22);
            this.label15.TabIndex = 55;
            this.label15.Text = "Mã nhân viên";
            // 
            // dtNgayMua
            // 
            this.dtNgayMua.CustomFormat = "dd/MM/yyyy";
            this.dtNgayMua.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayMua.Location = new System.Drawing.Point(759, 285);
            this.dtNgayMua.Name = "dtNgayMua";
            this.dtNgayMua.Size = new System.Drawing.Size(149, 30);
            this.dtNgayMua.TabIndex = 52;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(759, 325);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(149, 30);
            this.txtThanhTien.TabIndex = 53;
            this.txtThanhTien.Text = "0";
            this.txtThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtThanhTien.TextChanged += new System.EventHandler(this.txtThanhTien_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(652, 285);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 22);
            this.label17.TabIndex = 50;
            this.label17.Text = "Ngày mua";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(653, 327);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 22);
            this.label20.TabIndex = 51;
            this.label20.Text = "Thành tiền";
            // 
            // lwSP
            // 
            this.lwSP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.masp,
            this.tensp,
            this.soluong,
            dongia});
            this.lwSP.GridLines = true;
            this.lwSP.HideSelection = false;
            this.lwSP.Location = new System.Drawing.Point(15, 275);
            this.lwSP.Name = "lwSP";
            this.lwSP.Size = new System.Drawing.Size(585, 180);
            this.lwSP.TabIndex = 49;
            this.lwSP.UseCompatibleStateImageBehavior = false;
            this.lwSP.View = System.Windows.Forms.View.Details;
            this.lwSP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lwSP_MouseDown);
            // 
            // masp
            // 
            this.masp.Text = "Mã SP";
            this.masp.Width = 165;
            // 
            // tensp
            // 
            this.tensp.Text = "Tên SP";
            this.tensp.Width = 208;
            // 
            // soluong
            // 
            this.soluong.Text = "Số lượng";
            this.soluong.Width = 111;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnThemSP);
            this.groupBox3.Controls.Add(this.txtGiaNhap);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.cboMaSP);
            this.groupBox3.Controls.Add(this.txtSoLuong);
            this.groupBox3.Controls.Add(this.txtTenSP);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.btnLenSP);
            this.groupBox3.Location = new System.Drawing.Point(606, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 183);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sản phẩm";
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnThemSP.Location = new System.Drawing.Point(81, 134);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(96, 37);
            this.btnThemSP.TabIndex = 43;
            this.btnThemSP.Text = "Thêm ";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGiaNhap.Location = new System.Drawing.Point(282, 82);
            this.txtGiaNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGiaNhap.Multiline = true;
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(117, 29);
            this.txtGiaNhap.TabIndex = 41;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(202, 90);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 22);
            this.label16.TabIndex = 40;
            this.label16.Text = "Giá nhập";
            // 
            // cboMaSP
            // 
            this.cboMaSP.FormattingEnabled = true;
            this.cboMaSP.Location = new System.Drawing.Point(81, 41);
            this.cboMaSP.Name = "cboMaSP";
            this.cboMaSP.Size = new System.Drawing.Size(117, 30);
            this.cboMaSP.TabIndex = 20;
            this.cboMaSP.SelectedIndexChanged += new System.EventHandler(this.cboMaSP_SelectedIndexChanged);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoLuong.Location = new System.Drawing.Point(282, 40);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuong.Multiline = true;
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(117, 29);
            this.txtSoLuong.TabIndex = 32;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenSP.Location = new System.Drawing.Point(81, 82);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenSP.Multiline = true;
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(117, 44);
            this.txtTenSP.TabIndex = 25;
            this.txtTenSP.TextChanged += new System.EventHandler(this.txtTenSP_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(202, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 22);
            this.label13.TabIndex = 35;
            this.label13.Text = "Số lượng";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(5, 87);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 22);
            this.label18.TabIndex = 29;
            this.label18.Text = "Tên giày";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(5, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 22);
            this.label19.TabIndex = 27;
            this.label19.Text = "Mã giày";
            // 
            // btnLenSP
            // 
            this.btnLenSP.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnLenSP.Location = new System.Drawing.Point(251, 134);
            this.btnLenSP.Name = "btnLenSP";
            this.btnLenSP.Size = new System.Drawing.Size(96, 37);
            this.btnLenSP.TabIndex = 16;
            this.btnLenSP.Text = "Lên SP";
            this.btnLenSP.UseVisualStyleBackColor = false;
            this.btnLenSP.Click += new System.EventHandler(this.btnLenSP_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.cboMaNCC);
            this.groupBox2.Controls.Add(this.txtGioiTinh);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtTenNCC);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtSDT);
            this.groupBox2.Controls.Add(this.txtDiaChi);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(15, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 183);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhà cung cấp";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnThem.Location = new System.Drawing.Point(266, 140);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 37);
            this.btnThem.TabIndex = 42;
            this.btnThem.Text = "Thêm ";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboMaNCC
            // 
            this.cboMaNCC.FormattingEnabled = true;
            this.cboMaNCC.Location = new System.Drawing.Point(110, 24);
            this.cboMaNCC.Name = "cboMaNCC";
            this.cboMaNCC.Size = new System.Drawing.Size(181, 30);
            this.cboMaNCC.TabIndex = 18;
            this.cboMaNCC.SelectedIndexChanged += new System.EventHandler(this.cboMaNCC_SelectedIndexChanged);
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.Location = new System.Drawing.Point(110, 104);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(181, 30);
            this.txtGioiTinh.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 22);
            this.label14.TabIndex = 16;
            this.label14.Text = "Giới tính";
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(110, 64);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(181, 30);
            this.txtTenNCC.TabIndex = 1;
            this.txtTenNCC.TextChanged += new System.EventHandler(this.txtTenNCC_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mã NCC";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(390, 101);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(181, 30);
            this.txtEmail.TabIndex = 4;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(390, 62);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(181, 30);
            this.txtSDT.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(390, 24);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(181, 30);
            this.txtDiaChi.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tên NCC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "SĐT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 22);
            this.label9.TabIndex = 14;
            this.label9.Text = "Địa chỉ";
            // 
            // txtMaHDN
            // 
            this.txtMaHDN.Location = new System.Drawing.Point(142, 22);
            this.txtMaHDN.Name = "txtMaHDN";
            this.txtMaHDN.Size = new System.Drawing.Size(458, 30);
            this.txtMaHDN.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 25);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 22);
            this.label12.TabIndex = 46;
            this.label12.Text = "Mã hóa đơn";
            // 
            // lbTBHD
            // 
            this.lbTBHD.AutoSize = true;
            this.lbTBHD.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTBHD.ForeColor = System.Drawing.Color.Red;
            this.lbTBHD.Location = new System.Drawing.Point(619, 32);
            this.lbTBHD.Name = "lbTBHD";
            this.lbTBHD.Size = new System.Drawing.Size(0, 20);
            this.lbTBHD.TabIndex = 57;
            // 
            // btnHuy
            // 
            this.btnHuy.BackgroundImage = global::GUI_QuanLy.Properties.Resources.xoa;
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuy.Location = new System.Drawing.Point(905, 359);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 50);
            this.btnHuy.TabIndex = 62;
            this.btnHuy.Text = "Hủy ";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = global::GUI_QuanLy.Properties.Resources.back1;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(968, 415);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(57, 40);
            this.btnThoat.TabIndex = 61;
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackgroundImage = global::GUI_QuanLy.Properties.Resources.in1;
            this.btnIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(759, 361);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(100, 50);
            this.btnIn.TabIndex = 60;
            this.btnIn.Text = "In";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnLenDon
            // 
            this.btnLenDon.BackgroundImage = global::GUI_QuanLy.Properties.Resources.hoadon1;
            this.btnLenDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLenDon.Location = new System.Drawing.Point(623, 361);
            this.btnLenDon.Name = "btnLenDon";
            this.btnLenDon.Size = new System.Drawing.Size(100, 50);
            this.btnLenDon.TabIndex = 54;
            this.btnLenDon.Text = "Thêm";
            this.btnLenDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLenDon.UseVisualStyleBackColor = true;
            this.btnLenDon.Click += new System.EventHandler(this.btnLenDon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 63;
            this.label1.Text = "Tên nhân viên";
            // 
            // cboTenNV
            // 
            this.cboTenNV.FormattingEnabled = true;
            this.cboTenNV.Location = new System.Drawing.Point(414, 57);
            this.cboTenNV.Name = "cboTenNV";
            this.cboTenNV.Size = new System.Drawing.Size(186, 30);
            this.cboTenNV.TabIndex = 64;
            // 
            // frmLenHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1026, 455);
            this.Controls.Add(this.cboTenNV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.lbTBHD);
            this.Controls.Add(this.cboMaNV);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnLenDon);
            this.Controls.Add(this.dtNgayMua);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lwSP);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtMaHDN);
            this.Controls.Add(this.label12);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmLenHoaDonNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lên hóa đơn nhập";
            this.Load += new System.EventHandler(this.frmLenHoaDonNhap_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnLenDon;
        private System.Windows.Forms.DateTimePicker dtNgayMua;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListView lwSP;
        private System.Windows.Forms.ColumnHeader masp;
        private System.Windows.Forms.ColumnHeader tensp;
        private System.Windows.Forms.ColumnHeader soluong;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboMaSP;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnLenSP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cboMaNCC;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaHDN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbTBHD;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTenNV;
    }
}