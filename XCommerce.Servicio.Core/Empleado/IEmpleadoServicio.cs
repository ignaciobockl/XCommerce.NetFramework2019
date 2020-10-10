using System.Collections.Generic;
using XCommerce.Servicio.Core.Empleado.DTOs;

namespace XCommerce.Servicio.Core.Empleado
{
    public interface IEmpleadoServicio
    {
        long Insertar(EmpleadoDto dto);

        void Modificar(EmpleadoDto dto);

        void Eliminar(long empleadoId);

        // ===================================================== //

        IEnumerable<EmpleadoDto> Obtener(string cadenaBuscar);

        EmpleadoDto ObtenerPorId(long entidadId);

        int ObtenerSiguienteLegajo();

        EmpleadoDto ObtenerPorDni(string Dni);

        EmpleadoDto ObtenerPorDniParaModificar(string Dni, long EntidadId);

        EmpleadoDto ObtenerPorLegajo(string legajo);
    }
}
