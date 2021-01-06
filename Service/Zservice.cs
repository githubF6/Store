using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;
using Model;

namespace Service
{
    
    public class Zservice
    {
     Zdao dao = new Zdao();
        public IQueryable queryyh() {
           return dao.queryyh();
        }
        public IQueryable queryyh(string name) {
            try
            {
                var sum = dao.queryyh(name);
                int id = int.Parse(name);
                dao.queryyh(id);
                
                return sum;
            }
            catch (Exception)
            {
                var sum = dao.queryyh(name);
                return sum;
            }
           
        }


    }
}
