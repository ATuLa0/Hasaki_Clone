using Hasaki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Hasaki.Controllers
{
    public class HomeController : Controller
    {
        HasakiDatabaseEntities db = new HasakiDatabaseEntities();
        private List<SanPham> SanPhamMoi(int soluong)
        {
            return db.SanPhams.OrderByDescending(sp => sp.SanPhamID).Take(soluong).ToList();
        }
        public ActionResult Search(string SearchString = "")
        {
            if (SearchString != "")
            {
                var sp = db.SanPhams.Where(x => x.TenSanPham.ToUpper().Contains(SearchString.ToUpper()));
                return View(sp.ToList());
            }
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var products = SanPhamMoi(4);
            return View(products);
        }
        public ActionResult DanhMucPartial()
        {
            var dsDanhMuc = db.DanhMucSanPhams.ToList();
            return PartialView(dsDanhMuc);
        }
        public ActionResult SPTheoDanhMuc(int id)
        {
            var sps = db.SanPhams.Where(sp => sp.DanhMucSanPhams.Any(dm => dm.DanhMucSanPhamID == id)).ToList();
            return View("Index",sps);
        }
        public ActionResult ChiTietSP(int id)
        {
            var sps = db.SanPhams.FirstOrDefault(sp => sp.SanPhamID == id);
            return View(sps);
        }
    }
}