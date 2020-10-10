using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System.Windows.Forms;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core.Empleado;
using XCommerce.Servicio.Core.Localidad;
using XCommerce.Servicio.Core.Localidad.DTOs;
using XCommerce.Servicio.Core.Provincia;
using XCommerce.Servicio.Core.Provincia.DTOs;

namespace Presentacion.Core.Cliente
{
    public partial class _00004_Clientes_ABM : FormularioAbm
    {
        private readonly IClienteServicio _clienteServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IEmpleadoServicio _empleadoServicio;

        public _00004_Clientes_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
              : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _clienteServicio = new ClienteServicio();
            _provinciaServicio = new ProvinciaServicio();
            _localidadServicio = new LocalidadServicio();
            _empleadoServicio = new EmpleadoServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtApellido, "Apellido");
            AgregarControlesObligatorios(txtNombre, "Nombre");
            AgregarControlesObligatorios(txtDni, "DNI");
            AgregarControlesObligatorios(txtCelular, "Celular");
            AgregarControlesObligatorios(txtCalle, "Calle");            
            AgregarControlesObligatorios(txtNumero, "Numero");

            nudCuentaCorriente.Minimum = 0;
            nudCuentaCorriente.Maximum = 9999999;
            

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.ObtenerParaCmb(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                var provincia = (ProvinciaDto)cmbProvincia.Items[0];

                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(provincia.Id, string.Empty), "Descripcion", "Id");
            }

            
            txtApellido.KeyPress += Validacion.NoNumeros;
            txtApellido.KeyPress += Validacion.NoSimbolos;
            txtNombre.KeyPress += Validacion.NoNumeros;
            txtNombre.KeyPress += Validacion.NoSimbolos;
            txtDni.KeyPress += Validacion.NoLetras;
            txtDni.KeyPress += Validacion.NoSimbolos;
            txtCuil.KeyPress += Validacion.NoLetras;
            txtCuil.KeyPress += Validacion.NoSimbolos;
            txtTelefono.KeyPress += Validacion.NoLetras;
            txtTelefono.KeyPress += Validacion.NoSimbolos;
            txtCelular.KeyPress += Validacion.NoLetras;
            txtCelular.KeyPress += Validacion.NoSimbolos;
            txtCalle.KeyPress += Validacion.NoNumeros;
            txtCalle.KeyPress += Validacion.NoSimbolos;
            txtNumero.KeyPress += Validacion.NoLetras;
            txtNumero.KeyPress += Validacion.NoSimbolos;
            txtPiso.KeyPress += Validacion.NoLetras;
            txtPiso.KeyPress += Validacion.NoSimbolos;
            txtDepartamento.KeyPress += Validacion.NoSimbolos;
            txtManzana.KeyPress += Validacion.NoSimbolos;
            txtLote.KeyPress += Validacion.NoSimbolos;
            txtCasa.KeyPress += Validacion.NoSimbolos;
            nudCuentaCorriente.KeyPress += Validacion.NoSimbolos;

            lblCuentacorriente.Enabled = false;
            nudCuentaCorriente.Enabled = false;

            CheckCuentaCorriente.Checked = false;

            txtApellido.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {

            nudCuentaCorriente.Minimum = 0;
            nudCuentaCorriente.Maximum = 9999999;

            long? id = entidadId;

            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOperacion.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }


            var Cliente = _clienteServicio.ObtenerPorId(entidadId.Value);

            txtApellido.Text = Cliente.Apellido;
            txtNombre.Text = Cliente.Nombre;
            txtDni.Text = Cliente.Dni;
            txtTelefono.Text = Cliente.Telefono;
            txtCelular.Text = Cliente.Celular;
            txtEmail.Text = Cliente.Email;
            txtCuil.Text = Cliente.Cuil;
            dtpFechaNacimiento.Value = Cliente.FechaNacimiento;
            CheckCuentaCorriente.Checked = Cliente.PoseeCuentaCorriente;
            nudCuentaCorriente.Value = Cliente.MontoMaximoCtaCte;

            txtCalle.Text = Cliente.Calle;
            txtNumero.Text = Cliente.Numero.ToString();
            txtPiso.Text = Cliente.Piso;
            txtDepartamento.Text = Cliente.Departamento;
            txtCasa.Text = Cliente.Casa;
            txtLote.Text = Cliente.Lote;
            txtManzana.Text = Cliente.Manzana;
            txtBarrio.Text = Cliente.Barrio;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            cmbProvincia.SelectedValue = Cliente.ProvinciaId;

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(Cliente.ProvinciaId, string.Empty), "Descripcion", "Id");
            }
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevoCliente = new ClienteDto
            {
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Barrio = txtBarrio.Text,
                Calle = txtCalle.Text,
                Casa = txtCasa.Text,
                Celular = txtCelular.Text,
                Cuil = txtCuil.Text,
                Dni = txtDni.Text,
                Departamento = txtDepartamento.Text,
                Email = txtEmail.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                PoseeCuentaCorriente = CheckCuentaCorriente.Checked,
                MontoMaximoCtaCte = nudCuentaCorriente.Value,
                MontoDeudaCtaCte = 0,
                Lote = txtLote.Text,
                Manzana = txtManzana.Text,
                Numero = int.TryParse(txtNumero.Text, out var numero) ? numero : 0,
                Piso = txtPiso.Text,
                Telefono = txtTelefono.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                EstaEliminado = false,
            };

            var dniEmpleado = _empleadoServicio.ObtenerPorDni(txtDni.Text);
            var dni = _clienteServicio.ObtenerPorDni(txtDni.Text);

            if (dni == null && dniEmpleado == null)
            {
                _clienteServicio.Insertar(nuevoCliente);
                return true;
            }
            else
            {
                MessageBox.Show("El Dni ingresados ya existe.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var clienteParaModificar = new ClienteDto
            {
                Id = EntidadId.Value,
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Barrio = txtBarrio.Text,
                Calle = txtCalle.Text,
                Casa = txtCasa.Text,
                Celular = txtCelular.Text,
                Cuil = txtCuil.Text,
                Dni = txtDni.Text,
                Departamento = txtDepartamento.Text,
                Email = txtEmail.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                PoseeCuentaCorriente = CheckCuentaCorriente.Checked,
                MontoMaximoCtaCte = nudCuentaCorriente.Value,
                Lote = txtLote.Text,
                Manzana = txtManzana.Text,
                Numero = int.TryParse(txtNumero.Text, out var numero) ? numero : 0,
                Piso = txtPiso.Text,
                Telefono = txtTelefono.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                EstaEliminado = false,
            };

            var dniEmpleado = _empleadoServicio.ObtenerPorDniParaModificar(txtDni.Text, (long)EntidadId);
            var dni = _clienteServicio.ObtenerPorDniParaModificar(txtDni.Text, (long)EntidadId);

            if (dni == null && dniEmpleado == null)
            {
                _clienteServicio.Modificar(clienteParaModificar);
                return true;
            }
            else
            {
                MessageBox.Show("El Dni ingresados ya existe.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _clienteServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void CheckCuentaCorriente_CheckedChanged(object sender, System.EventArgs e)
        {
            if (CheckCuentaCorriente.Checked == true)
            {
                lblCuentacorriente.Enabled = true;
                nudCuentaCorriente.Enabled = true;
            }
            else
            {
                lblCuentacorriente.Enabled = false;
                nudCuentaCorriente.Enabled = false;
                nudCuentaCorriente.Value = 0;
            }
        }

        private void BtnNuevaProvincia_Click_1(object sender, System.EventArgs e)
        {
            var fNuevaProvincia = new _00006_Provincia_ABM(TipoOperacion.Nuevo);
            fNuevaProvincia.ShowDialog();

            if (!fNuevaProvincia.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }

        private void BtnLocalidad_Click_1(object sender, System.EventArgs e)
        {
            var fNuevaLocalidad = new _00008_Localidad_ABM(TipoOperacion.Nuevo);
            fNuevaLocalidad.ShowDialog();

            if (!fNuevaLocalidad.RealizoAlgunaOperacion) return;

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }
    }
}
