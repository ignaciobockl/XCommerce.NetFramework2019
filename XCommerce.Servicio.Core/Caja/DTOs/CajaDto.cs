using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Caja.DTOs
{
    public class CajaDto
    {
        public long Id { get; set; }

        public decimal MontoApertura { get; set; }

        public decimal? MontoCierre { get; set; }

        public DateTime FechaApertura { get; set; }

        public DateTime? FechaCierre { get; set; }

        public decimal MontoSistema { get; set; }

        public decimal Diferencia { get; set; }

        public long UsuarioAperturaId { get; set; }

        public long? UsuarioCierreId { get; set; }
    }
}
