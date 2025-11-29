<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="FormRegistroXCliente.aspx.cs" 
    Inherits="Presentacion.PaginasCliente.FormRegistroXCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1 style="text-align:center;">Detalles de la Reserva</h1>

    <div class="sitios-principal" style="display:flex; flex-wrap:wrap; justify-content:center;">
        <asp:Repeater ID="repeaterReservas" runat="server" OnItemDataBound="repeaterReservas_ItemDataBound">

            <ItemTemplate>
                <div class="sitio-previa"
                     style="border:1px solid #ccc; padding:15px; margin:10px; width:320px; border-radius:8px; text-align:left; background-color:#f9f9f9;">
                    
                    <h3 style="text-align:center;"><%# Eval("NombreSitio") %></h3>
                    <hr />

                    <p><strong>Fecha de Inicio:</strong> <%# Eval("FechaInicio", "{0:dd/MM/yyyy}") %></p>
                    <p><strong>Fecha de Fin:</strong> <%# Eval("FechaFin", "{0:dd/MM/yyyy}") %></p>
                    <p><strong>Cliente:</strong> <%# Eval("NombreCliente") %></p>

                    <hr />
                    <p><strong>Precio por Noche:</strong> ₡<%# Eval("PrecioPorNoche", "{0:N2}") %></p>
                    <p><strong>Cantidad de Noches:</strong> <%# Eval("CantidadNoches") %></p>
                    <p><strong>Total de Personas:</strong> <%# Eval("TotalPersonas") %></p>
                    <p><strong>Subtotal:</strong> ₡<%# Eval("Subtotal", "{0:N2}") %></p>
                    <p><strong>Impuestos (13%):</strong> ₡<%# Eval("Impuestos", "{0:N2}") %></p>
                    <p>
                      <p id="pComision" runat="server">
                        <strong>Comisión (10%):</strong>
                        ₡<asp:Label ID="Label1" runat="server" Text='<%# Eval("Comision", "{0:N2}") %>' />
                    </p>
                     ₡<asp:Label ID="lblComision" runat="server" Text='<%# Eval("Comision", "{0:N2}") %>' />
                    </p>

                    <p><strong>Total a Pagar:</strong> <span style="color:green; font-weight:bold;">₡<%# Eval("TotalPagar", "{0:N2}") %></span></p>

                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
