using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;

namespace CapaNegocio.Interface
{
    interface IAsignatura
    {
        DataTable Listar();
        bool Agregar(Asignatura asignatura);
        bool Eliminar(string cod_asignatura);
        bool Actualizar(Asignatura asignatura);
        DataTable Buscar(string cod_asignatura);
    }
}
