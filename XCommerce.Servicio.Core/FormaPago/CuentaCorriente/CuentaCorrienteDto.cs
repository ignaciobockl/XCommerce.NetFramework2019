using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace XCommerce.Servicio.Core.FormaPago.CuentaCorriente
{
    public class CuentaCorrienteDto : BaseDto
    {
        public long ClienteId { get; set; }

        public decimal SaldoDisponible { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public bool EstadoPago { get; set; }

        public int NumeroComprobante { get; set; }

        public string EstaPagadoStr => EstadoPago ? "Si" : "No";
    }
}
