using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Context;

namespace WEB.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        sqlwebEntities objsqlwebEntities = new sqlwebEntities();
        public ActionResult Index()
        {
            var lstCategory = objsqlwebEntities.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listProduct = objsqlwebEntities.Products.Where(n => n.Categoryid == Id).ToList();
            return View(listProduct);
        }

    }
}