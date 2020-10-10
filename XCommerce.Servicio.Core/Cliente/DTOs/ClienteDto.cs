using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Cliente.DTOs
{
    public class ClienteDto : BaseDto
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string ApyNom => $"{Apellido} {Nombre}";

        public string Dni { get; set; }

        public string Cuil { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Email { get; set; }

        public string Calle { get; set; }

        public int Numero { get; set; }

        public string Piso { get; set; }

        public string Departamento { get; set; }

        public string Manzana { get; set; }

        public string Lote { get; set; }

        public string Casa { get; set; }

        public string Barrio { get; set; }

        public long LocalidadId { get; set; }

        public long ProvinciaId { get; set; }

        public decimal MontoMaximoCtaCte { get; set; }

        public decimal MontoDeudaCtaCte { get; set; }

        public bool PoseeCuentaCorriente { get; set; }

        public string CuentaCorrienteSiNo => PoseeCuentaCorriente ? "SI" : "NO";
    }
}
