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
    public class SectionController : Controller
    {
         private readonly ISectionService service;

        public SectionController(ISectionService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddSection()
        {
            return View("~/Views/Section/_AddSection.cshtml");
        }

        [HttpPost]
        public ActionResult AddSection(SectionViewModel model)
        {
            model.DateAdded = DateTime.Now;
            service.CreateSection(model.ToBllSection());
            return RedirectToAction("Index", "Home");

        }

        [ChildActionOnly]
        public ActionResult AllSections()
        {
            var sections = service.GetAllSectionEntities().Select(section => section.ToModelSection());
            return PartialView("_AllSections",sections);
        }

    }
}
