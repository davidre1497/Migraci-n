using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Migración
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            // Crear conexión a la base de datos
            string connectionString = "Data Source=DESKTOP-G1GORC0\\SQLEXPRESS;Initial Catalog=MigracionDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                // Abrir conexión
                connection.Open();

                // Crear comando para insertar usuario
                SqlCommand command = new SqlCommand("INSERT INTO Usuarios (Nombre, Apellido, Username, Password) VALUES (@Nombre, @Apellido, @Username, @Password)", connection);

                // Agregar parámetros
                command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                command.Parameters.AddWithValue("@Username", txtUsername.Text);
                command.Parameters.AddWithValue("@Password", txtPassword.Text);

                // Ejecutar comando
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Mostrar mensaje de éxito
                    lblMensaje.Text = "Usuario registrado con éxito";
                }
                else
                {
                    // Mostrar mensaje de error
                    lblMensaje.Text = "Error al registrar usuario";
                }
            }
            catch (SqlException ex)
            {
                // Mostrar mensaje de error
                lblMensaje.Text = "Error al conectar a la base de datos: " + ex.Message;
            }
            finally
            {
                // Cerrar conexión
                connection.Close();
            }
        }
    }
}