using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace XCommerce.Servicio.Core.FormaPago
{
    public class FormaPagoServicio : IFormaPagoServicio
    {
        public long Insertar(FormaPagoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevaFormaPago = new AccesoDatos.FormaPago
                {
                    ComprobanteId = dto.ComprobanteId,
                    TipoFormaPago = dto.TipoFormaPago,
                    Monto = dto.Monto
                };

                context.FormasPagos.Add(nuevaFormaPago);

                context.SaveChanges();

                return nuevaFormaPago.Id;
            }
        }

        public FormaPagoDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.FormasPagos
                    .Select(x => new FormaPagoDto
                    {
                        Id = x.Id,
                        ComprobanteId = x.ComprobanteId,
                        TipoFormaPago = x.TipoFormaPago,
                        Monto = x.Monto
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
