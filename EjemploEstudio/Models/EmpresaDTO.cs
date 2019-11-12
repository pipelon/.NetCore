using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploEstudio.Models
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<SedeDTO> Sedes { get; set; }
    }
}
