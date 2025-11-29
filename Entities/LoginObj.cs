using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoginObj
    {
        public String operacion { get; set; }
        public int IdUsuario { get; set; }
        public string IdPersona { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int UsuarioCreador { get; set; }

        public SqlParameter[] listaAtributos()
        {
            IdUsuario = 0;
            Salt = "zzz";
            PasswordHash = "zzz";
            return new SqlParameter[] {
                new SqlParameter("@Operacion",operacion),
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@NombreUsuario", UserName ?? (object)DBNull.Value),
                new SqlParameter("@Password_Temp", Password ?? (object)DBNull.Value),
                new SqlParameter("@PasswordHash",PasswordHash ?? (object)DBNull.Value),
                //new SqlParameter("@Salt", Salt ?? (object)DBNull.Value),
                //new SqlParameter("@UsuarioCreador", UsuarioCreador)
            };


            /*
             *  @Operacion NVARCHAR(10), -- 'INSERT', 'UPDATE', 'DELETE'
        @IdUsuario INT = NULL,
        @IdPersona INT = NULL,
        @NombreUsuario NVARCHAR(50) = NULL,
        @PasswordHash NVARCHAR(255) = NULL,
        @Salt NVARCHAR(100) = NULL,
        @UsuarioCreador INT = NULL
                */
        }
        public DataTable ejecutarConsultaMantenimiento()
        {
            SqlParameter[] lista = listaAtributos();
            return Datos.ConexionSQL.EjecutarConRetorno("sp_MantenimientoUsuariosSistema_Temporal", lista);
        }
        public DataTable ejecutarConsultaAuntenticacion()
        {
            SqlParameter[] lista = new SqlParameter[] {
                new SqlParameter("@NombreUsuario", UserName),
                new SqlParameter("@Password_Temp", Password)
            };//lista con las datos del form
            return Datos.ConexionSQL.EjecutarConRetorno("sp_AutenticarUsuario_Temporal", lista);
        }
        public void VerificarUsuarioUnico()
        {
            SqlParameter[] lista = new SqlParameter[]
            {
        new SqlParameter("@usuario", UserName)
            };

            DataTable dt = Datos.ConexionSQL.EjecutarConRetorno("sp_usuario_unico", lista);

            if (dt.Rows.Count > 0)
            {
                int cantidad = Convert.ToInt32(dt.Rows[0]["cantidad"]);

                if (cantidad > 0)
                {
                    // Usuario ya existe → lanzamos una excepción controlada
                    throw new Exception("Nombre de usuario inválido: ya está en uso.");
                }
            }
            else
            {
                throw new Exception("Error al verificar la unicidad del usuario.");
            }
        }

        /*
         * ALTER procedure [dbo].[sp_usuario_unico](
	@usuario varchar(200)
)
as
begin	
	select
		count(UsuariosSistema.NombreUsuario) as[cantidad]
	from UsuariosSistema
	where NombreUsuario=@usuario 
end
         * 
         * 
         * 
         */
    }
}
