using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls.WebParts;
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
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();

            string consulta = "select * from productos ";

            //SI SE LLENARON AMBOS FILTROS
            if (txtCategoria.Text.Trim().Length > 0 && txtProducto.Text.Trim().Length > 0)
            {
                consulta += " where IdProducto " + ddlProducto.SelectedValue.ToString() + txtProducto.Text.Trim() + " AND " +
                "IdCategoría " + ddlCategoria.SelectedValue.ToString() + txtCategoria.Text.Trim();
                lblFiltrado.Text = "Filtrado por ID y Categoria";
                txtCategoria.Text = string.Empty;
                txtProducto.Text = string.Empty;
            }
            
            //SOLO SE LLENO ID
            else if (txtProducto.Text.Trim().Length > 0)
            {

                consulta += " where IdProducto " + ddlProducto.SelectedValue.ToString() + txtProducto.Text.Trim();
                txtProducto.Text = string.Empty;
                lblFiltrado.Text = "Filtrado por ID";
            }
            
            //SOLO SE LLENO CATEGORIA
            else if (txtCategoria.Text.Trim().Length > 0)
            {
                consulta += "Where IdCategoría" + ddlCategoria.SelectedValue.ToString() + txtCategoria.Text.Trim();
                txtCategoria.Text = string.Empty;
                lblFiltrado.Text = "Filtrado por Categoria";
            }
            else
            {
                //SI NO SE LLENO NINGUN FILTRO
                lblFiltrado.Text = string.Empty;
            }

                SqlDataAdapter adaptadorIdProducto = new SqlDataAdapter(consulta, cn);
                DataSet ds = new DataSet();
                adaptadorIdProducto.Fill(ds);

                grdProductos.DataSource = ds;
                grdProductos.DataBind();



                cn.Close();
        }
        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();

            txtCategoria.Text = string.Empty;
            txtProducto.Text = string.Empty;
            string consulta = "select * from productos";

            SqlDataAdapter adaptadorIdProducto = new SqlDataAdapter(consulta, cn);
            DataSet ds = new DataSet();
            adaptadorIdProducto.Fill(ds);

            grdProductos.DataSource = ds;
            grdProductos.DataBind();

            cn.Close();
        }
    }
}