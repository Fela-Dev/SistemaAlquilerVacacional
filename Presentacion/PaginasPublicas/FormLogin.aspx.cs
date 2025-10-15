using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
namespace Presentacion.PaginasPublicas
{
    public partial class FormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginObj loginControl = new LoginObj();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            LoginObj loginControl = new LoginObj();
            loginControl.UserName = txtUsuario.Text;
            loginControl.Password = txtPassword.Text;

            dt = loginControl.ejecutarConsultaAuntenticacion();

            if (dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
                string status = fila["Status"].ToString();
                string mensaje = fila["Mensaje"].ToString();
                
                if (status == "OK")
                {
                    // Asigna rol desde la BD
                    string rol = fila["Rol"].ToString(); // Ejemplo: Clientes, Proveedores, Empleados
                    int idPersona = Convert.ToInt32(fila["IDPersona"]);
                    int idUsuario = Convert.ToInt32(fila["IDUsuario"]);
                    String usuario = (fila["Usuario"].ToString());
                    String contra = (fila["contraa"].ToString());//contra
                    // Guarda el rol y usuario en la sesión
                    Session["rol"] = rol;
                    Session["usuario"] = txtUsuario.Text;
                    Session["idPersona"] = idPersona;
                    Session["IDUsuario"] = idUsuario;
                    Session["Usuario"] = usuario;
                    Session["contra"] = contra;
                    // Muestra alerta con el mensaje y el rol
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert1",
                        $"alert('{mensaje+idPersona} - Rol: {rol.Replace("'", "\\'")}');", true);

                    // Redirige a la página principal general
                    Response.Redirect("~/PaginasPublicas/FormPrincipal.aspx");
                }
                else if (status == "ERROR")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert2",
                        $"alert('{mensaje.Replace("'", "\\'")}');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert3",
                        "alert('Error desconocido');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert4",
                    "alert('Usuario o contraseña incorrectos');", true);
            }
        }

    }
}
/*
 * 
 * 
 * protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            int id = 0;
            try
            {
                lblError.Text = "";
                bool valido = false;

                if (Login1.UserName == "admin" && Login1.Password == "admin")
                {
                    valido = true;

                    //
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        Login1.UserName,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        true,
                        "RRHH"
                    );
                }
                else
                {
                    foreach (var login in logicaLo.ListaLogin())
                    {
                        if (Login1.UserName == login.Correo && Login1.Password == login.Contra)
                        {
                            valido = true;
                            id=login.Id;
                            break;
                        }
                    }
                }

                
                if (valido)
                {
                    // Crear el ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        Login1.UserName,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        true,
                        "1" 
                    );

                    
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    authCookie.Path = FormsAuthentication.FormsCookiePath;
                    Response.Cookies.Add(authCookie);

                    
                    Session["rol"] = ObtenerRol(id);
                    Session["id"] =id;
                    
                    Response.Redirect("~/PaginasPri/frmMain.aspx");

                }

            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
        }
        public String ObtenerRol(int id)
        {
            String rol;
            LogicaFuncionario logicaFuncionario = new LogicaFuncionario();
            Funcionario funcionario = new Funcionario();
            funcionario=logicaFuncionario.ObtenerFuncionarioPorId(id);

            rol = funcionario.Departamento;
            return rol;
        }



        public void ObtenerFuncionario()
        {

        }
    }
}
 * 
 * 
 * 
 */