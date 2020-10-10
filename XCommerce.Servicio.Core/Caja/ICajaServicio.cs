using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Caja.DTOs;
using XCommerce.Servicio.Core.Movimiento.DTOs;

namespace XCommerce.Servicio.Core.Caja
{
    public interface ICajaServicio
    {
        long Abrir(long usuarioId, decimal montoApertura);

        void Cerrar(long usuarioId, decimal MontoCierre, long cajaId, decimal montosistema);

        CajaDto Obtener(long CajaId);

        bool VerificarSiExisteCajaAbierta(long usuarioLogueadoId);

        CajaDto ObtenerIdporUsuario(long UsuarioId);

        void ActualizarMontoDelSistema(decimal MontoVenta, long Cajaid);

        void RealizarMovimiento(MovimientoDto movimiento);

        void GenerarDetalleCaja(MovimientoDto movimiento);
    }
}
