using _02.Entitys.ORM;
using _04.DAL;
using SqlSugar;
using System.Collections.Generic;

namespace _03.BLL
{
    public class LoginService : DbContext
    {
        public List<NLog> GetList()
        {
            return new SimpleClient<NLog>(Db).GetList();
        }

        public NLog GetById(int id)
        {
            return new SimpleClient<NLog>(Db).GetById(id);
        }

        //public int DeleteBy() 
        //{
        //    //Db.Deleteable();
        //}



        
    }
}
