using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Models;
using System.Data;

namespace Presentacion
{
    public partial class VistaAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TraerAutoresGridview();
                TraerCiudadesCbCity();
            }
            
        }

        private void TraerAutoresGridview()
        {
            List<Author> authors = DacAuthor.Listar();

            gridAuthors.DataSource = authors;

            gridAuthors.DataBind();
        }

        private void TraerCiudadesCbCity()
        {
            //Crear una DataTable que recibe las ciudades
            DataTable dt = DacAuthor.ListarCity();


            DataRow nuevaFila = dt.NewRow();
            nuevaFila["city"] = "[Todas]";
            dt.Rows.InsertAt(nuevaFila, 0);

            cbCity.DataSource = dt;
            cbCity.DataTextField = dt.Columns["city"].ToString();
            cbCity.DataValueField = dt.Columns["city"].ToString();
            cbCity.DataBind();


        }



        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            gridAuthors.DataSource = DacAuthor.TraerUnoDT(txtFiltrarPorId.Text);
            gridAuthors.DataBind();
        }

        protected void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string city = cbCity.SelectedValue.ToString();

            if (city == "[Todas]")
            {
                TraerAutoresGridview();
            }
            else
            {
                gridAuthors.DataSource = DacAuthor.Listar(city);
                gridAuthors.DataBind();
            }
        }




    }
}