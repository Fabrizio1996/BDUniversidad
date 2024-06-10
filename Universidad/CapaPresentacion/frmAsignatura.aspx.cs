using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmAsignatura : System.Web.UI.Page
    {
        private void Listar()
        {
            AsignaturaBL asignaturaBL = new AsignaturaBL();
            gvAsignatura.DataSource = asignaturaBL.Listar();
            gvAsignatura.DataBind();
            btnActualizar.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Crear un objeto Asignatura con los valores de las cajas de texto
            Asignatura asignatura = new Asignatura
            {
                cod_asignatura = txtcod_asignatura.Text.Trim(),
                nomb_asignatura = txtnomb_asignatura.Text.Trim(),
                creditos = int.Parse(txtcreditos.Text.Trim())
            };

            // Validar si el campo de créditos no está vacío
            if (!string.IsNullOrEmpty(txtcreditos.Text))
            {
                // Si no está vacío, intentar agregar la asignatura
                AsignaturaBL asignaturaBL = new AsignaturaBL();
                if (asignaturaBL.Agregar(asignatura))
                {
                    // Si se agrega correctamente, actualizar la lista y mostrar mensaje de éxito
                    Listar();
                    lblMensaje.Text = "Asignatura agregada correctamente.";
                }
                else
                {
                    // Si no se puede agregar, mostrar mensaje de error
                    lblMensaje.Text = asignaturaBL.Mensaje;
                }
            }
            else
            {
                // Si el campo de créditos está vacío, mostrar mensaje de error
                lblMensaje.Text = "Por favor, ingrese un valor para créditos.";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string codAsignatura = txtcod_asignatura.Text.Trim();
            AsignaturaBL asignaturaBL = new AsignaturaBL();
            if (asignaturaBL.Eliminar(codAsignatura))
            {
                Listar();
                lblMensaje.Text = asignaturaBL.Mensaje;
            }
            else
            {
                lblMensaje.Text = "Error al eliminar la asignatura.";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string codAsignatura = txtcod_asignatura.Text.Trim();

            DataTable resultadoBusqueda = new AsignaturaBL().Buscar(codAsignatura);

            if (resultadoBusqueda != null && resultadoBusqueda.Rows.Count > 0)
            {
                gvAsignatura.DataSource = resultadoBusqueda;
                gvAsignatura.DataBind();
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Text = "No se encontraron asignaturas con el código proporcionado.";
                gvAsignatura.DataSource = null;
                gvAsignatura.DataBind();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (gvAsignatura.SelectedRow != null)
            {
                Asignatura asignatura = new Asignatura
                {
                    cod_asignatura = txtcod_asignatura.Text.Trim(),
                    nomb_asignatura = txtnomb_asignatura.Text.Trim(),
                    creditos = int.Parse(txtcreditos.Text.Trim())
                };

                // Aquí puedes agregar cualquier lógica de validación adicional para `creditos`
                if (!string.IsNullOrEmpty(txtcreditos.Text))
                {
                    AsignaturaBL asignaturaBL = new AsignaturaBL();
                    if (asignaturaBL.Actualizar(asignatura))
                    {
                        Listar();
                        lblMensaje.Text = "Asignatura actualizada correctamente.";
                        LimpiarFormulario();
                    }
                    else
                    {
                        lblMensaje.Text = "Error al actualizar la asignatura: " + asignaturaBL.Mensaje;
                    }
                }
                else
                {
                    lblMensaje.Text = "Por favor, ingrese un valor para créditos.";
                }
            }
        }

        protected void gvAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvAsignatura.SelectedRow != null)
            {
                GridViewRow row = gvAsignatura.SelectedRow;

                txtcod_asignatura.Text = row.Cells[1].Text;
                txtnomb_asignatura.Text = row.Cells[2].Text;
                txtcreditos.Text = row.Cells[3].Text;

                btnActualizar.Visible = true;
                txtcod_asignatura.Enabled = true;
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
            txtcod_asignatura.Text = "";
            txtnomb_asignatura.Text = "";
            txtcreditos.Text = "";
        }
    }
}