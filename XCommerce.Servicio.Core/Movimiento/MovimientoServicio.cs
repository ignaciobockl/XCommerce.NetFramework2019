using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Movimiento.DTOs;
using static Presentacion.Helpers.DatosConstantes;

namespace XCommerce.Servicio.Core.Movimiento
{
    public class MovimientoServicio : IMovimientoServicio
    {
        public long Insertar(MovimientoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoMoviento = new AccesoDatos.Movimiento
                {
                    CajaId = dto.CajaId,
                    ComprobanteId = dto.ComprobanteId,
                    TipoMovimento = dto.TipoMovimiento,
                    UsuarioId = (long)dto.UsuarioId,
                    Monto = dto.Monto,
                    Fecha = dto.Fecha,
                    Descripcion = dto.Descripcion
                };

                context.Movimientos.Add(nuevoMoviento);

                context.SaveChanges();

                return nuevoMoviento.Id;
            }
        }

        public void Modificar(MovimientoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var movimientoModificar = context.Movimientos
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (movimientoModificar == null)
                    throw new Exception("No se encontro el Movimiento");

                movimientoModificar.CajaId = CajaAbiertaId;
                movimientoModificar.ComprobanteId = dto.ComprobanteId;
                movimientoModificar.TipoMovimento = dto.TipoMovimiento;
                movimientoModificar.UsuarioId = (long)dto.UsuarioId;
                movimientoModificar.Monto = dto.Monto;
                movimientoModificar.Fecha = dto.Fecha;
                movimientoModificar.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public IEnumerable<MovimientoDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Movimientos
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new MovimientoDto
                    {
                        Id = x.Id,
                        CajaId = x.CajaId,
                        ComprobanteId = x.ComprobanteId,
                        TipoMovimiento = x.TipoMovimento,
                        UsuarioId = x.UsuarioId,
                        Monto = x.Monto,
                        Fecha = x.Fecha,
                        Descripcion = x.Descripcion
                    }).ToList();
            }
        }

        public MovimientoDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Movimientos
                    .Select(x => new MovimientoDto
                    {
                        Id = x.Id,
                        CajaId = x.CajaId,
                        ComprobanteId = x.ComprobanteId,
                        TipoMovimiento = x.TipoMovimento,
                        UsuarioId = x.UsuarioId,
                        Monto = x.Monto,
                        Fecha = x.Fecha,
                        Descripcion = x.Descripcion
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
