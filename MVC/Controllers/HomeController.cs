using Common;
using DataAccess.Entity;
using MVC.Models;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    //[AuthFiter]
    public class HomeController : Controller
    {
        ProductService productService = new ProductService();
        OrderService orderService = new OrderService();
        OrderDetailService orderDetailService = new OrderDetailService();

        public ActionResult Index()
        {
            return View(productService.GetDefault(x => x.UnitsInStock > 0).ToList());
        }
        public ActionResult AddToCart(Guid id)
        {
            try
            {
                Product product = productService.GetById(id);
                Cart cart = null;

                if (Session["kcart"] == null)
                {
                    cart = new Cart();
                }
                else
                {
                    cart = Session["kcart"] as Cart;
                }

                CartItem ci = new CartItem();
                ci.Id = product.ID;
                ci.ProductName = product.ProductName;
                ci.Price = product.UnitPrice;
                cart.AddItem(ci);
                Session["kcart"] = cart;

                return RedirectToAction("index");

            }
            catch (Exception)
            {
                TempData["error"] = $"{id} karşılık gelen ürün bulunamadı";
            }

            return View();
        }
        public ActionResult MyCart()
        {
            if (Session["kcart"] != null)
            {
                return View();
            }
            else
            {
                TempData["error"] = "sepetinizde ürün bulunmamaktadır!";
                return RedirectToAction("Index");
            }
        }
        public ActionResult DeleteCartItem(Guid id)
        {
            Cart cart = Session["kcart"] as Cart;

            if (cart != null)
            {
                cart.DeleteItem(id);
            }

            return RedirectToAction("MyCart");
        }

        public ActionResult CompleteCart()
        {
            Cart cart = Session["kcart"] as Cart;
            AppUser user = Session["user"] as AppUser;
            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (cart != null)
            {
                string productList = "";

                #region Order and Order Detail add

                Order order = new Order();
                order.AppUserID = user.ID;
                Order result = orderService.Add(order);


                #endregion

                foreach (var item in cart.mycart)
                {
                    #region Order Detail Add

                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = result.ID;
                    orderDetail.ProductId = item.Id;
                    orderDetail.UnitPrice = (decimal)item.Price;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.Discount = 0;
                    orderDetail.SubTotal = (decimal)item.SubTotal;

                    orderDetailService.Add(orderDetail);

                    #endregion

                    Product product = productService.GetById(item.Id);
                    product.UnitsInStock -= Convert.ToInt16(item.Quantity);

                    productList += $" {item.ProductName} - {item.Price} - {item.SubTotal}";
                }

                Random rnd = new Random();
                ViewBag.OrderNumber = rnd.Next(1, 1000);


                #region Send Mail

                string content = $"Alışveriş Listeniz; Sipariş Numaranız: {ViewBag.OrderNumber} , ürünleriniz:  {productList}";
                MailSender.SendEmail(user.Email, "Sipariş Maili", content);

                #endregion

                Session.Remove("kcart");

                orderDetailList = orderDetailService.GetDefault(x => x.OrderId == result.ID);
            }


            return View(orderDetailList);
        }

        public ActionResult Exit()
        {
            Session.Remove("user");
            return RedirectToAction("index");
        }

    }
}