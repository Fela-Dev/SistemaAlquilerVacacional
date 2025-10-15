
using Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Presentacion.PaginasProvedor
{
    public partial class FormMantenimientoSitio : System.Web.UI.Page
    {
        int idSitio = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvFacilidadesSitio.DataSource = FacilidadesSitio;
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
                    dt.Columns.Add("TieneFacilidad", typeof(bool));

                    ViewState["FacilidadesSitio"] = dt;
                }
                return (DataTable)ViewState["FacilidadesSitio"];
            }
            set
            {
                ViewState["FacilidadesSitio"] = value;
            }
        }



        // Guardar Sitio y sus facilidades
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Sitio sitio = new Sitio();
                sitio.idProvedor = Convert.ToInt32(Session["idPersona"]);

                sitio.operacion = "INSERT";
                sitio.idSitio = 0;
                sitio.idEstado = Convert.ToInt32(dllEstadoSitio.SelectedValue);
                sitio.nombreSitio = txtNombre1.Text.Trim();
                sitio.descripcionCorta = txtDescripcionCorta.Text.Trim();
                sitio.descripcionCompleta = txtDescripcion.Text.Trim();
                sitio.TipoSitio = ddlSitio.SelectedValue;
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

                
                // Guardar el sitio
                DataTable nuevoSitio =sitio.ejecutarConsultaMantenimiento();
                if (nuevoSitio != null && nuevoSitio.Rows.Count > 0)
                {
                    idSitio = Convert.ToInt32(nuevoSitio.Rows[0]["IdSitio"]);
                    string codigoSitio = nuevoSitio.Rows[0]["CodigoSitio"].ToString();
                    string mensaje = nuevoSitio.Rows[0]["Mensaje"].ToString();

                    Console.WriteLine($"ID: {idSitio}, Código: {codigoSitio}, Mensaje: {mensaje}");
                }
                else
                {
                    throw new ArgumentException("Erros con el registro");
                }

                // Guardar las facilidades
                DataTable dtFacilidades = FacilidadesSitio;
                if(idSitio==0)
                {
                    throw new ArgumentException("Error al ibnsertar sitio");
                }
                foreach (DataRow fila in dtFacilidades.Rows)
                {
                    Facilidad f = new Facilidad();
                    f.Operacion = "INSERT";
                    f.IdFacilidad = Convert.ToInt32(fila["IdFacilidad"]);
                    f.IdSitio = idSitio; // Asignamos el id generado del sitio
                    f.NombreFacilidad = fila["NombreFacilidad"].ToString();
                    f.Descripcion = fila["Descripcion"].ToString();
                    f.TieneFacilidad = Convert.ToBoolean(fila["TieneFacilidad"]);
                    f.ejecutarConsultaMantenimiento();
                }

                // Limpiar campos y grid
                FacilidadesSitio = null;
                gvFacilidadesSitio.DataSource = null;
                gvFacilidadesSitio.DataBind();

                txtNombreFacilidad.Text = "";
                txtDescripcionFacilidad.Text = "";
                chkTieneFacilidad.Checked = false;

                // Mensaje al usuario
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Sitio y facilidades guardadas correctamente.');", true);

               
            }
            catch (Exception ex)
            {
                string script = $"alert('Error inesperado: {ex.Message.Replace("'", "\\'")}'); window.location='FormPrincipal.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(    ), "ErrorReserva", script, true);
            }
            try
            {
                // ID del sitio recién guardado
                //int idSitio = Convert.ToInt32(Session["IdSitioRecienGuardado"]);

                // Recuperar la lista temporal de imágenes
                DataTable dt = ImagenesSitio;

                if (dt == null || dt.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No hay imágenes para guardar.');", true);
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    string nombreArchivo = row["RutaImagen"].ToString(); // solo el nombre
                    string rutaFisica = Server.MapPath("~/"+ nombreArchivo);

                    if (!File.Exists(rutaFisica))
                    {
                        throw new FileNotFoundException("No se encontró la imagen en el servidor: " + rutaFisica+"=="+nombreArchivo);
                    }

                    Foto foto = new Foto()
                    {
                        Operacion = "INSERT",
                        IdSitio = idSitio,
                        RutaArchivo = rutaFisica,
                        EsPrincipal = Convert.ToBoolean(row["EsPrincipal"]),
                        Descripcion = row.Table.Columns.Contains("Descripcion") ? row["Descripcion"].ToString() : ""
                    };

                    // Renombrar la imagen para evitar colisiones
                    foto.MoverYRenombrarImagen(); // 

                    // Guardar en BD
                    foto.ejecutarConsultaMantenimiento();
                }

                ClientScript.RegisterStartupScript(this.GetType(), "ok", "alert('Todas las imágenes se guardaron correctamente.');", true);
            }
            catch (Exception ex)
            {
                string script = $"alert('Error inesperado: {ex.Message.Replace("'", "\\'")}');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorReserva", script, true);
                lblLimpieza.Text = ex.ToString();
            }


        }

        // Agregar facilidad temporal al DataTable
        protected void btnAgregarFacilidad_Click(object sender, EventArgs e)
        {
            DataTable dt = FacilidadesSitio;

            int nextId = dt.Rows.Count > 0 ? dt.AsEnumerable().Max(r => r.Field<int>("IdFacilidad")) + 1 : 1;

            DataRow dr = dt.NewRow();
            dr["IdFacilidad"] = nextId;
            dr["NombreFacilidad"] = txtNombreFacilidad.Text.Trim();
            dr["Descripcion"] = txtDescripcionFacilidad.Text.Trim();
            dr["TieneFacilidad"] = chkTieneFacilidad.Checked;

            dt.Rows.Add(dr);
            FacilidadesSitio = dt;

            gvFacilidadesSitio.DataSource = dt;
            gvFacilidadesSitio.DataBind();

            txtNombreFacilidad.Text = "";
            txtDescripcionFacilidad.Text = "";
            chkTieneFacilidad.Checked = false;


        }

        // Eliminar facilidad temporal
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
        // DataTable temporal en ViewState
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

                    ViewState["ImagenesSitio"] = dt;
                }
                return (DataTable)ViewState["ImagenesSitio"];
            }
            set { ViewState["ImagenesSitio"] = value; }
        }

        // Agregar imagen temporal
        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado un archivo
            if (!fuImagen.HasFile)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor seleccione una imagen.');", true);
                return;
            }

            // Guardar la imagen en una carpeta del servidor
            string carpetaDestino = Server.MapPath("/Imagenes/CarpetaTemporal/");
            string nombreArchivo = Path.GetFileName(fuImagen.FileName);
            string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);
            fuImagen.SaveAs(rutaCompleta);

            // Guardar los datos en el DataTable temporal
            DataTable dt = ImagenesSitio;
            int nextId = dt.Rows.Count > 0 ? dt.AsEnumerable().Max(r => r.Field<int>("IdImagen")) + 1 : 1;

            DataRow dr = dt.NewRow();
            dr["IdImagen"] = nextId;
            dr["RutaImagen"] = "/Imagenes/CarpetaTemporal/" + nombreArchivo;
            dr["EsPrincipal"] = chkEsPrincipal.Checked;

            dt.Rows.Add(dr);
            ImagenesSitio = dt;

            gvImagenesSitio.DataSource = dt;
            gvImagenesSitio.DataBind();

            chkEsPrincipal.Checked = false;

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Imagen agregada correctamente.');", true);
        }





        // Eliminar imagen temporal
        protected void gvImagenesSitio_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = ImagenesSitio;
            if (dt != null && dt.Rows.Count > e.RowIndex)
            {
                dt.Rows[e.RowIndex].Delete();
                ImagenesSitio = dt;

                gvImagenesSitio.DataSource = dt;
                gvImagenesSitio.DataBind();
            }
        }
        protected void btnProbarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                // Supongamos que ya tienes el ID del sitio creado
                int idSitio = 1; // Cambialo por el real o el que devuelva tu SP al guardar el sitio

                // Ruta absoluta de la imagen que querés probar
                string rutaOrigen = @"D:\Descargas\SI202201200054_news-scaled.jpg";


                // Crear el objeto Foto
                Foto foto = new Foto()
                {
                    Operacion = "INSERT",
                    IdSitio = idSitio,
                    RutaArchivo = rutaOrigen,
                    EsPrincipal = true,
                    Descripcion = "Imagen de prueba del sitio"
                };

                // Mover y renombrar la imagen al directorio del proyecto
                foto.MoverYRenombrarImagen();

                // Guardar en base de datos usando el SP
                DataTable resultado = foto.ejecutarConsultaMantenimiento();

                if (resultado != null && resultado.Rows.Count > 0)
                {
                    string mensaje = resultado.Rows[0]["Mensaje"].ToString();
                    string script = $"alert('Error inesperado: {mensaje.Replace("'", "\\'")}'); window.location='FormPrincipal.aspx';";
                    ClientScript.RegisterStartupScript(this.GetType(), "ErrorReserva", script, true);

                }
            }
            catch (Exception ex)
            {
                string script = $"alert('Error inesperado: {ex.Message.Replace("'", "\\'")}'); window.location='FormPrincipal.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorReserva", script, true);
            }
        }










        protected void gvFacilidadesSitio_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}