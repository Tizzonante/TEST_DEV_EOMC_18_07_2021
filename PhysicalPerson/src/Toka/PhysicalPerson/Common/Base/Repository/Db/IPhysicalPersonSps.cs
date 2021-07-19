using System.Collections.Generic;
using Toka.BaseServices.Common.Model.Repository.Db;
using Toka.BaseServices.Common.Repository.Db;
using Toka.PhysicalPerson.Common.Model;

namespace Toka.PhysicalPerson.Common.Base.Repository.Db
{
    public interface IPhysicalPersonSps<T> : IBaseSpExecutor<T> where T : class
    {
        ResponseDb CreateNew(PhysicalPDb physicaldb, int UserId);
        
        //Read
        List<PhysicalPDb> GetAllPhysicalPersons();
        T GetPhysicalPById(int idPhysicalPerson);

        ResponseDb Update(PhysicalPDb physicaldb, int UserId);

        ResponseDb Delete(int idPhysicalP);
    }
}
