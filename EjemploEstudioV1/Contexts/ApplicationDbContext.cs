using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploEstudioV1.Entities;

namespace EjemploEstudioV1.Contexts
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
