using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploEstudio.Entities;

namespace EjemploEstudio.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
