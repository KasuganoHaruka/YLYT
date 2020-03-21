using _02.Entitys;
using _02.Entitys.ORM;
using _04.DAL;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _03.Logic
{
    public class AccounttLogic
    {
        /// <summary>
        /// 数据访问对象
        /// </summary>
        public SqlSugarClient DbClient => new SqlSugarDbContext().DbClient;

        /// <summary>
        /// 根据用户信息获取 Account 对象
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public async Task<Account> GetAccountByUser(Sys_User User)
        {
            var _Account = new Account();


            var aa = DbClient.GetSimpleClient<Sys_UserRole>().GetById(User.User_ID);

            var _RoleList = DbClient.Queryable<Sys_UserRole>().Where(m1 => m1.UserRole_UserID == User.User_ID).Select(m1 => m1.UserRole_RoleID).ToList();
            var _RoleList1 = DbClient.Queryable<Sys_UserRole>().Where(m1 => m1.UserRole_UserID == User.User_ID).Select(m1 => (Guid)m1.UserRole_ID).ToList();
            var _RoleList2 = DbClient.Queryable<Sys_UserRole>().Where(m1 => m1.UserRole_UserID == User.User_ID).Select(m1 => (Guid)m1.UserRole_UserID).ToList();
            var _RoleList3 = DbClient.Queryable<Sys_UserRole>().Where(m1 => m1.UserRole_UserID == User.User_ID).Select(m1 => m1.UserRole_CreateTime).ToList();


            _Account.RoleIDList = _RoleList;//_Sys_UserRole.Select(w => w.UserRole_RoleID.ToGuid()).ToList();
            _Account.User = User;
            _Account.IsSuperManage = false;

            return _Account;
        }

    }
}
