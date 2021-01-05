using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace storage.Controllers
{
    public class ZController : Controller
    {
        // GET: Z
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult staff_management()
        {
            //员工管理
            return PartialView();
        }
        public PartialViewResult role_management()
        {
            //角色管理
            return PartialView();
        }
        public PartialViewResult divisional_management() {

            //部门管理
            return PartialView();
        }
        public PartialViewResult menu_management()
        {
            //菜单管理
            return PartialView();
        }
        public PartialViewResult authority_management()
        {
            //权限分配
            return PartialView();
        }
        public PartialViewResult TAG_management()
        {
            //标识符管理
            return PartialView();
        }
    }
}