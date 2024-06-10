<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMatricula.aspx.cs" Inherits="CapaPresentacion.frmMatricula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                <div class="container">
        <h2>Mantenimiento de la tabla matricula</h2>
        <div class="form-group">
            <label for="txtperiodo" class="control-label">periodo</label>
            <asp:TextBox runat="server" ID="txtperiodo" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvperiodo" runat="server" ControlToValidate="txtperiodo" ErrorMessage="periodo" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvcod_periodoEliminar" runat="server" ErrorMessage="periodo para eliminar" ValidationGroup="Eliminar" ControlToValidate="txtperiodo">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="txtpromedio" class="control-label">promedio</label>
            <asp:TextBox runat="server" ID="txtpromedio" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvpromedio" runat="server" ControlToValidate="txtpromedio" ErrorMessage="promedio obligatorio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvpromedioActualizar" runat="server" ControlToValidate="txtpromedio" ErrorMessage="Se requiere promedio para actulizar" ValidationGroup="Actualizar">*</asp:RequiredFieldValidator>
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
        <asp:Button Text="Ver Todas las Matriculas" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click" />
        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="Buscar" />
        <div class="form-group">
            <asp:GridView runat="server" ID="gvMatricula" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvMatricula_SelectedIndexChanged"></asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"/>
        </div>
    </div>
</asp:Content>
