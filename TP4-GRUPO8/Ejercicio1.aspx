<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4_GRUPO8.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            DESTINO INICIO<br />
            <br />
            <asp:Label ID="lblPrvIni" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="Large" Font-Underline="True" Text="Provincia: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlPrvIni" runat="server">
                <asp:ListItem>Buenos Aires</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
