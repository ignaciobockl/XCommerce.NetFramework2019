using Presentacion.Core.Venta_Salon;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Comprobante;
using XCommerce.Servicio.Core.Mesa;

namespace Presentacion.Core.Mesa.Control
{
    public partial class MesaControl : UserControl
    {
        private int _numeroMesa;
        private long _mesaId;
        private bool _esRedonda;
        

        public bool _EsRedonda
        {
            set => _esRedonda = value;
        }

        public long MesaId
        {
            set => _mesaId = value;
        }

        public int NumeroMesa
        {
            set
            {
                _numeroMesa = value;

                lblNumeroMesa.Text = value.ToString();
            }
        }

        public decimal PrecioConsumido
        {
            set => lblPrecio.Text = value.ToString("C");            
        }

        private EstadoMesa _estadoMesa;

        public EstadoMesa Estado
        {
            set
            {
                MenuAbrirMesa.Visible = false;
                MenuCerrarMesa.Visible = false;

                _estadoMesa = value;

                switch (value)
                {
                    case EstadoMesa.Abierta:
                        this.BackColor = Color.Green;
                        MenuCerrarMesa.Visible = true;
                        break;

                    case EstadoMesa.Cerrada:
                        this.BackColor = Color.Red;
                        MenuAbrirMesa.Visible = true;
                        break;

                    case EstadoMesa.FueraServicio:
                        this.BackColor = Color.Blue;
                        break;

                    case EstadoMesa.Reservada:
                        this.BackColor = Color.Yellow;
                        MenuAbrirMesa.Visible = true;
                        break;

                    default:
                        this.BackColor = Color.White;
                        break;
                }
            }
        }

        private readonly IComprobanteSalonServicio _comprobanteSalonServicio;
        private readonly IMesaServicio _mesaServicio;


        public MesaControl()
            : this(new ComprobanteSalonServicio(), new MesaServicio())
        {
            InitializeComponent();
            
            RedondearControl();           

            
        }

        public MesaControl(IComprobanteSalonServicio comprobanteSalonServicio, IMesaServicio mesaServicio)
        {
            _comprobanteSalonServicio = comprobanteSalonServicio;

            _mesaServicio = mesaServicio;
        }

        

        private void LblNumeroMesa_DoubleClick(object sender, EventArgs e)
        {
            if (_estadoMesa != EstadoMesa.Abierta) return;

            var comprobante = _comprobanteSalonServicio.ObtenerPorId(_mesaId);

            lblPrecio.Text = comprobante.Total.ToString("C");

            var fComprobanteVenta = new _0030_ComprobanteMesa(_mesaId, _numeroMesa);
            fComprobanteVenta.ShowDialog();
        }

        private void RedondearControl()
        {
            var gp = new GraphicsPath();
            gp.AddEllipse(0, 0, this.Width - 3, this.Height - 3);
            var rg = new Region(gp);
            this.Region = rg;
        }


        private void MenuAbrirMesa_Click(object sender, EventArgs e)
        {
            if (_estadoMesa == EstadoMesa.Abierta) return;

            _comprobanteSalonServicio.Generar(_mesaId, 1, 1);

            var comprobante = _comprobanteSalonServicio.ObtenerPorId(_mesaId);

            Estado = EstadoMesa.Abierta;
            
            lblPrecio.Text = comprobante.Total.ToString("C");            

            var fComprobanteVenta = new _0030_ComprobanteMesa(_mesaId, _numeroMesa);
            fComprobanteVenta.ShowDialog();
        }

        private void MenuCerrarMesa_Click_1(object sender, EventArgs e)
        {
            if (_estadoMesa == EstadoMesa.Cerrada) return;


            var mesaComprobante = _comprobanteSalonServicio.ObtenerPorId(_mesaId);


            var fFacturacionMesa = new _0031_FacturacionMesa(_mesaId, _numeroMesa, _estadoMesa, mesaComprobante.ComprobanteId);
            fFacturacionMesa.ShowDialog();


            Estado = _mesaServicio.ObtenerPorId(_mesaId).estadoMesa;
        }
    }
}
