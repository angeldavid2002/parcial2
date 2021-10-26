using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entidad
{
    public class Infraccion
    {
        [Key]
        public int idInfraccion { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal valorMulta { get; set; }
        public int idPersona { get; set; }
        public Persona persona { get; set; }
        
        
    }
}