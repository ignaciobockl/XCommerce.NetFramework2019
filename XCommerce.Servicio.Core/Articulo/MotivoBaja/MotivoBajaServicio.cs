using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Articulo.MotivoBaja.DTOs;

namespace XCommerce.Servicio.Core.Articulo.MotivoBaja
{
    public class MotivoBajaServicio : IMotivoBajaServicio
    {
        public long Insertar(MotivoBajaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoMotivoBaja = new AccesoDatos.MotivoBaja
                {
                    Descripcion = dto.Descripcion
                };

                context.MotivosBajas.Add(nuevoMotivoBaja);

                context.SaveChanges();

                return nuevoMotivoBaja.Id;
            }
        }

        public IEnumerable<MotivoBajaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.MotivosBajas
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new MotivoBajaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        
                    }).ToList();
            }
        }
    }
}
