using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_GRUPO8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string rutaBD = "Data Source=localhost\\sqlexpress;Initial Catalog=Libreria;Integrated Security=True";
        string librosTema1 = "Select * From Libros Where IdTema = 1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    SqlConnection cn = new SqlConnection(rutaBD);
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter adaptadorTemas = new SqlDataAdapter(librosTema1, cn);
                    adaptadorTemas.Fill(ds, "Libros");
                    grvLibros.DataSource = ds;
                    grvLibros.DataBind();
            }
        }

        protected void lnkbtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3a.aspx");
        }
    }
}