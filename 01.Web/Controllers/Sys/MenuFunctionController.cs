using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02.Entitys.ORM;
using _03.Logic.Interface;
using _04.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace _01.Web.Controllers.Sys
{

    /// <summary>
    /// 菜单按钮功能控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MenuFunctionController : BaseController
    {

        /// <summary>
        /// 数据访问对象
        /// </summary>
        private readonly IBaseLogic _logic;
        public MenuFunctionController(IBaseLogic logic)
        {
            this._logic = logic;
        }

        #region Insert

        [HttpPost("Insert")]
        public async Task<object> Insert(Sys_MenuFunction ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().Insert(ent);
        }

        [HttpPost("InsertReturnIdentity")]
        public async Task<object> InsertReturnIdentity(Sys_MenuFunction ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().InsertReturnIdentity(ent);
        }

        [HttpPost("InsertRange")]
        public async Task<object> InsertRange(Sys_MenuFunction[] ents)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().InsertRange(ents);
        }

        #endregion


        #region Delete

        [HttpPost("DeleteById")]
        public async Task<object> DeleteById(string id)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().DeleteById(id);
        }

        [HttpPost("Delete")]
        public async Task<object> Delete(Sys_MenuFunction ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().Delete(ent);
        }

        [HttpPost("DeleteByIds")]
        public async Task<object> DeleteByIds(string[] ids)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().DeleteByIds(ids);
        }

        #endregion


        #region Update

        [HttpPost("Update")]
        public async Task<object> Update(Sys_MenuFunction ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().Update(ent);
        }

        [HttpPost("UpdateRange")]
        public async Task<object> UpdateRange(Sys_MenuFunction[] ents)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().UpdateRange(ents);
        }

        #endregion


        #region Query

        [HttpPost("GetList")]
        public async Task<object> GetList()
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().GetList();
        }

        [HttpPost("GetPageList")]
        public async Task<object> GetPageList(PageModel page)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().GetPageList(new List<IConditionalModel>(), page);
        }

        [HttpPost("GetById")]
        public async Task<object> GetById(string id)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_MenuFunction>().GetById(id);
        }

        #endregion
    }
}