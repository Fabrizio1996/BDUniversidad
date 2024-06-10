using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmEstudiante : System.Web.UI.Page
    {
        private void Listar()
        {
            EstudianteBL estudianteBL = new EstudianteBL();
            gvEstudiante.DataSource = estudianteBL.Listar();
            gvEstudiante.DataBind();
            btnActualizar.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos de texto no están vacíos
            if (!string.IsNullOrEmpty(txtcod_est.Text.Trim()) && !string.IsNullOrEmpty(txtnomb_est.Text.Trim()))
            {
                // Si los campos no están vacíos, crear un objeto Estudiante y asignar los valores de las cajas de texto
                Estudiante estudiante = new Estudiante
                {
                    cod_est = txtcod_est.Text.Trim(),
                    nomb_est = txtnomb_est.Text.Trim()
                };

                // Intentar agregar el estudiante utilizando la lógica de negocio correspondiente (EstudianteBL)
                EstudianteBL estudianteBL = new EstudianteBL();
                if (estudianteBL.Agregar(estudiante))
                {
                    // Si se agrega correctamente, actualizar la lista y mostrar mensaje de éxito
                    Listar();
                    lblMensaje.Text = "Estudiante agregado correctamente.";
                }
                else
                {
                    // Si no se puede agregar, mostrar mensaje de error
                    lblMensaje.Text = estudianteBL.Mensaje;
                }
            }
            else
            {
                // Si uno o más campos están vacíos, mostrar mensaje de error
                lblMensaje.Text = "Error: Uno o más campos están vacíos.";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtcod_est != null)
            {
                string codEst = txtcod_est.Text.Trim();
                EstudianteBL estudianteBL = new EstudianteBL();
                if (estudianteBL.Eliminar(codEst))
                {
                    Listar();
                    lblMensaje.Text = "Estudiante eliminado correctamente.";
                }
                else
                {
                    lblMensaje.Text = estudianteBL.Mensaje;
                }
            }
            else
            {
                lblMensaje.Text = "Error: txtcod_est es null.";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (gvEstudiante.SelectedRow != null)
            {
                string codEst = txtcod_est.Text.Trim();
                string nombEst = txtnomb_est.Text.Trim();

                Estudiante estudiante = new Estudiante
                {
                    cod_est = codEst,
                    nomb_est = nombEst
                };

                EstudianteBL estudianteBL = new EstudianteBL();
                if (estudianteBL.Actualizar(estudiante))
                {
                    gvEstudiante.DataSource = estudianteBL.Listar();
                    gvEstudiante.DataBind();
                    lblMensaje.Text = "Estudiante actualizado correctamente.";
                    LimpiarFormulario();
                }
                else
                {
                    lblMensaje.Text = "Error al actualizar el estudiante.";
                }
            }
            else
            {
                lblMensaje.Text = "Error: Uno o más campos son null.";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtcod_est != null)
            {
                string codEst = txtcod_est.Text.Trim();
                DataTable resultadoBusqueda = new EstudianteBL().Buscar(codEst);

                if (resultadoBusqueda != null && resultadoBusqueda.Rows.Count > 0)
                {
                    gvEstudiante.DataSource = resultadoBusqueda;
                    gvEstudiante.DataBind();
                    lblMensaje.Text = "";
                }
                else
                {
                    lblMensaje.Text = "No se encontraron estudiantes con el código proporcionado.";
                    gvEstudiante.DataSource = null;
                    gvEstudiante.DataBind();
                }
            }
            else
            {
                lblMensaje.Text = "Error: txtcod_est es null.";
            }
        }

        protected void gvEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvEstudiante.SelectedRow != null)
            {
                GridViewRow row = gvEstudiante.SelectedRow;
                txtcod_est.Text = row.Cells[1].Text;
                txtnomb_est.Text = row.Cells[2].Text;
                btnActualizar.Visible = true;
                txtcod_est.Enabled = true;
            }
            else
            {
                lblMensaje.Text = "Error: No hay una fila seleccionada.";
            }
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
            lblMensaje.Text = "";
            LimpiarFormulario();
            btnActualizar.Visible = true;
        }

        private void LimpiarFormulario()
        {
            if (txtcod_est != null) txtcod_est.Text = "";
            if (txtnomb_est != null) txtnomb_est.Text = "";
        }
    }
}