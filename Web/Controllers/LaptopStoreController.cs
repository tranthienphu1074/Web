using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class LaptopStoreController : Controller
    {
        dbQLBanLaptopDataContext data = new dbQLBanLaptopDataContext();
        private List<DanhMuc> Laylaptopmoi(int count)
        {
            return data.DanhMucs.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        // GET: LaptopStore
        public ActionResult Index()
        {
            var laptopmoi = Laylaptopmoi(100);
            return View(laptopmoi);
        }

        public ActionResult ACER()
        {
            string Chuoi = "";
            var product = (from p in data.DanhMucs where p.Hang == "ACER" select p).Take(100).ToList();
            for (int i = 0; i < product.Count; i++)
            {
                Chuoi += "<div class=\"item-pro-home\">";
                Chuoi += "<div class=\"box-img-pro-home\">";
                Chuoi += "<img src = \"" + product[i].Image + "\" />";
                Chuoi += "</div>";
                Chuoi += "<a href=\"#\">" + product[i].TenSanPham + "</a>";
                Chuoi += "<p>Giá: " + product[i].GiaTien + "</p>";
                Chuoi += "</div>";
            }
            ViewBag.ACER = Chuoi;
            return View(product);
        }

        public ActionResult ASUS()
        {
            string Chuoi = "";
            var product = (from p in data.DanhMucs where p.Hang == "ASUS" select p).Take(100).ToList();
            for (int i = 0; i < product.Count; i++)
            {
                Chuoi += "<div class=\"item-pro-home\">";
                Chuoi += "<div class=\"box-img-pro-home\">";
                Chuoi += "<img src = \"" + product[i].Image + "\" />";
                Chuoi += "</div>";
                Chuoi += "<a href=\"#\">" + product[i].TenSanPham + "</a>";
                Chuoi += "<p>Giá: " + product[i].GiaTien + "</p>";
                Chuoi += "</div>";
            }
            ViewBag.ASUS = Chuoi;
            return View(product);
        }

        public ActionResult DELL()
        {
            string Chuoi = "";
            var product = (from p in data.DanhMucs where p.Hang == "DELL" select p).Take(100).ToList();
            for (int i = 0; i < product.Count; i++)
            {
                Chuoi += "<div class=\"item-pro-home\">";
                Chuoi += "<div class=\"box-img-pro-home\">";
                Chuoi += "<img src = \"" + product[i].Image + "\" />";
                Chuoi += "</div>";
                Chuoi += "<a href=\"#\">" + product[i].TenSanPham + "</a>";
                Chuoi += "<p>Giá: " + product[i].GiaTien + "</p>";
                Chuoi += "</div>";
            }
            ViewBag.DELL = Chuoi;
            return View(product);
        }

        public ActionResult MAC()
        {
            string Chuoi = "";
            var product = (from p in data.DanhMucs where p.Hang == "MAC" select p).Take(100).ToList();
            for (int i = 0; i < product.Count; i++)
            {
                Chuoi += "<div class=\"item-pro-home\">";
                Chuoi += "<div class=\"box-img-pro-home\">";
                Chuoi += "<img src = \"" + product[i].Image + "\" />";
                Chuoi += "</div>";
                Chuoi += "<a href=\"#\">" + product[i].TenSanPham + "</a>";
                Chuoi += "<p>Giá: " + product[i].GiaTien + "</p>";
                Chuoi += "</div>";
            }
            ViewBag.MAC = Chuoi;
            return View(product);
        }

        public ActionResult Detail(int id)
        {
            var laptop = from l in data.DanhMucs
                         where l.ID == id
                         select l;
            return View(laptop.Single());
        }
    }
}