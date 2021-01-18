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
        public ActionResult GLogin(string username, string password) {

            var list = Gservice.Login(username, password);

            if (list.Count > 0)
            {
                Session["Userid"] = list.ElementAt(0).zsName;
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
        public ActionResult queryUnit(int page, int limit, int measureID, string measureName) {


            return Json(Gservice.queryUnit(page, limit, measureID, measureName), JsonRequestBehavior.AllowGet);
        }
        public ActionResult QueryType(int page, int limit, int typeId, string typeName)
        {


            return Json(Gservice.QueryType(page, limit, typeId, typeName), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Queryproduct(int page, int limit, int ProductID, string ProductName, int selectTypeName) {
            return Json(Gservice.Queryproduct(page,limit,ProductID,ProductName,selectTypeName),JsonRequestBehavior.AllowGet);
        }
        public ActionResult QueryDtable(int page, int limit, string KwName)
        {
            return Json(Gservice.QueryDtable(page, limit,KwName), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Queryclient(int page, int limit, int clientID, string clientName)
        {
            return Json(Gservice.Queryclient(page, limit,clientID,clientName), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Querysupplier(int page, int limit, int supplierID, string supplierName, string supplierType)
        {
            return Json(Gservice.Querysupplier(page, limit,supplierID,supplierName,supplierType), JsonRequestBehavior.AllowGet);
        }
        public ActionResult querySelectType() {

            return Json(Gservice.querySelectType(),JsonRequestBehavior.AllowGet);
        }
        public ActionResult queryCkNameAndKwTypeName() {
            return Json(Gservice.queryCkNameAndKwTypeName(),JsonRequestBehavior.AllowGet);
        }
        public ActionResult queryInventory(int page, int limit, string kwName, string KwTypeName)
        {
            Debug.WriteLine("库位名:"+kwName);
            Debug.WriteLine("库位类型:" + KwTypeName);
            return Json(Gservice.queryInventory(page,limit,kwName,KwTypeName),JsonRequestBehavior.AllowGet);

        }
        public ActionResult queryTypeAndKwName() {

            return Json(Gservice.queryTypeAndKwName(),JsonRequestBehavior.AllowGet);
        }
        public ActionResult queryInventory_Report(int page, int limit,int Date)
        {

            return Json(Gservice.queryInventory_Report(page,limit,Date), JsonRequestBehavior.AllowGet);
        }
        public ActionResult query_queryInventory_ReportAll(int id) {
            return Json(Gservice.query_queryInventory_ReportAll(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Outbound_Statements(int page, int limit,int Date)
        {

            return Json(Gservice.Outbound_Statements(page, limit,Date), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Outbound_StatementsAll(int id) {
            return Json(Gservice.Outbound_StatementsAll(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Reported_loss_report(int page, int limit,int Date) {

            return Json(Gservice.Reported_loss_report(page,limit,Date),JsonRequestBehavior.AllowGet);
        }
        public ActionResult Return_Statements(int page, int limit, int Date) {
            
            return Json(Gservice.Return_Statements(page, limit,Date), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Return_Statements1()
        {
            return Json(Gservice.Return_Statements1(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Reported_loss_report1() {
            return Json(Gservice.Reported_loss_report1(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult queryCrk(int page, int limit,int Date) {
            return Json(Gservice.queryCrk(page,limit,Date), JsonRequestBehavior.AllowGet);
        }
        public ActionResult queryCrk1() {
            return Json(Gservice.queryCrk1(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult queryProduct_sum(int page, int limit,int Date) {
            return Json(Gservice.queryProduct_sum(page, limit,Date), JsonRequestBehavior.AllowGet);
        }
        public ActionResult queryProduct_sum1() {
            return Json(Gservice.queryProduct_sum1(), JsonRequestBehavior.AllowGet);
        }


    }
}