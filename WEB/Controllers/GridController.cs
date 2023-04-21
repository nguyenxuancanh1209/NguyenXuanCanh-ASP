using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class GridController : Controller
    {
        // GET: Grid
        public ActionResult Listing()
        {
            return View();
        }
    }
}