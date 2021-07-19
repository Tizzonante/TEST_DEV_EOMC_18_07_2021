using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Toka.BaseServices.Common.Model.Dto;

namespace Toka.BaseServices.Common.Repository.Db
{
    public interface IBaseSpExecutor<T>: IDisposable where T : class
    {
        void SetDatabase(ConnectionDataDto connectionDto);

        T InvokeStoreProcedureFirstResult(string query, params SqlParameter[] args);

        otherT InvokeStoreProcedureSingleResult<otherT>(string query, params SqlParameter[] args);

        List<T> InvokeStoreProcedureWithResults(string query, params SqlParameter[] args);

        List<otherT> InvokeStoreProcedureWithResults<otherT>(string query, params SqlParameter[] args);

        void InvokeStoreProcedure(string query, params SqlParameter[] args);
    }
}
