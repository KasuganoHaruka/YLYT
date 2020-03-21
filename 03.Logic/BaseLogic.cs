
using _03.Logic.Interface;
using _04.DAL;
using SqlSugar;


namespace _03.Logic
{

    public class BaseLogic : IBaseLogic
    {
        /// <summary>
        /// 数据访问对象
        /// </summary>
        private readonly ICoreDb iCoreDb;
        public BaseLogic(ICoreDb iCoreDb)
        {
            this.iCoreDb = iCoreDb;
        }


        public SqlSugarClient GetDbClient() { return iCoreDb.GetDbClient(); }
    }
}
