using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class DonHang
    {
        private string donHangId;
        private DateTime ngayTao;
        private long phiGiao;
        private long tongTien;
        private string trangThai;
        private string khachHangId;
        private string nhaHangId;
        private string khuyenMaiId;

        public DonHang() { }
        public DonHang(string donHangId, DateTime ngayTao, long phiGiao, long tongTien, string trangThai, string khachHangId, string nhaHangId, string khuyenMaiId)
        {
            this.donHangId = donHangId;
            this.ngayTao = ngayTao;
            this.phiGiao = phiGiao;
            this.tongTien = tongTien;
            this.trangThai = trangThai;
            this.khachHangId = khachHangId;
            this.nhaHangId = nhaHangId;
            this.khuyenMaiId = khuyenMaiId;
        }

        public string DonHangId
        {
            get { return donHangId; }
            set { donHangId = value; }
        }
        public DateTime NgayTao
        {
            get { return ngayTao; }
            set { ngayTao = value; }
        }
        public long PhiGiao
        {
            get { return phiGiao; }
            set { phiGiao = value; }
        }
        public long TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
        public string KhachHangId
        {
            get { return khachHangId; }
            set { khachHangId = value; }
        }
        public string NhaHangId
        {
            get { return nhaHangId; }
            set { nhaHangId = value; }
        }
        public string KhuyenMaiId
        {
            get { return khuyenMaiId; }
            set { khuyenMaiId = value; }
        }

    }
}
