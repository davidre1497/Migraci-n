using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Migración
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // No hay nada que hacer aquí
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (Autenticar(usuario, contraseña))
            {
                // Si la autenticación es correcta, creamos una sesión para el usuario
                Session["Usuario"] = usuario;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                // Si la autenticación falla, mostramos un mensaje de error
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
        }

        private bool Autenticar(string usuario, string contraseña)
        {
            // Conectamos a la base de datos
            string connectionString = "Data Source=<tu_servidor>;Initial Catalog=<tu_base_datos>;User ID=<tu_usuario>;Password=<tu_contraseña>";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Creamos un comando para verificar la autenticación
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña", connection);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Contraseña", contraseña);

                // Ejecutamos el comando y obtenemos el resultado
                int resultado = (int)command.ExecuteScalar();

                // Si el resultado es 1, significa que el usuario existe y la contraseña es correcta
                return resultado == 1;
            }
        }
    }
}