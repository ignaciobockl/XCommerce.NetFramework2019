using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Producto.DTOs;

namespace XCommerce.Servicio.Core.Producto
{
    public interface IProductoServicio
    {
        ProductoMesaDto ObtenerPorCodigo(long mesaId, string codigo);

        //============================================================//
        //                           KIOSKO                           //
        //============================================================//

        ProductoKioskoDto ObtenerPorCodigoKiosko(string codigo);

        bool TieneStock(string codigo, decimal cantidad);
    }
}
