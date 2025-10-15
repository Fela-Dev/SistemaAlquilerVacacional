using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Datos
{

    public class ConsultasPersonas
    {
        ConexionSQL conSql = new ConexionSQL();
        // Aquí irían los métodos para manejar las consultas relacionadas con personas
        public void   MantenimientoPersonas(SqlParameter[] listaDatos)
        {
            String spName = "sp_MantenimientoPersonas";
            ConexionSQL.EjecutarConRetorno(spName, listaDatos);
        }
    }
}
