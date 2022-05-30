using DataAccess.Entity;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin, moderator")]
    public class SubCategoryController : Controller
    {
        SubCategoryService subCategoryService = new SubCategoryService();
        CategoryService categoryService = new CategoryService();
        public ActionResult Index()
        {
            return View(subCategoryService.GetList());
        }

        public ActionResult Create()
        {
            ViewBag.Categories = categoryService.GetDefault(x => x.Status == Core.Enums.Status.Active).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SubCategory subCategory)
        {
            try
            {
                var result = subCategoryService.Add(subCategory);
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
                string result = subCategoryService.Delete(id);
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
            ViewBag.Categories = categoryService.GetDefault(x => x.Status == Core.Enums.Status.Active).ToList();
            SubCategory updated = subCategoryService.GetById(id);
            return View(updated);
        }
        [HttpPost]
        public ActionResult Update(SubCategory updated)
        {
            try
            {
                string result = subCategoryService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

    }
}