using System;
using System.Collections.Generic;

#nullable disable

namespace CargarDatos.Models
{
    public partial class Municipio
    {
        public int EntidadId { get; set; }
        public int MunicipioId { get; set; }
        public string Nombre { get; set; }
        public int? PoblacionTotal { get; set; }
        public int? PoblacionMasculina { get; set; }
        public int? PoblacionFemenina { get; set; }
    }
}
