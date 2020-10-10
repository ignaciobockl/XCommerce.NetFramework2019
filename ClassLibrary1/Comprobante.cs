using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Comprobante
    {
        public long Id { get; set; }

        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

        public decimal Total { get; set; }

        public long UsuarioId { get; set; }

        public long ClienteId { get; set; }

        public Enum TipoComprobante { get; set; }
    }
}
