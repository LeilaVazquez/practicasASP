<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PracticasASP.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <h2>Login</h2>
            <div class="mb-3">
                <label class="form-label">User</label>
                <asp:TextBox runat="server" ID="txtEmail" REQUIRED placeholder="Email" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" placeholder="*****" ID="txtPassword" CssClass="form-control" TextMode="Password" />
            </div>
            <asp:Button runat="server" Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
            <asp:button text="Cancelar" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn"/>
        </div>
    </div>

</asp:Content>
