<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoThaoTac_Main.aspx.cs" Inherits="Management_Books.SoThaoTac_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Books</title>
    <link rel="shortcut icon" type="image/x-icon" href="Nissei.ico" />
    <link rel="stylesheet" href="../Css/style.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
</head>
<body>
    <form id="form1" runat="server">
        <%-- -------------------------------------------------------Thanh TaskBar------------------------------------------------------------------------------------------------- --%>
            <table id="Table3" runat="server" enableviewstate="true" style="border-spacing: unset; width: 100%;">
            <tr>
                <td style="border-style:none; border-spacing: unset; text-align: left; background-color:#006699; width:15%" >
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Back" ID="btnBack" OnClick="btnBack_Click"  />
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Create" OnClick="btnCreate_Click"  />
                </td>
                <td style="border-spacing: unset; font-family: 'times New Roman', Times, serif; background-color: #006699; font-size: 30px; text-align: center; border: none; font-weight: bold;">
                    <p style="padding: 0; margin: 0; color: #FFFFFF;">MANAGEMENT BOOKS PRODUCTION</p>
                </td>
                <td style="border-spacing: unset; border-style: none; background-color: #006699; text-align: right; width: 12%">
                    <div >
                        <asp:Label runat="server" ID="lblTenDanhNhap" ForeColor="White" Style=" display:inline-table; margin-right:10px" Font-Bold="True"></asp:Label>
                        <a class="button_logout" id="btnDangXuat" runat="server" onserverclick="btnDangXuat_Click">
                            <div class="logout">Log Out </div>
                        </a>
                    </div>
                </td>
            </tr>
    </table>
    <%-- ---------------------------------------------------------------Thanh Tìm Kiếm------------------------------------------------------------------------------------------------ --%>
    <div style="width:100%;text-align:left">
            <asp:Label Font-Size="20px"  runat="server">From Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtFromDate"></asp:TextBox>
            <asp:Label Font-Size="20px" runat="server">To Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtToDate"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtLotNL_Search" style="height: 25px"></asp:TextBox>
            <asp:Button Cssclass="button2" runat="server"  Text="Search"/>
    </div>
    <br />
    <%-- ---------------------------------------------------------------Bảng Dữ Liệu Các Phiếu---------------------------------------------------------------------------------------- --%>
    <div style="width:100%">
        <asp:GridView style="width:100%" runat="server" ID="GridView" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="STT">
                    <ItemTemplate>
                        <asp:Label runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID Phiếu">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblIDPhieu" Text='<%#Eval("ID_Phieu")%>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Line">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblLine" Text='<%# Eval("Line")%>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mã">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblMaSanPham" Text='<%# Eval("MaSanPham")%>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tên">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTenSanPham" Text='<%# Eval("TenSanPham")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bản Vẽ">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblBanVe" Text='<%# Eval("BanVe")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày Thao Tác">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNgayThaoTac" Text='<%# Eval("NgayThaoTac")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Người Đảm Nhiệm">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNguoiDamNhiem" Text='<%# Eval("NguoiDamNhiem")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <%-- ---------------------------------------------------------------Footer-------------------------------------------------------------------------------------------------------- --%>
    <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
    </form>
</body>
</html>
