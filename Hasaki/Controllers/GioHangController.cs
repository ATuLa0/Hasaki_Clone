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
            ViewBag.TongSL = TongSL();
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

        public ActionResult ThemVaoGioHang(int id)
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
                sp.SoLuong++;
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

    }
}