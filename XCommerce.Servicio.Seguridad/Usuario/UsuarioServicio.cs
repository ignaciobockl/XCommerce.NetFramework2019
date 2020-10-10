using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Seguridad.Usuario.DTOs;
using static Presentacion.Helpers.CadenaCaracteres;

namespace XCommerce.Servicio.Seguridad.Usuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        public void CambiarEstado(string nombreUsuario, bool estado)
        {
            using (var conetxt = new ModeloXCommerceContainer())
            {
                var usuario = conetxt.Usuarios
                    .FirstOrDefault(usu => usu.NombreUser == nombreUsuario);

                if(usuario == null)
                    throw new Exception($"No se encontro el Usuario: {nombreUsuario}.");

                usuario.EstaBloqueado = estado;

                conetxt.SaveChanges();
            }
        }

        public void Crear(long personaId, string apellido, string nombre)
        {
            var nombreUsurio = CrearNombreUsuario(apellido, nombre);

            using (var context = new ModeloXCommerceContainer())
            {
                context.Usuarios.Add(new AccesoDatos.Usuario
                {
                    PersonaId = personaId,
                    EstaBloqueado = false,
                    NombreUser = nombreUsurio.ToLower(),
                    Password = Encriptar("P$assword")
                });

                context.SaveChanges();
            }
        }

        public string CrearNombreUsuario(string apellido, string nombre)
        {
            int contadorLetras = 1;

            int digito = 1;

            var usuarioNuevo = $"{nombre.Substring(0, contadorLetras)}{apellido.Trim().Replace(" ","")}";

            using (var context = new ModeloXCommerceContainer())
            {
                while (context.Usuarios.Any(x => x.NombreUser == usuarioNuevo))
                {
                    if (contadorLetras <= nombre.Trim().Length)
                    {
                        contadorLetras++;

                        usuarioNuevo = $"{nombre.Trim().Substring(0, contadorLetras)}{apellido.Trim()}";
                    }
                    else
                    {
                        usuarioNuevo = $"{nombre.Trim().Substring(0, contadorLetras++)}{apellido.Trim()}{digito}";

                        digito++;
                    }
                }
            }


            return usuarioNuevo;
        }

        public IEnumerable<UsuarioDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<Empleado>()
                    .AsNoTracking()
                    .Where(x => !x.EstaEliminado
                                && (x.Apellido.Contains(cadenaBuscar) || x.Nombre.Contains(cadenaBuscar)))
                    .Select(x => new UsuarioDto
                        {
                            PersonaId = x.Id,
                            ApellidoPersona = x.Apellido,
                            NombrePersona = x.Nombre,
                            NombreUsuario = x.Usuarios.Any()
                                ? x.Usuarios.FirstOrDefault().NombreUser
                                : "NO ASIGNADO",
                            Id = x.Usuarios.Any()
                                ? x.Usuarios.FirstOrDefault().Id
                                : 0,
                            EstaBloqueado = x.Usuarios.Any()
                                ? x.Usuarios.FirstOrDefault().EstaBloqueado
                                : false
                        }
                    ).Where(x => x.NombrePersona != "Final").ToList();
            }
        }

        public UsuarioDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Usuarios.OfType<AccesoDatos.Usuario>()
                    .AsNoTracking()
                    .Select(x => new UsuarioDto
                    {
                        Id = x.Id,
                        NombreUsuario = x.NombreUser,
                        EstaBloqueado = x.EstaBloqueado,
                        PersonaId = x.PersonaId
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }

        public UsuarioDto ObtenerPorNombreUsuario(string nombre)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Usuarios.OfType<AccesoDatos.Usuario>()
                    .Select(x => new UsuarioDto
                    {
                        Id = x.Id,
                        NombreUsuario = x.NombreUser,

                    }).FirstOrDefault(x => x.NombreUsuario == nombre);

            }
        }
    }
}
