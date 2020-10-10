using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Salon.DTOs
{
    public  class SalonDto : BaseDto
    {
        public string Descripcion { get; set; }

        public long ListaPrecioId { get; set; }

        public string ListaPrecio { get; set; }
        
    }
}
