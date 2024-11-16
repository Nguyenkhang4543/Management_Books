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
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Create" ID="Button1" OnClick="btnCreate_Click"  />
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" ID="btnHome" Text="Home" Visible="false" OnClick="btnHome_Click" />
                    <asp:Button CssClass="button2" runat="server" ID="btnadmin" Text="Admin" Visible="false" OnClick="btnAdmin_Click" />
                    <asp:Label ID="lblID" Style="display: none;" runat="server"></asp:Label>
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
    <div runat="server" id="taskMain">
    <%-- ---------------------------------------------------------------Thanh Tìm Kiếm------------------------------------------------------------------------------------------------ --%>
    <div style="width:100%;text-align:left; margin-top:15px;margin-left:15px">
            <asp:Button Cssclass="button2" ID="btnFirst" runat="server" Text="|&lt;" Font-Names="Times New Roman" Font-Size="Large" OnClick="btnFirst_Click" Font-Bold="True"/>
            <asp:Button Cssclass="button2" ID="btnPrevious" runat="server" Text="&lt;" Font-Names="Times New Roman" Font-Size="Large" OnClick="btnPrevious_Click" Font-Bold="True"/>
            <asp:Label ID="lblCurrPage" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lbl" runat="server" Text="/"></asp:Label>
            <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
            <asp:Button Cssclass="button2" ID="btnNext" runat="server" Text="&gt;" Font-Names="Times New Roman" Font-Size="Large"  OnClick="btnNext_Click"  Font-Bold="True"/>
            <asp:Button Cssclass="button2" ID="btnLast" runat="server" Text="&gt;|" Font-Names="Times New Roman" Font-Size="Large"  OnClick="btnLast_Click" Font-Bold="True"/>   
            <asp:Label Font-Size="20px"  runat="server">From Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtFromDate"></asp:TextBox>
            <asp:Label Font-Size="20px" runat="server">To Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtToDate"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtNoiDung" style="height: 25px"></asp:TextBox>
            <asp:Button Cssclass="button2" runat="server"  Text="Search" OnClick="btnSearch_Click" />
    </div>
    <br />
    <%-- ---------------------------------------------------------------Bảng Dữ Liệu Các Phiếu---------------------------------------------------------------------------------------- --%>
    <div style="width:100%">
        <asp:GridView runat="server" ID="GridView" style="text-align:center" AutoGenerateColumns="false" Width="100%" HeaderStyle-BackColor="Green" BackColor="Wheat" Font-Size="16px" HeaderStyle-ForeColor="White" OnRowCommand="GridView_RowCommand" >
            <Columns>
                <asp:TemplateField HeaderText="STT">
                    <ItemTemplate>
                        <asp:Label ID="lblSTT" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID Phiếu">
                    <ItemTemplate>
                        <asp:LinkButton ID="txtID" Text="View" runat="server" CommandName="View" CommandArgument="<%# Container.DataItemIndex %>" />  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Line">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblLine" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mã Sản Phẩm">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblMaSanPham" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tên Sản Phẩm">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTenSanPham"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bản Vẽ">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblBanVe"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày Thao Tác">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNgayThaoTac"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Người Đảm Nhiệm">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNguoiDamNhiem"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trạng Thái">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTrangThai"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Người Nhập">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNguoiNhap"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <%-- ---------------------------------------------------------------Footer-------------------------------------------------------------------------------------------------------- --%>
    </div>
    <div runat="server" id="taskadmin" visible="false">
        <div runat="server" id="Div1" visible="true">
            <div style="width:100%;text-align:center;margin-top:15px;margin-bottom:20px">
                    <label style="font-size:25px; border:1px solid black;font-weight:bold;background-color:aqua;color:red" >Phân Quyền Xác Nhận Sổ Thao Tác</label>
                </div>
                <div style="width:100%;">
                <div style="width:600px;border: 2px solid black;margin-top:10px;margin:auto;background-color:blanchedalmond">
                    <div style="width:100%;border-bottom:2px dashed black">
                         <div style="width:200px; margin-left:10px;margin-top:10px">
                            <label>Mã Nhân Viên:</label>
                        </div>
                        <div style="width:580px; display:flex; margin-left:10px;margin-top:10px;margin-bottom:10px">
                        <asp:TextBox ID="txtMaNhanVien" style="width:50%;margin-right:15px" runat="server" AutoPostBack="true" OnTextChanged="txtMaNhanVien_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtTenNhanVien" style="width:50%" runat="server" AutoPostBack="true"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" style="display:none"></asp:Label>
                        </div>
                    </div>
                    <div style="width:600px;text-align:center; margin-left:10px;margin-top:10px; margin-bottom:10px">
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:aliceblue;background-color:forestgreen; border-radius:5px;cursor:pointer" ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click"></asp:Button>
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:black;background-color:forestgreen; border-radius:5px;cursor:pointer" ID="btnThemMoi" runat="server" Text="Thêm Mới" Visible="false" OnClick="btnThemMoi_Click"></asp:Button>
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:black;background-color:yellow; border-radius:5px;cursor:pointer" ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click"></asp:Button>
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:white;background-color:red; border-radius:5px;cursor:pointer" ID="btnDelete" runat="server" Text="Xóa" Visible="false" OnClick="btnDelete_Click"></asp:Button>
                    </div>
                </div>
                </div>
                <br />
                <div style="width:100%;text-align:center">
                    <asp:Gridview style="width:100%" runat="server" ID="GridView2" AutoGenerateColumns="false" AutoPostBack="true" DataKeyNames="ID" AllowPaging="True" PageSize="10"
                        OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                        HeaderStyle-BackColor="Orange" >
                        <Columns>
                            <asp:TemplateField HeaderText="No." HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MSNV">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("MaNV")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Họ Tên">
                                <ItemTemplate>
                                    <asp:Label runat="server"  Text='<%# Eval("HoTen")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button CssClass="button2" ID="btnEdit" Text="Edit" runat="server" OnClick="btnEditQuyen_Click" CommandArgument='<%# Eval("ID") %>' />
                                </ItemTemplate>
                    </asp:TemplateField>
                        </Columns>
                    </asp:Gridview>
                </div>
            </div>
    </div>
    <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
    </form>
</body>
</html>
