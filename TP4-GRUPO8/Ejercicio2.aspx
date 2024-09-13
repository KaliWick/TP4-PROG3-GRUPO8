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
                <asp:ListItem Value="=">Igual a:</asp:ListItem>
                <asp:ListItem Value="&lt;">Menor a:</asp:ListItem>
                <asp:ListItem Value="&gt;">Mayor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtProducto" runat="server" Width="191px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblCateogria" runat="server" Text="ID Categoría:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlCategoria" runat="server">
                <asp:ListItem Value="=">Igual a:</asp:ListItem>
                <asp:ListItem Value="&lt;">Menor a:</asp:ListItem>
                <asp:ListItem Value="&gt;">Mayor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCategoria" runat="server" Width="186px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnQuitarFiltro" runat="server" Text="Quitar Filtro" OnClick="btnQuitarFiltro_Click" />
            <br />
            <br />
            <asp:GridView ID="grdProductos" runat="server">
            </asp:GridView>
            <br />
        </div>
        <div style="margin-left: 160px">
        </div>
    </form>
</body>
</html>
