<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormConsultaSitio.aspx.cs" Inherits="Presentacion.PaginasPublicas.FormConsultaSitio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
        .miniatura {
            width: 120px;
            height: 80px;
            border: 2px solid #ccc;
            border-radius: 8px;
            transition: border-color 0.3s;
            cursor: pointer;
        }
        .miniatura:hover {
            border-color: #007bff;
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
        }
        .btn-registrar {
            display:block;
            margin: 15px auto;
            padding: 10px 20px;
            font-size: 16px;
            background-color: #28a745;
            color: white;
            border: none;
            border-radius: 6px;
            cursor: pointer;
        }
        .btn-registrar:hover {
            background-color: #1e7e34;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align:center;">Detalles del Sitio</h2>
    <h2 style="text-align:center;"><asp:Label ID="lblTituloSitio" runat="server" Text="Detalles del Sitio" /></h2>

    <div style="display:flex; gap:4px; justify-content:center; align-items:flex-start; flex-wrap:wrap;">

        <!-- Sección: Imágenes -->
        <div class="form-section" style="max-width:600px;">
            <h3>Imágenes del Sitio</h3>
            <img id="imgPrincipal" runat="server" src="~/Imagenes/ImagenesSitios/sitioDefecto.jpg" class="imgPrincipal" alt="Imagen principal" />

            <br />

            <div class="galeria" id="galeriaFotos">
                <div class="galeria-item">
                    <img src="~/Imagenes/ImagenesSitios/sitioDefecto.jpg" class="miniatura" onclick="cambiarImagen(this);" />
                </div>
                <div class="galeria-item">
                    <img src="~/Imagenes/ImagenesSitios/sitioDefecto.jpg" class="miniatura" onclick="cambiarImagen(this);" />
                </div>
                <div class="galeria-item">
                    <img src="~/Imagenes/ImagenesSitios/sitioDefecto.jpg" class="miniatura" onclick="cambiarImagen(this);" />
                </div>
                <div class="galeria-item">
                    <img src="~/Imagenes/ImagenesSitios/sitioDefecto.jpg" class="miniatura" onclick="cambiarImagen(this);" />
                </div>
                <div class="galeria-item">
                    <img src="~/Imagenes/ImagenesSitios/sitioDefecto.jpg" class="miniatura" onclick="cambiarImagen(this);" />
                </div>
            </div>
        </div>

        <!-- Sección: Información general y detalles -->
        <div class="form-section" style="max-width:600px;">
            <h3>Información del Sitio</h3>
            <p><strong>Nombre:</strong> <asp:Label ID="lblNombreSitio" runat="server" Text="Sitio de Ejemplo" /></p>
            <p><strong>Descripción Corta:</strong> <asp:Label ID="lblDescripcionCorta" runat="server" Text="Descripción breve del sitio." /></p>
            <p><strong>Descripción Larga:</strong> <asp:Label ID="lblDescripcionLarga" runat="server" Text="Descripción completa y detallada del sitio." /></p>
            <p><strong>Tipo de Sitio:</strong> <asp:Label ID="lblTipoSitio" runat="server" Text="Playa" /></p>

            <h4>Ubicación</h4>
            <p><strong>Provincia:</strong> <asp:Label ID="lblProvincia" runat="server" Text="Guanacaste" /></p>
            <p><strong>Cantón:</strong> <asp:Label ID="lblCanton" runat="server" Text="Liberia" /></p>
            <p><strong>Distrito:</strong> <asp:Label ID="lblDistrito" runat="server" Text="Playa Hermosa" /></p>
            <p><strong>Dirección Exacta:</strong> <asp:Label ID="lblDireccion" runat="server" Text="Calle Falsa 123" /></p>
            <p><strong>Número de Casa:</strong> <asp:Label ID="lblNumeroCasa" runat="server" Text="12A" /></p>

            <h4>Detalles de alojamiento</h4>
            <p><strong>Habitaciones:</strong> <asp:Label ID="lblHabitaciones" runat="server" Text="3" /></p>
            <p><strong>Camas:</strong> <asp:Label ID="lblCamas" runat="server" Text="2" /></p>
            <p><strong>Baños:</strong> <asp:Label ID="lblBanos" runat="server" Text="2" /></p>
            <p><strong>Personas Máximas:</strong> <asp:Label ID="lblPersonasMax" runat="server" Text="6" /></p>
            <p><strong>Precio por Noche:</strong> ₡<asp:Label ID="lblPrecio" runat="server" Text="25000" /></p>
            <p><strong>Precio por persona:</strong> <asp:Label ID="lblPorPersona" runat="server" Text="Sí" /></p>
            <p><strong>Cargo de Limpieza:</strong> ₡<asp:Label ID="lblLimpieza" runat="server" Text="5000" /></p>
            <p><strong>Depósito de Seguridad:</strong> ₡<asp:Label ID="lblDeposito" runat="server" Text="10000" /></p>
            <p><strong>Mínimo de Noches:</strong> <asp:Label ID="lblMinNoches" runat="server" Text="2" /></p>
            <p><strong>Política de Cancelación:</strong> <asp:Label ID="lblPolitica" runat="server" Text="Flexible" /></p>
            <p><strong>Permite Mascotas:</strong> <asp:Label ID="lblMascotas" runat="server" Text="Sí" /></p>

          <h4>Facilidades</h4>
<asp:GridView ID="gvFacilidadesSitio" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="NombreFacilidad" HeaderText="Facilidad" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
    </Columns>
</asp:GridView>


            <h4>Calendario de Disponibilidad</h4>
            <asp:Calendar ID="Calendar1" runat="server" />

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn-registrar" OnClick="btnRegistrar_Click" />
        </div>
    </div>

    <script type="text/javascript">
        function cambiarImagen(imgMiniatura) {
            document.getElementById("<%= imgPrincipal.ClientID %>").src = imgMiniatura.src;
        }
    </script>
</asp:Content>
