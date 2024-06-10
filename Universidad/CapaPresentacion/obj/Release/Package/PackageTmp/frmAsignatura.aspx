<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAsignatura.aspx.cs" Inherits="CapaPresentacion.frmAsignatura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class="container">
        <h2>Mantenimiento de la tabla asignatura</h2>
        <div class="form-group">
            <label for="txtcod_asignatura" class="control-label">cod_asignatura</label>
            <asp:TextBox runat="server" ID="txtcod_asignatura" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvcod_asignatura" runat="server" ControlToValidate="txtcod_asignatura" ErrorMessage="cod_asignatura" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvcod_asignaturaEliminar" runat="server" ErrorMessage="cod_asignatura para eliminar" ValidationGroup="Eliminar" ControlToValidate="txtcod_asignatura">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvcod_asignaturaActualizar" runat="server" ControlToValidate="txtcod_asignatura" ErrorMessage="Se requiere cod_asignatura para actulizar" ValidationGroup="Actualizar">*</asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <label for="txtnomb_asignatura" class="control-label">nomb_asignatura</label>
            <asp:TextBox runat="server" ID="txtnomb_asignatura" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvnomb_asignatura" runat="server" ControlToValidate="txtnomb_asignatura" ErrorMessage="nomb_asignatura obligatorio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvnomb_asignaturaActualizar" runat="server" ControlToValidate="txtnomb_asignatura" ErrorMessage="Se requiere nomb_asignatura para actulizar" ValidationGroup="Actualizar">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="txtcreditos" class="control-label">creditos</label>
            <asp:TextBox runat="server" ID="txtcreditos" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvcreditos" runat="server" ControlToValidate="txtcreditos" ErrorMessage="creditos obligatorio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvcreditosActualizar" runat="server" ControlToValidate="txtcreditos" ErrorMessage="Se requiere creditos para actualizar" ValidationGroup="Actualizar">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Button Text="Agregar" runat="server" Id="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="Agregar"/>
            <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de que desea eliminar este alumno?');" ValidationGroup="Eliminar"/>
            <asp:Button Text="Actualizar" runat="server" Id="btnActualizar" CssClass="btn btn-danger" OnClick="btnActualizar_Click" ValidationGroup="Actualizar"/>
            <br />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Eliminar" />
            <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="Actualizar" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Agregar" />
        </div>
        <asp:Button Text="Buscar" runat="server" Id="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
        <asp:Button Text="Ver Todas las Asignaturas" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click" />
        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="Buscar" />
        <div class="form-group">
            <asp:GridView runat="server" ID="gvAsignatura" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvAsignatura_SelectedIndexChanged"></asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"/>
        </div>
    </div>
    </asp:Content>
