using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Articulo.DTOs;
using XCommerce.Servicio.Core.ListaPrecio.DTOs;

namespace XCommerce.Servicio.Core.ListaPrecio
{
    public class ListaPrecioServicio : IListaPrecioServicio
    {
        public void Eliminar(long listaPrecioId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ListaPrecioEliminar = context.ListaPrecios
                    .FirstOrDefault(x => x.Id == listaPrecioId);

                if (ListaPrecioEliminar == null)
                    throw new Exception("No se encontro la Lista de Precios");

                ListaPrecioEliminar.EstaEliminado = true;


                context.SaveChanges();
            }
        }

        public long Insertar(ListaPrecioDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevaListaPrecio = new AccesoDatos.ListaPrecio
                {
                    Descripcion = dto.Descripcion,
                    Rentabilidad = dto.Rentabilidad,
                    EstaEliminado = false
                };

                context.ListaPrecios.Add(nuevaListaPrecio);

                context.SaveChanges();

                return nuevaListaPrecio.Id;
            }

        }

        public void Modificar(ListaPrecioDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var listaPrecioModificar = context.ListaPrecios
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (listaPrecioModificar == null)
                    throw new Exception("No se encontro la Lista de Precio a Modificar");

                listaPrecioModificar.Descripcion = dto.Descripcion;
                listaPrecioModificar.Rentabilidad = dto.Rentabilidad;
                listaPrecioModificar.EstaEliminado = dto.EstaEliminado;

                context.SaveChanges();
            }
        }

        public IEnumerable<ListaPrecioDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.ListaPrecios
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new ListaPrecioDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Rentabilidad = x.Rentabilidad,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public ListaPrecioDto ObtenerPorId(long? articuloId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.ListaPrecios
                    .Select(x => new ListaPrecioDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Rentabilidad = x.Rentabilidad,
                        EstaEliminado = x.EstaEliminado

                    }).FirstOrDefault(x => x.Id == articuloId);
            }
        }

        public IEnumerable<ArticuloDto> ObtenerPorLista(long listaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Precios
                    .Include("Precios.ListaPrecios")
                    .Include("Precios.Articulos").Where(a=>a.ListaPrecioId == listaId)
                    .Select(l => new ArticuloDto
                    {
                        Id = l.ArticuloId,
                        Descripcion = l.Articulo.Descripcion,
                        Stock = l.Articulo.Stock,

                    }).ToList();             
                    
            }
        }

        public long UltimaListaId()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (context.ListaPrecios.Any())
                {
                    return (context.ListaPrecios
                        .Max(x => x.Id + 1));
                }
                else
                {
                    return 1;
                }
            }
        }

        public bool VerificarSiExisteLaListaDePrecio()
        {
            throw new NotImplementedException();
        }
    }
}
