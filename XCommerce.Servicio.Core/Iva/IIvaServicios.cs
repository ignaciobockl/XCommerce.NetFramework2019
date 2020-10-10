using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Iva.IvaDTOs;

namespace XCommerce.Servicio.Core.Iva
{
    public interface IIvaServicios
    {
        long Insertar(IvaDto dto);

        void Modificar(IvaDto dto);

        IEnumerable<IvaDto> Obtener(string cadenaBuscar);

        IvaDto ObtenerPorId(long entidadId);
    }
}
