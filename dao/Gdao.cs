using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace dao
{
    public class Gdao
    {
       static warehouseEntities entity = new warehouseEntities();
        public static int count() {
            return entity.measure.Count();
        }
        public List<admin> Login(string username,string password) {

            return entity.admin.Where(p => p.UserName == username && p.Password == password).ToList();
            //var obj = (
            //   from admin in entity.admin.Where(p => p.UserName == username && p.Password == password).Count()
            //    )
        }
        public static IQueryable QueryUnit(int pageIndex, int pageSize,int measureID,string measureName)
        {
            PageList page = new PageList();
            var obj =
                from u in entity.measure 
                select new
                {
                    measureID = u.measureID,
                    measureName = u.measureName
                };
            if (measureID!=0||measureName!="") {
                obj = obj.Where(p => p.measureID==measureID||p.measureName==measureName);
            }
            return obj.OrderBy(p=>p.measureID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        public static IQueryable QueryType(int pageIndex, int pageSize,int typeId,string typeName) {
            PageList page = new PageList();
            var obj =
                from t in entity.Type
                from a in entity.admin
                where t.CreateUser == t.admin.ID
                select new
                {
                    TypeID = t.TypeID,
                    TypeName = t.TypeName,
                    UserName = t.admin.UserName,
                    CreateTime = t.CreateTime,
                    Remark = t.Remark
                };
            if (typeId!=0||typeName!="") {
                obj = obj.Where(p => p.TypeID == typeId || p.TypeName == typeName);
            }
            return obj.OrderBy(p=>p.TypeID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        public static IQueryable Queryproduct(int pageIndex, int pageSize,int ProductID,string ProductName) {
            PageList page = new PageList();
            var obj =
                from p in entity.product
                from t in entity.Type
                from u in entity.measure
                where p.ProductType == t.TypeID && p.ProductUnit == u.measureID
                select new
                {
                    ProductID=p.ProductID,
                    ProductName= p.ProductName,
                    Productprice=p.Productprice,
                    ProductSpercification= p.ProductSpercification,
                    TypeName= p.Type.TypeName,
                    measureName=p.measure.measureName,
                    Remark= p.Remark
                };
            if (ProductID!=0||ProductName!="") {
                obj = obj.Where(p=>p.ProductID==ProductID||p.ProductName==ProductName);
            }
            return obj.OrderBy(p => p.ProductID).Skip((pageIndex - 1) * pageSize).Take(pageSize);

        }
        public static IQueryable QueryDtable(int pageIndex, int pageSize,string KwName) {
            PageList page = new PageList();
            var obj =
                from d in entity.Dtable
                from storageType in entity.storageType
                from store in entity.store
                from storange1 in entity.storage1
                where d.KwTypeID == storageType.KwTypeID && d.KwID == storange1.KwID && d.CkID == store.CkID
                select new
                {
                    ID = d.ID,
                    kwName = d.storage1.kwName,
                    CkName = d.store.CkName,
                    KwTypeName = d.storageType.KwTypeName,
                    Status = d.Status,
                    CreateTime = d.CreateTime
                };
            if (KwName!="") {
                obj = obj.Where(p=>p.kwName==KwName);
            }
            return obj.OrderBy(p => p.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        public static IQueryable Queryclient(int pageIndex, int pageSize,int clientID,string clientName) {
            PageList page = new PageList();
            var obj =
                from c in entity.client
                select new
                {
                    clientID= c.clientID,
                    clientName= c.clientName,
                    Phone=c.Phone,
                    CreateTime= c.CreateTime,

                };
            if (clientID!=0|| clientName!="") {
                obj = obj.Where(p=>p.clientID==clientID||p.clientName==clientName);
            }
            return obj.OrderBy(p => p.clientID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
