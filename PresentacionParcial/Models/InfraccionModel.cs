using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;

namespace PresentacionParcial.Models
{
    public class InfraccionInputModel
    {
        public int idInfraccion { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal valorMulta { get; set; }
        public Persona persona { get; set; }
        
        
    }

    public class InfraccionViewModel : InfraccionInputModel
    {
        public InfraccionViewModel()
        {

        }
        public InfraccionViewModel(Infraccion infraccion)
        {
            idInfraccion = infraccion.idInfraccion;
            codigo = infraccion.codigo;
            descripcion = infraccion.descripcion;
            valorMulta = infraccion.valorMulta;
            persona = infraccion.persona;
        }
    }
}