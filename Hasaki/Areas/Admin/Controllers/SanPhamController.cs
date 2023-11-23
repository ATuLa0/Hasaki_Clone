using Hasaki.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hasaki.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        HasakiDatabaseEntities db = new HasakiDatabaseEntities();
        // GET: Admin/SanPham
        public ActionResult DanhSachSP()
        {
            var dssp = db.SanPhams.ToList();
            return View(dssp);
        }
        [HttpGet]
        public ActionResult ThemSP()
        {
            ViewBag.ThuongHieuID = new SelectList(db.ThuongHieux, "ThuongHieuID", "TenThuongHieu");
            return View();
        }
        [HttpPost]
        public ActionResult ThemSP(SanPham sp)
        {
            if (!ModelState.IsValid)
            {
                return View(sp);
            }

            db.SanPhams.Add(sp);
            db.SaveChanges();

            return RedirectToAction("DanhSachSP");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var product = db.SanPhams.Find(id);
                db.SanPhams.Remove(product);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("DanhSachSP");
            }

            return RedirectToAction("DanhSachSP");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPhams.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.ThuongHieuID = new SelectList(db.ThuongHieux, "ThuongHieuID", "TenThuongHieu");
            var product = db.SanPhams.Find(id);
            if (product == null)
            {
                // Xử lý trường hợp không tìm thấy sản phẩm
                return HttpNotFound();
            }

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachSP");
            }
            return View(sanPham);
        }
    }
}