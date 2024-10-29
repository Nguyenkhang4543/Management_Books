<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoCatCable.aspx.cs" Inherits="Management_Books.SoCatCable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Books</title>
    <link rel="shortcut icon" type="image/x-icon" href="Nissei.ico" />
    <link rel="stylesheet" href="./Css/style.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:100%">
        <table id="Table3" runat="server" enableviewstate="true" style="border-spacing: unset; width: 100%;">
            <tr>
                <td style="border-style:none; border-spacing: unset; text-align: left; background-color:#006699; width:15%" >
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Back" ID="btnBack" OnClick="btnBack_Click"  />
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Save" />
                </td>
                <td style="border-spacing: unset; font-family: 'times New Roman', Times, serif; background-color: #006699; font-size: 30px; text-align: center; border: none; font-weight: bold;">
                    <p style="padding: 0; margin: 0; color: #FFFFFF;">MANAGEMENT BOOKS PRODUCTION</p>
                </td>
                <td style="border-spacing: unset; border-style: none; background-color: #006699; text-align: right; width: 12%">
                    <div >
                        <asp:Label runat="server" ID="lblTenDanhNhap" ForeColor="White" Style=" display:inline-table; margin-right:10px" Font-Bold="True"></asp:Label>
                        <a class="button_logout" id="btnDangXuat" runat="server" >
                            <div class="logout">Log Out </div>
                        </a>
                    </div>
                </td>
            </tr>
    </table>
        <div style="width:100%; text-align:center; font-size:25px;margin-top:10px;font-weight:bold; color:orangered">
            <label>Sổ Quản Lý Cắt Cable</label>
        </div>
        <div style="width:100%;margin-top:10px;">
            <table>
                <tr style="text-align:center">
                    <td class="TieuDe">
                        <asp:Label runat ="server">Lot Nguyên Liệu</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Đoạn</asp:Label>
                    </td>
                    <td class="TieuDe">
                        <asp:Label runat ="server">Ngày Cắt</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Lot Cắt</asp:Label>
                    </td>
                    <td class="TieuDe">
                        <asp:Label runat ="server">Sản Phẩm</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Kích Thước <br /> Cắt Cable</asp:Label>
                    </td>
                    <td class="TieuDe">
                        <asp:Label runat ="server">Số Đơn</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Số Đoạn</asp:Label>
                    </td>
                    <td class="TieuDe">
                        <asp:Label runat ="server">Leader Xác Nhận</asp:Label>
                    </td>
                </tr>
                <tr style="width:100%;text-align:center">
                    <td>
                        <asp:Textbox style="width:90%;" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox style="width:90%" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox style="width:90%" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox style="width:90%" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox style="width:90%" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox style="width:90%" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox style="width:90%" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox style="width:90%" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox style="width:90%" runat ="server"></asp:Textbox>
                    </td>
                </tr>
            </table>
        </div>
           <div style="width:100%;text-align:center;margin-top:10px;">
            <asp:Label Font-Size="20px" runat="server">TÌM KIẾM</asp:Label>
        </div>
        <div style="width:100%;text-align:center">
            <asp:Label Font-Size="20px" runat="server">From Date: </asp:Label>
            <asp:TextBox runat="server" type="Date" ID="txtFromDate"></asp:TextBox>
            <asp:Label Font-Size="20px" runat="server">To Date: </asp:Label>
            <asp:TextBox runat="server" type="Date" ID="txtToDate"></asp:TextBox>
            <asp:Button Cssclass="button2" runat="server" Text="Search"/>
        </div>
        <div style="width:100%; margin-top:15px">
            <asp:GridView runat="server" style="width:100%" AutoGenerateColumns="true" ID="GridView1">
            </asp:GridView>
        </div>
        <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
        </div>
    </form>
</body>
</html>
