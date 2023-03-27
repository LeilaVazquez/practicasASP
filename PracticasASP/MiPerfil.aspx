<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="PracticasASP.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 15px;
        }
    </style>
    <!-- <script>    
        function validar() {
            //captura el control
            const txtApellido = document.getElementById("txtApellido");
            if (txtApellido.value == "") {
                txtApellido.classList.add("is-invalid");
                return false;
            }
            txtApellido.classList.remove("is-invalid");
            return true;
        } 
    </script> -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                <!-- email:   ^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$ -->
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtApellido" CssClass="form-control" />
                <!--<asp:RangeValidator ErrorMessage="Fuera de rango" Type="Integer" MaximumValue="256" MinimumValue="1" ControlToValidate="txtApellido" runat="server" /> -->
                <!--<asp:RegularExpressionValidator ErrorMessage="Solo números" validationExpression="^[0-9]+$" ControlToValidate="txtApellido" runat="server" />-->
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
                <!-- elemento del HTML con propiedades del ASP(runat) -->
            </div>
            <asp:Image ImageUrl="https://www.chanchao.com.tw/images/default.jpg" runat="server" ID="imgNuevoPerfil" CssClass="img-fluid mb-3" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4"> <!-- OnClientClick="return validar()" -->
            <asp:Button Text="Guardar"  CssClass="btn btn-primary" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
            <asp:Button Text="Regresar" CssClass="btn" runat="server" ID="btnRegresar" />
        </div>
    </div>
</asp:Content>
