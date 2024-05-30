namespace GUI_QuanLy
{
    partial class frmThongKe
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
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgSP = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgNV = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgTonKho = new System.Windows.Forms.DataGridView();
            this.lblLoiNhuan = new System.Windows.Forms.Label();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.lblTongSoLuongTon = new System.Windows.Forms.Label();
            this.lblTongTienTon = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgHD = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSP)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNV)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTonKho)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHD)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackgroundImage = global::GUI_QuanLy.Properties.Resources.thongke;
            this.btnThongKe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThongKe.Location = new System.Drawing.Point(800, 4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(100, 55);
            this.btnThongKe.TabIndex = 33;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(126, 16);
            this.dtpTuNgay.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(287, 30);
            this.dtpTuNgay.TabIndex = 32;
            this.dtpTuNgay.Value = new System.DateTime(2024, 5, 29, 0, 0, 0, 0);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(474, 16);
            this.dtpDenNgay.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(287, 30);
            this.dtpDenNgay.TabIndex = 27;
            this.dtpDenNgay.Value = new System.DateTime(2024, 5, 29, 0, 0, 0, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgSP);
            this.groupBox2.Location = new System.Drawing.Point(12, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 180);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dgSP
            // 
            this.dgSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSP.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dgSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSP.Location = new System.Drawing.Point(10, 25);
            this.dgSP.Name = "dgSP";
            this.dgSP.RowHeadersWidth = 62;
            this.dgSP.RowTemplate.Height = 28;
            this.dgSP.Size = new System.Drawing.Size(481, 149);
            this.dgSP.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgNV);
            this.groupBox1.Location = new System.Drawing.Point(517, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 180);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhân viên";
            // 
            // dgNV
            // 
            this.dgNV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNV.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dgNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNV.Location = new System.Drawing.Point(10, 25);
            this.dgNV.Name = "dgNV";
            this.dgNV.RowHeadersWidth = 62;
            this.dgNV.RowTemplate.Height = 28;
            this.dgNV.Size = new System.Drawing.Size(481, 149);
            this.dgNV.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgTonKho);
            this.groupBox3.Location = new System.Drawing.Point(12, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(497, 180);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách sản phẩm tồn kho";
            // 
            // dgTonKho
            // 
            this.dgTonKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTonKho.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dgTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTonKho.Location = new System.Drawing.Point(10, 25);
            this.dgTonKho.Name = "dgTonKho";
            this.dgTonKho.RowHeadersWidth = 62;
            this.dgTonKho.RowTemplate.Height = 28;
            this.dgTonKho.Size = new System.Drawing.Size(481, 149);
            this.dgTonKho.TabIndex = 4;
            this.dgTonKho.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgTonKho_CellFormatting);
            // 
            // lblLoiNhuan
            // 
            this.lblLoiNhuan.AutoSize = true;
            this.lblLoiNhuan.BackColor = System.Drawing.Color.Transparent;
            this.lblLoiNhuan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoiNhuan.Location = new System.Drawing.Point(758, 430);
            this.lblLoiNhuan.Name = "lblLoiNhuan";
            this.lblLoiNhuan.Size = new System.Drawing.Size(118, 26);
            this.lblLoiNhuan.TabIndex = 77;
            this.lblLoiNhuan.Text = "Lợi nhuận";
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThu.Location = new System.Drawing.Point(522, 430);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(125, 26);
            this.lblDoanhThu.TabIndex = 76;
            this.lblDoanhThu.Text = "Doanh thu ";
            // 
            // lblTongSoLuongTon
            // 
            this.lblTongSoLuongTon.AutoSize = true;
            this.lblTongSoLuongTon.Location = new System.Drawing.Point(27, 430);
            this.lblTongSoLuongTon.Name = "lblTongSoLuongTon";
            this.lblTongSoLuongTon.Size = new System.Drawing.Size(0, 22);
            this.lblTongSoLuongTon.TabIndex = 78;
            // 
            // lblTongTienTon
            // 
            this.lblTongTienTon.AutoSize = true;
            this.lblTongTienTon.Location = new System.Drawing.Point(237, 430);
            this.lblTongTienTon.Name = "lblTongTienTon";
            this.lblTongTienTon.Size = new System.Drawing.Size(0, 22);
            this.lblTongTienTon.TabIndex = 79;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgHD);
            this.groupBox4.Location = new System.Drawing.Point(517, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(497, 180);
            this.groupBox4.TabIndex = 80;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thống kê hóa đơn";
            // 
            // dgHD
            // 
            this.dgHD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgHD.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dgHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHD.Location = new System.Drawing.Point(8, 25);
            this.dgHD.Name = "dgHD";
            this.dgHD.RowHeadersWidth = 62;
            this.dgHD.RowTemplate.Height = 28;
            this.dgHD.Size = new System.Drawing.Size(481, 149);
            this.dgHD.TabIndex = 5;
            this.dgHD.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgHD_CellFormatting);
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1026, 455);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblTongTienTon);
            this.Controls.Add(this.lblTongSoLuongTon);
            this.Controls.Add(this.lblDoanhThu);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblLoiNhuan);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgNV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTonKho)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgSP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgNV;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgTonKho;
        private System.Windows.Forms.Label lblLoiNhuan;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label lblTongSoLuongTon;
        private System.Windows.Forms.Label lblTongTienTon;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgHD;
    }
}