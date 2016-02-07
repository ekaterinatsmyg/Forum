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
    public class SearchController : Controller
    {
        private readonly IThemeService service;

        public SearchController(IThemeService service)
        {
            this.service = service;
        }

        [ChildActionOnly]
        public ActionResult Index()
        {
            return View("~/Views/shared/_Search.cshtml");
        }    
        
        [HttpPost]
        public ActionResult Search(SearchViewModel model)
        {
            IEnumerable<ThemeViewModel> result = service.SearchThemes(model.SearchString).Select(theme => theme.ToModelTheme());            
            return View(result);
        }


    }
}
