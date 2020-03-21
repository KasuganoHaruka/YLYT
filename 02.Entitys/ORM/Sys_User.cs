using SqlSugar;
using System;


namespace _02.Entitys.ORM
{
    ///<summary>
    ///
    ///</summary>
    public partial class Sys_User
    {
           public Sys_User(){


           }
           /// <summary>
           /// Desc:
           /// Default:newid()
           /// Nullable:False
           /// </summary>        
           [SugarColumn(IsPrimaryKey = true)]
           public Guid User_ID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string User_Name {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string User_LoginName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string User_Pwd {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string User_Email {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? User_IsDelete {get;set;}

           /// <summary>
           /// Desc:
           /// Default:DateTime.Now
           /// Nullable:True
           /// </summary>           
           public DateTime? User_CreateTime {get;set;}

    }
}
