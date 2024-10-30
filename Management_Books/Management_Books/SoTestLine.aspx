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
              <div style="max-height: 400px; overflow: auto;">
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
                </div>
        <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
        </div>
    </form>
</body>
</html>
