using System;
using Toka.WebApi.Common.Base.Model.Dto;

namespace Toka.WebApi.PhysicalPerson.Model
{
    public class PhysicalPersonDtoApi : BaseParamsBodyDto
    {
        public int PhysicalPersonId { get; set; }
        public string Names { get; set; }
        public string LastNameFather { get; set; }
        public string LastNameMother { get; set; }
        public string RFC { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}