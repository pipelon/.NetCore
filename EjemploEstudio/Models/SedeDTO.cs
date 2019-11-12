using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploEstudio.Models
{
    public class SedeDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public List<EmpleadoDTO> Empleados { get; set; }
    }
}
