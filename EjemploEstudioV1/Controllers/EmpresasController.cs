using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjemploEstudioV1.Contexts;
using EjemploEstudioV1.Entities;
using AutoMapper;
using EjemploEstudioV1.Models;

namespace EjemploEstudioV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmpresasController(ApplicationDbContext context, IMapper imaper)
        {
            _context = context;
            this._mapper = imaper;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetEmpresas()       
        {
            var empresas = await _context.Empresas.Include(x => x.Sedes).ToListAsync();
            return _mapper.Map<List<EmpresaDTO>>(empresas);
        }

        // GET: api/Empresas/5
        [HttpGet("{id}", Name = "ObtenerEmpresa")]
        public async Task<ActionResult<EmpresaDTO>> GetEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return _mapper.Map<EmpresaDTO>(empresa);
        }

        // POST: api/Empresas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> PostEmpresa([FromBody] EmpresaCrEdDTO empresaCr)
        {
            var empresa = _mapper.Map<Empresa>(empresaCr);
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
            var empresaDTO = _mapper.Map<EmpresaDTO>(empresa);
            return new CreatedAtRouteResult("ObtenerEmpresa", new { id = empresa.Id }, empresaDTO);
        }

        // PUT: api/Empresas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(int id, [FromBody] EmpresaCrEdDTO empresaEd)
        {

            var empresa = _mapper.Map<Empresa>(empresaEd);
            empresa.Id = id;
            _context.Entry(empresa).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
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

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empresa>> DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return empresa;
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.Id == id);
        }
    }
}
