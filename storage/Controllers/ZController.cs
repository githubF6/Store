using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;

namespace storage.Controllers
{
    public class ZController : Controller
    {
        // GET: Z
        Zservice z=new Zservice();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult staff_management()
        {
            //员工管理
            return PartialView();
        }
        public ActionResult staff_management_a()
        {
            //员工管理
            var a=z.queryyh();
            return Json(a,JsonRequestBehavior.AllowGet);
        }
        public ActionResult staff_management_dele(int id)
        {
            //员工管理
            var a=z.deleyh(id);
            return Json(a,JsonRequestBehavior.AllowGet);
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