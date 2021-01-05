using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;
using static System.Collections.Specialized.BitVector32;

namespace storage.Controllers
{
    public class GController : Controller
    {
        // GET: G
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GLogin(string username,string password) {

            var list = new Gservice().Login(username,password);
           
            if (list.Count > 0)
            {
                Session["Userid"] = list.ElementAt(0).UserName;
                Session.Timeout = 5;
                return Content("1");
            }
            else {
                return Content("2");
            }
            
        }
    }
}