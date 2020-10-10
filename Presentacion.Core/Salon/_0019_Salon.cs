using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Salon;
using XCommerce.Servicio.Core.Salon.DTOs;

namespace Presentacion.Core.Salon
{
    public partial class _0019_Salon : FormularioConsulta
    {
        private readonly ISalonServicio _salonServicio;

        public _0019_Salon()
            : this(new SalonServicio())
        {
            InitializeComponent();
        }

        public _0019_Salon(ISalonServicio salonServicios)
        {
            _salonServicio = salonServicios;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].Width = 100;
            grilla.Columns["Descripcion"].HeaderText = @"Salon";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["ListaPrecio"].Visible = true;
            grilla.Columns["ListaPrecio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ListaPrecio"].HeaderText = @"Lista de Precio";
            grilla.Columns["ListaPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["ListaPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _salonServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fSalonAbm = new _0020_Salon_ABM(TipoOperacion.Nuevo);
            fSalonAbm.ShowDialog();

            ActualizarSegunOperacion(fSalonAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((SalonDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fSalonAbm = new _0020_Salon_ABM(TipoOperacion.Modificar, EntidadId);
                fSalonAbm.ShowDialog();

                ActualizarSegunOperacion(fSalonAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((SalonDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fSalonAbm = new _0020_Salon_ABM(TipoOperacion.Eliminar, EntidadId);

                fSalonAbm.ShowDialog();

                ActualizarSegunOperacion(fSalonAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El salon se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // ======================================================================================= //

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }
    }
}
