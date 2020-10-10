using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Kiosko.DTOs;

namespace XCommerce.Servicio.Core.Kiosko
{
    public interface IDetalleComprobanteKioscoServicio
    {
        DetalleComprobanteKioscoDto Crear(decimal cantidad, ProductoKioscoDto dto);
        void Cargar(DetalleComprobanteKioscoDto dto, long comprobanteId);
    }
}
