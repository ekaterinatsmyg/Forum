using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Forum.Models;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using Forum.Providers;
using Forum.Mappers;

namespace Forum.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationViewModel model)
        {
            model.DateAdded = DateTime.Now;
            var anyUser = service.GetAllUserEntities().Any(user => user.Email.Contains(model.Email));
            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                var membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(model.ToBllUser());

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(model);
            
        }

        [AllowAnonymous]
        public ActionResult Login(string url)
        {
            var type = HttpContext.User.GetType();
            var iden = HttpContext.User.Identity.GetType();
            ViewBag.Url = url;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(SignInViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Login, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Login, viewModel.RememberMe);

                    return new JsonResult()
                    {
                        Data = new
                        {
                            isValid = true
                        }
                    };
                }
                else
                {
                    return new JsonResult()
                        {
                            Data = new
                            {
                                 isValid = false ,
                            errorMessage = "Неверный логин или пароль"
                            }
                           
                        };
                }

            }
            return Json(new
            {                
                isValid = false ,
                errorMessage = "хуй"
            }
            );
        }
        
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult BlockUser()
        {
            UserBlockViewModel model = new UserBlockViewModel()
            {
                UserBlockId = 0,
                Users = service.GetAllSimpleUsers()
            };

            return PartialView("_BlockedUser", model);
        }

        [HttpPost]
        public ActionResult BlockUser(UserBlockViewModel model)
        {
            service.BlockUser(model.UserBlockId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult UnBlockUser()
        {
            UserBlockViewModel model = new UserBlockViewModel()
            {
                UserBlockId = 0,
                Users = service.GetBlockedUsers()
            };

            return PartialView("_UnBlockedUser", model);
        }

        [HttpPost]
        public ActionResult UnBlockUser(UserBlockViewModel model)
        {
            service.UnBlockUser(model.UserBlockId);
            return RedirectToAction("Index", "Home");
        }
       
        [HttpGet]
        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult GetSender (int senderId)
        {
            var user = service.GetUserEntityById(senderId);
            return PartialView("_Sender", user.ToModelUser());
        }
    }
}
