using DataAccess.Entity;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class RaporController : Controller
    {
        // GET: Admin/Rapor

        OrderDetailService orderDetailService = new OrderDetailService();
        OrderService orderService = new OrderService();
        AppUserService userService = new AppUserService();
        public ActionResult Index()
        {
            List<OrderDetail> orderDetailList = orderDetailService.GetList();
            List<Order> orderList = orderService.GetList();
            List<AppUser> userList = userService.GetList();

            //toplam gelir
            decimal totalPrice = (decimal)orderDetailList.Sum(x => x.SubTotal);
            ViewBag.TotalPrice = totalPrice;


            //toplam sipariş
            int totalOrderCount = orderList.Count();
            ViewBag.TotalOrderCount = totalOrderCount;

            // toplam kullanıcı
            int totalUserCount = userList.Count();
            ViewBag.TotalUserCount = totalUserCount;

            // en çok satışı yapılan ürün
            MostSalesProduct mostSalesProduct = orderDetailService.GetMostSalesProduct();
            ViewBag.MostSalesProduct = mostSalesProduct;


            return View();
        }
    }
}