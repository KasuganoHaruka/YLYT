using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace _02.Entitys.ORM
{
    ///<summary>
    ///
    ///</summary>
    public partial class Sys_MenuFunction
    {
           public Sys_MenuFunction(){


           }
        /// <summary>
        /// Desc:
        /// Default:newid()
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public Guid MenuFunction_ID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Guid? MenuFunction_MenuID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Guid? MenuFunction_FunctionID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:DateTime.Now
           /// Nullable:True
           /// </summary>           
           public DateTime? MenuFunction_CreateTime {get;set;}

    }
}
