using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class PersonaService
    {
        private readonly ConnectionManager _conexion;
        private readonly Parcial2Context _context;
        private readonly PersonaRepository _repositorio;
        public PersonaService(Parcial2Context context)
        {
            _context=context;
        }
        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                var personaBuscada =_context.Personas.Find(persona.identificacion);
                if(personaBuscada != null){
                    return new GuardarPersonaResponse("Error la persona ya se encuentra registrada");
                }
                _context.Personas.Add(persona);
                _context.SaveChanges();
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public GuardarPersonaResponse Actualizar(Persona personaNueva)
        {
            try
            {
                var personaBuscada =_context.Personas.Find(personaNueva.identificacion);
                if(personaBuscada != null){
                    personaBuscada.nombre = personaNueva.nombre;
                    personaBuscada.edad =personaNueva.edad;
                    _context.Personas.Update(personaBuscada);
                    _context.SaveChanges();
                    return new GuardarPersonaResponse(personaBuscada);
                }
                return new GuardarPersonaResponse("Error la persona no existe");
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public List<Persona> ConsultarTodos()
        {
            List<Persona> personas = _context.Personas.ToList();
            return personas;
        }
        public string Eliminar(int identificacion)
        {
            try
            {
                var persona = _context.Personas.Find(identificacion);
                if (persona != null)
                {
                    _context.Personas.Remove(persona);
                    _context.SaveChanges();
                    return ($"El registro {persona.nombre} se ha eliminado satisfactoriamente.");
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
        public Persona BuscarxIdentificacion(int identificacion)
        {
            var persona = _context.Personas.Find(identificacion);
            return persona;
        }
        public int Totalizar()
        {
            return _repositorio.Totalizar();
        }
    }

    public class GuardarPersonaResponse 
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
}