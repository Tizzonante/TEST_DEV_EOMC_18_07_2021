using Toka.BaseServices.Common.Model.Repository.Db;
using Toka.BaseServices.Common.Service;
using Toka.PhysicalPerson.Common.Base.Repository.Db;
using Toka.PhysicalPerson.Common.Model;
using Toka.PhysicalPerson.Common.Rule;

namespace Toka.PhysicalPerson.Delete.Service.Impl
{
    public class PhysicalPDeleteService : BaseService, IPhysicalPDeleteService
    {
        private IPhysicalPersonSps<PhysicalPDb> storeProc;
        private IValidateResponseDbRule rule;

        public PhysicalPDeleteService(IPhysicalPersonSps<PhysicalPDb> storeProc, IValidateResponseDbRule rule)
        {
            this.storeProc = storeProc;
            this.rule = rule;
        }

        public PhysicalPDb Delete(int idPhysicalP, int userId)
        {
            PhysicalPDb response = null;

            Log.Debug("{0} The user with user Id: {0} will delete a physical Person with Id: {1}", userId, idPhysicalP);
            ResponseDb responseDb = storeProc.Delete(idPhysicalP);

            rule.Validate(responseDb);

            response = new PhysicalPDb
            {
                IdPersonaFisica = idPhysicalP
            };

            return response;
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
