using EjemploEstudio.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploEstudio.Models
{
    public class SedeCrEdDTO
    {
        [Required(ErrorMessage = "Este campo es requerido")] //Validación por atributo con mensaje personalizado
        [primeraLetraMayuscula]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")] //Validación por atributo con mensaje personalizado
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")] //Validación por atributo con mensaje personalizado
        public string Telefono { get; set; }
        [NotZeroRequired] //Validación por atributo con mensaje personalizado
        public int EmpresaId { get; set; }
    }
}
