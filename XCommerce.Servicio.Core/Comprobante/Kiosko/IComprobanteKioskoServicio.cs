using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Comprobante.Kiosko.DTOs;
using XCommerce.Servicio.Core.Kiosko.DTOs;

namespace XCommerce.Servicio.Core.Comprobante.Kiosko
{
    public interface IComprobanteKioskoServicio
    {
        void GenerarComprobante(ComprobanteKioskoDto dto,
            long cajaId);

        void AgregarItem(DetalleComprobanteKioscoDto dto,
            ComprobanteKioskoDto comprobanteDto);

        long UltimoComprobanteId();

        ComprobanteKioskoDto traerComprobantePorNumero(int numeroComprobante);

    }
}
