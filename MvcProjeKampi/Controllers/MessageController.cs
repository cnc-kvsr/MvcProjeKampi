using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = messageManager.GetListSendbox();
            return View(messageList);
        }
    }
}