using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        public ActionResult Details(Guid id)
        {
            var product = productService.GetById(id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public PartialViewResult _SampleProducts(Guid id)
        {
            var products = productService.GetDefault(x => x.SubCategoryId == id).Take(3).ToList();
            return PartialView(products);
        }
    }
}