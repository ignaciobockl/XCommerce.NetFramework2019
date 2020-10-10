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
using XCommerce.Servicio.Core.ListaPrecio;

namespace Presentacion.Core.ListaPrecio
{
    public partial class ArticuloLookUp : FormularioLookUpBase
    {       

        private readonly IListaPrecioServicio _listaPrecioServicio;

        public ArticuloLookUp(long? entidadId)

        {
            InitializeComponent();

            _listaPrecioServicio = new ListaPrecioServicio();

            dgvGrilla.DataSource = _listaPrecioServicio.ObtenerPorLista(entidadId.Value);
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
        }


    }
}
