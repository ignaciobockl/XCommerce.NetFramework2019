using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;

using XCommerce.Servicio.Core.Mesa.DTOs;

namespace XCommerce.Servicio.Core.Mesa
{
    public class MesaServicio : IMesaServicio
    {
        public void Eliminar(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesaEliminar = context.Mesas
                    .FirstOrDefault(x => x.Id == mesaId);

                if (mesaEliminar == null)
                    throw new Exception("No se encontro la mesa");

                mesaEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(MesaDto mesadto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevaMesa = new AccesoDatos.Mesa
                {
                    Numero = mesadto.Numero,
                    Descripcion = mesadto.Descripcion,
                    SalonId = mesadto.SalonId,
                    EstadoMesa = EstadoMesa.Cerrada,
                };
                context.Mesas.Add(nuevaMesa);

                context.SaveChanges();

                return nuevaMesa.Id;
            }
        }

        public void Modificar(MesaDto mesadto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesaModificar = context.Mesas
                   .FirstOrDefault(x => x.Id == mesadto.Id);

                if (mesaModificar == null)
                    throw new Exception("No se encontro la mesa");

                mesaModificar.Numero = mesadto.Numero;
                mesaModificar.Descripcion = mesadto.Descripcion;
                mesaModificar.SalonId = mesadto.SalonId;
              

                context.SaveChanges();
            }
        }

        public MesaDto ObtenerPorId(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas
                    .AsNoTracking()
                    .Select(x => new MesaDto
                    {
                        Id = x.Id,
                        Numero = x.Numero,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        estadoMesa = x.EstadoMesa,
                        SalonId = x.SalonId,
                        Salon = x.Salon.Descripcion

                    }).FirstOrDefault(x => x.Id == mesaId);
            }
        }

        public IEnumerable<MesaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new MesaDto
                    {
                        Id = x.Id,
                        Numero = x.Numero,
                        Descripcion = x.Descripcion,
                        SalonId = x.SalonId,
                        Salon = x.Salon.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        estadoMesa = x.EstadoMesa

                    }).ToList();
            }
        }

        public IEnumerable<MesaDto> ObtenerPorSalon(long SalonId, string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas
                    .AsNoTracking()
                    .Include(x => x.Salon)
                    .Where(x => x.SalonId == SalonId
                                && x.Salon.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new MesaDto
                    {
                        Id = x.Id,
                        Numero = x.Numero,
                        Descripcion = x.Descripcion,
                        SalonId = x.SalonId,
                        Salon = x.Salon.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        estadoMesa = x.EstadoMesa,
                        

                    }).ToList();
            }
        }

        public int ObtenerSiguienteMesa()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (context.Mesas.Any())
                {

                    return context.Mesas
                               .Max(x => x.Numero) + 1;
                }
                else
                {
                    return 1;
                }
            }
        }

        public void CambiarEstado(long mesaId, EstadoMesa estado)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesaModificar = context.Mesas
                    .FirstOrDefault(x => x.Id == mesaId);

                if (mesaModificar == null)
                    throw new Exception("No se encontro la mesa");

                mesaModificar.EstadoMesa = estado;


                context.SaveChanges();
            }
        }
    }
}
