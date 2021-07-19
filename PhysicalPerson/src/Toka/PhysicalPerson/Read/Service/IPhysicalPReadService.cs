using System.Collections.Generic;
using Toka.PhysicalPerson.Common.Model;

namespace Toka.PhysicalPerson.Read.Service
{
    public interface IPhysicalPReadService
    {
        List<PhysicalPDb> GetAll();
        PhysicalPDb GetById(int idPhysicalPerson);
    }
}
