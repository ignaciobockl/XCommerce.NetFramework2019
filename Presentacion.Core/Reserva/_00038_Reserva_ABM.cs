using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Core.Articulo.MotivoBaja;
using Presentacion.Core.Cliente;
using Presentacion.Core.Mesa;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core.Mesa;
using XCommerce.Servicio.Core.Mesa.DTOs;
using XCommerce.Servicio.Core.Reserva;
using XCommerce.Servicio.Core.Reserva.DTOs;
using XCommerce.Servicio.Core.Reserva.MotivoReserva;
using XCommerce.Servicio.Seguridad.Usuario;
using XCommerce.Servicio.Seguridad.Usuario.DTOs;

namespace Presentacion.Core.Reserva
{
    public partial class _00038_Reserva_ABM : FormularioAbm
    {
        private readonly IReservaServicio _reservaServicio;
        private readonly IMesaServicio _mesaServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IMotivoReservaServicio _motivoReserva;

        public _00038_Reserva_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
        :base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _reservaServicio = new ReservaServicio();
            _mesaServicio = new MesaServicio();
            _clienteServicio = new ClienteServicio();
            _usuarioServicio = new UsuarioServicio();
            _motivoReserva = new MotivoReservaServicio();

            if (tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(dtpFecha, "Fecha");
            AgregarControlesObligatorios(nudSeña, "Senia");
            AgregarControlesObligatorios(cmbEstado, "EstadoReserva");
            AgregarControlesObligatorios(cmbMesa, "MesaId");
            AgregarControlesObligatorios(cmbCliente, "ClienteId");
            AgregarControlesObligatorios(cmbUsuario, "UsuarioId");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            nudSeña.Minimum = 0;
            nudSeña.Maximum = 9999999;
            nudSeña.DecimalPlaces = 2;

            var estadoReserva = new List<EstadoReserva>()
            {
                EstadoReserva.Confirmada,
                EstadoReserva.Cancelada,
                EstadoReserva.NoConfirmada
            }.ToList();

            cmbEstado.DataSource = estadoReserva;

            CargarComboBox(cmbMesa, 
                _mesaServicio.Obtener(string.Empty),
                "Descripcion", 
                "Id");

            CargarComboBox(cmbCliente,
                _clienteServicio.Obtener(string.Empty),
                "Descripcion",
                "Id");

            CargarComboBox(cmbMotivo,
                _motivoReserva.Obtener(string.Empty),
                "Descripcion",
                "Id");

            cmbUsuario.SelectedItem = _usuarioServicio.ObtenerPorId(entidadId.Value);

            nudSeña.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            var reserva = _reservaServicio.ObtenerPorId(entidadId.Value);

            dtpFecha.Value = reserva.Fecha;
            nudSeña.Value = reserva.Senia;

            var estadoReserva = new List<EstadoReserva>()
            {
                EstadoReserva.Confirmada,
                EstadoReserva.Cancelada,
                EstadoReserva.NoConfirmada
            }.ToList();

            cmbEstado.DataSource = estadoReserva;

            CargarComboBox(cmbMesa,
                _mesaServicio.Obtener(string.Empty),
                "Descripcion",
                "Id");

            CargarComboBox(cmbCliente,
                _clienteServicio.Obtener(string.Empty),
                "Descripcion",
                "Id");

            CargarComboBox(cmbMotivo,
                _motivoReserva.Obtener(string.Empty),
                "Descripcion",
                "Id");

            cmbUsuario.SelectedItem = _usuarioServicio.ObtenerPorId(entidadId.Value);
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaReserva = new ReservaDto
            {
                Fecha = dtpFecha.Value,
                Senia = nudSeña.Value,
                EstadoReserva = ((EstadoReserva)cmbEstado.SelectedItem),
                MesaId = ((MesaDto)cmbMesa.SelectedItem).Id,
                ClienteId = ((ClienteDto)cmbCliente.SelectedItem).Id,
                MotivoReservaId = ((MotivoReservaDto)cmbMotivo.SelectedItem).Id,
                UsuarioId = ((UsuarioDto)cmbUsuario.SelectedItem).Id
            };

            _reservaServicio.Insertar(nuevaReserva);

            return true;
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var reservaModificar = new ReservaDto()
            {
                Id = EntidadId.Value,
                Fecha = dtpFecha.Value,
                Senia = nudSeña.Value,
                EstadoReserva = ((EstadoReserva)cmbEstado.SelectedItem),
                MesaId = ((MesaDto)cmbMesa.SelectedItem).Id,
                ClienteId = ((ClienteDto)cmbCliente.SelectedItem).Id,
                MotivoReservaId = ((MotivoReservaDto)cmbMotivo.SelectedItem).Id,
                UsuarioId = ((UsuarioDto)cmbUsuario.SelectedItem).Id
            };

            _reservaServicio.Modificar(reservaModificar);

            return true;
        }

        private void BtnMesa_Click(object sender, EventArgs e)
        {
            var fNuevaMesa = new _0029_Mesa_ABM(TipoOperacion.Nuevo);
            fNuevaMesa.ShowDialog();

            if (!fNuevaMesa.RealizoAlgunaOperacion) return;
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            var fNuevoCiente = new _00004_Clientes_ABM(TipoOperacion.Nuevo);
            fNuevoCiente.ShowDialog();

            if (!fNuevoCiente.RealizoAlgunaOperacion) return;
        }

        private void BtnMotivo_Click(object sender, EventArgs e)
        {
            var fNuevoMotivo = new _00018_MotivoBaja_ABM(TipoOperacion.Nuevo);
            fNuevoMotivo.ShowDialog();

            if (!fNuevoMotivo.RealizoAlgunaOperacion) return;
        }
    }
}
