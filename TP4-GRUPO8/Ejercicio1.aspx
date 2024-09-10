<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4_GRUPO8.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span class="auto-style1">DESTINO INICIO</span><br />
            <br />
            <asp:Label ID="lblProvinciaInicio" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="Large" Font-Underline="True" Text="Provincia: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlProvinciaInicio" runat="server">
                <asp:ListItem>--Seleccionar--</asp:ListItem>
            </asp:DropDownList>
        </div>
        <p class="auto-style1">
            <asp:Label ID="lblLocalidadInicio" runat="server" Font-Bold="True" Font-Size="Large" Font-Underline="True" Text="Localidad:"></asp:Label>
            <asp:DropDownList ID="ddlLocalidadInicio" runat="server" Height="35px" style="margin-left: 15px" Width="110px">
                <asp:ListItem>--Seleccionar--</asp:ListItem>
            </asp:DropDownList>
        </p>
    </form>
</body>
</html>
