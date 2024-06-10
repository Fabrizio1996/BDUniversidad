using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace CapaServicio
{
    /// <summary>
    /// Descripción breve de WSAlumno
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSAlumno : System.Web.Services.WebService
    {
        private string connectionString = "Server=localhost; Database=BDAcademico; Integrated Security=true";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public DataTable Listar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spListarAlumno", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Alumnos"); // Asignar un nombre al DataTable
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        [WebMethod]
        public bool Agregar(string codAlumno, string aPaterno, string aMaterno, string nombres, string codUsuario, string contrasena, string codEscuela)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spAgregarAlumno", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CodAlumno", codAlumno);
                command.Parameters.AddWithValue("@APaterno", aPaterno);
                command.Parameters.AddWithValue("@AMaterno", aMaterno);
                command.Parameters.AddWithValue("@Nombres", nombres);
                command.Parameters.AddWithValue("@CodUsuario", codUsuario);
                command.Parameters.AddWithValue("@Contrasena", contrasena);
                command.Parameters.AddWithValue("@CodEscuela", codEscuela);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public bool Eliminar(string codAlumno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spEliminarAlumno", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CodAlumno", codAlumno);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public bool Actualizar(string codAlumno, string aPaterno, string aMaterno, string nombres, string codEscuela)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spActualizarAlumno", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CodAlumno", codAlumno);
                command.Parameters.AddWithValue("@APaterno", aPaterno);
                command.Parameters.AddWithValue("@AMaterno", aMaterno);
                command.Parameters.AddWithValue("@Nombres", nombres);
                command.Parameters.AddWithValue("@CodEscuela", codEscuela);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public DataTable Buscar(string codAlumno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spBuscarAlumno", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CodAlumno", codAlumno);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Alumno"); // Asignar un nombre al DataTable
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
    }
}
