<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Management_Books.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Books Home</title>
    <link rel="shortcut icon" type="image/x-icon" href="../Nissei.ico" />
    <link rel="stylesheet" href="Css/style.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
    <style type="text/css">
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
    .button_home1 {
        width: 170px;
        height: 50px;
        background-color: #3b8b6c;
        border: none;
        color: white;
        padding: 8px;
        font-size: 16px;
        left: 10px;
        margin: 2px 2px;
        cursor: pointer;
        border-radius: 4px;
        border: 1px solid black;
    }

        .button_home1:hover {
            color: black;
            background-color: #79e7b8;
        }
    .button_home2 {
        width: 170px;
        height: 50px;
        background-color: #f2561d;
        border: none;
        color: white;
        padding: 8px;
        font-size: 16px;
        left: 10px;
        margin: 2px 2px;
        cursor: pointer;
        border-radius: 4px;
        border: 1px solid black;
    }

        .button_home2:hover {
            color: black;
            background-color: #82c7ff;
        }
         .button_home3 {
        width: 170px;
        height: 50px;
        background-color: #b54a61;
        border: none;
        color: white;
        padding: 8px;
        font-size: 16px;
        left: 10px;
        margin: 2px 2px;
        cursor: pointer;
        border-radius: 4px;
        border: 1px solid black;
    }

        .button_home3:hover {
            color: black;
            background-color: #82c7ff;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <table id="Table3" runat="server" enableviewstate="true" style="border-spacing: unset; width: 100%;">
            <tr>
                <td style="border-style:none; border-spacing: unset; text-align: left; background-color:#006699; width:15%" >
                     <asp:Button CssClass="button2" runat="server" Style="margin-left: 8px" Text="Admin" Visible="false" ID="btnAdmin" OnClick="btnManagement_Employees_Click"  />
                </td>
                <td style="border-spacing: unset; font-family: 'times New Roman', Times, serif; background-color: #006699; font-size: 30px; text-align: center; border: none; font-weight: bold;">
                    <p style="padding: 0; margin: 0; color: #FFFFFF;">MANAGEMENT BOOKS PRODUCTION</p>
                </td>
                <td style="border-spacing: unset; border-style: none; background-color: #006699; text-align: right; width: 12%">
                    <div >
                        <asp:Label runat="server" ID="lblTenDanhNhap" ForeColor="White" Style=" display:inline-table; margin-right:10px" Font-Bold="True"></asp:Label>
                        <a class="button_logout" id="btnDangXuat" runat="server" onserverclick="btnDangXuat_Click" >
                            <div class="logout">Log Out</div>
                        </a>
                    </div>
                </td>
            </tr>
    </table>
    <div style="width:100%;text-align:center" runat="server" id="barcode_tab" visible="false">
    <img src="Images/Barcode_Tab.png" alt="Barcode Tab" id="barcode_Tab_Image">
    </div>
    <div style="margin-top:10px">
        <asp:label runat="server" ID="lblSoKashime" Visible="false" style="margin-left:15px;font-size:25px; font-weight:bold;color:#0C599F">Kashime :</asp:label>
    </div>
    <div style="padding: 0 10px 10px 10px; text-align: center;">
        <asp:Checkbox runat="server" style="display:none" ID="CheckAdmin"></asp:Checkbox>
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ Thao Tác" OnClick="btnSoThaoTac_Click" ID="btnSoThaoTac" Visible="false"/>
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ Test Line" OnClick="btnSoTestLine_Click" ID="btnSoTestLine" Visible="false"/>
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac1" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac2" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac3" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac4" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac5" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac6" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac7" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac8" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac9" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac10" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac11" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac12" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac13" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac14" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac15" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac16" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac17" Visible="false" />
        <asp:Button CssClass="button_home1" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac18" Visible="false"/>
    </div>
    <div style="margin-top:10px;width:100%;">
        <asp:label runat="server" ID="lblSoLineCut" Visible="false" style="margin-left:15px;font-size:25px; font-weight:bold;color:#ff9999">Line Cut :</asp:label>
    </div>
    <div style ="padding: 0 10px 10px 10px; text-align: center;">
        <asp:button Cssclass="button_home2" type="submit" runat="server" Text="Sổ Cắt Cable" OnClick="btnSoCatCable_Click" ID="btnSoCatCable" Visible="false"/>
        <asp:button Cssclass="button_home2" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac19" Visible="false" />
        <asp:button Cssclass="button_home2" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac20" Visible="false" />
        <asp:button Cssclass="button_home2" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac21" Visible="false" />
        <asp:button Cssclass="button_home2" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac22" Visible="false" />
        <asp:button Cssclass="button_home2" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac23" Visible="false" />
        <asp:button Cssclass="button_home2" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac24" Visible="false" />
        <asp:button Cssclass="button_home2" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac25" Visible="false" />
        <asp:button Cssclass="button_home2" type="submit" runat="server" Text="Sổ ..." ID="btnSoThaoTac26" Visible="false" />
    </div>
    <div style="margin-top:10px;width:100%;">
        <asp:label runat="server" ID="Label1" style="margin-left:15px;font-size:25px; font-weight:bold;color:dodgerblue">Other :</asp:label>
    </div>
     <div style ="padding: 0 10px 10px 10px; text-align: center;">
        <asp:button Cssclass="button_home3" type="submit" runat="server" Text="Barcode Tab" ID="btnBarcode_Tab" OnClick="btnBarcode_Tab_Click" />
    </div>
    <br />
    <br />
    <br />
    <footer><b style="font-size: 18px">NISSEI ELECTRIC MY THO CO., LTD</b></footer>
    </form>
    <script type="text/javascript">

    window.onload = function() {
        setTimeout(function() {
            document.getElementById('barcode_Tab_Image').style.display = 'none';
        }, 5000); // 5000 milliseconds = 5 seconds
        };

    </script>
</body>
</html>
