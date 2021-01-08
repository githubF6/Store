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
        //搜索用户
        public IQueryable queryyh() {
            return dao.queryyh();
        }
        public IQueryable queryyh(string name) {
            var sum = dao.queryyh(name);
            return sum;
        }
        public IQueryable queryyh(int id) {
            var sum = dao.queryyh(id);
            return sum;
        }
        //添加用户
        public bool addyh(admin ad)
        {
            return dao.addyh(ad) >0;
        }
        //删除用户
        public bool deleyh(int id)
        {
            return dao.deleyh(id) > 0;
        }
        //修改用户
        public bool updatayh(admin ad) {
            return dao.updatayh(ad) > 0;
        }


    }
}
