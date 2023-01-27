<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PracticasASP.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <h2>Creá tu perfil</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" id="txtEmail" placeholder="Email" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" placeholder="*****" ID="txtPassword" CssClass="form-control" TextMode="Password" />
            </div>
            <asp:Button runat="server" Text="Registrarse" ID="btnRegistro" OnClick="btnRegistro_Click" CssClass="btn btn-primary" />
            <asp:button text="Cancelar" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn"/>
        </div>
    </div>

</asp:Content>
