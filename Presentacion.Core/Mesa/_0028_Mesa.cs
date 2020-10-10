using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Mesa;
using XCommerce.Servicio.Core.Mesa.DTOs;

namespace Presentacion.Core.Mesa
{
    public partial class _0028_Mesa : FormularioConsulta
    {
        private readonly IMesaServicio _mesaServicio;

        public _0028_Mesa()
            : this(new MesaServicio())
        {
            InitializeComponent();
        }

        public _0028_Mesa(IMesaServicio mesaServicio)
        {
            _mesaServicio = mesaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Numero"].Visible = true;
            grilla.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Numero"].HeaderText = @"Numero";
            grilla.Columns["Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Salon"].Visible = true;
            grilla.Columns["Salon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Salon"].HeaderText = @"Salon";
            grilla.Columns["Salon"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["estadoMesa"].Visible = true;
            grilla.Columns["estadoMesa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["estadoMesa"].HeaderText = @"Estado";
            grilla.Columns["estadoMesa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _mesaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fmesaABM = new _0029_Mesa_ABM(TipoOperacion.Nuevo);
            fmesaABM.ShowDialog();

            ActualizarSegunOperacion(fmesaABM.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((MesaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fmesaABM = new _0029_Mesa_ABM(TipoOperacion.Modificar, EntidadId);
                fmesaABM.ShowDialog();

                ActualizarSegunOperacion(fmesaABM.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Mesa se encuetra Elimnada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((MesaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fmesaABM = new _0029_Mesa_ABM(TipoOperacion.Eliminar, EntidadId);

                fmesaABM.ShowDialog();

                ActualizarSegunOperacion(fmesaABM.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La mesa se encuetra Elimnada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }
    }
}
