using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace dao
{
   public class Ydao
    {
        public static int Count() 
        {
            warehouseEntities entities = new warehouseEntities();
            return entities.rk.Count();
        }

        /// <summary>
        /// 入库管理
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageList GetRuKu(int pageIndex, int pageSize,int? id,string check) 
        {
           
            warehouseEntities entities = new warehouseEntities();
            PageList list = new PageList();
            
            var obj = from r in entities.rk
                      from s in entities.supplier
                      from a in entities.admin
                      where r.rkSupplier==s.supplierID&&r.CreateUser==a.ID
                      //where p.ID == id 
                      //orderby p.ID  
                      select new 
            {
                          ID= r.ID,
                          rkType=r.rkType,
                          supplierName=r.supplier.supplierName,
                          Sum= r.Sum,
                          Price=r.Price,
                          check1=r.check1,
                          CreateUser=r.admin.UserName,
                          CreateTime=r.CreateTime,
                          


                      };

            if (id != 0)
            {
                Debug.WriteLine("sdsd" + id);
                obj = obj.Where(p => p.ID == id);

            } else if (check!=""&&check!=null) {
                obj = obj.Where(p => p.check1==check);
            }
            else if (id==0&&check=="") {
                
            }
            list.DataList = obj.OrderBy(p => p.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            list.PageCount = obj.Count();
            return list ;
        }

        /// <summary>
        /// 出库管理
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageList GetChuKu(int pageIndex, int pageSize,int? id,string check)
        {
            warehouseEntities entities = new warehouseEntities();
            PageList list = new PageList();

            var obj = from p in entities.ck
                      from c in entities.client
                      from a in entities.admin
                      where p.Ckclient==c.clientID&&p.CreateUser==a.ID
                         
                      select new
                      {
                          ckID=p.ckID,
                          CkType=p.CkType,
                          clientName=p.client.clientName,
                          Sum=p.Sum,
                          Price=p.Price,
                          check1= p.check1,
                          UserName=p.admin.UserName,
                          CreateTime= p.CreateTime,
                       

                      };
            if (id != 0)
            {
                obj = obj.Where(p => p.ckID == id);
            } else if (check!=""&&check!=null) {
                obj = obj.Where(p => p.check1 == check);
            }
            list.DataList = obj = obj.OrderBy(p => p.ckID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            list.PageCount = obj.Count();
            return list;
        }
        /// <summary>
        /// 报损管理
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageList GetBaoSun(int pageIndex, int pageSize, int? id,string check)
        {
            warehouseEntities entities = new warehouseEntities();
            PageList list = new PageList();

            var obj = from b in entities.bs
                      from p in entities.product
                      from a in entities.admin
                      where b.ProductID==p.ProductID&&b.CreateUser==a.ID
                      select new
                      {
                          bsID= b.bsID,
                          BsType= b.BsType,
                          ProductName=b.product.ProductName,
                          Count= b.Count,
                          check1=b.check1,
                          UserName= b.admin.UserName,
                          CreateTime= b.CreateTime

                      };
            if (id != 0)
            {
                obj = obj.Where(p => p.bsID == id);
            }
            else if (check != "" && check != null) {
                obj = obj.Where(p=>p.check1==check);
            }
            list.DataList= obj.OrderBy(p => p.bsID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            list.PageCount = obj.Count();
            return list;
        }

        /// <summary>
        /// 根据单号查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IQueryable RuDanHao(int id) 
        {
            warehouseEntities entities = new warehouseEntities();
            var obj = from p in entities.rk where p.ID == id select new 
            {
                ID = p.ID,
                rkType = p.rkType,
                rkSupplier = p.rkSupplier,
                Sum = p.Sum,
                Price = p.Price,
                check1 = p.check1,
                CreateUser = p.CreateUser,
                CreateTime = p.CreateTime.ToString(),
            };

            return obj;
        }
        public static PageList Queryyk(int pageIndex, int pageSize, int? id, string check) {
            PageList list = new PageList();
            warehouseEntities entities = new warehouseEntities();
            var obj =
                from y in entities.yk
                from r in entities.rk
                from a in entities.admin
                where y.Rkid == r.ID && y.CreateUser == a.ID
                select new
                {
                    ykID=y.ykID,
                    ykType=y.ykType,
                    Count=y.Count,
                    check1=y.check1,
                    UserName=y.admin.UserName,
                    CreateTime= y.CreateTime,

                };
            if (id != 0)
            {
                obj = obj.Where(p => p.ykID == id);
            }
            else if (check != "" && check != null)
            {
                obj = obj.Where(p => p.check1 == check);
            }
            list.DataList  = obj.OrderBy(p => p.ykID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            list.PageCount = obj.Count();

            return list;
        }
        public static PageList Queryth(int pageIndex, int pageSize, int? id, string check) {
            PageList list = new PageList();
            warehouseEntities entities = new warehouseEntities();
            var obj =
                from t in entities.th
                from c in entities.ck
                from a in entities.admin
                where t.ckid == c.ckID && c.CreateUser == a.ID
                select new
                {
                    thID=t.thID,
                    thType=t.thType,
                    Count= t.Count,
                    check1=t.check1,
                    UserName=t.admin.UserName,
                    CreateTime=t.CreateTime
                };
            if (id != 0)
            {
                obj = obj.Where(p => p.thID == id);
            }
            else if (check != "" && check != null)
            {
                obj = obj.Where(p => p.check1 == check);
            }
            list.DataList= obj.OrderBy(p => p.thID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            list.PageCount = obj.Count();

            return list;
        }
    }
}
