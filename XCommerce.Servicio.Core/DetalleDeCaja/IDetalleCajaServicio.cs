using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.DetalleDeCaja.DTOs;

namespace XCommerce.Servicio.Core.DetalleDeCaja
{
   public interface IDetalleCajaServicio
    {
        void InsertarDetalle(DetalleCajaDto dto);

    }
}
