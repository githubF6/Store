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
            PageList list = new PageList();
            list.PageCount = dao.Ydao.Count();
            list.DataList = dao.Ydao.GetRuKu(page,limit,id,check);
            return list;
        }

        public static PageList GetChuKu(int page, int limi,int id,string check) 
        {
            PageList list = new PageList();
            list.PageCount = dao.Ydao.Count();
            list.DataList = dao.Ydao.GetChuKu(page, limi,id,check);
            return list;
        }

        public static PageList GetBaoSun(int page, int limi, int id,string check)
        {
            PageList list = new PageList();
            list.PageCount = dao.Ydao.Count();
            list.DataList = dao.Ydao.GetBaoSun(page, limi,id,check);
            return list;
        }

        public static IQueryable RuDanHao(int id) 
        {
            return dao.Ydao.RuDanHao(id);
        }
        public static PageList Queryyk(int page, int limi, int id, string check) {
            PageList list = new PageList();
            list.PageCount = dao.Ydao.Count();
            list.DataList = dao.Ydao.Queryyk(page, limi, id, check);
            return list;
        }
        public static PageList Queryth(int page, int limi, int id, string check)
        {
            PageList list = new PageList();
            list.PageCount = dao.Ydao.Count();
            list.DataList = dao.Ydao.Queryth(page, limi, id, check);
            return list;
        }
    }
}
