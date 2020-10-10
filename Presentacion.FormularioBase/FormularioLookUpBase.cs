using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.FormularioBase
{
    public partial class FormularioLookUpBase : FormularioConsulta
    {
        public FormularioLookUpBase()
        {
            InitializeComponent();

            btnEliminar.Visible = false;
            btnActualizar.Visible = false;
            btnImprimir.Visible = false;
            btnNuevo.Visible = false;
            btnModificar.Visible = false;
        }

        public override void DgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;

            }

            if (HayDatosCargados())
            {
                ObjetoLookUp = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
                this.Close();
            }
            else
            {
                EntidadId = null;
                EntidadSeleccionada = null;
            }
        }
    }
}
