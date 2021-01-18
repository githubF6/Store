using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.SqlClient;
using System.Diagnostics;
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
        public List<admin> Login(string username, string password) {

            return entity.admin.Where(p => p.UserName == username && p.Password == password).ToList();
            //var obj = (
            //   from admin in entity.admin.Where(p => p.UserName == username && p.Password == password).Count()
            //    )
        }
        public static PageList QueryUnit(int pageIndex, int pageSize, int measureID, string measureName)
        {
            PageList page = new PageList();
            var obj =
                from u in entity.measure
                select new
                {
                    measureID = u.measureID,
                    measureName = u.measureName
                };
            if (measureID != 0 || measureName != "") {
                obj = obj.Where(p => p.measureID == measureID || p.measureName == measureName);
            }
            page.DataList = obj.OrderBy(p => p.measureID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page;
        }
        public static PageList QueryType(int pageIndex, int pageSize, int typeId, string typeName) {
            PageList page = new PageList();
            var obj =
                from t in entity.Type
                from a in entity.admin
                where t.CreateUser == t.admin.ID && t.Status==0
                select new
                {
                    TypeID = t.TypeID,
                    TypeName = t.TypeName,
                    UserName = t.admin.UserName,
                    CreateTime = t.CreateTime,
                    Remark = t.Remark

                };
            if (typeId != 0 || typeName != "") {
                obj = obj.Where(p => p.TypeID == typeId || p.TypeName == typeName);
            }
            page.DataList = obj.OrderBy(p => p.TypeID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page ;
        }
        public static PageList Queryproduct(int pageIndex, int pageSize, int ProductID, string ProductName, int selectTypeName) {
            PageList page = new PageList();
            
            var obj =
                from p in entity.product
                from t in entity.Type
                from u in entity.measure
                where p.ProductType == t.TypeID && p.ProductUnit == u.measureID &&p.Status==0
                select new
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    Productprice = p.Productprice,
                    ProductSpercification = p.ProductSpercification,
                    TypeName = p.Type.TypeName,
                    measureName = p.measure.measureName,
                    count = p.count,
                    TypeID = p.Type.TypeID
                };
            if (ProductID != 0 || ProductName != "" || selectTypeName != 0) {
                obj = obj.Where(p => p.ProductID == ProductID || p.ProductName == ProductName || p.TypeID == selectTypeName);
            }
            page.DataList = obj.OrderBy(p => p.ProductID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page;

        }
        public static PageList QueryDtable(int pageIndex, int pageSize, string KwName) {
            PageList page = new PageList();
            var obj =
                from d in entity.Dtable
                from storageType in entity.storageType
                from store in entity.store
                from storange1 in entity.storage1
                where d.KwTypeID == storageType.KwTypeID && d.KwID == storange1.KwID && d.CkID == store.CkID &&d.Status==0
                select new
                {
                    ID = d.ID,
                    kwName = d.storage1.kwName,
                    CkName = d.store.CkName,
                    KwTypeName = d.storageType.KwTypeName,
                    Status = d.Status,
                    CreateTime = d.CreateTime
                };
            if (KwName != "") {
                obj = obj.Where(p => p.kwName == KwName);
            }
            page.DataList = obj.OrderBy(p => p.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page;
        }
        public static PageList Queryclient(int pageIndex, int pageSize, int clientID, string clientName) {
            PageList page = new PageList();
            var obj =
                from c in entity.client
                where c.Status==0
                select new
                {
                    clientID = c.clientID,
                    clientName = c.clientName,
                    Phone = c.Phone,
                    CreateTime = c.CreateTime,

                };
            if (clientID != 0 || clientName != "") {
                obj = obj.Where(p => p.clientID == clientID || p.clientName == clientName);
            }
            page.DataList = obj.OrderBy(p => p.clientID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page;
        }
        public static PageList Querysupplier(int pageIndex, int pageSize, int supplierID, string supplierName, string supplierType) {
            PageList page = new PageList();
            var obj =
                from s in entity.supplier
                where s.Status==0
                select new
                {
                    supplierID = s.supplierID,
                    supplierType = s.supplierType,
                    supplierName = s.supplierName,
                    Phone = s.Phone,
                    Email = s.Email,
                    supplier_contact = s.supplier_contact,
                    Address = s.Address,
                    Remark = s.Remark,

                };
            if (supplierID != 0 || supplierName != "" || supplierType != "") {
                obj = obj.Where(p => p.supplierID == supplierID || p.supplierName == supplierName || p.supplierType == supplierType);
            }
            page.DataList = obj.OrderBy(p => p.supplierID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page;
        }
        public static IQueryable querySelectType() {

            var obj =
                from t in entity.Type
                select new
                {
                    TypeID = t.TypeID,
                    TypeName = t.TypeName,

                };
            return obj;
        }
        public static IQueryable queryCkNameAndKwTypeName() {

            var obj =
                   from ck in entity.store
                   select new
                   {
                       CkID = ck.CkID,
                       CkName = ck.CkName
                   };
            var obj1 =
                from lx in entity.storageType
                select new
                {
                    KwTypeID=lx.KwTypeID,
                    KwTypeName = lx.KwTypeName,
                    obj=obj
                };
            return obj1;
        }
        public static PageList queryInventory(int pageIndex, int pageSize,string kwName, string KwTypeName) {
            PageList page = new PageList();
            var obj =
                    from p in entity.product
                    from s in entity.storage1
                    from sType in entity.storageType
                    from t in entity.Type
                    where p.KwID == s.KwID && p.KwTypeId == sType.KwTypeID &&p.ProductType==t.TypeID
                    select new
                    {
                        kwName=p.storage1.kwName,
                        KwTypeName=p.storageType.KwTypeName,
                        ProductID=p.ProductID,
                        ProductName=p.ProductName,
                        TypeName=p.Type.TypeName,
                        count=p.count
                    };
            if (kwName!=""&&KwTypeName!="") {
                obj = obj.Where(p=>p.kwName==kwName&&p.KwTypeName==KwTypeName);
            }
            else if (kwName!=""||KwTypeName!="") {
                Debug.WriteLine("我进入");
                
                obj=obj.Where(p=>p.kwName==kwName||p.KwTypeName==KwTypeName);
                foreach (var i in obj)
                {
                    Debug.WriteLine(i.kwName);
                }
            }
            page.DataList = obj.OrderBy(p => p.ProductID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page;
        }
        public static IQueryable queryTypeAndKwName() {

            var obj =
                from p in entity.storage1
                select new
                {
                    KwID=p.KwID,
                    kwName=p.kwName,
                    obj1=
                    from t in entity.storageType
                    select new {
                        KwTypeID=t.KwTypeID,
                        KwTypeName=t.KwTypeName
                    }
                    
                };
            
            return obj;
        }
        public static PageList queryInventory_Report(int pageIndex,int pageSize,int Date) {
            PageList page = new PageList();
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime d;
            var obj =
                from p in entity.rk
                from s in entity.supplier
                from a in entity.admin
                where p.rkSupplier == s.supplierID && p.CreateUser == a.ID
                select new
                {
                    ID=p.ID,
                    CreateTime=p.CreateTime,
                    supplierName=p.supplier.supplierName,
                    Sum=p.Sum,
                    Asum=p.Sum*p.Price,
                };
            if (Date != 0)
            {
                Debug.WriteLine("sadsads");
                d = date.AddDays(-Date);
                obj = obj.Where(p => p.CreateTime <= date && p.CreateTime >= d);
            }
            page.DataList = obj.OrderBy(p =>p.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page;
        }
        public static IQueryable query_queryInventory_ReportAll(int id) {

            var obj =
                from p in entity.rk
                from s in entity.supplier
                from a in entity.admin
                where p.rkSupplier == s.supplierID && p.CreateUser == a.ID && p.ID==id
                select new
                {
                    ID= p.ID,
                    rkType= p.rkType,
                    check1=p.check1,
                    supplierID= p.supplier.supplierID,
                    supplierName= p.supplier.supplierName,
                    supplier_contact=p.supplier.supplier_contact,
                    UserName=p.admin.zsName,
                    CreateTime=p.CreateTime,
                    Phone= p.supplier.Phone
                };
            return obj;
        }
        public static PageList Outbound_Statements(int pageIndex, int pageSize,int Date) {
            PageList page = new PageList();
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime d;
            var obj =
                from p in entity.ck
                from c in entity.client
                from a in entity.admin
                where p.Ckclient == c.clientID && p.CreateUser == a.ID
                select new {
                    ckID=p.ckID,
                    CreateTime= p.CreateTime,
                    clientNamev=p.client.clientName,
                    Sum=p.Sum,
                    Asum=p.Sum*p.Price
                };
            if (Date != 0)
            {
                Debug.WriteLine("sadsads");
                d = date.AddDays(-Date);
                obj = obj.Where(p => p.CreateTime <= date && p.CreateTime >= d);
            }
            page.DataList = obj.OrderBy(p => p.ckID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page;
        }
        public static IQueryable Outbound_StatementsAll(int id) {
            var obj =
                   from p in entity.ck
                   from c in entity.client
                   from a in entity.admin
                   where p.Ckclient == c.clientID && p.CreateUser == a.ID &&p.ckID==id
                   select new
                   {
                       ckID = p.ckID,
                       CkType= p.CkType,
                       check1=p.check1,
                       clientID=p.client.clientID,
                       clientName=p.client.clientName,
                       UserName=p.admin.UserName,
                       zsName=p.admin.zsName,
                       CreateTime=p.CreateTime,
                       Phone=p.client.Phone
                   };
            return obj;
        }
        public static PageList Reported_loss_report(int pageIndex, int pageSize,int Date) {
            PageList page = new PageList();
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime d;
            var obj =
                from p in entity.bs
                from c in entity.product
                from a in entity.admin
                where p.ProductID == c.ProductID && p.CreateUser == a.ID
                select new
                {
                    bsID=p.bsID,
                    ProductName=p.product.ProductName,
                    Count=p.Count,
                    sum=p.Count*95,
                    count=p.product.count,
                    CreateTime = p.CreateTime,
                };
            if (Date != 0)
            {
                Debug.WriteLine("sadsads");
                d = date.AddDays(-Date);
                obj = obj.Where(p => p.CreateTime <= date && p.CreateTime >= d);
            }
            var obj1 = from tb in obj
                       group tb by tb.ProductName
                     into grp
                       select new
                       {
                           bsID = grp.Select(p => p.bsID),
                           ProductName = grp.Select(p => p.ProductName),
                           Count = grp.Select(p => p.Count),
                           sum = grp.Select(p => p.sum),
                           bili = grp.Sum(p => p.count),
                           CreateTime = grp.Select(p => p.CreateTime),
                       };
            page.DataList = obj1.OrderBy(p => p.bsID.FirstOrDefault()).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj1.Count();
            return page;
        }
        public static PageList Return_Statements(int pageIndex, int pageSize,int Date) {


            DateTime date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime d;
            PageList page = new PageList();
            
            var obj =
                from p in entity.th
                from c in entity.product
                from a in entity.admin
                where p.ckid == c.ProductID && p.CreateUser == a.ID
               
                select new
                {

                    thID = p.thID,
                    ProductName = p.product.ProductName,
                    Count = p.Count,
                    sum = p.Count * 40,
                    count=p.product.count,
                    CreateTime=p.CreateTime,
                    
                    
                };
            if (Date != 0)
            {
                Debug.WriteLine("sadsads");
                d = date.AddDays(-Date);
                obj = obj.Where(p => p.CreateTime <= date && p.CreateTime >= d);
            }

            var obj1 =
                from tb in obj
                group tb by tb.ProductName into grp
                select new
                {

                    thID = grp.Select(p => p.thID),
                    ProductName = grp.Select(p => p.ProductName),
                    Count = grp.Select(p => p.Count),
                    sum = grp.Select(p => p.sum),
                    bili = grp.Sum(p => p.count),
                    CreateTime = grp.Select(p => p.CreateTime),
                    
                };
            
          
            page.DataList = obj1.OrderBy(p=>p.thID.FirstOrDefault()).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj1.Count();
            return page;
        }
        public static IQueryable Return_Statements1() {
            var obj =
                from p in entity.th
                from c in entity.product
                from a in entity.admin
                where p.ckid == c.ProductID && p.CreateUser == a.ID

                select new
                {

                    
                    ProductName = p.product.ProductName,
                    
                    
                    count = p.product.count

                };
            var obj1 =
                from tb in obj
                group tb by tb.ProductName into grp
                select new
                {

                    
                    ProductName = grp.Select(p => p.ProductName),
                   
                    
                    bili = grp.Sum(p => p.count)

                };
            return obj1;
        }
        public static IQueryable Reported_loss_report1() {
            var obj =
                   from p in entity.bs
                   from c in entity.product
                   from a in entity.admin
                   where p.ProductID == c.ProductID && p.CreateUser == a.ID

                   select new
                   {


                       ProductName = p.product.ProductName,


                       count = p.product.count

                   };

            var obj1 =
                from tb in obj
                group tb by tb.ProductName into grp
                select new
                {


                    ProductName = grp.Select(p => p.ProductName),


                    bili = grp.Sum(p => p.count)

                };
            return obj1;
        }
        public static PageList queryCrk(int pageIndex,int pageSize,int Date) {
            PageList page =new PageList();
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime d;
            var obj =
                    from p in entity.client
                   
                    select new
                    {
                        p.clientID,
                        p.clientName,
                        p.Phone,
                        p.count,
                        p.CreateTime
                    };
            if (Date != 0)
            {
                Debug.WriteLine("sadsads");
                d = date.AddDays(-Date);
                obj = obj.Where(p => p.CreateTime <= date && p.CreateTime >= d);
            }
            page.DataList = obj.OrderBy(p => p.clientID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page;
        }
        public static IQueryable queryCrk1() {

            var obj =
                from p in entity.client
                select new { 
                p.clientName,
                p.count
                };
            return obj.OrderByDescending(p => p.count);
        }
        public static PageList queryProduct_sum(int pageIndex,int pageSize,int Date) {
            PageList page = new PageList();
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime d;
            var obj =
                from p in entity.supplier
                select new
                {
                    p.supplierID,
                    p.supplierName,
                    p.supplierType,
                    p.Phone,
                    p.count,
                    p.CreateTime
                };
            if (Date != 0)
            {
                Debug.WriteLine("sadsads");
                d = date.AddDays(-Date);
                obj = obj.Where(p => p.CreateTime <= date && p.CreateTime >= d);
            }
            page.DataList = obj.OrderBy(p => p.supplierID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            page.PageCount = obj.Count();
            return page;

        }
        public static IQueryable queryProduct_sum1() {
            var obj =
                  from p in entity.supplier
                  select new
                  {
                      p.supplierName,
                      p.count
                  };
            return obj.OrderByDescending(p => p.count);
        }
    }
}
