using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        Context _context = new Context();
        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetByID(id);
            return View(contactValues);
        }

        public PartialViewResult InboxPartial()
        {
            var numberOfContact = _context.Contacts.Count();
            ViewBag.numberOfContact = numberOfContact;

            var numberOfReceiver = _context.Messages.Count(x => x.ReceiverMail == "admin@gmail.com");
            ViewBag.numberOfReceiver = numberOfReceiver;

            var numberOfSender = _context.Messages.Count(x => x.SenderMail == "admin@gmail.com");
            ViewBag.numberOfSender = numberOfSender;


            return PartialView();
        }
        
    }
}