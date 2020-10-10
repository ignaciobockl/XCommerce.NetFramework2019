using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Reserva.DTOs;

namespace XCommerce.Servicio.Core.Reserva
{
    public class ReservaServicio : IReservaServicio
    {
        public long Insertar(ReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevaReserva = new AccesoDatos.Reserva
                {
                    Fecha = dto.Fecha,
                    Senia = dto.Senia,
                    EstadoReserva = dto.EstadoReserva,
                    MesaId = dto.MesaId,
                    ClienteId = dto.MesaId,
                    UsuarioId = dto.UsuarioId,
                    MotivoReservaId = dto.MotivoReservaId
                };

                context.Reservas.Add(nuevaReserva);

                context.SaveChanges();

                return nuevaReserva.Id;
            }
        }

        public void Modificar(ReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var reservarModificar = context.Reservas
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (reservarModificar == null)
                    throw new Exception("No se encotro la Reserva a Modificar");

                reservarModificar.Fecha = dto.Fecha;
                reservarModificar.Senia = dto.Senia;
                reservarModificar.EstadoReserva = dto.EstadoReserva;
                reservarModificar.MesaId = dto.MesaId;
                reservarModificar.ClienteId = dto.ClienteId;
                reservarModificar.UsuarioId = dto.UsuarioId;
                reservarModificar.MotivoReservaId = dto.MotivoReservaId;

                context.SaveChanges();
            }
        }

        public IEnumerable<ReservaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Reservas
                    .Where(x => x.Cliente.Nombre.Contains(cadenaBuscar)||
                                x.Cliente.Apellido.Contains(cadenaBuscar))
                    .Select(x => new ReservaDto
                    {
                        Id = x.Id,
                        Fecha = x.Fecha,
                        Senia = x.Senia,
                        EstadoReserva = x.EstadoReserva,
                        MesaId = x.MesaId,
                        ClienteId = x.ClienteId,
                        UsuarioId = x.UsuarioId,
                        MotivoReservaId = x.MotivoReservaId
                    }).ToList();
            }
        }

        public ReservaDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Reservas
                    .Select(x => new ReservaDto
                    {
                        Id = x.Id,
                        Fecha = x.Fecha,
                        Senia = x.Senia,
                        EstadoReserva = x.EstadoReserva,
                        MesaId = x.MesaId,
                        ClienteId = x.ClienteId,
                        UsuarioId = x.UsuarioId,
                        MotivoReservaId = x.MotivoReservaId
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
