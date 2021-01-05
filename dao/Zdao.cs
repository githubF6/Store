using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace dao
{
    public class Zdao
    {
        warehouseEntities war = new warehouseEntities();

        public IQueryable qualy() {
            var dl = from aa in war.admin  select new
            {
                UserName =aa.UserName,
                Password = aa.Password,
                zsName = aa.zsName,
                Email = aa.Email,
                Phone = aa.Phone,
                CreateTime = aa.CreateTime,
                Status = aa.Status
            };
            return dl;
        }
    }
}
