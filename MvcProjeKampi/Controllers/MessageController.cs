using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        MessageValidator messageValidator = new MessageValidator();
        DraftController draftController = new DraftController();

        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            var count = messageManager.GetListStatusFalse().Where(x => x.ReceiverMail == "admin@gmail.com").Count();
            ViewBag.count = count;
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = messageManager.GetListSendbox();
            return View(messageList);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);
            values.MessageStatus = true;
            messageManager.MessageUpdate(values);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message message, string button)
        {
            ValidationResult results = messageValidator.Validate(message);
            if (button == "draft")
            {
                if (results.IsValid)
                {
                    Draft draft = new Draft();
                    draft.SenderMail = message.SenderMail;
                    draft.Subject = message.Subject;
                    draft.DraftContent = message.MessageContent;
                    draft.DraftDate = DateTime.Parse(DateTime.Now.ToLongDateString());
                    draftController.AddDraft(draft);
                    return RedirectToAction("Draft", "Draft");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            if (button=="post")
            {
                if (results.IsValid)
                {
                    message.SenderMail = "admin@gmail.com";
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAdd(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
        }

        //public ActionResult IsRead(int id)
        //{
        //    var message = messageManager.GetByID(id);
        //    if (message.MessageStatus==false)
        //    {
        //        message.MessageStatus = true;
        //    }
        //    messageManager.MessageUpdate(message);
        //    return RedirectToAction("ReadMessage");
        //}

        //public ActionResult ReadMessage()
        //{
        //    var readMessage = messageManager.GetListInbox().Where(x => x.MessageStatus == true).ToList();
        //    return View(readMessage);
        //}
        //public ActionResult UnreadMessage()
        //{
        //    var unreadMessage = messageManager.GetListInbox().Where(x => x.MessageStatus == false);
        //    return View(unreadMessage);
        //}

    }
}