using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploEstudio.Entities
{
    public class Sede
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public List<Empleado> Empleados { get; set; }
    }
}
