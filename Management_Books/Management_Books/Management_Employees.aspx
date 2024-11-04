<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Management_Employees.aspx.cs" Inherits="Management_Books.Management_Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Employees</title>
    <link rel="shortcut icon" type="image/x-icon" href="../Nissei.ico" />
    <link rel="stylesheet" href="../Css/style.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                <%-------------------------------Thanh Tiêu Đề-------------------------------%>
                <table id="Table3" runat="server" enableviewstate="true" style="border-spacing: unset; width: 100%;">
                <tr>
                    <td style="border-style:none; border-spacing: unset; text-align: left; background-color:#006699; width:15%" >
                        <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Back" ID="btnBack" OnClick="btnBack_Click"/>
                       <%-- <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Save" />--%>
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
                <%-------------------------------Bảng Thao Tác-------------------------------%>
                <div style="width:100%;text-align:center;margin-top:15px">
                    <label style="font-size:25px; border:1px solid black;font-weight:bold;background-color:aqua;color:red" >Quản Lý Sử Dụng Sổ</label>
                </div>
                <div style="width:600px;border: 2px solid black;margin-left:40px;margin-top:10px;background-color:burlywood">
                    <div style="width:100%;border-bottom:2px dashed black;">
                        <div style="width:95%; margin-left:10px;margin-top:10px;">
                            <label>Loại Sổ:</label>
                        </div>
                        <div style="width:580px;display:flex; margin-left:10px;margin-top:10px; margin-bottom:10px">
                            <asp:Dropdownlist runat="server" style="width:50%;margin-right:15px" AutoPostBack="true" ID="ddlBoPhan" OnSelectedIndexChanged="ddlLoaiSo_IndexChanged">
                                <asp:ListItem>*********************************</asp:ListItem>
                                <asp:ListItem>Kashime</asp:ListItem>
                                <asp:ListItem>LineCut</asp:ListItem>
                                </asp:Dropdownlist>
                        <asp:Dropdownlist ID="ddlLoaiSo" style="width:50%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMa_So" ></asp:Dropdownlist>
                        <asp:Label ID="lblMa_So" style="display:none" AutoPostBack="true" runat="server"></asp:Label>
                        <asp:Label ID="lblID" runat="server" style="display:none"></asp:Label>
                        </div>
                    </div>
                    <div style="width:100%;border-bottom:2px dashed black">
                         <div style="width:200px; margin-left:10px;margin-top:10px">
                            <label>Mã Nhân Viên:</label>
                        </div>
                        <div style="width:580px; display:flex; margin-left:10px;margin-top:10px;margin-bottom:10px">
                        <asp:TextBox ID="txtMaNhanVien" style="width:50%;margin-right:15px" runat="server" AutoPostBack="true" OnTextChanged="txtMaNhanVien_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtTenNhanVien" style="width:50%" runat="server" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width:100%;border-bottom:2px dashed black">
                        <div style="width:200px; margin-left:10px;margin-top:10px; margin-bottom:10px">
                            <label>Admin:</label>
                            <asp:Checkbox ID="CheckAllQuyen" style="cursor:pointer" runat="server"></asp:Checkbox>
                        </div>
                    </div>
                    <div style="width:600px;text-align:center; margin-left:10px;margin-top:10px; margin-bottom:10px">
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:aliceblue;background-color:forestgreen; border-radius:5px;cursor:pointer" ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click"></asp:Button>
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:black;background-color:yellow; border-radius:5px;cursor:pointer" ID="btnDelete" runat="server" Text="Xóa" Visible="false" OnClick="btnDelete_Click"></asp:Button>
                    </div>
                </div>
                <br />
                <div style="width:100%;text-align:center">
                    <asp:Gridview style="width:100%" runat="server" ID="GridView1" AutoGenerateColumns="false" DataKeyNames="ID" Pagesize="10" HeaderStyle-BackColor="YellowGreen" >
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MSNV">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("MSNV")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Họ Tên">
                                <ItemTemplate>
                                    <asp:Label runat="server"  Text='<%# Eval("HoTen")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên Sổ">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Ten_So")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã Sổ">
                                <ItemTemplate>
                                    <asp:Label runat="server"  Text='<%# Eval("Ma_So")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="All Books">
                                <ItemTemplate>
                                    <asp:Label runat="server"  Text='<%# Eval("ALL_Books")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button CssClass="button2" ID="btnEdit" Text="Edit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("ID") %>' />
                                </ItemTemplate>
                    </asp:TemplateField>
                        </Columns>
                    </asp:Gridview>
                </div>
                <%-------------------------------Footer-------------------------------%>
                <br />
                <br />
                <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
            </ContentTemplate>
              <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlBoPhan" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlLoaiSo" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
