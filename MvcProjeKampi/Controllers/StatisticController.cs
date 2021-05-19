using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context _context = new Context();
        public ActionResult Index()
        {
            var totalCategory = _context.Categories.Count();
            ViewBag.totalNumberOfCategories = totalCategory;

            var softwareCategory = _context.Headings.Count(x => x.CategoryID == 12);
            ViewBag.totalNumberOfSoftwareHeading = softwareCategory;
            
            var writerNameIncludedA = _context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.writerNameIncludedA = writerNameIncludedA;

            var maxHeadingNumber = _context.Headings.Max(x => x.Category.CategoryID);
            ViewBag.maxHeadingNumberOfCategory = maxHeadingNumber;

            var numberOfCategoryStatusTrue = _context.Categories.Count(x => x.CategoryStatus == true);
            ViewBag.numberOfCategoryStatusTrue = numberOfCategoryStatusTrue;

            var numberOfCategoryStatusFalse = _context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.numberOfCategoryStatusFalse = numberOfCategoryStatusFalse;


            return View();
        }
    }
}