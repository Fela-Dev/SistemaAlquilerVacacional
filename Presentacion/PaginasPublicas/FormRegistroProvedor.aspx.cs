using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.PaginasPublicas
{
    public partial class FormRegistroProvedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            

            Persona persona = new Persona();
            persona.operacion = "INSERT";//'INSERT'
            persona.IdTipoPersona = "Cliente";
            persona.IdEstado = 1;
            persona.IdPersona = 0;
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

            //ejecutar el sp
            persona.ejecutarConsulta();

            LoginObj loginObj = new LoginObj();
            loginObj.UserName = txtUsuario.Text;
            loginObj.Password = txtContra.Text;
            loginObj.IdPersona = txtNumeroIdentificacion.Text;
            loginObj.operacion = "INSERT";
            loginObj.ejecutarConsultaMantenimiento();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Funcionario actualizado exitosamente');", true);
        }
    }
}