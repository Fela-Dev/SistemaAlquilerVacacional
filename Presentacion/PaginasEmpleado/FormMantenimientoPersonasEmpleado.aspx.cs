using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.PaginasEmpleado
{
    public partial class FormMantenimientoPersonasEmpleado : System.Web.UI.Page
    {
        int idPersona;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ddlEstadoPersona.SelectedValue = "1"; // Activo por defecto
        }

        protected void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            txtFecha.Attributes["max"] = DateTime.Parse("2025-12-12").ToString("yyyy-MM-dd");
            idPersona = Convert.ToInt32(txtBuscarIdentificacion.Text);
            Persona persona = Persona.ObtenerPorId(idPersona);
            LoginObj login = new LoginObj();

            if (persona != null)
            {
                /*
                txtUsuario.Text = Session["Usuario"].ToString();
                txtContra.Text = Session["contra"].ToString();
                */
                txtPrimerNombre.Text = persona.PrimerNombre;
                txtSegundoNombre.Text = persona.SegundoNombre;
                txtPrimerApellido.Text = persona.PrimerApellido;
                txtSegundoApellido.Text = persona.SegundoApellido;
                txtEmailPrincipal.Text = persona.CorreoElectronicoPrincipal;
                txtEmailSecundario.Text = persona.CorreoElectronicoSecundario;
                txtTelefonoPrincipal.Text = persona.TelefonoPrincipal;
                txtTelefonoSecundario.Text = persona.TelefonoSecundario;
                txtProvincia.Text = persona.Provincia;
                txtCanton.Text = persona.Canton;
                txtDistrito.Text = persona.Distrito;
                txtDireccionExacta.Text = persona.DireccionExacta;
                txtNumeroIdentificacion.Text = persona.NumeroIdentificacion;
                txtNacionalidad.Text = persona.Nacionalidad;
                ddlGenero.DataValueField = persona.Genero;
                txtFecha.Text = persona.FechaNacimiento?.ToString("yyyy-MM-dd") ?? "";
                txtCodigoPostal.Text = persona.CodigoPostal;

                ddlEstadoPersona.SelectedValue = persona.IdEstado.ToString();

                txtUsuario.Text = persona.usuario;
                txtContra.Text = persona.contrasena;
            }
        }
        

        protected void btnGuardar_Click(object sender, EventArgs e)
        {



            Persona persona = new Persona();
            persona.operacion = "UPDATE";//'INSERT'
            persona.IdPersona = Convert.ToInt32(txtBuscarIdentificacion.Text);
            //persona.IdTipoPersona = Session["rol"].ToString();
            persona.IdEstado = 1;
            persona.PrimerNombre = txtPrimerNombre.Text;
            persona.SegundoNombre = txtSegundoNombre.Text;
            persona.PrimerApellido = txtPrimerApellido.Text;
            persona.SegundoApellido = txtSegundoApellido.Text;
            persona.Genero = ddlGenero.SelectedValue.Substring(0, 1);
            persona.FechaNacimiento = DateTime.Parse(txtFecha.Text);

            persona.TipoIdentificacion = ddlTipoIdentificacion.SelectedValue;
            persona.NumeroIdentificacion = txtNumeroIdentificacion.Text;
            persona.Nacionalidad = txtNacionalidad.Text;

            persona.TelefonoPrincipal = txtTelefonoPrincipal.Text;
            persona.TelefonoSecundario = txtTelefonoSecundario.Text;
            persona.CorreoElectronicoPrincipal = txtEmailPrincipal.Text;
            persona.CorreoElectronicoSecundario = txtEmailSecundario.Text;

            persona.Provincia = txtProvincia.Text;
            persona.Canton = txtCanton.Text;
            persona.Distrito = txtDistrito.Text;
            persona.DireccionExacta = txtDireccionExacta.Text;
            persona.CodigoPostal = txtCodigoPostal.Text;
            persona.IdEstado = Convert.ToInt32(ddlEstadoPersona.SelectedValue);




            try
            {
                DataTable resultado = persona.ejecutarConsulta();

                if (resultado != null && resultado.Rows.Count > 0)
                {
                    int idPersona = Convert.ToInt32(resultado.Rows[0]["IdPersona"]);
                    string mensaje = resultado.Rows[0]["Mensaje"].ToString();

                    if (idPersona > 0)
                    {
                        string script = $"alert('{mensaje.Replace("'", "\\'")}'); window.location='FormPrincipal.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "ExitoPersona", script, true);
                    }
                    else
                    {
                        string script = $"alert('No se pudo actualizar la persona.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorPersona", script, true);
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Funcionario actualizado exitofsfdcccccccccccccccccccccccccccsfdsfsdfsfsamente');", true);
                }
                else
                {
                    string script = $"alert('No se obtuvo respuesta del servidor.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "SinRespuesta", script, true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Funcionario actualizado exitosamente');", true);
                string script = $"alert('Error: {ex.Message.Replace("'", "\\'")}');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorGeneral", script, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}