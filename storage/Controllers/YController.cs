using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace storage.Controllers
{
    public class YController : Controller
    {
        // GET: Y
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult stock_management()
        {
            //入库管理
            return PartialView();
        }
        public PartialViewResult delivery_management()
        {
            //出库管理
            return PartialView();
        }
        public PartialViewResult breakage_management()
        {
            //报损管理
            return PartialView();
        }
        public PartialViewResult shifting_management()
        {
            //移库管理
            return PartialView();
        }
        public PartialViewResult sales_management()
        {
            //退货管理
            return PartialView();
        }
    }
}