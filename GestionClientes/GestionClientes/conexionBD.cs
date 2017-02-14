using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace GestionClientes
{
    class conexionBD
    { 

    SqlConnection conx = new SqlConnection("Data Source=DESKTOP-IQQHUJ4\\MSSQLSERVERAAA;Initial Catalog=GestionCientes;Integrated Security=True");
    SqlCommand cmd;
    DataTable dt = new DataTable();
    SqlDataReader dr;


    public void LlenarItems(ComboBox cBox)
    {
        conx.Open();

        cmd = new SqlCommand("select*from categorias", conx);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            cBox.Items.Add(dr["nombre"].ToString());
        }
        cBox.SelectedIndex = 0;
        conx.Close();
    }



    public void nuevoCliente(string nombre, string apellidoP, string telefono, string correo, int id)
    {

        SqlCommand cm = this.conx.CreateCommand();
        cm.CommandText = ("insert clientes(nombre, apellidos, telefono,correo,idCategoria)values('" + nombre + "', '" + apellidoP + "',  '" + telefono + "','" + correo + "'," + id + ")");
        conx.Open();
        cm.ExecuteNonQuery();
        MessageBox.Show("si");
        conx.Close();

    }
    public void actualizarCliente(string nombre, string apellidoP, string telefono, string correo, int id)
    {

        SqlCommand cm = this.conx.CreateCommand();
        cm.CommandText = ("UPDATE clientes SET nombre='" + nombre + "', apellidos='" + apellidoP + "', telefono='" + telefono + "', correo='" + correo + "' WHERE idCliente=" + id + "");
        conx.Open();
        cm.ExecuteNonQuery();
        MessageBox.Show("si");
        conx.Close();

    }
    public string idCategoria(string nombre)
    {
        cmd = new SqlCommand("select idCategoria from categorias where nombre='" + nombre + "'", conx);
        conx.Open();
        dr = cmd.ExecuteReader();
        string a = "";
        while (dr.Read())
        {
            a = dr["idCategoria"].ToString();
        }

        conx.Close();
        return a;
    }

    public void nuevaCategoria(string nombre)
    {
        try
        {
            SqlCommand cm = this.conx.CreateCommand();
            cm.CommandText = ("insert categorias(nombre)values('" + nombre + "');");
            conx.Open();
            cm.ExecuteNonQuery();
            MessageBox.Show("si");
            conx.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("no se pudo");
        }
    }
    public void Listar(DataGridView data)
    {
            
        conx.Open();
        SqlDataAdapter adap = new SqlDataAdapter(" select c.idCliente, c.nombre, c.apellidos, telefono, correo, (select nombre from categorias where categorias.idCategoria = c.idCategoria) as categoria from clientes c", conx);
        adap.Fill(dt);
        data.DataSource = dt;
        conx.Close();

    }

    public void buscarNombre(DataGridView data, string nombre)
    {
        conx.Open();
        SqlDataAdapter adap = new SqlDataAdapter("   select c.nombre,apellidos,telefono,correo,(select nombre from categorias where categorias.idCategoria=c.idCategoria)as categoria from clientes c where c.nombre like '" + nombre + "%'", conx);
        adap.Fill(dt);
        data.DataSource = dt;
        conx.Close();
    }
    public void eliminarCliente(int idCliente)
    {
        conx.Open();
        SqlCommand cm = new SqlCommand(" delete from clientes where idCliente =" + idCliente + "", conx);
        cm.ExecuteNonQuery();
        MessageBox.Show("Elemento eliminado");
        conx.Close();

    }
    public void buscarApellidoPaterno(DataGridView data, string apellidoP)
    {
        conx.Open();
        SqlDataAdapter adap = new SqlDataAdapter("   select c.nombre,apellidos,telefono,correo,(select nombre from categorias where categorias.idCategoria=c.idCategoria)as categoria from clientes c where c.apellidos like '" + apellidoP + "%'", conx);
        adap.Fill(dt);
        data.DataSource = dt;
        conx.Close();
    }
    public void buscarTelefono(DataGridView data, string telefono)
    {
        conx.Open();
        SqlDataAdapter adap = new SqlDataAdapter("   select c.nombre,apellidos,telefono,correo,(select nombre from categorias where categorias.idCategoria=c.idCategoria)as categoria from clientes c where c.telefono like '" + telefono + "%'", conx);
        adap.Fill(dt);
        data.DataSource = dt;
        conx.Close();
    }
    public void buscarCorreo(DataGridView data, string correo)
    {
        conx.Open();
        SqlDataAdapter adap = new SqlDataAdapter("   select c.nombre,apellidoP,apellidoM,telefono,correo,(select nombre from categoria where categoria.idCategoria=c.idCategoria)as categoria from clientes c where c.correo like '" + correo + "%'", conx);
        adap.Fill(dt);
        data.DataSource = dt;
        conx.Close();
    }
    public void editarCtegoria(string nombreNuevo, String nombreAnterior)
    {
        try
        {
            SqlCommand cm = this.conx.CreateCommand();
            cm.CommandText = ("  UPDATE categorias SET nombre = '" + nombreNuevo + "' WHERE nombre = '" + nombreAnterior + "'; ");
            conx.Open();
            cm.ExecuteNonQuery();
            MessageBox.Show("editado");
            conx.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("no se pukkmkdo");
        }
    }
    public void eliminarCategoria(string nombre)
    {

        try
        {
            conx.Open();
            SqlCommand cm = new SqlCommand(" DELETE FROM categorias WHERE nombre = '" + nombre + "'", conx);
            cm.ExecuteNonQuery();
            MessageBox.Show("Elemento eliminado");
            conx.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("elemento usado");
        }
    }
    public void buscarCliente(int idCliente, TextBox txtNombre, TextBox txtAP, TextBox txtCorreo, TextBox txtTelefono)
    {
        conx.Open();
        SqlDataAdapter adap = new SqlDataAdapter("select c.nombre,apellidos,telefono,correo,(select nombre from categorias where categorias.idCategoria=c.idCategoria)as categoria from clientes c where c.idCliente = '" + idCliente + "'", conx);
        adap.Fill(dt);
        txtNombre.Text = dt.Rows[0]["nombre"].ToString();
        txtAP.Text = dt.Rows[0]["apellidos"].ToString();
        txtCorreo.Text = dt.Rows[0]["correo"].ToString();
        txtTelefono.Text = dt.Rows[0]["telefono"].ToString();
        conx.Close();
    }








}
}
