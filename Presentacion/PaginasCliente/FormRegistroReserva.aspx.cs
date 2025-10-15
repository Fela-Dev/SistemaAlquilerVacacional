using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Datos;
namespace Presentacion.PaginasCliente
{
    public partial class FormRegistroReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validar sesión de cliente
            if (Session["idPersona"] == null || Session["rol"] == null || Session["rol"].ToString() != "Cliente")
            {
                Response.Redirect("~/PaginasPublicas/FormLogin.aspx");
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Captura de datos
                int idCliente = Convert.ToInt32(Session["idPersona"]); // o valor de prueba
                int usuarioRegistra = 1019; // puedes ajustarlo
                int idSitio = Convert.ToInt32(Request.QueryString["id"]);
                DateTime fechaInicio = calFechaInicio.SelectedDate;
                DateTime fechaFin = calFechaFin.SelectedDate;

                int adultos = string.IsNullOrEmpty(txtAdultos.Text) ? 0 : int.Parse(txtAdultos.Text);
                int ninos = string.IsNullOrEmpty(txtNinos.Text) ? 0 : int.Parse(txtNinos.Text);
                int bebes = string.IsNullOrEmpty(txtBebes.Text) ? 0 : int.Parse(txtBebes.Text);
                string solicitudes = txtSolicitudes.Text;
                string telefono = txtTelefono.Text;

                // Crear lista de parámetros
                SqlParameter[] listaParametros = new SqlParameter[]
                {
            new SqlParameter("@IdCliente", idCliente),
            new SqlParameter("@IdSitio", idSitio),
            new SqlParameter("@FechaInicio", fechaInicio),
            new SqlParameter("@FechaFin", fechaFin),
            new SqlParameter("@CantidadAdultos", adultos),
            new SqlParameter("@CantidadNinos", ninos),
            new SqlParameter("@CantidadBebes", bebes),
            new SqlParameter("@SolicitudesEspeciales", (object)solicitudes ?? DBNull.Value),
            new SqlParameter("@TelefonoContacto", (object)telefono ?? DBNull.Value),
            new SqlParameter("@UsuarioQueRegistra", usuarioRegistra)
                };

                // Ejecutar SP y obtener resultados
                DataTable dt = Datos.ConexionSQL.EjecutarConRetorno("sp_CrearReserva", listaParametros);

                if (dt.Rows.Count > 0)
                {
                    string mensaje = dt.Rows[0]["Mensaje"].ToString();
                    int idReserva = Convert.ToInt32(dt.Rows[0]["IdReserva"]);

                    if (idReserva > 0)
                    {
                        // Éxito
                        string script = $"alert('{mensaje.Replace("'", "\\'")}'); window.location='FormPrincipal.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "ExitoReserva", script, true);
                    }
                    else
                    {
                        // Error del SP
                        string script = $"alert('Error: {mensaje.Replace("'", "\\'")}'); window.location='FormPrincipal.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorReserva", script, true);
                    }
                }
                else
                {
                    // Ningún resultado devuelto
                    string script = "alert('Error: No se obtuvo respuesta del servidor.'); window.location='FormPrincipal.aspx';";
                    ClientScript.RegisterStartupScript(this.GetType(), "ErrorReserva", script, true);
                }
            }
            catch (Exception ex)
            {
                // Error inesperado de C#
                string script = $"alert('Error inesperado: {ex.Message.Replace("'", "\\'")}'); window.location='FormPrincipal.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorReserva", script, true);
            }
        }

    }
}

