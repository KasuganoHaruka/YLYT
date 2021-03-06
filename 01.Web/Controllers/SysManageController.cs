﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _03.Logic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace _01.Web.Controllers
{

    /// <summary>
    /// 系统管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SysManageController : BaseController
    {

        private IBaseLogic _logic;

        public SysManageController(IBaseLogic baseLogic)
        {
            this._logic = baseLogic;
        }


        /// <summary>
        /// 生成实体（所有表）
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="NameSpace"></param>
        [HttpPost("CreateAllTable")]
        public async Task<object> CreateAllTable(string FilePath = @"E:\6.代码Demo\YLYT.Core\02.Entitys\ORM", string NameSpace = "_02.Entitys.ORM")
        {
            _logic.GetDbClient().DbFirst.CreateClassFile(FilePath, NameSpace);

            return default;
        }

        /// <summary>
        /// CereatTableEntity
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateTables")]
        public async Task<object> CreateTables(string[] TableNames, string FilePath = @"E:\6.代码Demo\YLYT.Core\02.Entitys\ORM", string NameSpace = "_02.Entitys.ORM")
        {
            _logic.GetDbClient().DbFirst.Where(TableNames).CreateClassFile(FilePath, NameSpace);
            return default;
        }
    }
}