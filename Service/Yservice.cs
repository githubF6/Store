using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using dao;


namespace Service
{
   public class Yservice
    {
    
        public static PageList GetRuKu(int page,int limit,int id,string check) 
        {

            return dao.Ydao.GetRuKu(page, limit, id, check);
        }

        public static PageList GetChuKu(int page, int limi,int id,string check) 
        {
            
            return dao.Ydao.GetChuKu(page, limi, id, check);
        }

        public static PageList GetBaoSun(int page, int limi, int id,string check)
        {
            
            return dao.Ydao.GetBaoSun(page, limi, id, check);
        }

        public static IQueryable RuDanHao(int id) 
        {
            return dao.Ydao.RuDanHao(id);
        }
        public static PageList Queryyk(int page, int limi, int id, string check) {
            
            return dao.Ydao.Queryyk(page, limi, id, check);
        }
        public static PageList Queryth(int page, int limi, int id, string check)
        {
         
            return dao.Ydao.Queryth(page, limi, id, check);
        }
        //添加移库
        public static int addyk(yk lo)
        {
            return dao.Ydao.addyk(lo);
        }
        //添加退货
        public static int addth(th hh)
        {
            return dao.Ydao.addth(hh);
        }
        //移库类型查询
        public static IQueryable yktype(string yklx)
        {
            return dao.Ydao.yktype(yklx);
        }
        //修改移库
        public static int Edit(yk s)
        {
            return dao.Ydao.Edit(s);
        }
    }
}
