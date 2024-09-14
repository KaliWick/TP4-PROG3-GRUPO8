<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4_GRUPO8.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <span class="auto-style1">DESTINO INICIO</span><br />
            <br />
            <asp:Label ID="lblProvinciaInicio" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="Large" Font-Underline="True" Text="Provincia:"></asp:Label>
            <asp:DropDownList ID="ddlProvinciaInicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaInicio_SelectedIndexChanged">
                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblLocalidadInicio" runat="server" Font-Bold="True" Font-Size="Large" Font-Underline="True" Text="Localidad:"></asp:Label>
            <asp:DropDownList ID="ddlLocalidadInicio" runat="server" Height="35px" style="margin-left: 15px" Width="110px">
                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            DESTINO FINAL<br />
            <br />
            <span class="auto-style1">
            <asp:Label ID="lblProvinciaFinal0" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="Large" Font-Underline="True" Text="Provincia:"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlProvinciaFinal0" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaFinal0_SelectedIndexChanged">
                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblLocalidadFinal" runat="server" Font-Bold="True" Font-Size="Large" Font-Underline="True" Text="Localidad:"></asp:Label>
            <asp:DropDownList ID="ddlLocalidadFinal" runat="server" Height="35px" style="margin-left: 4px" Width="110px">
                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
            </asp:DropDownList>
            </span>
        </div>
    </form>
</body>
</html>
