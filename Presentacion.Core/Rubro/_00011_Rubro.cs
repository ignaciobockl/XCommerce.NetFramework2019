using System;
using System.Windows.Forms;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using XCommerce.Servicio.Core.Rubro;
using XCommerce.Servicio.Core.Rubro.DTOS;

namespace Presentacion.Core.Rubro
{
    public partial class _00011_Rubro : FormularioConsulta
    {
        private readonly IRubroSerivicio _rubroSerivicio;

        public _00011_Rubro()
            : this(new RubroServicio())
        {
            InitializeComponent();
        }

        public _00011_Rubro(IRubroSerivicio rubroSerivicio)
        {
            _rubroSerivicio = rubroSerivicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Rubro";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _rubroSerivicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fRubroAbm = new _00012_Rubro_ABM(TipoOperacion.Nuevo);
            fRubroAbm.ShowDialog();

            ActualizarSegunOperacion(fRubroAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((RubroDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fRubroAbm = new _00012_Rubro_ABM(TipoOperacion.Modificar, EntidadId);
                fRubroAbm.ShowDialog();

                ActualizarSegunOperacion(fRubroAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((RubroDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fRubroAbm = new _00012_Rubro_ABM(TipoOperacion.Eliminar, EntidadId);

                fRubroAbm.ShowDialog();

                ActualizarSegunOperacion(fRubroAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            ActualizarDatos(dgvGrilla, string.Empty);
        }
    }       
}
