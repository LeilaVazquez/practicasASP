﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="PracticasASP.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hubo un problema</h1>
    <asp:Label Text="" ID="lblMensaje" runat="server" />
    <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-primary"  OnClick="btnVolver_Click" runat="server" />
</asp:Content>
