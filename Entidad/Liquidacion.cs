using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entidad
{
    public class Liquidacion
    {
        [Key]
        public int id { get; set; }
        public DateTime fechaPago { get; set; }
        public int idInfraccion { get; set; }
        public Infraccion infraccion { get; set; }
        public Decimal valorMulta { get; set; }
        public Decimal ValoraPagar { get; set; }
        
        public void calcularValorPagar()
        {
            TimeSpan time = fechaPago - infraccion.fechaInfraccion;
            double dias = time.TotalDays;
            if(dias<=5){
                ValoraPagar = (valorMulta - (valorMulta/2));
            }else if(dias>5 && dias<30){
                ValoraPagar=valorMulta;
            }else if(dias>=30){
                ValoraPagar = valorMulta+((dias/30)*((valorMulta/100)())); 
            }
        }
        
        
    }
}