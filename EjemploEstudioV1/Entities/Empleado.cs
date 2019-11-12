using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploEstudioV1.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }        
        public bool Activo { get; set; }
        public int SedeId { get; set; }
        public Sede Sede { get; set; }
    }
}
