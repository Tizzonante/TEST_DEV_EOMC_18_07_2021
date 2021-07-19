using Toka.BaseServices.Common.Model.Repository.Db;
using Toka.BaseServices.Common.Service;
using Toka.PhysicalPerson.Common.Base.Repository.Db;
using Toka.PhysicalPerson.Common.Model;
using Toka.PhysicalPerson.Common.Rule;

namespace Toka.PhysicalPerson.Update.Service.Impl
{
    public class PhysicalPUpdateService : BaseService, IPhysicalPUpdateService
    {
        private IPhysicalPersonSps<PhysicalPDb> storeProc;
        private IValidateResponseDbRule rule;

        public PhysicalPUpdateService(IPhysicalPersonSps<PhysicalPDb> storeProc, IValidateResponseDbRule rule)
        {
            this.storeProc = storeProc;
            this.rule = rule;
        }

        public PhysicalPDb Update(PhysicalPDb physicaldb, int userId)
        {
            ResponseDb responseDb = storeProc.Update(physicaldb, userId);

            rule.Validate(responseDb);

            return storeProc.GetPhysicalPById(responseDb.ERROR);
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
