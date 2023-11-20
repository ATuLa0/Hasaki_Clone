using Hasaki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hasaki.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            List<GioHang> gioHangs = LayGioHang();
            if(gioHangs == null || gioHangs.Count == 0)
                return RedirectToAction("Index","Home");
            ViewBag.TongSL = TongSL();
            ViewBag.TongTien = TongTien();
            return View(gioHangs);
        }

        public ActionResult TongSLPartial()
        {
            Session["TongSL"] = TongSL();
            return PartialView();
        }

        public List<GioHang> LayGioHang()
        {
            List<GioHang> gioHangs = Session["GioHang"] as List<GioHang>;
            if (gioHangs == null)
            {
                gioHangs = new List<GioHang>();
                Session["GioHang"] = gioHangs;
            }
            return gioHangs;
        }

        public ActionResult ThemVaoGioHang(int id, int Quantity)
        {
            List<GioHang> gioHangs = LayGioHang();
            GioHang sp = gioHangs.FirstOrDefault(s => s.SanPhamID == id);
            if (sp == null)
            {
                sp = new GioHang(id);
                gioHangs.Add(sp);
            }
            else
            {
                sp.SoLuong += Quantity;
            }
            return RedirectToAction("ChiTietSP", "Home", new {id = id});
        }
        
        private int TongSL()
        {
            int TongSL = 0;
            List<GioHang> gioHangs = LayGioHang();
            if (gioHangs != null)
            {
                TongSL = gioHangs.Sum(sp => sp.SoLuong);
            }
            return TongSL;
        }

        public double TongTien()
        {
            double tongTien = 0;
            List<GioHang> gioHangs = LayGioHang();
            if (gioHangs != null)
                tongTien = gioHangs.Sum(s => s.TienHang());
            return tongTien;
        }

        public ActionResult XoaSP(int id)
        {
            List<GioHang> gioHang = LayGioHang();
            var sanpham = gioHang.FirstOrDefault(s => s.SanPhamID == id);
            if (sanpham != null)
            {
                gioHang.RemoveAll(s => s.SanPhamID == id);
                return RedirectToAction("Index");
            }
            if (gioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }
        public ActionResult CapNhatSL(int id, int Quantity)
        {
            List<GioHang> gioHang = LayGioHang();
            var sp = gioHang.FirstOrDefault(s => s.SanPhamID == id);
            if (sp != null)
            {
                sp.SoLuong = Quantity;
            }
            // Lưu lại danh sách giỏ hàng mới vào session
            Session["GioHang"] = gioHang;
            return RedirectToAction("Index");
        }
    }
}