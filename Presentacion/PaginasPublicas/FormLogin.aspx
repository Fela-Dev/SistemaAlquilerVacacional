<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLogin.aspx.cs" Inherits="Presentacion.PaginasPublicas.FormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="EstiloLogin.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server" class="login-form">
        <div class="form-group">
            <label for="txtUsuario" class="form-label">Usuario:</label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-input"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtPassword" class="form-label">Contraseña:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-input"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn-login" OnClick="btnLogin_Click" />
        </div>

        <div class="form-error" id="lblError" runat="server" Visible="false">
        
        </div>
    </form>
</body>

</html>
