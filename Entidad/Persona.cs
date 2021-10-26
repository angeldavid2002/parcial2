using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Persona
    {
        [Key]
        public int identificacion { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        
        
        
        
    }
}
