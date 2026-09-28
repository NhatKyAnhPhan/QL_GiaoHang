using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class ChiTietDonHang
    {
        private string donHangId;
        private string monAnId;
        private int soLuong;
        private long donGia;
        private string ghiChu;

        public ChiTietDonHang() { }
        public ChiTietDonHang(string donHangId, string monAnId, int soLuong, long donGia, string ghiChu)
        {
            this.donHangId = donHangId;
            this.monAnId = monAnId;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.ghiChu = ghiChu;
        }
        public string DonHangId { get {  return donHangId; } set { donHangId = value; } }
        public string MonAnId { get { return monAnId; } set { monAnId = value; } }
        public int SoLuong { get {  return soLuong; } set {  soLuong = value; } }
        public long DonGia { get {  return donGia; } set { donGia = value; } }
        public string GhiChu { get {  return ghiChu; } set {  ghiChu = value; } }
    }
}
