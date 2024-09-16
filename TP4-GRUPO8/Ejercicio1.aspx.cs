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
        Conexion1 conexion = new Conexion1();
        
       public void agregarItemDefault(DropDownList ddl)
        {
            ListItem defaultItem = new ListItem("--Seleccionar--", "0");
            ddl.Items.Insert(0, defaultItem);
        }
        public void vaciarAgregarItemDefault(DropDownList ddl)
        {
            ddl.Items.Clear();
            ListItem defaultItem = new ListItem("--Seleccionar--", "0");
            ddl.Items.Insert(0, defaultItem);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string consultaProvincias = "SELECT NombreProvincia, IdProvincia FROM Provincias";
                conexion.llenarProvinciasInicio(consultaProvincias,ddlProvinciaInicio);
                agregarItemDefault(ddlProvinciaInicio);
            }
        }
     
        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*----------LOCALIDADES INICIO----------*/

            int idProvincia = int.Parse(ddlProvinciaInicio.SelectedValue);
            
            string consultaLocalidades = "SELECT NombreLocalidad, IdLocalidad FROM Localidades " +
                "WHERE IdProvincia = "+idProvincia;
           
            vaciarAgregarItemDefault(ddlLocalidadInicio);
            conexion.llenarLocalidadesInicio(consultaLocalidades, ddlLocalidadInicio, ddlProvinciaInicio);
                
            
            
            /*----------PROVINCIAS DESTINO---------*/

            string provinciaElegida = ddlProvinciaInicio.SelectedItem.Text;

            string consultaProvincias = "SELECT NombreProvincia, IdProvincia " +
                   "FROM Provincias Where NombreProvincia <> '"+provinciaElegida+"'";

            vaciarAgregarItemDefault(ddlProvinciaFinal0);
            
            conexion.llenarProvinciasDestino(consultaProvincias, ddlProvinciaFinal0, ddlProvinciaInicio);
            
            if(ddlProvinciaFinal0.SelectedValue == "0")
            {
                vaciarAgregarItemDefault(ddlLocalidadFinal);
            }
        }

        protected void ddlProvinciaFinal0_SelectedIndexChanged(object sender, EventArgs e)
        {
                    int idProvincia = int.Parse(ddlProvinciaFinal0.SelectedValue);
                    string consultaLocalidades = "SELECT NombreLocalidad, IdLocalidad FROM Localidades " +
                        "WHERE IdProvincia = " + idProvincia;

            vaciarAgregarItemDefault(ddlLocalidadFinal);
            conexion.llenarLocalidadesDestino(consultaLocalidades, ddlLocalidadFinal, ddlProvinciaFinal0);
            

        }
        
    }
}