using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Logica
{
    public class LiquidacionService
    {
        private readonly Parcial2Context _context;
        private InfraccionService infraccionService { get; set; }
        private PersonaService personaService { get; set; }
        
        
        public LiquidacionService(Parcial2Context context)
        {
            _context = context;
            infraccionService = new InfraccionService(_context);
            personaService = new PersonaService(_context);
        }
        public LiquidacionResponse Guardar(Liquidacion liquidacion)
        {
            try
            {
                var infraccionBuscada = _context.Infracciones.Find(liquidacion.idInfraccion);
                if (infraccionBuscada != null)
                {
                    liquidacion.infraccion = infraccionService.BuscarxIdentificacion(liquidacion.idInfraccion);
                    liquidacion.infraccion.persona = personaService.BuscarxIdentificacion(liquidacion.infraccion.idPersona);
                    _context.Liquidaciones.Add(liquidacion);
                    _context.SaveChanges();
                    return new LiquidacionResponse(liquidacion);
                }
                return new LiquidacionResponse("Error la infraccion no se encuentra registrada");
            }
            catch (Exception e)
            {
                return new LiquidacionResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public List<Liquidacion> ConsultarTodos()
        {
            List<Liquidacion> liquidaciones = _context.Liquidaciones.ToList();
            foreach (var liquidacion in liquidaciones)
            {
                liquidacion.infraccion = _context.Infracciones.Find(liquidacion.idInfraccion);
                liquidacion.infraccion.persona=_context.Personas.Find(liquidacion.infraccion.idPersona);
                liquidacion.calcularValorPagar();
            }
            return liquidaciones;
        }
        public Liquidacion BuscarxIdentificacion(int identificacion)
        {
            var Liquidacion = _context.Liquidaciones.Find(identificacion);
            return Liquidacion;
        }
    }
    public class LiquidacionResponse
    {
        public LiquidacionResponse(Liquidacion liquidacion)
        {
            Error = false;
            this.liquidacion = liquidacion;
        }
        public LiquidacionResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Liquidacion liquidacion { get; set; }
    }
}