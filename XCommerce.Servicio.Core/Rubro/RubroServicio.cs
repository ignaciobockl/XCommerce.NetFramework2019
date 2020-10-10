using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Rubro.DTOS;

namespace XCommerce.Servicio.Core.Rubro
{
    public class RubroServicio : IRubroSerivicio
    {
        public void Eliminar(long rubroId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var rubroEliminar = context.Rubros
                    .FirstOrDefault(x => x.Id == rubroId);

                if (rubroEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener el Rubro");

                rubroEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(RubroDto rubroDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var rubroNuevo = new AccesoDatos.Rubro
                {
                    Descripcion = rubroDto.Descripcion
                };

                context.Rubros.Add(rubroNuevo);

                context.SaveChanges();

                return rubroNuevo.Id;
            }
        }

        public void Modificar(RubroDto rubroDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var rubroModificar = context.Rubros
                    .FirstOrDefault(x => x.Id == rubroDto.Id);

                if (rubroModificar == null)
                    throw new Exception("Ocurrio un error al Obtener el Rubro");

                rubroModificar.Descripcion = rubroDto.Descripcion;

                context.SaveChanges();            
            }
        }

        public IEnumerable<RubroDto> Obtener(string cadenabuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Rubros
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenabuscar))
                    .Select(x => new RubroDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

        public IEnumerable<RubroDto> ObtenerParaCmb(string cadenabuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Rubros
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenabuscar))
                    .Select(x => new RubroDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).Where(x=>x.EstaEliminado == false).ToList();
            }
        }

        public RubroDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Rubros
                    .AsNoTracking()
                    .Select(x => new RubroDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
