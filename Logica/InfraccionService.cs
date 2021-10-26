using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Entidad;
namespace Logica
{
    public class InfraccionService
    {
        private readonly Parcial2Context _context;
        public InfraccionService(Parcial2Context context)
        {
            _context=context;
        }
         public InfraccionResponse Guardar(Infraccion infraccion)
        {
            try
            {
                var persona =_context.Personas.Find(infraccion.persona.identificacion);
                if(persona != null){
                    infraccion.idPersona = _context.Personas.Find(infraccion.persona.identificacion).identificacion;
                    infraccion.persona = _context.Personas.Find(infraccion.persona.identificacion);
                    _context.Infracciones.Add(infraccion);
                    _context.SaveChanges();
                    return new InfraccionResponse(infraccion);
                }
                return new InfraccionResponse("la persona no se encuentra registrada");
            }
            catch (Exception e)
            {
                return new InfraccionResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public InfraccionResponse Actualizar(Infraccion infraccion)
        {
            try
            {
                var infraccionBuscada =_context.Infracciones.Find(infraccion.idInfraccion);
                if(infraccionBuscada != null){
                    infraccionBuscada.codigo = infraccionBuscada.codigo;
                    infraccionBuscada.descripcion =infraccionBuscada.descripcion;
                    infraccionBuscada.valorMulta = infraccionBuscada.valorMulta;
                    infraccionBuscada.persona = _context.Personas.Find(infraccion.idPersona);
                    infraccionBuscada.idPersona = infraccion.idPersona;
                    _context.Infracciones.Update(infraccionBuscada);
                    _context.SaveChanges();
                    return new InfraccionResponse(infraccionBuscada);
                }
                return new InfraccionResponse("Error la persona no existe");
            }
            catch (Exception e)
            {
                return new InfraccionResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public List<Infraccion> ConsultarTodos()
        {
            List<Infraccion> infracciones = _context.Infracciones.ToList();
            foreach (var infraccion in infracciones)
            {
                infraccion.persona=_context.Personas.Find(infraccion.idPersona);
            }
            return infracciones;
        }
        public string Eliminar(int identificacion)
        {
            try
            {
                var infraccion = _context.Infracciones.Find(identificacion);
                if (infraccion != null)
                {
                    _context.Infracciones.Remove(infraccion);
                    _context.SaveChanges();
                    return ($"El registro {infraccion.idInfraccion} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }

        }
        public Infraccion BuscarxIdentificacion(int identificacion)
        {
            var infraccion = _context.Infracciones.Find(identificacion);
            return infraccion;
        }
    }
    public class InfraccionResponse 
    {
        public InfraccionResponse(Infraccion infraccion)
        {
            Error = false;
            this.infraccion = infraccion;
        }
        public InfraccionResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Infraccion infraccion { get; set; }
    }
}