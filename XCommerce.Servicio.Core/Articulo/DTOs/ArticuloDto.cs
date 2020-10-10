using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Articulo.DTOs
{
    public class ArticuloDto : BaseDto
    {
        public string Codigo { get; set; }

        public string CodigoBarra { get; set; }

        public string Abreviatura { get; set; }

        public string Descripcion { get; set; }

        public string Detalle { get; set; }

        public byte[] Foto { get; set; }

        public bool ActivarLimiteVenta { get; set; }

        public decimal LimiteVenta { get; set; }

        public bool PermiteStockNegativo { get; set; }

        public bool EstaDiscontinuado { get; set; }

        public decimal StockMaximo { get; set; }

        public decimal StockMinimo { get; set; }

        public bool DescuentaStockl { get; set; }

        public long MarcaId { get; set; }

        public long RubroId { get; set; }

        public decimal Stock { get; set; }

    }
}
