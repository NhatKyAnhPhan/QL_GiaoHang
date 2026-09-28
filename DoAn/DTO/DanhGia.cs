using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class DanhGia
    {
        private string danhGiaId;
        private string donHangId;
        private float rating;
        private string noiDung;
        private DateTime ngayDG;

        public DanhGia() { }
        public DanhGia(string danhGiaId, string donHangId, float rating, string noiDung, DateTime ngayDG)
        {
            this.danhGiaId = danhGiaId;
            this.donHangId = donHangId;
            this.rating = rating;
            this.noiDung = noiDung;
            this.ngayDG = ngayDG;
        }
        
        public string DanhGiaId
        {
            get { return danhGiaId; }
            set {  danhGiaId = value; }
        }
        public string DonHangId
        {
            get { return donHangId; }
            set { donHangId = value; }
        }
        public float Rating
        { get { return rating; } set {  rating = value; } }
        public string NoiDung
        {
            get { return noiDung; }
            set { noiDung = value; }
        }
        public DateTime NgayDG
        {
            get { return ngayDG; }
            set { ngayDG = value; }
        }
    }
}
