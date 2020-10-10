using Presentacion.Core.Marca;
using Presentacion.Core.Rubro;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.Articulo.DTOs;
using XCommerce.Servicio.Core.Marca;
using XCommerce.Servicio.Core.Marca.DTOs;
using XCommerce.Servicio.Core.Rubro;
using XCommerce.Servicio.Core.Rubro.DTOS;

namespace Presentacion.Core.Articulo
{
    public partial class _00034_Articulo_ABM : FormularioAbm
    {
        private readonly IArticuloServicio _articuloServicio;

        private readonly IMarcaServicio _marcaServicio;

        private readonly IRubroSerivicio _rubroSerivicio;
        public _00034_Articulo_ABM(TipoOperacion tipoOperacion, 
            long? entidadId = null)
        :base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _articuloServicio = new ArticuloServicio();
            _rubroSerivicio = new RubroServicio();
            _marcaServicio = new MarcaServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtCodigo, "Codigo");            
            AgregarControlesObligatorios(nudStock, "Stock");
            AgregarControlesObligatorios(cmbMarca, "Marca");
            AgregarControlesObligatorios(cmbRubro, "Rubro");
                    
            Inicializador(entidadId);

            
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            txtCodigo.KeyPress += Validacion.NoSimbolos;
            txtCodigo.KeyPress += Validacion.NoLetras;

            txtCodigoBarra.KeyPress += Validacion.NoSimbolos;
            txtCodigoBarra.KeyPress += Validacion.NoLetras;

            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            txtAbreviatura.KeyPress += Validacion.NoSimbolos;

            txtDetalle.KeyPress += Validacion.NoSimbolos;

            txtCodigo.Focus();     

            nudStockMin.Minimum = 0;
            nudStockMin.Maximum = 9999999;

            nudStockMax.Minimum = 0;
            nudStockMax.Maximum = 9999999;

            nudLimiteVenta.Minimum = 0;
            nudLimiteVenta.Maximum = 9999999;

            nudStock.Minimum = 0;
            nudStock.Maximum = 9999999;

            imgFotoArticulo.Image = Constantes.Imagen.Usuario;

            CargarComboBox(cmbMarca, _marcaServicio.Obtener(string.Empty), "Descripcion", "Id");

            CargarComboBox(cmbRubro, _rubroSerivicio.Obtener(string.Empty), "Descripcion", "Id");           

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

            if (TipoOperacion == TipoOperacion.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

            var articulo = _articuloServicio.ObtenerPorId(entidadId.Value);

            txtCodigo.Text = articulo.Codigo;
            txtCodigoBarra.Text = articulo.CodigoBarra;
            txtDescripcion.Text = articulo.Descripcion;
            txtDetalle.Text = articulo.Detalle;
            txtAbreviatura.Text = articulo.Abreviatura;
            imgFotoArticulo.Image = ImagenDb.Convertir_Bytes_Imagen(articulo.Foto);

            if (articulo.ActivarLimiteVenta == true)
            {
                checkBoxLimiteVenta.CheckState = CheckState.Checked;
            }
            else
            {
                checkBoxLimiteVenta.CheckState = CheckState.Unchecked;
            }
            nudLimiteVenta.Value = articulo.LimiteVenta;
            if (articulo.PermiteStockNegativo == true)
            {
                checkBoxStockNegativo.CheckState = CheckState.Checked;
            }
            else
            {
                checkBoxStockNegativo.CheckState = CheckState.Unchecked;
            }
            if (articulo.EstaDiscontinuado == true)
            {
                checkBoxDiscontinuado.CheckState = CheckState.Checked;
            }
            else
            {
                checkBoxDiscontinuado.CheckState = CheckState.Unchecked;
            }

            nudStockMax.Value = articulo.StockMaximo;
            nudStockMin.Value = articulo.StockMinimo;
            if (articulo.DescuentaStockl == true)
            {
                checkBoxDescuentaStock.CheckState = CheckState.Checked;
            }
            else
            {
                checkBoxDescuentaStock.CheckState = CheckState.Unchecked;
            }

            CargarComboBox(cmbMarca, _marcaServicio.Obtener(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbRubro, _rubroSerivicio.Obtener(string.Empty), "Descripcion", "Id");
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if(_articuloServicio.VerificarSiExisteCodigo(txtCodigo.Text))
            {
                MessageBox.Show(@"El código que desea utilizar ya está en uso");
                return false;
            }
            else
            {
                var nuevoArticulo = new ArticuloDto
                {
                    Codigo = txtCodigo.Text,
                    CodigoBarra = txtCodigoBarra.Text,
                    Abreviatura = txtAbreviatura.Text,
                    Descripcion = txtDescripcion.Text,
                    Detalle = txtDetalle.Text,
                    Foto = ImagenDb.Convertir_Imagen_Bytes(imgFotoArticulo.Image),
                    ActivarLimiteVenta = Convert.ToBoolean(checkBoxLimiteVenta.CheckState),
                    LimiteVenta = nudLimiteVenta.Value,
                    PermiteStockNegativo = Convert.ToBoolean(checkBoxStockNegativo.CheckState),
                    EstaDiscontinuado = Convert.ToBoolean(checkBoxDiscontinuado.CheckState),
                    StockMaximo = nudStockMax.Value,
                    StockMinimo = nudStockMin.Value,
                    DescuentaStockl = Convert.ToBoolean(checkBoxDescuentaStock.CheckState),
                    EstaEliminado = false,
                    MarcaId = ((MarcaDto)cmbMarca.SelectedItem).Id,
                    RubroId = ((RubroDto)cmbRubro.SelectedItem).Id,
                    Stock = nudStock.Value

                };

                
                _articuloServicio.Insertar(nuevoArticulo);
                return true;

            }

            
                    
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var articuloModificar = new ArticuloDto
            {
                Id = EntidadId.Value,
                Codigo = txtCodigo.Text,
                CodigoBarra = txtCodigoBarra.Text,
                Abreviatura = txtAbreviatura.Text,
                Descripcion = txtDescripcion.Text,
                Detalle = txtDetalle.Text,
                Foto = ImagenDb.Convertir_Imagen_Bytes(imgFotoArticulo.Image),
                ActivarLimiteVenta = Convert.ToBoolean(checkBoxLimiteVenta.CheckState),
                LimiteVenta = nudLimiteVenta.Value,
                PermiteStockNegativo = Convert.ToBoolean(checkBoxStockNegativo.CheckState),
                EstaDiscontinuado = Convert.ToBoolean(checkBoxDiscontinuado.CheckState),
                StockMaximo = nudStockMax.Value,
                StockMinimo = nudStockMin.Value,
                DescuentaStockl = Convert.ToBoolean(checkBoxDescuentaStock.CheckState),
                MarcaId = ((MarcaDto)cmbMarca.SelectedItem).Id,
                RubroId = ((RubroDto)cmbRubro.SelectedItem).Id,
                Stock = nudStock.Value
            };

            var codigoArticulo = _articuloServicio.ObtenerPorCodigo(txtCodigo.Text);

            if(_articuloServicio.VerificarSiExisteCodigo(txtCodigo.Text) && codigoArticulo.Id != articuloModificar.Id)
            {
                MessageBox.Show(@"El código que desea utilizar ya está en uso");
                return false;

            }
            else
            {
                _articuloServicio.Modificar(articuloModificar);
                return true;
            }

            
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _articuloServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void BtnAgregarImagen_Click_1(object sender, EventArgs e)
        {
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                // Pregunta si Selecciono un Archivo
                if (!string.IsNullOrEmpty(archivo.FileName))
                {
                    imgFotoArticulo.Image = Image.FromFile(archivo.FileName);
                }
                else
                {
                    imgFotoArticulo.Image = Constantes.Imagen.Usuario;
                }
            }
            else
            {
                imgFotoArticulo.Image = Constantes.Imagen.Usuario;
            }
        }

        private void BtnMarca_Click(object sender, EventArgs e)
        {
            var fNuevaMarca = new _00014_Marca_ABM(TipoOperacion.Nuevo);

            fNuevaMarca.ShowDialog();

            if (!fNuevaMarca.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbMarca, _marcaServicio.ObtenerParaCmb(string.Empty), "Descripcion", "Id");
        }

        private void BtnRubro_Click(object sender, EventArgs e)
        {
            var fNuevoRubro = new _00012_Rubro_ABM(TipoOperacion.Nuevo);

            fNuevoRubro.ShowDialog();

            if (!fNuevoRubro.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbRubro, _rubroSerivicio.ObtenerParaCmb(string.Empty), "Descripcion", "Id");
        }
    }
}
