using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Iva.IvaDTOs;

namespace XCommerce.Servicio.Core.Iva
{
    public class IvaServicios : IIvaServicios
    {
        public long Insertar(IvaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ivaNuevo = new AccesoDatos.CondicionIva
                {
                    Descripcion = dto.Descripcion
                };

                context.CondicionIvas.Add(ivaNuevo);

                context.SaveChanges();

                return ivaNuevo.Id;
            }
        }

        public void Modificar(IvaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var IvaModificar = context.CondicionIvas
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (IvaModificar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                IvaModificar.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public IEnumerable<IvaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.CondicionIvas
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new IvaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,

                    }).ToList();
            }
        }

        public IvaDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.CondicionIvas
                    .AsNoTracking()
                    .Select(x => new IvaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,

                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
