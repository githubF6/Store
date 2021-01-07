using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
   public class Yservice
    {
    
        public static PageList GetRuKu(int page,int limit,int id) 
        {
            PageList list = new PageList();
            list.PageCount = dao.Ydao.Count();
            list.DataList = dao.Ydao.GetRuKu(page,limit,id);
            return list;
        }

        public static IQueryable RuDanHao(int id) 
        {
            return dao.Ydao.RuDanHao(id);
        }
    }
}
