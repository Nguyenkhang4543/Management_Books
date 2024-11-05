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
         <div style="width:100%">
            <table id="Table3" runat="server" enableviewstate="true" style="border-spacing: unset; width: 100%;">
            <tr>
                <td style="border-style:none; border-spacing: unset; text-align: left; background-color:#006699; width:15%" >
                    <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Back" ID="btnBack" OnClick="btnBack_Click"  />
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
<%-------------------------------------------------------------------------HTML-------------------------------------------------------------------------%>
            <%--        <div style="max-height: 400px; overflow: auto;">
                    <table border="1" style="text-align: center; width: 100%; border-spacing: 0;">
                        <tr >
                            <td colspan="5" ></td>
                            <td colspan="20" style=" border: none;">Người xác nhận  (*)<br />
                                          Ca 1: ACB (SX+QC) trở lên<br />
                                          Ca 3: Leader SX và QC xác nhận chéo
                            </td>
                            <td colspan="7" style=" border: none;">(O: đã hoàn thành<br />
                                                                    X: chưa hoàn thành)</td>
                        </tr>
                       
                        <tr >
                            <td rowspan="3">Line</td>
                            <td rowspan="3">Ngày sản xuất</td>
                            <td rowspan="3">Thời gian đổi sản phẩm</td>
                            <td rowspan="3">Sản phẩm đang sản xuất</td>
                            <td rowspan="3">Sản phẩm mới</td>
                            <th colspan="11">DẬP CABLE</th>
                            <td colspan="9">
                            </td>
                            <th colspan="7" >QC</th>
                        </tr>
                       
                        <tr >
                            <td colspan="2">Dập nguyên liệu còn lại về line nguyên liệu</td>
                            <td colspan="2">Gom tất cả dây quăng trong máy</td>
                            <td colspan="2">Thành phẩm đã giao hết qua QC </td>
                            <td colspan="2">Không còn phế phẩm của sản phẩm A	</td>
                            <th colspan="2">ACB Xác nhận</th>
                            <th rowspan="2">GHI CHÚ</th>

                            <td colspan="2">Không còn sản phẩm A ở công đoạn CDC hoặc đặc tính</td>
                            <td colspan="2">Không còn sản phẩm A ở̉công đoạn kiểm tra đặc tính</td>
                            <td colspan="2">Không còn sản phẩm A ở công đoạn kiểm tra ngoại dạng</td>
                            <th colspan="2">ACB Xác nhận</th>
                            <th rowspan="2">GHI CHÚ	</th>

                            <td colspan="2"> Khay, khuôn bẻ Taibar, trên line không còn sản phẩm A</td>
                            <td colspan="2">Tất cả sản phẩm A đã được đóng gói và đóng thùng</td>
                            <th colspan="2">ACB Xác nhận</th>
                            <th rowspan="2">GHI CHÚ	</th>
                        </tr>
                       
                        <tr >
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>SX</td>
                            <td>QC</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>SX</td>
                            <td>QC</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>KQ</td>
                            <td>SX</td>
                            <td>QC</td>
                        </tr>
                       
                    </table>
                </div>--%>
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
     
                <asp:TableCell><asp:TextBox ID="txtLine" style="width: 50px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtNgaySanXuat" style="width: 50px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtThoiGianDoiSanPham" style="width: 50px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtBoxSanPhamDangSanXuat" style="width: 80px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="textBoxSanPhamMoi" style="width: 80px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
     
                <asp:TableCell><asp:TextBox ID="txtKQ1" style="width: 25px; height:25px" runat="server" ></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ2" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ3" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ4" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ5" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ6" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ7" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ8" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSX1" style="width: 40px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtQC1" style="width: 40px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtGhiChu1" style="width: 70px; height:25px" runat="server"></asp:TextBox></asp:TableCell>

                <asp:TableCell><asp:TextBox ID="txtKQ9" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ10" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ11" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ12" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ13" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ14" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSX2" style="width: 40px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtQC2" style="width: 40px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtGhiChu2" style="width: 70px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
       
                <asp:TableCell><asp:TextBox ID="txtKQ15" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ16" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ17" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtKQ18" style="width: 25px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSX3" style="width: 40px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtQC3" style="width: 40px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtGhiChu3" style="width: 70px; height:25px" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            </asp:Table>

            </div>
            <div style="width:100%;text-align:center; margin-top:10px">
                 <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Save" />
            </div>
            <div style="width:100%;text-align:center">
            <asp:Label Font-Size="20px"  runat="server">From Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtFromDate"></asp:TextBox>
            <asp:Label Font-Size="20px" runat="server">To Date: </asp:Label>
            <asp:TextBox runat="server" style="height: 25px" type="Date" ID="txtToDate"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtLotNL_Search" style="height: 25px"></asp:TextBox>
            <asp:Button Cssclass="button2" runat="server" Text="Search"/>
        </div>
            <div>
                <asp:GridView runat ="server" ID="GridView" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Line">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("So_Line")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày Sản Xuất">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("Ngay_SX")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thời Gian Đổi Sản Phẩm">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ThoiGianDoi_SP")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sản Phẩm Đang Sản Xuất">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("SP_DangThaoTac")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sản Phẩm Mới">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("SP_TienHanhDoi")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dập nguyên liệu còn lại về line nguyên liệu">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("KTConLai_1")%>'></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("KTConLai_2")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gom tất cả dây quăng trong máy">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ThuGomConLai_1")%>'></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("ThuGomConLai_2")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thành phẩm đã giao hết qua QC">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("GiaoTP_QC_1")%>' ></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("GiaoTP_QC_2")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Không còn phế phẩm của sản phẩm A">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("KTPhePham_1")%>' ></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("KTPhePham_2")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACB Xác nhận">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ACB_XacNhan_SX_1")%>' ></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("ACB_XacNhan_QC_1")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GHI CHÚ">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("DapCable_GhiChu")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Không còn sản phẩm A ở công đoạn CDC hoặc đặc tính">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("KTCDC_A_1")%>' ></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("KTCDC_A_2")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Không còn sản phẩm A ở công đoạn kiểm tra đặc tính">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("KTCD_DTA_1")%>' ></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("KTCD_DTA_2")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Không còn sản phẩm A ở công đoạn kiểm tra ngoại dạng">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("KTND_A1")%>' ></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("KTND_A2")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACB Xác nhận">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ACB_XacNhan_SX_2")%>' ></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("ACB_XacNhan_QC_2")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GHI CHÚ">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("QC_GhiChu")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Khay, khuôn bẻ Taibar, trên line không còn sản phẩm A">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("KTTaibar_A_1")%>' ></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("KTTaibar_A_2")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tất cả sản phẩm A đã được đóng gói và đóng thùng">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("KTDongGoi_A_1")%>' ></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("KTDongGoi_A_2")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACB Xác nhận">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ACB_XacNhan_SX_3")%>' ></asp:Label>
                                <asp:Label runat="server" Text='<%# Eval("ACB_XacNhan_QC_3")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GHI CHÚ">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("DongGoi_GhiChu")%>' ></asp:Label>
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
