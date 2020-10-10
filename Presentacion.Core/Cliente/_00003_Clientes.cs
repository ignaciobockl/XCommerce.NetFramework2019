using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;

namespace Presentacion.Core.Cliente
{
    public partial class _00003_Clientes : FormularioConsulta
    {
        private readonly IClienteServicio _clienteServicio;

        public _00003_Clientes()
        :this(new ClienteServicio())
        {
            InitializeComponent();
        }

        public _00003_Clientes(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["ApyNom"].Visible = true;
            grilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            grilla.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Dni"].Visible = true;
            grilla.Columns["Dni"].Width = 100;
            grilla.Columns["Dni"].HeaderText = @"DNI";
            grilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Celular"].Visible = true;
            grilla.Columns["Celular"].Width = 150;
            grilla.Columns["Celular"].HeaderText = @"Celular";
            grilla.Columns["Celular"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["MontoDeudaCtaCte"].Visible = true;
            grilla.Columns["MontoDeudaCtaCte"].Width = 150;
            grilla.Columns["MontoDeudaCtaCte"].HeaderText = @"Deuda";
            grilla.Columns["MontoDeudaCtaCte"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Dni"].Visible = true;
            grilla.Columns["Dni"].Width = 100;
            grilla.Columns["Dni"].HeaderText = @"DNI";
            grilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _clienteServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fClienteAbm = new _00004_Clientes_ABM(TipoOperacion.Nuevo);
            fClienteAbm.ShowDialog();

            ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((ClienteDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fClienteAbm = new _00004_Clientes_ABM(TipoOperacion.Modificar, EntidadId);
                fClienteAbm.ShowDialog();

                ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Cliente se encuetra Eliminado",
                    @"Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((ClienteDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fClienteAbm = new _00004_Clientes_ABM(TipoOperacion.Eliminar, EntidadId);

                fClienteAbm.ShowDialog();

                ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Cliente se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
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
