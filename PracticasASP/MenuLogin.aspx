<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="PracticasASP.MenuLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <h2>Te logueaste correctamente</h2>
            <hr />
        </div>
        <div class="col-4">
            <asp:Button Text="Página 1" runat="server" ID="btnPagina1" OnClick="btnPagina1_Click" CssClass="btn btn-primary" />
        </div>
        <div class="col-4">
           <% if(Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN) { %>
            <asp:Button Text="Página 2" runat="server" ID="btnPagina2" OnClick="btnPagina2_Click" CssClass="btn btn-primary" />
            <p>Tenés que ser admin</p>
            <% } %>
        </div>
    </div>
</asp:Content>
