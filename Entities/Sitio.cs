using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sitio
    {
        public string operacion { get; set; }
        public int idProvedor { get; set; }
        public int idSitio { get; set; }
        public int idTipoSitio { get; set; }
        public int idEstado { get; set; }
        public string codigoSitio { get; set; }
        public string nombreSitio { get; set; }
        public string descripcionCorta { get; set; }
        public string descripcionCompleta { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string direccionExacta { get; set; }
        public string numeroCasa { get; set; }
        public int numeroHabitaciones { get; set; }
        public int numeroCamas { get; set; }
        public int numeroBanos { get; set; }
        public int personasMaximas { get; set; }
        public decimal precioPorNoche { get; set; }
        public bool esPorPersona { get; set; }
        public decimal cargoLimpieza { get; set; }
        public decimal depositoSeguridad { get; set; }
        public int minimoNoches { get; set; }
        public string politicaCancelacion { get; set; }
        public bool permiteMascotas { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaUltimaModificacion { get; set; }

        // Propiedades adicionales que usas en la UI
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string HorarioAtencion { get; set; }
        public string TipoSitio { get; set; }

        public string FotoPrincipal {  get; set; }
        public SqlParameter[] listaAtributos()
        {
            return new SqlParameter[]
            {
        new SqlParameter("@Operacion", operacion),
        new SqlParameter("@IdSitio", idSitio),
        new SqlParameter("@IdProveedor", idProvedor),
        new SqlParameter("@IdTipoSitio", idTipoSitio),
        new SqlParameter("@IdEstado", idEstado),
        //new SqlParameter("@CodigoSitio", codigoSitio ?? (object)DBNull.Value),
        new SqlParameter("@NombreSitio", nombreSitio ?? (object)DBNull.Value),
        new SqlParameter("@DescripcionCorta", descripcionCorta ?? (object)DBNull.Value),
        new SqlParameter("@DescripcionCompleta", descripcionCompleta ?? (object)DBNull.Value),
        new SqlParameter("@Provincia", provincia ?? (object)DBNull.Value),
        new SqlParameter("@Canton", canton ?? (object)DBNull.Value),
        new SqlParameter("@Distrito", distrito ?? (object)DBNull.Value),
        new SqlParameter("@DireccionExacta", direccionExacta ?? (object)DBNull.Value),
        new SqlParameter("@NumeroCasa", numeroCasa ?? (object)DBNull.Value),
        new SqlParameter("@NumeroHabitaciones", numeroHabitaciones),
        new SqlParameter("@NumeroCamas", numeroCamas),
        new SqlParameter("@NumeroBanos", numeroBanos),
        new SqlParameter("@PersonasMaximas", personasMaximas),
        new SqlParameter("@PrecioPorNoche", precioPorNoche),
        new SqlParameter("@EsPorPersona", esPorPersona),
        new SqlParameter("@CargoLimpieza", cargoLimpieza),
        new SqlParameter("@DepositoSeguridad", depositoSeguridad),
        new SqlParameter("@MinimoNoches", minimoNoches),
        new SqlParameter("@PoliticaCancelacion", politicaCancelacion ?? (object)DBNull.Value),
        new SqlParameter("@PermiteMascotas", permiteMascotas)
            };
        }
        public DataTable ejecutarConsultaMantenimiento()
        {
            SqlParameter[] lista = listaAtributos();
            return Datos.ConexionSQL.EjecutarConRetorno("sp_MantenimientoSitios", lista);
        }
        public static Sitio ObtenerPorId(int idSitio)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter("@IdSitio", idSitio)
                };

                // Asumiendo que tienes un SP tipo "SP_CONSULTAR_DATOS_SITIO"
                DataTable dt = Datos.ConexionSQL.EjecutarConRetorno("SP_CONSULTAR_DATOS_SITIO", parametros);

                if (dt.Rows.Count == 0)
                    return null; // No se encontró ningún sitio con ese ID

                DataRow row = dt.Rows[0];

                Sitio sitio = new Sitio
                {
                    idSitio = idSitio,
                    idProvedor = row["IdProveedor"] != DBNull.Value ? Convert.ToInt32(row["IdProveedor"]) : 0,
                    idTipoSitio = row["IdTipoSitio"] != DBNull.Value ? Convert.ToInt32(row["IdTipoSitio"]) : 0,
                    idEstado = row["IdEstado"] != DBNull.Value ? Convert.ToInt32(row["IdEstado"]) : 0,
                    nombreSitio = row["NombreSitio"]?.ToString(),
                    descripcionCorta = row["DescripcionCorta"]?.ToString(),
                    descripcionCompleta = row["DescripcionCompleta"]?.ToString(),
                    provincia = row["Provincia"]?.ToString(),
                    canton = row["Canton"]?.ToString(),
                    distrito = row["Distrito"]?.ToString(),
                    direccionExacta = row["DireccionExacta"]?.ToString(),
                    numeroCasa = row["NumeroCasa"]?.ToString(),
                    numeroHabitaciones = row["NumeroHabitaciones"] != DBNull.Value ? Convert.ToInt32(row["NumeroHabitaciones"]) : 0,
                    numeroCamas = row["NumeroCamas"] != DBNull.Value ? Convert.ToInt32(row["NumeroCamas"]) : 0,
                    numeroBanos = row["NumeroBanos"] != DBNull.Value ? Convert.ToInt32(row["NumeroBanos"]) : 0,
                    personasMaximas = row["PersonasMaximas"] != DBNull.Value ? Convert.ToInt32(row["PersonasMaximas"]) : 0,
                    precioPorNoche = row["PrecioPorNoche"] != DBNull.Value ? Convert.ToDecimal(row["PrecioPorNoche"]) : 0,
                    esPorPersona = row["EsPorPersona"] != DBNull.Value ? Convert.ToBoolean(row["EsPorPersona"]) : false,
                    cargoLimpieza = row["CargoLimpieza"] != DBNull.Value ? Convert.ToDecimal(row["CargoLimpieza"]) : 0,
                    depositoSeguridad = row["DepositoSeguridad"] != DBNull.Value ? Convert.ToDecimal(row["DepositoSeguridad"]) : 0,
                    minimoNoches = row["MinimoNoches"] != DBNull.Value ? Convert.ToInt32(row["MinimoNoches"]) : 0,
                    politicaCancelacion = row["PoliticaCancelacion"]?.ToString(),
                    permiteMascotas = row["PermiteMascotas"] != DBNull.Value ? Convert.ToBoolean(row["PermiteMascotas"]) : false,
                };

                return sitio;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos del sitio: " + ex.Message);
            }
        }


    }
    /*
     * Los proveedores de lugares de alquiler, una vez inscritos como tal, pueden agregar uno o más sitios 
brindando fotos, tamaño del lugar, ubicación, cantidad de habitaciones, cantidad de camas, cantidad 
máxima de personas, monto de alquiler por noche, debe indicar si el precio del sitio es por persona o por 
el lugar, facilidades con las que cuenta, por ejemplo, cable, refrigeradora, cocina, aire acondicionado, 
piscina, si está cerca de una playa y distancia, número de casa, como es la seguridad y otras condiciones 
que consideren convenientes agregar. Debe clasificar el sitio como playa, montaña o citadino. Tanto el 
sitio como el proveedor tienen un estado, en el sitio el estado es activo o inactivo, y en el proveedor tiene 
la misma clasificación del estado que un cliente.
    SELECT TOP (1000) [IdSitio]
      ,[IdProveedor]
      ,[IdTipoSitio]
      ,[IdEstado]
      ,[CodigoSitio]
      ,[NombreSitio]
      ,[DescripcionCorta]
      ,[DescripcionCompleta]
      ,[Provincia]
      ,[Canton]
      ,[Distrito]
      ,[DireccionExacta]
      ,[NumeroCasa]
      ,[NumeroHabitaciones]
      ,[NumeroCamas]
      ,[NumeroBanos]
      ,[PersonasMaximas]
      ,[PrecioPorNoche]
      ,[EsPorPersona]
      ,[CargoLimpieza]
      ,[DepositoSeguridad]
      ,[MinimoNoches]
      ,[PoliticaCancelacion]
      ,[PermiteMascotas]
      ,[FechaRegistro]
      ,[FechaUltimaModificacion]
  FROM [SistemaAlquilerVacacional].[dbo].[Sitios]

}
        */
}
