using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Proveedor.DTOs;

namespace XCommerce.Servicio.Core.Proveedor
{
    public class ProveedorServicio : IProveedorServicio
    {
        public long Insertar(ProveedorDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoProveedor = new AccesoDatos.Proveedor
                {
                    RazonSocial = dto.RazonSocial,
                    Telefono = dto.Telefono,
                    Email = dto.Email,
                    Contacto = dto.Contacto,
                    CondicionIvaId = dto.CondicionIvaId
                };

                context.Proveedores.Add(nuevoProveedor);

                context.SaveChanges();

                return nuevoProveedor.Id;
            }
        }

        public void Modificar(ProveedorDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var proveedorModificar = context.Proveedores
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (proveedorModificar == null)
                    throw new Exception("No se encontro el Proveedor");

                proveedorModificar.RazonSocial = dto.RazonSocial;
                proveedorModificar.Telefono = dto.Telefono;
                proveedorModificar.Email = dto.Email;
                proveedorModificar.Contacto = dto.Contacto;
                proveedorModificar.CondicionIvaId = dto.CondicionIvaId;

                context.SaveChanges();
            }
        }

        public IEnumerable<ProveedorDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Proveedores
                    .Where(x => x.RazonSocial.Contains(cadenaBuscar) ||
                                x.Telefono.Contains(cadenaBuscar) ||
                                x.CondicionIva.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new ProveedorDto
                    {
                        Id = x.Id,
                        RazonSocial = x.RazonSocial,
                        Telefono = x.Telefono,
                        Email = x.Email,
                        Contacto = x.Contacto,
                        CondicionIvaId = x.CondicionIvaId
                    }).ToList();
            }
        }

        public ProveedorDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Proveedores
                    .Select(x => new ProveedorDto
                    {
                        Id = x.Id,
                        RazonSocial = x.RazonSocial,
                        Telefono = x.Telefono,
                        Email = x.Email,
                        Contacto = x.Contacto,
                        CondicionIvaId = x.CondicionIvaId
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
