using System.Collections.Generic;
using XCommerce.Servicio.Seguridad.Usuario.DTOs;

namespace XCommerce.Servicio.Seguridad.Usuario
{
    public interface IUsuarioServicio
    {
        /// <summary>
        /// Metodo para Bloquear o Desbloquear el Usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre del USuario</param>
        /// <param name="estado">Estado => True: bloquear; False: desbloquear</param>
        void CambiarEstado(string nombreUsuario, bool estado);

        IEnumerable<UsuarioDto> Obtener(string cadenaBuscar);

        void Crear(long personaId, string apellido, string nombre);

        UsuarioDto ObtenerPorId(long entidadId);

        UsuarioDto ObtenerPorNombreUsuario(string nombre);
    }
}
