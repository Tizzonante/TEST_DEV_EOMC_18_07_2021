using Toka.PhysicalPerson.Common.Model;

namespace Toka.PhysicalPerson.Update.Service
{
    public interface IPhysicalPUpdateService
    {
        PhysicalPDb Update(PhysicalPDb physicaldb, int userId);
    }
}
