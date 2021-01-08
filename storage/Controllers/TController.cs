using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace storage.Controllers
{
    public class TController : Controller
    {
        // GET: T
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult shipping_management()
        {
            //仓位管理
            return PartialView();
        }
        public PartialViewResult supplier_management()
        {
            //供应商管理
            return PartialView();
        }
        public PartialViewResult client_management()
        {
            //客户管理
            return PartialView();
        }
        public PartialViewResult unit()
        {
            //计量单位
           
            return PartialView();
        }
        public PartialViewResult productType()
        {
            //产品类别
            return PartialView();
        }
        public PartialViewResult product_management()
        {
            //产品管理
            return PartialView();
        }
    }
}