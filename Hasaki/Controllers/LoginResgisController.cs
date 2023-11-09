using Hasaki.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Hasaki.Controllers
{
    public class LoginResgisController : Controller
    {
        // GET: LoginResgis
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(KhachHang kh)
        {
            var db = new HasakiDatabaseEntities();
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.Email))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(kh.MatKhau))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if(ModelState.IsValid)
                {
                    var sha256 = SHA256.Create();
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(kh.MatKhau));

                    var sb = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        sb.Append(bytes[i].ToString("x2"));
                    }
                    string matkhau = sb.ToString();
                    var khach = db.KhachHangs.FirstOrDefault(k => k.Email == kh.Email && k.MatKhau.ToLower() == matkhau.ToString());
                    if (khach != null)
                    {
                        ViewBag.ThongBao = "Đăng nhập thành công";
                        Session["TaiKhoan"] = khach;
                    }
                    else
                        ViewBag.ThongBao = "Lỗi";
                }
            }
            return View();
        }
    }
}