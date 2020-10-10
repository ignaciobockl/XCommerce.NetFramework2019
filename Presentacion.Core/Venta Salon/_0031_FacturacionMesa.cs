using Presentacion.Core.Cliente;
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
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core.Comprobante;
using XCommerce.Servicio.Core.Comprobante.DTOs;
using XCommerce.Servicio.Core.DetalleDeCaja;
using XCommerce.Servicio.Core.DetalleDeCaja.DTOs;
using XCommerce.Servicio.Core.Mesa;
using XCommerce.Servicio.Core.Movimiento;
using XCommerce.Servicio.Core.Movimiento.DTOs;
using XCommerce.Servicio.Core.Producto;
using XCommerce.Servicio.Seguridad.Usuario;
using static Presentacion.Helpers.DatosConstantes;

namespace Presentacion.Core.Venta_Salon
{


    public partial class _0031_FacturacionMesa : FormularioBase.FormularioBase
    {
        private TipoFormaPago _tipoFormaPago;
        private EstadoMesa _estadoMesa;

        private readonly IComprobanteSalonServicio _comprobanteSalonServicio;
        private readonly IProductoServicio _productoServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IMovimientoServicio _movimientoServicio;
        private readonly ICajaServicio _cajaServicio;
        private readonly IMesaServicio _mesaServicio;
        private readonly IDetalleCajaServicio _detalleCajaServicio;
        private readonly long _mesaId;
        private readonly long _comprobanteId;

        public EstadoMesa Estado { get; set; }

        public _0031_FacturacionMesa()
            : this(new ProductoServicio(), new ComprobanteSalonServicio(), new ClienteServicio(),
                new UsuarioServicio())
        {
            InitializeComponent();

            _movimientoServicio = new MovimientoServicio();
            _cajaServicio = new CajaServicio();
            _mesaServicio = new MesaServicio();
            _detalleCajaServicio = new DetalleCajaServicio();
            Inicializador(_mesaId);
            pnlCuentaCorriente.Enabled = false;
            cmbTipoComprobante.DataSource = Enum.GetValues(typeof(TipoComprobante));
            txtUsuario.Text = NombreUsuarioLogueado;
        }

        public _0031_FacturacionMesa(IProductoServicio productoServicio, IComprobanteSalonServicio comprobanteSalonServicio
            , IClienteServicio clienteServicio, IUsuarioServicio usuarioServicio)
        {
            _productoServicio = productoServicio;
            _comprobanteSalonServicio = comprobanteSalonServicio;
            _clienteServicio = clienteServicio;
            _usuarioServicio = usuarioServicio;
        }

        private void Inicializador(long EntidadId)
        {
            nudSubTotal.Minimum = 0;
            nudSubTotal.Maximum = 99999999;

            nudTotal.Minimum = 0;
            nudTotal.Maximum = 99999999;

            nudMontoRestar.Minimum = 0;
            nudMontoRestar.Maximum = 99999999;

            RestanteCuentaCorriente.Minimum = -1000000;
            RestanteCuentaCorriente.Maximum = 99999999;

            nudMontoActual.Minimum = 0;
            nudMontoActual.Maximum = 99999999;

            nudNumero.Value = _comprobanteSalonServicio.ObtenerNumeroComprobante();

            RadioEfectivo.Checked = true;

           
        }

        public _0031_FacturacionMesa(long mesaId, int NumeroMesa, EstadoMesa estadoMesa, long comprobanteId)
            : this()
        {
            _mesaId = mesaId;

            _comprobanteId = comprobanteId;

            this.Text = $"Cierre - Mesa {NumeroMesa}";

            _estadoMesa = estadoMesa;

            ObtenerComprobanteMesa(_comprobanteId);
        }

        private void ObtenerComprobanteMesa(long comprobanteId)
        {
            var ComprobanteMesaDto = _comprobanteSalonServicio.ObtenerComprobantePorId(comprobanteId);

            if (ComprobanteMesaDto == null)
            {
                MessageBox.Show("Ocurrio un error");
                this.Close();
            }

            dgbGrillaVenta.DataSource = ComprobanteMesaDto.Items.ToList();

            nudDescuento.Value = ComprobanteMesaDto.Descuento;
            nudSubTotal.Value = ComprobanteMesaDto.SubTotal;
            nudTotal.Value = ComprobanteMesaDto.Total;

            FormatearGrillaVenta();
        }

        private void FormatearGrillaVenta()
        {
            for (var i = 0; i < dgbGrillaVenta.ColumnCount; i++)
            {
                dgbGrillaVenta.Columns[i].Visible = false;
            }

            dgbGrillaVenta.Columns["CodigoProducto"].Visible = true;
            dgbGrillaVenta.Columns["CodigoProducto"].Width = 100;
            dgbGrillaVenta.Columns["CodigoProducto"].HeaderText = @"Codigo";
            dgbGrillaVenta.Columns["CodigoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgbGrillaVenta.Columns["CodigoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgbGrillaVenta.Columns["DescripcionProducto"].Visible = true;
            dgbGrillaVenta.Columns["DescripcionProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgbGrillaVenta.Columns["DescripcionProducto"].HeaderText = @"Descripcion";
            dgbGrillaVenta.Columns["DescripcionProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgbGrillaVenta.Columns["DescripcionProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgbGrillaVenta.Columns["PrecioUnitario"].Visible = true;
            dgbGrillaVenta.Columns["PrecioUnitario"].Width = 100;
            dgbGrillaVenta.Columns["PrecioUnitario"].HeaderText = @"Precio Unitario";
            dgbGrillaVenta.Columns["PrecioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgbGrillaVenta.Columns["PrecioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgbGrillaVenta.Columns["Cantidad"].Visible = true;
            dgbGrillaVenta.Columns["Cantidad"].Width = 100;
            dgbGrillaVenta.Columns["Cantidad"].HeaderText = @"Cantidad";
            dgbGrillaVenta.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgbGrillaVenta.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgbGrillaVenta.Columns["SubTotalLinea"].Visible = true;
            dgbGrillaVenta.Columns["SubTotalLinea"].Width = 100;
            dgbGrillaVenta.Columns["SubTotalLinea"].HeaderText = @"Sub Total";
            dgbGrillaVenta.Columns["SubTotalLinea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgbGrillaVenta.Columns["SubTotalLinea"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void RadioCuentaCorriente_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioCuentaCorriente.Checked)
            {
                pnlCuentaCorriente.Enabled = true;

                txtApyNom.Clear();

                txtDni.Clear();

                txtDni.Focus();

                _tipoFormaPago = TipoFormaPago.CuentaCorriente;
            }
        }


        private void TxtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                var Cliente = _clienteServicio.ObtenerPorDni(txtDni.Text);

                if (Cliente == null)
                {
                    MessageBox.Show("No se encontro el cliente");
                    return;
                }

                txtApyNom.Text = Cliente.ApyNom;

                nudMontoActual.Value = Cliente.MontoMaximoCtaCte;

                nudMontoRestar.Value = nudTotal.Value;

                var restante = nudMontoActual.Value - nudMontoRestar.Value;

                RestanteCuentaCorriente.Value = restante;
            }
        }

        private void BtnCobrar_Click_1(object sender, EventArgs e)
        {
            var _cliente = _clienteServicio.ObtenerPorDni("99999999");


            //---------------------------------------------------------//

            //---------------------------------------------------------//

            var ObtenerComprobante = _comprobanteSalonServicio.ObtenerComprobantePorId(_comprobanteId);

            var FacturacionMesa = new ComprobanteCierreDto
            {
                Id = ObtenerComprobante.ComprobanteId,
                MesaId = ObtenerComprobante.MesaId,
                UsuarioId = UsuarioLogueadoId,
                ClienteId = _cliente.Id,                
                Descuento = nudDescuento.Value,
                
                Fecha = dtpFechaFactura.Value,
                Numero = (int)nudNumero.Value,
                TipoDeComprobante = ((TipoComprobante)cmbTipoComprobante.SelectedItem),
                EstadoComprobante = EstadoComprobanteSalon.Enviado,
                Total = nudTotal.Value,
                SubTotal = nudTotal.Value,
                MozoId = ObtenerComprobante.MozoId,
                Comensales = ObtenerComprobante.Comensales,
            };

            var Cliente = _clienteServicio.ObtenerPorDni(txtDni.Text);

            if (Cliente == null)
            {
                MessageBox.Show("Por favor seleccione un medio de pago o un cliente valido", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtApyNom.Text = Cliente.ApyNom;
            nudMontoActual.Value = Cliente.MontoMaximoCtaCte;

            if (nudTotal.Value > 0)
            {
                if (RadioCuentaCorriente.Checked)
                {
                    Cliente.MontoDeudaCtaCte += nudTotal.Value;
                    nudMontoRestar.Value = nudTotal.Value;

                    if (Cliente.MontoDeudaCtaCte <= Cliente.MontoMaximoCtaCte)
                    {
                        RestanteCuentaCorriente.Value = Cliente.MontoMaximoCtaCte - nudTotal.Value;

                        var ClienteModificar = new ClienteDto()
                        {
                            Id = Cliente.Id,
                            MontoDeudaCtaCte = Cliente.MontoDeudaCtaCte,
                            MontoMaximoCtaCte = Cliente.MontoMaximoCtaCte
                        };

                        _clienteServicio.ModificarCuentaCorriente(ClienteModificar);

                        _comprobanteSalonServicio.GenerarComprobanteCierre(FacturacionMesa);

                        var nuevoMovimiento = new MovimientoDto()
                        {
                            CajaId = CajaAbiertaId,
                            ComprobanteId = FacturacionMesa.Id,
                            TipoMovimiento = TipoMovimiento.Ingreso,
                            UsuarioId = FacturacionMesa.UsuarioId,
                            Monto = FacturacionMesa.Total,
                            Fecha = FacturacionMesa.Fecha,
                            Descripcion = "FAC_" + FacturacionMesa.TipoDeComprobante + "_" + FacturacionMesa.Numero + "_" +
                                     FacturacionMesa.Fecha.ToShortDateString().Replace("/", string.Empty) + "_SALON"
                        };
                        _movimientoServicio.Insertar(nuevoMovimiento);
                        _cajaServicio.ActualizarMontoDelSistema(nuevoMovimiento.Monto, nuevoMovimiento.CajaId);

                        var nuevoDetalle = new DetalleCajaDto()
                        {
                            CajaId = CajaAbiertaId,
                            Monto = FacturacionMesa.Total,
                            FormaPago = TipoPago.CtaCte
                        };

                        _detalleCajaServicio.InsertarDetalle(nuevoDetalle);

                        MessageBox.Show(@"Operacion realizada con Exito.", @"Atención", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);


                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(@"Monto Cuenta Corriente Insuficiente , seleccione otra forma de pago", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                        return;
                    }
                }
                else
                {
                    _comprobanteSalonServicio.GenerarComprobanteCierre(FacturacionMesa);

                    var nuevoMovimiento = new MovimientoDto()
                    {
                        CajaId = CajaAbiertaId,
                        ComprobanteId = FacturacionMesa.Id,
                        TipoMovimiento = TipoMovimiento.Ingreso,
                        UsuarioId = FacturacionMesa.UsuarioId,
                        Monto = FacturacionMesa.Total,
                        Fecha = FacturacionMesa.Fecha,
                        Descripcion = "FAC_" + FacturacionMesa.TipoDeComprobante + "_" + FacturacionMesa.Numero + "_" +
                                      FacturacionMesa.Fecha.ToShortDateString().Replace("/", string.Empty) + "_SALON"
                    };
                    _movimientoServicio.Insertar(nuevoMovimiento);
                    _cajaServicio.ActualizarMontoDelSistema(nuevoMovimiento.Monto, nuevoMovimiento.CajaId);


                    var nuevoDetalle = new DetalleCajaDto()
                    {
                        CajaId = CajaAbiertaId,
                        Monto = FacturacionMesa.Total,
                        FormaPago = TipoPago.Efectivo
                    };

                    _detalleCajaServicio.InsertarDetalle(nuevoDetalle);

                    MessageBox.Show(@"Operacion realizada con Exito.", @"Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

                    _mesaServicio.CambiarEstado(_mesaId, EstadoMesa.Cerrada);

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un articulo.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _mesaServicio.CambiarEstado(_mesaId, EstadoMesa.Abierta);
            }


        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            _mesaServicio.CambiarEstado(_mesaId, EstadoMesa.Abierta);
            this.Close();
        }

        private void RadioEfectivo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (RadioEfectivo.Checked)
            {
                pnlCuentaCorriente.Enabled = false;

                txtDni.Text = "99999999";

                txtApyNom.Text = "Consumidor Final";

                _tipoFormaPago = TipoFormaPago.Efectivo;

                nudMontoActual.Value = 0;

                nudMontoRestar.Value = 0;

                RestanteCuentaCorriente.Value = 0;
            }
        }

        private void RadioCuentaCorriente_CheckedChanged_1(object sender, EventArgs e)
        {
            if (RadioCuentaCorriente.Checked)
            {
                pnlCuentaCorriente.Enabled = true;

                txtApyNom.Clear();

                txtDni.Clear();

                txtDni.Focus();

                _tipoFormaPago = TipoFormaPago.CuentaCorriente;
            }

        }

        private void BtnBusquedaCliente_Click(object sender, EventArgs e)
        {
            var lookupCliente = new _00047_LookUp_Clientes();

            lookupCliente.ShowDialog();

            var clienteDto = new ClienteDto();

            
            clienteDto = (ClienteDto)lookupCliente.ObjetoLookUp;
            if (clienteDto != null)
            {
                txtDni.Text = clienteDto.Dni;
                txtApyNom.Text = clienteDto.ApyNom;

                nudMontoActual.Value = clienteDto.MontoMaximoCtaCte;

                nudMontoRestar.Value = nudTotal.Value;

                txtDni.Enabled = false;
            }           

        }
    }
}
