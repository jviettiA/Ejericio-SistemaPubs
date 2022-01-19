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
    public partial class VistaStore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TraerStoresGridview();
            TraerStatesCbState();
        }

        private void TraerStoresGridview()
        {
            List<Store> stores = DacStore.Listar();

            gridStores.DataSource = stores;

            gridStores.DataBind();
        }

        private void TraerStatesCbState()
        {

            DataTable dt = DacStore.ListarState();


            //Agregar [Todas] en el cbCity
            DataRow nuevaFila = dt.NewRow();
            nuevaFila["state"] = "[Todas]";
            dt.Rows.InsertAt(nuevaFila, 0);


            cbState.DataSource = dt;
            cbState.DataTextField = dt.Columns["state"].ToString();

            cbState.DataValueField = dt.Columns["state"].ToString();
            cbState.DataBind();


        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            gridStores.DataSource = DacStore.TraerUnoDT(txtFiltrarPorId.Text);
            gridStores.DataBind();
        }

        protected void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string state = cbState.SelectedValue.ToString();

            if (state == "[Todas]")
            {
                TraerStoresGridview();
            }
            else
            {
                gridStores.DataSource = DacStore.Listar(state);
                gridStores.DataBind();
            }
        }
    }
}