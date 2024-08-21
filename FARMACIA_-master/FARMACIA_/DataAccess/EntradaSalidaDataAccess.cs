using ControlMigracionWeb.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ControlMigracionWeb.DataAccess
{
    public class EntradaSalidaDataAccess
    {
        private readonly string _connectionString;

        public EntradaSalidaDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ControlMigracion"].ConnectionString;
        }

        public List<EntradaSalida> ObtenerEntradasSalidas()
        {
            List<EntradaSalida> entradasSalidas = new List<EntradaSalida>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM EntradasSalidas", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EntradaSalida entradaSalida = new EntradaSalida();
                    entradaSalida.IdEntradaSalida = reader.GetInt32(0);
                    entradaSalida.FechaEntrada = reader.GetDateTime(1);
                    entradaSalida.FechaSalida = reader.GetDateTime(2);
                    entradaSalida.LugarEntrada = reader.GetString(3);
                    entradaSalida.LugarSalida = reader.GetString(4);

                    entradasSalidas.Add(entradaSalida);
                }
            }

            return entradasSalidas;
        }

        public void RegistrarEntradaSalida(EntradaSalida entradaSalida)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO EntradasSalidas (FechaEntrada, FechaSalida, LugarEntrada, LugarSalida) VALUES (@fechaEntrada, @fechaSalida, @lugarEntrada, @lugarSalida)", connection);
                command.Parameters.AddWithValue("@fechaEntrada", entradaSalida.FechaEntrada);
                command.Parameters.AddWithValue("@fechaSalida", entradaSalida.FechaSalida);
                command.Parameters.AddWithValue("@lugarEntrada", entradaSalida.LugarEntrada);
                command.Parameters.AddWithValue("@lugarSalida", entradaSalida.LugarSalida);

                command.ExecuteNonQuery();
            }
        }
    }

    public class UsuarioDataAccess
    {
        private readonly string _connectionString;

        public UsuarioDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ControlMigracion"].ConnectionString;
        }

        public bool AutenticarUsuario(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Usuarios WHERE Username = @username AND Password = @password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);


                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void RegistrarUsuario(string nombre, string apellido, string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Usuarios (Nombre, Apellido, Username, Password) VALUES (@nombre, @apellido, @username, @password)", connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                command.ExecuteNonQuery();
            }
        }
    }
}

