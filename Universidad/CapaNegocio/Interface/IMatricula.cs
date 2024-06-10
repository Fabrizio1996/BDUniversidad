using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;

namespace CapaNegocio.Interface
{
    interface IMatricula
    {
        DataTable Listar();
        bool Agregar(Matricula matricula);
        bool Eliminar(string EnrollmentID);
        bool Actualizar(Matricula matricula);
        DataTable Buscar(string EnrollmentID);
    }
}
