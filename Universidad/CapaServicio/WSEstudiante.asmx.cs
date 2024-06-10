using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace CapaServicio
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WSEstudiante : System.Web.Services.WebService
    {
        private string connectionString = "Server=localhost; Database=universidad; Integrated Security=true";

        [WebMethod]
        public DataTable ListarEstudiantes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spListarEstudiantes", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Estudiantes");
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        [WebMethod]
        public bool AgregarEstudiante(string cod_est, string nomb_est)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spAgregarEstudiante", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_est", cod_est);
                command.Parameters.AddWithValue("@nomb_est", nomb_est);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public bool ActualizarEstudiante(string cod_est, string nomb_est)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spActualizarEstudiante", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_est", cod_est);
                command.Parameters.AddWithValue("@nomb_est", nomb_est);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public bool EliminarEstudiante(string cod_est)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spEliminarEstudiante", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_est", cod_est);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public DataTable BuscarEstudiantePorCodigo(string cod_est)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spBuscarEstudiantePorCodigo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_est", cod_est);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Estudiante");
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
    }
}
