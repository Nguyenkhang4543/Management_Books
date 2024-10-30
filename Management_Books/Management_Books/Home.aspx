<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Management_Books.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Books Home</title>
    <link rel="shortcut icon" type="image/x-icon" href="../Nissei.ico" />
    <link rel="stylesheet" href="../Css/style.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table id="Table3" runat="server" enableviewstate="true" style="border-spacing: unset; width: 100%;">
            <tr>
                <td style="border-style:none; border-spacing: unset; text-align: left; background-color:#006699; width:15%" ></td>
                <td style="border-spacing: unset; font-family: 'times New Roman', Times, serif; background-color: #006699; font-size: 30px; text-align: center; border: none; font-weight: bold;">
                    <p style="padding: 0; margin: 0; color: #FFFFFF;">MANAGEMENT BOOKS PRODUCTION</p>
                </td>
                <td style="border-spacing: unset; border-style: none; background-color: #006699; text-align: right; width: 12%">
                    <div >
                        <asp:Label runat="server" ID="lblTenDanhNhap" ForeColor="White" Style=" display:inline-table; margin-right:10px" Font-Bold="True"></asp:Label>
                        <a class="button_logout" id="btnDangXuat" runat="server" >
                            <div class="logout">Log Out</div>
                        </a>
                    </div>
                </td>
            </tr>
    </table>
    <div style="margin-top:10px">
        <label style="margin-left:15px;font-size:25px; font-weight:bold;color:#0C599F">Kashime :</label>
    </div>
    <div style="border-bottom: 3px solid #0C599F;padding: 0 10px 10px 10px; text-align: center;">
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ Thao Tác" OnClick="btnSoThaoTac_Click" />
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ Test Line" OnClick="btnSoTestLine_Click"/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
        <asp:Button CssClass="button3" type="submit" runat="server" Text="Sổ ..."/>
    </div>
     <div style="margin-top:10px">
        <label style="margin-left:15px;font-size:25px; font-weight:bold;color:#ff9999">Line Cut :</label>
    </div>
    <div style ="border-bottom: 3px solid #ff9999;padding: 0 10px 10px 10px; text-align: center;">
        <asp:button Cssclass="button4" type="submit" runat="server" Text="Sổ Cắt Cable" OnClick="btnSoCatCable_Click" />
        <asp:button Cssclass="button4" type="submit" runat="server" Text="Sổ ..." />
        <asp:button Cssclass="button4" type="submit" runat="server" Text="Sổ ..." />
        <asp:button Cssclass="button4" type="submit" runat="server" Text="Sổ ..." />
        <asp:button Cssclass="button4" type="submit" runat="server" Text="Sổ ..." />
        <asp:button Cssclass="button4" type="submit" runat="server" Text="Sổ ..." />
        <asp:button Cssclass="button4" type="submit" runat="server" Text="Sổ ..." />
        <asp:button Cssclass="button4" type="submit" runat="server" Text="Sổ ..." />
        <asp:button Cssclass="button4" type="submit" runat="server" Text="Sổ ..." />
        
    </div>
    <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
    </form>
</body>
</html>
