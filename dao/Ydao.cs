using System;
using System.Collections.Generic;
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


        public static IQueryable GetRuKu(int pageIndex, int pageSize) 
        {
            warehouseEntities entities = new warehouseEntities();
            PageList list = new PageList();
            var obj = from p in entities.rk orderby p.ID select new 
            {
                ID= p.ID  ,
                rkType = p.rkType ,
                rkSupplier = p.rkSupplier,
                Sum=  p.Sum ,
                Price=    p.Price ,
                check1= p.check1   ,
                CreateUser= p.CreateUser  ,
                CreateTime=  p.CreateTime.ToString() ,
            };
            return obj.Skip((pageIndex - 1) * pageSize).Take(pageSize) ;
        }
    }
}
