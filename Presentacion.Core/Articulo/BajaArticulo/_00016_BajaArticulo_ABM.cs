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
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using XCommerce.Servicio.Core.Articulo.BajaArticulo;
using XCommerce.Servicio.Core.Articulo.BajaArticulo.DTOs;
using XCommerce.Servicio.Core.Articulo.DTOs;
using XCommerce.Servicio.Core.Articulo.MotivoBaja;
using XCommerce.Servicio.Core.Articulo.MotivoBaja.DTOs;

namespace Presentacion.Core.Articulo.BajaArticulo
{
    public partial class _00016_BajaArticulo_ABM : FormularioAbm
    {
        private readonly IBajaArticuloServicio _bajaArticuloServicio;
        private readonly IMotivoBajaServicio _motivoBajaServicio;
        private int _articuloId;
        public _00016_BajaArticulo_ABM(TipoOperacion tipoOperacion,
            long? entidadId = null)
        : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _bajaArticuloServicio = new BajaArticuloServicio();
            _motivoBajaServicio = new MotivoBajaServicio();

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(nudCantidad, "Cantidad");
            AgregarControlesObligatorios(cmbMotivoBaja, "Motivo Baja");
            AgregarControlesObligatorios(txtArticulo, "Articulo");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {           

            if (entidadId.HasValue) return;

            CargarComboBox(cmbMotivoBaja, _motivoBajaServicio.Obtener(string.Empty), "Descripcion", "Id");

            // Asignando un Evento
            txtObservacion.KeyPress += Validacion.NoSimbolos;

            txtObservacion.Focus();
        }
               
        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", 
                    @"Atención", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaBajaArticulo = new BajaArticuloDto
            {
                Fecha = dtpFecha.Value,
                Observacion = txtObservacion.Text,
                Cantidad = nudCantidad.Value,
                MotivoBajaId = ((MotivoBajaDto)cmbMotivoBaja.SelectedItem).Id,
                ArticuloId =  _articuloId
            };

            _bajaArticuloServicio.Insertar(nuevaBajaArticulo);

            return true;
        }

        private void BtnMotivoBaja_Click(object sender, EventArgs e)
        {
            var fNuevoMotivoBaja = new _00018_MotivoBaja_ABM(TipoOperacion.Nuevo);
            fNuevoMotivoBaja.ShowDialog();

            if (!fNuevoMotivoBaja.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbMotivoBaja, _motivoBajaServicio
                .Obtener(string.Empty), "Descripcion", "Id");
            
        }



        private void BtnAgregarArticulo_Click(object sender, EventArgs e)
        {
            var fNuevaArticulos = new _00048_LookUp_Articulos();

            fNuevaArticulos.ShowDialog();

            var articuloLookUp = new ArticuloDto();

            articuloLookUp = (ArticuloDto)fNuevaArticulos.ObjetoLookUp;

            if (articuloLookUp != null)
            {
                txtArticulo.Text = articuloLookUp.Descripcion;
                _articuloId = (int)articuloLookUp.Id;
            }
        }



        
}
}
