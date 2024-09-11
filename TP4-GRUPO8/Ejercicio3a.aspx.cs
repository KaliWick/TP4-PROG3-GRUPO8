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
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        string rutaBD = "Data Source=localhost\\sqlexpress;Initial Catalog=Libreria;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            //CONEXION CON SQL
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();
            SqlCommand cmdTemas = new SqlCommand("select * from Temas", cn);
            SqlDataReader dr = cmdTemas.ExecuteReader();
            

            cn.Close();
            }
        }

        protected void lnkbtnVerLibros_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ejercicio3b.aspx");
        }
    }
}