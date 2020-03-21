using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _02.Entitys.ORM;
using _03.Logic.Interface;
using _03.Logic.Sys;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace _01.Web.Controllers.Sys
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseController
    {

        /// <summary>
        /// 数据访问对象
        /// </summary>
        private readonly IMenuLogic _logic;
        public MenuController(IMenuLogic logic)
        {
            this._logic = logic;
        }


        #region Insert

        [HttpPost("Insert")]
        public async Task<object> Insert(Sys_Menu ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().Insert(ent);
        }

        [HttpPost("InsertReturnIdentity")]
        public async Task<object> InsertReturnIdentity(Sys_Menu ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().InsertReturnIdentity(ent);
        }

        [HttpPost("InsertRange")]
        public async Task<object> InsertRange(Sys_Menu[] ents)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().InsertRange(ents);
        }

        #endregion


        #region Delete

        [HttpPost("DeleteById")]
        public async Task<object> DeleteById(string id)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().DeleteById(id);
        }

        [HttpPost("Delete")]
        public async Task<object> Delete(Sys_Menu ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().Delete(ent);
        }

        [HttpPost("DeleteByIds")]
        public async Task<object> DeleteByIds(string[] ids)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().DeleteByIds(ids);
        }

        #endregion


        #region Update

        [HttpPost("Update")]
        public async Task<object> Update(Sys_Menu ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().Update(ent);
        }

        [HttpPost("UpdateRange")]
        public async Task<object> UpdateRange(Sys_Menu[] ents)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().UpdateRange(ents);
        }

        #endregion


        #region Query

        [HttpPost("GetList")]
        public async Task<object> GetList()
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().GetList();
        }

        [HttpPost("GetPageList")]
        public async Task<object> GetPageList(PageModel page)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().GetPageList(new List<IConditionalModel>(), page);
        }

        [HttpPost("GetById")]
        public async Task<object> GetById(string id)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_Menu>().GetById(id);
        }

        #endregion


        #region Logic

        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetMenuData")]
        public async Task<object> GetMenuData()
        {
            return _logic.GetMenuData();
        }


        /// <summary>
        /// 根据角色ID 获取菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetMenuByRoleID")]
        public async Task<object> GetMenuByRoleID()
        {
            return _logic.GetMenuByRoleID(CurrentAccount).Result;
        }

   
        #endregion

    }
}