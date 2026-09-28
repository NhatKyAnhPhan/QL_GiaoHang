namespace DoAn.UI
{
    partial class FormDatHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatHang));
            this.label1 = new System.Windows.Forms.Label();
            this.grChonNH = new System.Windows.Forms.GroupBox();
            this.cboNhaHang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grDMMA = new System.Windows.Forms.GroupBox();
            this.cboMonAn = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grDS = new System.Windows.Forms.GroupBox();
            this.grGioHang = new System.Windows.Forms.GroupBox();
            this.dtGH = new System.Windows.Forms.DataGridView();
            this.grChitietmon = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGC = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.grKH = new System.Windows.Forms.GroupBox();
            this.cboKH = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grKM = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboKM = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grTien = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDat = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dtDS = new System.Windows.Forms.DataGridView();
            this.grChonNH.SuspendLayout();
            this.grDMMA.SuspendLayout();
            this.grDS.SuspendLayout();
            this.grGioHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGH)).BeginInit();
            this.grChitietmon.SuspendLayout();
            this.grKH.SuspendLayout();
            this.grKM.SuspendLayout();
            this.grTien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(383, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đặt Hàng";
            // 
            // grChonNH
            // 
            this.grChonNH.Controls.Add(this.cboNhaHang);
            this.grChonNH.Controls.Add(this.label2);
            this.grChonNH.Location = new System.Drawing.Point(11, 84);
            this.grChonNH.Name = "grChonNH";
            this.grChonNH.Size = new System.Drawing.Size(417, 85);
            this.grChonNH.TabIndex = 1;
            this.grChonNH.TabStop = false;
            this.grChonNH.Text = "Chọn Nhà hàng";
            // 
            // cboNhaHang
            // 
            this.cboNhaHang.FormattingEnabled = true;
            this.cboNhaHang.Location = new System.Drawing.Point(118, 41);
            this.cboNhaHang.Name = "cboNhaHang";
            this.cboNhaHang.Size = new System.Drawing.Size(280, 33);
            this.cboNhaHang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhà hàng";
            // 
            // grDMMA
            // 
            this.grDMMA.Controls.Add(this.cboMonAn);
            this.grDMMA.Controls.Add(this.label3);
            this.grDMMA.Location = new System.Drawing.Point(462, 84);
            this.grDMMA.Name = "grDMMA";
            this.grDMMA.Size = new System.Drawing.Size(417, 85);
            this.grDMMA.TabIndex = 2;
            this.grDMMA.TabStop = false;
            this.grDMMA.Text = "Danh mục món ăn";
            // 
            // cboMonAn
            // 
            this.cboMonAn.FormattingEnabled = true;
            this.cboMonAn.Location = new System.Drawing.Point(118, 41);
            this.cboMonAn.Name = "cboMonAn";
            this.cboMonAn.Size = new System.Drawing.Size(280, 33);
            this.cboMonAn.TabIndex = 2;
            this.cboMonAn.SelectedIndexChanged += new System.EventHandler(this.cboMonAn_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Món ăn";
            // 
            // grDS
            // 
            this.grDS.Controls.Add(this.dtDS);
            this.grDS.Location = new System.Drawing.Point(11, 195);
            this.grDS.Name = "grDS";
            this.grDS.Size = new System.Drawing.Size(417, 133);
            this.grDS.TabIndex = 3;
            this.grDS.TabStop = false;
            this.grDS.Text = "Danh sách món ăn";
            // 
            // grGioHang
            // 
            this.grGioHang.Controls.Add(this.btnNew);
            this.grGioHang.Controls.Add(this.btnXoa);
            this.grGioHang.Controls.Add(this.dtGH);
            this.grGioHang.Location = new System.Drawing.Point(462, 195);
            this.grGioHang.Name = "grGioHang";
            this.grGioHang.Size = new System.Drawing.Size(417, 184);
            this.grGioHang.TabIndex = 4;
            this.grGioHang.TabStop = false;
            this.grGioHang.Text = "Giỏ hàng";
            // 
            // dtGH
            // 
            this.dtGH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGH.Location = new System.Drawing.Point(27, 32);
            this.dtGH.Name = "dtGH";
            this.dtGH.RowHeadersWidth = 62;
            this.dtGH.RowTemplate.Height = 28;
            this.dtGH.Size = new System.Drawing.Size(371, 86);
            this.dtGH.TabIndex = 0;
            // 
            // grChitietmon
            // 
            this.grChitietmon.Controls.Add(this.label7);
            this.grChitietmon.Controls.Add(this.label6);
            this.grChitietmon.Controls.Add(this.label5);
            this.grChitietmon.Controls.Add(this.label4);
            this.grChitietmon.Controls.Add(this.txtGC);
            this.grChitietmon.Controls.Add(this.txtSL);
            this.grChitietmon.Controls.Add(this.txtGia);
            this.grChitietmon.Controls.Add(this.txtTenMon);
            this.grChitietmon.Location = new System.Drawing.Point(11, 348);
            this.grChitietmon.Name = "grChitietmon";
            this.grChitietmon.Size = new System.Drawing.Size(417, 205);
            this.grChitietmon.TabIndex = 5;
            this.grChitietmon.TabStop = false;
            this.grChitietmon.Text = "Chi tiết món";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ghi chú";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số Lượng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tên Món";
            // 
            // txtGC
            // 
            this.txtGC.Location = new System.Drawing.Point(118, 153);
            this.txtGC.Name = "txtGC";
            this.txtGC.Size = new System.Drawing.Size(232, 33);
            this.txtGC.TabIndex = 9;
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(118, 114);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(167, 33);
            this.txtSL.TabIndex = 8;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(118, 75);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(167, 33);
            this.txtGia.TabIndex = 7;
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(118, 36);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(167, 33);
            this.txtTenMon.TabIndex = 6;
            // 
            // grKH
            // 
            this.grKH.Controls.Add(this.cboKH);
            this.grKH.Controls.Add(this.label8);
            this.grKH.Location = new System.Drawing.Point(462, 405);
            this.grKH.Name = "grKH";
            this.grKH.Size = new System.Drawing.Size(417, 85);
            this.grKH.TabIndex = 6;
            this.grKH.TabStop = false;
            this.grKH.Text = "Khách Hàng";
            // 
            // cboKH
            // 
            this.cboKH.FormattingEnabled = true;
            this.cboKH.Location = new System.Drawing.Point(131, 41);
            this.cboKH.Name = "cboKH";
            this.cboKH.Size = new System.Drawing.Size(267, 33);
            this.cboKH.TabIndex = 2;
            this.cboKH.SelectedIndexChanged += new System.EventHandler(this.cboNhaHang_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "Khách hàng";
            // 
            // grKM
            // 
            this.grKM.Controls.Add(this.label10);
            this.grKM.Controls.Add(this.cboKM);
            this.grKM.Controls.Add(this.label9);
            this.grKM.Location = new System.Drawing.Point(462, 504);
            this.grKM.Name = "grKM";
            this.grKM.Size = new System.Drawing.Size(417, 136);
            this.grKM.TabIndex = 7;
            this.grKM.TabStop = false;
            this.grKM.Text = "Khuyến mãi";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 25);
            this.label10.TabIndex = 3;
            this.label10.Text = "Ngày hiệu lực";
            // 
            // cboKM
            // 
            this.cboKM.FormattingEnabled = true;
            this.cboKM.Location = new System.Drawing.Point(131, 41);
            this.cboKM.Name = "cboKM";
            this.cboKM.Size = new System.Drawing.Size(267, 33);
            this.cboKM.TabIndex = 2;
            this.cboKM.SelectedIndexChanged += new System.EventHandler(this.cboKM_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 25);
            this.label9.TabIndex = 2;
            this.label9.Text = "Giảm (%)";
            // 
            // grTien
            // 
            this.grTien.Controls.Add(this.textBox3);
            this.grTien.Controls.Add(this.textBox2);
            this.grTien.Controls.Add(this.textBox1);
            this.grTien.Controls.Add(this.label13);
            this.grTien.Controls.Add(this.label11);
            this.grTien.Controls.Add(this.label12);
            this.grTien.Location = new System.Drawing.Point(11, 574);
            this.grTien.Name = "grTien";
            this.grTien.Size = new System.Drawing.Size(417, 186);
            this.grTien.TabIndex = 8;
            this.grTien.TabStop = false;
            this.grTien.Text = "Tổng Tiền";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(118, 131);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(232, 33);
            this.textBox3.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(232, 33);
            this.textBox2.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(232, 33);
            this.textBox1.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 25);
            this.label13.TabIndex = 4;
            this.label13.Text = "Giảm Giá";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 25);
            this.label11.TabIndex = 3;
            this.label11.Text = "Thêm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "Tổng món";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Pink;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(686, 662);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(125, 58);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDat
            // 
            this.btnDat.BackColor = System.Drawing.Color.Pink;
            this.btnDat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDat.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDat.Image = ((System.Drawing.Image)(resources.GetObject("btnDat.Image")));
            this.btnDat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDat.Location = new System.Drawing.Point(451, 659);
            this.btnDat.Name = "btnDat";
            this.btnDat.Size = new System.Drawing.Size(153, 58);
            this.btnDat.TabIndex = 9;
            this.btnDat.Text = "Đặt Hàng";
            this.btnDat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDat.UseVisualStyleBackColor = false;
            this.btnDat.Click += new System.EventHandler(this.btnDat_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNew.Image = global::DoAn.Properties.Resources.loop;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(209, 124);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(166, 54);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Làm mới";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnXoa.Image = global::DoAn.Properties.Resources.delete;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(27, 124);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(153, 54);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa Item";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dtDS
            // 
            this.dtDS.AllowUserToAddRows = false;
            this.dtDS.AllowUserToDeleteRows = false;
            this.dtDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDS.Location = new System.Drawing.Point(11, 32);
            this.dtDS.Name = "dtDS";
            this.dtDS.ReadOnly = true;
            this.dtDS.RowHeadersWidth = 62;
            this.dtDS.RowTemplate.Height = 28;
            this.dtDS.Size = new System.Drawing.Size(371, 86);
            this.dtDS.TabIndex = 1;
            this.dtDS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDS_CellClick);
            this.dtDS.DoubleClick += new System.EventHandler(this.dtDS_DoubleClick);
            // 
            // FormDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 819);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDat);
            this.Controls.Add(this.grTien);
            this.Controls.Add(this.grKM);
            this.Controls.Add(this.grKH);
            this.Controls.Add(this.grChitietmon);
            this.Controls.Add(this.grGioHang);
            this.Controls.Add(this.grDS);
            this.Controls.Add(this.grDMMA);
            this.Controls.Add(this.grChonNH);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDatHang";
            this.Text = "FormDatHang";
            this.grChonNH.ResumeLayout(false);
            this.grChonNH.PerformLayout();
            this.grDMMA.ResumeLayout(false);
            this.grDMMA.PerformLayout();
            this.grDS.ResumeLayout(false);
            this.grGioHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGH)).EndInit();
            this.grChitietmon.ResumeLayout(false);
            this.grChitietmon.PerformLayout();
            this.grKH.ResumeLayout(false);
            this.grKH.PerformLayout();
            this.grKM.ResumeLayout(false);
            this.grKM.PerformLayout();
            this.grTien.ResumeLayout(false);
            this.grTien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grChonNH;
        private System.Windows.Forms.ComboBox cboNhaHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grDMMA;
        private System.Windows.Forms.ComboBox cboMonAn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grDS;
        private System.Windows.Forms.GroupBox grGioHang;
        private System.Windows.Forms.DataGridView dtGH;
        private System.Windows.Forms.GroupBox grChitietmon;
        private System.Windows.Forms.TextBox txtGC;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox grKH;
        private System.Windows.Forms.ComboBox cboKH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grKM;
        private System.Windows.Forms.ComboBox cboKM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grTien;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dtDS;
    }
}