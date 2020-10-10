using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Marca;
using XCommerce.Servicio.Core.Marca.DTOs;

namespace Presentacion.Core.Marca
{
    public partial class _00013_Marca : FormularioConsulta
    {
        private readonly IMarcaServicio _marcaServicio;
        public _00013_Marca()
            :this(new MarcaServicio())
        {
            InitializeComponent();
        }

        public _00013_Marca(IMarcaServicio marcaServicio)
        {
            _marcaServicio = marcaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Marca";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _marcaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fProvinciaAbm = new _00014_Marca_ABM(TipoOperacion.Nuevo);
            fProvinciaAbm.ShowDialog();

            ActualizarSegunOperacion(fProvinciaAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((MarcaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fProvinciaAbm = new _00014_Marca_ABM(TipoOperacion.Modificar, EntidadId);
                fProvinciaAbm.ShowDialog();

                ActualizarSegunOperacion(fProvinciaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Marca se encuetra Elimnada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((MarcaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fMarcaAbm = new _00014_Marca_ABM(TipoOperacion.Eliminar, EntidadId);

                fMarcaAbm.ShowDialog();

                ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Marca se encuetra Elimnada", @"Atención", MessageBoxButtons.OK,
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
