using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// Agregar la siguiente librerias
using RLCRUD.EntidadesDeNegocio;
using RLCRUD.LogicaDeNegocio;
using System.Text.Json;

namespace RLCRUD.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private ContactoBL contactoBL = new ContactoBL();

        // GET: api/<ContactoController>
        [HttpGet]
        public async Task<IEnumerable<Contacto>> Get()
        {
            return await contactoBL.ObtenerTodosAsync();
        }

        // GET api/<ContactoController>/5
        [HttpGet("{id}")]
        public async Task<Contacto> Get(int id)
        {
            Contacto contacto = new Contacto();
            contacto.Id = id;
            return await contactoBL.ObtenerPorIdAsync(contacto);
        }

        // POST api/<ContactoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Contacto contacto)
        {
            try
            {
                await contactoBL.CrearAsync(contacto);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<ContactoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Contacto contacto)
        {

            if (contacto.Id == id)
            {
                await contactoBL.ModificarAsync(contacto);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE api/<ContactoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Contacto contacto = new Contacto();
                contacto.Id = id;
                await contactoBL.EliminarAsync(contacto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Contacto>> Buscar([FromBody] object pContacto)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strContacto = JsonSerializer.Serialize(pContacto);
            Contacto contacto = JsonSerializer.Deserialize<Contacto>(strContacto, option);
            return await contactoBL.BuscarAsync(contacto);

        }
    }
}
