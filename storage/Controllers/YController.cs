using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Model;

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

       
        public ActionResult GetRuKu(int page, int limit,int id,string check)
        {
            
            return Json(Yservice.GetRuKu(page, limit,id,check),JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChuKu(int page, int limit,int id,string check) 
        {
            return Json(Yservice.GetChuKu(page, limit,id,check), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBaoSun(int page, int limit, int id,string check) 
        {
            return Json(Yservice.GetBaoSun(page, limit,id,check), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RuDanHao(int id) 
        {
            Debug.Write("id"+id);
            return Json(Yservice.RuDanHao(id),JsonRequestBehavior.AllowGet);
        }
        public ActionResult Queryyk(int page, int limit, int id, string check)
        {
            return Json(Yservice.Queryyk(page, limit, id, check), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Queryth(int page, int limit, int id, string check)
        {
            return Json(Yservice.Queryth(page, limit, id, check), JsonRequestBehavior.AllowGet);
        }
        //添加移库
        public ActionResult getadd(yk lo)
        {
            lo.Rkid = 4;
            lo.Status = 0;
            Debug.Write("创建用户:"+lo.CreateUser);
            return Json(Yservice.addyk(lo), JsonRequestBehavior.AllowGet);
        }
        //添加退货
        public ActionResult getaddth(th hh)
        {
            hh.ckid = 4;
            hh.Status=0;
            Debug.Write("创建用户:" + hh.CreateUser);
            return Json(Yservice.addth(hh), JsonRequestBehavior.AllowGet);
        }
        //移库类型查询
        public ActionResult selecttype(string yklx)
        {
            Debug.Write("yklx" + yklx);
            return Json(Yservice.yktype(yklx), JsonRequestBehavior.AllowGet);
        }
        //修改移库
        public ActionResult updateyk(yk s)
        {
            return Json(Yservice.Edit(s), JsonRequestBehavior.AllowGet);
        }
    }
}