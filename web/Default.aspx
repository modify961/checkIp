<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            当前共存储IP:<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        </div>
        <div>
            <table class="list" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <td>IP</td>
                        <td >端口号</td>
                        <td >数量</td>
                        <td >格式</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ip")%></td>
                                <td class="center"><%#Eval("port")%></td>
                                <td class="center"><%#Eval("type")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>

            </table>
        </div>
    </form>
</body>
</html>
