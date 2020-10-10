using Presentacion.Helpers;
using System;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;

namespace Presentacion.Core.Cliente
{
    public partial class _00046_PagarCuentaCorriente : FormularioBase.FormularioBase
    {
        private readonly IClienteServicio _clienteServicio;


        public _00046_PagarCuentaCorriente()
        {
            InitializeComponent();

            _clienteServicio = new ClienteServicio();

            nudDeuda.Minimum = 0;
            nudDeuda.Maximum = 9999999;
            nudDeuda.DecimalPlaces = 2;

            nudSaldo.Minimum = 0;
            nudSaldo.Maximum = 9999999;
            nudSaldo.DecimalPlaces = 2;

            nudDeudaFinal.Minimum = -9999999;
            nudDeudaFinal.Maximum = 9999999;
            nudDeudaFinal.DecimalPlaces = 2;
            nudDeudaFinal.Enabled = false;

            btnPagar.Enabled = false;

            txtCliente.Enabled = false;

            txtCliente.KeyPress += Validacion.NoNumeros;
            txtCliente.KeyPress += Validacion.NoSimbolos;

            txtDni.KeyPress += Validacion.NoSimbolos;
            txtDni.KeyPress += Validacion.NoLetras;

            nudSaldo.KeyPress += Validacion.NoSimbolos;

        }

        public _00046_PagarCuentaCorriente(IClienteServicio clienteServicio,
            Label label1, NumericUpDown nudDeudaFinal, Label label4, Label label3,
            NumericUpDown nudDeuda, NumericUpDown nudSaldo, Label label2, Label lblDni, 
            TextBox txtCliente, TextBox txtDni, Button btnPagar)
        {
            _clienteServicio = clienteServicio;
            this.label1 = label1;
            this.nudDeudaFinal = nudDeudaFinal;
            this.label4 = label4;
            this.label3 = label3;
            this.nudDeuda = nudDeuda;
            this.nudSaldo = nudSaldo;
            this.label2 = label2;
            this.lblDni = lblDni;
            this.txtCliente = txtCliente;
            this.txtDni = txtDni;
            this.btnPagar = btnPagar;
        }

        private void TxtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                var cliente = _clienteServicio.ObtenerPorDni(txtDni.Text);

                if(cliente == null)
                {
                    MessageBox.Show(@"El cliente que está buscando no existe");
                    return;
                }


                if(_clienteServicio.TieneCuentaCorriente(cliente.Id))
                {
                    txtCliente.Text = cliente.ApyNom;
                    nudDeuda.Value = cliente.MontoDeudaCtaCte;
                    txtCliente.Enabled = false;
                    nudDeuda.Enabled = false;
                    btnPagar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("El Cliente no posee cuenta corriente");
                }
                
            }
        }

        private void LinkCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {           

            var lookupCliente = new _00047_LookUp_Clientes();

            lookupCliente.ShowDialog();

            var clienteDto = new ClienteDto();

            clienteDto = (ClienteDto)lookupCliente.ObjetoLookUp;

            if (clienteDto != null)
            {
                if (_clienteServicio.TieneCuentaCorriente(clienteDto.Id))
                {
                    if (clienteDto.MontoDeudaCtaCte == 0)
                    {
                        MessageBox.Show("El cliente no posee deuda a pagar");
                        return;
                    }
                    txtDni.Text = clienteDto.Dni;
                    txtCliente.Text = clienteDto.ApyNom;
                    nudDeuda.Value = clienteDto.MontoDeudaCtaCte;
                    txtDni.Enabled = false;
                    btnPagar.Enabled = true;
                    nudSaldo.Focus();
                }
                else
                {
                    MessageBox.Show(@"El cliente no posee cuenta corriente.");
                    return;
                }
            }               

        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            if (nudSaldo.Value >= 0)
            {
                if (nudSaldo.Value > nudDeuda.Value)
                {
                    MessageBox.Show("Por favor ingrese un monto igual o menor a la deuda");
                    return;
                }                
                else
                {
                    nudDeudaFinal.Value = nudDeuda.Value - nudSaldo.Value;
                    var cliente = _clienteServicio.ObtenerPorDni(txtDni.Text);

                    var modificarCuenta = new ClienteDto();

                    modificarCuenta.MontoDeudaCtaCte = nudDeudaFinal.Value;
                    modificarCuenta.MontoMaximoCtaCte = cliente.MontoMaximoCtaCte;
                    modificarCuenta.Id = cliente.Id;
                    _clienteServicio.ModificarCuentaCorriente(modificarCuenta);

                    
                    MessageBox.Show("Operacion realizada con exito");
                }                

                this.Close();
            }
            else
            {
                throw new Exception("Ingrese la Cantidad a Abonar");
            }

            if (txtCliente.Text != null && txtDni.Text != null)
            {
                _clienteServicio.PagarCuentaCorriente(
                    _clienteServicio.ObtenerPorDni(txtDni.Text).Id);
            }
        }

        private void NudSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnPagar.Focus();
            }
        }
    }
}
