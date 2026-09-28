using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class TK_KhachHang
    {
        private string khachHangId;
        private string khachHangName;
        private string diaChi;
        private string email;
        private string sdt;
        private string matKhau;
        private DateTime createAt;
        private string roleId;

        public TK_KhachHang()
        {
        }

        public TK_KhachHang(string khachHangId, string khachHangName, string diaChi, string email, string sdt, string matKhau, DateTime createAt, string roleId)
        {
            this.khachHangId = khachHangId;
            this.khachHangName = khachHangName;
            this.diaChi = diaChi;
            this.email = email;
            this.sdt = sdt;
            this.matKhau = matKhau;
            this.createAt = createAt;
            this.roleId = roleId;
        }
        public string KhachHangId
        {
            get { return khachHangId; }
            set { khachHangId = value; }
        }
        public string KhachHangName
        {
            get { return khachHangName; }
            set { khachHangName = value; }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
        public DateTime CreateAt
        {
            get { return createAt; }
            set { createAt = value; }
        }
        public string RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
    }
}
