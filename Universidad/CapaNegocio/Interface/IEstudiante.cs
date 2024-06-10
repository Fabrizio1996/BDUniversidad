using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;

namespace CapaNegocio.Interface
{
    interface IEstudiante
    {
        DataTable Listar();
        bool Agregar(Estudiante estudiante);
        bool Eliminar(string cod_est);
        bool Actualizar(Estudiante estudiante);
        DataTable Buscar(string cod_est);
    }
}
