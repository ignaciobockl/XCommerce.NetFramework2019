using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.ListaPrecio.DTOs;
using XCommerce.Servicio.Core.Salon.DTOs;

namespace XCommerce.Servicio.Core.Salon
{
    public class SalonServicio : ISalonServicio
    {
        public void Eliminar(long salonId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var salonEliminar = context.Salones
                    .FirstOrDefault(x => x.Id == salonId);

                if (salonEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener el Salón");

                salonEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(SalonDto salonDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var salonNuevo = new AccesoDatos.Salon
                {
                    EstaEliminado = salonDto.EstaEliminado,
                    Descripcion = salonDto.Descripcion,
                    ListaPrecioId = salonDto.ListaPrecioId
                };              

                context.Salones.Add(salonNuevo);

                context.SaveChanges();

                return salonNuevo.Id;
            }
        }

        public void Modificar(SalonDto salonDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var salonModificar = context.Salones
                    .FirstOrDefault(x => x.Id == salonDto.Id);

                if (salonModificar == null)
                    throw new Exception("Ocurrio un error al Obtener el Salón");


                salonModificar.Descripcion = salonDto.Descripcion;
                salonModificar.EstaEliminado = salonDto.EstaEliminado;

                context.SaveChanges();
            }
        }

        public IEnumerable<SalonDto> Obtener(string cadenaBuscar)
        {          

            using (var context = new ModeloXCommerceContainer())
            {
                return context.Salones
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new SalonDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        ListaPrecio = x.ListaPrecio.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public SalonDto ObtenerPorId(long salonID)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Salones
                    .AsNoTracking()
                    .Select(x => new SalonDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        ListaPrecio = x.ListaPrecio.Descripcion,
                        EstaEliminado = x.EstaEliminado,

                    }).FirstOrDefault(x => x.Id == salonID);
            }
        }
    }
}
