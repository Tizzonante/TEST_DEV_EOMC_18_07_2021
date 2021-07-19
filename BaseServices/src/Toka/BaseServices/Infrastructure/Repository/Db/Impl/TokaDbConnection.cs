using Toka.BaseServices.Common.Constant.Db.ConnectionData;
using Toka.BaseServices.Common.Model.Dto;

namespace Toka.BaseServices.Infrastructure.Repository.Db.Impl
{
    public class TokaDbConnection : ConnectionDataDto, ITokaDbConnection
    {
        public TokaDbConnection()
        {
            Server = TokaDbConnectionConst.Server;
            User = TokaDbConnectionConst.User;
            PassWord = TokaDbConnectionConst.PassWord;
            DataBase = TokaDbConnectionConst.DataBase;
            ApplicationName = TokaDbConnectionConst.ApplicationName;
        }
    }
}
