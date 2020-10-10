using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Empresa.DTOs;

namespace XCommerce.Servicio.Core.Empresa
{
    public interface IEmpresaServicio
    {
        long Insertar(EmpresaDto dto);

        void Modificar(EmpresaDto dto);        

        // ===================================================== //

        IEnumerable<EmpresaDto> Obtener(string cadenaBuscar);

        EmpresaDto ObtenerPorId(long entidadId);
    }
}
