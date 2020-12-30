using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace dao
{
    public class Gdao
    {
        warehouseEntities entity = new warehouseEntities();
        public List<admin> Login(string username,string password) {

            return entity.admin.Where(p => p.UserName == username && p.Password == password).ToList();
            //var obj = (
            //   from admin in entity.admin.Where(p => p.UserName == username && p.Password == password).Count()
            //    )
        }
    }
}
