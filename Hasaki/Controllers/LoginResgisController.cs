using Hasaki.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
                        Session["TaiKhoan"] = khach;
                    }
                    else
                    {
                        var mail = db.KhachHangs.FirstOrDefault(k => k.Email == kh.Email);
                        if (mail != null)
                        {
                        ModelState.AddModelError(string.Empty, "Sai mật khẩu");
                        return View();
                        }
                        ModelState.AddModelError(string.Empty, "Tài khoản không tồn tại");
                        return View();
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Regis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Regis(string email, string matkhau1, string matkhau2)
        {
            var db = new HasakiDatabaseEntities();
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(email))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(matkhau1))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(matkhau2))
                    ModelState.AddModelError(string.Empty, "Nhập lại mật khẩu");
                if (matkhau1 != matkhau2)
                    ModelState.AddModelError(string.Empty, "Mật khẩu không khớp");
                if (ModelState.IsValid)
                {
                    var sha256 = SHA256.Create();
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(matkhau1));

                    var sb = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        sb.Append(bytes[i].ToString("x2"));
                    }
                    string matkhau = sb.ToString();
                    var khach = db.KhachHangs.FirstOrDefault(k => k.Email == email);
                    if (khach != null)
                    {
                        ModelState.AddModelError(string.Empty, "Tài khoản đã tồn tại");
                    }
                    else if (khach == null)
                    {
                        KhachHang khachhang = new KhachHang();
                        khachhang.Email = email;
                        khachhang.MatKhau = sb.ToString();
                        db.KhachHangs.Add(khachhang);
                        db.SaveChanges();
                        // Gửi email đăng ký thành công
                        ViewBag.ThongBao = "Đăng ký thành công";
                    }
                    else
                        ViewBag.ThongBao = "Lỗi";
                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}