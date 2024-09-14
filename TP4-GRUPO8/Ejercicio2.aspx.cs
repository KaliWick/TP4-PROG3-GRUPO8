using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls.WebParts;
namespace TP4_GRUPO8
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        string rutaBD = "Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            //CONEXION CON SQL
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();

                SqlDataAdapter adaptadorGrdProductos = new SqlDataAdapter("select * from productos",cn);
                DataSet ds = new DataSet();
                adaptadorGrdProductos.Fill(ds,"Productos");

                grdProductos.DataSource = ds;
                grdProductos.DataBind();


            cn.Close();

            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string op = ddlProducto.SelectedValue;
            string IdProducto = txtProducto.Text;
            string consultaIdProductos = "Select * From productos Where IdProducto " + op + " " + IdProducto;
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();

            string consulta = "select * from productos ";

            if (txtCategoria.Text.Trim().Length > 0 && txtProducto.Text.Trim().Length > 0)
            {
                consulta += " where IdProducto " + ddlProducto.SelectedValue.ToString() + txtProducto.Text.Trim() + " AND " +
                   "IdCategoría " + ddlCategoria.SelectedValue.ToString() + txtCategoria.Text.Trim();
                //SI SE LLENARON AMBOS FILTROS
            }
            else if (txtProducto.Text.Trim().Length > 0)
            {

                //SOLO SE LLENO ID
                consulta += " where IdProducto " + ddlProducto.SelectedValue.ToString() + txtProducto.Text.Trim();
                txtProducto.Text = string.Empty;
            }else if (txtCategoria.Text.Trim().Length > 0)
            {
                //SOLO SE LLENO CATEGORIA
                consulta += "Where IdCategoría" + ddlCategoria.SelectedValue.ToString() + txtCategoria.Text.Trim();
                txtCategoria.Text = string.Empty;
            }
            else
            {
                //SI NO SE LLENO NINGUN FILTRO
            }

                SqlDataAdapter adaptadorIdProducto = new SqlDataAdapter(consulta, cn);
                DataSet ds = new DataSet();
                adaptadorIdProducto.Fill(ds);

                grdProductos.DataSource = ds;
                grdProductos.DataBind();



                cn.Close();
        }
        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();

            txtCategoria.Text = string.Empty;
            txtProducto.Text = string.Empty;
            string consulta = "select * from productos";

            SqlDataAdapter adaptadorIdProducto = new SqlDataAdapter(consulta, cn);
            DataSet ds = new DataSet();
            adaptadorIdProducto.Fill(ds);

            grdProductos.DataSource = ds;
            grdProductos.DataBind();

            cn.Close();
        }
    }
}