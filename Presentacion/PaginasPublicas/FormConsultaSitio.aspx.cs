using Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Datos;
namespace Presentacion.PaginasPublicas
{
    public partial class FormConsultaSitio : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el IdSitio de la query string
                string idStr = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idStr) && int.TryParse(idStr, out int idSitio))
                {
                    // Mostrarlo en el título
                    lblTituloSitio.Text = $"Detalles del Sitio #{idSitio}";

                    // Aquí podrías llamar a un método que cargue los datos reales del sitio desde la base de datos
                    CargarDatosSitio(idSitio);
                }
                else
                {
                    lblTituloSitio.Text = "Detalles del Sitio";
                }
            }
        }

        private void CargarDatosSitio(int idSitio)
        {
            try
            {
                // 1️⃣ Consultar la base de datos
                Sitio sitio = Sitio.ObtenerPorId(idSitio);
                if (sitio == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('No se encontró el sitio.');", true);
                    return;
                }

               

                // 3️⃣ Llenar los campos de la interfaz
                lblNombreSitio.Text = sitio.nombreSitio ?? "";
                lblDescripcionCorta.Text = sitio.descripcionCorta ?? "";
                lblDescripcionLarga.Text = sitio.descripcionCompleta ?? "";
                lblTipoSitio.Text = ObtenerNombreTipoSitio(sitio.idTipoSitio);

                lblProvincia.Text = sitio.provincia ?? "";
                lblCanton.Text = sitio.canton ?? "";
                lblDistrito.Text = sitio.distrito ?? "";
                lblDireccion.Text = sitio.direccionExacta ?? "";
                lblNumeroCasa.Text = sitio.numeroCasa ?? "";
                lblHabitaciones.Text = sitio.numeroHabitaciones.ToString();
                lblCamas.Text = sitio.numeroCamas.ToString();
                lblBanos.Text = sitio.numeroBanos.ToString();
                lblPersonasMax.Text = sitio.personasMaximas.ToString();
                lblPrecio.Text = sitio.precioPorNoche.ToString("N0");
                lblPorPersona.Text = sitio.esPorPersona ? "Sí" : "No";
                lblLimpieza.Text = sitio.cargoLimpieza.ToString("N0");
                lblDeposito.Text = sitio.depositoSeguridad.ToString("N0");
                lblMinNoches.Text = sitio.minimoNoches.ToString();
                lblPolitica.Text = sitio.politicaCancelacion ?? "";
                lblMascotas.Text = sitio.permiteMascotas ? "Sí" : "No";


                Facilidad facilidad = new Facilidad(); 
                DataTable dtFacilidades = facilidad.ejecutarConsultarFacilidades(idSitio); 
                gvFacilidadesSitio.DataSource = dtFacilidades; 
                gvFacilidadesSitio.DataBind();

            }
            catch (Exception ex)
            {
                lblLimpieza.Text += ex.Message;
                //Response.Redirect("/PaginasPublicas/FormPrincipal.aspx");
                ScriptManager.RegisterStartupScript(this, GetType(), "msg",
                    $"alert('Error al cargar los datos del sitio: {ex.Message}');", true);
            }
        }
        private string ObtenerNombreTipoSitio(int idTipoSitio)
        {
            switch (idTipoSitio)
            {
                case 1:
                    return "Playa";
                case 2:
                    return "Montaña";
                case 3:
                    return "Citadino";
                default:
                    return "Desconocido";
            }
        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Session["rol"] == null || Session["rol"].ToString() != "Cliente")
            {
                Response.Redirect("/PaginasPublicas/FormPrincipal.aspx");
            }

            // Aquí agregas la lógica para registrar al usuario o registrar interés en el sitio
            // Ejemplo:
            Response.Redirect("/PaginasCliente/FormRegistroReserva.aspx?id=" + Request.QueryString["id"]);
            Response.Write("Has registrado tu interés en este sitio.");
        }
    }
}
