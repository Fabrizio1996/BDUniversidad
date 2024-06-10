using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
using CapaEntidad;

namespace CapaNegocio
{
    public class EstudianteBL : Interface.IEstudiante
    {
        private Datos datos = new DatosSQL();

        public string Mensaje { get; set; }

        public DataTable Listar()
        {
            return datos.TraerDataTable("spListarEstudiantes");
        }

        public bool Agregar(Estudiante estudiante)
        {
            DataRow fila = datos.TraerDataRow("spAgregarEstudiante", estudiante.cod_est, estudiante.nomb_est);
            // Traer el mensaje del procedimiento almacenado para llevar al formulario
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public bool Eliminar(string cod_est)
        {
            DataRow fila = datos.TraerDataRow("spEliminarEstudiante",cod_est);
            // Traer el mensaje del procedimiento almacenado para llevar al formulario
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }


        public bool Actualizar(Estudiante estudiante)
        {
            DataRow fila = datos.TraerDataRow("spActualizarEstudiante", estudiante.cod_est, estudiante.nomb_est);
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            return codError == 0;
        }



        public DataTable Buscar(string cod_est)
        {
            return datos.TraerDataTable("spBuscarEstudiantePorCodigo", cod_est);
        }
    }
}
