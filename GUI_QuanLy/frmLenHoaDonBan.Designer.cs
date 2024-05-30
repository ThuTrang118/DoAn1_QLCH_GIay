namespace GUI_QuanLy
{
    partial class frmLenHoaDonBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLenHoaDonBan));
            this.txtTienThua = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtKhachTra = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtNgayMua = new System.Windows.Forms.DateTimePicker();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnInHD = new System.Windows.Forms.Button();
            this.btnLenDon = new System.Windows.Forms.Button();
            this.lwSP = new System.Windows.Forms.ListView();
            this.masp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tensp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soluong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dongia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.cboMaSP = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnLenSP = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboMaKH = new System.Windows.Forms.ComboBox();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaHDB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbTBHD = new System.Windows.Forms.Label();
            this.cboTenNV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTienThua
            // 
            this.txtTienThua.Location = new System.Drawing.Point(730, 387);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.ReadOnly = true;
            this.txtTienThua.Size = new System.Drawing.Size(163, 30);
            this.txtTienThua.TabIndex = 60;
            this.txtTienThua.Text = "0";
            this.txtTienThua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(613, 392);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 22);
            this.label18.TabIndex = 59;
            this.label18.Text = "Tiền thừa";
            // 
            // txtKhachTra
            // 
            this.txtKhachTra.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtKhachTra.Location = new System.Drawing.Point(729, 351);
            this.txtKhachTra.Name = "txtKhachTra";
            this.txtKhachTra.Size = new System.Drawing.Size(164, 30);
            this.txtKhachTra.TabIndex = 57;
            this.txtKhachTra.TextChanged += new System.EventHandler(this.txtKhachTra_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(613, 356);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 22);
            this.label16.TabIndex = 58;
            this.label16.Text = "Khách trả";
            // 
            // dtNgayMua
            // 
            this.dtNgayMua.CustomFormat = "dd/MM/yyyy";
            this.dtNgayMua.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayMua.Location = new System.Drawing.Point(728, 278);
            this.dtNgayMua.Name = "dtNgayMua";
            this.dtNgayMua.Size = new System.Drawing.Size(163, 30);
            this.dtNgayMua.TabIndex = 54;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(729, 315);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(163, 30);
            this.txtThanhTien.TabIndex = 55;
            this.txtThanhTien.Text = "0";
            this.txtThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtThanhTien.TextChanged += new System.EventHandler(this.txtThanhTien_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(610, 280);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 22);
            this.label17.TabIndex = 52;
            this.label17.Text = "Ngày mua";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(612, 319);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 22);
            this.label20.TabIndex = 53;
            this.label20.Text = "Thành tiền";
            // 
            // btnInHD
            // 
            this.btnInHD.BackgroundImage = global::GUI_QuanLy.Properties.Resources._in;
            this.btnInHD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInHD.Location = new System.Drawing.Point(901, 338);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(110, 40);
            this.btnInHD.TabIndex = 61;
            this.btnInHD.Text = "In Hóa Đơn";
            this.btnInHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInHD.UseVisualStyleBackColor = true;
            this.btnInHD.Click += new System.EventHandler(this.btnInHD_Click);
            // 
            // btnLenDon
            // 
            this.btnLenDon.BackgroundImage = global::GUI_QuanLy.Properties.Resources.hoadon1;
            this.btnLenDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLenDon.Location = new System.Drawing.Point(901, 288);
            this.btnLenDon.Name = "btnLenDon";
            this.btnLenDon.Size = new System.Drawing.Size(110, 40);
            this.btnLenDon.TabIndex = 56;
            this.btnLenDon.Text = "Lên đơn";
            this.btnLenDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLenDon.UseVisualStyleBackColor = true;
            this.btnLenDon.Click += new System.EventHandler(this.btnLenDon_Click);
            // 
            // lwSP
            // 
            this.lwSP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.masp,
            this.tensp,
            this.soluong,
            this.dongia});
            this.lwSP.GridLines = true;
            this.lwSP.HideSelection = false;
            this.lwSP.Location = new System.Drawing.Point(15, 272);
            this.lwSP.Name = "lwSP";
            this.lwSP.Size = new System.Drawing.Size(585, 171);
            this.lwSP.TabIndex = 51;
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
            // dongia
            // 
            this.dongia.Text = "Đơn giá";
            this.dongia.Width = 113;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTenSP);
            this.groupBox3.Controls.Add(this.txtSoLuong);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtGiaBan);
            this.groupBox3.Controls.Add(this.cboMaSP);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.btnLenSP);
            this.groupBox3.Location = new System.Drawing.Point(606, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 171);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sản phẩm";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenSP.Location = new System.Drawing.Point(89, 66);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenSP.Multiline = true;
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(117, 44);
            this.txtTenSP.TabIndex = 26;
            this.txtTenSP.TextChanged += new System.EventHandler(this.txtTenSP_TextChanged);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(279, 34);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(117, 30);
            this.txtSoLuong.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 37);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 22);
            this.label10.TabIndex = 20;
            this.label10.Text = "Mã SP";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(279, 72);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.ReadOnly = true;
            this.txtGiaBan.Size = new System.Drawing.Size(117, 30);
            this.txtGiaBan.TabIndex = 24;
            this.txtGiaBan.Text = "0";
            this.txtGiaBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboMaSP
            // 
            this.cboMaSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaSP.FormattingEnabled = true;
            this.cboMaSP.Location = new System.Drawing.Point(89, 31);
            this.cboMaSP.Name = "cboMaSP";
            this.cboMaSP.Size = new System.Drawing.Size(117, 30);
            this.cboMaSP.TabIndex = 17;
            this.cboMaSP.SelectedIndexChanged += new System.EventHandler(this.cboMaSP_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(234, 37);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 22);
            this.label11.TabIndex = 22;
            this.label11.Text = "SL";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 78);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 22);
            this.label13.TabIndex = 21;
            this.label13.Text = "Tên SP";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(205, 76);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 22);
            this.label15.TabIndex = 23;
            this.label15.Text = "Giá bán";
            // 
            // btnLenSP
            // 
            this.btnLenSP.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnLenSP.Location = new System.Drawing.Point(170, 128);
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
            this.groupBox2.Controls.Add(this.cboMaKH);
            this.groupBox2.Controls.Add(this.txtGioiTinh);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtTenKH);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtSDT);
            this.groupBox2.Controls.Add(this.txtDiaChi);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(15, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 171);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khách hàng";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnThem.Location = new System.Drawing.Point(266, 128);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 37);
            this.btnThem.TabIndex = 25;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboMaKH
            // 
            this.cboMaKH.FormattingEnabled = true;
            this.cboMaKH.Location = new System.Drawing.Point(110, 19);
            this.cboMaKH.Name = "cboMaKH";
            this.cboMaKH.Size = new System.Drawing.Size(181, 30);
            this.cboMaKH.TabIndex = 47;
            this.cboMaKH.SelectedIndexChanged += new System.EventHandler(this.cboMaKH_SelectedIndexChanged);
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.Location = new System.Drawing.Point(110, 91);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(181, 30);
            this.txtGioiTinh.TabIndex = 42;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 22);
            this.label14.TabIndex = 16;
            this.label14.Text = "Giới tính";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(110, 56);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(181, 30);
            this.txtTenKH.TabIndex = 1;
            this.txtTenKH.TextChanged += new System.EventHandler(this.txtTenKH_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mã KH";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(390, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(181, 30);
            this.txtEmail.TabIndex = 4;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(390, 55);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(181, 30);
            this.txtSDT.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(390, 21);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(181, 30);
            this.txtDiaChi.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tên KH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 98);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "SĐT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 22);
            this.label9.TabIndex = 14;
            this.label9.Text = "Địa chỉ";
            // 
            // txtMaHDB
            // 
            this.txtMaHDB.Location = new System.Drawing.Point(142, 11);
            this.txtMaHDB.Name = "txtMaHDB";
            this.txtMaHDB.Size = new System.Drawing.Size(458, 30);
            this.txtMaHDB.TabIndex = 47;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 14);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 22);
            this.label12.TabIndex = 48;
            this.label12.Text = "Mã hóa đơn";
            // 
            // lbTBHD
            // 
            this.lbTBHD.AutoSize = true;
            this.lbTBHD.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTBHD.ForeColor = System.Drawing.Color.Red;
            this.lbTBHD.Location = new System.Drawing.Point(613, 37);
            this.lbTBHD.Name = "lbTBHD";
            this.lbTBHD.Size = new System.Drawing.Size(0, 20);
            this.lbTBHD.TabIndex = 64;
            // 
            // cboTenNV
            // 
            this.cboTenNV.FormattingEnabled = true;
            this.cboTenNV.Location = new System.Drawing.Point(414, 47);
            this.cboTenNV.Name = "cboTenNV";
            this.cboTenNV.Size = new System.Drawing.Size(186, 30);
            this.cboTenNV.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 67;
            this.label1.Text = "Tên nhân viên";
            // 
            // cboMaNV
            // 
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(142, 48);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(138, 30);
            this.cboMaNV.TabIndex = 66;
            this.cboMaNV.SelectedIndexChanged += new System.EventHandler(this.cboMaNV_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 22);
            this.label2.TabIndex = 65;
            this.label2.Text = "Mã nhân viên";
            // 
            // btnHuy
            // 
            this.btnHuy.BackgroundImage = global::GUI_QuanLy.Properties.Resources.xoa;
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuy.Location = new System.Drawing.Point(901, 392);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 40);
            this.btnHuy.TabIndex = 69;
            this.btnHuy.Text = "Hủy ";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmLenHoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1026, 455);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.cboTenNV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMaNV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTBHD);
            this.Controls.Add(this.txtTienThua);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtKhachTra);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtNgayMua);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnInHD);
            this.Controls.Add(this.btnLenDon);
            this.Controls.Add(this.lwSP);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtMaHDB);
            this.Controls.Add(this.label12);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmLenHoaDonBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lên hóa đơn bán";
            this.Load += new System.EventHandler(this.frmLenHoaDonBan_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTienThua;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtKhachTra;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtNgayMua;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.Button btnLenDon;
        private System.Windows.Forms.ListView lwSP;
        private System.Windows.Forms.ColumnHeader masp;
        private System.Windows.Forms.ColumnHeader tensp;
        private System.Windows.Forms.ColumnHeader soluong;
        private System.Windows.Forms.ColumnHeader dongia;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.ComboBox cboMaSP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnLenSP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cboMaKH;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaHDB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbTBHD;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.ComboBox cboTenNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHuy;
    }
}