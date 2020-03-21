using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _04.DAL
{
    public interface ICoreDb
    {

        SqlSugarClient GetDbClient();

        //#region Insert

        //bool Insert<T>(T ent) where T : class, new() where T : class, new();
        
        //bool InsertRange<T>(T[] ents) where T : class, new();

        //int InsertReturnIdentity<T>(T ent) where T : class, new();

        //#endregion


        //#region Delete

        //bool DeleteById<T>(string id) where T : class, new();

        //bool Delete<T>(T ent) where T : class, new();

        //bool DeleteByIds<T>(string[] ids) where T : class, new();

        //#endregion


        //#region Update

        //bool Update<T>(T ent) where T : class, new();

        //bool UpdateRange<T>(T[] ents) where T : class, new();

        //#endregion


        //#region Query

        //List<T> GetList<T>() where T : class, new();

        //List<T> GetPageList<T>(PageModel page) where T : class, new();

        //T GetById<T>(string id) where T : class, new();

        //#endregion


    }
}
