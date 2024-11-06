using Project_63134295.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63134295.Controllers
{
    public class Cart_63134295Controller : Controller
    {
        // GET: Cart_63134277
        Project_63134295Entities db = new Project_63134295Entities();

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ActionResult AddToCart(int id)
        {
            var sachs = db.GoiTaps.SingleOrDefault(s => s.MaGoi == id.ToString());
            if (sachs != null)
            {
                GetCart().Add(sachs);
            }
            return RedirectToAction("ShowToCart", "Cart_63134295");
        }

        public ActionResult ThanhToan()
        {
            return View();
        }

        public ActionResult Show()
        {
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult CheckOut(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart != null && cart.Items != null)
            {
                DonHang dh = new DonHang();
                dh.ngaydat = DateTime.Now;
                dh.TenKH = form["Ten_KH"];
                dh.diachi = form["diachi"];
                dh.ghichu = form["ghichu"];
                dh.email = form["email"];
                db.DonHangs.Add(dh);
                db.SaveChanges();

                foreach (var item in cart.Items)
                {
                    if (item._goitap != null && item._goitap_soluong != 0)
                    {
                        ChiTietDonHang ct = new ChiTietDonHang();
                        ct.MaDH = dh.MaDH;
                        ct.MaGoi = item._goitap.MaGoi;
                        ct.tong = (int?)item._goitap.Gia;
                        ct.soluong = item._goitap_soluong;
                        db.ChiTietDonHangs.Add(ct);
                    }
                    else
                    {
                        // Xử lý lỗi hoặc chuyển hướng đến trang thông báo lỗi
                        return Content("Thanh toán không thành công");
                    }
                }

                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("ThanhCong", "Cart_63134295");
            }
            else
            {
                // Xử lý lỗi hoặc chuyển hướng đến trang thông báo lỗi
                return Content("Thanh toán không thành công");
            }
        }

        public ActionResult ThanhCong()
        {
            return View();
        }

        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("ShowToCart", "Cart_63134295");
            }

            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult Update(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int MaGoi = int.Parse(form["MaGoi"]);
            int soluong = int.Parse(form["SL"]);
            cart.Update_Soluong(MaGoi, soluong);
            return RedirectToAction("ShowToCart", "Cart_63134295");
        }

        public ActionResult Remove_Cart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove(id);
            return RedirectToAction("ShowToCart", "Cart_63134295");
        }

        public PartialViewResult Bag()
        {
            int total = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                total = cart.Tong_SL();
                ViewBag.sl_cart = total;
                return PartialView("Bag");
            }
            return PartialView();
        }
    }
}