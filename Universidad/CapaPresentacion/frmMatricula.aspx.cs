using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmMatricula : System.Web.UI.Page
    {
        private void Listar()
        {
            MatriculaBL matriculaBL = new MatriculaBL();
            gvMatricula.DataSource = matriculaBL.Listar();
            gvMatricula.DataBind();
            btnActualizar.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtperiodo.Text) && !string.IsNullOrEmpty(txtpromedio.Text))
            {
                string periodo = txtperiodo.Text.Trim();
                decimal promedio = Convert.ToDecimal(txtpromedio.Text.Trim());

                Matricula matricula = new Matricula
                {
                    periodo = periodo,
                    promedio = promedio
                };

                MatriculaBL matriculaBL = new MatriculaBL();
                if (matriculaBL.Agregar(matricula))
                {
                    Listar();
                    lblMensaje.Text = "Matrícula agregada correctamente.";
                }
                else
                {
                    lblMensaje.Text = matriculaBL.Mensaje;
                }
            }
            else
            {
                lblMensaje.Text = "Error: Uno o más campos están vacíos.";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtperiodo.Text))
            {
                string periodo = txtperiodo.Text.Trim();
                MatriculaBL matriculaBL = new MatriculaBL();
                if (matriculaBL.Eliminar(periodo))
                {
                    Listar();
                    lblMensaje.Text = "Matrícula eliminada correctamente.";
                }
                else
                {
                    lblMensaje.Text = matriculaBL.Mensaje;
                }
            }
            else
            {
                lblMensaje.Text = "Error: periodo es null.";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (gvMatricula.SelectedRow != null && !string.IsNullOrEmpty(txtperiodo.Text) && !string.IsNullOrEmpty(txtpromedio.Text))
            {
                string periodo = txtperiodo.Text.Trim();
                decimal promedio = Convert.ToDecimal(txtpromedio.Text.Trim());

                Matricula matricula = new Matricula
                {
                    periodo = periodo,
                    promedio = promedio
                };

                MatriculaBL matriculaBL = new MatriculaBL();
                if (matriculaBL.Actualizar(matricula))
                {
                    gvMatricula.DataSource = matriculaBL.Listar();
                    gvMatricula.DataBind();
                    lblMensaje.Text = "Matrícula actualizada correctamente.";
                    LimpiarFormulario();
                }
                else
                {
                    lblMensaje.Text = "Error al actualizar la matrícula.";
                }
            }
            else
            {
                lblMensaje.Text = "Error: Uno o más campos son null.";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtperiodo.Text))
            {
                string periodo = txtperiodo.Text.Trim();
                DataTable resultadoBusqueda = new MatriculaBL().Buscar(periodo);

                if (resultadoBusqueda != null && resultadoBusqueda.Rows.Count > 0)
                {
                    gvMatricula.DataSource = resultadoBusqueda;
                    gvMatricula.DataBind();
                    lblMensaje.Text = "";
                }
                else
                {
                    lblMensaje.Text = "No se encontraron matrículas para el periodo proporcionado.";
                    gvMatricula.DataSource = null;
                    gvMatricula.DataBind();
                }
            }
            else
            {
                lblMensaje.Text = "Error: periodo es null.";
            }
        }

        protected void gvMatricula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvMatricula.SelectedRow != null)
            {
                GridViewRow row = gvMatricula.SelectedRow;
                txtperiodo.Text = row.Cells[1].Text;
                txtpromedio.Text = row.Cells[2].Text;
                btnActualizar.Visible = true;
                txtperiodo.Enabled = false;
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
            if (!string.IsNullOrEmpty(txtperiodo.Text)) txtperiodo.Text = "";
            if (!string.IsNullOrEmpty(txtpromedio.Text)) txtpromedio.Text = "";
        }
    }
}