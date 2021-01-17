 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Model;

namespace dao
{
    public class Zdao
    {
        warehouseEntities war = new warehouseEntities();


        // 用户初始全查询
        public IQueryable queryyh() {
            var dl = from aa in war.admin select new
            {
                ID = aa.ID,
                UserName = aa.UserName,
                Password = aa.Password,
                Department = aa.department,
                Departmentname = aa.department1.departmentName,
                AdminStatus=aa.AdminStatus.Name,
                IsDelete = aa.AdminStatus.IsDelete > 0 ? "正常" : "封禁",
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
                             Department = aa.department,
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
                         Department = aa.department,
                         Status = aa.Status
                     };
            return dl;
        }
        //用户添加
        public int addyh(admin ad) {
            war.admin.Add(ad);
            return war.SaveChanges();
        }
        //
        public int deleyh(int id) {
            var obj = (from aa in war.admin where aa.ID == id select aa).First();
            obj.AdminStatus.IsDelete = 0;
            return war.SaveChanges();
        }
        public int updatayh(admin ad) {
            var obj = war.Set<admin>().Attach(ad);
            war.Entry<admin>(ad).State = System.Data.Entity.EntityState.Modified;
            return war.SaveChanges();
        }




    }
}
