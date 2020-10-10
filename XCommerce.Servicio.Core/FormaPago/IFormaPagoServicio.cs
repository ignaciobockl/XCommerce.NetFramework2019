using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace XCommerce.Servicio.Core.FormaPago
{
    public interface IFormaPagoServicio
    {
        long Insertar(FormaPagoDto dto);

        //===========================================//

        FormaPagoDto ObtenerPorId(long entidadId);
    }
}
