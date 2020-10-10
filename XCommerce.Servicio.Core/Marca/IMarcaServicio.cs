using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Marca.DTOs;

namespace XCommerce.Servicio.Core.Marca
{
    public interface IMarcaServicio
    {
        long Insertar(MarcaDto dto);

        void Modificar(MarcaDto dto);

        void Eliminar(long empleadoId);

        // ===================================================== //

        IEnumerable<MarcaDto> Obtener(string cadenaBuscar);

        IEnumerable<MarcaDto> ObtenerParaCmb(string cadenaBuscar);

        MarcaDto ObtenerPorId(long entidadId);
    }
}
