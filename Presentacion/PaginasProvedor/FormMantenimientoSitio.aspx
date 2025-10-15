<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormMantenimientoSitio.aspx.cs" Inherits="Presentacion.PaginasProvedor.FormMantenimientoSitio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EstiloLogin.css" rel="stylesheet" type="text/css" />
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
        .miniatura {
            width: 120px;
            height: 80px;
            cursor: pointer;
            cursor: pointer;
            border: 2px solid #ccc;
            border-radius: 8px;
            transition: border-color 0.3s;
        }
        .miniatura:hover {
            border-color: #007bff;
        }
        .imgPrincipal {
            width: 500px;
            height: 300px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.3);
            display: block;
            margin: 0 auto;
        }
        .galeria {
            display: flex;
            flex-wrap: wrap;
            gap: 15px;
            justify-content: center;
            align-items: center;
        }
        .galeria-item {
            display: flex;
            flex-direction: column;
            align-items: center;
            gap: 5px;
        }
        .boton-miniatura {
            padding: 5px 10px;
            font-size: 13px;
            border: none;
            border-radius: 5px;
            background-color: #007bff;
            color: white;
            cursor: pointer;
        }
        .boton-miniatura:hover {
            background-color: #0056b3;
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
        .boton-principal:hover {
            background-color: #1e7e34;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align:center;">Mantenimiento de Sitio</h2>

    <div style="display:flex; gap:4px; justify-content:center; align-items:flex-start; flex-wrap:wrap;">
        <!--Primera-->
        <div class="form-section" style="max-width:600px;">
       <!-- Sección: Imágenes -->
<div class="form-section" style="max-width:600px;">
    <h3>Imágenes del Sitio</h3>
    
    <img id="imgPrincipal" runat="server" src="~/Imagenes/ImagenesSitios/sitioDefecto.jpg" class="imgPrincipal" alt="Imagen principal" />
    <br />

   <div class="galeria">
    <% for (int i = 1; i <= 5; i++) { %>
        <div class="galeria-item">
            <asp:CheckBox ID='CheckBox1' runat="server" Text="Imagen Principal" CssClass="mb-1" />
            <img id='Img1'
                 src="~/Imagenes/ImagenesSitios/sitioDefecto.jpg"
                 class="miniatura"
                 runat="server"
                 onclick="cambiarImagen(this)" />
            <asp:Button ID='Button1' runat="server" Text="Cambiar" CssClass="boton-miniatura" OnClick="Button1_Click" />
            <asp:Button ID='Button2' runat="server" Text="Eliminar" CssClass="boton-miniatura" OnClick="btnEliminar_Click" />
        </div>
    <% } %>
</div>
    <!-- Controles para agregar imagen nueva -->
<div class="form-group">
    <asp:FileUpload ID="fuImagen" runat="server" CssClass="form-control" />
</div>

<div class="form-group">
    <asp:CheckBox ID="chkEsPrincipal" runat="server" Text="¿Imagen principal?" />
</div>

<div class="form-group">
    <asp:Button ID="btnAgregarImagen" runat="server" Text="Agregar Imagen" CssClass="boton-miniatura" OnClick="btnAgregarImagen_Click" />
</div>


<!-- GridView para mostrar imágenes agregadas -->
<asp:GridView ID="gvImagenesSitio" runat="server" CssClass="table table-striped"
    AutoGenerateColumns="False" DataKeyNames="IdImagen"
    OnRowDeleting="gvImagenesSitio_RowDeleting">
    <Columns>
        <asp:BoundField DataField="IdImagen" HeaderText="ID" Visible="false" />
        <asp:BoundField DataField="RutaImagen" HeaderText="Imagen" />
        <asp:CheckBoxField DataField="EsPrincipal" HeaderText="Principal" />
        <asp:BoundField DataField="NombreArchivo" HeaderText="Imagen" />
        <asp:CommandField ShowDeleteButton="True" DeleteText="Quitar" />
    </Columns>
</asp:GridView>



</div>


        <!-- Sección: Detalles del sitio -->
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
        <asp:Label ID="txtNombre" runat="server" Text="Nombre del Sitio:" />
        <asp:TextBox ID="txtNombre1" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <asp:Label ID="Label2" runat="server" Text="Descripción Larga:" />
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
    </div>

    <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Descripción Corta:" />
        <asp:TextBox ID="txtDescripcionCorta" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
    </div>
    <div class="form-section" style="text-align:center;">
    <asp:DropDownList ID="ddlTipoSitio" runat="server" CssClass="form-control" Width="250px">
        <asp:ListItem Text="Playa" Value="1" Selected="True" />
        <asp:ListItem Text="Montaña" Value="2" Selected="False" />
        <asp:ListItem Text="Citadino" Value="3" Selected="False" />
    </asp:DropDownList>
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
<!-- Sección: Facilidades -->
<div class="form-section">
    <h3>Facilidades del Sitio</h3>

    <p>Seleccione las facilidades que ofrece el sitio y, si lo desea, agregue una descripción.</p>

    <!-- DataTable (GridView) para mostrar y editar facilidades -->
  <asp:GridView ID="gvFacilidadesSitio" runat="server" CssClass="table table-striped"
    AutoGenerateColumns="False" DataKeyNames="IdFacilidad" 
    OnRowDeleting="gvFacilidadesSitio_RowDeleting">
    <Columns>
        <asp:BoundField DataField="IdFacilidad" HeaderText="ID" Visible="false" />
        <asp:BoundField DataField="NombreFacilidad" HeaderText="Facilidad" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción del Sitio" />
        <asp:CheckBoxField DataField="TieneFacilidad" HeaderText="Disponible" />
        <asp:CommandField ShowDeleteButton="True" DeleteText="Quitar" />
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
        <asp:Button ID="btnAgregarFacilidad" runat="server" Text="Agregar" CssClass="btn btn-secondary" OnClick="btnAgregarFacilidad_Click" />
    </div>
</div>

        <div class="form-section" style="text-align:center;">
    <asp:DropDownList ID="dllEstadoSitio" runat="server" CssClass="form-control" Width="250px">
        <asp:ListItem Text="Activo" Value="1" Selected="True" />
        <asp:ListItem Text="Inactivo" Value="2" Selected="False" />
    </asp:DropDownList>
</div>
        <!-- ComboBox -->
<div class="form-section" style="text-align:center;">
    <asp:DropDownList ID="ddlSitio" runat="server" CssClass="form-control" Width="250px">
        <asp:ListItem Text="Nuevo Sitio" Value="Nuevo" Selected="True" />
    </asp:DropDownList>
</div>

        <div class="form-section" style="max-width:600px;">
            <!-- Botones principales -->
            <div class="form-section" style="text-align:center;">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="boton-principal" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="boton-principal" style="background-color:#dc3545;" />
                <asp:Button ID="btnProbarFoto" runat="server" Text="Probar Foto" OnClick="btnProbarFoto_Click" />

            </div>

            <!-- Calendario -->
            <div class="form-section" style="text-align:center;">
                <h3>Calendario</h3>
                <asp:Calendar ID="Calendar1" runat="server" />
            </div>
        </div>

</div>

         </div>   
        <!--tercerp-->
        

      

    <script type="text/javascript">
        function cambiarImagen(imgMiniatura) {
            document.getElementById("imgPrincipal").src = imgMiniatura.src;
        }
    </script>
</asp:Content>
