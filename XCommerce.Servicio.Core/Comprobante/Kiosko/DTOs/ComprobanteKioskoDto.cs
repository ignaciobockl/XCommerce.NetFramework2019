using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Base;
using XCommerce.Servicio.Core.Kiosko.DTOs;

namespace XCommerce.Servicio.Core.Comprobante.Kiosko.DTOs
{
    public class ComprobanteKioskoDto : BaseDto
    {
        public ComprobanteKioskoDto()
        {
            if (Items == null)
                Items = new List<DetalleComprobanteKioscoDto>();
        }
        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

        public decimal Total { get; set; }

        public long UsuarioId { get; set; }

        public long ClienteId { get; set; }

        public TipoComprobante TipoComprobante { get; set; }

        public List<DetalleComprobanteKioscoDto> Items { get; set; }
    }
}
