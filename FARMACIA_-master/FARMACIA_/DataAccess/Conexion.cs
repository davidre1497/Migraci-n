using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlMigraciónApp.Datos
{
    public class Conexion
    {
        public static SqlConnection GetConexion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MigracionDBConnectionString"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}