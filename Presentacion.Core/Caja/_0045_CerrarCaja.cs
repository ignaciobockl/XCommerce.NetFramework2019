using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Caja;
using XCommerce.Servicio.Core.Mesa;
using static Presentacion.Helpers.DatosConstantes;

namespace Presentacion.Core.Caja
{
    public partial class _0045_CerrarCaja : FormularioBase.FormularioBase
    {
        private readonly IMesaServicio mesaServicio;
        private readonly ICajaServicio cajaServicio;
        public _0045_CerrarCaja()
        {
            InitializeComponent();

            mesaServicio = new MesaServicio();
            cajaServicio = new CajaServicio();

            lblUsuario.Text += NombreUsuarioLogueado;
            lblFechaCierre.Text += DateTime.Now.ToString();

            nudSistema.Maximum = 99999999;
            nudSistema.Minimum = -99999999;
            nudCierre.Maximum = 99999999;
            nudCierre.Minimum = -99999999;
            nudDiferencia.Maximum = 99999999;
            nudDiferencia.Minimum = -99999999;

            CargarDatos();
        }        

        private void BtnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (UsuarioLogueadoId == null) return;

            if (!VerificarMesasAbiertas())
            {
                MessageBox.Show("Debe cerrar todas las mesas para cerrar la caja");
                return;
            }

            if (cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
            {
                
                var cerrarCaja = cajaServicio.ObtenerIdporUsuario(UsuarioLogueadoId.Value);                
                
                cajaServicio.Cerrar(UsuarioLogueadoId.Value, nudCierre.Value, cerrarCaja.Id, nudSistema.Value);

                EstadoCaja = false;

                MessageBox.Show("La caja se cerro correctamente");

                this.Close();                
                
            }
            else
            {
                MessageBox.Show("La caja se encuentra cerrada");
            }            
        }

        void CargarDatos()
        {
            if (UsuarioLogueadoId == null) return;

            var a = cajaServicio.ObtenerIdporUsuario(UsuarioLogueadoId.Value);

            nudSistema.Maximum = 99999999;
            nudSistema.Minimum = 0;

            if (!EstadoCaja)
            {
                return;
            }
            else
            {
                if (CajaAbiertaId > 0)
                {
                    nudSistema.Value = a.MontoSistema;
                }
            }
        }

        bool VerificarMesasAbiertas()
        {
            var MesasAbiertas = mesaServicio.Obtener(string.Empty);
            foreach (var mesa in MesasAbiertas)
            {
                if (mesa.estadoMesa == EstadoMesa.Abierta)
                {
                    return false;
                }
            }
            return true;
        }

       
        private void NudCierre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                if (nudCierre.Value != 0)
                {
                    nudDiferencia.Value = nudCierre.Value - nudSistema.Value;
                }

                btnCerrarCaja.Focus();
            }
            
        }        
    }
}
