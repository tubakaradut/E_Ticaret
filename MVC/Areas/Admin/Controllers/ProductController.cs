using DataAccess.Entity;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        SubCategoryService subCategoryService = new SubCategoryService();
        SupplierService supplierService = new SupplierService();

        public ActionResult Index()
        {
            return View(productService.GetList());
        }

        public ActionResult Create()
        {
            ViewBag.SubCategories = subCategoryService.GetDefault(x => x.Status == Core.Enums.Status.Active).ToList();
            ViewBag.Suppliers = supplierService.GetDefault(x => x.Status == Core.Enums.Status.Active).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase fileImage)
        {
            try
            {
                //product.ProductImagePath = ImageUploader.UploadImage("~/Content/image/product/", fileImage);
                var result = productService.Add(product);
                TempData["info"] = result;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        public ActionResult Update(Guid id)
        {
            try
            {
                ViewBag.SubCategories = subCategoryService.GetDefault(x => x.Status == Core.Enums.Status.Active).ToList();
                ViewBag.Suppliers = supplierService.GetDefault(x => x.Status == Core.Enums.Status.Active).ToList();
                Product product = productService.GetById(id);
                return View(product);

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
          

        }
        [HttpPost]
        public ActionResult Update(Product updated)
        {
            try
            {
                string result = productService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                string result = productService.Delete(id);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }
    }
}