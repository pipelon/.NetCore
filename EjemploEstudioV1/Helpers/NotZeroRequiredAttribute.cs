using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploEstudioV1.Helpers
{
    public class NotZeroRequiredAttribute: RequiredAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Si no viene un valor entonces devuelve true pq no es necesario validar nada
            if (string.IsNullOrEmpty(value.ToString()) || value.ToString().Equals("0"))
            {
                return new ValidationResult("No puede ser vacío  ni cero");
            }
            
            return base.IsValid(value, validationContext);
        }
    }
}
