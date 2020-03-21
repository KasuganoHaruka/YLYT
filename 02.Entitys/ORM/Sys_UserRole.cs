using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace _02.Entitys.ORM
{
    ///<summary>
    ///
    ///</summary>
    public partial class Sys_UserRole
    {
        public Sys_UserRole()
        {
        }
        /// <summary>
        /// Desc:
        /// Default:newid()
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public Guid UserRole_ID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Guid UserRole_UserID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Guid UserRole_RoleID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:DateTime.Now
        /// Nullable:True
        /// </summary>           
        public DateTime UserRole_CreateTime { get; set; }

    }
}
