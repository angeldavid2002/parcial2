using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using PresentacionParcial.Models;

namespace PresentacionParcial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfraccionController : ControllerBase
    {
        private readonly InfraccionService _infraccionService;
        public InfraccionController(Parcial2Context context)
        {
            _infraccionService = new InfraccionService(context);
        }

        [HttpGet]
        public IEnumerable<InfraccionViewModel> Gets()
        {
            var infraccion = _infraccionService.ConsultarTodos().Select(p => new InfraccionViewModel(p));
            return infraccion;
        }

        // GET: api/Persona/5
        [HttpGet("{identificacion}")]
        public ActionResult<InfraccionViewModel> Get(int identificacion)
        {
            var infraccion = _infraccionService.BuscarxIdentificacion(identificacion);
            if (infraccion == null) return NotFound();
            var infraccionViewModel = new InfraccionViewModel(infraccion);
            return infraccionViewModel;
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<InfraccionViewModel>
        Post(InfraccionInputModel infraccionInputModel)
        {
            Infraccion infraccion = MapearInfraccion(infraccionInputModel);

            var response = _infraccionService.Guardar(infraccion);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.infraccion);
        }

        // DELETE: api/Persona/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(int identificacion)
        {
            string mensaje = _infraccionService.Eliminar(identificacion);
            return Ok(mensaje);
        }

        private Infraccion MapearInfraccion(InfraccionInputModel infraccionInputModel)
        {
            var infraccion = new Infraccion
            {
                idInfraccion = infraccionInputModel.idInfraccion,
                codigo = infraccionInputModel.codigo,
                descripcion = infraccionInputModel.descripcion,
                fechaInfraccion = infraccionInputModel.fechaInfraccion,
                valorMulta = infraccionInputModel.valorMulta,
                persona = new Persona
                {
                    identificacion = infraccionInputModel.persona.identificacion,
                },
            };
            return infraccion;
        }

        // PUT: api/Persona/5
        [HttpPut]
        public ActionResult<string> Put(InfraccionInputModel infraccionInput)
        {
            Infraccion infraccion = MapearInfraccion(infraccionInput);
            var response = _infraccionService.Actualizar(infraccion);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.infraccion);
        }
    }
}