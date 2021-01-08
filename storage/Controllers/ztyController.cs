using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace storage.Controllers
{
    public class ztyController : Controller
    {
        // GET: zty

        //bll b = new bll();
        //
        //员工管理
        //

        //搜索全部
        public ActionResult Zyggl() {

            return View();
        }
        public ActionResult ygglqualy()
        {
            //var li=b.ygglqualy();
            return Json("", JsonRequestBehavior.AllowGet);
        }
        //条件搜索
        public ActionResult ygglqualydata()
        {
            return PartialView();
        }
        //添加
        public ActionResult yggladd()
        {
            return View();
        }
        //修改
        public ActionResult ygglupdata()
        {
            return View();
        }
        //删除
        public ActionResult yggldele()
        {
            return View();
        }


        //
        //角色管理
        //

        //搜索全部
        public ActionResult hsglqualy()
        {
            return View();
        }
        //条件搜索
        public ActionResult hsglqualydata()
        {
            return View();
        }
        //添加
        public ActionResult hsgladd()
        {
            return View();
        }
        //修改
        public ActionResult hsglupdata()
        {
            return View();
        }
        //删除
        public ActionResult hsgldele()
        {
            return View();
        }


        //
        //部门管理
        //

        //搜索全部
        public ActionResult bmglqualy()
        {
            return View();
        }
        //条件搜索
        public ActionResult bmglqualydata()
        {
            return View();
        }
        //添加
        public ActionResult bmgladd()
        {
            return View();
        }
        //修改
        public ActionResult bmglupdata()
        {
            return View();
        }
        //删除
        public ActionResult bmgldele()
        {
            return View();
        }


        //
        //菜单管理
        //

        //搜索全部
        public ActionResult cdglqualy()
        {
            return View();
        }
        //条件搜索
        public ActionResult cdglqualydata()
        {
            return View();
        }
        //添加
        public ActionResult cdgladd()
        {
            return View();
        }
        //修改
        public ActionResult cdglupdata()
        {
            return View();
        }
        //删除
        public ActionResult cdgldele()
        {
            return View();
        }


        //
        //权限分配
        //
        public ActionResult qxfp()
        {
            return View();
        }
        //
        //标识符管理
        //
        public ActionResult bsfgl()
        {
            return View();
        }
    }
}