using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Core.Caja;
using Presentacion.Core.Cliente;
using Presentacion.Core.ListaPrecio;
using Presentacion.Helpers;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.Caja;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core.Comprobante.Kiosko;
using XCommerce.Servicio.Core.Comprobante.Kiosko.DTOs;
using XCommerce.Servicio.Core.Empleado;
using XCommerce.Servicio.Core.FormaPago;
using XCommerce.Servicio.Core.Kiosko;
using XCommerce.Servicio.Core.Kiosko.DTOs;
using XCommerce.Servicio.Core.ListaPrecio;
using XCommerce.Servicio.Core.ListaPrecio.DTOs;
using XCommerce.Servicio.Core.Movimiento;
using XCommerce.Servicio.Core.Movimiento.DTOs;
using XCommerce.Servicio.Core.Producto;
using XCommerce.Servicio.Seguridad.Usuario;
using static Presentacion.Helpers.DatosConstantes;

namespace Presentacion.Core.Kiosko
{
    public partial class _00049_Kiosko : FormularioBase.FormularioBase
    {
        private readonly IArticuloServicio _articuloServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IEmpleadoServicio _empleadoServicio;
        private readonly IFormaPagoServicio _formaPagoServicio;
        private readonly IComprobanteKioskoServicio _comprobanteKioskoServicio;
        private readonly IDetalleComprobanteKioscoServicio _detalleComprobanteKioscoServicio;
        private readonly ICajaServicio _cajaServicio;
        private readonly IMovimientoServicio _movimientoServicio;
        private readonly IProductoServicio _productoServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        private ComprobanteKioskoDto _comprobanteKioskoDto;
        private List<DetalleComprobanteKioscoDto> _listaDetalles;

        public _00049_Kiosko()
        {
            InitializeComponent();

            _articuloServicio = new ArticuloServicio();
            _usuarioServicio = new UsuarioServicio();
            _clienteServicio = new ClienteServicio();
            _empleadoServicio = new EmpleadoServicio();
            _formaPagoServicio = new FormaPagoServicio();
            _comprobanteKioskoServicio = new ComprobanteKioskoServicio();
            _cajaServicio = new CajaServicio();
            _movimientoServicio = new MovimientoServicio();
            _productoServicio = new ProductoServicio();
            _comprobanteKioskoDto = new ComprobanteKioskoDto();
            _listaDetalles = new List<DetalleComprobanteKioscoDto>();
            _listaPrecioServicio = new ListaPrecioServicio();

            Inicializador();

            dgvGrilla.DataSource = _listaDetalles;

            FormatearGrilla(dgvGrilla);
        }



        private void FormatearGrilla(DataGridView grilla)
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["CodigoProducto"].Visible = true;
            grilla.Columns["CodigoProducto"].Width = 100;
            grilla.Columns["CodigoProducto"].HeaderText = @"Codigo";
            grilla.Columns["CodigoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["CodigoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["DescripcionProducto"].Visible = true;
            grilla.Columns["DescripcionProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["DescripcionProducto"].HeaderText = @"Descripcion";
            grilla.Columns["DescripcionProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["DescripcionProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["PrecioUnitario"].Visible = true;
            grilla.Columns["PrecioUnitario"].Width = 100;
            grilla.Columns["PrecioUnitario"].HeaderText = @"Precio Unitario";
            grilla.Columns["PrecioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["PrecioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Cantidad"].Visible = true;
            grilla.Columns["Cantidad"].Width = 100;
            grilla.Columns["Cantidad"].HeaderText = @"Cantidad";
            grilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["SubTotalLinea"].Visible = true;
            grilla.Columns["SubTotalLinea"].Width = 100;
            grilla.Columns["SubTotalLinea"].HeaderText = @"Sub Total";
            grilla.Columns["SubTotalLinea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["SubTotalLinea"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        void Inicializador()
        {
            if (NombreUsuarioLogueado == "Admin")
            {
                MessageBox.Show("Para abrir el Kiosko debe loguearse con un Usuario Registrado", 
                    "Atencion",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                this.Close();
            }

            txtCodigo.KeyPress += Validacion.NoSimbolos;
            txtCodigo.KeyPress += Validacion.NoLetras;

            txtClienteDni.KeyPress += Validacion.NoSimbolos;
            txtClienteDni.KeyPress += Validacion.NoLetras;

            labels.KeyPress += Validacion.NoNumeros;
            labels.KeyPress += Validacion.NoSimbolos;

            nudPrecioUnitario.Enabled = false;
            nudPrecioUnitario.Minimum = 0;
            nudPrecioUnitario.DecimalPlaces = 2;
            nudPrecioUnitario.Maximum = 999999;

            nudUnidades.Minimum = 1;
            nudUnidades.Maximum = 999999;
            nudUnidades.DecimalPlaces = 0;

            txtUsusarioLogueado.Enabled = false;
            txtEmpleadoLegajo.Enabled = false;
            txtEmpleadoNombre.Enabled = false;
            txtUsusarioLogueado.Text = _usuarioServicio.ObtenerPorId(Convert.ToInt64(UsuarioLogueadoId)).NombreUsuario;
            txtEmpleadoLegajo.Text = Convert.ToString(_empleadoServicio
                .ObtenerPorId(_usuarioServicio.ObtenerPorId(Convert.ToInt64(UsuarioLogueadoId)).PersonaId).Legajo);
            txtEmpleadoNombre.Text = _empleadoServicio.ObtenerPorLegajo(txtEmpleadoLegajo.Text).ApyNom;

            txtClienteDni.Enabled = false;
            txtClienteNombre.Enabled = false;
            txtClienteApellido.Enabled = false;
            txtDescripcion.Enabled = false;

            dtpFecha.Enabled = false;
            dtpFecha.Value = DateTime.Today;

            nudSubTotal.Enabled = false;
            nudSubTotal.Minimum = 0m;
            nudSubTotal.Maximum = 9999999m;
            nudSubTotal.DecimalPlaces = 2;
            nudDescuento.Minimum = 0m;
            nudDescuento.Maximum = 100m;
            nudTotal.Enabled = false;
            nudTotal.Minimum = 0m;
            nudTotal.Maximum = 9999999m;
            nudTotal.DecimalPlaces = 2;

            var tipoComprobante = new List<TipoComprobante>
            {
                TipoComprobante.B,
                TipoComprobante.A,
                TipoComprobante.C,
                TipoComprobante.X
            }.ToList();

            cmbTipoComprobante.DataSource = tipoComprobante;

            var tipoFormaPago = new List<TipoFormaPago>
            {
                TipoFormaPago.Efectivo,
                TipoFormaPago.CuentaCorriente,
                TipoFormaPago.Cheque,
                TipoFormaPago.Tarjeta

            }.ToList();

            cmbFormaPago.DataSource = tipoFormaPago;

            btnCobrar.Enabled = false;

            var clienteId = _clienteServicio.ObtenerPorDni("99999999").Id;
            txtClienteDni.Text = _clienteServicio.ObtenerPorId(clienteId).Dni;
            txtClienteNombre.Text = _clienteServicio.ObtenerPorId(clienteId).Nombre;
            txtClienteApellido.Text = _clienteServicio.ObtenerPorId(clienteId).Apellido;
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCodigo.Text != null)
            {
                if ((char)Keys.Enter == e.KeyChar)
                {
                    var producto = _productoServicio.ObtenerPorCodigoKiosko(txtCodigo.Text);

                    if (producto != null)
                    {
                        var stock = _productoServicio.TieneStock(txtCodigo.Text, nudUnidades.Value);

                        var listaProducto = _listaPrecioServicio.ObtenerPorId(producto.Id);

                        if (!listaProducto.EstaEliminado)
                        {
                            if (stock)
                            {
                                txtDescripcion.Text = producto.Descripcion;
                                nudPrecioUnitario.Value = producto.Precio;

                                txtDescripcion.Enabled = false;
                                txtCodigo.Enabled = true;

                                btnAgregar.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El Producto no tiene Stock.",
                                    "Atencion",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La lista a la que el producto ingresado pertenece fue eliminada");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el Producto.",
                            "Atencion",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }




                }
            }
            else
            {
                MessageBox.Show("Ingrese el Codigo o Codigo de Barra de un Producto.",
                    "Atencion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != null 
                    && labels.Text != null 
                    && nudPrecioUnitario.Value != null
                    && nudUnidades.Value >= 1)
            {
                var producto = _productoServicio.ObtenerPorCodigoKiosko(txtCodigo.Text);

                var nuevoDetalle = new DetalleComprobanteKioscoDto();
                nuevoDetalle.CodigoProducto = producto.Codigo;
                nuevoDetalle.DescripcionProducto = producto.Descripcion;
                nuevoDetalle.Cantidad = nudUnidades.Value;
                nuevoDetalle.PrecioUnitario = nudPrecioUnitario.Value;
                nuevoDetalle.ArticuloId = (int)producto.Id;

                //find busca el objeto de la lista
                var verificarSiExiste = _listaDetalles.Find(
                    x => x.CodigoProducto == nuevoDetalle.CodigoProducto);

                if (verificarSiExiste != null)
                {
                    _listaDetalles.FirstOrDefault(x => x.CodigoProducto == nuevoDetalle.CodigoProducto)
                        .Cantidad += nuevoDetalle.Cantidad;
                }
                else
                {
                            _listaDetalles.Add(nuevoDetalle);
                }

                // Currency Manager maneja el bindeo de datos

                // Data binding es un mecanismo mediante el cual podemos enlazar los elementos de la
                // interfaz de usuario con los objetos que contienen la información a mostrar. ...
                // WPF nos permite de manera sencilla realizar binding a una propiedad de un control
                // utilizando propiedades de otros controles, objetos, colecciones, etc.
                CurrencyManager cm = (CurrencyManager)this.dgvGrilla.BindingContext[_listaDetalles];
                if (cm != null)
                {
                    cm.Refresh();
                }

                //calcular subtotal
                nudSubTotal.Value = _listaDetalles.Sum(x => x.SubTotalLinea);

                nudTotal.Value = nudSubTotal.Value - ((nudSubTotal.Value * nudDescuento.Value) / 100);
                btnCobrar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al agregar al Producto, Verifique los valores!.",
                    "Atencion", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvGrilla.DataSource == null)
            {
                return;
            }

            var item = (DetalleComprobanteKioscoDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;

            var verificarSiExiste = _listaDetalles.Find(x => x.CodigoProducto == item.CodigoProducto);

            if (verificarSiExiste != null)
            {
                _listaDetalles.Find(x => x.CodigoProducto == item.CodigoProducto).Cantidad -= nudUnidades.Value;

                //resta los productos para calcular el subtotal
                nudSubTotal.Value = _listaDetalles.Sum(x => x.SubTotalLinea);

                if (_listaDetalles.Find(x => x.CodigoProducto == item.CodigoProducto).Cantidad <= 0)
                {
                    _listaDetalles.Remove(verificarSiExiste);
                }

                CurrencyManager cm = (CurrencyManager)this.dgvGrilla.BindingContext[_listaDetalles];
                if (cm != null)
                {
                    cm.Refresh();
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            txtCodigo.Clear();
            txtDescripcion.Enabled = false;
            txtDescripcion.Clear();
            nudPrecioUnitario.Value = 0m;
            nudUnidades.Value = 1;
            txtCodigo.Focus();
        }

        private void BtnAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCodigo.Text != null
                && labels.Text != null
                && nudPrecioUnitario.Value != null
                && nudUnidades.Value >= 1)
            {
                if ((char) Keys.Enter == e.KeyChar)
                {
                    var producto = _productoServicio.ObtenerPorCodigoKiosko(txtCodigo.Text);

                    var nuevoDetalle = new DetalleComprobanteKioscoDto();
                    nuevoDetalle.CodigoProducto = producto.Codigo;
                    nuevoDetalle.DescripcionProducto = producto.Descripcion;
                    nuevoDetalle.Cantidad = nudUnidades.Value;
                    nuevoDetalle.PrecioUnitario = nudPrecioUnitario.Value;

                    //find busca el objeto de la lista
                    var verificarSiExiste = _listaDetalles.Find(
                        x => x.CodigoProducto == nuevoDetalle.CodigoProducto);

                    if (verificarSiExiste != null)
                    {
                        _listaDetalles.FirstOrDefault(x => x.CodigoProducto == nuevoDetalle.CodigoProducto)
                            .Cantidad += nuevoDetalle.Cantidad;
                    }
                    else
                    {
                        _listaDetalles.Add(nuevoDetalle);
                    }

                    // Currency Manager maneja el bindeo de datos

                    // Data binding es un mecanismo mediante el cual podemos enlazar los elementos de la
                    // interfaz de usuario con los objetos que contienen la información a mostrar. ...
                    // WPF nos permite de manera sencilla realizar binding a una propiedad de un control
                    // utilizando propiedades de otros controles, objetos, colecciones, etc.
                    CurrencyManager cm = (CurrencyManager)this.dgvGrilla.BindingContext[_listaDetalles];
                    if (cm != null)
                    {
                        cm.Refresh();
                    }

                    //calcular subtotal
                    nudSubTotal.Value = _listaDetalles.Sum(x => x.SubTotalLinea);

                    nudTotal.Value = nudSubTotal.Value - ((nudSubTotal.Value * nudDescuento.Value) / 100);
                    btnCobrar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Error al agregar al Producto, Verifique los valores!.",
                    "Atencion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void NudDescuento_Click(object sender, EventArgs e)
        {
            nudTotal.Value = nudSubTotal.Value - ((nudSubTotal.Value * nudDescuento.Value) / 100);
        }

        private void NudDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char) Keys.Enter == e.KeyChar)
            {
                nudTotal.Value = nudSubTotal.Value - ((nudSubTotal.Value * nudDescuento.Value) / 100);
            }
        }

        private void TxtClienteDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                var cliente = _clienteServicio.ObtenerPorDni(txtClienteDni.Text);

                if (cliente == null)
                {
                    MessageBox.Show("No se encontro el Cliente, Intente Nuevamente",
                        "Informacion",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    if (_clienteServicio.ObtenerPorId(cliente.Id) != null)
                    {
                        txtClienteDni.Text = cliente.Dni;
                        txtClienteNombre.Text = cliente.Nombre;
                        txtClienteApellido.Text = cliente.Apellido;

                        txtClienteNombre.Enabled = false;
                        txtClienteApellido.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el Cliente, Intente Nuevamente",
                            "Informacion",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            var lookupCliente = new _00047_LookUp_Clientes();

            lookupCliente.ShowDialog();

            var clienteDto = new ClienteDto();

            clienteDto = (ClienteDto)lookupCliente.ObjetoLookUp;

            if (clienteDto != null)
            {
                if (_clienteServicio.ObtenerPorId(clienteDto.Id) != null)
                {
                    txtClienteDni.Text = clienteDto.Dni;
                    txtClienteNombre.Text = clienteDto.Nombre;
                    txtClienteApellido.Text = clienteDto.Apellido;

                    txtClienteNombre.Enabled = false;
                    txtClienteApellido.Enabled = false;
                }
                else
                {
                    throw new Exception("Error en el Cliente.");
                }
            }

        }

        private void BtnCobrar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.DataSource == null)
            {
                MessageBox.Show(@"No hay Productos Cargados.",
                    @"Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if  ((TipoFormaPago)cmbFormaPago.SelectedItem == TipoFormaPago.Efectivo)
            {
                var ultimoComprobante = _comprobanteKioskoServicio.UltimoComprobanteId();

                var caja = _cajaServicio.Obtener(CajaAbiertaId).Id;

                var ClienteId = _clienteServicio.ObtenerPorDni(txtClienteDni.Text).Id;

                var fecha = dtpFecha.Value;

                var comprobante = new ComprobanteKioskoDto
                {
                    Numero = (int)ultimoComprobante,
                    Fecha = fecha,
                    SubTotal = nudSubTotal.Value,
                    Descuento = nudDescuento.Value,
                    Total = nudTotal.Value,
                    UsuarioId = (long)UsuarioLogueadoId,
                    ClienteId = ClienteId,
                    TipoComprobante = (TipoComprobante)cmbTipoComprobante.SelectedItem,
                    Items = _listaDetalles

                };

                _comprobanteKioskoServicio.GenerarComprobante(comprobante, caja);


                var traerComprobante = _comprobanteKioskoServicio.traerComprobantePorNumero(comprobante.Numero);


                var nuevoMovimiento = new MovimientoDto
                {
                    CajaId = caja,
                    ComprobanteId = traerComprobante.Id,
                    TipoMovimiento = TipoMovimiento.Ingreso,
                    UsuarioId = UsuarioLogueadoId,
                    Monto = nudTotal.Value,
                    Fecha = dtpFecha.Value,
                    Descripcion = "FAC_" + cmbTipoComprobante.Text + "_" +
                                  $"{_comprobanteKioskoServicio.UltimoComprobanteId()}" + "_" +
                                  DateTime.Now.ToShortDateString().Replace("/", string.Empty) + "_KIOSCO"
                };

                _movimientoServicio.Insertar(nuevoMovimiento);

                _cajaServicio.RealizarMovimiento(nuevoMovimiento);

                foreach (var items in _comprobanteKioskoDto.Items)
                {
                    //descontar stock
                    _articuloServicio.DescontarStock(items.ProductoId, items.Cantidad);
                }

                MessageBox.Show("Facturacion Realizada Correctamente",
                    "Informacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {

            _listaDetalles.Clear(); 

            CurrencyManager cm = (CurrencyManager)this.dgvGrilla.BindingContext[_listaDetalles];
            if (cm != null)
            {
                cm.Refresh();
            }

            _comprobanteKioskoDto = new ComprobanteKioskoDto();

            txtCodigo.Enabled = true;
            txtCodigo.Clear();
            txtDescripcion.Enabled = false;
            txtDescripcion.Clear();
            nudPrecioUnitario.Value = 0m;
            nudUnidades.Value = 1;
            txtCodigo.Focus();
            txtClienteDni.Clear();
            txtClienteNombre.Clear();
            txtClienteApellido.Clear();
            nudSubTotal.Value = 0.00m;
            nudDescuento.Value = 0m;
            nudTotal.Value = 0.00m;
            btnCobrar.Enabled = false;
            var clienteId = _clienteServicio.ObtenerPorDni("99999999").Id;
            txtClienteDni.Text = _clienteServicio.ObtenerPorId(clienteId).Dni;
            txtClienteNombre.Text = _clienteServicio.ObtenerPorId(clienteId).Nombre;
            txtClienteApellido.Text = _clienteServicio.ObtenerPorId(clienteId).Apellido;
        }
    }
}
 
