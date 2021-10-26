using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;

namespace PresentacionParcial.Models
{
    public class LiquidacionInputModel
    {
        public int id { get; set; }
        public DateTime fechaPago { get; set; }
        public int idInfraccion { get; set; }
        public Infraccion infraccion { get; set; }


    }

    public class LiquidacionViewModel : LiquidacionInputModel
    {
        public LiquidacionViewModel()
        {

        }
        public LiquidacionViewModel(Liquidacion liquidacion)
        {
            idInfraccion = liquidacion.idInfraccion;
            fechaPago = liquidacion.fechaPago;
            id = liquidacion.id;
            infraccion = liquidacion.infraccion;
        }
    }
}