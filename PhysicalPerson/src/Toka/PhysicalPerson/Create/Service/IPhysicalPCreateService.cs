using Toka.PhysicalPerson.Common.Model;

namespace Toka.PhysicalPerson.Create.Service
{
    public interface IPhysicalPCreateService
    {
        PhysicalPDb CreateNew(PhysicalPDb physicaldb, int userId);
    }
}
