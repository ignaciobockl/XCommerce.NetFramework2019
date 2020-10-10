using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Comprobante.DTOs;
using XCommerce.Servicio.Core.Comprobante.Kiosko.DTOs;
using XCommerce.Servicio.Core.Kiosko.DTOs;

namespace XCommerce.Servicio.Core.Comprobante.Kiosko
{
    public class ComprobanteKioskoServicio : IComprobanteKioskoServicio
    {
        public void AgregarItem(DetalleComprobanteKioscoDto dto, ComprobanteKioskoDto comprobanteDto)
        {
            if (comprobanteDto.Items != null)
            {
                var item = comprobanteDto.Items
                    .FirstOrDefault(x => x.CodigoProducto == dto.CodigoProducto);

                if (item == null)
                {
                    comprobanteDto.Items.Add(dto);
                }
                else
                {
                    item.Cantidad += dto.Cantidad;
                }
            }
            else
            {
                comprobanteDto.Items.Add(dto);
            }
        }

        public void GenerarComprobante(ComprobanteKioskoDto dto, long cajaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoComprobante = new ComprobanteFactura
                {
                    Numero = Convert.ToInt32(UltimoComprobanteId()),
                    Fecha = DateTime.Now,
                    SubTotal = dto.SubTotal,
                    Descuento = dto.Descuento,
                    Total = dto.Total,
                    UsuarioId = dto.UsuarioId,
                    ClienteId = dto.ClienteId,
                    TipoComprobante = dto.TipoComprobante
                };

                context.Comprobantes.Add(nuevoComprobante);

                context.SaveChanges();

                var comprobante = context.Comprobantes.FirstOrDefault(x => x.Numero == dto.Numero);

                foreach (var items in dto.Items)
                {
                    comprobante.DetalleComprobantes.Add(new AccesoDatos.DetalleComprobante
                    {
                        ComprobanteId = comprobante.Id,
                        Codigo = items.CodigoProducto,
                        Descripcion = items.DescripcionProducto,
                        PrecioUnitario = items.PrecioUnitario,
                        Cantidad = items.Cantidad,
                        SubTotal = items.SubTotalLinea,
                        ArticuloId = items.ArticuloId
                    });
                }

                context.SaveChanges();
            }
        }

        public long UltimoComprobanteId()
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

        public ComprobanteKioskoDto traerComprobantePorNumero(int numeroComprobante)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobanteRetornar = context.Comprobantes.Select(l => new ComprobanteKioskoDto
                {
                        Id = l.Id,
                        Numero = l.Numero,
                        SubTotal = l.SubTotal,
                        TipoComprobante = l.TipoComprobante,
                        Total = l.Total,
                        UsuarioId = l.UsuarioId,
                        Descuento = l.Descuento, Fecha = l.Fecha,
                        ClienteId = l.ClienteId,
                }).FirstOrDefault(x => x.Numero == numeroComprobante);

                if (comprobanteRetornar == null)
                {
                    throw new Exception(" No se encontró el comprobante");
                     
                }

                return comprobanteRetornar;




                


            }
        }
    }
}
