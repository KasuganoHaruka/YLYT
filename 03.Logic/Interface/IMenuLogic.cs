using _02.Entitys;
using _02.Entitys.ORM;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _03.Logic.Interface
{

    public interface IMenuLogic : IBaseLogic
    {

        object GetMenuData();

        Task<List<Sys_Menu>> GetMenuByRoleID(Account _Account);

    }
}
