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
      
    </style>
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

        
             <table style="width: 100%; min-width: 1000px; border: 1px solid #143c54; background: #d1f0ff; border-spacing: unset">
                        <tr>
                            <td style="width: 20%; font-weight: bold; font-size: 36px; border: 1px solid #143c54; text-align: center" class="center" rowspan="3"><span>NEM</span></td>
                            <td style="width: 50%; font-weight: bold; font-size: 28PX; border: 1px solid #143c54; text-align: center" class="center" rowspan="3"><span>BẢNG THAO TÁC SẢN PHẨM KASHIME<br />
                               カシメ製品の作業表</span></td>
                            <td style="width: 10%; font-weight: bold; text-align: left; border: 1px solid #143c54;"><span>KMH:</span></td>
                            <td style="width: 20%; text-align: left; border: 1px solid #143c54;"><span>KMH:NEV-03-M-(WA)-F014 (1)</span></td>
                        </tr>
                        <tr>
                            <td style="width: 10%; font-weight: bold; text-align: left; border: 1px solid #143c54;"><span>NGAY日:</span></td>
                            <td style="width: 20%; text-align: left; border: 1px solid #143c54;"><span>2017.10.05</span></td>
                        </tr>
                        <tr>
                            <td style="width: 10%; font-weight: bold; text-align: left; border: 1px solid #143c54;"><span>Trangページ:</span></td>
                            <td style="width: 20%; text-align: left; border: 1px solid #143c54;"><span>1/1</span></td>
                        </tr>
                    </table>

                <table class ="tblForm" style="margin-top:20px">            
                <tr style="text-align: center ">
                    <td class="font">LINE ライン: </td>
                    <td class="font" >CABLE ケーブル</td>
                    <td class="font">SLEEVE スリーブ</td>
                </tr>
                <tr>
                    <td class="font1">Bản vẽ 図面: </td>
                    <td ></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="font1">Mã sp 品目: </td>
                    <td ></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="font1">Tên sp 品名: </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="font1">Ngày thao tác 作業日: </td>
                    <td ></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="font1">Đảm nhiệm 担当:</td>
                    <td ></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="font1">Hơi máy dập 圧力( 0.4 ~  0.5 ): </td>
                    <td ></td>
                    <td></td>
                </tr>
            </table>

            <table class="tblForm" style="margin-top: 20px">
                <tr class="font">
                    <td class="font" colspan="1" rowspan="3"  width="120px"; >Lot No。<br /> ロットNo.</td>
                    <td rowspan="3"  width="50px"; >Số lượng <br />数量</td>
                     <td colspan="6">Người thao tác 作業者</td>
                    <td rowspan="3"  width="110px";>Leader <br />đóng gói <br /> 梱包リーダー</td>
                    <td colspan="8" rowspan="1">Công đoạn<br />工程</td>
                </tr>
               
                <tr class="font">
                    <td colspan="1" rowspan="2"  width="100px"; >Set cable Dập máy <br />ケーブルセット カシメ </td>
                    <td rowspan="2"  width="100px";>Dập sleeve <br />スリーブカシメ</td>
                     <td rowspan="2"  width="75px"; >Số lượng đóng gói <br />梱包数量</td>
                    <td rowspan="2"  width="80px";>Số lượng bù <br />補充数量</td>
                    <td rowspan="2" width="95px";>MSNV đóng gói <br />梱包者の社員</td>
                     <td rowspan="2" width="100px";>MSNV người đóng thùng <br />箱梱包者の社員</td>
                    <td rowspan="1"  width="100px";>Cable<br />ケーブル"</td>
                    <td width="100px";>Sleeve<br />スリーブ"</td>
                    <td width="100px";>Nhúng chì <br />予備半田</td>
                    <td colspan="5">Giao QC <br /> 品管移転</td>
                </tr>
                <tr>
                    <td  colspan="1" rowspan="3"></td>
                    <td></td>
                     <td></td>
                    <td  class="font" colspan="1" rowspan="3" width="100px";>6-9h</td>
                    <td class="font"  width="100px"; >10-12h</td>
                     <td class="font" width="100px";>13-15h</td>
                    <td class="font" width="100px";>16-18h</td>
                    <td class="font" width="100px"; >OK Đơn<br />ロット</td>
                </tr>
                </table>



        <footer class="auto-style3"><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
        </div>
    </form>
</body>
</html>
