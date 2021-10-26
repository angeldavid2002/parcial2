using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Microsoft.EntityFrameworkCore;


namespace Datos
{
    public class Parcial2Context : DbContext
    {
        public Parcial2Context(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Infraccion> Infracciones { get; set; }
        
        
    }
}