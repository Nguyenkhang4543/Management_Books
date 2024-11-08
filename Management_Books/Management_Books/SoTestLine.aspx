<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoTestLine.aspx.cs" Inherits="Management_Books.SoTestLine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Books</title>
    <link rel="shortcut icon" type="image/x-icon" href="Nissei.ico" />
    <link rel="stylesheet" href="Css/style.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
</head>
<body>
     <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
        <div style="width:100%" runat="server" id="btnMain" visible="true">
            <table id="Table3" runat="server" enableviewstate="true" style="border-spacing: unset; width: 100%;">
            <tr>
                <td style="border-style:none; border-spacing: unset; text-align: left; background-color:#006699; width:15%" >
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Back" ID="btnBack" OnClick="btnBack_Click" />
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Admin" Visible="false" ID="btnAdminMain" OnClick="btnAdminMain_Click" />
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
            <div style="margin-top: 5px; overflow: auto; text-align: center">
            <asp:Table runat="server" BorderWidth="1px" Width="100%" CellPadding="0" CellSpacing="0" GridLines="Both">

            <asp:TableRow>
                <asp:TableCell ColumnSpan="5" ></asp:TableCell>
                <asp:TableCell ColumnSpan="20" BorderStyle="None" Style="background-color: #e2dfdf">
                    Người xác nhận (*)<br />
                    Ca 1: ACB (SX+QC) trở lên<br />
                    Ca 3: Leader SX và QC xác nhận chéo
                </asp:TableCell>
                <asp:TableCell ColumnSpan="7" BorderStyle="None" Style="background-color: #e2dfdf">
                    (O: đã hoàn thành<br />
                    X: chưa hoàn thành)
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow >
  
                <asp:TableCell RowSpan="3" Style="background-color: #fffdb4">Line</asp:TableCell>
                <asp:TableCell RowSpan="3" Style="background-color: #fffdb4">Ngày sản xuất</asp:TableCell>
                <asp:TableCell RowSpan="3" Style="background-color: #fffdb4" >Thời gian đổi sản phẩm</asp:TableCell>
                <asp:TableCell RowSpan="3" Style="background-color: #fffdb4">Sản phẩm <br /> đang sản xuất</asp:TableCell>
                <asp:TableCell RowSpan="3" Style="background-color: #fffdb4"> Sản phẩm <br /> mới</asp:TableCell>
                <asp:TableHeaderCell ColumnSpan="11" style="background-color: #7be040">DẬP CABLE</asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="9" style="background-color: #ff9c55" >QC</asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="7" style="background-color: #32b4ff" >ĐÓNG GÓI</asp:TableHeaderCell>
            </asp:TableRow>
            <%-------------------DẬP CABLE-----------------%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Style="background-color: #cffeb3" >Dập nguyên liệu còn lại về line nguyên liệu</asp:TableCell>
                <asp:TableCell ColumnSpan="2" Style="background-color: #cffeb3" >Gom tất cả dây quăng trong máy</asp:TableCell>
                <asp:TableCell ColumnSpan="2" Style="background-color: #cffeb3" >Thành phẩm đã giao hết qua QC</asp:TableCell>
                <asp:TableCell ColumnSpan="2" Style="background-color: #cffeb3" >Không còn phế phẩm của sản phẩm A</asp:TableCell>
                <asp:TableHeaderCell ColumnSpan="2" Style="background-color: #cffeb3" >ACB Xác nhận</asp:TableHeaderCell>
                <asp:TableCell RowSpan="2" Style="background-color: #cffeb3" >GHI CHÚ </asp:TableCell>
            <%-------------------QC-----------------%>
                <asp:TableCell ColumnSpan="2" Style="background-color: #ffcda9" >Không còn sản phẩm A ở công đoạn CDC hoặc đặc tính</asp:TableCell>
                <asp:TableCell ColumnSpan="2" Style="background-color: #ffcda9">Không còn sản phẩm A ở công đoạn kiểm tra đặc tính</asp:TableCell>
                <asp:TableCell ColumnSpan="2" Style="background-color: #ffcda9">Không còn sản phẩm A ở công đoạn kiểm tra ngoại dạng</asp:TableCell>
                <asp:TableHeaderCell ColumnSpan="2" Style="background-color: #ffcda9">ACB Xác nhận</asp:TableHeaderCell>
                <asp:TableCell RowSpan="2" Style="background-color: #ffcda9">GHI CHÚ</asp:TableCell>
            <%-------------------ĐÓNG GÓI-----------------%>
                <asp:TableCell ColumnSpan="2" Style="background-color: #baeaf3">Khay, khuôn bẻ Taibar, trên line không còn sản phẩm A</asp:TableCell>
                <asp:TableCell ColumnSpan="2" Style="background-color: #baeaf3">Tất cả sản phẩm A đã được đóng gói và đóng thùng</asp:TableCell>
                <asp:TableHeaderCell ColumnSpan="2" Style="background-color: #baeaf3">ACB Xác nhận</asp:TableHeaderCell>
                <asp:TableCell RowSpan="2" Style="background-color: #baeaf3">GHI CHÚ</asp:TableCell>
            </asp:TableRow>
            <%-------------------XÁC NHẬN-----------------%>
            <asp:TableRow Style="background-color: #e2dfdf">
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>SX</asp:TableCell>
                <asp:TableCell>QC</asp:TableCell>

                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>SX</asp:TableCell>
                <asp:TableCell>QC</asp:TableCell>

                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>KQ</asp:TableCell>
                <asp:TableCell>SX</asp:TableCell>
                <asp:TableCell>QC</asp:TableCell>
            </asp:TableRow>
            <%-- ------------------TextBox------------------%>
            <asp:TableRow style ="height:40px; text-align:center">
     
                <asp:TableCell><asp:TextBox ID="txtSo_Line" style="width: 50px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtNgay_SX" type="date" style="width: 100px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtThoiGianDoi_SP" style="width: 50px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSP_DangThaoTac" style="width: 80px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSP_TienHanhDoi" style="width: 80px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
     
                <asp:TableCell><asp:TextBox ID="txtKTConLai_1" style="width: 25px; height:25px" runat="server" ></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKTConLai_2" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtThuGomConLai_1" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtThuGomConLai_2" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtGiaoTP_QC_1" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtGiaoTP_QC_2" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtKTPhePham_1" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKTPhePham_2" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtACB_XacNhan_SX_1" style="width: 40px; height:25px" Enabled="false" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtACB_XacNhan_QC_1" style="width: 40px; height:25px" Enabled="false" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtDapCable_GhiChu" style="width: 70px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtKTCDC_A_1" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKTCDC_A_2" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtKTCD_DTA_1" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKTCD_DTA_2" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtKTND_A1" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKTND_A2" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtACB_XacNhan_SX_2" style="width: 40px; height:25px" Enabled="false" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtACB_XacNhan_QC_2" style="width: 40px; height:25px" Enabled="false" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtQC_GhiChu" style="width: 70px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
       
                <asp:TableCell><asp:TextBox ID="txtKTTaibar_A_1" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKTTaibar_A_2" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtKTDongGoi_A_1" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKTDongGoi_A_2" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtACB_XacNhan_SX_3" style="width: 40px; height:25px" Enabled="false" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtACB_XacNhan_QC_3" style="width: 40px; height:25px" Enabled="false" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtDongGoi_GhiChu" style="width: 70px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            </asp:Table>

            </div>
            <div style="width:100%;text-align:center; margin-top:10px">
                <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Save"  OnClick="btnSave_Click" />
            </div>
             <asp:HiddenField runat="server" ID="hdfID" />
             <asp:CheckBox runat="server" ID="CheckAdmin" style="display:none"/>
            <div style="width:100%;text-align:center">
            <asp:Label Font-Size="20px"  runat="server">From Date: </asp:Label>
            <asp:TextBox runat="server"  style="height: 25px" type="Date" ID="txtFromDate"></asp:TextBox>
            <asp:Label Font-Size="20px" runat="server">To Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtToDate"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtSoLine_Search" style="height: 25px"></asp:TextBox>
            <asp:Button Cssclass="button2" runat="server"  OnClick="btnSearch_Click" Text="Search"/>
            </div>
            <div style="width:100%">
                <asp:GridView runat ="server" ID="GridView" AutoGenerateColumns="false" Width="100%"  DataKeyNames="ID" >
                    <Columns>
                        <asp:TemplateField HeaderText="Line" HeaderStyle-BackColor="#fffdb4">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSo_Line" Text='<%# Eval("So_Line")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày Sản Xuất" HeaderStyle-BackColor="#fffdb4">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblNgay_SX" Text='<%# Eval("Ngay_SX")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thời Gian Đổi Sản Phẩm" HeaderStyle-BackColor="#fffdb4">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblThoiGianDoi_SP" Text='<%# Eval("ThoiGianDoi_SP")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sản Phẩm Đang Sản Xuất" HeaderStyle-BackColor="#fffdb4">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSP_DangThaoTac" Text='<%# Eval("SP_DangThaoTac")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sản Phẩm Mới" HeaderStyle-BackColor="#fffdb4">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSP_TienHanhDoi" Text='<%# Eval("SP_TienHanhDoi")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dập nguyên liệu còn lại về line nguyên liệu" HeaderStyle-BackColor="#cffeb3">
                            <ItemTemplate>
                                <div style="text-align:center">
                                    <asp:Label runat="server" ID="lblKTConLai_1" Text='<%# Eval("KTConLai_1")%>'></asp:Label>
                                    <asp:Label runat="server" style="color:black;" Text="|"></asp:Label>
                                    <asp:Label runat="server" ID="lblKTConLai_2" Text='<%# Eval("KTConLai_2")%>'></asp:Label>
                                </div>
                           </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gom tất cả dây quăng trong máy" HeaderStyle-BackColor="#cffeb3">
                            <ItemTemplate>
                                <div style="text-align:center">
                                    <asp:Label runat="server" ID="lblThuGomConLai_1" Text='<%# Eval("ThuGomConLai_1")%>'></asp:Label>
                                    <asp:Label runat="server" style="color:black;" Text="|"></asp:Label>
                                    <asp:Label runat="server" ID="lblThuGomConLai_2" Text='<%# Eval("ThuGomConLai_2")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thành phẩm đã giao hết qua QC" HeaderStyle-BackColor="#cffeb3">
                            <ItemTemplate>
                                <div style="text-align:center">
                                    <asp:Label runat="server" ID="lblGiaoTP_QC_1" Text='<%# Eval("GiaoTP_QC_1")%>'></asp:Label>
                                    <asp:Label runat="server" style="color:black;" Text="|"></asp:Label>
                                    <asp:Label runat="server" ID="lblGiaoTP_QC_2" Text='<%# Eval("GiaoTP_QC_2")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Không còn phế phẩm của sản phẩm A" HeaderStyle-BackColor="#cffeb3">
                            <ItemTemplate>
                                <div style="text-align:center">
                                    <asp:Label runat="server" ID="lblKTPhePham_1" Text='<%# Eval("KTPhePham_1")%>'></asp:Label>
                                    <asp:Label runat="server" style="color:black;" Text="|"></asp:Label>
                                    <asp:Label runat="server" ID="lblKTPhePham_2" Text='<%# Eval("KTPhePham_2")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACB Xác nhận" ItemStyle-Width="115px" HeaderStyle-BackColor="#cffeb3">
                            <ItemTemplate>
                                <asp:Label runat="server" style="border:1px solid black;float:left; width:50px;height:20px;" ID="lblACB_XacNhan_SX_1" Text='<%# Eval("ACB_XacNhan_SX_1")%>' ></asp:Label>
                                <asp:Label runat="server" style="border:1px solid black;float:right; width:50px;height:20px;" ID="lblACB_XacNhan_QC_1" Text='<%# Eval("ACB_XacNhan_QC_1")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GHI CHÚ" HeaderStyle-BackColor="#cffeb3">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDapCable_GhiChu" Text='<%# Eval("DapCable_GhiChu")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Không còn sản phẩm A ở công đoạn CDC hoặc đặc tính" HeaderStyle-BackColor="#ffcda9" >
                            <ItemTemplate>
                                <div style="text-align:center">
                                    <asp:Label runat="server" ID="lblKTCDC_A_1" Text='<%# Eval("KTCDC_A_1")%>'></asp:Label>
                                    <asp:Label runat="server" style="color:black;" Text="|"></asp:Label>
                                    <asp:Label runat="server" ID="lblKTCDC_A_2" Text='<%# Eval("KTCDC_A_2")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Không còn sản phẩm A ở công đoạn kiểm tra đặc tính" HeaderStyle-BackColor="#ffcda9">
                            <ItemTemplate>
                                <div style="text-align:center">
                                    <asp:Label runat="server" ID="lblKTCD_DTA_1" Text='<%# Eval("KTCD_DTA_1")%>'></asp:Label>
                                    <asp:Label runat="server" style="color:black;" Text="|"></asp:Label>
                                    <asp:Label runat="server" ID="lblKTCD_DTA_2" Text='<%# Eval("KTCD_DTA_2")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Không còn sản phẩm A ở công đoạn kiểm tra ngoại dạng" HeaderStyle-BackColor="#ffcda9">
                            <ItemTemplate>
                                <div style="text-align:center">
                                    <asp:Label runat="server" ID="lblKTND_A1" Text='<%# Eval("KTND_A1")%>'></asp:Label>
                                    <asp:Label runat="server" style="color:black;" Text="|"></asp:Label>
                                    <asp:Label runat="server" ID="lblKTND_A2" Text='<%# Eval("KTND_A2")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACB Xác nhận" ItemStyle-Width="115px" HeaderStyle-BackColor="#ffcda9">
                            <ItemTemplate>
                                <asp:Label runat="server" style="border:1px solid black;float:left; width: 50px;height: 20px;" ID="lblACB_XacNhan_SX_2" Text='<%# Eval("ACB_XacNhan_SX_2")%>' ></asp:Label>
                                <asp:Label runat="server" style="border:1px solid black;float:right; width: 50px;height:20px;" ID="lblACB_XacNhan_QC_2" Text='<%# Eval("ACB_XacNhan_QC_2")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GHI CHÚ" HeaderStyle-BackColor="#ffcda9">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblQC_GhiChu" Text='<%# Eval("QC_GhiChu")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Khay, khuôn bẻ Taibar, trên line không còn sản phẩm A" HeaderStyle-BackColor="#baeaf3">
                            <ItemTemplate>
                                <div style="text-align:center">
                                    <asp:Label runat="server" ID="lblKTTaibar_A_1" Text='<%# Eval("KTTaibar_A_1")%>'></asp:Label>
                                    <asp:Label runat="server" style="color:black;" Text="|"></asp:Label>
                                    <asp:Label runat="server" ID="lblKTTaibar_A_2" Text='<%# Eval("KTTaibar_A_2")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tất cả sản phẩm A đã được đóng gói và đóng thùng" HeaderStyle-BackColor="#baeaf3">
                            <ItemTemplate>
                                  <div style="text-align:center">
                                    <asp:Label runat="server" ID="lblKTDongGoi_A_1" Text='<%# Eval("KTDongGoi_A_1")%>'></asp:Label>
                                    <asp:Label runat="server" style="color:black;" Text="|"></asp:Label>
                                    <asp:Label runat="server" ID="lblKTDongGoi_A_2" Text='<%# Eval("KTDongGoi_A_2")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACB Xác nhận" ItemStyle-Width="115px" HeaderStyle-BackColor="#baeaf3">
                            <ItemTemplate>
                                <asp:Label runat="server" style="border:1px solid black;float:left; width:50px;height:20px;" ID="lblACB_XacNhan_SX_3" Text='<%# Eval("ACB_XacNhan_SX_3")%>' ></asp:Label>
                                <asp:Label runat="server" style="border:1px solid black;float:right; width:50px;height:20px;" ID="lblACB_XacNhan_QC_3" Text='<%# Eval("ACB_XacNhan_QC_3")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GHI CHÚ" HeaderStyle-BackColor="#baeaf3">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDongGoi_GhiChu" Text='<%# Eval("DongGoi_GhiChu")%>' ></asp:Label>
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
            <br />
            <br />
        <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
        </div>

        <div runat="server" id="btnAdmin" visible="false">
                 <table id="Table1" runat="server" enableviewstate="true" style="border-spacing: unset; width: 100%;">
            <tr>
                <td style="border-style:none; border-spacing: unset; text-align: left; background-color:#006699; width:15%" >
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Back" ID="Button1" OnClick="btnBack_Click" />
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Home" Visible="false" ID="btnMainBack" OnClick="btnMainBack_Click" />
                </td>
                <td style="border-spacing: unset; font-family: 'times New Roman', Times, serif; background-color: #006699; font-size: 30px; text-align: center; border: none; font-weight: bold;">
                    <p style="padding: 0; margin: 0; color: #FFFFFF;">MANAGEMENT BOOKS PRODUCTION</p>
                </td>
                <td style="border-spacing: unset; border-style: none; background-color: #006699; text-align: right; width: 12%">
                    <div >
                        <asp:Label runat="server" ID="Label1" ForeColor="White" Style=" display:inline-table; margin-right:10px" Font-Bold="True"></asp:Label>
                        <a class="button_logout" id="A1" runat="server" onserverclick="btnDangXuat_Click" >
                            <div class="logout">Log Out </div>
                        </a>
                    </div>
                </td>
            </tr>
    </table>
                <div style="width:100%;text-align:center;margin-top:15px;margin-bottom:20px">
                    <label style="font-size:25px; border:1px solid black;font-weight:bold;background-color:aqua;color:red" >Phân Quyền Sản Xuất, QC</label>
                </div>
                <div style="width:100%;">
                <div style="width:600px;border: 2px solid black;margin-top:10px;margin:auto;background-color:blanchedalmond">
                    <div style="width:100%;border-bottom:2px dashed black;">
                        <div style="width:95%; margin-left:10px;margin-top:10px;">
                            <label>Bộ Phận:</label>
                        </div>
                        <div style="width:580px;display:flex; margin-left:10px;margin-top:10px; margin-bottom:10px">
                            <asp:Dropdownlist runat="server" style="width:50%;margin-right:15px" ID="ddlBoPhan">
                                <asp:ListItem>*********************************</asp:ListItem>
                                <asp:ListItem>SX</asp:ListItem>
                                <asp:ListItem>QC</asp:ListItem>
                                </asp:Dropdownlist>
                        </div>
                    </div>
                    <div style="width:100%;border-bottom:2px dashed black">
                         <div style="width:200px; margin-left:10px;margin-top:10px">
                            <label>Mã Nhân Viên:</label>
                        </div>
                        <div style="width:580px; display:flex; margin-left:10px;margin-top:10px;margin-bottom:10px">
                        <asp:TextBox ID="txtMaNhanVien" style="width:50%;margin-right:15px" runat="server" AutoPostBack="true" OnTextChanged="txtMaNhanVien_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtTenNhanVien" style="width:50%" runat="server" AutoPostBack="true"></asp:TextBox>
                        <asp:Label ID="lblID" runat="server" style="display:none"></asp:Label>
                        </div>
                    </div>
                    <div style="width:600px;text-align:center; margin-left:10px;margin-top:10px; margin-bottom:10px">
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:aliceblue;background-color:forestgreen; border-radius:5px;cursor:pointer" ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click"></asp:Button>
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:black;background-color:yellow; border-radius:5px;cursor:pointer" ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click"></asp:Button>
                        <asp:Button type="submit" style="width:80px;height:35px;font-weight:bold;color:white;background-color:red; border-radius:5px;cursor:pointer" ID="btnDelete" runat="server" Text="Xóa" Visible="false" OnClick="btnDelete_Click"></asp:Button>
                    </div>
                </div>
                </div>
                <br />
                <div style="width:100%;text-align:center">
                    <asp:Gridview style="width:100%" runat="server" ID="GridView1" AutoGenerateColumns="false" AutoPostBack="true" DataKeyNames="ID" Pagesize="10" HeaderStyle-BackColor="Orange" >
                        <Columns>
                            <asp:TemplateField HeaderText="No." HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
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
                            <asp:TemplateField HeaderText="Bộ Phận">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("BoPhan")%>'></asp:Label>
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
                <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
            </div>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtACB_XacNhan_SX_1" />
            <asp:AsyncPostBackTrigger ControlID="txtACB_XacNhan_QC_1" />
            <asp:AsyncPostBackTrigger ControlID="txtACB_XacNhan_SX_2" />
            <asp:AsyncPostBackTrigger ControlID="txtACB_XacNhan_QC_2" />
            <asp:AsyncPostBackTrigger ControlID="txtACB_XacNhan_SX_3" />
            <asp:AsyncPostBackTrigger ControlID="txtACB_XacNhan_QC_3" />
        </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
