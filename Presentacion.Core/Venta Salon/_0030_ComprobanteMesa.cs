using Presentacion.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Comprobante;
using XCommerce.Servicio.Core.Comprobante.DTOs;
using XCommerce.Servicio.Core.Empleado;
using XCommerce.Servicio.Core.Precio;
using XCommerce.Servicio.Core.Producto;
using XCommerce.Servicio.Core.Producto.DTOs;

namespace Presentacion.Core.Venta_Salon
{
    public partial class _0030_ComprobanteMesa : FormularioBase.FormularioBase
    {
        private readonly long _mesaId;

        private readonly IComprobanteSalonServicio _comprobanteSalonServicio;
        private readonly IProductoServicio _productoServicio;
        private readonly IEmpleadoServicio _empleadoServicio;
        
        public object articuloEliminar;

        public _0030_ComprobanteMesa()
            : this(new ComprobanteSalonServicio(), new ProductoServicio(), new EmpleadoServicio())
        {
            InitializeComponent();

            inicializador(_mesaId);

            txtCodigo.Focus();
        }

        private void inicializador(long EntidadId)
        {
            nudSubTotal.Minimum = 0;
            nudSubTotal.Maximum = 99999999;

            nudTotal.Minimum = 0;
            nudTotal.Maximum = 99999999;

            txtCodigo.KeyPress += Validacion.NoLetras;
            txtCodigo.KeyPress += Validacion.NoSimbolos;

            txtMozo.KeyPress += Validacion.NoLetras;
            txtMozo.KeyPress += Validacion.NoSimbolos;

            nudTotal.KeyPress += Validacion.NoSimbolos;
            nudTotal.KeyPress += Validacion.NoSimbolos;

            txtLegajo.Enabled = false;
            txtCodigo.Enabled = false;
        }

        public _0030_ComprobanteMesa(IComprobanteSalonServicio comprobanteSalonServicio, IProductoServicio productoServicio,
            IEmpleadoServicio empleadoServicio)
        {
            _comprobanteSalonServicio = comprobanteSalonServicio;
            _productoServicio = productoServicio;
            _empleadoServicio = empleadoServicio;
        }

        public _0030_ComprobanteMesa(long mesaId, int _numeroMesa)
            : this()
        {
            _mesaId = mesaId;
            Text = $"Venta - Mesa {_numeroMesa}";

            ObtenerComprobanteMesa(mesaId);
        }

        private void ObtenerComprobanteMesa(long mesaId)
        {
            var ComprobanteMesaDto = _comprobanteSalonServicio.ObtenerPorId(mesaId);

            if (ComprobanteMesaDto == null)
            {
                MessageBox.Show("Ocurrio un error");
                this.Close();
            }

            

            nudSubTotal.Value = ComprobanteMesaDto.SubTotal;
            nudNumero.Value = _comprobanteSalonServicio.ObtenerNumeroComprobante();
            nudDescuento.Value = ComprobanteMesaDto.Descuento;
            nudTotal.Value = ComprobanteMesaDto.Total;
            
            

            if (ComprobanteMesaDto.MozoId == null)
            {
                txtLegajo.Text = string.Empty;
                txtMozo.Text = string.Empty;
            }
            else
            {
                txtLegajo.Text = ComprobanteMesaDto.MozoId.ToString();
                txtMozo.Text = ComprobanteMesaDto.ApyNomMozo;
            }

            dgvGrilla.DataSource = ComprobanteMesaDto.Items.ToList();

            FormatearGrillaVenta();
        }

        private void FormatearGrillaVenta()
        {
            for (var i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }

            dgvGrilla.Columns["CodigoProducto"].Visible = true;
            dgvGrilla.Columns["CodigoProducto"].Width = 100;
            dgvGrilla.Columns["CodigoProducto"].HeaderText = @"Codigo";
            dgvGrilla.Columns["CodigoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["CodigoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["DescripcionProducto"].Visible = true;
            dgvGrilla.Columns["DescripcionProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["DescripcionProducto"].HeaderText = @"Descripcion";
            dgvGrilla.Columns["DescripcionProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["DescripcionProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["PrecioUnitario"].Visible = true;
            dgvGrilla.Columns["PrecioUnitario"].Width = 100;
            dgvGrilla.Columns["PrecioUnitario"].HeaderText = @"Precio Unitario";
            dgvGrilla.Columns["PrecioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["PrecioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Cantidad"].Visible = true;
            dgvGrilla.Columns["Cantidad"].Width = 150;
            dgvGrilla.Columns["Cantidad"].HeaderText = @"Cantidad";
            dgvGrilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["SubTotalLinea"].Visible = true;
            dgvGrilla.Columns["SubTotalLinea"].Width = 100;
            dgvGrilla.Columns["SubTotalLinea"].HeaderText = @"Sub Total";
            dgvGrilla.Columns["SubTotalLinea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["SubTotalLinea"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }       

        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            var producto = _productoServicio.ObtenerPorCodigo(_mesaId, txtCodigo.Text);

            if ((char)Keys.Enter == e.KeyChar)
            {
                txtCodigo.Focus();

                nudCantidad.Enabled = false;
            }
        }

        

        private void TxtCodigo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    MessageBox.Show("Por favor ingrese un codigo");
                    return;
                }

                var producto = _productoServicio.ObtenerPorCodigo(_mesaId, txtCodigo.Text);

                if (producto == null)
                {
                    MessageBox.Show("No se encontro el producto ingresado.");
                }
                else
                {
                    producto.Stock -= producto.Cantidad;

                    if (producto.Stock > 0)
                    {
                        _comprobanteSalonServicio.AgregarItem(_mesaId, nudCantidad.Value, producto);
                        txtDescripcion.Text = producto.Descripcion;
                        txtPrecioUnitario.Text = producto.Precio.ToString();


                        ObtenerComprobanteMesa(_mesaId);

                        nudCantidad.Value = 1;
                    }
                    else
                    {
                        MessageBox.Show("Se supero la cantidad de productos en stock.", "Atencion",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                
                txtCodigo.Clear();
            }

            if ((char)Keys.L == e.KeyChar)
            {
                nudCantidad.Enabled = true;
                nudCantidad.Focus();
                nudCantidad.Value = 0;
            }
        }

        private void TxtLegajo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                if (string.IsNullOrEmpty(txtLegajo.Text))
                {
                    MessageBox.Show("Por favor ingrese un legajo valido");
                    return;
                }

                var mozo = _empleadoServicio.ObtenerPorLegajo(txtLegajo.Text);

                if (mozo != null)
                {
                    if (mozo.EstaEliminado)
                    {
                        MessageBox.Show("El mozo seleccionado se encuentra eliminado");
                    }
                    else
                    {
                        var mesa = _comprobanteSalonServicio.ObtenerPorId(_mesaId);
                        _comprobanteSalonServicio.ModificarMozo(_mesaId, mozo);

                        txtMozo.Text = mozo.ApyNom;

                        txtCodigo.Enabled = true;
                        txtCodigo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro el mozo");
                }
            }
        }

        

        private void DgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.DataSource == null)
            {
                MessageBox.Show("No hay items que eliminar");
                return;
            }

            if(e.RowIndex < 0)
            {
                return;
               
            }
                        

            articuloEliminar = dgvGrilla.Rows[e.RowIndex].DataBoundItem;

            var pdto = (DetalleComprobanteSalonDto)articuloEliminar;

            var productoEliminar = _productoServicio.ObtenerPorCodigo(_mesaId, pdto.CodigoProducto);

            _comprobanteSalonServicio.QuitarItem(_mesaId, nudCantidad.Value, productoEliminar);            

            var ComprobanteMesaDto = _comprobanteSalonServicio.ObtenerPorId(_mesaId);

            nudSubTotal.Value = ComprobanteMesaDto.SubTotal;            
            nudDescuento.Value = ComprobanteMesaDto.Descuento;
            nudTotal.Value = ComprobanteMesaDto.Total;

            var mozo = _empleadoServicio.ObtenerPorLegajo(txtLegajo.Text);

            //txtMozo.Text = mozo.ApyNom;            

            dgvGrilla.DataSource = ComprobanteMesaDto.Items.ToList();
            

            FormatearGrillaVenta();

            
        }

        private void NudComensales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((char)Keys.Enter == e.KeyChar)
            {
                var comprobante = _comprobanteSalonServicio.ObtenerPorId(_mesaId);

                if(comprobante == null)
                {
                    MessageBox.Show(@"No se encontró al comprobante.");
                    return;
                }

                _comprobanteSalonServicio.ModificarComensal(comprobante.Id, nudComensales.Value.ToString());

                txtLegajo.Enabled = true;
                txtLegajo.Focus();
            }
        }
    }
}
