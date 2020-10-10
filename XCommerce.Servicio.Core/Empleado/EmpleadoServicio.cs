﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Empleado.DTOs;

namespace XCommerce.Servicio.Core.Empleado
{
    public class EmpleadoServicio : IEmpleadoServicio
    {
        public void Eliminar(long empleadoId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var bloquearUsuario = context.Usuarios
                    .FirstOrDefault(x => x.Id == x.PersonaId);

                var empleadoEliminar = context.Personas.OfType<AccesoDatos.Empleado>()
                    .FirstOrDefault(x => x.Id == empleadoId);

                if (empleadoEliminar == null)
                    throw new Exception("No se encontro el Empleado");

                empleadoEliminar.EstaEliminado = true;
                bloquearUsuario.EstaBloqueado = true;


                context.SaveChanges();
            }
        }

        public long Insertar(EmpleadoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoEmpleado = new AccesoDatos.Empleado
                {
                    Legajo = dto.Legajo,
                    Apellido = dto.Apellido,
                    Nombre = dto.Nombre,
                    Dni = dto.Dni,
                    Telefono = dto.Telefono,
                    Celular = dto.Celular,
                    Email = dto.Email,
                    Cuil = dto.Cuil,
                    FechaNacimiento = dto.FechaNacimiento,
                    Foto = dto.Foto,
                    FechaIngreso = dto.FechaIngreso,
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


                context.Personas.Add(nuevoEmpleado);

                context.SaveChanges();

                return nuevoEmpleado.Id;
            }
        }

        public void Modificar(EmpleadoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var empleadoModificar = context.Personas.OfType<AccesoDatos.Empleado>()
                    .Include(x => x.Direccion)
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (empleadoModificar == null)
                    throw new Exception("No se encontro el Empleado");

                empleadoModificar.Legajo = dto.Legajo;
                empleadoModificar.Apellido = dto.Apellido;
                empleadoModificar.Nombre = dto.Nombre;
                empleadoModificar.Dni = dto.Dni;
                empleadoModificar.Telefono = dto.Telefono;
                empleadoModificar.Celular = dto.Celular;
                empleadoModificar.Email = dto.Email;
                empleadoModificar.Cuil = dto.Cuil;
                empleadoModificar.FechaNacimiento = dto.FechaNacimiento;
                empleadoModificar.Foto = dto.Foto;

                empleadoModificar.Direccion.Calle = dto.Calle;
                empleadoModificar.Direccion.Numero = dto.Numero;
                empleadoModificar.Direccion.Piso = dto.Piso;
                empleadoModificar.Direccion.Dpto = dto.Dpto;
                empleadoModificar.Direccion.Casa = dto.Casa;
                empleadoModificar.Direccion.Lote = dto.Lote;
                empleadoModificar.Direccion.Barrio = dto.Barrio;
                empleadoModificar.Direccion.Mza = dto.Mza;
                empleadoModificar.Direccion.LocalidadId = dto.LocalidadId;

                context.SaveChanges();
            }
        }

        public IEnumerable<EmpleadoDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Where(x => x.Nombre.Contains(cadenaBuscar)
                                || x.Apellido.Contains(cadenaBuscar)
                                || x.Dni == cadenaBuscar
                                || x.Email == cadenaBuscar)
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Legajo = x.Legajo,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Direccion.Calle,
                        Numero = (int)x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,
                        Casa = x.Direccion.Casa,
                        Lote = x.Direccion.Lote,
                        Barrio = x.Direccion.Barrio,
                        Mza = x.Direccion.Mza,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                        
                    }).ToList();
            }
        }

        public EmpleadoDto ObtenerPorDni(string Dni)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Legajo = x.Legajo,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Direccion.Calle,
                        Numero = (int)x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,
                        Casa = x.Direccion.Casa,
                        Lote = x.Direccion.Lote,
                        Barrio = x.Direccion.Barrio,
                        Mza = x.Direccion.Mza,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }
                    ).FirstOrDefault(x => x.Dni == Dni);
            }
        }

        public EmpleadoDto ObtenerPorDniParaModificar(string Dni, long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Legajo = x.Legajo,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Direccion.Calle,
                        Numero = (int)x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,
                        Casa = x.Direccion.Casa,
                        Lote = x.Direccion.Lote,
                        Barrio = x.Direccion.Barrio,
                        Mza = x.Direccion.Mza,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }
                    ).FirstOrDefault(x => x.Dni == Dni && x.Id != EntidadId);
            }
        }

        public EmpleadoDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Legajo = x.Legajo,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Direccion.Calle,
                        Numero = (int)x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,
                        Casa = x.Direccion.Casa,
                        Lote = x.Direccion.Lote,
                        Barrio = x.Direccion.Barrio,
                        Mza = x.Direccion.Mza,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }
                    ).FirstOrDefault(x => x.Id == entidadId);
            }
        }

        public EmpleadoDto ObtenerPorLegajo(string legajo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Legajo = x.Legajo,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Direccion.Calle,
                        Numero = (int) x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,
                        Casa = x.Direccion.Casa,
                        Lote = x.Direccion.Lote,
                        Barrio = x.Direccion.Barrio,
                        Mza = x.Direccion.Mza,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId

                    }).FirstOrDefault(x => x.Legajo.ToString() == legajo);
            }
        }

        public int ObtenerSiguienteLegajo()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (context.Personas.OfType<AccesoDatos.Empleado>().Any())
                {
                    return context.Personas
                               .OfType<AccesoDatos.Empleado>()
                               .Max(x => x.Legajo) + 1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
