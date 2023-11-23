using Hasaki.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Hasaki.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        HasakiDatabaseEntities db = new HasakiDatabaseEntities();
        // GET: Admin/DanhMuc
        public ActionResult DanhSachDM()
        {
            var cate = db.DanhMucSanPhams.ToList();
            return View(cate);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DanhMucSanPham cate)
        {
            if (!ModelState.IsValid)
            {
                return View(cate);
            }

            db.DanhMucSanPhams.Add(cate);
            db.SaveChanges();

            return RedirectToAction("DanhSachDM");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var cate = db.DanhMucSanPhams.Find(id);
                db.DanhMucSanPhams.Remove(cate);
                db.SaveChanges();
            }
            catch (Exception)
            {
                // Dính liên kết tới các bảng khác sẽ reload lại trang không thực hiện tác vụ
                return RedirectToAction("DanhSachDM");
            }

            return RedirectToAction("DanhSachDM");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSanPham cate = db.DanhMucSanPhams.Find(id);
            if (cate == null)
            {
                return HttpNotFound();
            }
            return View(cate);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cate = db.DanhMucSanPhams.Find(id);
            if (cate == null)
            {
                // Xử lý trường hợp không tìm thấy sản phẩm
                return HttpNotFound();
            }

            return View(cate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMucSanPham cate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachDM");
            }
            return View(cate);
        }
    }
}