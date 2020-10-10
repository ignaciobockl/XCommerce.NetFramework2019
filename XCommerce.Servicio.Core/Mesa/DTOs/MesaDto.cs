using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Mesa.DTOs
{
    public class MesaDto : BaseDto
    {
        public int Numero { get; set; }

        public string Descripcion { get; set; }

        public long SalonId { get; set; }

        public string Salon { get; set; }

        public EstadoMesa estadoMesa { get; set; }

        public ComprobanteSalon comprobanteSalon { get; set; }        
    }
}
