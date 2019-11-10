using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
		// GET: Home
		QUANLYBDSEntities m = new QUANLYBDSEntities(); 
        public ActionResult Index()
        {
			var p = m.Properties.ToList();
            return View(p);
        }
    }
}