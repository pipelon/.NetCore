using EjemploEstudio.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploEstudio.Models
{
    public class EmpleadoCrEdDTO
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [primeraLetraMayuscula]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress]
        public string Email { get; set; }
        [NotZeroRequired]
        public decimal Salario { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public bool? Activo { get; set; }
        [NotZeroRequired]
        public int SedeId { get; set; }
    }
}
