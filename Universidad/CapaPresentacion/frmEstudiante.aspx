<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEstudiante.aspx.cs" Inherits="CapaPresentacion.frmEstudiante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <h2>Mantenimiento de la tabla estudiante</h2>
        <div class="form-group">
            <label for="txtcod_est" class="control-label">cod_est</label>
            <asp:TextBox runat="server" ID="txtcod_est" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvcod_est" runat="server" ControlToValidate="txtcod_est" ErrorMessage="cod_est" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvcod_estEliminar" runat="server" ErrorMessage="cod_est para eliminar" ValidationGroup="Eliminar" ControlToValidate="txtcod_est">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvcod_estActualizar" runat="server" ControlToValidate="txtnomb_est" ErrorMessage="Se requiere cod_est para actualizar" ValidationGroup="Actualizar">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="txtnomb_est" class="control-label">nomb_est</label>
            <asp:TextBox runat="server" ID="txtnomb_est" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvnomb_est" runat="server" ControlToValidate="txtnomb_est" ErrorMessage="nomb_est obligatorio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvnomb_estActualizar" runat="server" ControlToValidate="txtnomb_est" ErrorMessage="Se requiere nomb_est para actulizar" ValidationGroup="Actualizar">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Button Text="Agregar" runat="server" Id="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="Agregar"/>
            <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de que desea eliminar este Estudiante?');" ValidationGroup="Eliminar"/>
            <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-danger" OnClick="btnActualizar_Click" ValidationGroup="Actualizar" />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Agregar" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Eliminar" />
            <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="Actualizar" />
        </div>
        <asp:Button Text="Buscar" runat="server" Id="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
        <asp:Button Text="Ver Todos los Estudiantes" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click" />
        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="Buscar" />
        <div class="form-group">
            <asp:GridView runat="server" ID="gvEstudiante" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvEstudiante_SelectedIndexChanged"></asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"/>
        </div>
    </div>
</asp:Content>
