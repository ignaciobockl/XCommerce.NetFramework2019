using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core.FormaPago.CuentaCorriente;

namespace XCommerce.Servicio.Core.Cliente
{
    public class ClienteServicio : IClienteServicio
    {
        public void Eliminar(long clienteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var clienteEliminar = context.Personas.OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Id == clienteId);

                if (clienteEliminar == null) throw new Exception("No se encontro el Cliente");

                clienteEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(ClienteDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoCliente = new AccesoDatos.Cliente()
                {
                    Apellido = dto.Apellido,
                    Nombre = dto.Nombre,
                    Dni = dto.Dni,
                    Cuil = dto.Cuil,
                    Telefono = dto.Telefono,
                    Celular = dto.Celular,
                    FechaNacimiento = dto.FechaNacimiento,
                    Email = dto.Email,
                    PoseeCuentaCorriente = dto.PoseeCuentaCorriente,
                    MontoMaximoCtaCte = dto.MontoMaximoCtaCte,
                    Direccion = new Direccion()
                    {
                        Calle = dto.Calle,
                        Numero = dto.Numero,
                        Piso = dto.Piso,
                        Dpto = dto.Departamento,
                        Mza = dto.Manzana,
                        Lote = dto.Lote,
                        Casa = dto.Casa,
                        Barrio = dto.Barrio,
                        LocalidadId = dto.LocalidadId
                    }
                };

                context.Personas.Add(nuevoCliente);

                context.SaveChanges();

                return nuevoCliente.Id;
            }
        }

        public void Modificar(ClienteDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var clienteModificar = context.Personas.OfType<AccesoDatos.Cliente>()
                    .Include(x => x.Direccion)
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (clienteModificar == null) throw new Exception("No se encontro el Cliente");

                clienteModificar.Apellido = dto.Apellido;
                clienteModificar.Nombre = dto.Nombre;
                clienteModificar.Dni = dto.Dni;
                clienteModificar.Cuil = dto.Cuil;
                clienteModificar.Telefono = dto.Telefono;
                clienteModificar.Celular = dto.Celular;
                clienteModificar.FechaNacimiento = dto.FechaNacimiento;
                clienteModificar.Email = dto.Email;
                clienteModificar.PoseeCuentaCorriente = dto.PoseeCuentaCorriente;
                clienteModificar.MontoMaximoCtaCte = dto.MontoMaximoCtaCte;
                clienteModificar.MontoDeudaCtaCte = dto.MontoDeudaCtaCte;                
                clienteModificar.Direccion.Calle = dto.Calle;
                clienteModificar.Direccion.Numero = dto.Numero;
                clienteModificar.Direccion.Piso = dto.Piso;
                clienteModificar.Direccion.Dpto = dto.Departamento;
                clienteModificar.Direccion.Mza = dto.Manzana;
                clienteModificar.Direccion.Lote = dto.Lote;
                clienteModificar.Direccion.Casa = dto.Casa;
                clienteModificar.Direccion.Barrio = dto.Barrio;
                clienteModificar.Direccion.LocalidadId = dto.LocalidadId;

                context.SaveChanges();
            }
        }

        public void ModificarCuentaCorriente(ClienteDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarCuenta = context.Personas.OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Id == dto.Id);

                if(ModificarCuenta == null)
                    throw new Exception("Ocurrio un error al obtener el cliente");

                ModificarCuenta.Id = dto.Id;
                ModificarCuenta.MontoMaximoCtaCte = dto.MontoMaximoCtaCte;
                ModificarCuenta.MontoDeudaCtaCte = dto.MontoDeudaCtaCte;               

                context.SaveChanges();
            }
        }

        public decimal MontoDisponibleCuentaCorriente(long clienteId)
        {
            var monto = 0m;

            using (var context = new ModeloXCommerceContainer())
            {
                var cliente = context.Personas.OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Id == clienteId);

                var deuda = context.FormasPagos.OfType<CuentaCorrienteDto>()
                    .Where(x => x.ClienteId == clienteId && x.EstadoPago == false).ToList();

                foreach (var item in deuda)
                {
                    monto += item.Monto;
                }

                return cliente.MontoMaximoCtaCte - monto;
            }
        }

        public IEnumerable<ClienteDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Where(x => x.Nombre.Contains(cadenaBuscar) ||
                                x.Apellido.Contains(cadenaBuscar) ||
                                x.Dni == cadenaBuscar ||
                                x.Email == cadenaBuscar)
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Cuil = x.Cuil,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        FechaNacimiento = x.FechaNacimiento,
                        Email = x.Email,
                        EstaEliminado = x.EstaEliminado,
                        MontoMaximoCtaCte = x.MontoMaximoCtaCte,
                        MontoDeudaCtaCte = x.MontoDeudaCtaCte,
                        PoseeCuentaCorriente = x.PoseeCuentaCorriente,
                        Casa = x.Direccion.Casa,
                        Numero = (int) x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Departamento = x.Direccion.Dpto,
                        Manzana = x.Direccion.Mza,
                        Lote = x.Direccion.Lote,
                        Calle = x.Direccion.Calle,
                        Barrio = x.Direccion.Barrio,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }).Where(x => x.Dni != "99999999").ToList();
            }
        }

        public IEnumerable<ClienteDto> ObtenerParaLoockUp(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Where(x => x.Nombre.Contains(cadenaBuscar) ||
                                x.Apellido.Contains(cadenaBuscar) ||
                                x.Dni == cadenaBuscar ||
                                x.Email == cadenaBuscar)
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Cuil = x.Cuil,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        FechaNacimiento = x.FechaNacimiento,
                        Email = x.Email,
                        EstaEliminado = x.EstaEliminado,
                        MontoMaximoCtaCte = x.MontoMaximoCtaCte,
                        MontoDeudaCtaCte = x.MontoDeudaCtaCte,
                        PoseeCuentaCorriente = x.PoseeCuentaCorriente,
                        Casa = x.Direccion.Casa,
                        Numero = (int)x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Departamento = x.Direccion.Dpto,
                        Manzana = x.Direccion.Mza,
                        Lote = x.Direccion.Lote,
                        Calle = x.Direccion.Calle,
                        Barrio = x.Direccion.Barrio,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }).Where(x => x.Dni != "99999999" && x.EstaEliminado == false && x.PoseeCuentaCorriente == true).ToList();
            }
        }
        public ClienteDto ObtenerPorDni(string clienteDni)
        {
            using (var context = new ModeloXCommerceContainer())

                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Cuil = x.Cuil,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        FechaNacimiento = x.FechaNacimiento,
                        Email = x.Email,
                        MontoMaximoCtaCte = x.MontoMaximoCtaCte,
                        MontoDeudaCtaCte = x.MontoDeudaCtaCte,
                        PoseeCuentaCorriente = x.PoseeCuentaCorriente,
                        Casa = x.Direccion.Casa,
                        Numero = (int) x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Departamento = x.Direccion.Dpto,
                        Manzana = x.Direccion.Mza,
                        Lote = x.Direccion.Lote,
                        Calle = x.Direccion.Calle,
                        Barrio = x.Direccion.Barrio,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId                        

                    }).FirstOrDefault(x => x.Dni == clienteDni);

        }

        public ClienteDto ObtenerPorDniParaModificar(string clienteDni, long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())

                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        EstaEliminado = x.EstaEliminado,
                        PoseeCuentaCorriente = x.PoseeCuentaCorriente,
                        MontoMaximoCtaCte = x.MontoMaximoCtaCte,
                        MontoDeudaCtaCte = x.MontoDeudaCtaCte,

                        Calle = x.Direccion.Calle,
                        Numero = (int)x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Departamento = x.Direccion.Dpto,
                        Casa = x.Direccion.Casa,
                        Lote = x.Direccion.Lote,
                        Barrio = x.Direccion.Barrio,
                        Manzana = x.Direccion.Mza,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId,
                        

                    }).FirstOrDefault(x => x.Dni == clienteDni && x.Id != EntidadId);
        }

        public ClienteDto ObtenerPorId(long clienteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Cuil = x.Cuil,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        FechaNacimiento = x.FechaNacimiento,
                        Email = x.Email,
                        PoseeCuentaCorriente = x.PoseeCuentaCorriente,
                        MontoMaximoCtaCte = x.MontoMaximoCtaCte,
                        MontoDeudaCtaCte = x.MontoDeudaCtaCte,

                        Casa = x.Direccion.Casa,
                        Numero = (int) x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Departamento = x.Direccion.Dpto,
                        Manzana = x.Direccion.Mza,
                        Lote = x.Direccion.Lote,
                        Calle = x.Direccion.Calle,
                        Barrio = x.Direccion.Barrio,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }).FirstOrDefault(x => x.Id == clienteId);
            }
        }

        public void PagarCuentaCorriente(long clienteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var cliente = context.FormasPagos.OfType<FormaPagoCtaCte>()
                    .Where(x => x.ClienteId == clienteId);

                if (cliente != null)
                {
                    foreach(var item in cliente)
                    {
                        item.EstadoPago = true;
                    }

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Ocurrio un error al intentar Pagar la Cuenta Corriente");
                }
            }
        }

        public bool TieneCuentaCorriente(long clienteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var cliente = context.Personas.OfType<AccesoDatos.Cliente>().FirstOrDefault(x => x.Id == clienteId);

                return cliente.PoseeCuentaCorriente;
                
            }
        }
    }
}
