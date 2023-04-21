using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Context;

namespace WEB.Controllers
{
    public class ProductController : Controller
    {
        sqlwebEntities objsqlwebEntities = new sqlwebEntities();
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = objsqlwebEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}