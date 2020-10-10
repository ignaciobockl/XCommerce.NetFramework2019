using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Comprobante.DTOs;
using XCommerce.Servicio.Core.Empleado.DTOs;
using XCommerce.Servicio.Core.Producto.DTOs;

namespace XCommerce.Servicio.Core.Comprobante
{
    public class ComprobanteSalonServicio : IComprobanteSalonServicio
    {

        public void AgregarItem(long mesaId, decimal cantidad, ProductoMesaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes
                    .OfType<ComprobanteSalon>()
                    .FirstOrDefault(x => x.MesaId == mesaId
                                      && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso);

                if (comprobante == null)
                {
                    throw new Exception("Ocurrio un error al obtener el comprobante");
                }

                var item = comprobante.DetalleComprobantes
                    .FirstOrDefault(x => x.Codigo == dto.Codigo);

                if (item == null)
                {
                    comprobante.DetalleComprobantes.Add(new DetalleComprobante
                    {
                        ArticuloId = (int)dto.Id,
                        
                        Cantidad = cantidad,                        
                        Codigo = dto.Codigo,
                        Descripcion = dto.Descripcion,
                        PrecioUnitario = dto.Precio,
                        SubTotal = dto.Precio * cantidad,
                    });
                }
                else
                {
                    item.Cantidad += cantidad;
                    item.SubTotal = item.Cantidad * item.PrecioUnitario;
                }

                if (dto.DescuentaStock)
                {
                    var producto = context.Articulos.FirstOrDefault(x => x.Id == dto.Id);

                    if (producto == null)
                    {
                        throw new Exception("Ocurrio un error al descontar stock");
                    }
                    if (producto.Stock >= cantidad)
                    {
                        producto.Stock -= cantidad;
                        cantidad -= 1;
                    }
                    
                    

                }

                context.SaveChanges();
            }
        }

        public void Generar(long mesaId, long usuarioId, int comensales, long? mozoId = null)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (context.Comprobantes.OfType<ComprobanteSalon>()
                    .Any(x => x.MesaId == mesaId && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso))
                    return;

                var clienteConsumidorFinal = context.Personas
                    .OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Dni == "99999999");               
                    

                if (clienteConsumidorFinal == null)
                {
                    throw new Exception("Ocurrio un error al obtener el Consumidor Final");
                }

                var mesa = context.Mesas.FirstOrDefault(x => x.Id == mesaId);

                if (mesa == null)
                {
                    throw new Exception("Ocurrio un error al obtener la mesa");
                }

                mesa.EstadoMesa = EstadoMesa.Abierta;

                var nuevoComprobante = new ComprobanteSalon
                {
                    MesaId = mesaId,
                    ClienteId = clienteConsumidorFinal.Id,
                    Comensal = comensales.ToString(),
                    Descuento = 0m,
                    EstadoComprobanteSalon = EstadoComprobanteSalon.EnProceso,
                    Fecha = DateTime.Now,
                    MozoId = mozoId,
                    
                    Numero = 0,
                    SubTotal = 0,
                    Total = 0m,
                    TipoComprobante = TipoComprobante.X,
                    UsuarioId = usuarioId,
                    DetalleComprobantes = new List<DetalleComprobante>()
                };

                context.Comprobantes.Add(nuevoComprobante);

                context.SaveChanges();
            }
        }

        public ComprobanteMesaDto Obtener(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<ComprobanteSalon>()
                    .AsNoTracking()
                    .Include(x => x.Mozo)
                    .Select(x => new ComprobanteMesaDto
                    {
                        ClienteId = x.ClienteId,
                        ComprobanteId = x.Id,
                        Descuento = x.Descuento,
                        Fecha = x.Fecha,
                        MesaId = x.MesaId,
                        Numero = x.Numero,
                        MozoId = x.MozoId,
                        Legajo = x.MozoId.HasValue ? x.Mozo.Legajo : 0,
                        ApellidoMozo = x.MozoId.HasValue ? x.Mozo.Apellido : "NO",
                        NombreMozo = x.MozoId.HasValue ? x.Mozo.Nombre : "ASIGNADO",
                        UsuarioId = x.UsuarioId,
                        Items = x.DetalleComprobantes.Select(c => new DetalleComprobanteSalonDto
                        {
                            Cantidad = c.Cantidad,
                            PrecioUnitario = c.PrecioUnitario,
                            ComprobanteId = c.ComprobanteId,
                            CodigoProducto = c.Codigo,
                            DescripcionProducto = c.Descripcion,
                            DetalleId = c.Id,
                            ProductoId = c.ArticuloId,
                        }).ToList()

                    }).FirstOrDefault(x => x.MesaId == mesaId);
            }
        }

        public ComprobanteMesaDto ObtenerPorId(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<ComprobanteSalon>()
                    .AsNoTracking()
                    .Include(x => x.Mozo)
                    .Select(x => new ComprobanteMesaDto
                    {
                        Id = x.Id,
                        ClienteId = x.ClienteId,
                        ComprobanteId = x.Id,
                        Descuento = x.Descuento,
                        Fecha = x.Fecha,
                        MesaId = x.MesaId,
                        Numero = x.Numero,
                        MozoId = x.MozoId,
                        Legajo = x.MozoId.HasValue ? x.Mozo.Legajo : 0,
                        ApellidoMozo = x.MozoId.HasValue ? x.Mozo.Apellido : "NO",
                        NombreMozo = x.MozoId.HasValue ? x.Mozo.Nombre : "ASIGNADO",
                        UsuarioId = x.UsuarioId,
                        EstadoComprobante = x.EstadoComprobanteSalon,
                        Items = x.DetalleComprobantes.Select(c => new DetalleComprobanteSalonDto
                        {
                            Cantidad = c.Cantidad,
                            PrecioUnitario = c.PrecioUnitario,
                            ComprobanteId = c.ComprobanteId,
                            CodigoProducto = c.Codigo,
                            DescripcionProducto = c.Descripcion,
                            DetalleId = c.Id,
                            ProductoId = c.ArticuloId,

                        }).ToList()

                    }).FirstOrDefault(x => x.MesaId == mesaId && x.EstadoComprobante == EstadoComprobanteSalon.EnProceso);

                
            }
        }

        public ComprobanteMesaDto ObtenerComprobantePorId(long ComprobanteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<ComprobanteSalon>()
                    .AsNoTracking()
                    .Include(x => x.Mozo)
                    .Select(x => new ComprobanteMesaDto
                    {
                        ClienteId = x.ClienteId,
                        ComprobanteId = x.Id,
                        Descuento = x.Descuento,
                        Numero = x.Numero,
                        Fecha = x.Fecha,
                        MesaId = x.MesaId,
                        MozoId = x.MozoId,
                        Comensales = x.Comensal,
                        UsuarioId = x.UsuarioId,
                        EstadoComprobante = x.EstadoComprobanteSalon,
                        Items = x.DetalleComprobantes.Select(c => new DetalleComprobanteSalonDto
                        {
                            Cantidad = c.Cantidad,
                            PrecioUnitario = c.PrecioUnitario,
                            ComprobanteId = c.ComprobanteId,
                            CodigoProducto = c.Codigo,
                            DescripcionProducto = c.Descripcion,
                            DetalleId = c.Id,
                            ProductoId = c.ArticuloId,

                        }).ToList()

                    }).FirstOrDefault(x => x.ComprobanteId == ComprobanteId);
            }
        }

        public void GenerarComprobanteCierre(ComprobanteCierreDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ComprobanteModificar = context.Comprobantes.OfType<ComprobanteSalon>()
                    .FirstOrDefault(x => x.Id == dto.Id);

                var estadoMesa = context.Mesas
                    .FirstOrDefault(x => x.Id == dto.MesaId);

                if (ComprobanteModificar == null)
                    throw new Exception("No se encontro el comprobante");

                ComprobanteModificar.MesaId = dto.MesaId;
                ComprobanteModificar.MozoId = dto.MozoId;
                ComprobanteModificar.Numero = dto.Numero;
                ComprobanteModificar.SubTotal = dto.SubTotal;
                ComprobanteModificar.Total = dto.Total;
                ComprobanteModificar.Fecha = dto.Fecha;
                ComprobanteModificar.Descuento = dto.Descuento;
                ComprobanteModificar.Comensal = dto.Comensales;
                ComprobanteModificar.EstadoComprobanteSalon = EstadoComprobanteSalon.Enviado;
                ComprobanteModificar.TipoComprobante = dto.TipoDeComprobante;
                ComprobanteModificar.Total = dto.Total;
                ComprobanteModificar.SubTotal = dto.SubTotal;
                estadoMesa.EstadoMesa = EstadoMesa.Cerrada;

                context.SaveChanges();
            }
        }

        public void ModificarMozo(long mesaId, EmpleadoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {

                var moZo = context.Personas
                    .OfType<AccesoDatos.Empleado>()
                    .FirstOrDefault(x => x.Id == dto.Id);

                var comprobante = context.Comprobantes
                     .OfType<ComprobanteSalon>()
                     .FirstOrDefault(x => x.MesaId == mesaId
                                       && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso);

                if (moZo == null)
                {
                    throw new Exception("Ocurrio un error al obtener el comprobante");
                }

                
                comprobante.MozoId = moZo.Id;

                context.SaveChanges();
            }
        }

        public long ObtenerNumeroComprobante()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (context.Comprobantes.Any())
                {
                    return (context.Comprobantes
                        .Max(x => x.Id));
                }
                else
                {
                    return 1;
                }
            }
        }

        public void QuitarItem(long mesaId, decimal cantidad, ProductoMesaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes
                    .OfType<ComprobanteSalon>()
                    .FirstOrDefault(x => x.MesaId == mesaId
                                      && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso);

                if (comprobante == null)
                {
                    throw new Exception("Ocurrio un error al obtener el comprobante");
                }

                var item = comprobante.DetalleComprobantes
                    .FirstOrDefault(x => x.Codigo == dto.Codigo);

                if (item == null)
                {
                    return;
                }
                else
                {
                    

                    if (item.Cantidad > 1)
                    {
                        item.Cantidad -= cantidad;
                        item.SubTotal = item.Cantidad * item.PrecioUnitario;
                    }
                    else if (item.Cantidad == 1)
                    {
                        comprobante.DetalleComprobantes.Remove(item);
                        context.DetalleComprobantes.Remove(item);
                    }
                }

                

                context.SaveChanges();
            }
        }

        public void ModificarComensal(long comprobanteId, string comensales)
        {
            using(var contex = new ModeloXCommerceContainer())
            {
                var agregarComensal = contex.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>().FirstOrDefault(x => x.Id == comprobanteId);

                agregarComensal.Comensal = comensales;

                contex.SaveChanges();

            }
        }
    }
}
