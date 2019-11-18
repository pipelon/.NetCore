using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEstudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaUnitController : ControllerBase
    {
        
        //Metodo que retorna Ok o NotFoun de pendiendo del parametro
        public ActionResult GetAlgo(int id)
        {
            if(id == 1)
            {
                return Ok(true);
            }
            if (id == 2)
            {
                return Ok(false);
            }
            return NotFound();

        }
    }
}