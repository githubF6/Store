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
        }
}
