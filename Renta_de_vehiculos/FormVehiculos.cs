using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Renta_de_vehiculos
{
    public partial class FormVehiculos : Form
    {
        VehiculoBL _vehiculo;
        TiposBL _tipos;

        public FormVehiculos()
        {
            InitializeComponent();

            _vehiculo = new VehiculoBL();
            vehiculoBindingSource.DataSource = _vehiculo.ObtenerVehiculos();

            _tipos = new TiposBL();
            listaTipoBindingSource.DataSource = _tipos.ObtenerTipos();
             
        }

        private void activoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void activoLabel_Click(object sender, EventArgs e)
        {

        }

        private void vehiculoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            vehiculoBindingSource.EndEdit();
            var vehiculo = (Vehiculo)vehiculoBindingSource.Current;

            if (fotoPictureBox.Image != null)
            {
                vehiculo.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }

            else
            {
                vehiculo.Foto = null;
            }

            var resultado = _vehiculo.GuardarVehiculo(vehiculo);

            if (resultado.Exitoso == true)
            {
                vehiculoBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotenes(true);

                MessageBox.Show("Producto Guardado");

            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _vehiculo.AgregarVehiculo();
            vehiculoBindingSource.MoveLast();

            DeshabilitarHabilitarBotenes(false);
        }

        private void DeshabilitarHabilitarBotenes(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            Cancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
            if (iDTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Desea Eliminar este Registro?", "Eliminar ", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(iDTextBox.Text);
                    Eliminar(id);
                }
                
            }
        }

        private void Eliminar(int id)
        {
            var resultado = _vehiculo.EliminarVehiculo(id);

            if (resultado == true)
            {
                vehiculoBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el producto");
            }

        }

        private void Cancelar_click(object sender, EventArgs e)
        {
            _vehiculo.CancelarCambios();
            DeshabilitarHabilitarBotenes(true);
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotenes(true);
            Eliminar(0);
        }

        private void fotoLabel_Click(object sender, EventArgs e)
        {

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void fotoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var vehiculo = (Vehiculo)vehiculoBindingSource.Current;

            if (vehiculo != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }
                else
                {
                    MessageBox.Show("Debe de crear una nueva casilla o llenarlas todas las casilla primero");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void tipoidComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tipoidLabel_Click(object sender, EventArgs e)
        {

        }

        private void tiposBLBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void iDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormVehiculos_Load(object sender, EventArgs e)
        {

        }

        private void precioTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                var buscar = textBox1.Text;
                vehiculoBindingSource.DataSource = _vehiculo.ObtenerVehiculos(buscar);
            }
        }
    }
}
