using System;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Articulo.DTOs;
using XCommerce.Servicio.Core.Producto.DTOs;


namespace XCommerce.Servicio.Core.Producto
{
    public class ProductoServicio : IProductoServicio
    {
        public ProductoMesaDto ObtenerPorCodigo(long mesaId, string codigo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                try
                {
                    return context.Articulos
                   .Include(x => x.Precios)
                   .Include("Precios.ListaPrecio")
                   .Include("Precios.ListaPrecio.Salones")
                   .Include("Precios.ListaPrecio.Salones.Mesas")
                   .AsNoTracking()
                   .Select(x => new ProductoMesaDto
                   {
                       Id = x.Id,
                       Descripcion = x.Descripcion,
                       EstaEliminado = x.EstaEliminado,
                       Codigo = x.Codigo,
                       CodigoBarra = x.CodigoBarra,
                       Stock = x.Stock,
                       DescuentaStock = x.DescuentaStock,
                       Precio = x.Precios
                       .FirstOrDefault(l => l.ListaPrecio.Salon.Any(s => s.Mesas.Any(m => m.Id == mesaId))
                                         && l.ArticuloId == x.Id
                                         && l.FechaActualizacion == context.Precios
                                              .Where(l2 => l2.ListaPrecio.Salon.Any(
                                                           s2 => s2.Mesas.Any(m2 => m2.Id == mesaId))
                                                      && l2.ArticuloId == x.Id)
                                              .Max(max => max.FechaActualizacion)).PrecioPublico

                   }).FirstOrDefault(x => x.Codigo == codigo
                                       || x.CodigoBarra == codigo);

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public ProductoKioskoDto ObtenerPorCodigoKiosko(string codigo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                try
                {
                    var producto = context.Articulos
                       .Include(x => x.Precios)
                       .Include("Precio.ListaPrecio")
                       .Include("Precio.Articulo")
                       .AsNoTracking()
                       .Select(x => new ProductoKioskoDto
                       {
                           Id = x.Id,
                           Codigo = x.Codigo,
                           CodigoBarra = x.CodigoBarra,
                           Descripcion = x.Descripcion,
                           Precio = context.Precios.Where(h => h.ListaPrecio.Descripcion == "Lista Kiosko")
                               .FirstOrDefault(l => l.Articulo.Codigo == codigo).PrecioPublico,
                           DescuentaStock = x.DescuentaStock

                       }).FirstOrDefault(x => x.Codigo == codigo || x.CodigoBarra == codigo);                    

                    return producto;
                }
                catch (Exception)
                {

                    return null;
                }                
            }
        }

        public bool TieneStock(string codigo, decimal cantidad)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var producto = context.Articulos
                    .Select(x => new ArticuloDto
                    {
                        Codigo = x.Codigo,
                        CodigoBarra = x.CodigoBarra,
                        Abreviatura = x.Abreviatura,
                        Descripcion = x.Descripcion,
                        Detalle = x.Detalle,
                        Foto = x.Foto,
                        ActivarLimiteVenta = x.ActivarLimiteVenta,
                        LimiteVenta = x.LimiteVenta,
                        PermiteStockNegativo = x.PermiteStockNegativo,
                        EstaDiscontinuado = x.EstaDiscontinuado,
                        StockMaximo = x.StockMaximo,
                        StockMinimo = x.StockMinimo,
                        DescuentaStockl = x.DescuentaStock,
                        MarcaId = x.MarcaId,
                        RubroId = x.RubroId,
                        Stock = x.Stock
                    }).FirstOrDefault(x => x.Codigo == codigo || x.CodigoBarra == codigo);

                if (producto.ActivarLimiteVenta)
                {
                    return true;
                }

                if (producto.PermiteStockNegativo)
                {
                    return true;
                }
                else if (producto.Stock < producto.StockMinimo)
                {
                    return false;
                }

                if (cantidad > producto.Stock)
                {
                    return false;
                }
                else if (cantidad > producto.Stock && producto.PermiteStockNegativo)
                {
                    return true;
                }
                else if (cantidad < producto.Stock)
                {
                    return true;
                }

                return true;
            }
        }
    }
}
