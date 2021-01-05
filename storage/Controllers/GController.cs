using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Model;
using Service;
using static System.Collections.Specialized.BitVector32;

namespace storage.Controllers
{
    public class GController : Controller
    {
        // GET: Ghttps://github.com/githubF6/Store.git 
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
        public PartialViewResult store_list() {

            //库存清单
            return PartialView();
        }
        public PartialViewResult product_sum()
        {

            //货品统计
            return PartialView();
        }
        public PartialViewResult crk()
        {

            //出入库统计
            return PartialView();
        }
        public PartialViewResult rk()
        {

            //入库报表
            return PartialView();
        }
        public PartialViewResult ck()
        {

            //出库报表
            return PartialView();
        }
        public PartialViewResult breakage_statement() {

            //报损管理
            return PartialView();
        }

        public PartialViewResult return_statement()
        {

            //退货管理
            return PartialView();
        }


    }
}