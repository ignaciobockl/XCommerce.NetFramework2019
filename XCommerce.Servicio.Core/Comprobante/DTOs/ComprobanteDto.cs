using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Comprobante.DTOs
{
    public class ComprobanteDto : BaseDto
    {
        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

        public decimal Total { get; set; }

        public long UsuarioId { get; set; }

        public long ClienteId { get; set; }

        public TipoComprobante TipoComprobante { get; set; }
    }
}
