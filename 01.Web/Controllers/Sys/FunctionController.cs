using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02.Entitys.ORM;
using _04.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace _01.Web.Controllers.Sys
{

    /// <summary>
    /// 功能按钮控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : BaseController
    {
      
        #region Insert

        [HttpPost("Insert")]
        public async Task<object> Insert(Sys_Function ent)
        {
            return _DbClient.GetSimpleClient<Sys_Function>().Insert(ent);
        }

        [HttpPost("InsertReturnIdentity")]
        public async Task<object> InsertReturnIdentity(Sys_Function ent)
        {
            return _DbClient.GetSimpleClient<Sys_Function>().InsertReturnIdentity(ent);
        }

        [HttpPost("InsertRange")]
        public async Task<object> InsertRange(Sys_Function[] ents)
        {
            return _DbClient.GetSimpleClient<Sys_Function>().InsertRange(ents);
        }

        #endregion


        #region Delete

        [HttpPost("DeleteById")]
        public async Task<object> DeleteById(string id)
        {
            return _DbClient.GetSimpleClient<Sys_Function>().DeleteById(id);
        }

        [HttpPost("Delete")]
        public async Task<object> Delete(Sys_Function ent)
        {
            return _DbClient.GetSimpleClient<Sys_Function>().Delete(ent);
        }

        [HttpPost("DeleteByIds")]
        public async Task<object> DeleteByIds(string[] ids)
        {
            return _DbClient.GetSimpleClient<Sys_Function>().DeleteByIds(ids);
        }

        #endregion


        #region Update

        [HttpPost("Update")]
        public async Task<object> Update(Sys_Function ent)
        {
            return _DbClient.GetSimpleClient<Sys_Function>().Update(ent);
        }

        [HttpPost("UpdateRange")]
        public async Task<object> UpdateRange(Sys_Function[] ents)
        {
            return _DbClient.GetSimpleClient<Sys_Function>().UpdateRange(ents);
        }

        #endregion


        #region Query

        [HttpPost("GetList")]
        public async Task<object> GetList()
        {
            return _DbClient.GetSimpleClient<Sys_Function>().GetList();
        }

        [HttpPost("GetPageList")]
        public async Task<object> GetPageList(PageModel page)
        {
            return _DbClient.GetSimpleClient<Sys_Function>().GetPageList(new List<IConditionalModel>(), page);
        }

        [HttpPost("GetById")]
        public async Task<object> GetById(string id)
        {
            return _DbClient.GetSimpleClient<Sys_Function>().GetById(id);
        }

        #endregion


    }


}