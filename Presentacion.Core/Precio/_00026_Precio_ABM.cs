using Presentacion.Core.Articulo;
using Presentacion.Core.ListaPrecio;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.Articulo.DTOs;
using XCommerce.Servicio.Core.ListaPrecio;
using XCommerce.Servicio.Core.ListaPrecio.DTOs;
using XCommerce.Servicio.Core.Precio;
using XCommerce.Servicio.Core.Precio.DTOs;

namespace Presentacion.Core.Precio
{
    public partial class _00026_Precio_ABM : FormularioAbm
    {
        private readonly IPrecioServicio _precioServicio;

        private readonly IListaPrecioServicio _listaPrecioServicio;

        private readonly IArticuloServicio _articuloServicio;

        private int _articuloId;
        public _00026_Precio_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _precioServicio = new PrecioServicio();

            _articuloServicio = new ArticuloServicio();

            _listaPrecioServicio = new ListaPrecioServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(nudPrecioCosto, "Precio Costo");
            AgregarControlesObligatorios(dtpFechaActualizacion, "Fecha de Actualizacion");
            AgregarControlesObligatorios(cmbListaPrecio, "Lista de Precios");

            
            dtpFechaActualizacion.Enabled = false;

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            nudPrecioCosto.Focus();

            CargarComboBox(cmbListaPrecio,
                _listaPrecioServicio.Obtener(string.Empty),
                "Descripcion",
                "Id");

            nudPrecioCosto.Minimum = 0;
            nudPrecioCosto.Maximum = 9999999;
            nudPrecioCosto.DecimalPlaces = 2;

            nudPrecioCosto.Focus();

        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave",
                    @"Error Grave", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                this.Close();
            }

            var precio = _precioServicio.ObtenerPorId(entidadId.Value);

            nudPrecioCosto.Value = precio.PrecioCosto;
            dtpFechaActualizacion.Value = precio.FechaActualizacion;

            cmbListaPrecio.SelectedItem = precio.ListaPrecioId;
            if (precio.ActivarHoraVenta == true)
            {
                checkBActivarHoraVenta.CheckState = CheckState.Checked;
            }
            else
            {
                checkBActivarHoraVenta.CheckState = CheckState.Unchecked;
            }

            dtpHoraVenta.Value = precio.HoraVenta;

            CargarComboBox(cmbListaPrecio,
                _listaPrecioServicio.Obtener(string.Empty),
                "Descripcion",
                "Id");


        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevoPrecio = new PrecioDto
            {
                PrecioCosto = nudPrecioCosto.Value,
                PrecioPublico = CalcularPrecioPublico(),
                FechaActualizacion = dtpFechaActualizacion.Value,
                ListaPrecioId = ((ListaPrecioDto)cmbListaPrecio.SelectedItem).Id,
                ArticuloId = _articuloId,
                ActivarHoraVenta = checkBActivarHoraVenta.Checked,
                HoraVenta = dtpHoraVenta.Value
            };

            _precioServicio.Insertar(nuevoPrecio);

            return true;
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var precioModificar = new PrecioDto()
            {
                Id = EntidadId.Value,
                PrecioCosto = nudPrecioCosto.Value,
                FechaActualizacion = dtpFechaActualizacion.Value,
                ListaPrecioId = ((ListaPrecioDto)cmbListaPrecio.SelectedItem).Id,
                ArticuloId = _articuloId,
                ActivarHoraVenta = checkBActivarHoraVenta.Checked,
                HoraVenta = dtpHoraVenta.Value
            };

            _precioServicio.Modificar(precioModificar);

            return true;
        }

        private void BtnListaPrecios_Click(object sender, EventArgs e)
        {
            var fNuevaListaPrecios = new _00036_ListaPrecios_ABM(TipoOperacion.Nuevo);

            fNuevaListaPrecios.ShowDialog();

            if (!fNuevaListaPrecios.RealizoAlgunaOperacion) return;

        }

        private void BtnArticulos_Click(object sender, EventArgs e)
        {
            var fNuevaArticulos = new _00048_LookUp_Articulos();

            fNuevaArticulos.ShowDialog();

            var articuloLookUp = new ArticuloDto();

            articuloLookUp = (ArticuloDto)fNuevaArticulos.ObjetoLookUp;

            if (articuloLookUp != null)
            {
                txtArticulo.Text = articuloLookUp.Descripcion;
                _articuloId = (int)articuloLookUp.Id;
            }
        }


        private decimal CalcularPrecioPublico()
        {
            decimal precioPublico;
            precioPublico = nudPrecioCosto.Value + nudPrecioCosto.Value *
                (_listaPrecioServicio.ObtenerPorId(((ListaPrecioDto)cmbListaPrecio.SelectedItem).Id).Rentabilidad) / 100;

            return precioPublico;
        }

        private void CheckBActivarHoraVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBActivarHoraVenta.CheckState == CheckState.Checked)
            {
                dtpHoraVenta.Enabled = true;
            }
            else if (checkBActivarHoraVenta.CheckState == CheckState.Unchecked)
            {
                dtpHoraVenta.Enabled = false;
            }
        }
    }
     
}
