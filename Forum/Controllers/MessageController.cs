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

    public class MessageController : Controller
    {
        private readonly IMessageService service;

        public MessageController(IMessageService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {          
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult ResponseToTheme(int? themeId)
        {
            ViewBag.ThemeId = themeId.Value;
            return View("~/Views/Message/_ResponseToTheme.cshtml");
        }

        [HttpPost]
        public ActionResult ResponseToTheme(MessageViewModel model, int? themeId)
        {
            model.DatePublication = DateTime.Now;
            model.SenderId = Convert.ToInt32(HttpContext.Profile.GetPropertyValue("Id"));
            model.ThemeId = themeId.Value;
            service.CreateMessage(model.ToBllMessage());
            var messages = service.GetMessagesByThemeId(themeId.Value).Select(message => message.ToModelMessage());
            return PartialView("_MessagesOfTheme", messages);
        }



        [ChildActionOnly]
        public ActionResult MessagesOfTheme(int themeId)
        {

            var messages = service.GetMessagesByThemeId(themeId).Select(message => message.ToModelMessage());
            return PartialView("_MessagesOfTheme", messages);
        }

        [HttpGet]
        public ActionResult DeleteMessage(int? messageId, int? themeId)
        {
            var message = service.GetMessageEntityById(messageId.Value);
            service.DeleteMessage(message);
            var messages = service.GetMessagesByThemeId(themeId.Value).Select(m => m.ToModelMessage());
            return PartialView("_MessagesOfTheme", messages);
        }

    
        [ChildActionOnly]
        public ActionResult UpdateMessages(int? messageId, int? themeId)
        {
            ViewBag.MessageId = messageId.Value;
            ViewBag.themeId = themeId.Value;
            return PartialView("_UpdateMessage");
        }

        [HttpPost]
        public ActionResult UpdateMessage(MessageViewModel model, int? messageId, int? themeId)
        {
            var message = service.GetMessageEntityById(messageId.Value);
            message.Content = model.Content;
            service.UpdateMessage(message);
            var messages = service.GetMessagesByThemeId(themeId.Value).Select(m => m.ToModelMessage());
            return PartialView("_MessagesOfTheme", messages);
        }

    }
}
