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
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Save" OnClick="btnSave_Click" />
                    <asp:Label ID="lblID" Style="display: none;" runat="server"></asp:Label>
                </td>
                <td style="border-spacing: unset; font-family: 'times New Roman', Times, serif; background-color: #006699; font-size: 30px; text-align: center; border: none; font-weight: bold;">
                    <p style="padding: 0; margin: 0; color: #FFFFFF;">MANAGEMENT BOOKS PRODUCTION</p>
                </td>
                <td style="border-spacing: unset; border-style: none; background-color: #006699; text-align: right; width: 12%">
                    <div >
                        <asp:Label runat="server" ID="lblTenDanhNhap" ForeColor="White" Style=" display:inline-table; margin-right:10px" Font-Bold="True"></asp:Label>
                        <a class="button_logout" id="btnDangXuat" runat="server" onserverclick="btnDangXuat_Click" >
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
            <table style="width:100%">
                <tr style="text-align:center; ">
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
                <tr style="width:100%; text-align:center">
                    <td>
                        <asp:Textbox ID="txtLotNL" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtDoan" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtNgayCat" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtLotCat" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtSanPham" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtKichThuocCat" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtSoDon" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtSoDoan" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtLeaderXacNhan" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                </tr>
            </table>
            <asp:HiddenField runat="server" ID="hdfID" />
        </div>

             <div style="width:100%;margin-top:10px;">
            <table style="width:100%">
                <tr style="text-align:center; ">
                    <td class="TieuDe">
                        <asp:Label runat ="server">Ngày cắt Cable</asp:Label>
                    </td>
                    <td class="TieuDe">
                        <asp:Label runat ="server">Lot Nguyên Liệu</asp:Label>
                    </td>
                    <td class="TieuDe">
                        <asp:Label runat ="server">Lot Thành Phẩm Cut</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Sản Phẩm</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Line Sản Xuất</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Bản Vẽ</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Kích Thước <br /> Cắt Cable (Bản Vẽ)</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Kích Thước <br /> Cắt Cable (Thực Tế)</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Máy Cắt</asp:Label>
                    </td>
                    <td class="TieuDe">
                        <asp:Label runat ="server">Số Đơn</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Số Đoạn</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Số Lượng Sử Dụng</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Người Thao Tác</asp:Label>
                    </td>
                    <td class="TieuDe">
                        <asp:Label runat ="server">Leader Xác Nhận</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Ghi Chú</asp:Label>
                    </td>
                </tr>
                <tr style="width:100%; text-align:center">
                    <td>
                        <asp:Textbox ID="Textbox1" Type="date" style="width:90%; height:25px" runat ="server"></asp:Textbox>

                    </td>
                     <td>
                        <asp:Textbox ID="Textbox2" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="Textbox3" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="Textbox4" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="Textbox5" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="Textbox6" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="Textbox7" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="Textbox8" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="Textbox9" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="Textbox10" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="Textbox11" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="Textbox12" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="Textbox13" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="Textbox14" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="Textbox15" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>

                </tr>
            </table>
            <asp:HiddenField runat="server" ID="HiddenField1" />
        </div>
        <div style="width:100%;text-align:center;margin-top:10px;">
            <asp:Label Font-Size="20px" runat="server">TÌM KIẾM</asp:Label>
        </div>
        <div style="width:100%;text-align:center">
            <asp:Label Font-Size="20px"  runat="server">From Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtFromDate"></asp:TextBox>
            <asp:Label Font-Size="20px" runat="server">To Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtToDate"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtLotNL_Search" style="height: 25px"></asp:TextBox>
            <asp:Button Cssclass="button2" runat="server"  OnClick="btnSearch_Click" Text="Search"/>
        </div>
<%--        <div style="width:100%; margin-top:15px">
            <asp:GridView runat="server" style="width:100%; text-align:center" AutoGenerateColumns="false" ID="GridView1" DataKeyNames="ID" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" >
                <Columns>
                    <asp:TemplateField HeaderText="LOT NL">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLotNL" Text='<%# Eval("LOT_NL")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số Bobin">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLotDoan" Text='<%# Eval("LOT_Doan")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ngày Cắt">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNgayCat" Text='<%# Eval("NGAYCAT")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LOT Cắt">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLotCat" Text='<%# Eval("LOT_Cat")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sản Phẩm">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSanPham" Text='<%# Eval("SanPham")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kích Thước <br/> Cắt">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblKichThuocCat" Text='<%# Eval("KichThuocCat")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số Đơn">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSoDon" Text='<%# Eval("So_Don")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số Đoạn">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSoDoan" Text='<%# Eval("So_Doan")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Leader <br/> Xác Nhận">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLeaderXacNhan" Text='<%# Eval("Leader_XacNhan")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button CssClass="button2" ID="btnEdit" Text="Edit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("ID") %>' />
                                </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>--%>
              <div style="width:100%; margin-top:15px">
            <asp:GridView runat="server" style="width:100%; text-align:center" AutoGenerateColumns="false" ID="GridView1" DataKeyNames="ID" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" >
                <Columns>
                     <asp:TemplateField HeaderText="Ngày Cắt Cable">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNgayCat" Text='<%# Eval("NGAYCAT")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LOT NL">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLotNL" Text='<%# Eval("LOT_NL")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="LOT Thành Phẩm Cut">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLotTp" Text='<%# Eval("LOT_TP")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sản Phẩm">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSanPham" Text='<%# Eval("SanPham")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Line Sx">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLineSx" Text='<%# Eval("LineSx")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bản Vẽ">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblBanVe" Text='<%# Eval("BanVe")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kích thước cắt Cable(Bản Vẽ)">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblKichThuocBanVe" Text='<%# Eval("KichThuocBanVe")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Kích thước cắt Cable(Thực Tế)">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblKichThuocThucTe" Text='<%# Eval("KichThuocThucTe")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Máy Cắt">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblMayCat" Text='<%# Eval("May_Cat")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số Đơn">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSoDon" Text='<%# Eval("So_Don")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số Đoạn">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSoDoan" Text='<%# Eval("So_Doan")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Số Lượng SD">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSoLuongSD" Text='<%# Eval("SoLuongSD")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Người Thao Tác">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNguoiThaoTac" Text='<%# Eval("NguoiThaoTac")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Leader <br/> Xác Nhận">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLeaderXacNhan" Text='<%# Eval("Leader_XacNhan")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GhiChu">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblGhiChu" Text='<%# Eval("GhiChu")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button CssClass="button2" ID="btnEdit" Text="Edit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("ID") %>' />
                                </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
        </div>
    </form>
</body>
</html>
