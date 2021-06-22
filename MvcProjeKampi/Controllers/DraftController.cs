using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DraftController : Controller
    {
        // GET: Draft
        DraftManager draftManager = new DraftManager(new EfDraftDal());
        public ActionResult Draftbox()
        {
            var draftList = draftManager.GetListDraftbox();
            return View(draftList);
        }

        public ActionResult GetDraftboxMessageDetails(int id)
        {
            var values = draftManager.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddDraft()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDraft(Draft draft)
        {
            draft.DraftDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            draftManager.DraftAdd(draft);
            return RedirectToAction("Draft");
        }
    }
}