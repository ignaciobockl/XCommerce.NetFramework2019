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
using XCommerce.Servicio.Core.Iva;
using XCommerce.Servicio.Core.Iva.IvaDTOs;
using XCommerce.Servicio.Core.Proveedor;
using XCommerce.Servicio.Core.Proveedor.DTOs;

namespace Presentacion.Core.Proveedores
{
    public partial class _00040_Proveedores_ABM : FormularioAbm
    {
        private readonly IProveedorServicio _proveedorServicio;
        private readonly IIvaServicios _ivaServicios;
        public _00040_Proveedores_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
        :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            _proveedorServicio = new ProveedorServicio();
            _ivaServicios = new IvaServicios();

            if (tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtRazonSocil,"RazonSocial");
            AgregarControlesObligatorios(txtTelefono,"Telefono");
            AgregarControlesObligatorios(txtEmail,"Email");
            AgregarControlesObligatorios(cmbCondicionIva,"CondicioIva");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbCondicionIva,
                _ivaServicios.Obtener(string.Empty),
                "Descripcion",
                "Id");

            txtRazonSocil.KeyPress += Validacion.NoSimbolos;

            txtTelefono.KeyPress += Validacion.NoLetras;
            txtTelefono.KeyPress += Validacion.NoSimbolos;

            txtContacto.KeyPress += Validacion.NoSimbolos;

            txtRazonSocil.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", 
                    @"Error Grave", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Stop);

                this.Close();
            }

            var proveedor = _proveedorServicio.ObtenerPorId(entidadId.Value);

            txtRazonSocil.Text = proveedor.RazonSocial;
            txtTelefono.Text = proveedor.Telefono;
            txtEmail.Text = proveedor.Email;
            txtContacto.Text = proveedor.Contacto;

            CargarComboBox(cmbCondicionIva,
                _ivaServicios.Obtener(string.Empty),
                "Descripcion",
                "Id");

            cmbCondicionIva.SelectedItem = proveedor.CondicionIvaId;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevoProveedor = new ProveedorDto
            {
                RazonSocial = txtRazonSocil.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Contacto = txtContacto.Text,
                CondicionIvaId = ((IvaDto) cmbCondicionIva.SelectedItem).Id
            };

            _proveedorServicio.Insertar(nuevoProveedor);

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

            var proveedorModificar = new ProveedorDto
            {
                Id = EntidadId.Value,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,
                Contacto = txtContacto.Text,
                EstaEliminado = false,
                CondicionIvaId = ((IvaDto)cmbCondicionIva.SelectedItem).Id
            };

            _proveedorServicio.Modificar(proveedorModificar);

            return true;
        }
    }
}
