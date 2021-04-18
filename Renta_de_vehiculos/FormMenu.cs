using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Renta_de_vehiculos
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteCliente = new FormReporteCliente();
            formReporteCliente.MdiParent = this;
            formReporteCliente.Show();
        }

        private void alquilerToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();

            
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();

            toolStripStatusLabel1.Text = Utils.nombreUsuario;
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formVehiculos = new FormVehiculos();
            formVehiculos.MdiParent = this;
            formVehiculos.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.Show();

        }

        private void reporteProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteProductos = new FormReporteProductos();
            formReporteProductos.MdiParent = this;
            formReporteProductos.Show();
        }

        private void reporteDeDañosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteDanos = new FormReporteDanos();
            formReporteDanos.MdiParent = this;
            formReporteDanos.Show();
        
        }

        private void archivosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
            formFactura.MdiParent = this;
            formFactura.Show();
        }

        private void contactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formContacto = new FormContacto();
            formContacto.MdiParent = this;
            formContacto.Show();
        }

        private void reporteFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteFacturas = new FormReporteFactura();
            formReporteFacturas.MdiParent = this;
            formReporteFacturas.Show();
        }
    
    }
}
