using Project_63134295.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63134295.Controllers
{
    public class Account_63134295Controller : Controller
    {
        // GET: Account_63134295
        Project_63134295Entities db = new Project_63134295Entities();
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());

        }
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult Signout()
        {
            Session.Clear();
            return RedirectToAction("Index", "TrangChu_63134295");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account account)
        {
            var checkLogin = db.Accounts.Where(x => x.Email.Equals(account.Email) && x.MK.Equals(account.MK)).FirstOrDefault();
            if (checkLogin != null)
            {
                Account acc = db.Accounts.FirstOrDefault(x => x.Email.Equals(account.Email) && x.MK.Equals(account.MK));
                Session["Email"] = account.Email.ToString();
                Session["TenHienThi"] = acc.TenHienThi.ToString();
                if (acc.RoleID == 1)
                {
                    return RedirectToAction("Index", "NhanViens_63134295");
                }
                else
                {
                    return RedirectToAction("Index", "TrangChu_63134295");
                }
            }
            else
            {
                ViewBag.Notification = "Wrong Username or password";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Account account)
        {
            if (db.Accounts.Any(x => x.Email == account.Email))
            {
                ViewBag.Notification = "This account has already existed";
                return View();
            }
            else
            {
                account.RoleID = 0;
                account.CreateDate = DateTime.Now;
                if (account.MK != account.RePass)
                {
                    ViewBag.Notification = "Mat khau khong khop, vui long nhap lai";
                    return View();
                }
                db.Accounts.Add(account);
                db.SaveChanges();

                Session["Email"] = account.Email.ToString();
                Session["TenHienThi"] = account.TenHienThi.ToString();
                return RedirectToAction("Index", "TrangChu_63134295");
            }
        }
        private bool CheckPermission()
        {
            if (Session["Email"] != null)
            {
                int roleId = Convert.ToInt32(Session["RoleID"]);
                if (roleId == 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}