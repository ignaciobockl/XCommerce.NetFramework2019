﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.ListaPrecio.DTOs
{
    public class ListaPrecioDto : BaseDto
    {
        public string Descripcion { get; set; }

        public decimal Rentabilidad { get; set; }

    }
}
