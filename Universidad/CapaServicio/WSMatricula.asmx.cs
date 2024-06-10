using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace CapaServicio
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WSMatricula : System.Web.Services.WebService
    {
        private string connectionString = "Server=localhost; Database=universidad; Integrated Security=true";

        [WebMethod]
        public DataTable ListarMatriculas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spListarMatriculas", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Matriculas");
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        [WebMethod]
        public bool AgregarMatricula(string periodo, decimal promedio, string cod_asignatura, string cod_est)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spAgregarMatricula", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_asignatura", cod_asignatura);
                command.Parameters.AddWithValue("@cod_est", cod_est);
                command.Parameters.AddWithValue("@periodo", periodo);
                command.Parameters.AddWithValue("@promedio", promedio);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public bool ActualizarMatricula(string periodo, decimal promedio, int CourseID, int StudentID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spActualizarMatricula", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@periodo", periodo);
                command.Parameters.AddWithValue("@promedio", promedio);
                command.Parameters.AddWithValue("@CourseID", CourseID);
                command.Parameters.AddWithValue("@StudentID", StudentID);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public bool EliminarMatricula(string periodo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spEliminarMatricula", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@periodo", periodo);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public DataTable BuscarMatriculaPorCodigo(string periodo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spBuscarMatriculaPorCodigo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_matricula", periodo);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Matricula");
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
    }
}
