using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Articulo.DTOs;
using XCommerce.Servicio.Core.Empleado.DTOs;

namespace XCommerce.Servicio.Core.Articulo
{
    public interface IArticuloServicio
    {
        long Insertar(ArticuloDto dto);

        void Modificar(ArticuloDto dto);

        void Eliminar(long articuloId);

        //======================================//

        IEnumerable<ArticuloDto> Obtener(string cadenaBuscar);

        IEnumerable<ArticuloDto> ObtenerParaLookUp(string cadenaBuscar);

        ArticuloDto ObtenerPorId(long entidadId);

        ArticuloDto ObtenerPorCodigo(string codigo);

        void DescontarStock(long articuloId, decimal cantidad);

        bool VerificarSiExisteCodigo(string codigoArticulo);
    }
}
