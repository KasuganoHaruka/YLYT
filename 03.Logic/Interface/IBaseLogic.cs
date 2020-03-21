using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Logic.Interface
{
    public interface IBaseLogic
    {
        SqlSugarClient GetDbClient();
    }


}
