using Toka.PhysicalPerson.Common.Model;

namespace Toka.PhysicalPerson.Delete.Service
{
    public interface IPhysicalPDeleteService
    {
        PhysicalPDb Delete(int idPhysicalP, int userId);
    }
}
