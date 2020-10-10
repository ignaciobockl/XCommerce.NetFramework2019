using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Kiosko.DTOs
{
    public class ProductoKioscoDto : BaseDto
    {
        public string Codigo { get; set; }

        public string CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool DescuentaStock { get; set; }

        public bool ListaPreciosId { get; set; }

        public string ListaPrecios { get; set; }
    }
}
