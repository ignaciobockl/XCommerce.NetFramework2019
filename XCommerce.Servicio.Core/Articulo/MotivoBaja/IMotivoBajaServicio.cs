using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Articulo.MotivoBaja.DTOs;

namespace XCommerce.Servicio.Core.Articulo.MotivoBaja
{
    public interface IMotivoBajaServicio
    {
        IEnumerable<MotivoBajaDto> Obtener(string cadenaBuscar);
        long Insertar(MotivoBajaDto dto);
    }
}
