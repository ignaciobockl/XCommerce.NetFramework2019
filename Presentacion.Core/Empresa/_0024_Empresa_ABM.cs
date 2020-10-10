using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;
using Presentacion.Core.Iva;
using XCommerce.Servicio.Core.Empresa;
using XCommerce.Servicio.Core.Empresa.DTOs;
using XCommerce.Servicio.Core.Iva;
using XCommerce.Servicio.Core.Localidad;
using XCommerce.Servicio.Core.Localidad.DTOs;
using XCommerce.Servicio.Core.Provincia;
using XCommerce.Servicio.Core.Provincia.DTOs;
using XCommerce.Servicio.Core.Iva.IvaDTOs;

namespace Presentacion.Core.Empresa
{
    public partial class _0024_Empresa_ABM : FormularioAbm
    {
        private readonly IEmpresaServicio _empresaServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IIvaServicios _ivaServicios;

        public _0024_Empresa_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _empresaServicio = new EmpresaServicio();
            _provinciaServicio = new ProvinciaServicio();
            _localidadServicio = new LocalidadServicio();
            _ivaServicios = new IvaServicios();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtRazonSocial, "Razon Social");
            AgregarControlesObligatorios(txtNombreFantacia, "Nombre de Fantacia");
            AgregarControlesObligatorios(txtCuit, "Cuit");
            AgregarControlesObligatorios(txtSucursal, "Sucursal");
            AgregarControlesObligatorios(txtCalle, "Calle");


            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            CargarComboBox(cmbIVA, _ivaServicios.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                var provincia = (ProvinciaDto)cmbProvincia.Items[0];

                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(provincia.Id, string.Empty), "Descripcion", "Id");
            }

            // Asignando un Evento

            txtRazonSocial.KeyPress += Validacion.NoNumeros;
            txtCuit.KeyPress += Validacion.NoSimbolos;
            txtCuit.KeyPress += Validacion.NoLetras;
            txtTelefono.KeyPress += Validacion.NoSimbolos;
            txtTelefono.KeyPress += Validacion.NoLetras;
            txtCalle.KeyPress += Validacion.NoSimbolos;
            txtBarrio.KeyPress += Validacion.NoSimbolos;
            imgFotoEmpresa.Image = Constantes.Imagen.Usuario;

            

            txtRazonSocial.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOperacion.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

            var empresa = _empresaServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales

            txtRazonSocial.Text = empresa.RazonSocial;
            txtNombreFantacia.Text = empresa.NombreFantasia;
            txtTelefono.Text = empresa.Telefono;
            txtSucursal.Text = empresa.Sucursal;
            txtCuit.Text = empresa.Cuit;
            txtMail.Text = empresa.Email;
            imgFotoEmpresa.Image = ImagenDb.Convertir_Bytes_Imagen(empresa.Logo);

            // Datos Direccion
            txtCalle.Text = empresa.Calle;
            txtNumero.Text = empresa.Numero.ToString();
            txtPiso.Text = empresa.Piso;
            txtDepartamento.Text = empresa.Dpto;
            txtBarrio.Text = empresa.Barrio;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            cmbProvincia.SelectedItem = empresa.ProvinciaId;

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(empresa.ProvinciaId, string.Empty), "Descripcion", "Id");
            }

            CargarComboBox(cmbIVA, _ivaServicios.Obtener(string.Empty), "Descripcion", "Id");

            cmbIVA.SelectedItem = empresa.CondicionIvaId;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaEmpresa = new EmpresaDto
            {
                
                RazonSocial = txtRazonSocial.Text,
                NombreFantasia = txtNombreFantacia.Text,
                Telefono = txtTelefono.Text,
                Cuit = txtCuit.Text,
                Email = txtMail.Text,
                Sucursal = txtSucursal.Text,
                CondicionIvaId = ((IvaDto)cmbIVA.SelectedItem).Id,                
                Logo = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpresa.Image),              
               
                Calle = txtCalle.Text,
                Numero = int.TryParse(txtNumero.Text, out var numero) ? numero : 0,
                Dpto = txtDepartamento.Text,
                Piso = txtPiso.Text,
                Barrio = txtBarrio.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,

            };

            _empresaServicio.Insertar(nuevaEmpresa);

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

            var empresaParaModificar = new EmpresaDto
            {
                Id = EntidadId.Value,
                RazonSocial = txtRazonSocial.Text,
                NombreFantasia = txtNombreFantacia.Text,
                Telefono = txtTelefono.Text,
                Cuit = txtCuit.Text,
                Email = txtMail.Text,
                Sucursal = txtSucursal.Text,
                Logo = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpresa.Image),
                CondicionIvaId = ((IvaDto)cmbIVA.SelectedItem).Id,

                Calle = txtCalle.Text,
                Numero = int.TryParse(txtNumero.Text, out var numero) ? numero : 0,
                Dpto = txtDepartamento.Text,
                Piso = txtPiso.Text,
                Barrio = txtBarrio.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
            };

            _empresaServicio.Modificar(empresaParaModificar);

            return true;
        }

        public override void EjecutarComando()
        {
            base.EjecutarComando();
        }

        private void cmbProvincia_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion",
                    "Id");
            }
        }   

        private void BtnIva_Click(object sender, EventArgs e)
        {
            var fNuevoIva = new _0022_Iva_ABM(TipoOperacion.Nuevo);

            fNuevoIva.ShowDialog();

            CargarComboBox(cmbIVA, _ivaServicios.Obtener(string.Empty), "Descripcion", "Id");
        }

        private void BtnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                // Pregunta si Selecciono un Archivo
                if (!string.IsNullOrEmpty(archivo.FileName))
                {
                    imgFotoEmpresa.Image = Image.FromFile(archivo.FileName);
                }
                else
                {
                    imgFotoEmpresa.Image = Constantes.Imagen.Usuario;
                }
            }
            else
            {
                imgFotoEmpresa.Image = Constantes.Imagen.Usuario;
            }
        }

        private void BtnNuevaLocalidad_Click(object sender, EventArgs e)
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

        private void BtnNuevaProvincia_Click(object sender, EventArgs e)
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
    }
}

