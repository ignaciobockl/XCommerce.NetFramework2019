using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using XCommerce.Servicio.Core.ListaPrecio;
using XCommerce.Servicio.Core.ListaPrecio.DTOs;

namespace Presentacion.Core.ListaPrecio
{
    public partial class _00035_ListaPrecios : FormularioConsulta
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;
        public _00035_ListaPrecios()
        :this(new ListaPrecioServicio())
        {
            InitializeComponent();
        }

        public _00035_ListaPrecios(IListaPrecioServicio listaPrecioServicio)
        {
            _listaPrecioServicio = listaPrecioServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Rentabilidad"].Visible = true;
            grilla.Columns["Rentabilidad"].Width = 150;
            grilla.Columns["Rentabilidad"].HeaderText = @"Rentabilidad";
            grilla.Columns["Rentabilidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _listaPrecioServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fListaPrecioAbm = new _00036_ListaPrecios_ABM(TipoOperacion.Nuevo);
            fListaPrecioAbm.ShowDialog();

            ActualizarSegunOperacion(fListaPrecioAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((ListaPrecioDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fListaPrecioAbm = new _00036_ListaPrecios_ABM(TipoOperacion.Modificar, EntidadId);
                fListaPrecioAbm.ShowDialog();

                ActualizarSegunOperacion(fListaPrecioAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Lista de Precio se encuetra Elimnada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((ListaPrecioDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fListaPrecioAbm = new _00036_ListaPrecios_ABM(TipoOperacion.Eliminar, EntidadId);

                fListaPrecioAbm.ShowDialog();

                ActualizarSegunOperacion(fListaPrecioAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Lista de Precio se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
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

        public override void DgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var fArticulosLookUp = new ArticuloLookUp(EntidadId);
            fArticulosLookUp.ShowDialog();
        }
    }
}
