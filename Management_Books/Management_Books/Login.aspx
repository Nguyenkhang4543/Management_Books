<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Management_Books.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Books Login</title>
    <link rel="shortcut icon" type="image/x-icon" href="Nissei.ico" />
    <link href="Css/style_Login.css" rel='stylesheet' type='text/css' />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
</head>
<body>
     <form id="form1" runat="server">
     <asp:Label ID="lblsession" runat="server"></asp:Label>
     <div>
         <div class="Content"></div>
     <div class="main-agile">

         <div class="content-wthree">
             <div class="about-middle">
                     <div class="banner-bottom-2">
                         <div class="about-midd-main">
                             <img class="agile-img" src="Images/NISSEI.png" alt=""  />
                             <h5 style="text-align: center;font-weight: bold;font-size: 20px;">Welcome To N.E.M</h5>
                         </div>
                         <div class="new-account-form">
                             <h2 class="heading-w3-agile" style="color: #FF0000; font-size: xx-large">MANAGEMENT BOOKS</h2>
                             <p style="font-size:15px; text-align: center;">&nbsp;</p>
                             <div class="inputs">
                                 <b>ID</b>
                                 <i class="fas fa-user" aria-hidden="true" style="font-size: 18px;">:</i>
                                 <asp:TextBox ID="txtUserName" class="email" type="text" runat="server" placeholder="Tài khoản đăng nhập (MSNV)" required=""></asp:TextBox>
                             </div>
                             <div class="inputs">
                                 <b>Password</b>
                                 <i class="fa fa-unlock-alt" aria-hidden="true" style="font-size: 18px;">:</i>
                                 <asp:TextBox ID="txtPassword" type="password" class="password" runat="server" placeholder="Nhập mật khẩu" required=""></asp:TextBox>
                             </div>
                             <asp:Button ID="btnLogin" type="submit" runat="server" Text="Login" OnClick="btnLogin_Click" />
                              <br /><br />
                         </div>
                     </div>
                 <div class="clear"></div>
             </div>
         </div>
     </div>
     </div>
 </form>
</body>
</html>
