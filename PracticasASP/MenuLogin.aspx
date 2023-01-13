<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="PracticasASP.MenuLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-6">
        <h2>Te logueaste correctamente</h2>
        <br />
    <div class="mb-3">
        <asp:Button Text="Página 1" runat="server" ID="btnPagina1" OnClick="btnPagina1_Click" CssClass="btn btn-primary" />
    </div>
    <div class="mb-3">
        <asp:Button Text="Página 2" runat="server" ID="btnPagina2" OnClick="btnPagina2_Click" CssClass="btn btn-primary" />
        <label>Tenés que ser admin</label>
    </div>
      </div>
</asp:Content>
