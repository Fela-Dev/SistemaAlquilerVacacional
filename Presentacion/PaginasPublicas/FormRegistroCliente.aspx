<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormRegistroCliente.aspx.cs" Inherits="Presentacion.PaginasPublicas.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-group {
            margin-bottom: 10px;
        }
        label, .form-label {
            font-weight: bold;
        }
        .form-section {
            margin-bottom: 20px;
            border: 1px solid #ccc;
            padding: 15px;
            border-radius: 8px;
            background-color: #f9f9f9;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align:center;">Registro de Personas</h2>

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="display: flex; gap: 90px;">
                <div>
                    <!-- div vacío :( -->
                </div>

                <div>
                    <!-- Sección: Identificación -->
                    <div class="form-section">
                        <h3>Identificación</h3>
                        <div class="form-group">
                            <asp:Label ID="lblTipoIdentificacion" runat="server" Text="Tipo de Identificación:" />
                            <asp:DropDownList ID="ddlTipoIdentificacion" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Cédula" Value="Cedula" />
                                <asp:ListItem Text="Pasaporte" Value="Pasaporte" />
                                <asp:ListItem Text="Licencia" Value="Licencia" />
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblNumeroIdentificacion" runat="server" Text="Número de Identificación:" />
                            <asp:TextBox ID="txtNumeroIdentificacion" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" />
                            <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control" />
                        </div>
                    </div>

                    <!-- Sección: Datos personales -->
                    <div class="form-section">
                        <h3>Datos Personales</h3>
                        <div class="form-group">
                            <asp:Label ID="lblPrimerNombre" runat="server" Text="Primer Nombre:" />
                            <asp:TextBox ID="txtPrimerNombre" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblSegundoNombre" runat="server" Text="Segundo Nombre (Opcional):" />
                            <asp:TextBox ID="txtSegundoNombre" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPrimerApellido" runat="server" Text="Primer Apellido:" />
                            <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido (Opcional):" />
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblGenero" runat="server" Text="Género:" />
                            <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Masculino" Value="M" />
                                <asp:ListItem Text="Femenino" Value="F" />
                                <asp:ListItem Text="Otro" Value="O" />
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Fecha de Nacimiento:" />
                            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" Required="true" />

                        </div>
                    </div>
                </div>

                <div>
                    <!-- Sección: Contacto -->
                    <div class="form-section">
                        <h3>Contacto</h3>
                        <div class="form-group">
                            <asp:Label ID="lblTelefonoPrincipal" runat="server" Text="Teléfono Principal:" />
                            <asp:TextBox ID="txtTelefonoPrincipal" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblTelefonoSecundario" runat="server" Text="Teléfono Secundario (Opcional):" />
                            <asp:TextBox ID="txtTelefonoSecundario" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblEmailPrincipal" runat="server" Text="Correo Principal:" />
                            <asp:TextBox ID="txtEmailPrincipal" runat="server" CssClass="form-control" TextMode="Email" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblEmailSecundario" runat="server" Text="Correo Secundario (Opcional):" />
                            <asp:TextBox ID="txtEmailSecundario" runat="server" CssClass="form-control" TextMode="Email" />
                        </div>
                    </div>

                    <!-- Sección: Dirección -->
                    <div class="form-section">
                        <h3>Dirección</h3>
                        <div class="form-group">
                            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" />
                            <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblCanton" runat="server" Text="Cantón:" />
                            <asp:TextBox ID="txtCanton" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblDistrito" runat="server" Text="Distrito (Opcional):" />
                            <asp:TextBox ID="txtDistrito" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblDireccionExacta" runat="server" Text="Dirección Exacta:" />
                            <asp:TextBox ID="txtDireccionExacta" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblCodigoPostal" runat="server" Text="Código Postal (Opcional):" />
                            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" />
                        </div>

                        <!-- Botones -->
                        <div class="form-group" style="text-align:center; margin-top:20px;">
                            <asp:Button ID="btnGuardar" runat="server" CssClass="boton-personalizado" Text="Guardar" OnClick="btnGuardar_Click" />
                            <asp:Button ID="btnCancelar" runat="server" CssClass="boton-personalizado" Text="Cancelar" OnClick="btnCancelar_Click" />
                        </div>
                    </div>
                </div>
                <div>
                     <div class="form-section">
                         <h3>Crear Usuario</h3>
                         <div class="form-group">
                             <asp:Label ID="Label2" runat="server" Text="Nombre de Usuario:" />
                             <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
                         </div>
                         <div class="form-group">
                             <asp:Label ID="Label3" runat="server" Text="Contraseña:" />
                             <asp:TextBox ID="txtContra" runat="server" CssClass="form-control" />
                         </div>
                         <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="Confirmar Contraseña:" />
                            <asp:TextBox ID="txtContra2" runat="server" CssClass="form-control" />
                        </div>
                    <!-- div vacío :( -->
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
