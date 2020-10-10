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
using XCommerce.Servicio.Core.ListaPrecio;
using XCommerce.Servicio.Core.ListaPrecio.DTOs;

namespace Presentacion.Core.ListaPrecio
{
    public partial class _00036_ListaPrecios_ABM : FormularioAbm
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;

        long? EntidadIdLocal;
        public _00036_ListaPrecios_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
         :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            EntidadIdLocal = entidadId;

            _listaPrecioServicio = new ListaPrecioServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
            AgregarControlesObligatorios(nudRetabilidad, "Rentabilidad");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            nudRetabilidad.Minimum = 0;
            nudRetabilidad.Maximum = 100;

            txtDescripcion.Focus();

            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            nudRetabilidad.KeyPress += Validacion.NoSimbolos;
        }

        public override void CargarDatos(long? entidadId)
        {

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

            var listaPrecio = _listaPrecioServicio.ObtenerPorId(EntidadIdLocal.Value);

            txtDescripcion.Text = listaPrecio.Descripcion;
            nudRetabilidad.Value = listaPrecio.Rentabilidad;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaListaPrecio = new ListaPrecioDto
            {
                Descripcion = txtDescripcion.Text,
                Rentabilidad = nudRetabilidad.Value
            };

            _listaPrecioServicio.Insertar(nuevaListaPrecio);

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

            var listaPrecioModificar = new ListaPrecioDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                Rentabilidad = nudRetabilidad.Value,
                EstaEliminado = false
            };

            _listaPrecioServicio.Modificar(listaPrecioModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _listaPrecioServicio.Eliminar(EntidadId.Value);

            return true;
        }
    }
}
