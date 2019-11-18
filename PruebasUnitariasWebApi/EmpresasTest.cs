using AutoMapper;
using EjemploEstudio.Contexts;
using EjemploEstudio.Controllers;
using EjemploEstudio.Entities;
using EjemploEstudio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace PruebasUnitariasWebApi
{
    [TestClass]
    public class EmpresasTest
    {
        [TestMethod]
        public void if_param_is_one_returns_true()
        {
            //Preparacion
            var id = 1;
            var prueba = new PruebaUnitController();
            // Prueba
            var resultado = prueba.GetAlgo(id);
            OkObjectResult okObjectResult = resultado as OkObjectResult;
            //Verificacion    
            Assert.IsNotNull(okObjectResult);
            Assert.IsTrue(Convert.ToBoolean(okObjectResult.Value));
        }

        [TestMethod]
        public void if_param_is_two_returns_false()
        {
            //Preparacion
            var id = 2;
            var prueba = new PruebaUnitController();
            // Prueba
            var resultado = prueba.GetAlgo(id);
            OkObjectResult okObjectResult = resultado as OkObjectResult;
            //Verificacion    
            Assert.IsNotNull(okObjectResult);
            Assert.IsFalse(Convert.ToBoolean(okObjectResult.Value));
        }

        [TestMethod]
        public void if_param_is_three_returns_not_found()
        {
            //Preparacion
            var id = 3;
            var prueba = new PruebaUnitController();
            // Prueba
            var resultado = prueba.GetAlgo(id);
            NotFoundResult notFoundObjectResult = resultado as NotFoundResult;
            //Verificacion
            Assert.IsNotNull(notFoundObjectResult);
        }

        /*[TestMethod]
        public void Id_Empresa_No_Exites()
        {
            //Preparacion
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "EmpresasListDatabase")
            .Options;

            var context = new ApplicationDbContext(options);
            context.Empresas.Add(new Empresa { Id = 1, Nombre = "Empresa 1", Activo = true });
            context.Empresas.Add(new Empresa { Id = 2, Nombre = "Empresa 2", Activo = true });
            context.Empresas.Add(new Empresa { Id = 3, Nombre = "Empresa 3", Activo = true });
            context.SaveChanges();
            var mock2 = new Mock<IMapper>();

            //Prueba
            var empresasController = new EmpresasController(context, mock2.Object);
            var resultado = empresasController.GetEmpresa(20).Result;

            // Verificación
            Assert.IsInstanceOfType(resultado.Result, typeof(NotFoundResult));

        }*/
    }
}
