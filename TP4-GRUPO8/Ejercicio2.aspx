<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4_GRUPO8.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblIdProducto" runat="server" Text="Id Producto:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlProducto" runat="server">
                <asp:ListItem Value="Igual">Igual a:</asp:ListItem>
                <asp:ListItem Value="Menor">Menor a:</asp:ListItem>
                <asp:ListItem Value="Mayor">Mayor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtProducto" runat="server" Width="175px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblCateogria" runat="server" Text="ID Categoría:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlCategoria" runat="server">
                <asp:ListItem Value="Igual">Igual a:</asp:ListItem>
                <asp:ListItem Value="Menor">Menor a:</asp:ListItem>
                <asp:ListItem Value="Mayor">Mayor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCategoria" runat="server" Width="186px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
