<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormActualizarSitios.aspx.cs" Inherits="Presentacion.PaginasProvedor.FormActualizarSitios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EstiloLogin.css" rel="stylesheet" type="text/css" />
    <style>
        .form-group { margin-bottom: 10px; }
        label, .form-label { font-weight: bold; }
        .form-section {
            margin-bottom: 20px;
            border: 1px solid #ccc;
            padding: 15px;
            border-radius: 8px;
            background-color: #f9f9f9;
        }
        .imgPrincipal {
            width: 500px;
            height: 300px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.3);
            display: block;
            margin: 0 auto;
        }
        .boton-principal {
            padding: 8px 16px;
            font-size: 15px;
            border: none;
            border-radius: 6px;
            background-color: #28a745;
            color: white;
            cursor: pointer;
            margin-top: 15px;
        }
        .boton-principal:hover { background-color: #1e7e34; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 style="text-align:center;">Actualizar Sitio</h2>

    <!-- Buscar Sitio por ID -->
    <div class="form-section" style="text-align:center;">
        <asp:Label ID="lblIdSitio" runat="server" Text="Ingrese ID del Sitio:" />
        <asp:TextBox ID="txtIdSitioBuscar" runat="server" CssClass="form-control" Width="100px" />
        <asp:Button ID="btnBuscarSitio" runat="server" Text="Buscar" CssClass="boton-principal" OnClick="btnBuscarSitio_Click" />
    </div>

    <!-- Datos del sitio -->
    <div class="form-section" style="max-width:600px; margin:auto;">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre del Sitio:" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />

        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción Larga:" />
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />

        <asp:Label ID="lblDescripcionCorta" runat="server" Text="Descripción Corta:" />
        <asp:TextBox ID="txtDescripcionCorta" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />

        <asp:Label ID="lblTipoSitio" runat="server" Text="Tipo de Sitio:" />
        <asp:DropDownList ID="ddlTipoSitio" runat="server" CssClass="form-control" Width="250px">
            <asp:ListItem Text="Playa" Value="1" />
            <asp:ListItem Text="Montaña" Value="2" />
            <asp:ListItem Text="Citadino" Value="3" />
        </asp:DropDownList>
    </div>

    <!-- Imágenes -->
    <div class="form-section" style="max-width:600px; margin:auto; margin-top:20px;">
        <h3>Imágenes</h3>
        <asp:Image ID="imgPrincipal" runat="server" CssClass="imgPrincipal" ImageUrl="~/Imagenes/ImagenesSitios/sitioDefecto.jpg" />

        <asp:GridView ID="gvImagenesSitio" runat="server" CssClass="table table-striped"
            AutoGenerateColumns="False" DataKeyNames="IdImagen"
            OnRowDeleting="gvImagenesSitio_RowDeleting">
            <Columns>
                <asp:BoundField DataField="IdImagen" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="RutaImagen" HeaderText="Imagen" />
                <asp:CheckBoxField DataField="EsPrincipal" HeaderText="Principal" />
                <asp:BoundField DataField="NombreArchivo" HeaderText="Archivo" />
                <asp:CommandField ShowDeleteButton="True" DeleteText="Quitar" />
                <asp:CommandField ShowDeleteButton="True" DeleteText="Antigua" />
            </Columns>
        </asp:GridView>

        <!-- Subir nueva imagen -->
        <div class="form-group">
            <asp:FileUpload ID="fuNuevaImagen" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:CheckBox ID="chkNuevaPrincipal" runat="server" Text="¿Imagen Principal?" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnAgregarImagen" runat="server" Text="Agregar Imagen" CssClass="boton-principal" OnClick="btnAgregarImagen_Click" />
        </div>
    </div>
           
    <!-- Sección: Detalles del sitio -->
<div>
<div class="form-section">
    <h3>Detalles del Sitio</h3>

    <div class="form-group">
        <asp:Label ID="lblHabitaciones" runat="server" Text="Habitaciones:" />
        <asp:TextBox ID="txtHabitaciones" runat="server" CssClass="form-control" TextMode="Number" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblCamas" runat="server" Text="Camas:" />
        <asp:TextBox ID="txtCamas" runat="server" CssClass="form-control" TextMode="Number" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblBanos" runat="server" Text="Baños:" />
        <asp:TextBox ID="txtBanos" runat="server" CssClass="form-control" TextMode="Number" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblPersonasMax" runat="server" Text="Personas Máximas:" />
        <asp:TextBox ID="txtPersonasMax" runat="server" CssClass="form-control" TextMode="Number" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblPrecio" runat="server" Text="Precio por Noche (₡):" />
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number" />
    </div>
    <div class="form-group">
        <asp:CheckBox ID="chkPorPersona" runat="server" Text="¿Precio por persona?" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblLimpieza" runat="server" Text="Cargo de Limpieza (₡):" />
        <asp:TextBox ID="txtLimpieza" runat="server" CssClass="form-control" TextMode="Number" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblDeposito" runat="server" Text="Depósito de Seguridad (₡):" />
        <asp:TextBox ID="txtDeposito" runat="server" CssClass="form-control" TextMode="Number" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblMinNoches" runat="server" Text="Mínimo de Noches:" />
        <asp:TextBox ID="txtMinNoches" runat="server" CssClass="form-control" TextMode="Number" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblPolitica" runat="server" Text="Política de Cancelación:" />
        <asp:TextBox ID="txtPolitica" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
    </div>
    <div class="form-group">
        <asp:CheckBox ID="chkMascotas" runat="server" Text="¿Permite mascotas?" />
    </div>
</div>
            </div>
        

        <!--Segundo-->
         <div class="form-section" style="max-width:600px;">
             <!-- Sección: Información general -->
<div class="form-section">
    <h3>Información del Sitio</h3>

    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Nombre del Sitio:" />
        <asp:TextBox ID="txtNombre1" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <asp:Label ID="Label2" runat="server" Text="Descripción Larga:" />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
    </div>

    <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Descripción Corta:" />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
    </div>
    <div class="form-section" style="text-align:center;">
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="250px">
        <asp:ListItem Text="Playa" Value="1" Selected="True" />
        <asp:ListItem Text="Montaña" Value="2" Selected="False" />
        <asp:ListItem Text="Citadino" Value="3" Selected="False" />
    </asp:DropDownList>
</div>
    </div>
</div>

<!-- Sección: Ubicación -->
<div class="form-section">
    <h3>Ubicación</h3>

    <div class="form-group">
        <asp:Label ID="Label4" runat="server" Text="Provincia:" />
        <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <asp:Label ID="Label5" runat="server" Text="Cantón:" />
        <asp:TextBox ID="txtCanton" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <asp:Label ID="Label6" runat="server" Text="Distrito:" />
        <asp:TextBox ID="txtDistrito" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <asp:Label ID="Label7" runat="server" Text="Dirección Exacta:" />
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <asp:Label ID="Label8" runat="server" Text="Número de Casa:" />
        <asp:TextBox ID="txtNumeroCasa" runat="server" CssClass="form-control" />
    </div>
</div>

    <!-- Facilidades -->
    <div class="form-section" style="max-width:600px; margin:auto; margin-top:20px;">
        <h3>Facilidades</h3>
        <asp:GridView ID="gvFacilidadesSitio" runat="server" CssClass="table table-striped"
            AutoGenerateColumns="False" DataKeyNames="IdFacilidad"
            OnRowDeleting="gvFacilidadesSitio_RowDeleting" OnSelectedIndexChanged="gvFacilidadesSitio_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="IdFacilidad" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="NombreFacilidad" HeaderText="Facilidad" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            </Columns>
        </asp:GridView>

        <div class="form-group">
            <asp:TextBox ID="txtNombreFacilidad" runat="server" CssClass="form-control" Placeholder="Nombre de la facilidad" />
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtDescripcionFacilidad" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" Placeholder="Descripción" />
        </div>
        <div class="form-group">
            <asp:CheckBox ID="chkTieneFacilidad" runat="server" Text="Disponible" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnAgregarFacilidad" runat="server" Text="Agregar" CssClass="boton-principal" OnClick="btnAgregarFacilidad_Click" />
        </div>
    </div>
            <div class="form-section" style="text-align:center;">
    <asp:DropDownList ID="dllEstadoSitio" runat="server" CssClass="form-control" Width="250px">
        <asp:ListItem Text="Activo" Value="1" Selected="True" />
        <asp:ListItem Text="Inactivo" Value="2" Selected="False" />
    </asp:DropDownList>
</div>
    <!-- Guardar cambios -->
    <div class="form-section" style="text-align:center;">
        <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar Cambios" CssClass="boton-principal" OnClick="btnGuardarCambios_Click" />
    </div>

</asp:Content>

