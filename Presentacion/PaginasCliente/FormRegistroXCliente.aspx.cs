using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Presentacion.PaginasCliente
{
    public partial class FormRegistroXCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            CargarReservasCliente();
        }

        private void CargarReservasCliente(int? idCliente = null)
        {
            
            idCliente = Convert.ToInt32(Session["idPersona"]);
            string rol = Session["rol"].ToString();
            if (rol=="Empleado")
            {
                idCliente = 0;

                

            }

            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                if (idCliente.HasValue)
                    parametros.Add(new SqlParameter("@IdCliente", idCliente.Value));
                else
                    parametros.Add(new SqlParameter("@IdCliente", DBNull.Value));

                DataTable dt = Datos.ConexionSQL.EjecutarConRetorno("sp_ConsultarReservasClienteSimple", parametros.ToArray());

                repeaterReservas.DataSource = dt;
                repeaterReservas.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar las reservas: " + ex.Message);
            }
        }

        protected void repeaterReservas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string rol = Session["rol"]?.ToString();

                // Buscar el párrafo completo
                HtmlGenericControl pComision = (HtmlGenericControl)e.Item.FindControl("pComision");

                if (rol == "Cliente" && pComision != null)
                {
                    pComision.Visible = false;
                }
            }
        }


         
    }
}