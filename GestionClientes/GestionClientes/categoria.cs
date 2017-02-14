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
    public partial class categoria : Form
    {
        int valor = 0;
        public categoria(int a)
        {

            InitializeComponent();
            if (a == 1)
            {
                cboxCategoria.Visible = false;
                valor = 1;
            }
            else if (a == 2)
            {
                cboxCategoria.Visible = true;
                conexionBD objNP = new conexionBD();
                objNP.LlenarItems(this.cboxCategoria);
                valor = 2;
            }
            else if (a == 3)
            {
                valor = 3;
                cboxCategoria.Visible = true;
                txtCategoria.Visible = false;
                conexionBD objNP = new conexionBD();
                objNP.LlenarItems(this.cboxCategoria);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (valor == 1)
            {
                if (txtCategoria.Text != "")
                {
                    conexionBD objNP = new conexionBD();
                    objNP.nuevaCategoria(txtCategoria.Text);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ingrese nombre de la categoria");
                }
            }
            else if (valor == 2)
            {
                if (txtCategoria.Text != "")
                {
                    conexionBD objNP = new conexionBD();
                    objNP.editarCtegoria(txtCategoria.Text, Convert.ToString(cboxCategoria.SelectedItem));
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ingrese nombre de la categoria");
                }
            }
            else if (valor == 3)
            {
                conexionBD objNP = new conexionBD();
                objNP.eliminarCategoria(Convert.ToString(cboxCategoria.SelectedItem));
                this.Hide();
            }

            Form1 objMain = new Form1();
            objMain.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboxCategoria_SelectedIndexChanged(object sender, EventArgs e)
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
