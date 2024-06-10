using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntidad;
using CapaNegocio.Interface;

namespace CapaNegocio
{
    public class AsignaturaBL : Interface.IAsignatura
    {
        //Llamar  a la CapaDato
        private Datos datos = new DatosSQL();

        //Mensaje del procedimiento almacenado
        public string Mensaje { get; set; }

        public DataTable Listar()
        {
            return datos.TraerDataTable("spListarAsignaturas");
        }

        public bool Agregar(Asignatura asignatura)
        {
            DataRow fila = datos.TraerDataRow("spAgregarAsignatura", asignatura.cod_asignatura, asignatura.nomb_asignatura, asignatura.creditos);
            // Traer el mensaje del procedimiento almacenado para llevar al formulario
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public bool Eliminar(string cod_asignatura)
        {
            DataRow fila = datos.TraerDataRow("spEliminarAsignatura", cod_asignatura);
            // Traer el mensaje del procedimiento almacenado para llevar al formulario
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            return codError == 0;
        }

        public bool Actualizar(Asignatura asignatura)
        {
            DataRow fila = datos.TraerDataRow("spActualizarAsignatura", asignatura.cod_asignatura, asignatura.nomb_asignatura, asignatura.creditos);
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) return true;
            else return false;
        }

        public DataTable Buscar(string cod_asignatura)
        {
            return datos.TraerDataTable("spBuscarAsignaturaPorCodigo", cod_asignatura);
        }
    }
}
