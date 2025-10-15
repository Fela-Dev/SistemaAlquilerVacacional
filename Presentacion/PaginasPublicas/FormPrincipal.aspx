<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="FormPrincipal.aspx.cs" 
    Inherits="Presentacion.PaginasPublicas.FormPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 style="text-align:center;">Explora Sitios Disponibles</h1>

    <!-- 🔹 Panel de filtros -->
    <asp:Panel ID="pnlFiltros" runat="server" CssClass="filtros" Style="border:1px solid #ccc; padding:15px; margin-bottom:20px; border-radius:10px;">
        <h3>Filtrar búsqueda</h3>

        <table style="width:100%; border-collapse:collapse;">
            <tr>
                <td style="padding:5px;">
                    <asp:Label runat="server" AssociatedControlID="txtFechaInicio" Text="Fecha Inicio:" />
                    <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control" />
                </td>
                <td style="padding:5px;">
                    <asp:Label runat="server" AssociatedControlID="txtFechaFin" Text="Fecha Fin:" />
                    <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control" />
                </td>
                <td style="padding:5px;">
                    <asp:Label runat="server" AssociatedControlID="ddlTipoSitio" Text="Tipo de sitio:" />
                    <asp:DropDownList ID="ddlTipoSitio" runat="server" CssClass="form-control">
                        <asp:ListItem Text="(Todos)" Value="" />
                        <asp:ListItem Text="Playa" Value="1" />
                        <asp:ListItem Text="Monstana" Value="2" />
                        <asp:ListItem Text="Citadino" Value="3" />
                    </asp:DropDownList>
                </td>
                <td style="padding:5px;">
                    <asp:Label runat="server" AssociatedControlID="txtProvincia" Text="Provincia:" />
                    <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" />
                </td>
                <td style="padding:5px;">
                    <asp:Label runat="server" AssociatedControlID="txtCanton" Text="Cantón:" />
                    <asp:TextBox ID="txtCanton" runat="server" CssClass="form-control" />
                </td>
            </tr>
            <tr>
                <td style="padding:5px;">
                    <asp:Label runat="server" AssociatedControlID="txtPersonas" Text="Personas mínimas:" />
                    <asp:TextBox ID="txtPersonas" runat="server" TextMode="Number" CssClass="form-control" />
                </td>
                <td style="padding:5px;">
                    <asp:Label runat="server" AssociatedControlID="txtPrecioMin" Text="Precio mínimo:" />
                    <asp:TextBox ID="txtPrecioMin" runat="server" TextMode="Number" CssClass="form-control" />
                </td>
                <td style="padding:5px;">
                    <asp:Label runat="server" AssociatedControlID="txtPrecioMax" Text="Precio máximo:" />
                    <asp:TextBox ID="txtPrecioMax" runat="server" TextMode="Number" CssClass="form-control" />
                </td>
                <td style="padding:5px;">
                    <asp:Label runat="server" AssociatedControlID="chkMascotas" Text="Permite mascotas:" />
                    <asp:CheckBox ID="chkMascotas" runat="server" />
                </td>
                <td style="padding:5px;">
                    <asp:Label runat="server" AssociatedControlID="txtFacilidades" Text="Facilidades (coma):" />
                    <asp:TextBox ID="txtFacilidades" runat="server" CssClass="form-control" Placeholder="WiFi,Piscina..." />
                </td>
            </tr>
        </table>

        <div style="text-align:right; margin-top:10px;">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" />
        </div>
    </asp:Panel>

    <!-- 🔹 Resultados -->
    <div class="sitios-principal" style="display:flex; flex-wrap:wrap; justify-content:center;">
        <asp:Repeater ID="repeaterSitios" runat="server">
            <ItemTemplate>
                <div class="sitio-previa"
                     style="border:1px solid #ccc; padding:10px; margin:10px; width:260px; border-radius:8px; text-align:center;">
                    <img src='<%# Eval("FotoPrincipal") %>'
                         alt='<%# Eval("NombreSitio") %>'
                         style="width:100%; height:150px; object-fit:cover; border-radius:8px;" />
                    <h3><%# Eval("NombreSitio") %></h3>
                    <p><strong>Ubicación:</strong> <%# Eval("Provincia") %>, <%# Eval("Canton") %></p>
                    <p><strong>Tipo:</strong> <%# Eval("TipoSitio") %></p>


                    <p><strong>Capacidad:</strong> <%# Eval("PersonasMaximas") %> personas</p>
                    <p><strong>Precio:</strong> ₡<%# Eval("PrecioPorNoche") %></p>
                    <asp:HyperLink ID="hlDetalles" runat="server"
                        NavigateUrl='<%# "~/PaginasPublicas/FormConsultaSitio.aspx?id=" + Eval("IdSitio") %>'
                        Text="Ver Detalles"
                        CssClass="btn btn-success" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
