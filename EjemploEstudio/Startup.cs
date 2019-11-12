using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EjemploEstudio.Contexts;
using EjemploEstudio.Entities;
using EjemploEstudio.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EjemploEstudio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Servicio autoMapper para combinar  los DTO con los Entities
            services.AddAutoMapper(options =>
            {
                options.CreateMap<Empresa, EmpresaDTO>();
                options.CreateMap<EmpresaDTO, Empresa>();
                options.CreateMap<EmpresaCrEdDTO, Empresa>();
                options.CreateMap<Sede, SedeDTO>();
                options.CreateMap<SedeDTO, Sede>();
                options.CreateMap<SedeCrEdDTO, Sede>();
                options.CreateMap<Empleado, EmpleadoDTO>();
                options.CreateMap<EmpleadoDTO, Empleado>();
                options.CreateMap<EmpleadoCrEdDTO, Empleado>();
            }, typeof(Startup));
            //Servicio para conectarse a la base de datos SQL Server
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            //Servicio para evitar la referencia ciclica en los DTO
            services.AddControllers()
                .AddNewtonsoftJson(x => 
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
