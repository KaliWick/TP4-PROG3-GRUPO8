using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
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

            if (txtCategoria.Text.Trim().Length > 0 && txtProducto.Text.Trim().Length > 0)
            {
                //SI SE LLENARON AMBOS FILTROS
            }else if (txtProducto.Text.Trim().Length > 0)
            {
                //SOLO SE LLENO ID
                SqlDataAdapter adaptadorIdProducto = new SqlDataAdapter(consultaIdProductos, cn);
                DataSet ds = new DataSet();
                adaptadorIdProducto.Fill(ds);

                grdProductos.DataSource = ds;
                grdProductos.DataBind();
                
                txtProducto.Text = string.Empty;
                txtCategoria.Text = string.Empty;
            }else if (txtCategoria.Text.Trim().Length > 0)
            {
                //SOLO SE LLENO CATEGORIA
            }
            else
            {
                //SI NO SE LLENO NINGUN FILTRO
            }

                cn.Close();
        }
        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = string.Empty;
            txtProducto.Text = string.Empty;
        }
    }
}