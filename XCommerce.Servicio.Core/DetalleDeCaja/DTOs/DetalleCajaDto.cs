using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core.DetalleDeCaja.DTOs
{
    public class DetalleCajaDto
    {
        public long Id { get; set; }

        public long CajaId { get; set; }

        public decimal Monto { get; set; }

        public  TipoPago FormaPago { get; set; }
    }
}
