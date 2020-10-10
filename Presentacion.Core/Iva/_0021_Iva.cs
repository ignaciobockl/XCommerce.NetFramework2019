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
using XCommerce.Servicio.Core.Iva;

namespace Presentacion.Core.Iva
{
    public partial class _0021_Iva : FormularioConsulta
    {
        private readonly IIvaServicios _ivaServicios;

        public _0021_Iva()
           : this(new IvaServicios())
        {
            InitializeComponent();

            btnEliminar.Visible = false;
        }

        public _0021_Iva(IIvaServicios ivaServicios)
        {
            _ivaServicios = ivaServicios;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Iva";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _ivaServicios.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fIvaAbm = new _0022_Iva_ABM(TipoOperacion.Nuevo);
            fIvaAbm.ShowDialog();

            ActualizarSegunOperacion(fIvaAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {

            base.EjecutarModificar();

            if (!PuedeEjecutarComando) return;

            var fIvaAbm = new _0022_Iva_ABM(TipoOperacion.Modificar, EntidadId);
            fIvaAbm.ShowDialog();

            ActualizarSegunOperacion(fIvaAbm.RealizoAlgunaOperacion);

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
