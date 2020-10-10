using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Precio.DTOs;

namespace XCommerce.Servicio.Core.Precio
{
    public interface IPrecioServicio
    {
        long Insertar(PrecioDto dto);

        void Modificar(PrecioDto dto);


        //================================================//

        PrecioDto ObtenerPorId(long entidadId);
    }
}
