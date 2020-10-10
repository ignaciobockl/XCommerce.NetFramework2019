using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Producto.DTOs
{
    public class ProductoMesaDto : BaseDto
    {
        public string Codigo { get; set; }

        public string CodigoBarra { get; set; }

        public int Cantidad { get; set; }

        public decimal Stock { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool DescuentaStock { get; set; }
        
    }
}
