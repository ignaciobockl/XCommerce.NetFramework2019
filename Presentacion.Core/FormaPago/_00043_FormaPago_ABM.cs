using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Comprobante;
using XCommerce.Servicio.Core.FormaPago;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace Presentacion.Core.FormaPago
{
    public partial class _00043_FormaPago_ABM : FormularioAbm
    {
        private readonly IFormaPagoServicio _formaPagoServicio;
        private readonly IComprobanteServicio _comprobanteServicio;
        public _00043_FormaPago_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
        :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            _formaPagoServicio =  new FormaPagoServicio();
            _comprobanteServicio = new ComprobanteServicio();

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(nudComprobante, "Comprobante");
            AgregarControlesObligatorios(cmbTipoFormaPago, "Tipo Forma de Pago");
            AgregarControlesObligatorios(nudMonto, "Monto");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            nudComprobante.Value = _comprobanteServicio.ObtenerNumeroComprobante(Convert.ToInt64(entidadId));

            var tipoFormaPago = new List<TipoFormaPago>()
            {
                TipoFormaPago.Cheque,
                TipoFormaPago.CuentaCorriente,
                TipoFormaPago.Efectivo,
                TipoFormaPago.Tarjeta
            }.ToList();

            cmbTipoFormaPago.DataSource = tipoFormaPago;

            nudMonto.Minimum = 0;
            nudMonto.Maximum = 9999999;
            nudMonto.DecimalPlaces = 2;

            nudMonto.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave",
                    @"Error Grave",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                this.Close();
            }

            var tipoFormaPago = _formaPagoServicio.ObtenerPorId(entidadId.Value);

            nudComprobante.Value = _comprobanteServicio.ObtenerNumeroComprobante(Convert.ToInt64(entidadId));

            //nudComprobante.Value = tipoFormaPago.ComprobanteId;

            /*var FormaPago = new List<TipoFormaPago>()
            {
                TipoFormaPago.Cheque,
                TipoFormaPago.CuentaCorriente,
                TipoFormaPago.Efectivo,
                TipoFormaPago.Tarjeta
            }.ToList();

            cmbTipoFormaPago.DataSource = FormaPago;*/

            cmbTipoFormaPago.SelectedItem = tipoFormaPago.TipoFormaPago;

            nudMonto.Value = tipoFormaPago.Monto;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaFormaPago = new FormaPagoDto
            {
                ComprobanteId = Convert.ToInt64(nudComprobante.Value),
                TipoFormaPago = ((TipoFormaPago) cmbTipoFormaPago.SelectedItem),
                Monto = nudMonto.Value
            };

            _formaPagoServicio.Insertar(nuevaFormaPago);

            return true;
        }
    }
}
