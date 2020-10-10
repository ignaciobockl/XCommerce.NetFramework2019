using Presentacion.FormularioBase;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Movimiento;

namespace Presentacion.Core.Movimiento
{
    public partial class _00041_Movimiento : FormularioConsulta
    {
        private readonly IMovimientoServicio _movimientoServicio;
        public _00041_Movimiento()
        :this(new MovimientoServicio())
        {
            InitializeComponent();

            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            btnNuevo.Visible = false;
            btnActualizar.Visible = false;
        }

        public _00041_Movimiento(IMovimientoServicio movimientoServicio)
        {
            _movimientoServicio = movimientoServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].Width = 100;
            grilla.Columns["Fecha"].HeaderText = @"Fecha";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Monto"].Visible = true;
            grilla.Columns["Monto"].Width = 100;
            grilla.Columns["Monto"].HeaderText = @"Monto";
            grilla.Columns["Monto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["TipoMovimiento"].Visible = true;
            grilla.Columns["TipoMovimiento"].Width = 100;
            grilla.Columns["TipoMovimiento"].HeaderText = @"Tipo";
            grilla.Columns["TipoMovimiento"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;           

        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _movimientoServicio.Obtener(cadenaBuscar);
        }        

        // ======================================================================================= //

        
    }
}
