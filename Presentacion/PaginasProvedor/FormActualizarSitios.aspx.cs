using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Presentacion.PaginasProvedor
{
    public partial class FormActualizarSitios : System.Web.UI.Page
    {
        int idSitioBuscado=0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarSitio_Click(object sender, EventArgs e)
        {
            idSitioBuscado =Convert.ToInt32(txtIdSitioBuscar.Text);
            Sitio sitio = Sitio.ObtenerPorId(idSitioBuscado);
            CargarDatosEnInterfaz(sitio);


        }

        protected void gvFacilidadesSitio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarFacilidad_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //try
            //{
                Sitio sitio = new Sitio();//Session["idPersona"]
                //sitio.idProvedor = Convert.ToInt32(Session["idPersona"]);

                sitio.operacion = "UPDATE";
                sitio.idSitio =  Convert.ToInt32(txtIdSitioBuscar.Text);
                sitio.idEstado = Convert.ToInt32(dllEstadoSitio.SelectedValue);
                sitio.nombreSitio = txtNombre.Text.Trim();
                sitio.descripcionCorta = txtDescripcionCorta.Text.Trim();
                sitio.descripcionCompleta = txtDescripcion.Text.Trim();
                sitio.TipoSitio = ddlTipoSitio.SelectedValue;
                sitio.provincia = txtProvincia.Text.Trim();
                sitio.canton = txtCanton.Text.Trim();
                sitio.distrito = txtDistrito.Text.Trim();
                sitio.direccionExacta = txtDireccion.Text.Trim();
                sitio.numeroCasa = txtNumeroCasa.Text.Trim();
                sitio.idTipoSitio = Convert.ToInt32(ddlTipoSitio.SelectedValue);
                sitio.numeroHabitaciones = int.Parse(txtHabitaciones.Text);
                sitio.numeroCamas = int.Parse(txtCamas.Text);
                sitio.numeroBanos = int.Parse(txtBanos.Text);
                sitio.personasMaximas = int.Parse(txtPersonasMax.Text);
                sitio.precioPorNoche = int.Parse(txtPrecio.Text);
                sitio.esPorPersona = chkPorPersona.Checked;
                sitio.cargoLimpieza = decimal.Parse(txtLimpieza.Text);
                sitio.depositoSeguridad = decimal.Parse(txtDeposito.Text);
                sitio.minimoNoches = int.Parse(txtMinNoches.Text);
                sitio.politicaCancelacion = txtPolitica.Text;
                sitio.permiteMascotas = chkMascotas.Checked;
                
                DataTable nuevoSitio = sitio.ejecutarConsultaMantenimiento();
                if (nuevoSitio != null && nuevoSitio.Rows.Count > 0)
                {
                    idSitioBuscado = Convert.ToInt32(nuevoSitio.Rows[0]["IdSitio"]);
                    //string codigoSitio = nuevoSitio.Rows[0]["CodigoSitio"].ToString();
                    string mensaje = nuevoSitio.Rows[0]["Mensaje"].ToString();

                    //Console.WriteLine($"ID: {idSitioBuscado}, Código: {codigoSitio}, Mensaje: {mensaje}");
                }
                else
                {
                    throw new ArgumentException("Erros con el registro");
                }
        //    }
            //catch (Exception ex)
            //{
               // string script = $"alert('Error inesperado: {ex.Message.Replace("'", "\\'")}'); window.location='FormPrincipal.aspx';";
                //ClientScript.RegisterStartupScript(this.GetType(), "ErrorReserva", script, true);
            //}

        }
        private DataTable ImagenesSitio
        {
            get
            {
                if (ViewState["ImagenesSitio"] == null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdImagen", typeof(int));
                    dt.Columns.Add("NombreArchivo", typeof(string));
                    dt.Columns.Add("RutaImagen", typeof(string));
                    dt.Columns.Add("EsPrincipal", typeof(bool));
                    dt.Columns.Add("Antigua", typeof(bool));

                    ViewState["ImagenesSitio"] = dt;
                }
                return (DataTable)ViewState["ImagenesSitio"];
            }
            set { ViewState["ImagenesSitio"] = value; }
        }
        private void CargarDatosEnInterfaz(Sitio sitio)
        {
            // 1️⃣ Validar que el objeto sitio exista
            if (sitio == null)
                return;

            // 2️⃣ Validar que la sesión exista
            if (Session == null)
                return;

            // 3️⃣ Validar que la sesión tenga los datos necesarios
            if (Session["idPersona"] == null || Session["rol"] == null)
                return;

            // 4️⃣ Validar que el proveedor o rol sea correcto
            int idPersonaSesion = Convert.ToInt32(Session["idPersona"]);
            string rolSesion = Session["rol"].ToString();

            if (sitio.idProvedor != idPersonaSesion && rolSesion != "Empleado")
            {
                string mensaje = "¡Acceso denegado!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + mensaje + "');", true);
                return;
            }
            




            // Estado y tipo de sitio
            dllEstadoSitio.SelectedValue = sitio.idEstado.ToString();
            ddlTipoSitio.SelectedValue = sitio.idTipoSitio.ToString();
            //ddlSitio.SelectedValue = sitio.TipoSitio ?? "Nuevo";

            // Información general
            txtNombre.Text= sitio.nombreSitio ?? "";
            txtNombre1.Text = sitio.nombreSitio ?? "";
            txtDescripcion.Text = sitio.descripcionCompleta ?? "";
            txtDescripcionCorta.Text = sitio.descripcionCorta ?? "";

            // Ubicación
            txtProvincia.Text = sitio.provincia ?? "";
            txtCanton.Text = sitio.canton ?? "";
            txtDistrito.Text = sitio.distrito ?? "";
            txtDireccion.Text = sitio.direccionExacta ?? "";
            txtNumeroCasa.Text = sitio.numeroCasa ?? "";

            // Detalles del sitio
            txtHabitaciones.Text = sitio.numeroHabitaciones.ToString();
            txtCamas.Text = sitio.numeroCamas.ToString();
            txtBanos.Text = sitio.numeroBanos.ToString();
            txtPersonasMax.Text = sitio.personasMaximas.ToString();
            txtPrecio.Text = (Convert.ToInt32((sitio.precioPorNoche))).ToString();
            chkPorPersona.Checked = sitio.esPorPersona;
            txtLimpieza.Text = sitio.cargoLimpieza.ToString();
            txtDeposito.Text = sitio.depositoSeguridad.ToString();
            txtMinNoches.Text = sitio.minimoNoches.ToString();
            txtPolitica.Text = sitio.politicaCancelacion ?? "";
            chkMascotas.Checked = sitio.permiteMascotas;



            Facilidad facilidad = new Facilidad();
            DataTable dtFacilidades = facilidad.ejecutarConsultarFacilidades(Convert.ToInt32(txtIdSitioBuscar.Text));
            gvFacilidadesSitio.DataSource = dtFacilidades;
            gvFacilidadesSitio.DataBind();
            /*
            // Imagen principal (si la tuvieras en el objeto)
            if (!string.IsNullOrEmpty(sitio.RutaImagenPrincipal))
            {
                imgPrincipal.ImageUrl = sitio.RutaImagenPrincipal;
            }

            // Aquí podrías cargar el GridView de imágenes y facilidades
            gvImagenesSitio.DataSource = sitio.ListaImagenes; // lista de imágenes del sitio
            gvImagenesSitio.DataBind();

            gvFacilidadesSitio.DataSource = sitio.ListaFacilidades; // lista de facilidades
            gvFacilidadesSitio.DataBind();
            */
        }

        protected void gvImagenesSitio_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }
        protected void gvFacilidadesSitio_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = FacilidadesSitio;
            if (dt != null && dt.Rows.Count > e.RowIndex)
            {
                dt.Rows[e.RowIndex].Delete();
                FacilidadesSitio = dt;

                gvFacilidadesSitio.DataSource = dt;
                gvFacilidadesSitio.DataBind();
            }
        }

        private DataTable FacilidadesSitio
        {
            get
            {
                if (ViewState["FacilidadesSitio"] == null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdFacilidad", typeof(int));
                    dt.Columns.Add("NombreFacilidad", typeof(string));
                    dt.Columns.Add("Descripcion", typeof(string));
                    
                    
                    ViewState["FacilidadesSitio"] = dt;
                }
                return (DataTable)ViewState["FacilidadesSitio"];
            }
            set
            {
                ViewState["FacilidadesSitio"] = value;
            }
        }
    }
}