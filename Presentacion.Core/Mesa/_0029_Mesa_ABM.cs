using Presentacion.Core.Salon;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Mesa;
using XCommerce.Servicio.Core.Mesa.DTOs;
using XCommerce.Servicio.Core.Salon;
using XCommerce.Servicio.Core.Salon.DTOs;

namespace Presentacion.Core.Mesa
{
    public partial class _0029_Mesa_ABM : FormularioAbm
    {
        private readonly IMesaServicio _mesaServicio;
        private readonly ISalonServicio _salonServicio;

        public _0029_Mesa_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _mesaServicio = new MesaServicio();
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

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
            AgregarControlesObligatorios(nudNumero, "Numero");
            AgregarControlesObligatorios(cmbSalon, "Salon");


            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbSalon, _salonServicio.Obtener(string.Empty), "Salon", "Descripcion");

            nudNumero.Minimum = 1;
            nudNumero.Maximum = 99999999;
            nudNumero.Value = _mesaServicio.ObtenerSiguienteMesa();

            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            nudNumero.Focus();
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

            var mesa = _mesaServicio.ObtenerPorId(entidadId.Value);

            txtDescripcion.Text = mesa.Descripcion;

            CargarComboBox(cmbSalon, _salonServicio.Obtener(string.Empty), "Descripcion", "Id");
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaMesa = new MesaDto
            {
                Numero = (int)nudNumero.Value,
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false,
                estadoMesa = XCommerce.AccesoDatos.EstadoMesa.Cerrada,
                SalonId = ((SalonDto)cmbSalon.SelectedItem).Id

            };

            _mesaServicio.Insertar(nuevaMesa);

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

            var mesaModificar = new MesaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                Numero = (int)nudNumero.Value,
                SalonId = ((SalonDto)cmbSalon.SelectedItem).Id,
                EstaEliminado = false,

            };

            _mesaServicio.Modificar(mesaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _mesaServicio.Eliminar(EntidadId.Value);

            return true;
        }

        public override void EjecutarComando()
        {
            base.EjecutarComando();

            if (TipoOperacion == TipoOperacion.Nuevo)
                nudNumero.Value = _mesaServicio.ObtenerSiguienteMesa();
        }

        private void btnNuevoSalon_Click(object sender, EventArgs e)
        {
            var fnuevoSalon = new _0020_Salon_ABM(TipoOperacion.Nuevo);
            fnuevoSalon.ShowDialog();

            if (!fnuevoSalon.RealizoAlgunaOperacion) return;


            CargarComboBox(cmbSalon, _salonServicio.Obtener(string.Empty), "Salon", "Descripcion");
            if (cmbSalon.Items.Count > 0)
            {

                _salonServicio.Obtener(((SalonDto)cmbSalon.SelectedItem).Descripcion);
            }
        }
    }
}
