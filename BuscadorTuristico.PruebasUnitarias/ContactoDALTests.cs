using Microsoft.VisualStudio.TestTools.UnitTesting;
using RLCRUD.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLCRUD.EntidadesDeNegocio;

namespace RLCRUD.AccesoADatos.Tests
{
    [TestClass()]
    public class ContactoDALTests
    {
        private static Contacto contactoInicial = new Contacto { Id = 1 };  // Agregar un id existente en la base de datos     
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var contacto = new Contacto();
            contacto.Nombre = "Rocío Hernández";
            contacto.Telefono = "7725-9581";
            contacto.Correo = "rociolueb21@gmail.com";
            int result = await ContactoDAL.CrearAsync(contacto);
            Assert.AreNotEqual(0, result);
            contactoInicial.Id = contacto.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var contacto = new Contacto();
            contacto.Id = contactoInicial.Id;
            contacto.Nombre = "Rocío";
            contacto.Telefono = "77259581";
            contacto.Correo = "hlu7373@gmail.com";
            int result = await ContactoDAL.ModificarAsync(contacto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var contacto = new Contacto();
            contacto.Id = contactoInicial.Id;
            var resultContacto = await ContactoDAL.ObtenerPorIdAsync(contacto);
            Assert.AreEqual(contacto.Id, resultContacto.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultContactos = await ContactoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultContactos.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var contacto = new Contacto();
            contacto.Nombre = "a";
            contacto.Telefono = "A";
            contacto.Correo = "a";
            contacto.Top_Aux = 10;
            var resultContactos = await ContactoDAL.BuscarAsync(contacto);
            Assert.AreNotEqual(0, resultContactos.Count);
        }
        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var contacto = new Contacto();
            contacto.Id = contactoInicial.Id;
            int result = await ContactoDAL.EliminarAsync(contacto);
            Assert.AreNotEqual(0, result);
        }
    }
}