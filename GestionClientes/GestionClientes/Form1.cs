using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionClientes
{
    public partial class Form1 : Form
    {

        conexionBD objconexion = new conexionBD();
        public Form1()
        {
            InitializeComponent();
            conexionBD objconexion = new conexionBD();
            objconexion.Listar(this.dataClientes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexionBD objconexion = new conexionBD();
            objconexion.eliminarCliente(int.Parse(this.txtIdCliente.Text));
            objconexion.Listar(this.dataClientes);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboxOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                dataClientes.SelectAll();
                dataClientes.ClearSelection();

                if (cboxOpciones.SelectedItem.Equals("Nombre"))
                {
                    objconexion.buscarNombre(this.dataClientes, txtBuscar.Text);
                }
                if (cboxOpciones.SelectedItem.Equals("ApellidoPaterno"))
                {
                    objconexion.buscarApellidoPaterno(this.dataClientes, txtBuscar.Text);
                }
                if (cboxOpciones.SelectedItem.Equals("Telefono"))
                {
                    objconexion.buscarTelefono(this.dataClientes, txtBuscar.Text);
                }
                if (cboxOpciones.SelectedItem.Equals("Correo"))
                {
                    objconexion.buscarCorreo(this.dataClientes, txtBuscar.Text);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario objUsuario = new usuario(1, int.Parse(txtIdCliente.Text));              
                objconexion.buscarCliente(int.Parse(txtIdCliente.Text), objUsuario.txtNombre, objUsuario.txtAP, objUsuario.txtCorreo, objUsuario.txtTelefono);
                objUsuario.Show();
                this.Hide();
            }
            catch (Exception)
            {
            }

        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            usuario objUsuario = new usuario(1, 0);
            this.Hide();
            objUsuario.Show();
        }

        private void nuevaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            categoria objCategoria = new categoria(1);
            this.Hide();
            objCategoria.Show();
        }

        private void editarToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            categoria objCategoria = new categoria(2);
            this.Hide();
            objCategoria.Show();
        }

        private void eliminarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            categoria objCategoria = new categoria(3);
            objCategoria.Show();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                conexionBD objconexion = new conexionBD();
                objconexion.eliminarCliente(int.Parse(this.txtIdCliente.Text));
                objconexion.Listar(this.dataClientes);
            }
            catch (Exception)
            {
            }

        }
    }
}
