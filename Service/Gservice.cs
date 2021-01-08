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
            PageList list = new PageList();
            list.PageCount = Gdao.count();
            list.DataList = Gdao.QueryUnit(page, limit,measureID,measureName);
            return list;
        }
        public static PageList QueryType(int pageIndex, int pageSize, int typeId, string typeName)
        {
            PageList page = new PageList();
            page.PageCount = Gdao.count();
            page.DataList = Gdao.QueryType(pageIndex,pageSize,typeId,typeName);
            return page;
        }
        public static PageList Queryproduct(int page, int limit, int ProductID, string ProductName) {
            PageList list = new PageList();
            list.PageCount = Gdao.count();
            list.DataList = Gdao.Queryproduct(page, limit,ProductID,  ProductName);
            return list;
        }
        public static PageList QueryDtable(int page, int limit, string KwName)
        {
            PageList list = new PageList();
            list.PageCount = Gdao.count();
            list.DataList = Gdao.QueryDtable(page, limit,KwName);
            return list;
        }
        public static PageList Queryclient(int page, int limit, int clientID, string clientName)
        {
            PageList list = new PageList();
            list.PageCount = Gdao.count();
            list.DataList = Gdao.Queryclient(page, limit,clientID,clientName);
            return list;
        }
        public static PageList Querysupplier(int page, int limit, int supplierID, string supplierName, string supplierType)
        {
            PageList list = new PageList();
            list.PageCount = Gdao.count();
            list.DataList = Gdao.Querysupplier(page, limit,supplierID,supplierName,supplierType);
            return list;
        }
    }
}
