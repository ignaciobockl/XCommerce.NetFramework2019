using System.Collections.Generic;
using XCommerce.Servicio.Core.Cliente.DTOs;

namespace XCommerce.Servicio.Core.Cliente
{
    public interface IClienteServicio
    {
        long Insertar(ClienteDto dto);

        void Modificar(ClienteDto dto);

        void Eliminar(long clienteId);

        //===================================================//

        IEnumerable<ClienteDto> Obtener(string cadenaBuscar);

        IEnumerable<ClienteDto> ObtenerParaLoockUp(string cadenaBuscar);

        ClienteDto ObtenerPorId(long clienteId);

        ClienteDto ObtenerPorDni(string clienteDni);

        decimal MontoDisponibleCuentaCorriente(long clienteId);

        ClienteDto ObtenerPorDniParaModificar(string clienteDni, long EntidadId);

        void PagarCuentaCorriente(long clienteId);

        void ModificarCuentaCorriente(ClienteDto dto);

        bool TieneCuentaCorriente(long clienteId);
    }
}
