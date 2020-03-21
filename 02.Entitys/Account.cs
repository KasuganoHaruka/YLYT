using _02.Entitys.Interfaca;
using _02.Entitys.ORM;
using System;
using System.Collections.Generic;

namespace _02.Entitys
{
    /// <summary>
    /// 
    /// </summary>
    public class Account : IBaseClass
    {
       
        /// <summary>
        /// 角色ID
        /// </summary>
        public List<Guid> RoleIDList { get; set; }
    
        /// <summary>
        /// 当前登录人 是否是 超级管理员
        /// </summary>
        public bool IsSuperManage { get; set; }

        /// <summary>
        /// User对象
        /// </summary>
        public Sys_User User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Account()
        {
            this.IsSuperManage = false;
        }
    }
}
