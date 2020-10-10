using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core.Reserva.MotivoReserva
{
    public class MotivoReservaServicio : IMotivoReservaServicio
    {
        public long Insertar(MotivoReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoMotivoReserva = new AccesoDatos.MotivoReserva
                {
                    Descripcion = dto.Descripcion
                };

                context.MotivoReservaSet.Add(nuevoMotivoReserva);

                context.SaveChanges();

                return nuevoMotivoReserva.Id;
            }
        }

        public IEnumerable<MotivoReservaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.MotivoReservaSet
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new MotivoReservaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion
                    }).ToList();
            }
        }
    }
}
