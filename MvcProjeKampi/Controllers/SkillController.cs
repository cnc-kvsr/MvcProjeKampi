using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());

        public ActionResult Index()
        {
            var skillValues = skillManager.GetList();
            return View(skillValues);
        }

        public ActionResult SkillCard()
        {
            var skillValues = skillManager.GetList();
            ViewBag.d1 = skillValues.FirstOrDefault().Writer.WriterName;
            ViewBag.d2 = skillValues.FirstOrDefault().Writer.WriterSurName;
            ViewBag.d3 = skillValues.FirstOrDefault().Writer.WriterTitle;
            return View(skillValues);
        }
    }
}