using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;
using Model;

namespace Service
{
    public class Gservice
    {
        public List<admin> Login(string username, string password)
        {
            return new Gdao().Login(username, password);
        }
    }
}
