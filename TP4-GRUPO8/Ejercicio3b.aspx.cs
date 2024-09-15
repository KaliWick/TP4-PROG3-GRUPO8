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
        //string librosTema1 = "Select * From Libros Where IdTema = 1";
        //string librosTema2 = "Select * From Libros Where IdTema = 2";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string IdTema = ((DropDownList)PreviousPage.FindControl("ddlTemas")).SelectedValue.ToString();
                if (IdTema != "0")
                {
                    string consulta = "select * from Libros where IdTema =" + IdTema;

                    SqlConnection cntemas = new SqlConnection(rutaBD);
                    cntemas.Open();

                    DataSet dataSet = new DataSet();
                    SqlDataAdapter adapterTemas = new SqlDataAdapter(consulta, cntemas);
                    adapterTemas.Fill(dataSet, "Libros");

                    grvLibros.DataSource = dataSet;
                    grvLibros.DataBind();

                    cntemas.Close();
                }else if (IdTema == "0")
                {
                    string consultaTodos = "select * from Libros";
                    SqlConnection cntemas = new SqlConnection(rutaBD);
                    cntemas.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter adapterTodos = new SqlDataAdapter(consultaTodos, cntemas);
                    adapterTodos.Fill(ds, "Libros");

                    grvLibros.DataSource = ds;
                    grvLibros.DataBind();

                    cntemas.Close();
                }
            }
        }

        protected void lnkbtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3a.aspx");
        }
    }
}