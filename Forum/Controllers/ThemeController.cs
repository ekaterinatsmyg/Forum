using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Models;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using Forum.Providers;
using Forum.Mappers;

namespace Forum.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IThemeService service;

        public ThemeController(IThemeService service)
        {
            this.service = service;
        }
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult Create(int? sectionId)
        {
            ViewBag.SectionId = sectionId;
            return View("~/Views/Theme/_Create.cshtml");
        }
        [HttpPost]
        public ActionResult Create (ThemeViewModel model, int? sectionId)
        {
            model.DatePublication = DateTime.Now;
            model.CreatorId = Convert.ToInt32(HttpContext.Profile.GetPropertyValue("Id"));
            model.CountViews = 0;            
            service.CreateTheme(model.ToBllTheme());
            var themes = service.GetBySectionId(sectionId.Value).Select(theme => theme.ToModelTheme());
            return PartialView("_ThemeOfSectionTable",themes);
        }

        public ActionResult ThemesOfSection(int? sectionId)
        {
            var themes = service.GetBySectionId(sectionId.Value).Select(theme => theme.ToModelTheme());
            return View(themes);            
        }
        [ChildActionOnly]
        public ActionResult ThemesOfSectionTable(int? sectionId)
        {
            var themes = service.GetBySectionId(sectionId.Value).Select(theme => theme.ToModelTheme());
            return View("_ThemeOfSectionTable",themes);
        }
        [ChildActionOnly]
        public ActionResult ThemeOfSection(int? sectionId)
        {
            var themes = service.GetBySectionId(sectionId.Value).Select(theme => theme.ToModelTheme());
            ViewBag.sectionId = sectionId;
            return PartialView("_ThemeOfSection",themes);
        }

        
        public ActionResult Details(int id)
        {
            ViewBag.CurrentThemeId = id;
            var model = service.GetThemeEntityById(id).ToModelTheme();
            ++model.CountViews;
            service.UpdateTheme(model.ToBllTheme());
            return View(model);
        }

    }
}
