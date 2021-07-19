using System.Data.SqlClient;
using Toka.BaseServices.Common.Model.Dto;
using Toka.BaseServices.Infrastructure.Components.Impl;

namespace Toka.BaseServices.Common.Repository.Db.Impl
{
    public class BaseRepositoryDataBase : BaseComponent, IBaseRepositoryDataBase
    {
        private ConnectionDataDto connectionData;

        public void SetDatabase(ConnectionDataDto connectionDto)
        {
            connectionData = connectionDto;
        }

        public BaseDbContext CreateBaseDbContext()
        {
            return new BaseDbContext(GetSqlConnection());
        }

        private SqlConnection GetSqlConnection()
        {
            SqlConnectionStringBuilder aux = new SqlConnectionStringBuilder
            {
                DataSource = connectionData.Server,
                InitialCatalog = connectionData.DataBase,
                UserID = connectionData.User,
                Password = connectionData.PassWord,
                MultipleActiveResultSets = true,
                PersistSecurityInfo = true,
                ApplicationName = connectionData.ApplicationName
            };
            return new SqlConnection(aux.ToString());
        }
    }
}
