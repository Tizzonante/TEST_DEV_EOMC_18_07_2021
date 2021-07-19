using System;
using Toka.BaseServices.Common.Model.Dto;
using Toka.BaseServices.Common.Repository.Db.Impl;

namespace Toka.BaseServices.Common.Repository.Db
{
    public interface IBaseRepositoryDataBase : IDisposable
    {
        void SetDatabase(ConnectionDataDto connectionDto);

        BaseDbContext CreateBaseDbContext();
    }
}
