using System.Data.Common;
using System.Data.Entity;

namespace Toka.BaseServices.Common.Repository.Db.Impl
{
    public class BaseDbContext : DbContext, IBaseDbContext
    {
        //eomc
        public BaseDbContext(string stringConnection) : base(stringConnection)
        {

        }

        public BaseDbContext(DbConnection dataDto) : base(dataDto, true)
        {

        }
    }
}
