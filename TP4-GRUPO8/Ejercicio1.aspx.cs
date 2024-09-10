using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace TP4_GRUPO8
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        string rutaBD = "Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        string consultaProvincias = "select * from provincias";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(rutaBD);
                cn.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter(consultaProvincias, cn);
                DataSet ds = new DataSet();
                adaptador.Fill(ds,"Provincias");
            }
        }
    }
}