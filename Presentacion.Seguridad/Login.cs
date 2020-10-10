﻿using System;
using System.Windows.Forms;
using XCommerce.Servicio.Seguridad.Seguridad;
using XCommerce.Servicio.Seguridad.Usuario;
using static Presentacion.Helpers.DatosConstantes;


namespace Presentacion.Seguridad
{
    public partial class Login : Form
    {
        // Atributos / Variables

        private readonly IAccesoSistema _accesoSistema;
        private readonly IUsuarioServicio _usuarioServicio;

        private int _cantidadAccesosFallidos;

        // Propiedades
        public bool PuedeAccederSistema { get; protected set; }

        public Login()
        {
            InitializeComponent();

            txtPassoword.UseSystemPasswordChar = true;
        }

        public Login(IAccesoSistema accesoSistema, IUsuarioServicio usuarioServicio)
            : this()
        {
            _accesoSistema = accesoSistema;
            _usuarioServicio = usuarioServicio;
            _cantidadAccesosFallidos = 0;
        }

        private void BtnIngresar_Click(object sender, System.EventArgs e)
        {
            // 1 - Verificar si esta cargado el usuario
            // 2 - verificar si esta cargado el password

            if (!VerificarDatosObligatorios()) return;

            // 3 - verificar si el usuario y la Pass son Correctos (Autenticacion)
            if (_accesoSistema.VerificarSiExisteUsuario(txtUsuario.Text, txtPassoword.Text))
            {
                // 5 - Verificar si Esta Bloqueado
                if (!_accesoSistema.VerificarSiEstaBloqueadoUsuario(txtUsuario.Text))
                {
                    // 7 - Cuando este correcto ingresar al sistema.

                    PuedeAccederSistema = true;

                    NombreUsuarioLogueado = txtUsuario.Text;

                    if (txtUsuario.Text != "Admin")
                    {
                        var idUsuario = _usuarioServicio.ObtenerPorNombreUsuario(NombreUsuarioLogueado);

                        UsuarioLogueadoId = idUsuario.Id;
                    }

                    this.Close(); // Cierro el Formulario de Login
                }
                else
                {
                    // 6 - Si esta bloqueado mostrar mensaje
                    MessageBox.Show(@"El Usuario esta BLOQUEADO.");

                    txtPassoword.Clear();

                    txtUsuario.Clear();

                    txtUsuario.Focus();

                    _cantidadAccesosFallidos = 0;

                    PuedeAccederSistema = false;

                    return;
                }

            }
            else
            {
                PuedeAccederSistema = false;

                // 4 - Si no existe mostrar Mensaje
                MessageBox.Show(@"El usuario o la contraseña son incorrectos.");

                txtPassoword.Clear();

                txtPassoword.Focus();

                // incrementar los Intentos Fallidos
                _cantidadAccesosFallidos++;

                if (_cantidadAccesosFallidos >= 3)
                {
                    try
                    {
                        // Bloquear el Usuario
                        _usuarioServicio.CambiarEstado(txtUsuario.Text, true);
                        // Notificar al Usuario que esta Bloqueado
                        MessageBox.Show(@"El Usuario FUE BLOQUEADO. Comunicarse con el Adminsitrador.");
                        Application.Exit();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        txtPassoword.Clear();
                        txtPassoword.Focus();
                    }
                        
                }
            }
        }

        private bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show(@"El nombre de Usuario es Obligatorio.");
                return false;
            }

            if (string.IsNullOrEmpty(txtPassoword.Text))
            {
                MessageBox.Show(@"La contraseña es Obligatoria.");
                return false;
            }

            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtPassoword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) && !(e.KeyChar == Convert.ToChar(Keys.Tab)))
            {
                BtnIngresar_Click(sender,e);
            }
        }

        private void ImgOjo_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassoword.UseSystemPasswordChar = false;
        }

        private void ImgOjo_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassoword.UseSystemPasswordChar = true;
        }
    }
}
