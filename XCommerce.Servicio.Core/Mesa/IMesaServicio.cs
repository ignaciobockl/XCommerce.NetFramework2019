using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Mesa.DTOs;

namespace XCommerce.Servicio.Core.Mesa
{
    public interface IMesaServicio
    {
        long Insertar(MesaDto mesadto);

        void Modificar(MesaDto mesadto);

        void Eliminar(long mesaId);

        IEnumerable<MesaDto> Obtener(string cadenaBuscar);

        IEnumerable<MesaDto> ObtenerPorSalon(long SalonId, string cadenaBuscar);

        MesaDto ObtenerPorId(long mesaId);

        int ObtenerSiguienteMesa();

        void CambiarEstado(long mesaId, EstadoMesa estado);
    }
}
