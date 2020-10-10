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
using XCommerce.Servicio.Core.Articulo.MotivoBaja;
using XCommerce.Servicio.Core.Articulo.MotivoBaja.DTOs;

namespace Presentacion.Core.Articulo.MotivoBaja
{
    public partial class _00018_MotivoBaja_ABM : FormularioAbm
    {
        private readonly IMotivoBajaServicio _motivoBajaServicio;

        public _00018_MotivoBaja_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _motivoBajaServicio = new MotivoBajaServicio();

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion, "Descripción");

            Inicializador(entidadId);

        }
    

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            

            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            txtDescripcion.Focus();
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevoMotivoBaja = new MotivoBajaDto
            {
                Descripcion = txtDescripcion.Text,
            };

            _motivoBajaServicio.Insertar(nuevoMotivoBaja);

            return true;
        }
    }
}
