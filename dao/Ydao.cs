﻿using System;
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
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IQueryable GetRuKu(int pageIndex, int pageSize,int? id) 
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
            };
            
            if (id!=0)
            {
                Debug.WriteLine("sdsd"+id);
                obj = obj.Where(p => p.ID == id).OrderByDescending(p => p.ID);

            }
            else {
                obj = obj.OrderByDescending(p => p.ID!=0);
            }
            return obj=obj.Skip((pageIndex - 1) * pageSize).Take(pageSize) ;
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
