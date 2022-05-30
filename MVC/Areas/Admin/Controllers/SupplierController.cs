using DataAccess.Entity;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin,moderator")]
    public class SupplierController : Controller
    {
        SupplierService supplierService = new SupplierService();
        public ActionResult Index()
        {
            return View(supplierService.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Supplier supplier)
        {
            try
            {
                var result = supplierService.Add(supplier);
                TempData["info"] = result;
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }

        }
        public ActionResult Delete(Guid id)
        {
            try
            {
                var result = supplierService.Delete(id);
                TempData["info"] = result;
                return RedirectToAction("index");
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
                Supplier updated = supplierService.GetById(id);

                return View(updated);

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Update(Supplier updated)
        {
            try
            {
                string result = supplierService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }
    }
}