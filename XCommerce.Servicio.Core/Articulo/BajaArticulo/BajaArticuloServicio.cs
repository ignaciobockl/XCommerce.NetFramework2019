using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Articulo.BajaArticulo.DTOs;

namespace XCommerce.Servicio.Core.Articulo.BajaArticulo
{
    public class BajaArticuloServicio : IBajaArticuloServicio
    {
        public long Insertar(BajaArticuloDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoBajaArticulo = new AccesoDatos.BajaArticulo
                {
                    Fecha = dto.Fecha,
                    Cantidad = dto.Cantidad,
                    Observacion = dto.Observacion,
                    MotivoBajaId = dto.MotivoBajaId,
                    ArticuloId = dto.ArticuloId
                };

                context.BajaArticulos.Add(nuevoBajaArticulo);

                context.SaveChanges();

                return nuevoBajaArticulo.Id;

            }
        }

        public IEnumerable<BajaArticuloDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.BajaArticulos
                    .Where(x => x.Articulo.Codigo.Contains(cadenaBuscar) ||
                                x.Articulo.Descripcion.Contains(cadenaBuscar) ||
                                x.Observacion.Contains(cadenaBuscar)
                    )
                    .Select(x => new BajaArticuloDto
                    {
                        Id = x.Id,
                        Fecha = x.Fecha,
                        Cantidad = x.Cantidad,
                        Observacion = x.Observacion,
                        MotivoBajaId = x.MotivoBajaId,
                        ArticuloId = x.ArticuloId
                    }).ToList();
            }
        }
    }
}
