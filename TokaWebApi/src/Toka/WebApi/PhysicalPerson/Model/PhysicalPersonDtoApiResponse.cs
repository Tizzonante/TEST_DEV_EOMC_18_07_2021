using System;
using Toka.BaseServices.Common.Model;

namespace Toka.WebApi.PhysicalPerson.Model
{
    public class PhysicalPersonDtoApiResponse : BaseModel
    {
        public int PhysicalPersonId { get; set; }
        public string Names { get; set; }
        public string LastNameFather { get; set; }
        public string LastNameMother { get; set; }
        public string RFC { get; set; }
        public DateTime? BirthDate { get; set; }

        public DateTime? RegistryDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}