using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TP4_GRUPO8
{
    public class Conexion1
    {
        private string rutaBD = "Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public bool llenarProvinciasInicio(string consultaProvincias,DropDownList ddlProvinciaInicio)
        {
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();

            SqlDataAdapter adaptadorProvinciasInicio = new SqlDataAdapter(consultaProvincias, cn);
            DataSet dsProvinciasInicio = new DataSet();
            adaptadorProvinciasInicio.Fill(dsProvinciasInicio, "Provincias");

            ddlProvinciaInicio.DataSource = dsProvinciasInicio.Tables["Provincias"];
            ddlProvinciaInicio.DataTextField = "NombreProvincia";
            ddlProvinciaInicio.DataValueField = "IdProvincia";
            ddlProvinciaInicio.DataBind();

            cn.Close();
            return true;
        }
        public bool llenarLocalidadesInicio(string consultaLocalidades,DropDownList ddlLocalidadInicio, DropDownList ddlProvinciaInicio)
        {
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();

            SqlDataAdapter adaptadorLocalidadesInicio = new SqlDataAdapter(consultaLocalidades, cn);
            DataSet dsLocalidadesInicio = new DataSet();
            adaptadorLocalidadesInicio.Fill(dsLocalidadesInicio, "Localidades");

            //si el valor es diferente al default se llena, Sino se vacia
            if (ddlProvinciaInicio.SelectedValue != "0")
            {
                ddlLocalidadInicio.DataSource = dsLocalidadesInicio.Tables["Localidades"];
                ddlLocalidadInicio.DataTextField = "NombreLocalidad";
                ddlLocalidadInicio.DataValueField = "IdLocalidad";
                ddlLocalidadInicio.DataBind();

                cn.Close();
                return true;
            }
            else
            {
                cn.Close();
                return false;
            }
        }
        public bool llenarProvinciasDestino(string consultaProvinciasDestino, DropDownList ddlProvinciaFinal0, DropDownList ddlProvinciaInicio)
        {
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();

            SqlDataAdapter addaptadorProvDes = new SqlDataAdapter(consultaProvinciasDestino,cn);
            DataSet dsProvDes = new DataSet();
            addaptadorProvDes.Fill(dsProvDes, "provincias");

            //si el valor de la provincia de inicio no es el default, se llena
            if (ddlProvinciaInicio.SelectedValue != "0")
            {
                foreach (DataRow dr in dsProvDes.Tables["provincias"].Rows)
                {
                    ListItem provFinal = new ListItem();
                    provFinal.Text = dr["NombreProvincia"].ToString();
                    provFinal.Value = dr["IdProvincia"].ToString();
                    ddlProvinciaFinal0.Items.Add(provFinal);
                }
            }
             
            cn.Close();
            return true;
        }
        public bool llenarLocalidadesDestino(string consultaLocalidades, DropDownList ddlLocalidadFinal, DropDownList ddlProvinciaFinal0)
        {
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();

            SqlDataAdapter adaptadorLocalidadesFinal = new SqlDataAdapter(consultaLocalidades, cn);
            DataSet dsLocalidadesFinal = new DataSet();
            adaptadorLocalidadesFinal.Fill(dsLocalidadesFinal, "Localidades");

            if (ddlProvinciaFinal0.SelectedValue != "0")
            {
                ddlLocalidadFinal.DataSource = dsLocalidadesFinal.Tables["Localidades"];
                ddlLocalidadFinal.DataTextField = "NombreLocalidad";
                ddlLocalidadFinal.DataValueField = "IdLocalidad";

                ddlLocalidadFinal.DataBind();
                cn.Close();
                return true;
            }
            else
            {
                cn.Close();
                return false;
            }
 
        }
    }
}