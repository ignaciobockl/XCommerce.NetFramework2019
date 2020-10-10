using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.Reserva.MotivoReserva
{
    public interface IMotivoReservaServicio
    {
        long Insertar(MotivoReservaDto dto);

        //===========================================//

        IEnumerable<MotivoReservaDto> Obtener(string cadenaBuscar);
    }
}
