using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Rubro.DTOS;

namespace XCommerce.Servicio.Core.Rubro
{
    public interface IRubroSerivicio
    {
         long Insertar(RubroDto dto);

         void Modificar(RubroDto dto);

         void Eliminar(long rubroId);

         IEnumerable<RubroDto> Obtener(string cadenabuscar);

         IEnumerable<RubroDto> ObtenerParaCmb(string cadenabuscar);

        RubroDto ObtenerPorId(long entidadId);
    }
}
