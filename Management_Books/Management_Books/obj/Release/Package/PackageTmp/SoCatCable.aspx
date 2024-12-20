﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoCatCable.aspx.cs" Inherits="Management_Books.SoCatCable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Books</title>
    <link rel="shortcut icon" type="image/x-icon" href="Nissei.ico" />
    <link rel="stylesheet" href="Css/style.css" />
    <script src="Scripts/materialize.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
    <style>
        
        .button2 {
            background-color: #006699;
            border: none;
            color: white;
            padding: 8px;
            font-size: 16px;
            left: 10px;
            margin: 2px 2px;
            cursor: pointer;
            border-radius: 8px;
            border:black;
        }

            .button2:hover {
                color: red;
                background-color: #bbdeee;
            }
        .button3 {
            background-color: #e99e40;
            border: none;
            color: black;
            padding: 8px;
            font-size: 16px;
            left: 10px;
            margin: 2px 2px;
            cursor: pointer;
            border-radius: 8px;
            width:100px;
            height:40px;
            border:2px solid red;
            font-weight:bold;
        }

            .button3:hover {
                color: white;
                background-color: #84b2dc;
                border:2px solid black;
            }

        .button6 {
            width: 100px;
            background-color:green;
            border: none;
            color: white;
            padding: 8px;
            font-size: 16px;
            margin-left: 50px;
            margin: 2px 2px;
            cursor: pointer;
            border-radius: 4px;
            border: 1px solid black;
        }

            .button6:hover {
                color: white;
                background-color: #138496;
            }
    </style>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var inputs = document.querySelectorAll('input[type="text"], input[type="date"]');
            inputs.forEach(function (input, index) {
                input.addEventListener('keypress', function (e) {
                    if (e.key === 'Enter') {
                        e.preventDefault();
                        var nextInput = inputs[index + 1];
                        if (nextInput) {
                            nextInput.focus();
                        }
                    }
                });
            });
        });
    </script>
</head>
    
<body>
    <form id="form1" runat="server">
        <div style="width:100%">
        <table id="Table3" runat="server" enableviewstate="true" style="border-spacing: unset; width: 100%;">
            <tr>
                <td style="border-style:none; border-spacing: unset; text-align: left; background-color:#006699; width:15%" >
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Back" ID="btnBack" OnClick="btnBack_Click"  />
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" ID="btnHome" Text="Home" Visible="false" OnClick="btnHome_Click" />
                    <asp:Button CssClass="button2" runat="server" ID="btnadmin" Text="Admin" Visible="false" OnClick="btnAdmin_Click" />
                    <asp:Label ID="lblID" Style="display: none;" runat="server"></asp:Label>
                    <asp:CheckBox runat="server" ID="CheckAdmin" style="display:none"/>
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
       <%--------------------------------------------------Import Du Lieu Nguon------------------------------------------------------------%>
        <br />
        <div runat="server" id="btnLabelImport" visible="false" enableviewstate="true">
            <label style="margin-left:20px; font-size:20px;font-weight:bold">Import Data Source:</label>
        </div>
        <div runat="server" id="taskbar_ImportDuLieuNguon" enableviewstate="true" style= "width:480px;margin-top:10px; margin-left:20px;border: 1px solid black" visible="false">
            <asp:Button runat="server" CssClass="button6" Text="Sample file"  OnClick="btnSamPle_Click"/>
            <asp:Fileupload runat="server" ID="FileUpLoad" style="background-color:aliceblue"/>
            <asp:Button runat="server" CssClass="button6" Text="Import" ID="btnImport" OnClick="btnImport_Click"></asp:Button>
        </div>
        <div runat="server" id="taskbarThaoTac" visible="true" >
        <div style="width:100%; text-align:center; font-size:25px;margin-top:10px;font-weight:bold; color:orangered">
            <label>Sổ Quản Lý Cắt Cable</label>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
        <div style="width:100%;margin-top:10px;">
            <table style="width:100%;">
                <tr style="text-align:center; ">
                    <td class="TieuDe">
                        <asp:Label runat ="server">Ngày cắt Cable</asp:Label>
                    </td>
                     <td class="TieuDe">
                        <asp:Label runat ="server">Mã Sản Phẩm</asp:Label>
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
                        <asp:Textbox ID="txtNgayCatCable" ClientIDMode="Static" Type="date" style="width:90%; height:25px;" runat ="server"></asp:Textbox>

                    </td>
                    <td>
                        <asp:Textbox ID="txtMaSP" ClientIDMode="Static" style="width:90%; height:25px" runat ="server" AutoPostBack="true" OnTextChanged="txtMaSP_TextChanged" ></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtLotNguyenLieu" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtLotThanhPham" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtTenSanPham" ReadOnly="true" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtLineSanXuat" ReadOnly="true" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtBanVe" ReadOnly="true" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtKTBanVe" ReadOnly="true" style="width:50%; height:25px" runat ="server"></asp:Textbox>
                        <asp:Label runat="server" ID="lblDoLech"></asp:Label>
                    </td>
                     <td>
                        <asp:Textbox ID="txtKTThucTe" ClientIDMode="Static" style="width:90%; height:25px" runat ="server" AutoPostBack="true" OnTextChanged="txtKTThucTe_TextChanged" ></asp:Textbox>
                    </td>
                     <td>
                        <asp:Textbox ID="txtMayCat" ClientIDMode="Static" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="txtSoDonNew" ClientIDMode="Static" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="txtSoDoanNew" ClientIDMode="Static" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="txtSoLuong" ClientIDMode="Static" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="txtNguoiThaoTac" ClientIDMode="Static" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="txtLeader" ClientIDMode="Static" style="width:90%; height:25px" Visible="false" runat ="server"></asp:Textbox>
                    </td>
                       <td>
                        <asp:Textbox ID="txtGhiChu" ClientIDMode="Static" style="width:90%; height:25px" runat ="server"></asp:Textbox>
                    </td>

                </tr>
            </table>
            <asp:HiddenField runat="server" ID="hdfID1" />
        </div>
        <div style="width:100%;text-align:center;margin-top:10px;">
            <asp:Label Font-Size="20px" runat="server">TÌM KIẾM</asp:Label>
        </div>
        <div style="width:100%;text-align:center" enableviewstate="true">
            <asp:Label Font-Size="20px"  runat="server">From Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtFromDate"></asp:TextBox>
            <asp:Label Font-Size="20px" runat="server">To Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtToDate"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtLotNL_Search" style="height: 25px"></asp:TextBox>
            <asp:Button Cssclass="button3" runat="server"  OnClick="btnSearch_Click" Text="Search"/>
        </div>
        <div style="width:100%; margin-top:15px">
            <asp:GridView runat="server" style="width:100%; text-align:center" AutoGenerateColumns="false" ID="GridView1" DataKeyNames="ID" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" >
                <Columns>
                     <asp:TemplateField HeaderText="Ngày Cắt Cable">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNgayCat" Text='<%# Eval("NgayCatCable")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Mã Sản Phẩm">
                        <ItemTemplate>
                            <asp:Label runat="server"  ID="lblMaSanPham" Text='<%# Eval("MaSP")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LOT NL">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLotNL" Text='<%# Eval("LotNguyenLieu")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="LOT Thành Phẩm Cut">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLotTp" Text='<%# Eval("LotThanhPham")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sản Phẩm">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSanPham" Text='<%# Eval("TenSanPham")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Line Sx">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLineSX" Text='<%# Eval("LineSanXuat")%>'></asp:Label>
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
                            <asp:Label runat="server" ID="lblMayCat" Text='<%# Eval("MayCat")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số Đơn">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSoDon" Text='<%# Eval("SoDon")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số Đoạn">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSoDoan" Text='<%# Eval("SoDoan")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Số Lượng SD">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSoLuongSD" Text='<%# Eval("SoLuong")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Người Thao Tác">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNguoiThaoTac" Text='<%# Eval("NguoiThaoTac")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Leader <br/> Xác Nhận">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLeaderXacNhan" Text='<%# Eval("LeaderXacNhan")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GhiChu">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblGhiChu" Text='<%# Eval("GhiChu")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GhiChu">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNguoiTaoPhieu" Text='<%# Eval("NguoiTaoPhieu")%>'></asp:Label>
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
        </div>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtMaSP" />
            <asp:AsyncPostBackTrigger ControlID="txtKTThucTe" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        <div runat="server" id="taskadmin" visible="false" enableviewstate="true">
            <div style="width:100%;text-align:center;margin-top:15px;margin-bottom:20px">
                    <label style="font-size:25px; border:1px solid black;font-weight:bold;background-color:aqua;color:red" >Phân Quyền Leader Xác Nhận</label>
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
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:aliceblue;background-color:#4c8aa9; border-radius:5px;cursor:pointer" ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click"></asp:Button>
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:white;background-color:#4c8aa9; border-radius:5px;cursor:pointer" ID="btnThemMoi" runat="server" Text="Thêm Mới" Visible="false" OnClick="btnThemMoi_Click"></asp:Button>
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
