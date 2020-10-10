using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.Comprobante
{
    public interface IComprobanteServicio
    {
        int ObtenerNumeroComprobante(long numeroComprobante);

    }
}
