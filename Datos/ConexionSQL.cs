using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class ConexionSQL
    {
        private static SqlConnection conexion;
        private static readonly string CADENA_CONEXION =
        "Server=MSI;Database=SistemaAlquilerVacacional;Integrated Security=True;";

        public static void Conectar()
        {
            try
            {
                conexion = new SqlConnection(CADENA_CONEXION);
                conexion.Open();
                Console.WriteLine("Conexión a SQL Server realizada");
            }
            catch (Exception e)
            {
                throw new Exception($"Error conectando a SQL Server: {e.Message}");
            }
        }

        public static void Cerrar()
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                conexion = null;
                Console.WriteLine("Conexión cerrada");
            }
        }

        public static bool EjecutarSinRetorno(string spName, SqlParameter[] parametros = null)
        {
            using (var conexionLocal = new SqlConnection(CADENA_CONEXION))
            {
                conexionLocal.Open();
                using (var cmd = new SqlCommand(spName, conexionLocal) { CommandType = CommandType.StoredProcedure })
                {
                    try
                    {
                        if (parametros != null)
                            cmd.Parameters.AddRange(parametros);

                        Console.WriteLine("-> " + spName + " <-");

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Aquí puedes loguear el error si quieres
                        Console.WriteLine("Error al ejecutar SP: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public static DataTable EjecutarConRetorno(string spName, SqlParameter[] parametros = null)
        {
            using (var conexionLocal = new SqlConnection(CADENA_CONEXION))
            {
                using (var cmd = new SqlCommand(spName, conexionLocal) { CommandType = CommandType.StoredProcedure })
                {
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    DataTable dtResultado = new DataTable();

                    try
                    {
                        conexionLocal.Open(); // Abrimos la conexión antes de ejecutar
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dtResultado.Load(reader);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Error ejecutando stored procedure: {e.Message}");
                    }

                    return dtResultado;
                }
            }
        }



        public static object EjecutarConRetorno1(string spName, SqlParameter[] parametros = null)
        {
            SqlCommand cmd = null;
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                cmd = new SqlCommand(spName, conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                cmd.ExecuteNonQuery();

                // Retornar valores de parámetros OUT
                var resultados = new System.Collections.Generic.List<object>();
                foreach (SqlParameter p in cmd.Parameters)
                {
                    if (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.InputOutput)
                        resultados.Add(p.Value);
                }

                return resultados;
            }
            catch (Exception e)
            {
                throw new Exception($"Error ejecutando stored procedure: {e.Message}");
            }
            finally
            {
                cmd?.Dispose();
            }
        }
    }
}
