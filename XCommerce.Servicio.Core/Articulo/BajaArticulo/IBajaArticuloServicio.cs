using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Articulo.BajaArticulo.DTOs;

namespace XCommerce.Servicio.Core.Articulo.BajaArticulo
{
    public interface IBajaArticuloServicio
    {
        long Insertar(BajaArticuloDto dto);
        IEnumerable<BajaArticuloDto> Obtener(string cadenaBuscar);
    }
}
