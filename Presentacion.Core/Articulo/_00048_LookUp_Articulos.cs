using Presentacion.FormularioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Articulo;

namespace Presentacion.Core.Articulo
{
    public partial class _00048_LookUp_Articulos : FormularioLookUpBase
    {
        private readonly IArticuloServicio _articuloServicio;

        public _00048_LookUp_Articulos()
            : this(new ArticuloServicio())
        {
            InitializeComponent();
        }

        public _00048_LookUp_Articulos(IArticuloServicio articuloServicio)
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

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _articuloServicio.ObtenerParaLookUp(cadenaBuscar);
        }
    }
}
