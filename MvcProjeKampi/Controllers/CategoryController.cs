using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            //var categoryValues = categoryManager.GetAllBL();
            return View();
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }


        /*Sayfa yüklenir yüklenmez veri ekleme işlemi olmasın diye önce [HttpGet]; 
         * sayfa yüklendikten sonra istediğimiz anda ekleme yapabilmek için  [HttpPost] attribute'ü kullanılır. */
       
        
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            //categoryManager.CategoryAddBL(category);
            return RedirectToAction("GetCategoryList");
        }
    }
}