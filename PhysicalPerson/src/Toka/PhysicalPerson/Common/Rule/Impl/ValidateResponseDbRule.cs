using System;
using Toka.BaseServices.Common.Exceptions;
using Toka.BaseServices.Common.Model.Repository.Db;
using Toka.BaseServices.Common.Rule;

namespace Toka.PhysicalPerson.Common.Rule.Impl
{
    public class ValidateResponseDbRule : BaseRule, IValidateResponseDbRule
    {
        public void Validate(ResponseDb responseDatabase)
        {
            if (null != responseDatabase && responseDatabase.ERROR < 0)
            {
                throw new TokaBaseException(responseDatabase.MENSAJEERROR);
            }
        }
    }

}
