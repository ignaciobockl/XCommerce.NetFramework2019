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
using XCommerce.Servicio.Core.Reserva;
using XCommerce.Servicio.Core.Reserva.DTOs;

namespace Presentacion.Core.Reserva
{
    public partial class _00037_Reserva : FormularioConsulta
    {
        private readonly IReservaServicio _reservaServicio;
        public _00037_Reserva()
            :this(new ReservaServicio())
        {
            InitializeComponent();
        }

        public _00037_Reserva(IReservaServicio reservaServicio)
        {
            _reservaServicio = reservaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].Width = 100;
            grilla.Columns["Fecha"].HeaderText = @"Fecha de Reserva";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Senia"].Visible = true;
            grilla.Columns["Fecha"].Width = 100;
            grilla.Columns["Senia"].HeaderText = @"Seña";
            grilla.Columns["Senia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstadoReserva"].Visible = true;
            grilla.Columns["EstadoReserva"].Width = 150;
            grilla.Columns["EstadoReserva"].HeaderText = @"Estado de Reserva";
            grilla.Columns["EstadoReserva"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["MesaId.Numero"].Visible = true;
            grilla.Columns["MesaId.Numero"].Width = 100;
            grilla.Columns["MesaId.Numero"].HeaderText = @"Numero de Mesa";
            grilla.Columns["MesaId.Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["ClienteId.ApyNom"].Visible = true;
            grilla.Columns["ClienteId.ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ClienteId.ApyNom"].HeaderText = @"Apellido y Nombre";
            grilla.Columns["ClienteId.ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _reservaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fReservaAbm = new _00038_Reserva_ABM(TipoOperacion.Nuevo);
            fReservaAbm.ShowDialog();

            ActualizarSegunOperacion(fReservaAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((ReservaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fReservaAbm = new _00038_Reserva_ABM(TipoOperacion.Modificar, EntidadId);
                fReservaAbm.ShowDialog();

                ActualizarSegunOperacion(fReservaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Reserva se encuentra Eliminada", 
                    @"Atención", 
                    MessageBoxButtons.OK,
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
