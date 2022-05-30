using Common;
using DataAccess.Entity;
using MVC.ViewModels;
using Service.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        AppUserService appUserService = new AppUserService();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {

                AppUser appUser = appUserService.GetDefault(x => x.Username == loginVM.Username && x.Password == loginVM.Password && x.IsActive).FirstOrDefault();

                if (loginVM != null)
                {
                    FormsAuthentication.SetAuthCookie(appUser.Username, true);
                    Session["user"] = appUser;
                    return RedirectToAction("index", "Home");
                }

                else
                {
                    TempData["error"] = "Kullanıcı Bilgileri Hatalı veya Hesabınızı Aktive Değil!";
                    return View(loginVM);
                }
            }
            else
            {
                return View(loginVM);
            }
        }

        public ActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeOl(AppUserVM appUserVM)
        {
            if (ModelState.IsValid)
            {
                AppUser getAppUser = appUserService.GetDefault(x => x.Email == appUserVM.Email && x.IsActive).FirstOrDefault();

                if (getAppUser != null)
                {
                    TempData["error"] = "Aynı mail adresine ait başka bir kayıt bulunmaktadır!";
                    return View(appUserVM);
                }


                AppUser appUser = new AppUser();
                appUser.Email = appUserVM.Email;
                appUser.Password = appUserVM.Password;
                appUser.Username = appUserVM.Username;
                appUser.Firstname = appUserVM.Firstname;
                appUser.Lastname = appUserVM.Lastname;



                appUser.ActivationCode = Guid.NewGuid();
                var result = appUserService.Add(appUser);

                TempData["info"] = result;

                //Mailsender
                MailSender.SendEmail(appUserVM.Email, "Üyelik Aktivayon", $"üyeliğinizi aktif hale getirebilmek için linki tıklayın https://localhost:44365/Login/Activation/" + appUser.ActivationCode);
                return RedirectToAction("index", "login");
            }
            else
            {
                return View(appUserVM);
            }

        }
        public ActionResult Activation(Guid id)
        {
            if (id != null)
            {
                AppUser user = appUserService.GetDefault(x => x.ActivationCode == id).FirstOrDefault();
                user.IsActive = true;
                appUserService.Update(user);

                Session["user"] = user;

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("UyeOl");
            }

        }
    }
}