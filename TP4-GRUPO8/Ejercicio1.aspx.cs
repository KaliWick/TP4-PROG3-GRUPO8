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

                //AGREGAR VALOR DEFAULT
                ListItem defaultItem = new ListItem("--Seleccionar--", "0");
                ddlProvinciaInicio.Items.Insert(0, defaultItem);
                
                //TERMINAR LA CONEXION
                cn.Close();
            }
        }

        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
           //conexion
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();

            //---------------------LOCALIDADES DDL-------------------
            
            //se obtiene el valor de la provincia y se construye la consulta con el mismo
            int idProvincia = int.Parse(ddlProvinciaInicio.SelectedValue);
            string consultaLocalidades = "SELECT NombreLocalidad, IdLocalidad FROM Localidades " +
                "WHERE IdProvincia = "+idProvincia;
         
            //adaptador
            SqlDataAdapter adaptadorLocalidadesInicio = new SqlDataAdapter(consultaLocalidades, cn);
            DataSet dsLocalidadesInicio = new DataSet();
            adaptadorLocalidadesInicio.Fill(dsLocalidadesInicio, "Localidades");

            //si el valor es diferente al default se llena, Sino se vacia y se coloca uno nuevo
            if(ddlProvinciaInicio.SelectedValue != "0")
            {
                ddlLocalidadInicio.DataSource = dsLocalidadesInicio.Tables["Localidades"];
                ddlLocalidadInicio.DataTextField = "NombreLocalidad";
                ddlLocalidadInicio.DataValueField = "IdLocalidad";

                ddlLocalidadInicio.DataBind();
            }
            else
            {
                ddlLocalidadInicio.Items.Clear();
                ListItem defaultItem2 = new ListItem("--Seleccionar--", "0");
                ddlLocalidadInicio.Items.Insert(0, defaultItem2);
            }

            //---------------------PROVINCIA DESTINO DDL-------------------

            //consulta
            string provinciaElegida = ddlProvinciaInicio.SelectedItem.Text;
            string consultaProvincias = "SELECT NombreProvincia, IdProvincia " +
                "FROM Provincias Where NombreProvincia <> '"+provinciaElegida+"'";


            //adaptador
            SqlDataAdapter addaptadorProvDes = new SqlDataAdapter(consultaProvincias, cn);
            DataSet dsProvDes = new DataSet();
            addaptadorProvDes.Fill(dsProvDes,"provincias");

            //se limpia y se inserta un valor default
            ddlProvinciaFinal0.Items.Clear();
            ListItem defaultItem = new ListItem("--Seleccionar--", "0");
            ddlProvinciaFinal0.Items.Insert(0, defaultItem);

            //se llena el ddl
            foreach (DataRow dr in dsProvDes.Tables["provincias"].Rows)
            {
               /* 
                if (dr["NombreProvincia"].ToString() != ddlProvinciaInicio.SelectedItem.ToString())
                {
                    ListItem provFinal = new ListItem();
                    provFinal.Text = dr["NombreProvincia"].ToString();
                    provFinal.Value = dr["IdProvincia"].ToString();
                    ddlProvinciaFinal0.Items.Add(provFinal);
                }
               */
                    ListItem provFinal = new ListItem();
                    provFinal.Text = dr["NombreProvincia"].ToString();
                    provFinal.Value = "0";

                    ddlProvinciaFinal0.Items.Add(provFinal);

                
            }

            
            //cierre de conexion
            cn.Close();

        }

    }
}