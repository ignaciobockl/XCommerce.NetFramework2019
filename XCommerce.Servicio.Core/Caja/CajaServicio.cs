using System;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Caja.DTOs;
using XCommerce.Servicio.Core.Movimiento.DTOs;

namespace XCommerce.Servicio.Core.Caja
{
    public class CajaServicio : ICajaServicio
    {
        public long Abrir(long usuarioId, decimal montoApertura)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var AbrirCaja = new AccesoDatos.Caja
                {
                    FechaApertura = DateTime.Now,
                    MontoApertura = montoApertura,
                    UsuarioAperturaId = usuarioId,
                    UsuarioCierreId = null,
                    MontoCierre = null,
                    Diferencia = 0m,
                    MontoSistema = montoApertura,
                    FechaCierre = null
                };

                context.Cajas.Add(AbrirCaja);
                context.SaveChanges();
                return AbrirCaja.Id;
            }
        }

        public void ActualizarMontoDelSistema(decimal MontoVenta, long Cajaid)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarMonto = context.Cajas
                    .FirstOrDefault(x => x.Id == Cajaid);

                if (ModificarMonto == null)
                {
                    throw new Exception("Error");
                }
                else
                {
                    ModificarMonto.MontoSistema += MontoVenta;
                    context.SaveChanges();
                }
            }
        }

        public void Cerrar(long usuarioId, decimal MontoCierre, long cajaId, decimal montosistema)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var CerrarCaja = context.Cajas.OfType<AccesoDatos.Caja>()
                    .FirstOrDefault(x => x.FechaCierre == null & x.Id == cajaId);
                if (CerrarCaja == null)
                {
                    throw new Exception("Error");
                }
                else
                {
                    CerrarCaja.FechaCierre = DateTime.Now;
                    CerrarCaja.UsuarioCierreId = usuarioId;
                    CerrarCaja.MontoCierre = MontoCierre;
                    CerrarCaja.Diferencia = MontoCierre - montosistema;

                    context.SaveChanges();
                }
            }
        }

        public CajaDto Obtener(long CajaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Cajas.OfType<AccesoDatos.Caja>()
                    .Select(x => new CajaDto
                    {
                        Id = x.Id,
                        Diferencia = x.Diferencia,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        MontoSistema = x.MontoSistema,
                        UsuarioAperturaId = x.UsuarioAperturaId,
                        UsuarioCierreId = x.UsuarioCierreId

                    }).FirstOrDefault(x => x.Id == CajaId);
            }
        }

        public CajaDto ObtenerIdporUsuario(long UsuarioId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Cajas.OfType<AccesoDatos.Caja>()
                    .Select(x => new CajaDto
                    {
                        Id = x.Id,
                        Diferencia = x.Diferencia,
                        FechaApertura = x.FechaApertura,
                        MontoApertura = x.MontoApertura,
                        MontoSistema = x.MontoSistema,
                        UsuarioAperturaId = x.UsuarioAperturaId,
                        FechaCierre = x.FechaCierre

                    }).FirstOrDefault(x => x.FechaCierre == null && x.UsuarioAperturaId == UsuarioId);

            }
        }

        public bool VerificarSiExisteCajaAbierta(long usuarioLogueadoId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Cajas.OfType<AccesoDatos.Caja>()
                    .Any(x => x.FechaCierre == null);
            }
        }

        public void RealizarMovimiento(MovimientoDto movimiento)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var cajaActualizar = context.Cajas.OfType<AccesoDatos.Caja>()
                    .FirstOrDefault(x => x.Id == movimiento.CajaId);

                if (cajaActualizar == null)
                    throw new Exception("No se encontro la caja");

                if (movimiento.TipoMovimiento == TipoMovimiento.Ingreso)
                {
                    cajaActualizar.MontoSistema += movimiento.Monto;
                }
                else
                {
                    cajaActualizar.MontoSistema -= movimiento.Monto;
                }

                GenerarDetalleCaja(movimiento);

                context.SaveChanges();
            }
        }

        public void GenerarDetalleCaja(MovimientoDto movimiento)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoDetalleCaja = new AccesoDatos.DetalleCaja()
                {
                    CajaId = movimiento.CajaId,
                    Monto = movimiento.Monto,
                    TipoPago = TipoPago.Efectivo


                };

                context.DetalleCajas.Add(nuevoDetalleCaja);

                context.SaveChanges();
            }
        }
    }
}
