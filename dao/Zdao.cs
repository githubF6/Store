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
        //用户初始全查询
        public IQueryable queryyh() {
            var dl = from aa in war.admin select new
            {
                ID =aa.ID,
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
        public IQueryable queryyh(int id) {
                var dl = from aa in war.admin
                         where aa.ID == id
                         select new
                         {
                             ID = aa.ID,
                             UserName = aa.UserName,
                             Password = aa.Password,
                             zsName = aa.zsName,
                             Email = aa.Email,
                             Phone = aa.Phone,
                             CreateTime = aa.CreateTime,
                             Status = aa.Status
                         };
                return dl;
        }
        public IQueryable queryyh(string name)
        {
            var dl = from aa in war.admin
                     where (aa.UserName.Contains(name))
                     select new
                     {
                         ID = aa.ID,
                         UserName = aa.UserName,
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
