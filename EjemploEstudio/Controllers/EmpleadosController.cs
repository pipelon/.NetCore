using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjemploEstudio.Contexts;
using EjemploEstudio.Entities;
using AutoMapper;
using EjemploEstudio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EjemploEstudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Decorador para pedir autenticacion en todo el controlador
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmpleadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmpleadosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> GetEmpleados()
        {
            var empleados = await _context.Empleados.Include(x => x.Sede).ToListAsync();
            return _mapper.Map<List<EmpleadoDTO>>(empleados);
        }
                

        // GET: api/Empleados/5
        [HttpGet("{id}", Name = "ObtenerEmpleado")]
        public async Task<ActionResult<EmpleadoDTO>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return _mapper.Map<EmpleadoDTO>(empleado);
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        //Decorador para solicitar JWT Autentication en una accion con Rol
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> PutEmpleado(int id, [FromBody] EmpleadoCrEdDTO empEd)
        {
            var empleado = _mapper.Map<Empleado>(empEd);
            empleado.Id = id;
            _context.Entry(empleado).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Empleados
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> PostEmpleado([FromBody] EmpleadoCrEdDTO empCr)
        {
            var empleado = _mapper.Map<Empleado>(empCr);
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            var empDTO = _mapper.Map<EmpleadoDTO>(empleado);
            return new CreatedAtRouteResult("ObtenerSede", new { id = empleado.Id }, empDTO);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<Empleado>> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return empleado;
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
