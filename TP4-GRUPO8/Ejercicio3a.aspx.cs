﻿using System;
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

           // string tema = ddlTemas.SelectedItem.Text;

                ddlTemas.DataSource = dr;
                ddlTemas.DataTextField = "Tema";
                ddlTemas.DataValueField = "IdTema";
                ddlTemas.DataBind();
                ListItem todos = new ListItem();
                todos.Text = "Todos";
                todos.Value = "0";
                ddlTemas.Items.Add(todos);
    cn.Close();
            }
        }

        protected void lnkbtnVerLibros_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ejercicio3b.aspx");
        }

        protected void ddlTemas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}