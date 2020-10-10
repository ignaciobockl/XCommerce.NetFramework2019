using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Movimiento.DTOs;

namespace XCommerce.Servicio.Core.Movimiento
{
    public interface IMovimientoServicio
    {
        long Insertar(MovimientoDto dto);

        void Modificar(MovimientoDto dto);

        //================================================//

        IEnumerable<MovimientoDto> Obtener(string cadenaBuscar);

        MovimientoDto ObtenerPorId(long entidadId);
    }
}
