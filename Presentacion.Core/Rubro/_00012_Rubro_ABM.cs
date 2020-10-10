using Presentacion.FormularioBase;
using Presentacion.Helpers;
using XCommerce.Servicio.Core.Rubro;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Rubro.DTOS;

namespace Presentacion.Core.Rubro
{
    public partial class _00012_Rubro_ABM : FormularioAbm
    {
        private readonly IRubroSerivicio _rubroServicio;

        public _00012_Rubro_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _rubroServicio = new RubroServicio();

            if (TipoOperacion == TipoOperacion.Eliminar || TipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            // Asignando un Evento
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

            var provincia = _rubroServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = provincia.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevoRubro = new RubroDto
            {
                Descripcion = txtDescripcion.Text,
            };

            _rubroServicio.Insertar(nuevoRubro);

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

            var rubroModificar = new RubroDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };

            _rubroServicio.Modificar(rubroModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _rubroServicio.Eliminar(EntidadId.Value);

            return true;
        }
    }
}
