<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PracticasASP.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Catálogo</h1>
    <p>Artículos</p>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%--        <%
            foreach (dominio.Articulos articulo in ListaArticulos)
            { %>
        <div class="col">
            <div class="card">
                <img src="<%: articulo.ImagenUrl %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                    <p class="card-text"><%: articulo.Descripcion %></p>
                    <a href="DetalleArticulo.aspx?id=<%: articulo.Id %>">Detalle</a>
                </div>
            </div>
        </div>

        <% } %>--%>

        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" onerror="this.src='Images/default.png'"  class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Precio") %></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Descripcion") %>">Detalle</a>
                            <asp:Button ID="btnEjemplo" runat="server" Text="Ejemplo" CssClass="btn btn-primary" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEjemplo_Click" />
                            <%--CommandArgument va con comillas simples--%>
                           <%-- Genera un postback capturando el ID para el code behind--%>
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
