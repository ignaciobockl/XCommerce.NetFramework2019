using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.Comprobante.DTOs
{
    public class DetalleComprobanteSalonDto
    {
        public long ComprobanteId { get; set; }

        public long DetalleId { get; set; }

        public long ProductoId { get; set; }

        public string CodigoProducto { get; set; }

        public string DescripcionProducto { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Cantidad { get; set; }

        public decimal SubTotalLinea => PrecioUnitario * Cantidad;
    }
}
