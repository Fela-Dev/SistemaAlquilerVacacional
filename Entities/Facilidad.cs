using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Facilidad
    {
        public string Operacion { get; set; }        // "INSERT", "UPDATE", "DELETE"
        public int? IdFacilidad { get; set; }        // Puede ser null si es INSERT
        public int? IdSitio { get; set; }            // Relación con el sitio, opcional
        public string NombreFacilidad { get; set; }  // Nombre de la facilidad
        public bool? TieneFacilidad { get; set; }    // Indica si aplica
        public string Descripcion { get; set; }      // Descripción adicional

        public SqlParameter[] listaAtributos()
        {
            return new SqlParameter[]
            {
        new SqlParameter("@Operacion", (object)Operacion ?? DBNull.Value),
        new SqlParameter("@IdFacilidad", (object)IdFacilidad ?? DBNull.Value),
        new SqlParameter("@IdSitio", (object)IdSitio ?? DBNull.Value),
        new SqlParameter("@NombreFacilidad", (object)NombreFacilidad ?? DBNull.Value),
        new SqlParameter("@TieneFacilidad", (object)TieneFacilidad ?? DBNull.Value),
        new SqlParameter("@Descripcion", (object)Descripcion ?? DBNull.Value)
            };
        }
        public DataTable ejecutarConsultaMantenimiento()
        {
            SqlParameter[] lista = listaAtributos();
            return Datos.ConexionSQL.EjecutarConRetorno("sp_MantenimientoFacilidades", lista);
        }
        public DataTable ejecutarConsultarFacilidades(int idSitio)
        {
            SqlParameter[] lista = new SqlParameter[] { new SqlParameter("@IdSitio", (object)idSitio?? DBNull.Value) };
            
            return Datos.ConexionSQL.EjecutarConRetorno("sp_ConsultarFacilidadesSitio", lista);
        }
        /*
         *   @Operacion NVARCHAR(10),  -- "INSERT", "UPDATE", "DELETE"
@IdFacilidad INT = NULL,
@IdSitio INT = NULL,
@NombreFacilidad NVARCHAR(50) = NULL,
@TieneFacilidad BIT = NULL,
@Descripcion NVARCHAR(200) = NULL
         */
        public void GuardarFacilidad(Facilidad facilidad)
        {
            // Aquí iría la lógica para guardar la facilidad en la base de datos
            // usando los atributos de la clase Facilidad.
        }
    }
    
    }
