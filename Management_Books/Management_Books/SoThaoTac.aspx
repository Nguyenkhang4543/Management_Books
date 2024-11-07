<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoThaoTac.aspx.cs" Inherits="Management_Books.SoThaoTac" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Books</title>
    <link rel="shortcut icon" type="image/x-icon" href="Nissei.ico" />
    <link rel="stylesheet" href="../Css/style.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
    <style type="text/css">

        .font {
            font-weight: bold;
            text-align: center;
            background-color: #feffa9;
        }
        .font1 {
             font-weight: bold;
        }
        .textbox1{
            width:80%;
        }
        .textbox2{
            width:90%;
        }
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                 <div style="width:100%">
        <%-------------------------------Thanh Tiêu Đề-------------------------------%>
        <table id="Table3" runat="server" enableviewstate="true" style="border-spacing: unset; width: 100%;">
            <tr>
                <td style="border-style:none; border-spacing: unset; text-align: left; background-color:#006699; width:15%" >
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Back" ID="btnBack" OnClick="btnBack_Click"  />
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Save" OnClick="btnSave_Click"  />
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
        <br />
        <%-------------------------------Số Quản Lý QC-------------------------------%>
        <table style="width:100%;border: 1px solid #143c54; background: #d1f0ff; border-spacing: unset; margin-bottom:5px">
                <tr style="height:30px;">
                    <td style="width: 20%; font-weight: bold; font-size: 30px; border: 1px solid #143c54; text-align: center" class="center" rowspan="3"><span>NEM</span></td>
                    <td style="width: 50%; font-weight: bold; font-size: 24PX; border: 1px solid #143c54; text-align: center" class="center" rowspan="3"><span>BẢNG THAO TÁC SẢN PHẨM KASHIME<br />
                        カシメ製品の作業表</span></td>
                    <td style="width: 10%; font-weight: bold; text-align: left; border: 1px solid #143c54;"><span>KMH:</span></td>
                    <td style="width: 20%; text-align: left; border: 1px solid #143c54;"><span>KMH:NEV-03-M-(WA)-F014 (1)</span></td>
                </tr>
                <tr  style="height:30px;">
                    <td style="width: 10%; font-weight: bold; text-align: left; border: 1px solid #143c54;"><span>NGAY日:</span></td>
                    <td style="width: 20%; text-align: left; border: 1px solid #143c54;"><span>2017.10.05</span></td>
                </tr>
                <tr style="height:30px;">
                    <td style="width: 10%; font-weight: bold; text-align: left; border: 1px solid #143c54;"><span>Trangページ:</span></td>
                    <td style="width: 20%; text-align: left; border: 1px solid #143c54;"><span>1/1</span></td>
                </tr>
         </table>
        <asp:Label runat="server" ID="lblID_Phieu"></asp:Label>
        <asp:Label runat="server" ID="lblTrangThai"></asp:Label>
        <%-------------------------------Bảng Số 2-------------------------------%>
        <table class ="tblForm" style=" margin-bottom:5px">            
                <tr style="text-align: center">
                    <td class="font">LINE ライン: </td>
                    <td class="font">CABLE ケーブル</td>
                    <td class="font">SLEEVE スリーブ</td>
                </tr>
                <tr>
                    <td class="font1">Lineライン:
                    <asp:TextBox runat="server" ID="txtLine"></asp:TextBox>
                    </td>
                    <td >
                        <asp:TextBox class="textbox2" ID="txtCable1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox class="textbox2"  ID="txtSlevee1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="font1">Bản vẽ 図面:
                    <asp:TextBox runat="server" ID="txtBanVe"></asp:TextBox>
                    </td>
                    <td >
                        <asp:TextBox class="textbox2" ID="txtCable2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox class="textbox2"  ID="txtSlevee2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="font1">Mã sp 品目:
                        <asp:TextBox runat="server" ID="txtMaSanPham"></asp:TextBox>
                    </td>
                    <td >
                        <asp:TextBox class="textbox2"  ID="txtCable3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox class="textbox2" ID="txtSlevee3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="font1">Tên sp 品名:
                        <asp:TextBox runat="server" ID="txtTenSanPham"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox class="textbox2"  ID="txtCable4" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox class="textbox2"  ID="txtSlevee4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="font1">Ngày thao tác 作業日:
                        <asp:TextBox type="date" runat="server" ID="txtNgayThaoTac"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox class="textbox2"  ID="txtCable5" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox class="textbox2"  ID="txtSlevee5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="font1">Đảm nhiệm 担当:
                        <asp:TextBox runat="server" ID="txtNguoiDamNhiem"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="font1">Hơi máy dập 圧力( 0.4 ~  0.5 ):
                        <asp:TextBox runat="server" ID="txtHoiMayDap"></asp:TextBox>
                    </td>
                </tr>
            </table>
        <%-------------------------------Grid View-------------------------------%>
        <div>
            <asp:GridView ID="GridView1" runat="server" style="width:100%; text-align:center" AutoGenerateColumns="False" HeaderStyle-BackColor="#feffa9">
                 <Columns>
                     <asp:TemplateField HeaderStyle-Width="1%" HeaderText="OK">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" style="height:50px" AutoPostBack="True" Enabled="false" runat="server" Visible="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lot No。<br /> ロットNo.">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtSoDon" runat="server" placeholder="STT Đơn"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtSoLot" runat="server" placeholder="Số Lot"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtNgaySanXuat" runat="server" placeholder="Ngày,Ca SX"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Số <br />lượng<br/>数量">
                            <ItemTemplate>
                                <asp:TextBox style="width:50px" ID="txtSoLuong" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Set cable <br/> Dập máy <br />ケーブルセ <br />ット カシメ">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px" ID="txtSetCable" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dập sleeve <br />スリーブカ<br />シメ">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px" ID="txtDapSleeve" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Số <br /> lượng <br /> đóng gói <br />梱包数 <br />量">
                            <ItemTemplate>
                                <asp:TextBox  style="width:50px" ID="txtSoLuongDongGoi" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Số lượng <br /> bù <br />補充数量">
                            <ItemTemplate>
                                <asp:TextBox style="width:50px" ID="txtSoLuongBu" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MSNV <br /> đóng gói <br />梱包者の <br />社員">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtMSNV_DongGoi_1" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtMSNV_DongGoi_2" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtMSNV_DongGoi_3" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtMSNV_DongGoi_4" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MSNV <br /> đóng thùng <br />箱梱包者の<br />社員">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtMSNV_DongThung_1" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtMSNV_DongThung_2" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtMSNV_DongThung_3" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtMSNV_DongThung_4" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Leader đóng gói <br /> 梱包リ<br />ーダー">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px" ID="txtLeader_DongGoi" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cable<br />ケーブル">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtCable" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px" ID="txtQC_Confirm" runat="server" placeholder="QC Confirm"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sleeve<br />スリーブ">
                            <ItemTemplate>
                                <asp:TextBox style="width:50px" ID="txtSleeve" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nhúng chì <br />予備半田">
                            <ItemTemplate>
                                <asp:TextBox style="width:50px" ID="txtNhungChi" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="6-9h">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_1" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_2" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_3" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_4" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="10-12h">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_5" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_6" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_7" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_8" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="13-15h">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_9" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_10" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_11" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_12" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="16-18h">
                            <ItemTemplate>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_13" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_14" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_15" runat="server"></asp:TextBox>
                                <asp:TextBox style="width:80px;margin-bottom:5px" ID="txtGiaoNhan_16" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OK Đơn<br />ロット">
                            <ItemTemplate>
                                <asp:TextBox style="width:50px" ID="txtOkDon" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
            </asp:GridView>
           <%-- <asp:Button class="button" ID="btnAddNewRow" runat="server" Text="+" OnClick="btnAddNewRow_Click" Height="30px" Width="36px" />
            <asp:Button class="button" ID="btnDeleteRow" runat="server" Text="-" Onclick="btnDeleteRow_Click" Height="30px" Width="36px" />--%>
            <asp:Button class="button" ID="btnAddNewRow" runat="server" Text="+" OnClick="btnAddNewRow_Click" Height="30px" Width="36px" />
            <asp:Button class="button" ID="btnDeleteRow" runat="server" Text="-" OnClick="btnDeleteRow_Click" Height="30px" Width="36px" />
        </div>
        <%-------------------------------Footer-------------------------------%>
        <br />
        <br />
        <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
        </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAddNewRow" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDeleteRow" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
    