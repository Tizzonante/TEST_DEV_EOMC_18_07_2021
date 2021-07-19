using System;
using Toka.BaseServices.Common.Model;

namespace Toka.PhysicalPerson.Common.Model
{
    public class PhysicalPDb : BaseModel
    {
        public int IdPersonaFisica { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string RFC { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool Activo { get; set; }
    }
}
