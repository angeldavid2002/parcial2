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
    public class LiquidacionController : ControllerBase
    {
        private readonly LiquidacionService _liquidacionService;
        public LiquidacionController(Parcial2Context context)
        {
            _liquidacionService = new LiquidacionService(context);
        }
        [HttpGet]
        public IEnumerable<LiquidacionViewModel> Gets()
        {
            var infraccion = _liquidacionService.ConsultarTodos().Select(p => new LiquidacionViewModel(p));
            return infraccion;
        }
        [HttpGet("{identificacion}")]
        public ActionResult<LiquidacionViewModel> Get(int identificacion)
        {
            var liquidacion = _liquidacionService.BuscarxIdentificacion(identificacion);
            if (liquidacion == null) return NotFound();
            var liquidacionViewModel = new LiquidacionViewModel(liquidacion);
            return liquidacionViewModel;
        }
        [HttpPost]
        public ActionResult<LiquidacionViewModel> Post(LiquidacionInputModel liquidacionInputModel)
        {
            Liquidacion liquidacion = MapearLiquidacion(liquidacionInputModel);

            var response = _liquidacionService.Guardar(liquidacion);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.liquidacion);
        }
        private Liquidacion MapearLiquidacion(LiquidacionInputModel liquidacionInputModel)
        {
            var liquidacion = new Liquidacion
            {
                id = liquidacionInputModel.id,
                fechaPago = liquidacionInputModel.fechaPago,
                idInfraccion = liquidacionInputModel.idInfraccion,
                infraccion = new Infraccion
                {
                    idInfraccion = liquidacionInputModel.infraccion.idInfraccion,
                    persona = new Persona
                    {
                        identificacion = liquidacionInputModel.infraccion.persona.identificacion,
                    },
                },
            };
            return liquidacion;
        }
    }
}