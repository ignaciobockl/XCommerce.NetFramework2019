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
using XCommerce.Servicio.Core.Articulo.MotivoBaja;

namespace Presentacion.Core.Articulo.MotivoBaja
{
    public partial class _00017_MotivoBaja : FormularioConsulta
    {
        private readonly IMotivoBajaServicio _motivoBajaServicio;
        public _00017_MotivoBaja()
            :this(new MotivoBajaServicio())

        {
            InitializeComponent();
        }

        public _00017_MotivoBaja(IMotivoBajaServicio motivoBajaServicio)
        {
            _motivoBajaServicio = motivoBajaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Motivo de Baja";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void EjecutarNuevo()
        {
            var fMotivoBajaAbm = new _00018_MotivoBaja_ABM(TipoOperacion.Nuevo, EntidadId);
            fMotivoBajaAbm.ShowDialog();

            ActualizarSegunOperacion(fMotivoBajaAbm.RealizoAlgunaOperacion);
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
