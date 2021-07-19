using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Toka.BaseServices.Common.Constant.Messages;
using Toka.BaseServices.Common.Exceptions;
using Toka.BaseServices.Common.Model.Dto;

namespace Toka.BaseServices.Common.Repository.Db.Impl
{
    public class BaseSpExecutor<T> : BaseRepository, IBaseSpExecutor<T> where T : class
    {
        private IBaseRepositoryDataBase baseRepo;

        public BaseSpExecutor(IBaseRepositoryDataBase baseRepositoryDataBase)
        {
            this.baseRepo = baseRepositoryDataBase;
        }

        public void SetDatabase(ConnectionDataDto connectionDto)
        {
            baseRepo.SetDatabase(connectionDto);
        }

        public T InvokeStoreProcedureFirstResult(string query, params SqlParameter[] args)
        {
            return First(InvokeStoreProcedureWithResults(query, args));
        }

        public otherT InvokeStoreProcedureSingleResult<otherT>(string query, params SqlParameter[] args)
        {
            string queryInfo = string.Empty;
            try
            {
                var dbcontext = baseRepo.CreateBaseDbContext();

                WriteLog(query);

                var task = dbcontext.Database.SqlQuery<otherT>(query, args).SingleOrDefaultAsync();
                otherT value = task.Result;

                dbcontext.Dispose();
                return value;
            }
            catch (Exception ex)
            {
                throw new TokaBaseException(BuildMessageException(query), ex);
            }
        }

        public List<T> InvokeStoreProcedureWithResults(string query, params SqlParameter[] args)
        {
            string queryInfo = string.Empty;
            try
            {
                var dbcontext = baseRepo.CreateBaseDbContext();
                WriteLog(query);

                var task = dbcontext.Database.SqlQuery<T>(query, args).ToListAsync();
                List<T> data = task.Result;

                dbcontext.Dispose();
                return data ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new TokaBaseException(BuildMessageException(query), ex);
            }
        }

        public List<otherT> InvokeStoreProcedureWithResults<otherT>(string query, params SqlParameter[] args)
        {
            string queryInfo = string.Empty;
            try
            {
                var dbcontext = baseRepo.CreateBaseDbContext();

                WriteLog(query);
                var task = dbcontext.Database.SqlQuery<otherT>(query, args).ToListAsync();
                List<otherT> data = task.Result;

                dbcontext.Dispose();
                return data ?? new List<otherT>();
            }
            catch (Exception ex)
            {
                throw new TokaBaseException(BuildMessageException(query), ex);
            }
        }

        public void InvokeStoreProcedure(string query, params SqlParameter[] args)
        {
            string queryInfo = string.Empty;
            try
            {
                var dbcontext = baseRepo.CreateBaseDbContext();

                WriteLog(query);

                dbcontext.Database.ExecuteSqlCommand(query, args);
            }
            catch (Exception ex)
            {
                throw new TokaBaseException(BuildMessageException(query), ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                base.Dispose(disposing);
                baseRepo.Dispose();
                baseRepo = null;
            }
        }

        private T First(List<T> list)
        {
            return list?.Count > 0 ? list[0] : null;
        }

        private static string BuildMessageException(string query)
        {
            return String.Format(BaseExceptionMsgConstant.EXCEPTION_DATA_BASE, query);
        }

        private void WriteLog(string query)
        {
            Log.Trace(BaseMsgConstant.QUERY_TO_EXECUTE_DATA_BASE, query);
        }
    }
}
