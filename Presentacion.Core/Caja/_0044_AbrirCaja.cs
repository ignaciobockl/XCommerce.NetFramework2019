using System;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Caja;
using XCommerce.Servicio.Seguridad.Usuario;
using static Presentacion.Helpers.DatosConstantes;

namespace Presentacion.Core.Caja
{
    public partial class _0044_AbrirCaja : FormularioBase.FormularioBase
    {
        private readonly ICajaServicio _cajaServicio;
        

        bool EstadoDeCajaAbierta;
        public _0044_AbrirCaja()
        {
            InitializeComponent();

            _cajaServicio = new CajaServicio();
            

            nudMontoApertura.Maximum = 9999999;
            nudMontoApertura.Minimum = 0;

            lblUsuario.Text += NombreUsuarioLogueado;
            lblFecha.Text += DateTime.Now.ToString();
            EstadoDeCajaAbierta = false;
        }

        private void BtnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (!_cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
            {
                if (UsuarioLogueadoId.Value != null)
                {
                    CajaAbiertaId = _cajaServicio.Abrir(UsuarioLogueadoId.Value, nudMontoApertura.Value);
                    EstadoDeCajaAbierta = true;
                    EstadoCaja = EstadoDeCajaAbierta;
                    MessageBox.Show("La caja se abrio correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La caja se encuentra abierta");
                }
            }
            else
            {
                MessageBox.Show("Ocurrio un error al abrir la caja");
            }
        }

        private void NudMontoApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                btnAbrirCaja.Focus();
            }
        }        
    }
}
