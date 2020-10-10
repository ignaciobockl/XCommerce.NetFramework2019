using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Empresa.DTOs;

namespace XCommerce.Servicio.Core.Empresa
{
    public class EmpresaServicio : IEmpresaServicio
    {        
        public long Insertar(EmpresaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoEmpresa = new AccesoDatos.Empresa
                {
                    CondicionIvaId = dto.CondicionIvaId,
                    NombreFantasia = dto.NombreFantasia,
                    RazonSocial = dto.RazonSocial,
                    Cuit = dto.Cuit,
                    Telefono = dto.Telefono,
                    Mail = dto.Email,
                    Sucursal = dto.Sucursal,
                    Logo = dto.Logo,
                    Direccion = new Direccion
                    {
                        Calle = dto.Calle,
                        Numero = dto.Numero,
                        Piso = dto.Piso,
                        Dpto = dto.Dpto,
                        Casa = dto.Casa,
                        Lote = dto.Lote,
                        Barrio = dto.Barrio,
                        Mza = dto.Mza,
                        LocalidadId = dto.LocalidadId
                    }
                };

                context.Empresas.Add(nuevoEmpresa);

                context.SaveChanges();

                return nuevoEmpresa.Id;
            }
        }

        public void Modificar(EmpresaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var empresaModificar = context.Empresas
                    .Include(x => x.Direccion)
                    .FirstOrDefault(x => x.Id == dto.Id);                    

                if (empresaModificar == null) throw new Exception("No se encontro la Empresa");

                empresaModificar.NombreFantasia = dto.NombreFantasia;
                empresaModificar.RazonSocial = dto.RazonSocial;
                empresaModificar.Cuit = dto.Cuit;
                empresaModificar.Telefono = dto.Telefono;
                empresaModificar.Mail = dto.Email;
                empresaModificar.Sucursal = dto.Sucursal;
                empresaModificar.Logo = dto.Logo;
                empresaModificar.CondicionIvaId = dto.CondicionIvaId;

                empresaModificar.Direccion.Calle = dto.Calle;
                empresaModificar.Direccion.Numero = dto.Numero;
                empresaModificar.Direccion.Piso = dto.Piso;
                empresaModificar.Direccion.Dpto = dto.Dpto;
                empresaModificar.Direccion.Barrio = dto.Barrio;
                empresaModificar.Direccion.LocalidadId = dto.LocalidadId;

                context.SaveChanges();
            }
        }

        public IEnumerable<EmpresaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Empresas
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Where(x => x.NombreFantasia.Contains(cadenaBuscar)
                                || x.RazonSocial.Contains(cadenaBuscar)
                                || x.Cuit == cadenaBuscar
                                || x.Mail == cadenaBuscar)
                    .Select(x => new EmpresaDto()
                    {
                        Id = x.Id,
                        NombreFantasia = x.NombreFantasia,
                        RazonSocial = x.RazonSocial,
                        Cuit = x.Cuit,
                        Telefono = x.Telefono,
                        Email = x.Mail,
                        Sucursal = x.Sucursal,
                        Logo = x.Logo,
                        Calle = x.Direccion.Calle,
                        Numero = (int)x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,
                        Barrio = x.Direccion.Barrio,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }).ToList();
            }
        }

        public EmpresaDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Empresas
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Select(x => new EmpresaDto()
                    {
                        Id = x.Id,
                        NombreFantasia = x.NombreFantasia,
                        RazonSocial = x.RazonSocial,
                        Cuit = x.Cuit,
                        Telefono = x.Telefono,
                        Email = x.Mail,
                        Sucursal = x.Sucursal,
                        Logo = x.Logo,
                        Calle = x.Direccion.Calle,
                        Numero = (int)x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,                       
                        Barrio = x.Direccion.Barrio,                        
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }
                    ).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
