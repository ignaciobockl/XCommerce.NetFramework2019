using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Precio.DTOs;

namespace XCommerce.Servicio.Core.Precio
{
    public class PrecioServicio : IPrecioServicio
    {
        public long Insertar(PrecioDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoPrecio = new AccesoDatos.Precio
                {
                    PrecioCosto = dto.PrecioCosto,
                    PrecioPublico = dto.PrecioPublico,
                    FechaActualizacion = dto.FechaActualizacion,
                    ListaPrecioId = dto.ListaPrecioId,
                    ArticuloId = dto.ArticuloId,
                    ActivarHoraVenta = dto.ActivarHoraVenta,
                    HoraVenta = dto.HoraVenta,
                };

                context.Precios.Add(nuevoPrecio);

                context.SaveChanges();

                return nuevoPrecio.Id;
            }
        }

        public void Modificar(PrecioDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarPrecio = context.Precios
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarPrecio == null)
                    throw new Exception("Error, no se encontro la Lista de Precios.");

                ModificarPrecio.PrecioCosto = dto.PrecioCosto;
                ModificarPrecio.PrecioPublico = dto.PrecioPublico;
                ModificarPrecio.FechaActualizacion = dto.FechaActualizacion;
                ModificarPrecio.ListaPrecioId = dto.ListaPrecioId;
                ModificarPrecio.ArticuloId = dto.ArticuloId;
                ModificarPrecio.ActivarHoraVenta = dto.ActivarHoraVenta;
                ModificarPrecio.HoraVenta = dto.HoraVenta;

                context.SaveChanges();
            }
        }

        public PrecioDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Precios.OfType<AccesoDatos.Precio>()
                    .AsNoTracking()
                    .Select(x => new PrecioDto
                    {
                        Id = x.Id,
                        PrecioCosto = x.PrecioCosto,
                        PrecioPublico = x.PrecioPublico,
                        FechaActualizacion = x.FechaActualizacion,
                        ListaPrecioId = x.ListaPrecioId,
                        ArticuloId = x.ArticuloId,
                        ActivarHoraVenta = x.ActivarHoraVenta,
                        HoraVenta = x.HoraVenta

                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
