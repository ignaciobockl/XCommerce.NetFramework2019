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
using XCommerce.Servicio.Core.Articulo.BajaArticulo;

namespace Presentacion.Core.Articulo.BajaArticulo
{
    public partial class _00015_BajaArticulo : FormularioConsulta
    {
        private readonly IBajaArticuloServicio _bajaArticuloServicio;
        public _00015_BajaArticulo()
        :this(new BajaArticuloServicio())
        {
            InitializeComponent();

            btnEliminar.Visible = false;
            btnModificar.Visible = false;
        }

        public _00015_BajaArticulo(IBajaArticuloServicio bajaArticuloServicio)
        {
            _bajaArticuloServicio = bajaArticuloServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].Width = 100;
            grilla.Columns["Fecha"].HeaderText = @"Fecha";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Cantidad"].Visible = true;
            grilla.Columns["Cantidad"].Width = 100;
            grilla.Columns["Cantidad"].HeaderText = @"Cantidad";
            grilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Observacion"].Visible = true;
            grilla.Columns["Observacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Observacion"].HeaderText = @"Observacion";
            grilla.Columns["Observacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _bajaArticuloServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fBajaArticuloAbm = new _00016_BajaArticulo_ABM(TipoOperacion.Nuevo);
            fBajaArticuloAbm.ShowDialog();

            ActualizarSegunOperacion(fBajaArticuloAbm.RealizoAlgunaOperacion);

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
