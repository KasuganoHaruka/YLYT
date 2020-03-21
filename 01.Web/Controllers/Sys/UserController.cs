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
    /// 用户控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        /// <summary>
        /// 数据访问对象
        /// </summary>
        private readonly IBaseLogic _logic;
        public UserController(IBaseLogic logic)
        {
            this._logic = logic;
        }

        #region Insert

        [HttpPost("Insert")]
        public async Task<object> Insert(Sys_User ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().Insert(ent);
        }

        [HttpPost("InsertReturnIdentity")]
        public async Task<object> InsertReturnIdentity(Sys_User ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().InsertReturnIdentity(ent);
        }

        [HttpPost("InsertRange")]
        public async Task<object> InsertRange(Sys_User[] ents)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().InsertRange(ents);
        }

        #endregion


        #region Delete

        [HttpPost("DeleteById")]
        public async Task<object> DeleteById(string id)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().DeleteById(id);
        }

        [HttpPost("Delete")]
        public async Task<object> Delete(Sys_User ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().Delete(ent);
        }

        [HttpPost("DeleteByIds")]
        public async Task<object> DeleteByIds(string[] ids)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().DeleteByIds(ids);
        }

        #endregion


        #region Update

        [HttpPost("Update")]
        public async Task<object> Update(Sys_User ent)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().Update(ent);
        }

        [HttpPost("UpdateRange")]
        public async Task<object> UpdateRange(Sys_User[] ents)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().UpdateRange(ents);
        }

        #endregion


        #region Query

        [HttpPost("GetList")]
        public async Task<object> GetList()
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().GetList();
        }

        [HttpPost("GetPageList")]
        public async Task<object> GetPageList(PageModel page)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().GetPageList(new List<IConditionalModel>(), page);
        }

        [HttpPost("GetById")]
        public async Task<object> GetById(string id)
        {
            return _logic.GetDbClient().GetSimpleClient<Sys_User>().GetById(id);
        }

        #endregion
    }
}