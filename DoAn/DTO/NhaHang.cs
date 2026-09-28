using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class NhaHang
    {
        private string nhaHangId;
        private string nhaHangName;
        private string diaChi;
        private string email;
        private string sdt;
        private TimeSpan gioMo;
        private TimeSpan gioDong;
        private string trangThai;
       
        public NhaHang() { }
        public NhaHang(string nhaHangId, string nhaHangName, string diaChi, string email, string sdt, TimeSpan gioMo, TimeSpan gioDong, string trangThai)
        {
            this.nhaHangId = nhaHangId;
            this.nhaHangName = nhaHangName;
            this.diaChi = diaChi;
            this.email = email;
            this.sdt = sdt;
            this.gioMo = gioMo;
            this.gioDong = gioDong;
            this.trangThai = trangThai;
        }
        public string NhaHangId { get {  return nhaHangId; } set { nhaHangId = value; } }
        public string NhaHangName { get {  return nhaHangName; } set { nhaHangName = value; } }
        public string DiaChi { get {  return diaChi; } set {  diaChi = value; } }
        public string Email { get { return email; } set { email = value; } }    
        public string Sdt { get {  return sdt; } set {  sdt = value; } }
        public TimeSpan GioMo { get {  return gioMo; } set {  gioMo = value; } }
        public TimeSpan GioDong { get { return gioDong; } set { gioDong = value; } }
        public string TrangThai { get { return trangThai; } set { trangThai = value; } }
    }
}
