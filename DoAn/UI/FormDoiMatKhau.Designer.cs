namespace DoAn.UI
{
    partial class FormDoiMatKhau
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoiMatKhau));
            this.txt_ReMKMoi = new System.Windows.Forms.TextBox();
            this.txt_MKMoi = new System.Windows.Forms.TextBox();
            this.txt_MKCu = new System.Windows.Forms.TextBox();
            this.txt_TaiKhoan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btnDoi = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_ReMKMoi
            // 
            this.txt_ReMKMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_ReMKMoi.Location = new System.Drawing.Point(312, 255);
            this.txt_ReMKMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ReMKMoi.Name = "txt_ReMKMoi";
            this.txt_ReMKMoi.Size = new System.Drawing.Size(307, 35);
            this.txt_ReMKMoi.TabIndex = 3;
            this.txt_ReMKMoi.UseSystemPasswordChar = true;
            // 
            // txt_MKMoi
            // 
            this.txt_MKMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_MKMoi.Location = new System.Drawing.Point(312, 201);
            this.txt_MKMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MKMoi.Name = "txt_MKMoi";
            this.txt_MKMoi.Size = new System.Drawing.Size(307, 35);
            this.txt_MKMoi.TabIndex = 2;
            this.txt_MKMoi.UseSystemPasswordChar = true;
            // txt_MKCu
            // 
            this.txt_MKCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_MKCu.Location = new System.Drawing.Point(312, 140);
            this.txt_MKCu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MKCu.Name = "txt_MKCu";
            this.txt_MKCu.Size = new System.Drawing.Size(307, 35);
            this.txt_MKCu.TabIndex = 1;
            this.txt_MKCu.UseSystemPasswordChar = true;
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TaiKhoan.Location = new System.Drawing.Point(312, 75);
            this.txt_TaiKhoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.ReadOnly = true;
            this.txt_TaiKhoan.Size = new System.Drawing.Size(307, 35);
            this.txt_TaiKhoan.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(40, 258);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 29);
            this.label4.TabIndex = 85;
            this.label4.Text = "Nhập lại mật khẩu mới:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(40, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 29);
            this.label3.TabIndex = 84;
            this.label3.Text = "Mật khẩu mới:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(40, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 29);
            this.label1.TabIndex = 83;
            this.label1.Text = "Mật khẩu cũ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(40, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 29);
            this.label6.TabIndex = 82;
            this.label6.Text = "Tên đăng nhập:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(204, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 37);
            this.label5.TabIndex = 81;
            this.label5.Text = "ĐỔI MẬT KHẨU";
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Thoat.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thoat.Image")));
            this.btn_Thoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Thoat.Location = new System.Drawing.Point(446, 329);
            this.btn_Thoat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Padding = new System.Windows.Forms.Padding(5);
            this.btn_Thoat.Size = new System.Drawing.Size(173, 65);
            this.btn_Thoat.TabIndex = 6;
            this.btn_Thoat.Text = " THOÁT  ";
            this.btn_Thoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btnDoi
            // 
            this.btnDoi.BackColor = System.Drawing.Color.LightGreen;
            this.btnDoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDoi.Image = ((System.Drawing.Image)(resources.GetObject("btnDoi.Image")));
            this.btnDoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoi.Location = new System.Drawing.Point(234, 329);
            this.btnDoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(198, 65);
            this.btnDoi.TabIndex = 5;
            this.btnDoi.Text = "XÁC NHẬN ";
            this.btnDoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDoi.UseVisualStyleBackColor = false;
            this.btnDoi.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(668, 420);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btnDoi);
            this.Controls.Add(this.txt_ReMKMoi);
            this.Controls.Add(this.txt_MKMoi);
            this.Controls.Add(this.txt_MKCu);
            this.Controls.Add(this.txt_TaiKhoan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormDoiMatKhau";
            this.Text = "frmDoiMatKhau";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDoiMatKhau_FormClosing);
            this.Load += new System.EventHandler(this.FormDoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btnDoi;
        private System.Windows.Forms.TextBox txt_ReMKMoi;
        private System.Windows.Forms.TextBox txt_MKMoi;
        private System.Windows.Forms.TextBox txt_MKCu;
        private System.Windows.Forms.TextBox txt_TaiKhoan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}