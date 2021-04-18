using BL.Rentas;
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
    public partial class FormReporteProductos : Form
    {
        public FormReporteProductos()
        {
            InitializeComponent();

            var _vehiculoBL = new VehiculoBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _vehiculoBL.ObtenerVehiculos();

            var reporte = new ReporteVehiculo();
            reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }

        private void FormReporteProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
