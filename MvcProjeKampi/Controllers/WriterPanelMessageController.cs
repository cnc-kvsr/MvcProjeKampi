using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        DraftController draftController = new DraftController();
        Context _context = new Context();
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            var count = messageManager.GetListStatusFalse().Where(x => x.ReceiverMail == "gizem@hotmail.com").Count();
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
            if (button == "post")
            {
                if (results.IsValid)
                {
                    message.SenderMail = "gizem@hotmail.com";
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

        public PartialViewResult MessageListMenu()
        {
            var numberOfContact = _context.Contacts.Count();
            ViewBag.numberOfContact = numberOfContact;

            var numberOfReceiver = _context.Messages.Count(x => x.ReceiverMail == "gizem@hotmail.com");
            ViewBag.numberOfReceiver = numberOfReceiver;

            var numberOfSender = _context.Messages.Count(x => x.SenderMail == "gizem@hotmail.com");
            ViewBag.numberOfSender = numberOfSender;

            var numberOfDraft = _context.Drafts.Count(x => x.SenderMail == "gizem@hotmail.com");
            ViewBag.numberOfDraft = numberOfDraft;
            return PartialView();
        }

    }
}