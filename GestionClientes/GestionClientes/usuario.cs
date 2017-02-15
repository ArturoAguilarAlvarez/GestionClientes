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
    public partial class usuario : Form
    {
        //la variable idCliente es una ayuda que se tiene para mostrar si es agregar un nuevo usuario o una edicion de usuario
        int tipo;
            int idCliente;
            public usuario(int tipo, int idCliente)
            {
                this.tipo = tipo;
                this.idCliente = idCliente;
                InitializeComponent();
            conexionBD objNP = new conexionBD();
                objNP.LlenarItems(this.cboxOpciones);
            }

            private void button1_Click(object sender, EventArgs e)
            {
                int id = buscarIdCategoria(Convert.ToString(cboxOpciones.SelectedItem));
            conexionBD objNP = new conexionBD();



            //si idCliente es 0 es un nuevo usuario de lo cantrario es una edicion de usuario 
                if (idCliente == 0)
                {
                    if (txtNombre.Text != "" && txtAP.Text != "" && txtCorreo.Text != "" && txtTelefono.Text != "")
                    {
                        objNP.nuevoCliente(txtNombre.Text, txtAP.Text, txtTelefono.Text, txtCorreo.Text, id);
                        this.Hide();
                    }
                    else if (txtNombre.Text != "" && txtAP.Text != "" && txtTelefono.Text != "")
                    {
                        objNP.nuevoCliente(txtNombre.Text, txtAP.Text, txtTelefono.Text, "", id);
                        this.Hide();
                    }
                    else if (txtNombre.Text != "" && txtAP.Text != "" && txtCorreo.Text != "")
                    {
                        objNP.nuevoCliente(txtNombre.Text, txtAP.Text, "", txtCorreo.Text, id);
                        this.Hide();
                    }
                    else if (txtNombre.Text != "" && txtAP.Text != "")
                    {
                        objNP.nuevoCliente(txtNombre.Text, txtAP.Text, "", "", id);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("ingrese nombres y apellidos");
                    }
                }
                else
                {
                id = buscarIdCategoria(Convert.ToString(cboxOpciones.SelectedItem));
                objNP.actualizarCliente(txtNombre.Text, txtAP.Text, txtTelefono.Text, txtCorreo.Text, idCliente,id);
                    this.Hide();
                }

                Form1 objMain = new Form1();
                objMain.Show();

            }

            private void button2_Click(object sender, EventArgs e)
            {

            }



            //metodos


            //metodo Buscar iDCategoria
            public int buscarIdCategoria(string nombre)
            {
            conexionBD objNP = new conexionBD();
                String a = objNP.idCategoria(nombre);
                return int.Parse(a);
            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

            private void cboxOpciones_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void label6_Click(object sender, EventArgs e)
            {

            }

            private void txtCorreo_TextChanged(object sender, EventArgs e)
            {

            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void label4_Click(object sender, EventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void txtTelefono_TextChanged(object sender, EventArgs e)
            {

            }

            private void txtAP_TextChanged(object sender, EventArgs e)
            {

            }

            private void txtNombre_TextChanged(object sender, EventArgs e)
            {

            }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 objMain = new Form1();
            objMain.Show();
            this.Close();
        }
    }
}
