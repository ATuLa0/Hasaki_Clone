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
        public ActionResult Index()
        {
            var products = SanPhamMoi(4);
            return View(products);
        }
    }
}