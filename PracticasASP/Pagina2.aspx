<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pagina2.aspx.cs" Inherits="PracticasASP.Pagina2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Acceso denegado</h1>
    <label>Tenes que ser admin </label>
    <br />
    <br />
    <asp:Button Text="Regresar" runat="server" ID="btnRegresar2" OnClick="btnRegresar2_Click" CssClass="btn btn-primary" />
</asp:Content>
