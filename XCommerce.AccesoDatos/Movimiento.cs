//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XCommerce.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movimiento
    {
        public long Id { get; set; }
        public long CajaId { get; set; }
        public long ComprobanteId { get; set; }
        public TipoMovimiento TipoMovimento { get; set; }
        public long UsuarioId { get; set; }
        public decimal Monto { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
    
        public virtual Caja Caja { get; set; }
        public virtual Comprobante Comprobante { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
