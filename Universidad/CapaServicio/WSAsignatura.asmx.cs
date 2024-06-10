using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace CapaServicio
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WSAsignatura : System.Web.Services.WebService
    {
        private string connectionString = "Server=localhost; Database=universidad; Integrated Security=true";

        [WebMethod]
        public DataTable ListarAsignaturas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spListarAsignaturas", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Asignaturas");
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        [WebMethod]
        public bool AgregarAsignatura(string cod_asignatura, string nomb_asignatura, int creditos)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spAgregarAsignatura", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_asignatura", cod_asignatura);
                command.Parameters.AddWithValue("@nomb_asignatura", nomb_asignatura);
                command.Parameters.AddWithValue("@creditos", creditos);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public bool ActualizarAsignatura(string cod_asig, string nomb_asignatura, int creditos)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spActualizarAsignatura", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_asig", cod_asig);
                command.Parameters.AddWithValue("@nomb_asignatura", nomb_asignatura);
                command.Parameters.AddWithValue("@creditos", creditos);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public bool EliminarAsignatura(string cod_asig)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spEliminarAsignatura", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_asig", cod_asig);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
        }

        [WebMethod]
        public DataTable BuscarAsignaturaPorCodigo(string cod_asig)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spBuscarAsignaturaPorCodigo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cod_asig", cod_asig);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Asignatura");
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
    }
}
