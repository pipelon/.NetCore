using EjemploEstudio.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploEstudio.Models
{
    public class EmpresaCrEdDTO
    {
        //Llamado a funcion customizada de validaciones
        //[GenericRequired]
        [Required(ErrorMessage = "Este campo es requerido")] //Validación por atributo con mensaje personalizado
        [primeraLetraMayuscula] //Validacion generica. Ver carpeta Helpers
        public string Nombre { get; set; }
    }

    //Funcion para hacer validaciones customizadas en el modelo
    /*public class GenericRequired : RequiredAttribute
    {
        public GenericRequired()
        {
            //code......
            ErrorMessage = "{0} es super requerido";
        }
    }*/
}
