using Presentacion.Core.ListaPrecio;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System.Windows.Forms;
using XCommerce.Servicio.Core.ListaPrecio;
using XCommerce.Servicio.Core.ListaPrecio.DTOs;
using XCommerce.Servicio.Core.Salon;
using XCommerce.Servicio.Core.Salon.DTOs;

namespace Presentacion.Core.Salon
{
    public partial class _0020_Salon_ABM : FormularioAbm
    {
        private readonly ISalonServicio _salonServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;

        public _0020_Salon_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

           _listaPrecioServicio = new ListaPrecioServicio();

            _salonServicio = new SalonServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion, "Descripción");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbListaPrecioSalon, _listaPrecioServicio.Obtener(string.Empty), "Descripcion", "Id");

            //Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoNumeros;

            txtDescripcion.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOperacion.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

           CargarComboBox(cmbListaPrecioSalon, _listaPrecioServicio.Obtener(string.Empty), "Descripcion", "Id");

            var salon = _salonServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = salon.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevoSalon = new SalonDto
            {
                Descripcion = txtDescripcion.Text,
                ListaPrecioId = ((ListaPrecioDto)cmbListaPrecioSalon.SelectedItem).Id
            };

            _salonServicio.Insertar(nuevoSalon);

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

            var provinciaParaModificar = new SalonDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };

            _salonServicio.Modificar(provinciaParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _salonServicio.Eliminar(EntidadId.Value);

            return true;
        }        

        private void BtnListaPrecios_Click_1(object sender, System.EventArgs e)
        {
            var fNuevaLista = new _00036_ListaPrecios_ABM(TipoOperacion.Nuevo);

            fNuevaLista.ShowDialog();

            CargarComboBox(cmbListaPrecioSalon, _listaPrecioServicio.Obtener(string.Empty), "Descripcion", "Id");

            
        }
    }
}
