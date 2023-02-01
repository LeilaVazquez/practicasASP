<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EmailOk.aspx.cs" Inherits="PracticasASP.EmailOk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <h2>Ya estas registrado.</h2>
            <asp:Button Text="Volver" runat="server" ID="btnVolver" CssClass="btn btn-primary" OnClick="btnVolver_Click"/>
        </div>
    </div>
</asp:Content>
