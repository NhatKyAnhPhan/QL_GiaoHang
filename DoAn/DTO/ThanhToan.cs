using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class ThanhToan
    {
        private string thanhToanId;
        private string donHangId;
        private string phuongThuc;
        private long soTien;
        private DateTime ngayTT;
        private string trangThai;

        public ThanhToan() { }

        public ThanhToan(string thanhToanId, string donHangId, string phuongThuc, long soTien, DateTime ngayTT, string trangThai)
        {
            this.thanhToanId = thanhToanId;
            this.donHangId = donHangId;
            this.phuongThuc = phuongThuc;
            this.soTien = soTien;
            this.ngayTT = ngayTT;
            this.trangThai = trangThai;
        }
        public string ThanhToanId 
        { 
            get {  return thanhToanId; } 
            set { thanhToanId = value;}
        }
        public string DonHangId
        {
            get { return donHangId; }
            set { donHangId = value;}
        }
        public string PhuongThuc
        {
            get { return phuongThuc; }
            set { phuongThuc = value; }
        }
        public long SoTien
        {
            get { return soTien; }
            set { soTien = value; }
        }
        public DateTime NgayTT
        {
            get { return ngayTT; }
            set { ngayTT = value; }
        }
        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
    }
}
