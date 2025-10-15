using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Entities
{
    public class Persona
    {
        //para sql
        public String operacion { get; set; }//insert, update, delete
        
        public int IdPersona { get; set; }
        public int IdEstado { get; set; } // Activo, Inactivo, Suspendido
        public String IdTipoPersona { get; set; } // Cliente, Proveedor, Empleado, etc.

        // Identificador persona
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nacionalidad { get; set; }

        // Datos personales
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Genero { get; set; } // M F O
        public DateTime? FechaNacimiento { get; set; } 

        // Datos de contacto
        public string TelefonoPrincipal { get; set; }
        public string TelefonoSecundario { get; set; }
        public string CorreoElectronicoPrincipal { get; set; }
        public string CorreoElectronicoSecundario { get; set; }

        // Dirección
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string DireccionExacta { get; set; }
        public string CodigoPostal { get; set; }
        
        public string usuario { get; set; }
        public string contrasena { get; set; }

        public int idUsuario { get; set; }  
        // Auditoría
        //fin atributos

        public SqlParameter[] ListaAtributos()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Operacion", operacion ?? (object)DBNull.Value),
                new SqlParameter("@IdPersona", IdPersona),
                new SqlParameter("@IdEstado", IdEstado),
                new SqlParameter("@TipoPersona", IdTipoPersona ?? (object)DBNull.Value),
                new SqlParameter("@TipoIdentificacion", TipoIdentificacion ?? (object)DBNull.Value),
                new SqlParameter("@NumeroIdentificacion", NumeroIdentificacion ?? (object)DBNull.Value),
                new SqlParameter("@Nacionalidad", Nacionalidad ?? (object)DBNull.Value),
                new SqlParameter("@PrimerNombre", PrimerNombre ?? (object)DBNull.Value),
                new SqlParameter("@SegundoNombre", SegundoNombre ?? (object)DBNull.Value),
                new SqlParameter("@PrimerApellido", PrimerApellido ?? (object)DBNull.Value),
                new SqlParameter("@SegundoApellido", SegundoApellido ?? (object)DBNull.Value),
                new SqlParameter("@FechaNacimiento", FechaNacimiento),
                new SqlParameter("@Genero", Genero ?? (object)DBNull.Value),
                new SqlParameter("@TelefonoPrincipal", TelefonoPrincipal ?? (object)DBNull.Value),
                new SqlParameter("@TelefonoSecundario", TelefonoSecundario ?? (object)DBNull.Value),
                new SqlParameter("@EmailPrincipal", CorreoElectronicoPrincipal ?? (object)DBNull.Value),
                new SqlParameter("@EmailSecundario", CorreoElectronicoSecundario ?? (object)DBNull.Value),
                new SqlParameter("@Provincia", Provincia ?? (object)DBNull.Value),
                new SqlParameter("@Canton", Canton ?? (object)DBNull.Value),
                new SqlParameter("@Distrito", Distrito ?? (object)DBNull.Value),
                new SqlParameter("@DireccionExacta", DireccionExacta ?? (object)DBNull.Value),
                new SqlParameter("@CodigoPostal", CodigoPostal ?? (object)DBNull.Value)
                    };
        }
        public DataTable ejecutarConsulta()
        {
            SqlParameter[] lista = ListaAtributos();
            return Datos.ConexionSQL.EjecutarConRetorno("sp_MantenimientoPersonas", lista);

        }
        public static Persona ObtenerPorId(int idPersona)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter("@IdPersona", idPersona)
                };

                DataTable dt = Datos.ConexionSQL.EjecutarConRetorno("SP_CONSULTAR_DATOS_PERSONA", parametros);

                if (dt.Rows.Count == 0)
                    return null; // No se encontró ninguna persona con ese ID

                DataRow row = dt.Rows[0];

                Persona persona = new Persona
                {
                    IdPersona = idPersona,
                    IdEstado = row["IdEstado"] != DBNull.Value ? Convert.ToInt32(row["IdEstado"]) : 0,
                    IdTipoPersona = row["TipoPersona"]?.ToString(),
                    TipoIdentificacion = row["TipoIdentificacion"]?.ToString(),
                    NumeroIdentificacion = row["NumeroIdentificacion"]?.ToString(),
                    Nacionalidad = row["Nacionalidad"]?.ToString(),
                    PrimerNombre = row["PrimerNombre"]?.ToString(),
                    SegundoNombre = row["SegundoNombre"]?.ToString(),
                    PrimerApellido = row["PrimerApellido"]?.ToString(),
                    SegundoApellido = row["SegundoApellido"]?.ToString(),
                    Genero = row["Genero"]?.ToString(),
                    FechaNacimiento = row["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(row["FechaNacimiento"]) : (DateTime?)null,
                    TelefonoPrincipal = row["TelefonoPrincipal"]?.ToString(),
                    TelefonoSecundario = row["TelefonoSecundario"]?.ToString(),
                    CorreoElectronicoPrincipal = row["EmailPrincipal"]?.ToString(),
                    CorreoElectronicoSecundario = row["EmailSecundario"]?.ToString(),
                    Provincia = row["Provincia"]?.ToString(),
                    Canton = row["Canton"]?.ToString(),
                    Distrito = row["Distrito"]?.ToString(),
                    DireccionExacta = row["DireccionExacta"]?.ToString(),
                    CodigoPostal = row["CodigoPostal"]?.ToString(),
                    usuario = row["NombreUsuario"]?.ToString(),
                    contrasena = row["Password_Temp"]?.ToString(),
                    idUsuario = row["IdUsuario"] != DBNull.Value ? Convert.ToInt32(row["IdUsuario"]) : 0
                };

                return persona;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos de la persona: " + ex.Message);
            }
        }





        /*
        @Operacion NVARCHAR(10), -- 'INSERT', 'UPDATE', 'DELETE'
        @IdPersona INT = NULL,
        @IdEstado INT = NULL,
        @TipoPersona NVARCHAR(10) = NULL,
        @TipoIdentificacion NVARCHAR(15) = NULL,
        @NumeroIdentificacion NVARCHAR(50) = NULL,
        @Nacionalidad NVARCHAR(50) = NULL,
        @PrimerNombre NVARCHAR(50) = NULL,
        @SegundoNombre NVARCHAR(50) = NULL,
        @PrimerApellido NVARCHAR(50) = NULL,
        @SegundoApellido NVARCHAR(50) = NULL,
        @FechaNacimiento DATE = NULL,
        @Genero NCHAR(1) = NULL,
        @TelefonoPrincipal NVARCHAR(20) = NULL,
        @TelefonoSecundario NVARCHAR(20) = NULL,
        @EmailPrincipal NVARCHAR(150) = NULL,
        @EmailSecundario NVARCHAR(150) = NULL,
        @Provincia NVARCHAR(50) = NULL,
        @Canton NVARCHAR(50) = NULL,
        @Distrito NVARCHAR(50) = NULL,
        @DireccionExacta NVARCHAR(300) = NULL,
        @CodigoPostal NVARCHAR(10) = NULL
        */
        // public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }

}
