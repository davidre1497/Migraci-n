using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Migración
{
    public partial class EntradasSalidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Cargar datos de la grilla
            LoadGridData();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Crear conexión a la base de datos
            string connectionString = "Data Source=DESKTOP-G1GORC0\\SQLEXPRESS;Initial Catalog=MigracionDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                // Abrir conexión
                connection.Open();

                // Crear comando para insertar entrada o salida
                SqlCommand command = new SqlCommand("INSERT INTO EntradasSalidas (Persona, FechaEntrada, FechaSalida) VALUES (@Persona, @FechaEntrada, @FechaSalida)", connection);

                // Agregar parámetros
                command.Parameters.AddWithValue("@Persona", txtPersona.Text);
                command.Parameters.AddWithValue("@FechaEntrada", txtFechaEntrada.Text);
                command.Parameters.AddWithValue("@FechaSalida", txtFechaSalida.Text);

                // Ejecutar comando
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Mostrar mensaje de éxito
                    lblMensaje.Text = "Entrada/Salida registrada con éxito";
                    LoadGridData(); // Recargar datos de la grilla
                }
                else
                {
                    // Mostrar mensaje de error
                    lblMensaje.Text = "Error al registrar entrada/salida";
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

        private void LoadGridData()
        {
            // Crear conexión a la base de datos
            string connectionString = "Data Source=DESKTOP-G1GORC0\\SQLEXPRESS;Initial Catalog=MigracionDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                // Abrir conexión
                connection.Open();

                // Crear comando para seleccionar entradas y salidas
                SqlCommand command = new SqlCommand("SELECT * FROM EntradasSalidas", connection);

                // Ejecutar comando
                SqlDataReader reader = command.ExecuteReader();

                // Cargar datos en la grilla
                gvEntradasSalidas.DataSource = reader;
                gvEntradasSalidas.DataBind();
            }
            catch (SqlException ex)
            {
                // Mostrar mensaje de error
                lblMensaje.Text = "Error al cargar datos: " + ex.Message;
            }
            finally
            {
                // Cerrar conexión
                connection.Close();
            }
        }
    }
}