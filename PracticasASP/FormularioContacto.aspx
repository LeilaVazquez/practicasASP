<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioContacto.aspx.cs" Inherits="PracticasASP.FormularioContacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Asunto</label>
                <asp:TextBox runat="server" ID="txtAsunto" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Mensaje</label>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMensaje" CssClass="form-control" />
            </div>
            <asp:Button Text="Aceptar" runat="server" CssClass="btn btn-primary" ID="btnAceptar" OnClick="btnAceptar_Click" />
        </div>
        <div class="col"></div>
    </div>
</asp:Content>
