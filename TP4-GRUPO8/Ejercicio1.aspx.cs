using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;
namespace TP4_GRUPO8
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        string rutaBD = "Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        string consultaProvincias = "SELECT NombreProvincia, IdProvincia FROM Provincias";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CONEXION CON SQL

                SqlConnection cn = new SqlConnection(rutaBD);
                cn.Open();


                //TRAER PROVINCIAS AL DDL
                SqlDataAdapter adaptadorProvinciasInicio= new SqlDataAdapter(consultaProvincias, cn);
                DataSet dsProvinciasInicio = new DataSet();
                adaptadorProvinciasInicio.Fill(dsProvinciasInicio, "Provincias");


                ddlProvinciaInicio.DataSource = dsProvinciasInicio.Tables["Provincias"];
                ddlProvinciaInicio.DataTextField = "NombreProvincia";
                ddlProvinciaInicio.DataValueField = "IdProvincia";

                ddlProvinciaInicio.DataBind();

                ListItem defaultItem = new ListItem("--Seleccionar--", "0");
                ddlProvinciaInicio.Items.Insert(0, defaultItem);
                
                //TERMINAR LA CONEXION
                cn.Close();
            }
        }

        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consultaLocalidadesBsAs = "SELECT NombreLocalidad, IdLocalidad FROM Localidades Where IdProvincia = 1";
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();
            SqlDataAdapter adaptadorLocalidadesInicio = new SqlDataAdapter(consultaLocalidadesBsAs, cn);
            DataSet dsLocalidadesInicio = new DataSet();
            adaptadorLocalidadesInicio.Fill(dsLocalidadesInicio, "Localidades");
            if (ddlProvinciaInicio.SelectedIndex == 1)
            {
                ddlLocalidadInicio.DataSource = dsLocalidadesInicio.Tables["Localidades"];
                ddlLocalidadInicio.DataTextField = "NombreLocalidad";
                ddlLocalidadInicio.DataValueField = "IdLocalidad";
                ddlLocalidadInicio.DataBind();
            }
            else ddlLocalidadInicio.DataBind();

            string consultaLocalidades_EnRs = "SELECT NombreLocalidad, IdLocalidad FROM Localidades Where IdProvincia = 2 ";
            SqlConnection cn2 = new SqlConnection(rutaBD);
            cn2.Open();
            SqlDataAdapter AdaptadorDeLocalidadesInicio2 = new SqlDataAdapter(consultaLocalidades_EnRs, cn2);
            DataSet dsLocalidadesInicio2 = new DataSet();
            AdaptadorDeLocalidadesInicio2.Fill(dsLocalidadesInicio2, "Localidades");
            if (ddlProvinciaInicio.SelectedIndex == 2)
            {
                ddlLocalidadInicio.DataSource = dsLocalidadesInicio2.Tables["Localidades"];
                ddlLocalidadInicio.DataTextField = "NombreLocalidad";
                ddlLocalidadInicio.DataValueField = "IdLocalidad";
                ddlLocalidadInicio.DataBind();
            }
            else ddlLocalidadInicio.DataBind();
        }
       
    }
}