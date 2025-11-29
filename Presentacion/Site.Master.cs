using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfigurarMenuSegunSesion();
            }
        }

        private void ConfigurarMenuSegunSesion()
        {
            if (Session["idPersona"] == null)
            {
                // Usuario no logueado → mostrar solo público
                MostrarMenuPublico();
            }
            else
            {
                string rol = Session["rol"]?.ToString();
                switch (rol)
                {
                    case "Proveedor":
                        MostrarMenuProveedor();
                        break;
                    case "Cliente":
                        MostrarMenuCliente();
                        break;
                    case "Empleado":
                        MostrarMenuEmpleado();
                        break;
                    default:
                        MostrarMenuPublico();
                        break;
                }
            }
        }

        private void MostrarMenuPublico()
        {
            liRegistroCliente.Visible = true;
            liRegistroProveedor.Visible = true;
            liIngresarSitio.Visible = false;
            li1.Visible = false;
            liLogin.Visible = true;
            li1MisDatos.Visible = false;
        }

        private void MostrarMenuProveedor()
        {
            liRegistroCliente.Visible = false;
            liRegistroProveedor.Visible = false;
            liIngresarSitio.Visible = true;
            li1.Visible = false;
            liLogin.Visible = false;
            li1MisDatos.Visible = true;
            liActualizarSitio.Visible=true;
        }

        private void MostrarMenuCliente()
        {
            liRegistroCliente.Visible = false;
            liRegistroProveedor.Visible = false;
            liIngresarSitio.Visible = false;
            li1.Visible=false;
            liLogin.Visible = false;
            li1MisDatos.Visible = true;
            rxc.Visible = true;
        }
        private void MostrarMenuEmpleado()
        {
            li1.Visible=true;
            liRegistroCliente.Visible = true;
            liRegistroProveedor.Visible = true;
            liIngresarSitio.Visible = true;
            li1.Visible = true;
            liLogin.Visible = false;
            li1MisDatos.Visible = true;
        }
    }
}