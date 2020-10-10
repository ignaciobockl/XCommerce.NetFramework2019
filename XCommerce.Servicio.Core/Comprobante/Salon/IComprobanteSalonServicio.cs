using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Comprobante.DTOs;
using XCommerce.Servicio.Core.Empleado.DTOs;
using XCommerce.Servicio.Core.Producto.DTOs;

namespace XCommerce.Servicio.Core.Comprobante
{
    public interface IComprobanteSalonServicio
    {
        void Generar(long mesaId, long usuarioId, int comensales, long? mozoId = null);

        ComprobanteMesaDto Obtener(long mesaId);

        ComprobanteMesaDto ObtenerPorId(long mesaId);

        void AgregarItem(long mesaId, decimal cantidad, ProductoMesaDto dto);

        void QuitarItem(long mesaId, decimal cantidad, ProductoMesaDto dto);

        ComprobanteMesaDto ObtenerComprobantePorId(long ComprobanteId);

        void GenerarComprobanteCierre(ComprobanteCierreDto dto);

        void ModificarMozo(long mesaId, EmpleadoDto ddto);

        long ObtenerNumeroComprobante();

        void ModificarComensal(long comprobanteId, string comensales);

        
    }
}
