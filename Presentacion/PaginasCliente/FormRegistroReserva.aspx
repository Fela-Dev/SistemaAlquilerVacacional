<%@ Page Title="Registrar Reserva" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormRegistroReserva.aspx.cs" Inherits="Presentacion.PaginasCliente.FormRegistroReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 600px;
            margin: 30px auto;
            padding: 25px;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 0 8px rgba(0,0,0,0.1);
        }
        h2 {
            text-align: center;
            color: #333;
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: block;
            font-weight: bold;
        }
        input[type="text"], input[type="number"], textarea {
            width: 100%;
            padding: 8px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }
        .btn-registrar {
            display: block;
            width: 100%;
            padding: 10px;
            font-size: 16px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 6px;
            cursor: pointer;
        }
        .btn-registrar:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <h2>Registrar Reserva</h2>

        <!-- Calendario Fecha Inicio -->
        <div class="form-group">
            <label>Fecha de Inicio</label>
            <asp:Calendar ID="calFechaInicio" runat="server"></asp:Calendar>
        </div>

        <!-- Calendario Fecha Fin -->
        <div class="form-group">
            <label>Fecha de Fin</label>
            <asp:Calendar ID="calFechaFin" runat="server"></asp:Calendar>
        </div>

        <!-- Cantidades -->
        <div class="form-group">
            <label>Total de Personas</label>
            <asp:TextBox ID="txtTotalPersonas" runat="server" TextMode="Number" />
        </div>
        <div class="form-group">
            <label>Cantidad de Adultos</label>
            <asp:TextBox ID="txtAdultos" runat="server" TextMode="Number" />
        </div>
        <div class="form-group">
            <label>Cantidad de Niños</label>
            <asp:TextBox ID="txtNinos" runat="server" TextMode="Number" />
        </div>
        <div class="form-group">
            <label>Cantidad de Bebés</label>
            <asp:TextBox ID="txtBebes" runat="server" TextMode="Number" />
        </div>

        <!-- Otros campos -->
        <div class="form-group">
            <label>Solicitudes Especiales</label>
            <asp:TextBox ID="txtSolicitudes" runat="server" TextMode="MultiLine" Rows="3" />
        </div>

        <div class="form-group">
            <label>Teléfono de Contacto</label>
            <asp:TextBox ID="txtTelefono" runat="server" />
        </div>
        <!-- Sección para mostrar resumen del costo -->
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

        <div class="form-group" style="margin-top:25px;">
            <h3>Resumen del Costo</h3>

            <asp:Panel ID="pnlResumenCosto" runat="server" CssClass="form-container" Visible="false">
                <table style="width:100%; border-collapse:collapse;">
                    <tr>
                        <td><strong>Precio por Noche:</strong></td>
                        <td><asp:Label ID="lblPrecioPorNoche" runat="server" Text="₡0.00"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Cantidad de Noches:</strong></td>
                        <td><asp:Label ID="lblCantidadNoches" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Total de Personas:</strong></td>
                        <td><asp:Label ID="lblTotalPersonas" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Subtotal:</strong></td>
                        <td><asp:Label ID="lblSubtotal" runat="server" Text="₡0.00"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Impuestos (13%):</strong></td>
                        <td><asp:Label ID="lblImpuestos" runat="server" Text="₡0.00"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Comisión (10%):</strong></td>
                        <td><asp:Label ID="lblComision" runat="server" Text="₡0.00"></asp:Label></td>
                    </tr>
                    <tr style="border-top:1px solid #ccc;">
                        <td><strong>Total a Pagar:</strong></td>
                        <td><asp:Label ID="lblTotal" runat="server" Text="₡0.00" Font-Bold="True"></asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:Button ID="btnCalcularCosto" runat="server" Text="Calcular Costo"
                        CssClass="btn-registrar"
                        OnClick="btnCalcularCosto_Click" />
        </div>

    </ContentTemplate>

   
   
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnCalcularCosto" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>


        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Reserva" CssClass="btn-registrar" OnClick="btnRegistrar_Click" />
    </div>
</asp:Content>
