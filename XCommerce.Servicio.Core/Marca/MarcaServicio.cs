using System;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Marca.DTOs;

namespace XCommerce.Servicio.Core.Marca
{
    public class MarcaServicio : IMarcaServicio
    {
        public void Eliminar(long marcaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var marcaEliminar = context.Marcas
                    .FirstOrDefault(x => x.Id == marcaId);

                if (marcaEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                marcaEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(MarcaDto marcaDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var marcaNueva = new AccesoDatos.Marca
                {
                    Descripcion = marcaDto.Descripcion
                };

                context.Marcas.Add(marcaNueva);

                context.SaveChanges();

                return marcaNueva.Id;
            }
        }

        public void Modificar(MarcaDto marcaDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var marcaModificar = context.Marcas
                    .FirstOrDefault(x => x.Id == marcaDto.Id);

                if (marcaModificar == null)
                    throw new Exception("Ocurrio un error al Obtener la Marca");

                marcaModificar.Descripcion = marcaDto.Descripcion;

                context.SaveChanges();
            }
        }

        public IEnumerable<MarcaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Marcas
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new MarcaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public IEnumerable<MarcaDto> ObtenerParaCmb(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Marcas
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new MarcaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).Where(x => x.EstaEliminado == false).ToList();
            }
        }

        public MarcaDto ObtenerPorId(long marcaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Marcas
                    .AsNoTracking()
                    .Select(x => new MarcaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).FirstOrDefault(x => x.Id == marcaId);
            }
        }
    }
}
