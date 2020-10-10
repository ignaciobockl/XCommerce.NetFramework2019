using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Kiosko.DTOs;

namespace XCommerce.Servicio.Core.Kiosko
{
    public class DetalleComprobanteKioscoServicio : IDetalleComprobanteKioscoServicio
    {
        public DetalleComprobanteKioscoDto Crear(decimal cantidad, ProductoKioscoDto dto)
        {
            return new DetalleComprobanteKioscoDto
            {
                ProductoId = dto.Id,
                CodigoProducto = dto.Codigo,
                DescripcionProducto = dto.Descripcion,
                PrecioUnitario = dto.Precio,
                Cantidad = cantidad
            };
        }

        public void Cargar(DetalleComprobanteKioscoDto dto, long comprobanteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoDetalle = new AccesoDatos.DetalleComprobante()
                {
                    ComprobanteId = comprobanteId,
                    Codigo = dto.CodigoProducto,
                    Descripcion = dto.DescripcionProducto,
                    PrecioUnitario = dto.PrecioUnitario,
                    Cantidad = dto.Cantidad,
                    SubTotal = dto.SubTotalLinea,
                    ArticuloId = (int)dto.ProductoId
                };

                context.DetalleComprobantes.Add(nuevoDetalle);

                context.SaveChanges();
            }
        }
    }
}
