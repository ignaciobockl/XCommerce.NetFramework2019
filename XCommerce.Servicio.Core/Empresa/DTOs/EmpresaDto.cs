using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Empresa.DTOs
{
    public class EmpresaDto : BaseDto
    {
        public long CondicionIvaId { get; set; }

        public string NombreFantasia { get; set; }

        public string RazonSocial { get; set; }

        public string Cuit { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Sucursal { get; set; }

        public byte[] Logo { get; set; }

        // =========================================== //
        // ========      Datos del Domicilio    ====== //
        // =========================================== //

        public string Calle { get; set; }

        public int Numero { get; set; }

        public string Piso { get; set; }

        public string Dpto { get; set; }

        public string Casa { get; set; }

        public string Lote { get; set; }

        public string Mza { get; set; }

        public string Barrio { get; set; }

        public long LocalidadId { get; set; }

        public long ProvinciaId { get; set; }
    }
}
