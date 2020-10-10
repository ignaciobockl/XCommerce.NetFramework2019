using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Empresa;

namespace Presentacion.Core.Empresa
{
    public partial class _0023_Empresa : FormularioConsulta
    {
        private readonly IEmpresaServicio _empresaServicio;

        public _0023_Empresa()
            : this(new EmpresaServicio())
        {
            InitializeComponent();

            btnEliminar.Visible = false;
        }

        public _0023_Empresa(IEmpresaServicio empresaServicio)
        {

            _empresaServicio = empresaServicio;

        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["RazonSocial"].Visible = true;
            grilla.Columns["RazonSocial"].Width = 100;
            grilla.Columns["RazonSocial"].HeaderText = @"Razon Social";
            grilla.Columns["RazonSocial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["NombreFantasia"].Visible = true;
            grilla.Columns["NombreFantasia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["NombreFantasia"].HeaderText = @"Nombre de Fantasia";
            grilla.Columns["NombreFantasia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Sucursal"].Visible = true;
            grilla.Columns["Sucursal"].Width = 100;
            grilla.Columns["Sucursal"].HeaderText = @"Sucursal";
            grilla.Columns["Sucursal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _empresaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fEmpresaAbm = new _0024_Empresa_ABM(TipoOperacion.Nuevo);
            fEmpresaAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpresaAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();

            if (!PuedeEjecutarComando) return;

            var fEmpresaAbm = new _0024_Empresa_ABM(TipoOperacion.Modificar, EntidadId);
            fEmpresaAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpresaAbm.RealizoAlgunaOperacion);
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
