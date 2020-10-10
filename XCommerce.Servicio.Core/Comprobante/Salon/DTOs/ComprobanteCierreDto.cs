using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core.Comprobante.DTOs
{
    public class ComprobanteCierreDto
    {
        public ComprobanteCierreDto()
        {
            if (Items == null)
                Items = new List<DetalleComprobanteSalonDto>();
        }

        public long MesaId { get; set; }

        public long? MozoId { get; set; }

        public long Id { get; set; }

        public string Comensales { get; set; }

        public DateTime Fecha { get; set; }

        public long ClienteId { get; set; }

        public long? UsuarioId { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

        public decimal Total { get; set; }

        public List<DetalleComprobanteSalonDto> Items { get; set; }

        public TipoComprobante TipoDeComprobante { get; set; }

        public EstadoComprobanteSalon EstadoComprobante { get; set; }



        public int Numero { get; set; }
    }
}
