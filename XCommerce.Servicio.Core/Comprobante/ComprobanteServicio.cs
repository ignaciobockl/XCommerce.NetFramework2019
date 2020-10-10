using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core.Comprobante
{
    public class ComprobanteServicio : IComprobanteServicio
    {
        public int ObtenerNumeroComprobante(long numeroComprobante)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes
                    .FirstOrDefault(x => x.Id == numeroComprobante).Numero;
            }
        }
    }
}
