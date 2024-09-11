<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3a.aspx.cs" Inherits="TP4_GRUPO8.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTemas" runat="server" Text="Seleccionar Temas:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlTemas" runat="server">
                <asp:ListItem Value="Tema1">Tema 1</asp:ListItem>
                <asp:ListItem Value="Tema2">Tema 2</asp:ListItem>
                <asp:ListItem Value="Tema3">Tema 3</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            <asp:LinkButton ID="lnkbtnVerLibros" runat="server" OnClick="lnkbtnVerLibros_Click">Ver libros</asp:LinkButton>
        </div>
    </form>
</body>
</html>
