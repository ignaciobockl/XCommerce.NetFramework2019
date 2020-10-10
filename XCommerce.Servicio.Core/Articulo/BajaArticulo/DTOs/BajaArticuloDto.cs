using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Articulo.BajaArticulo.DTOs
{
    public class BajaArticuloDto : BaseDto
    {
        public DateTime Fecha { get; set; }

        public decimal Cantidad { get; set; }

        public string Observacion { get; set; }

        public long MotivoBajaId { get; set; }

        public int ArticuloId { get; set; }
    }
}
