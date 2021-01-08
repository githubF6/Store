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
        public static IQueryable GetRuKu(int pageIndex, int pageSize,int? id,string check) 
        {
           
            warehouseEntities entities = new warehouseEntities();
            PageList list = new PageList();
            
            var obj = from p in entities.rk
                      //where p.ID == id 
                      //orderby p.ID  
                      select new 
            {
                ID= p.ID  ,
                rkType = p.rkType ,
                rkSupplier = p.rkSupplier,
                Sum=  p.Sum ,
                Price=    p.Price ,
                check1= p.check1   ,
                CreateUser= p.CreateUser  ,
                CreateTime=  p.CreateTime.ToString() ,
                supplierName= p.supplier.supplierName,

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
            
            return obj=obj.OrderBy(p=>p.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize) ;
        }

        /// <summary>
        /// 出库管理
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IQueryable GetChuKu(int pageIndex, int pageSize,int? id)
        {
            warehouseEntities entities = new warehouseEntities();
            PageList list = new PageList();

            var obj = from p in entities.ck
                         
                      select new
                      {
                        ckID = p.ckID           ,
                       CkType = p.CkType          ,
                        Ckclient = p.Ckclient     ,
                        Sum = p.Sum               ,
                       Price = p.Price            ,
                          check1 = p.check1       ,
                       CreateUser = p.CreateUser  ,
                       CreateTime = p.CreateTime  ,
                     Status = p.Status            
                      };
            if (id!=0) 
            {
                obj = obj.Where(p => p.ckID == id);
            }
            return obj = obj.OrderBy(p => p.ckID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        /// <summary>
        /// 报损管理
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IQueryable GetBaoSun(int pageIndex, int pageSize, int? id)
        {
            warehouseEntities entities = new warehouseEntities();
            PageList list = new PageList();

            var obj = from p in entities.bs
                         
                      select new
                      {
                          bsID = p.bsID,       
                          BsType = p.BsType      ,
                          ProductID = p.ProductID   ,
                          Count = p.Count       ,
                          check1 = p.check1       ,
                          CreateUser = p.CreateUser  ,
                          CreateTime = p.CreateTime  ,
                          Status = p.Status
                          

                      };
            if (id != 0)
            {
                obj = obj.Where(p => p.bsID == id);
            }
            return obj = obj.OrderBy(p => p.bsID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
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
    }
}
