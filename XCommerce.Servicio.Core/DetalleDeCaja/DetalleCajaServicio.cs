using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.DetalleDeCaja.DTOs;

namespace XCommerce.Servicio.Core.DetalleDeCaja
{
    public class DetalleCajaServicio : IDetalleCajaServicio
    {
        public void InsertarDetalle(DetalleCajaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoDetalle = new DetalleCaja();

                nuevoDetalle.Id = dto.Id;
                nuevoDetalle.CajaId = dto.CajaId;
                nuevoDetalle.Monto = dto.Monto;
                nuevoDetalle.TipoPago = dto.FormaPago;

                context.DetalleCajas.Add(nuevoDetalle);
                context.SaveChanges();


            }
        }
    }
}
