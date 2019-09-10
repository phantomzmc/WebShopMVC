<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Purchase.Account.LoginForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
    <title>Purchase</title>
    <link rel="stylesheet" href="~/Styles/_Login.css" type="text/css">
</head>
<body>
    <form id="form1" runat="server" >
    <div Align="center" style="background:#6189df; box-shadow: 0px 5px 5px #6E6E6E;" >
    <h1>ISUZU CHIANGMAI SALES</h1>
    </div>
    <center>
    <div style="padding-top:10px;">
    <div class="Login">
    <br />
        <div class="Login_Form">
        <br />
        <h1>Login Purchase</h1>
            <asp:TextBox ID="Txt_Username" runat="server" placeholder="USERNAME" CssClass="Login_un" ></asp:TextBox>
        <br /><br />
            <asp:TextBox ID="Txt_Password" runat="server" placeholder="PASSWORD" CssClass="Login_ps" TextMode="Password"></asp:TextBox>
        <br /><br />
            <asp:Button ID="Btn_Login" runat="server" Text="LOGIN!" CssClass="Login_btn" 
                onclick="Btn_Login_Click" />
        <br />
            <asp:Label ID="Lb_Err" runat="server" Text="Check your 'USERNAME' or 'PASSWORD'" CssClass="Login_lbl"></asp:Label>
        </div>
    </div>
    </div>
    </center>
    </div>
    </form>
</body>
</html>
