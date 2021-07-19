using System.Collections.Generic;
using Toka.BaseServices.Common.Service;
using Toka.PhysicalPerson.Common.Base.Repository.Db;
using Toka.PhysicalPerson.Common.Model;

namespace Toka.PhysicalPerson.Read.Service.Impl
{
    public class PhysicalPReadService : BaseService, IPhysicalPReadService
    {
        private IPhysicalPersonSps<PhysicalPDb> storeProc;

        public PhysicalPReadService(IPhysicalPersonSps<PhysicalPDb> storeProc)
        {
            this.storeProc = storeProc;
        }

        public List<PhysicalPDb> GetAll()
        {
            return storeProc.GetAllPhysicalPersons();
        }

        public PhysicalPDb GetById(int idPhysicalPerson)
        {
            return storeProc.GetPhysicalPById(idPhysicalPerson);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                base.Dispose(disposing);
                if (disposing)
                {
                    if (null != storeProc)
                    {
                        storeProc.Dispose();
                        storeProc = null;
                    }
                }
            }

        }
    }
}
