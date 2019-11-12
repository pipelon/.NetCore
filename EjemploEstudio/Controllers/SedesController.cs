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

namespace EjemploEstudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SedesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Sedes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SedeDTO>>> GetSedes()
        {
            var sedes = await _context.Sedes.Include(x => x.Empresa).ToListAsync();
            return _mapper.Map<List<SedeDTO>>(sedes);
        }

        // GET: api/Sedes/5
        [HttpGet("{id}", Name = "ObtenerSede")]
        public async Task<ActionResult<SedeDTO>> GetSede(int id)
        {
            var sede = await _context.Sedes.FindAsync(id);

            if (sede == null)
            {
                return NotFound();
            }

            return _mapper.Map<SedeDTO>(sede);
        }

        // PUT: api/Sedes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSede(int id, [FromBody] SedeCrEdDTO sedeEd)
        {
            var sede = _mapper.Map<Sede>(sedeEd);
            sede.Id = id;
            _context.Entry(sede).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeExists(id))
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

        // POST: api/Sedes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> PostSede([FromBody] SedeCrEdDTO sedeCr)
        {
            var sede = _mapper.Map<Sede>(sedeCr);
            _context.Sedes.Add(sede);
            await _context.SaveChangesAsync();
            var sedeDTO = _mapper.Map<SedeDTO>(sede);
            return new CreatedAtRouteResult("ObtenerSede", new { id = sede.Id }, sedeDTO);
        }

        // DELETE: api/Sedes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sede>> DeleteSede(int id)
        {
            var sede = await _context.Sedes.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }

            _context.Sedes.Remove(sede);
            await _context.SaveChangesAsync();

            return sede;
        }

        private bool SedeExists(int id)
        {
            return _context.Sedes.Any(e => e.Id == id);
        }
    }
}
