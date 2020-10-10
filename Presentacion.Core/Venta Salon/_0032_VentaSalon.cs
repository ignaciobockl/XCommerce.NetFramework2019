using Presentacion.Core.Mesa.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Comprobante;
using XCommerce.Servicio.Core.Mesa;
using XCommerce.Servicio.Core.Salon;

namespace Presentacion.Core.Venta_Salon
{
    public partial class _0032_VentaSalon : FormularioBase.FormularioBase
    {
        private readonly ISalonServicio _salonServicio;
        private readonly IMesaServicio _mesaServicios;
        private readonly IComprobanteSalonServicio _comprobanteSalonServicio;

        public _0032_VentaSalon()
        {
            InitializeComponent();

            _salonServicio = new SalonServicio();
            _mesaServicios = new MesaServicio();
            _comprobanteSalonServicio = new ComprobanteSalonServicio();

            btnSalir.Image = Constantes.Imagen.BotonSalir;
        }

        private void CrearControles()
        {
            var contenedorPagina = new TabControl();            
            var contadorTabIndex = 0;

            foreach (var salon in _salonServicio.Obtener(string.Empty).Where(x => !x.EstaEliminado))
            {

                var ListaDeMesas = _mesaServicios.ObtenerPorSalon(salon.Id, string.Empty);

                var flowPanel = new FlowLayoutPanel
                {
                    Name = $"flowPanel{salon.Id}",
                    Dock = DockStyle.Fill,
                    BackColor = Color.AliceBlue
                };

                foreach (var mesa in ListaDeMesas.Where(x => !x.EstaEliminado))
                {
                    var controlMesa = new MesaControl
                    {
                        MesaId = mesa.Id,
                        NumeroMesa = mesa.Numero,
                        Estado = mesa.estadoMesa,
                        PrecioConsumido = 0                  
                    };                    

                    flowPanel.Controls.Add(controlMesa);
                }

                var pagina = new TabPage
                {
                    Location = new Point(4, 22),
                    Name = $"Pagina{salon.Id}",
                    Padding = new Padding(3),
                    Size = new Size(854, 357),
                    TabIndex = contadorTabIndex,
                    Text = $"{salon.Descripcion}",
                    UseVisualStyleBackColor = true
                };

                pagina.Controls.Add(flowPanel);

                contenedorPagina.Controls.Add(pagina);

                contadorTabIndex++;
            }

            contenedorPagina.Dock = DockStyle.Fill;
            contenedorPagina.Location = new Point(0, 66);
            contenedorPagina.Name = "Contenedor";
            contenedorPagina.SelectedIndex = 0;
            contenedorPagina.Size = new Size(862, 383);
            contenedorPagina.TabIndex = 9;
            contenedorPagina.ResumeLayout(false);
            this.Controls.Add(contenedorPagina);
            this.Controls.SetChildIndex(contenedorPagina, 0);
            contenedorPagina.ResumeLayout(false);

        }

        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _0032_VentaSalon_Load(object sender, EventArgs e)
        {
            CrearControles();
        }
    }
}
