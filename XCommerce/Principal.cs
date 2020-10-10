using Presentacion.Core.Empleado;
using System.Windows.Forms;
using Presentacion.Core.Articulo;
using Presentacion.Core.Caja;
using Presentacion.Core.Cliente;
using Presentacion.Core.Iva;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using Presentacion.Helpers;
using Presentacion.Seguridad.Usuario;
using Presentacion.Core.Rubro;
using Presentacion.Core.Marca;
using Presentacion.Core.Mesa;
using Presentacion.Core.Salon;
using Presentacion.Core.Venta_Salon;
using Presentacion.Core.ListaPrecio;
using Presentacion.Core.Precio;
using static Presentacion.Helpers.DatosConstantes;
using Presentacion.Core.Articulo.BajaArticulo;
using Presentacion.Core.Movimiento;
using Presentacion.Core.Kiosko;
using Presentacion.Seguridad;
using XCommerce.Servicio.Core.Cliente;
using System;
using System.Linq;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core.ListaPrecio;
using XCommerce.Servicio.Core.Localidad;
using XCommerce.Servicio.Core.Localidad.DTOs;
using XCommerce.Servicio.Core.Provincia;
using XCommerce.Servicio.Core.Provincia.DTOs;
using XCommerce.Servicio.Core.ListaPrecio.DTOs;

namespace XCommerce
{
    public partial class Principal : Form
    {
        private readonly IClienteServicio _clienteServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        public Principal()
        {
            InitializeComponent();

            verificarUsuario();

            _clienteServicio = new ClienteServicio();
            _provinciaServicio = new ProvinciaServicio();
            _localidadServicio = new LocalidadServicio();
            _listaPrecioServicio = new ListaPrecioServicio();

            //ConsumidorFinal();
        }

        private void ConsumidorFinal()
        {
            var clientedni = _clienteServicio.ObtenerPorDni("99999999");
            var provinciaDescripcion = _provinciaServicio.Obtener("Tucuman");
            var localidadDescripcion = _localidadServicio.Obtener("San Miguel de Tucuman");
            var provinciaId = 1;
            var localidadId = 1;

            if (clientedni == null)
            {
                if (provinciaDescripcion == null)
                {
                    var provincia = new ProvinciaDto();

                    provincia.Id = 1;
                    provincia.Descripcion = "Tucuman";

                    _provinciaServicio.Insertar(provincia);
                }

                if (localidadDescripcion == null)
                {
                    var localidad = new LocalidadDto();

                    localidad.Id = 1;
                    localidad.Descripcion = "San Miguel de Tucuman";
                    localidad.ProvinciaId = provinciaId;

                    _localidadServicio.Insertar(localidad);
                }

                var cliente = new ClienteDto();

                cliente.Apellido = "Final";
                cliente.Nombre = "Consumidor";
                cliente.Dni = "99999999";
                cliente.Cuil = "99999999";
                cliente.Email = "99@gmail.com";
                cliente.FechaNacimiento = DateTime.Now;
                cliente.Calle = "sin nombre";
                cliente.Numero = 99;
                cliente.Barrio = "sin nombre";
                cliente.ProvinciaId = 1;
                cliente.LocalidadId = 1;

                _clienteServicio.Insertar(cliente);
            }
        }

        private void consultaDeEmpleadosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fEmpleados = new _00001_Empleados();
            fEmpleados.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fProvincia = new _00005_Provincia();
            fProvincia.ShowDialog();
        }

        private void nuevaProvinciaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevaProvincia = new _00006_Provincia_ABM(TipoOperacion.Nuevo);
            fNuevaProvincia.ShowDialog();
        }

        private void consultaToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            var fLocalidad = new _00007_Localidad();
            fLocalidad.ShowDialog();
        }

        private void nuevaLocalidadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevaLocalidad = new _00008_Localidad_ABM(TipoOperacion.Nuevo);
            fNuevaLocalidad.ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevoEmpleado = new _00002_ABM_Empleados(TipoOperacion.Nuevo);
            fNuevoEmpleado.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fUsuarios = new _00009_Usuarios();

            fUsuarios.ShowDialog();
        }

        private void consultaClienteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fCliente = new _00003_Clientes();

            fCliente.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevoCliente = new _00004_Clientes_ABM(TipoOperacion.Nuevo);
            fNuevoCliente.ShowDialog();

        }

        private void AbmToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevoRubro = new _00012_Rubro_ABM(TipoOperacion.Nuevo);
            fNuevoRubro.ShowDialog();
        }

        private void ListadoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fRubro = new _00011_Rubro();
            fRubro.ShowDialog();
        }

        private void ConsultaMarcasToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fMarca = new _00013_Marca();
            fMarca.ShowDialog();
        }

        private void NuevaMarcaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fnuevaMarca = new _00014_Marca_ABM(TipoOperacion.Nuevo);
            fnuevaMarca.ShowDialog();
        }

        private void ConsultaToolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            var fSalon = new _0019_Salon();
            fSalon.ShowDialog();
        }

        private void NuevoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevoSalon = new _0020_Salon_ABM(TipoOperacion.Nuevo);
            fNuevoSalon.ShowDialog();
        }

        private void ConsultaToolStripMenuItem3_Click(object sender, System.EventArgs e)
        {
            var fMesa = new _0028_Mesa();
            fMesa.ShowDialog();
        }

        private void NuevaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevaMesa = new _0029_Mesa_ABM(TipoOperacion.Nuevo);
            fNuevaMesa.ShowDialog();
        }

        private void AbrirToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fAbrirCaja = new _0044_AbrirCaja();
            fAbrirCaja.ShowDialog();
        }

        private void CerrarToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fCerrarCaja = new _0045_CerrarCaja();

            if (!EstadoCaja)
            {
                MessageBox.Show("La caja se encuentra cerrada");
            }
            else
            {
                fCerrarCaja.ShowDialog();
            }
            
        }

        private void ConsultaToolStripMenuItem4_Click(object sender, System.EventArgs e)
        {
            var fIva = new _0021_Iva();
            fIva.ShowDialog();
        }

        private void NuevoToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            var fNuevoIva = new _0022_Iva_ABM(TipoOperacion.Nuevo);
            fNuevoIva.ShowDialog();
        }

        private void ConsultaToolStripMenuItem5_Click(object sender, System.EventArgs e)
        {
            var fArticulo = new _00033_Articulo();
            fArticulo.ShowDialog();
        }

        private void NuevoToolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            var fNuevoArticulo = new _00034_Articulo_ABM(TipoOperacion.Nuevo);
            fNuevoArticulo.ShowDialog();
        }

        private void VentaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fVentaSalon = new _0032_VentaSalon();

            if (EstadoCaja)
            {
                fVentaSalon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor abra una caja");
            }
        }

        private void ConsultaToolStripMenuItem6_Click(object sender, System.EventArgs e)
        {
            var fListaPrecios = new _00035_ListaPrecios();
            fListaPrecios.ShowDialog();
        }

        private void NuevaToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            var fNuevaListaPrecios = new _00036_ListaPrecios_ABM(TipoOperacion.Nuevo);
            fNuevaListaPrecios.ShowDialog();
        }

        private void AgregarPrecioToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fPrecio = new _00026_Precio_ABM(TipoOperacion.Nuevo);
            fPrecio.ShowDialog();
        }


        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EstadoCaja)
            {
                MessageBox.Show("Cierre la Caja.");

                e.Cancel = true;
              
                return;

            }
        }

        private void PagarCuentaCorrienteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fPagarCuentaCorriente = new _00046_PagarCuentaCorriente();

            fPagarCuentaCorriente.ShowDialog();
        }

        private void ConsultaToolStripMenuItem7_Click(object sender, System.EventArgs e)
        {
            var fBajaArticulo = new _00015_BajaArticulo();
            fBajaArticulo.ShowDialog();
        }

        private void NuevaToolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            var fNuevaBaja = new _00016_BajaArticulo_ABM(TipoOperacion.Nuevo);
            fNuevaBaja.ShowDialog();
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            if (EstadoCaja == false)
            {
                DialogResult result = MessageBox.Show("La Caja debe esta Abierta para ingresar al Kiosko." +
                                                       " ¿Desea Abrir la Caja?",
                    "Informacion",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var fAbriCaja = new _0044_AbrirCaja();

                    fAbriCaja.ShowDialog();

                    if (EstadoCaja)
                    {
                        var listaPrecio = _listaPrecioServicio.Obtener("Lista Kiosko");

                        if (listaPrecio.Count() == 0)
                        {
                            DialogResult result2 = MessageBox.Show("No existe la Lista de Precio para el Kiosko. ¿Desea Crearla?",
                                "Informacion",
                                MessageBoxButtons.YesNoCancel);

                            if (result2 == DialogResult.Yes)
                            {
                                var listaParaKiosko = new ListaPrecioDto();

                                listaParaKiosko.Id = _listaPrecioServicio.UltimaListaId();
                                listaParaKiosko.Descripcion = "Lista Kiosko";
                                listaParaKiosko.Rentabilidad = 10;

                                _listaPrecioServicio.Insertar(listaParaKiosko);


                                MessageBox.Show(
                                    "La Rentabilidad del Kiosko es 10% por defecto. ¿Desea Modificarla?",
                                    "Informacion",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                var fKiosko = new _00049_Kiosko();
                                fKiosko.ShowDialog();
                            }
                            else if (result2 == DialogResult.No)
                            {
                                MessageBox.Show("No puede iniciar el Kiosko si no hay una Lista de Precios Correspondiente.",
                                    "Informacion",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else
                        {
                            var fKiosko = new _00049_Kiosko();

                            fKiosko.ShowDialog();
                        }
                    }
                
                }
                else if (result == DialogResult.No)
                {

                }
            }
            else
            {
                var fKiosko = new _00049_Kiosko();

                fKiosko.ShowDialog();
            }
        }

        private void Caja_Click(object sender, System.EventArgs e)
        {
            if(EstadoCaja)
            {

                DialogResult result = MessageBox.Show("¿Desea cerrar la caja?", "Advertencia", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var fCajaCerrar = new _0045_CerrarCaja();
                    fCajaCerrar.ShowDialog();

                }
                else if (result == DialogResult.No)
                {

                }
            }
            else
            {
                DialogResult result = MessageBox.Show("No se encuentra ninguna caja abierta." +
                    " ¿Desea abrirla?", "Advertencia", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var fcajaAbrir = new _0044_AbrirCaja();
                    fcajaAbrir.ShowDialog();
                   
                }
                else if (result == DialogResult.No)
                {

                }
            }
        }

        private void MovimientosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fMoviminetos = new _00041_Movimiento();
            fMoviminetos.ShowDialog();
        }

        private void Salon_Click(object sender, System.EventArgs e)
        {
            if (EstadoCaja == false)
            {
                DialogResult result = MessageBox.Show("La Caja debe esta Abierta para ingresar al Salon." +
                                                      " ¿Desea Abrir la Caja?",
                    "Informacion",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var fAbriCaja = new _0044_AbrirCaja();

                    fAbriCaja.ShowDialog();

                    if (EstadoCaja)
                    {
                        var fSalon = new _0032_VentaSalon();

                        fSalon.ShowDialog();
                    }

                }
                else if (result == DialogResult.No)
                {

                }
            }
            else
            {
                var fSalon = new _0032_VentaSalon();

                fSalon.ShowDialog();
            }
        }

        private void Listadeprecios_Click(object sender, System.EventArgs e)
        {
            var fArticulo = new _00035_ListaPrecios();
            fArticulo.ShowDialog();
        }

        private void verificarUsuario()
        {
            if (NombreUsuarioLogueado == "Admin")
            {
                caja.Enabled = false;
                salon.Enabled = false;
                consultart.Enabled = false;
                kiosko.Enabled = false;
            }
        }

        private void ConsultaToolStripMenuItem6_Click_1(object sender, System.EventArgs e)
        {
            var fMovimientos = new _00041_Movimiento();
            fMovimientos.ShowDialog();
        }

        
    }
}
