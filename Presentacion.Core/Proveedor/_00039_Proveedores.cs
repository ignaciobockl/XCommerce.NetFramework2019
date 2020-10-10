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
using XCommerce.Servicio.Core.Proveedor;
using XCommerce.Servicio.Core.Proveedor.DTOs;

namespace Presentacion.Core.Proveedores
{
    public partial class _00039_Proveedores : FormularioConsulta
    {
        private readonly IProveedorServicio _proveedorServicio;
        public _00039_Proveedores()
        :this(new ProveedorServicio())
        {
            InitializeComponent();
        }

        public _00039_Proveedores(IProveedorServicio proveedorServicio)
        {
            _proveedorServicio = proveedorServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["RazonSocial"].Visible = true;
            grilla.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["RazonSocial"].HeaderText = @"Razon Social";
            grilla.Columns["RazonSocial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Telefono"].Visible = true;
            grilla.Columns["Telefono"].Width = 100;
            grilla.Columns["Telefono"].HeaderText = @"Telefono";
            grilla.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Email"].Visible = true;
            grilla.Columns["Email"].Width = 150;
            grilla.Columns["Email"].HeaderText = @"Email";
            grilla.Columns["Email"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["CondicionIvaId.Descripcion"].Visible = true;
            grilla.Columns["CondicionIvaId.Descripcion"].Width = 100;
            grilla.Columns["CondicionIvaId.Descripcion"].HeaderText = @"Apellido y Nombre";
            grilla.Columns["CondicionIvaId.Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _proveedorServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fProveedorAbm = new _00040_Proveedores_ABM(TipoOperacion.Nuevo);
            fProveedorAbm.ShowDialog();

            ActualizarSegunOperacion(fProveedorAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((ProveedorDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fProveedorAbm = new _00040_Proveedores_ABM(TipoOperacion.Modificar, EntidadId);
                fProveedorAbm.ShowDialog();

                ActualizarSegunOperacion(fProveedorAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Proveedor se encuentra Eliminado",
                    @"Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
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
