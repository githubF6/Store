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
        public static int Count() 
        {
            return dao.Ydao.Count();
        }
        public static PageList GetRuKu(int page,int limit) 
        {
            PageList list = new PageList();
            list.PageCount = dao.Ydao.Count();
            list.DataList = dao.Ydao.GetRuKu(page,limit);
            return list;
        }
    }
}
