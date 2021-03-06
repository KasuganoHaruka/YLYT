﻿using _02.Entitys;
using _02.Entitys.ORM;
using SqlSugar;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using _04.DAL;
using _03.Logic.Interface;
using System;

namespace _03.Logic.Sys
{

    public class MenuLogic : IMenuLogic
    {
        private readonly ICoreDb _iCoreDb;
        public MenuLogic(ICoreDb iCoreDb)
        {
            this._iCoreDb = iCoreDb;
        }

        public SqlSugarClient GetDbClient() { return _iCoreDb.GetDbClient(); }


        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <returns></returns>
        public object GetMenuData()
        {
            var menuList = GetDbClient().Queryable<Sys_Menu, Sys_Menu>((m1, m2) => new object[] {
                JoinType.Left,m1.Menu_ParentID == m2.Menu_ID})
                .Where((m1, m2) => m1.Menu_IsShow == 1 && m2.Menu_IsShow == 1)
                .Select((m1, m2) => new
                {
                    m1.Menu_ID,
                    m1.Menu_Num,
                    m1.Menu_Name,
                    m1.Menu_Url,
                    m1.Menu_Icon,
                    m1.Menu_ParentID,
                    m1.Menu_IsShow,
                    Parent_Name = m2.Menu_Name,
                    Parent_IsShow = m2.Menu_IsShow
                }).OrderBy((m1) => m1.Menu_Num).ToList();

            return menuList;
        }

        /// <summary>
        /// 根据角色ID 获取菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<Sys_Menu>> GetMenuByRoleID(Account account)
        {

            if (account.IsSuperManage)
                return _iCoreDb.GetDbClient().Queryable<Sys_Menu>().Where(m1 => m1.Menu_IsShow == 1).OrderBy(m1 => m1.Menu_Num).ToList();

            var RoleMenuList = _iCoreDb.GetDbClient().Queryable<Sys_RoleMenuFunction, Sys_Menu, Sys_Function>((m1, m2, m3) =>
                SqlFunc.Subqueryable<Sys_RoleMenuFunction>().Where(p => account.RoleIDList.Contains((Guid)p.RoleMenuFunction_RoleID)).Any()

                //_Account.RoleIDList.Where(a => a == m1.RoleMenuFunction_RoleID).Any()
                && m1.RoleMenuFunction_MenuID == m2.Menu_ID
                && m1.RoleMenuFunction_FunctionID == m3.Function_ID
            ).OrderBy((m1, m2) => m2.Menu_Num).Select<Sys_Menu>().ToList();

            var NewMenuList = new List<Sys_Menu>();

            foreach (var item in RoleMenuList)
            {
                if (!NewMenuList.Any(w => w.Menu_ID == item.Menu_ID)) NewMenuList.Add(item);
            }
            return NewMenuList;
        }

    }
}
