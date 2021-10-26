using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PresentacionParcial.Models;

namespace PresentacionParcial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _personaService;

        public IConfiguration Configuration { get; }

        public PersonaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString =
                Configuration["ConnectionStrings:DefaultConnection"];
            _personaService = new PersonaService(connectionString);
        }

        // GET: api/Persona
        [HttpGet]
        public IEnumerable<PersonaViewModel> Gets()
        {
            var personas =
                _personaService
                    .ConsultarTodos()
                    .Select(p => new PersonaViewModel(p));
            return personas;
        }

        // GET: api/Persona/5
        [HttpGet("{identificacion}")]
        public ActionResult<PersonaViewModel> Get(int identificacion)
        {
            var persona = _personaService.BuscarxIdentificacion(identificacion);
            if (persona == null) return NotFound();
            var personaViewModel = new PersonaViewModel(persona);
            return personaViewModel;
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<PersonaViewModel>
        Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.Guardar(persona);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }

        // DELETE: api/Persona/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(int identificacion)
        {
            string mensaje = _personaService.Eliminar(identificacion);
            return Ok(mensaje);
        }

        private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona =
                new Persona {
                    identificacion = personaInput.identificacion,
                    nombre = personaInput.nombre,
                    edad = personaInput.edad
                };
            return persona;
        }

        // PUT: api/Persona/5
        [HttpPut]
        public ActionResult<string> Put(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.Actualizar(persona);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }
    }
}
