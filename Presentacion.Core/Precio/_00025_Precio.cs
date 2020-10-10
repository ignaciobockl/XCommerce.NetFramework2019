using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.ListaPrecio;
using XCommerce.Servicio.Core.Precio;
using XCommerce.Servicio.Core.Precio.DTOs;

namespace Presentacion.Core.Precio
{
    public partial class _00025_Precio : FormularioConsulta
    {
        private readonly IPrecioServicio _precioServicio;

        private readonly IArticuloServicio _articuloServicio;

        private readonly IListaPrecioServicio _listaPrecioServicio;
        public _00025_Precio()
             :this(new PrecioServicio(), new ArticuloServicio(), new ListaPrecioServicio())
        {
            InitializeComponent();
        }

        public _00025_Precio(IPrecioServicio precioServicio, 
            IArticuloServicio articuloServicio, 
            IListaPrecioServicio listaPrecioServicio)
        {
            _precioServicio = precioServicio;

            _articuloServicio = articuloServicio;

            _listaPrecioServicio = listaPrecioServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["PrecioCosto"].Visible = true;
            grilla.Columns["PrecioCosto"].Width = 100;
            grilla.Columns["PrecioCosto"].HeaderText = @"Precio Costo";
            grilla.Columns["PrecioCosto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["PrecioPublico"].Visible = true;
            grilla.Columns["PrecioPublico"].Width = 100;
            grilla.Columns["PrecioPublico"].HeaderText = @"Precio Publico";
            grilla.Columns["PrecioPublico"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["FechaActualizacion"].Visible = true;
            grilla.Columns["FechaActualizacion"].Width = 125;
            grilla.Columns["FechaActualizacion"].HeaderText = @"Fecha de Actualizacion";
            grilla.Columns["FechaActualizacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Articulo.Descripcion"].Visible = true;
            grilla.Columns["Articulo.Descripcion"].Width = 100;
            grilla.Columns["Articulo.Descripcion"].HeaderText = @"Articulo Id";
            grilla.Columns["Articulo.Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["ListaPrecio.Descripcion"].Visible = true;
            grilla.Columns["ListaPrecio.Descripcion"].Width = 100;
            grilla.Columns["ListaPrecio.Descripcion"].HeaderText = @"Lista de Precio Id";
            grilla.Columns["ListaPrecio.Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        /*public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _precioServicio.Obtener(cadenaBuscar);
        }*/

        public override void EjecutarNuevo()
        {
            var fPrecioAbm = new _00026_Precio_ABM(TipoOperacion.Nuevo);
            fPrecioAbm.ShowDialog();

            ActualizarSegunOperacion(fPrecioAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((PrecioDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fPrecioAbm = new _00026_Precio_ABM(TipoOperacion.Modificar, EntidadId);
                fPrecioAbm.ShowDialog();

                ActualizarSegunOperacion(fPrecioAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Precio se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
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

        private void _00025_Precio_Load(object sender, EventArgs e)
        {

        }
    }
}
