using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;

namespace PresentacionParcial.Models
{
    public class PersonaInputModel
    {
        public int identificacion { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
    }

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }
        public PersonaViewModel(Persona persona)
        {
            identificacion = persona.identificacion;
            nombre = persona.nombre;
            edad = persona.edad;
        }
    }
}