using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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

    }
}