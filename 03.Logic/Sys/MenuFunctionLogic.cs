using _02.Entitys;
using _02.Entitys.ORM;
using SqlSugar;


namespace _03.Logic.Sys
{

    public class MenuFunctionLogic
    {

        public MenuFunctionLogic(SqlSugarClient DbClient)
        {
            this.DbClient = DbClient;
        }

        private SqlSugarClient DbClient;


        /// <summary>
        /// 获取菜单功能数据
        /// </summary>
        /// <returns></returns>
        public  object GetMenuFunctionData()
        {
            //不需要用LEFT JOIN或者 RIGHT JOIN 只是单纯的INNER JOIN时
            //var menuList = DbClient.Queryable<Sys_Menu, Sys_Menu>((m1, m2) => m1.Menu_ParentID == m2.Menu_ID)
            //    .Select((m1, m2) => new
            //    {
            //        m1.Menu_ID,
            //        m1.Menu_Num,
            //        m1.Menu_Name,
            //        m1.Menu_Url,
            //        m1.Menu_Icon,
            //        m1.Menu_ParentID,
            //        m1.Menu_IsShow,
            //        Parent_Name = m2.Menu_Name,
            //        Parent_IsShow = m2.Menu_IsShow
            //    }).OrderBy((m1) => m1.Menu_Num).ToList();

            var menuList = DbClient.Queryable<Sys_Menu, Sys_Menu>((m1, m2) => new object[] {
                JoinType.Left,m1.Menu_ParentID == m2.Menu_ID})
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
    }
}
