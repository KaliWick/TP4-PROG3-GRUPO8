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

        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = string.Empty;
            txtProducto.Text = string.Empty;
            
        }
    }
}