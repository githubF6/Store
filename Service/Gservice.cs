using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;
using Model;

namespace Service
{
    public static class Gservice
    {
       
        public static List<admin> Login(string username, string password)
        {
            return new Gdao().Login(username, password);
        }
        public static PageList queryUnit(int page, int limit, int measureID, string measureName)
        {

            return Gdao.QueryUnit(page,limit,measureID,measureName); ;
        }
        public static PageList QueryType(int pageIndex, int pageSize, int typeId, string typeName)
        {
            return Gdao.QueryType(pageIndex,pageSize,typeId,typeName);
        }
            public static PageList Queryproduct(int page, int limit, int ProductID, string ProductName, int selectTypeName) {
            
            
            
            return Gdao.Queryproduct(page,limit,ProductID,ProductName,selectTypeName);
        }
        public static PageList QueryDtable(int page, int limit, string KwName)
        {

            return Gdao.QueryDtable(page, limit,KwName);
        }
        public static PageList Queryclient(int page, int limit, int clientID, string clientName)
        {
            return Gdao.Queryclient(page, limit,clientID,clientName);
        }
        public static PageList Querysupplier(int page, int limit, int supplierID, string supplierName, string supplierType)
        {
            return Gdao.Querysupplier(page, limit,supplierID,supplierName,supplierType);
        }
        public static IQueryable querySelectType() {

            return Gdao.querySelectType();
        }
        public static IQueryable queryCkNameAndKwTypeName()
        {
            return Gdao.queryCkNameAndKwTypeName();
        }
        public static PageList queryInventory(int page, int limit, string kwName, string KwTypeName)
        {
            return Gdao.queryInventory(page,limit,kwName,KwTypeName);
        }
        public static IQueryable queryTypeAndKwName()
        {
            return Gdao.queryTypeAndKwName();
        }
        public static PageList queryInventory_Report(int page, int limit,int Date)
        {
            return Gdao.queryInventory_Report(page,limit,Date);
        }
        public static IQueryable query_queryInventory_ReportAll(int id)
        {
            return Gdao.query_queryInventory_ReportAll(id);
        }
        public static PageList Outbound_Statements(int page, int limit,int Date)
        {
            return Gdao.Outbound_Statements(page, limit,Date);
        }
        public static IQueryable Outbound_StatementsAll(int id)
        {
            return Gdao.Outbound_StatementsAll(id);
        }
        public static PageList Reported_loss_report(int page, int limit,int Date)
        {
            return Gdao.Reported_loss_report(page,limit,Date);
        
        }
        public static PageList Return_Statements(int page, int limit, int Date)
        {
            return Gdao.Return_Statements(page, limit, Date);

        }
        public static IQueryable Return_Statements1()
        {
            return Gdao.Return_Statements1();
        }
        public static IQueryable Reported_loss_report1()
        {
            return Gdao.Reported_loss_report1();
        }
        public static PageList queryCrk(int page, int limit,int Date)
        {
            return Gdao.queryCrk(page, limit,Date);
        }
        public static IQueryable queryCrk1()
        {
            return Gdao.queryCrk1();
        }
        public static PageList queryProduct_sum(int pageIndex, int pageSize,int Date)
        {
            return Gdao.queryProduct_sum(pageIndex, pageSize,Date);
        }
        public static IQueryable queryProduct_sum1()
        {
            return Gdao.queryProduct_sum1();
        }
        }
    }
