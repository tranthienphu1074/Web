using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Giohang
    {
        dbQLBanLaptopDataContext data = new dbQLBanLaptopDataContext();
        public int iMasanpham { set; get; }
        public string iTensanpham { set; get; }
        public string iAnhbia { set; get; }
        public Double iDongia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * iDongia; }
        }

        public Giohang(int Masanpham)
        {
            iMasanpham = Masanpham;
            DanhMuc danhmuc = data.DanhMucs.Single(n => n.ID == iMasanpham);
            iTensanpham = danhmuc.TenSanPham;
            iAnhbia = danhmuc.Image;
            iDongia = double.Parse(danhmuc.GiaTien.ToString());
            iSoluong = 1;
        }
    }
}