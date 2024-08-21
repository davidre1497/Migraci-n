using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlMigraciónApp.Datos
{
    public class UsuarioDataAccess
    {
        public static bool ValidarUsuario(string usuario, string contraseña)
        {
            using (SqlConnection connection = Conexion.GetConexion())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Usuarios WHERE Usuario = @usuario AND Contraseña = @contraseña", connection);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contraseña", contraseña);
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public static void AgregarUsuario(string nombre, string apellido, string usuario, string contraseña)
        {
            using (SqlConnection connection = Conexion.GetConexion())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Usuarios (Nombre, Apellido, Usuario, Contraseña) VALUES (@nombre, @apellido, @usuario, @contraseña)", connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contraseña", contraseña);
                command.ExecuteNonQuery();
            }
        }
    }
}