using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.Articulo.DTOs;

namespace Presentacion.Core.Articulo
{
    public partial class _00033_Articulo : FormularioConsulta
    {
        private readonly IArticuloServicio _articuloServicio;

        public _00033_Articulo()
            : this(new ArticuloServicio())
        {
            InitializeComponent();
        }

        public _00033_Articulo(IArticuloServicio articuloServicio)
        {
            _articuloServicio = articuloServicio;
        }
        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Codigo"].Visible = true;
            grilla.Columns["Codigo"].Width = 100;
            grilla.Columns["Codigo"].HeaderText = @"Codigo";
            grilla.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Stock"].Visible = true;
            grilla.Columns["Stock"].Width = 100;
            grilla.Columns["Stock"].HeaderText = @"Stock";
            grilla.Columns["Stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _articuloServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fArticuloabm = new _00034_Articulo_ABM(TipoOperacion.Nuevo);
            fArticuloabm.ShowDialog();

            ActualizarSegunOperacion(fArticuloabm.RealizoAlgunaOperacion);
        }

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }

        public override void EjecutarModificar()
        {
            if (!((ArticuloDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fArticuloabm = new _00034_Articulo_ABM(TipoOperacion.Modificar, EntidadId);
                fArticuloabm.ShowDialog();

                ActualizarSegunOperacion(fArticuloabm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El articulo se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((ArticuloDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fArticuloabm = new _00034_Articulo_ABM(TipoOperacion.Eliminar, EntidadId);

                fArticuloabm.ShowDialog();

                ActualizarSegunOperacion(fArticuloabm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El articulo se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


        }
    }

}

