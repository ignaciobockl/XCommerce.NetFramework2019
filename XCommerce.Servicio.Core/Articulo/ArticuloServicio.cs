using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Articulo.DTOs;
using XCommerce.Servicio.Core.Empleado.DTOs;

namespace XCommerce.Servicio.Core.Articulo
{
    public class ArticuloServicio : IArticuloServicio
    {
        public void Eliminar(long articuloId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var articuloEliminar = context.Articulos
                    .FirstOrDefault(x => x.Id == articuloId);

                if (articuloEliminar == null)
                    throw new Exception("No se encontro el Articulo");

                articuloEliminar.EstaEliminado = true;


                context.SaveChanges();
            }
        }

        public long Insertar(ArticuloDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoArticulo = new AccesoDatos.Articulo
                {
                    Codigo = dto.Codigo,
                    CodigoBarra = dto.CodigoBarra,
                    Abreviatura = dto.Abreviatura,
                    Descripcion = dto.Descripcion,
                    Detalle = dto.Detalle,
                    Foto = dto.Foto,
                    ActivarLimiteVenta = dto.ActivarLimiteVenta,
                    LimiteVenta = dto.LimiteVenta,
                    PermiteStockNegativo = dto.PermiteStockNegativo,
                    EstaDiscontinuado = dto.EstaDiscontinuado,
                    StockMaximo = dto.StockMaximo,
                    StockMinimo = dto.StockMinimo,
                    DescuentaStock = dto.DescuentaStockl,
                    EstaEliminado = false,
                    MarcaId = dto.MarcaId,
                    RubroId = dto.RubroId,
                    Stock = dto.Stock
                };

                context.Articulos.Add(nuevoArticulo);

                context.SaveChanges();

                return nuevoArticulo.Id;
            }
        }

        public void Modificar(ArticuloDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var articuloModificar = context.Articulos
                    .FirstOrDefault(x => x.Id == dto.Id);

                if(articuloModificar == null)
                    throw new Exception("No se encontro el Articulo a Modificar");

                articuloModificar.Codigo = dto.Codigo;
                articuloModificar.CodigoBarra = dto.CodigoBarra;
                articuloModificar.Abreviatura = dto.Abreviatura;
                articuloModificar.Descripcion = dto.Descripcion;
                articuloModificar.Detalle = dto.Detalle;
                articuloModificar.Foto = dto.Foto;
                articuloModificar.ActivarLimiteVenta = dto.ActivarLimiteVenta;
                articuloModificar.LimiteVenta = dto.LimiteVenta;
                articuloModificar.PermiteStockNegativo = dto.PermiteStockNegativo;
                articuloModificar.EstaDiscontinuado = dto.EstaDiscontinuado;
                articuloModificar.StockMaximo = dto.StockMaximo;
                articuloModificar.StockMinimo = dto.StockMinimo;
                articuloModificar.DescuentaStock = dto.DescuentaStockl;
                articuloModificar.EstaEliminado = dto.EstaEliminado;
                articuloModificar.MarcaId = dto.MarcaId;
                articuloModificar.RubroId = dto.RubroId;
                articuloModificar.Stock = dto.Stock;

                context.SaveChanges();
            }
        }

        public IEnumerable<ArticuloDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos
                    .Where(x => x.Descripcion.Contains(cadenaBuscar) ||
                                x.Codigo.Contains(cadenaBuscar) ||
                                x.CodigoBarra.Contains(cadenaBuscar) ||
                                x.Detalle.Contains(cadenaBuscar))
                    .Select(x => new ArticuloDto
                    {
                        Id = x.Id,
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
                        EstaEliminado = x.EstaEliminado,
                        MarcaId = x.MarcaId,
                        RubroId = x.RubroId,
                        Stock = x.Stock
                    }).ToList();
            }
        }

        public ArticuloDto ObtenerPorCodigo(string codigo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos
                    .Select(x => new ArticuloDto
                    {
                        Id = x.Id,
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
                        EstaEliminado = x.EstaEliminado,
                        MarcaId = x.MarcaId,
                        RubroId = x.RubroId,
                        Stock = x.Stock
                    }).FirstOrDefault(x => x.Codigo == codigo);
            }
        }

        public ArticuloDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos
                    .Select(x => new ArticuloDto
                    {
                        Id = x.Id,
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
                        EstaEliminado = x.EstaEliminado,
                        MarcaId = x.MarcaId,
                        RubroId = x.RubroId,
                        Stock = x.Stock
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }

        public void DescontarStock(long articuloId, decimal cantidad)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var articuloActualizar = context.Articulos.OfType<AccesoDatos.Articulo>()
                    .FirstOrDefault(x => x.Id == articuloId);

                if (articuloActualizar == null)
                    throw new Exception("No se encontro el Empleado");

                articuloActualizar.Stock -= cantidad;

                context.SaveChanges();
            }
        }

        public bool VerificarSiExisteCodigo(string codigoArticulo)
        {
            using(var context = new ModeloXCommerceContainer())
            {
                var articulo = context.Articulos.FirstOrDefault(x => x.Codigo == codigoArticulo || x.CodigoBarra == codigoArticulo);

                if(articulo == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public IEnumerable<ArticuloDto> ObtenerParaLookUp(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos
                    .Where(x => x.Descripcion.Contains(cadenaBuscar) ||
                                x.Codigo.Contains(cadenaBuscar) ||
                                x.CodigoBarra.Contains(cadenaBuscar) ||
                                x.Detalle.Contains(cadenaBuscar))
                    .Select(x => new ArticuloDto
                    {
                        Id = x.Id,
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
                        EstaEliminado = x.EstaEliminado,
                        MarcaId = x.MarcaId,
                        RubroId = x.RubroId,
                        Stock = x.Stock
                    }).Where(x => x.EstaEliminado == false && x.EstaDiscontinuado == false).ToList();
            }
        }
    }
}
