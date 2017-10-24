using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        dbQLBanLaptopDataContext data = new dbQLBanLaptopDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                Admin ad = data.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }

        public ActionResult SanPham()
        {
            return View(data.DanhMucs.ToList());
        }

        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Them(DanhMuc danhMuc)
        {
            data.DanhMucs.InsertOnSubmit(danhMuc);
            data.SubmitChanges();
            return RedirectToAction("SanPham");
        }

        public ActionResult ChiTiet(int id)
        {
            DanhMuc danhMuc = data.DanhMucs.SingleOrDefault(n => n.ID == id);
            ViewBag.id = danhMuc.ID;
            if(danhMuc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(danhMuc);
        }

        public ActionResult Xoa(int id)
        {
            DanhMuc danhMuc = data.DanhMucs.SingleOrDefault(n => n.ID == id);
            ViewBag.ID = danhMuc.ID;
            if(danhMuc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(danhMuc);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult Xacnhanxoa(int id)
        {
            DanhMuc danhMuc = data.DanhMucs.SingleOrDefault(n => n.ID == id);
            ViewBag.ID = danhMuc.ID;
            if(danhMuc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.DanhMucs.DeleteOnSubmit(danhMuc);
            data.SubmitChanges();
            return RedirectToAction("SanPham");
        }

        [HttpGet]
        public ActionResult Sua(int id)
        {
            DanhMuc danhMuc = data.DanhMucs.SingleOrDefault(n => n.ID == id);
            if(danhMuc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(danhMuc);
        }

        [HttpPost, ActionName("Sua")]
        public ActionResult Xacnhansua(int id)
        {
            DanhMuc danhMuc = data.DanhMucs.SingleOrDefault(n => n.ID == id);
            ViewBag.ID = danhMuc.ID;
            if (danhMuc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            UpdateModel(danhMuc);
            data.SubmitChanges();
            return RedirectToAction("SanPham");
        }
    }
}