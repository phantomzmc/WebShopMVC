<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="_PurchaseForm.aspx.cs" Inherits="Purchase._Form._PurchaseForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
        .ajax__combobox_itemlist
        {
            position:fixed !important;
        }
        .style3
       {
           border-left-style:dashed; border-right-style:dashed; border-right-color:Black; border-width: 1px; border-bottom-style:dashed; border-bottom-color:#CCCCCC;     
       }
        .style4
       {
           border-left-style:dashed; border-right-style:dashed; border-right-color:White; border-left-color:White; border-width: 1px;
       }
        .style5
        {
            height: 28px;
        }
        .style6
        {
            height: 29px;
        }
        .style7
        {
            font-size: medium;
        }
        .style9
        {
            font-size: medium;
        }
        </style>
    <script LANGUAGE="JavaScript">
        document.onkeydown = chkEvent
        var formInUse = false;
        function chkEvent(e) {
            var keycode;
            if (window.event) keycode = window.event.keyCode; //*** for IE ***//
            else if (e) keycode = e.which; //*** for Firefox ***//
            if (keycode == 8 && formInUse == false) {
                return false;
            } else if (keycode == 13) {
                return false;
            }
        }
        function enforcechar(what, limit, evt) { //fuction จำกัดจำนวนคำใน TEXTBOX  และกรอกได้เฉพาะตัวเลข

            var charCode = (evt.which) ? evt.which : event.keyCode

            if (charCode == 8)
                return true;

            if (what.value.length >= limit)
                return false

            if (charCode == 46)
                return true;

            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function Comma(Num) { //เพิ่มคอมม่าอัตโนมัติ
            Num += '';
            Num = Num.replace(/,/g, '');

            x = Num.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1))
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            return x1 + x2;
        }

        function isNumberKey(evt) { //function กรอกได้เฉพาะตัวเลข
            var charCode = (evt.which) ? evt.which : event.keyCode

            if (charCode == 46)
                return true;

            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
 
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="padding-left:50px; padding-bottom:10px;">
            <asp:Label ID="Label1" runat="server" Text="ใบสั่งซื้อ" ForeColor="Black" Font-Bold="true" Font-Underline="true" ></asp:Label>
        </div>
        <asp:Panel ID="Panel_SMCNumber" runat="server" style="margin-bottom:10px; border-bottom-style: dotted; border-bottom-width: 3px; border-bottom-color: #CCCCCC;">
                <table>
                <tr>
                    <td style="padding-top:5px; ">
                        <asp:Panel ID="Panel_SMCNumber_Err" runat="server" Visible="false" style=" padding-bottom:5px;">
                            <center>
                                <table width="100%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_SMcNumber_Err" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                        <table cellpadding="0" cellspacing="2">
                        <tr>   
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label2" runat="server" style="font-size: medium" Font-Bold="true"
                                    Text="หมายเลขเครื่อง :"></asp:Label>
                                <asp:Label ID="Label17" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td width="180px">
                                <asp:TextBox ID="Txt_SMCNumber" runat="server" CssClass="textbox" Font-Bold="true" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="100px"></asp:TextBox>
                                &nbsp;<asp:Button ID="Btn_SMCNumber" runat="server" CssClass="css_button" 
                                    onclick="Btn_SMCNumber_Click" Text="ค้นหา" />
                            </td>
                        </tr>
                        </table>
                    </td>
                </tr>
                </table>
                </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" Visible="false">        
        <div style="background-color: white;  text-align: left; margin-right: 5px; margin-bottom: 10px; margin-left: 5px; padding:5px;" 
        class="modalPopup_inset">
        <div style="width:100%; padding-bottom:10px;" Align="left">
        <table cellpadding="0" cellspacing="3">
        <tr>
            <td style="padding-left:50px;" width="100px"  valign="top">
                <asp:Image ID="Image10" runat="server" ImageUrl="~/Image/LOGO ISUZU1.png" 
                    Width="50px" />
            </td>
            <td valign="middle">
                <asp:RadioButtonList ID="Rb_Company" runat="server" style="font-size: large;" 
                    Font-Bold="true" Enabled="False">
                </asp:RadioButtonList>
            </td>
        </tr>
        </table>   
        </div>
        <div style="width:100%; background:#6189df; " Align="left">
        <table cellpadding="0" cellspacing="0" >
        <tr>
            <td style="padding-left:10px; padding-right:5px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/LOGO ISUZU1.png" Width="20px" />
            </td>
            <td style="padding-left:5px; padding-top:10px;">
                <asp:LinkButton ID="LinkBtn_CusData" runat="server" Text="ข้อมูลลูกค้า" style="padding-left:5px; padding-right:5px;"
                    BackColor="White" ForeColor="#6189df" Font-Bold="true" Font-Size="Large" Height="30px" 
                    Font-Underline="false" onclick="LinkBtn_CusData_Click"></asp:LinkButton>
            </td>
            <td style="padding-left:5px; padding-top:10px;">
                    <asp:LinkButton ID="LinkBtn_CarData" runat="server" Text="ข้อมูลรถ" 
                    ForeColor="White" style="padding-left:5px; padding-right:5px;" 
                    Font-Bold="true" Font-Size="Large" Font-Underline="false" Height="30px"
                    onclick="LinkBtn_CarData_Click"></asp:LinkButton>
            </td>
            <td style="padding-left:5px; padding-top:10px;">
                    <asp:LinkButton ID="LinkBtn_Accessories" runat="server" Text="อุปกรณ์ตกแต่ง" 
                    ForeColor="White" style="padding-left:5px; padding-right:5px;" 
                    Font-Bold="true" Font-Size="Large" Font-Underline="false" Height="30px"
                    onclick="LinkBtn_Accessories_Click"></asp:LinkButton>
            </td>
            <td style="padding-left:5px; padding-top:10px;">
                <asp:LinkButton ID="LinkButton_Finance" runat="server" Text="ไฟแนนซ์/รายการชำระเงิน" 
                    ForeColor="White" style="padding-left:5px; padding-right:5px;" 
                    Font-Bold="true" Font-Size="Large" Font-Underline="false" Height="30px"
                    onclick="LinkButton_Finance_Click"></asp:LinkButton>
            </td>
        </tr>
        </table>         
        </div>
        <div style="width:100%; padding-top:10px; padding-bottom:10px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;">
        <div style="padding-left:50px;">
            <asp:Label ID="Label4" runat="server" Text="* ข้อมูลที่จำเป็นต้องกรอก" ForeColor="Red" Font-Size="Small"></asp:Label><br />
            <asp:Label ID="Label19" runat="server" Text="* รูปแบบการกรอกวันที่ 01/01/2559 หรือ 01 ม.ค. 59" ForeColor="#999999" Font-Size="Small"></asp:Label>
        </div>
        </div>
        <table width="100%"> 
        <tr>
            <td style="padding-top:10px;">
                                
                <asp:Panel ID="Panel_CustomerData" runat="server" >
                <table cellpadding="0" cellspacing="2">
                <tr>
                    <td style="padding-left:50px; " width="140px" >
                        <asp:Label ID="Label343" runat="server" style="font-size: medium" 
                            Text="วันที่ออกรถ :"></asp:Label>
                        <asp:Label ID="Label453" runat="server" ForeColor="Red" 
                            style="font-size: small" Text="*"></asp:Label>
                    </td>
                    <td colspan="3" >
                        <asp:TextBox ID="Txt_Date" runat="server" CssClass="textbox" Disabled 
                            ForeColor="Blue"  Width="100px" 
                            ToolTip="*รูปแบบการกรอก 01/01/2559 หรือ 01 ม.ค. 59" 
                            ontextchanged="Txt_Date_TextChanged"></asp:TextBox>
                            <asp:ImageButton ID="Img_Date" runat="server" ImageAlign="Bottom" width="20px" ImageUrl="~/Image/Calendar.png" />
                            <asp:CalendarExtender ID="CalendarExtender_Date" runat="server" PopupButtonID="Img_Date"
                            TargetControlID="Txt_Date" Format="dd MMM yy">
                            </asp:CalendarExtender>
                        <asp:Label ID="Txt_EmpID" runat="server" style="display:none"></asp:Label>
                        <asp:Label ID="Txt_CusID" runat="server" style="display:none"></asp:Label>
                        <asp:Label ID="Txt_BookID" runat="server" style="display:none"></asp:Label>
                        <asp:Label ID="Txt_BookNo" runat="server" style="display:none"></asp:Label>
                        <asp:Label ID="Txt_ProspectNo" runat="server" style="display:none"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label428" runat="server" style="font-size: medium" 
                            Text="รหัสลูกค้า :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Txt_CusNo0" runat="server" CssClass="textbox" Disabled="" 
                            ForeColor="Blue" Width="100px" Text="ลูกค้าใหม่"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                        <td colspan="6" >
                            <div style="width:90%; padding-left:50px;">
                            <hr />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px; " width="140px" >
                            <asp:Label ID="Label423" runat="server" style="font-size: medium" 
                                Text="ประเภทลูกค้า :"></asp:Label>
                        </td>
                        <td width="180px" >
                            <asp:DropDownList ID="DD_CusType" runat="server" style="font-size: medium" 
                                ForeColor="Blue" AutoPostBack="True" 
                                onselectedindexchanged="DD_CusType_SelectedIndexChanged">
                                <asp:ListItem>บุคคล</asp:ListItem>
                                <asp:ListItem>บริษัท</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="130px" >
                            <asp:Label ID="Label436" runat="server" style="font-size: medium" Text="ที่ปรึกษาการขาย :"></asp:Label>
                            </td>
                        <td width="170px" >
                            <asp:TextBox ID="Txt_SaleName" runat="server" CssClass="textbox" Disabled="" 
                                Enabled="true" ForeColor="Blue" Width="170px"></asp:TextBox>
                            </td>
                        <td width="130px" >
                            </td>
                        <td width="150px" >
                            </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        <asp:Panel ID="Panel_Person" runat="server">
                        <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label15" runat="server" style="font-size: medium" 
                                    Text="เลขบัตรประชาชน :"></asp:Label>
                                <asp:Label ID="Label339" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td width="180px">
                                <asp:TextBox ID="Txt_IDCard" runat="server" AutoPostBack="True" 
                                    CssClass="textbox" ForeColor="Blue" 
                                    onkeypress="return enforcechar(this,13,event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ontextchanged="Txt_IDCard_TextChanged" Width="140px"></asp:TextBox>
                            </td>
                            <td width="130px">
                                &nbsp;</td>
                            <td width="170px">
                                &nbsp;</td>
                            <td width="130px">
                                &nbsp;</td>
                            <td width="150px">
                                &nbsp;</td>
                        </tr>
                            <tr>
                                <td style="padding-left:50px; " width="140px">
                                    <asp:Label ID="Label3" runat="server" style="font-size: medium" 
                                        Text="คำนำหน้า / ยศ :"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" ForeColor="Red" style="font-size: small" 
                                        Text="*"></asp:Label>
                                </td>
                                <td width="180px">
                                    <asp:TextBox ID="Txt_Prefix" runat="server" CssClass="textbox" Enabled="true"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Text="คุณ" Width="70px"></asp:TextBox>
                                </td>
                                <td width="130px">
                                    <asp:Label ID="Label6" runat="server" style="font-size: medium" Text="ชื่อ :"></asp:Label>
                                    <asp:Label ID="Label7" runat="server" ForeColor="Red" style="font-size: small" 
                                        Text="*"></asp:Label>
                                </td>
                                <td width="170px">
                                    <asp:TextBox ID="Txt_Name" runat="server" CssClass="textbox" ForeColor="Blue"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        Width="100px"></asp:TextBox>
                                </td>
                                <td width="130px">
                                    <asp:Label ID="Label8" runat="server" style="font-size: medium" 
                                        Text="นามสกุล :"></asp:Label>
                                    <asp:Label ID="Label9" runat="server" ForeColor="Red" style="font-size: small" 
                                        Text="*"></asp:Label>
                                </td>
                                <td width="150px">
                                    <asp:TextBox ID="Txt_Surname" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;" 
                                        ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; " >
                                    <asp:Label ID="Label10" runat="server" Text="ชื่อเล่น :" style="font-size: medium"></asp:Label> 
                                </td>
                                <td >
                                    <asp:TextBox ID="Txt_Nickname" runat="server" CssClass="textbox" Width="100px" ForeColor="Blue"  onfocus="formInUse = true;" onblur="formInUse = false;"></asp:TextBox>
                                </td>
                                <td >
                                    <asp:Label ID="Label11" runat="server" Text="วันเกิด :" style="font-size: medium"></asp:Label> 
                                    <asp:Label ID="Label12" runat="server" Text="*" style="font-size: small" ForeColor="Red"></asp:Label> 
                                </td>
                                <td >
                                    <asp:TextBox ID="Txt_Birthday" runat="server" CssClass="textbox" Width="100px" ForeColor="Blue"
                                AutoPostBack="True" ontextchanged="Txt_Birthday_TextChanged" onfocus="formInUse = true;" onblur="formInUse = false;"
                                ToolTip="*รูปแบบการกรอก 01/01/2559 หรือ 01 ม.ค. 59" ></asp:TextBox>
                            <asp:ImageButton ID="Img_Birthday" runat="server" ImageAlign="Bottom" width="20px" ImageUrl="~/Image/Calendar.png" />
                            <asp:CalendarExtender ID="CalendarExtender_Birthday" runat="server" PopupButtonID="Img_Birthday"
                            TargetControlID="Txt_Birthday" Format="dd MMM yy">
                            </asp:CalendarExtender>
                                </td>
                                <td >
                                    <asp:Label ID="Label14" runat="server" style="font-size: medium" Text="เพศ :"></asp:Label>
                                </td>
                                <td >
                                    <asp:DropDownList ID="DD_Person_Sex" runat="server" CssClass="textbox" Width="100px" ForeColor="Blue">
                                <asp:ListItem Value="ไม่ระบุ">ไม่ระบุ</asp:ListItem>
                                <asp:ListItem Value="ชาย">ชาย</asp:ListItem>
                                <asp:ListItem Value="หญิง">หญิง</asp:ListItem>
                            </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; ">
                                    <asp:Label ID="Label443" runat="server" style="font-size: medium" Text="วุฒิ :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DD_Education" runat="server" CssClass="textbox" 
                                        ForeColor="Blue" Width="140px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label444" runat="server" style="font-size: medium" 
                                        Text="จำนวนสมาชิก :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_Total_Member" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel_Company" runat="server">
                        <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label424" runat="server" style="font-size: medium" 
                                    Text="เลขนิติบุคคล :"></asp:Label>
                                <asp:Label ID="Label425" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_CorporationCode" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" onkeypress="return enforcechar(this,13,event)" 
                                    Width="140px" AutoPostBack="True" 
                                    ontextchanged="Txt_CorporationCode_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; ">
                                <asp:Label ID="Label426" runat="server" style="font-size: medium" 
                                    Text="ชื่อบริษัท :"></asp:Label>
                                <asp:Label ID="Label427" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_CompanyName" runat="server" CssClass="textbox" ForeColor="Blue"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="6">
                        <div style="width:90%; padding-left:50px;">
                            <hr />
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td  colspan="6" style="padding-left:50px;">
                            <asp:Label ID="Label21" runat="server" Font-Size="Small" ForeColor="#999999" 
                                Text="* กรุณากรอกเบอร์ มือถือ/บ้าน อย่างน้อย 1 เบอร์"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px; height:30px;">
                            <asp:Label ID="Label16" runat="server" style="font-size: medium" 
                                Text="เบอร์มือถือ 1 :"></asp:Label>
                        </td>
                        <td width="150px" colspan="2" style="width: 280px">
                            <asp:TextBox ID="Txt_TelMobile1" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;" 
                                ForeColor="Blue" onkeypress="return enforcechar(this,10,event)" Width="100px"></asp:TextBox>
                        </td>
                        <td width="150px">
                            <asp:Label ID="Label25" runat="server" style="font-size: medium" 
                                Text="เบอร์มือถือ 2 :"></asp:Label>
                        </td>
                        <td width="130px" colspan="2" style="width: 280px">
                            <asp:TextBox ID="Txt_TelMobile2" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                ForeColor="Blue" onkeypress="return enforcechar(this,10,event)" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px; height:30px;" >
                            <asp:Label ID="Label18" runat="server" style="font-size: medium" 
                                Text="เบอร์บ้าน/ที่ทำงาน :"></asp:Label>
                        </td>
                        <td width="150px" colspan="2" style="width: 280px">
                            <asp:TextBox ID="Txt_TelHome_Work" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                ForeColor="Blue"  Width="130px"></asp:TextBox>
                        </td>
                        <td width="150px">
                            <asp:Label ID="Label26" runat="server" style="font-size: medium" 
                                Text="เบอร์แฟกซ์ :"></asp:Label>
                        </td>
                        <td width="130px" colspan="2" style="width: 280px">
                            <asp:TextBox ID="Txt_Fax" runat="server" CssClass="textbox" ForeColor="Blue"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                Width="130px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px; height:30px;" >
                            <asp:Label ID="Label76" runat="server" style="font-size: medium" 
                                Text="LINE ID :"></asp:Label>
                        </td>
                        <td width="150px" colspan="2" style="width: 280px">
                            <asp:TextBox ID="Txt_lineID" runat="server" CssClass="textbox"  
                                onfocus="formInUse = true;" onblur="formInUse = false;"
                                ForeColor="Blue"  Width="250px"></asp:TextBox>
                        </td>
                        <td width="150px">
                            &nbsp;</td>
                        <td width="130px" colspan="2" style="width: 280px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6" >
                            <div style="width:90%; padding-left:50px;">
                                <hr />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px; " valign="top">
                            <asp:Label ID="Label20" runat="server" style="font-size: medium" 
                                Text="อาชีพ :"></asp:Label>
                            <asp:Label ID="Label22" runat="server" ForeColor="Red" 
                                style="font-size: small" Text="*"></asp:Label>
                        </td>
                        <td width="150px" colspan="2" style="width: 280px" >
                            <asp:DropDownList ID="DD_Career" runat="server" CssClass="textbox" 
                                ForeColor="Blue" Width="250px" AutoPostBack="True" 
                                onselectedindexchanged="DD_Career_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Panel ID="Panel_Career_Other" runat="server" Visible="false">
                                                                <table cellpadding="0" cellspacing="3">
                                                                <tr>
                                                                    <td style="padding-top:5px;">
                                                                    <asp:TextBox ID="Txt_Career_Other" runat="server" CssClass="textbox" Height="40px"  Width="300px" placeholder="โปรดระบุ.."
                                                                    onfocus="formInUse = true;" onblur="formInUse = false;" TextMode="MultiLine" ></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                </table>
                            </asp:Panel>
                        </td>
                        <td width="150px" valign="top">
                            <asp:Label ID="Label24" runat="server" style="font-size: medium" 
                                Text="หมายเหตุอาชีพ :"></asp:Label>
                            </td>
                        <td width="130px" colspan="2" style="width: 280px" valign="top">
                            <asp:TextBox ID="Txt_Career_Remark" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                ForeColor="Blue" Width="250px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="style1" style="padding-left:50px; ">
                            <asp:Label ID="Label342" runat="server" style="font-size: medium" 
                                Text="รายได้ :"></asp:Label>
                        </td>
                        <td colspan="5">
                            <asp:DropDownList ID="DD_InCome" runat="server" CssClass="textbox" 
                                ForeColor="Blue" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td  colspan="6">
                            <div style="width:90%; padding-left:50px;">
                                <hr  />
                            </div>
                            </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px; ">
                            <asp:Label ID="Label27" runat="server" style="font-size: medium" 
                                Text="ที่อยู่ :"></asp:Label>
                            <asp:Label ID="Label28" runat="server" ForeColor="Red" style="font-size: small" 
                                Text="*"></asp:Label>
                        </td>
                        <td colspan="5">
                            <asp:Button ID="Btn_AddAddress" runat="server" CssClass="css_button" 
                                onclick="Btn_AddAddress_Click" Text="เพิ่มที่อยู่" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="padding-left:60px; padding-top:5px; padding-bottom:5px; ">

                            <asp:GridView ID="gv_Address" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" EmptyDataText="ไม่พบข้อมูลรายการ!" 
                                GridLines="None" PageSize="15" 
                                ShowHeaderWhenEmpty="True" ForeColor="#333333">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="เลขที่">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Address" runat="server" 
                                                Text='<%# Eval("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หมู่ที่">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Moo" runat="server" Text='<%# (int)Eval("Add_Moo") == 0 ? "-" :Eval("Add_Moo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หมู่บ้าน">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_HomeName" runat="server" 
                                                Text='<%# (string)Eval("Add_HomeName") == "" ? "-" : Eval("Add_HomeName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถนน">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Road" runat="server" 
                                                Text='<%# (string)Eval("Add_Road") == "" ? "-" : Eval("Add_Road") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="style4" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ซอย">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Soi" runat="server" 
                                                Text='<%# (string)Eval("Add_Soi") == "" ? "-" :Eval("Add_Soi") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตำบล">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_District" runat="server" 
                                                Text='<%# Eval("_District.DISTRICT_ID") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_DistrictName" runat="server" 
                                                Text='<%# Eval("_District.DISTRICT_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="อำเภอ">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Amphur" runat="server" Text='<%# Eval("_Amphur.AMPHUR_ID") %>' 
                                                Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_AmphurName" runat="server" 
                                                Text='<%# Eval("_Amphur.AMPHUR_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="จังหวัด">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Province" runat="server" 
                                                Text='<%# Eval("_Province.PROVINCE_ID") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_ProvinceName" runat="server" 
                                                Text='<%# Eval("_Province.PROVINCE_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รหัสไปรษณีย์">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Postel" runat="server" 
                                                Text='<%# Eval("_Postel.Postel_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="Btn_EditAddress" runat="server" onclick="Btn_EditAddress_Click" 
                                                Text="แก้ไข" Width="50px" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Img_Add_Del" runat="server" ImageUrl="~/Image/Del.png" 
                                                onclick="Img_Add_Del_Click" style="height: 16px" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" 
                                    Height="30" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                            </asp:GridView>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-left:50px; ">
                            <asp:Label ID="Label337" runat="server" style="font-size: medium" 
                                Text="ที่อยู่ส่งเอกสาร :"></asp:Label>
                            <asp:Label ID="Label338" runat="server" ForeColor="Red" 
                                style="font-size: small" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="Cb_SendAddress" runat="server" AutoPostBack="True" 
                                Checked="True" oncheckedchanged="Cb_SendAddress_CheckedChanged" 
                                style="font-size: medium" Text="ตามที่อยู่" />
                            &nbsp;
                            <asp:CheckBox ID="Cb_SendAddress_New" runat="server" AutoPostBack="True" 
                                oncheckedchanged="Cb_SendAddress_New_CheckedChanged" style="font-size: medium" 
                                Text="ที่อยู่ใหม่" />
                        </td>
                        <td>
                            <asp:Button ID="Btn_AddSendAddress" runat="server" CssClass="css_button" 
                                onclick="Btn_AddSendAddress_Click" Text="เพิ่มที่อยู่" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="6" style="padding-left:60px; padding-top:5px; padding-bottom:5px; ">
                            <asp:GridView ID="gv_SentAddress" runat="server" AutoGenerateColumns="False" 
                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                CellPadding="2" EmptyDataText="ไม่พบข้อมูลรายการ!" ForeColor="Black" 
                                GridLines="None" PageSize="15" ShowHeaderWhenEmpty="True">
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                <Columns>
                                    <asp:TemplateField HeaderText="เลขที่">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Address0" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หมู่ที่">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Moo0" runat="server" 
                                                Text='<%# (int)Eval("Add_Moo") == 0 ? "-" :Eval("Add_Moo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หมู่บ้าน">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_HomeName0" runat="server" 
                                                Text='<%# (string)Eval("Add_HomeName") == "" ? "-" : Eval("Add_HomeName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถนน">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Road0" runat="server" 
                                                Text='<%# (string)Eval("Add_Road") == "" ? "-" : Eval("Add_Road") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ซอย">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Soi0" runat="server" 
                                                Text='<%# (string)Eval("Add_Soi") == "" ? "-" :Eval("Add_Soi") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตำบล">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_District0" runat="server" 
                                                Text='<%# Eval("_District.DISTRICT_ID") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_DistrictName0" runat="server" 
                                                Text='<%# Eval("_District.DISTRICT_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="อำเภอ">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Amphur0" runat="server" 
                                                Text='<%# Eval("_Amphur.AMPHUR_ID") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_AmphurName0" runat="server" 
                                                Text='<%# Eval("_Amphur.AMPHUR_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="จังหวัด">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Province0" runat="server" 
                                                Text='<%# Eval("_Province.PROVINCE_ID") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_ProvinceName0" runat="server" 
                                                Text='<%# Eval("_Province.PROVINCE_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รหัสไปรษณีย์">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Postel0" runat="server" 
                                                Text='<%# Eval("_Postel.Postel_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Img_SentAdd_Del" runat="server" ImageUrl="~/Image/Del.png" 
                                                onclick="Img_SentAdd_Del_Click" style="height: 16px" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" Height="30" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                            </asp:GridView>
                        </td>
                    </tr>

                </table>
                <div style="width:100%; margin-top:10px; padding-top:10px; padding-top:10px; border-top-style: solid; border-top-width: 1px; border-top-color: #CCCCCC;">
                    <div style="padding-right:50px;" Align="right">
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="ถัดไป >>" 
                            Font-Underline="true" Font-Size="Larger" onclick="LinkButton1_Click"></asp:LinkButton>
                    </div>
                </div>
                </asp:Panel>
                <asp:Panel ID="Panel_SCustomerData" runat="server" >
                <table cellpadding="0" cellspacing="2">
                <tr>
                    <td style="padding-left:50px; " width="140px" >
                        <asp:Label ID="Label29" runat="server" style="font-size: medium" 
                            Text="วันที่ออกรถ :"></asp:Label>
                        <asp:Label ID="Label454" runat="server" ForeColor="Red" 
                            style="font-size: small" Text="*"></asp:Label>
                    </td>
                    <td colspan="3" >
                        <asp:TextBox ID="Txt_SDate" runat="server" CssClass="textbox" 
                            ForeColor="Blue"  Width="100px" AutoPostBack="True" 
                            ontextchanged="Txt_SDate_TextChanged" ></asp:TextBox>
                            <asp:ImageButton ID="Img_SDate" runat="server" ImageAlign="Bottom" width="20px" ImageUrl="~/Image/Calendar.png" />
                            <asp:CalendarExtender ID="CalendarExtender_SDate" runat="server" PopupButtonID="Img_SDate"
                            TargetControlID="Txt_SDate" Format="dd MMM yy">
                            </asp:CalendarExtender>
                        
                    </td>
                    <td>
                        <asp:Label ID="Label422" runat="server" style="font-size: medium" 
                            Text="รหัสลูกค้า :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Txt_CusNo" runat="server" CssClass="textbox" Disabled
                            ForeColor="Blue" Width="100px"></asp:TextBox>
                        <asp:ImageButton ID="Img_refresh" runat="server" width="20px"
                            ImageUrl="~/Image/refresh.png" onclick="Img_refresh_Click" />
                    </td>
                </tr>
                <tr>
                        <td colspan="6" >
                            <div style="width:90%; padding-left:50px;">
                            <hr />
                            </div>
                        </td>
                </tr>
                <tr>
                        <td style="padding-left:50px; " width="140px">
                            <asp:Label ID="Label429" runat="server" style="font-size: medium" 
                                Text="ประเภทลูกค้า :"></asp:Label>
                        </td>
                        <td width="180px">
                            <asp:DropDownList ID="DD_SCusType" runat="server" ForeColor="Blue" 
                                style="font-size: medium" Enabled="False">
                                <asp:ListItem>บุคคล</asp:ListItem>
                                <asp:ListItem>บริษัท</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="130px">
                            <asp:Label ID="Label435" runat="server" style="font-size: medium" 
                                Text="ที่ปรึกษาการขาย :"></asp:Label>
                        </td>
                        <td width="170px">
                            <asp:TextBox ID="Txt_SSaleName" runat="server" CssClass="textbox" Disabled="" 
                                Enabled="true" ForeColor="Blue" Width="170px"></asp:TextBox>
                        </td>
                        <td width="130px">
                            &nbsp;</td>
                        <td width="150px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        <asp:Panel ID="Panel_SPerson" runat="server">
                        <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label30" runat="server" style="font-size: medium" 
                                Text="คำนำหน้า / ยศ :"></asp:Label>
                            <asp:Label ID="Label31" runat="server" ForeColor="Red" style="font-size: small" 
                                Text="*"></asp:Label>
                            </td>
                            <td width="180px">
                                <asp:TextBox ID="Txt_SPrefix" runat="server" CssClass="textbox" Enabled="false" 
                                ForeColor="Blue" Text="คุณ" Width="70px"></asp:TextBox>
                            </td>
                            <td width="130px">
                                <asp:Label ID="Label32" runat="server" style="font-size: medium" Text="ชื่อ :"></asp:Label>
                                <asp:Label ID="Label33" runat="server" ForeColor="Red" style="font-size: small" 
                                Text="*"></asp:Label>
                            </td>
                            <td width="170px">
                                <asp:TextBox ID="Txt_SName" runat="server" CssClass="textbox" ForeColor="Blue" 
                                Width="100px" Enabled="false"></asp:TextBox>
                            </td>
                            <td width="130px">
                            <asp:Label ID="Label34" runat="server" style="font-size: medium" 
                                Text="นามสกุล :"></asp:Label>
                            <asp:Label ID="Label57" runat="server" ForeColor="Red" style="font-size: small" 
                                Text="*"></asp:Label>
                            </td>
                            <td width="150px">
                            <asp:TextBox ID="Txt_SSurname" runat="server" CssClass="textbox" 
                                ForeColor="Blue" Width="100px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                            <tr>
                                <td style="padding-left:50px; " >
                                    <asp:Label ID="Label58" runat="server" Text="ชื่อเล่น :" style="font-size: medium"></asp:Label> 
                                </td>
                                <td >
                                    <asp:TextBox ID="Txt_SNickName" runat="server" CssClass="textbox" Width="100px" 
                                        ForeColor="Blue" Enabled="false"></asp:TextBox>
                                </td>
                                <td >
                                    <asp:Label ID="Label59" runat="server" Text="วันเกิด :" style="font-size: medium"></asp:Label> 
                                    <asp:Label ID="Label60" runat="server" Text="*" style="font-size: small" ForeColor="Red"></asp:Label> 
                                </td>
                                <td >
                                    <asp:TextBox ID="Txt_SBirthDay" runat="server" CssClass="textbox" Width="100px" ForeColor="Blue" Enabled="false"
                                AutoPostBack="True" ontextchanged="Txt_SBirthDay_TextChanged" 
                                ToolTip="*รูปแบบการกรอก 01/01/2559 หรือ 01 ม.ค. 59" ></asp:TextBox>
                            <asp:ImageButton ID="Img_SBirthday" runat="server" ImageAlign="Bottom" width="20px" ImageUrl="~/Image/Calendar.png" Visible="false"/>
                            <asp:CalendarExtender ID="CalendarExtender_SBirthday" runat="server" PopupButtonID="Img_SBirthday"
                            TargetControlID="Txt_SBirthDay" Format="dd MMM yy">
                            </asp:CalendarExtender>
                                </td>
                                <td >
                                    <asp:Label ID="Label61" runat="server" style="font-size: medium" Text="เพศ :"></asp:Label>
                                </td>
                                <td >
                                    <asp:DropDownList ID="DD_SPreson_Sex" runat="server" CssClass="textbox" 
                                        Width="100px" ForeColor="Blue" Enabled="false">
                                <asp:ListItem Value="ไม่ระบุ">ไม่ระบุ</asp:ListItem>
                                <asp:ListItem Value="ชาย">ชาย</asp:ListItem>
                                <asp:ListItem Value="หญิง">หญิง</asp:ListItem>
                            </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; ">
                                    <asp:Label ID="Label62" runat="server" style="font-size: medium" 
                                Text="เลขบัตรประชาชน :"></asp:Label>
                            <asp:Label ID="Label63" runat="server" ForeColor="Red" 
                                style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_SIDCard" runat="server" CssClass="textbox" Width="140px" 
                                        ForeColor="Blue" onkeypress="return enforcechar(this,13,event)" 
                                        Enabled="false"  > </asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label64" runat="server" style="font-size: medium" 
                                Text="วุฒิ :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DD_SEducation" runat="server" CssClass="textbox" 
                                ForeColor="Blue" Width="140px" Enabled="false">
                            </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label65" runat="server" style="font-size: medium" Text="จำนวนสมาชิก :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_STotal_Member" runat="server" CssClass="textbox" 
                                ForeColor="Blue" onkeypress="return isNumberKey(event)"
                                Width="50px" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel_SCompany" runat="server">
                        <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label35" runat="server" style="font-size: medium" 
                                    Text="เลขนิติบุคคล :"></asp:Label>
                                <asp:Label ID="Label36" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_SCorporationCode" runat="server" CssClass="textbox" Disabled
                                    ForeColor="Blue" onkeypress="return enforcechar(this,13,event)" 
                                    Width="140px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; ">
                                <asp:Label ID="Label37" runat="server" style="font-size: medium" 
                                    Text="ชื่อบริษัท :"></asp:Label>
                                <asp:Label ID="Label38" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_SCompanyName" runat="server" CssClass="textbox" ForeColor="Blue" Disabled
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        </td>
                    </tr>
                <tr>
                        <td colspan="6">
                        <div style="width:90%; padding-left:50px;">
                            <hr />
                        </div>
                        </td>
                </tr>
                <tr>
                        <td style="padding-left:50px; " valign="top">
                            <asp:Label ID="Label49" runat="server" style="font-size: medium" 
                                Text="อาชีพ :"></asp:Label>
                            <asp:Label ID="Label50" runat="server" ForeColor="Red" 
                                style="font-size: small" Text="*"></asp:Label>
                        </td>
                        <td width="150px" colspan="2" style="width: 280px" >
                            <asp:DropDownList ID="DD_SCareer" runat="server" CssClass="textbox" Enabled="false"
                                ForeColor="Blue" Width="250px" 
                                onselectedindexchanged="DD_SCareer_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Panel ID="Panel_SCareer_Other" runat="server" Visible="false">
                                                                <table cellpadding="0" cellspacing="3">
                                                                <tr>
                                                                    <td style="padding-top:5px;">
                                                                    <asp:TextBox ID="Txt_SCareer_Other" runat="server" CssClass="textbox" Height="40px"  Width="300px" placeholder="โปรดระบุ.." Enabled="false"
                                                                    onfocus="formInUse = true;" onblur="formInUse = false;" TextMode="MultiLine" ></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                </table>
                                                                </asp:Panel>
                        </td>
                        <td width="150px" valign="top">
                            <asp:Label ID="Label51" runat="server" style="font-size: medium" 
                                Text="หมายเหตุอาชีพ :"></asp:Label>
                            </td>
                        <td width="130px" colspan="2" style="width: 280px" valign="top">
                            <asp:TextBox ID="Txt_SCareer_Remark" runat="server" CssClass="textbox" Enabled="false"
                                ForeColor="Blue" Width="250px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="style1" style="padding-left:50px; ">
                            <asp:Label ID="Label52" runat="server" style="font-size: medium" 
                                Text="รายได้ :"></asp:Label>
                        </td>
                        <td colspan="5">
                            <asp:DropDownList ID="DD_SInCome" runat="server" CssClass="textbox" Enabled="false"
                                ForeColor="Blue" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                <tr>
                        <td  colspan="6">
                            <div style="width:90%; padding-left:50px;">
                                <hr  />
                            </div>
                            </td>
                    </tr>
                <tr>
                        <td style="padding-left:50px; ">
                            <asp:Label ID="Label53" runat="server" style="font-size: medium" 
                                Text="ที่อยู่ :"></asp:Label>
                            <asp:Label ID="Label54" runat="server" ForeColor="Red" style="font-size: small" 
                                Text="*"></asp:Label>
                        </td>
                        <td colspan="5">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="padding-left:60px; padding-top:5px; padding-bottom:5px; ">

                            <asp:GridView ID="gv_SAddress" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" EmptyDataText="ไม่พบข้อมูลรายการ!" 
                                GridLines="None" PageSize="15" 
                                ShowHeaderWhenEmpty="True" ForeColor="#333333">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="เลขที่">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Address" runat="server" 
                                                Text='<%# Eval("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หมู่ที่">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Moo" runat="server" Text='<%# (int)Eval("Add_Moo") == 0 ? "-" :Eval("Add_Moo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หมู่บ้าน">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_HomeName" runat="server" 
                                                Text='<%# (string)Eval("Add_HomeName") == "" ? "-" : Eval("Add_HomeName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถนน">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Road" runat="server" 
                                                Text='<%# (string)Eval("Add_Road") == "" ? "-" : Eval("Add_Road") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="style4" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ซอย">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Soi" runat="server" 
                                                Text='<%# (string)Eval("Add_Soi") == "" ? "-" :Eval("Add_Soi") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตำบล">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_District" runat="server" 
                                                Text='<%# Eval("_District.DISTRICT_ID") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_DistrictName" runat="server" 
                                                Text='<%# Eval("_District.DISTRICT_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="อำเภอ">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Amphur" runat="server" Text='<%# Eval("_Amphur.AMPHUR_ID") %>' 
                                                Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_AmphurName" runat="server" 
                                                Text='<%# Eval("_Amphur.AMPHUR_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="จังหวัด">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Province" runat="server" 
                                                Text='<%# Eval("_Province.PROVINCE_ID") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_ProvinceName" runat="server" 
                                                Text='<%# Eval("_Province.PROVINCE_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รหัสไปรษณีย์">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Postel" runat="server" 
                                                Text='<%# Eval("_Postel.Postel_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" 
                                    Height="30" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px; ">
                            <asp:Label ID="Label55" runat="server" style="font-size: medium" 
                                Text="ที่อยู่ส่งเอกสาร :"></asp:Label>
                            <asp:Label ID="Label56" runat="server" ForeColor="Red" 
                                style="font-size: small" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="Cb_SSendAddress" runat="server" AutoPostBack="True" Enabled="false"
                                Checked="True" oncheckedchanged="Cb_SSendAddress_CheckedChanged" 
                                style="font-size: medium" Text="ตามที่อยู่" />
                            &nbsp;
                            <asp:CheckBox ID="Cb_SSendAddress_New" runat="server" AutoPostBack="True" Enabled="false"
                                oncheckedchanged="Cb_SSendAddress_New_CheckedChanged" style="font-size: medium" 
                                Text="ที่อยู่ใหม่" />
                        </td>
                        <td>
                            <asp:Button ID="Btn_SAddSendAddress" runat="server" CssClass="css_button" Text="เพิ่มที่อยู่" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="padding-left:60px; padding-top:5px; padding-bottom:5px; ">
                            <asp:GridView ID="gv_SSendAddress" runat="server" AutoGenerateColumns="False" 
                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                CellPadding="2" EmptyDataText="ไม่พบข้อมูลรายการ!" ForeColor="Black" 
                                GridLines="None" PageSize="15" ShowHeaderWhenEmpty="True">
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                <Columns>
                                    <asp:TemplateField HeaderText="เลขที่">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Address0" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หมู่ที่">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Moo0" runat="server" 
                                                Text='<%# (int)Eval("Add_Moo") == 0 ? "-" :Eval("Add_Moo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หมู่บ้าน">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_HomeName0" runat="server" 
                                                Text='<%# (string)Eval("Add_HomeName") == "" ? "-" : Eval("Add_HomeName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถนน">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Road0" runat="server" 
                                                Text='<%# (string)Eval("Add_Road") == "" ? "-" : Eval("Add_Road") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ซอย">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Soi0" runat="server" 
                                                Text='<%# (string)Eval("Add_Soi") == "" ? "-" :Eval("Add_Soi") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตำบล">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_District0" runat="server" 
                                                Text='<%# Eval("_District.DISTRICT_ID") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_DistrictName0" runat="server" 
                                                Text='<%# Eval("_District.DISTRICT_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="อำเภอ">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Amphur0" runat="server" 
                                                Text='<%# Eval("_Amphur.AMPHUR_ID") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_AmphurName0" runat="server" 
                                                Text='<%# Eval("_Amphur.AMPHUR_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="จังหวัด">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Province0" runat="server" 
                                                Text='<%# Eval("_Province.PROVINCE_ID") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Lb_Add_ProvinceName0" runat="server" 
                                                Text='<%# Eval("_Province.PROVINCE_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รหัสไปรษณีย์">
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Add_Postel0" runat="server" 
                                                Text='<%# Eval("_Postel.Postel_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" Height="30" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <div style="width:100%; margin-top:10px; padding-top:10px; padding-top:10px; border-top-style: solid; border-top-width: 1px; border-top-color: #CCCCCC;">
                    <div style="padding-right:50px;" Align="right">
                        <asp:LinkButton ID="LinkButton4" runat="server" Text="ถัดไป >>" 
                            Font-Underline="true" Font-Size="Larger" onclick="LinkButton4_Click" ></asp:LinkButton>
                    </div>
                </div>
                </asp:Panel>
                <asp:Panel ID="Panel_CarData" runat="server">
                <table>
                <tr>
                    <td style="padding-top:10px;">
                        <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="160px" >
                                <asp:Label ID="Label381" runat="server" style="font-size: medium" 
                                    Text="สั่งซื้อรถยนต์ :"></asp:Label>
                                <asp:Label ID="Label382" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td width="310px" >
                                <asp:TextBox ID="Txt_CarName" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" Width="100px">ISUZU</asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label397" runat="server" style="font-size: medium" 
                                    Text="ประเภทการซื้อ :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DD_BuyType" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" Width="120px">
                                    <asp:ListItem Value="Buy_First">ซื้อครั้งแรก</asp:ListItem>
                                    <asp:ListItem Value="Buy_Add">ซื้อเพิ่มเติม</asp:ListItem>
                                    <asp:ListItem Value="Buy_Compensate">ซื้อทดแทน</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                            <tr>
                                <td style="padding-left:50px; " width="160px">
                                    <asp:Label ID="Label344" runat="server" style="font-size: medium" 
                                        Text="หมายเลขเครื่อง :"></asp:Label>
                                    <asp:Label ID="Label345" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td width="210px">
                                    <asp:TextBox ID="Txt_MCNumber" runat="server" CssClass="textbox" Disabled="" 
                                        ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                                <td width="160px">
                                    <asp:Label ID="Label346" runat="server" style="font-size: medium" 
                                        Text="หมายเลขตัวถัง :"></asp:Label>
                                    <asp:Label ID="Label347" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_TruckNumber" runat="server" CssClass="textbox" Disabled="" 
                                        ForeColor="Blue" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; "  >
                                    <asp:Label ID="Label383" runat="server" style="font-size: medium" Text="รุ่น :"></asp:Label>
                                    <asp:Label ID="Label384" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td  >
                                    <asp:TextBox ID="Txt_MName" runat="server" CssClass="textbox" Disabled="" 
                                        ForeColor="Blue" Width="300px"></asp:TextBox>
                                </td>
                                <td  >
                                    <asp:Label ID="Label385" runat="server" style="font-size: medium" Text="แบบ :"></asp:Label>
                                    <asp:Label ID="Label386" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td  >
                                    <asp:Label ID="Txt_MCode" runat="server" style="display:none"></asp:Label>
                                    <asp:TextBox ID="Txt_MSaleCode" runat="server" CssClass="textbox" Disabled="" 
                                        ForeColor="Blue" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; " >
                                    <asp:Label ID="Label437" runat="server" style="font-size: medium" Text="สี :"></asp:Label>
                                    <asp:Label ID="Label438" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td >
                                        <asp:TextBox ID="Txt_CName" runat="server" CssClass="textbox" Disabled="" 
                                            ForeColor="Blue" Width="200px"></asp:TextBox>
                                </td>
                                <td >
                                    &nbsp;</td>
                                <td >
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; ">
                                    <asp:Label ID="Label387" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                                    <asp:Label ID="Label388" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Txt_CCode" runat="server" style="display:none"></asp:Label>
                                    <asp:TextBox ID="Txt_CarPrice" runat="server" CssClass="textbox" Disabled="" 
                                        ForeColor="Blue" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label354" runat="server" style="font-size: medium" 
                                        Text="หมายเลขทะเบียน :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_CarPlate" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" >
                                    <div style="width:90%; padding-left:50px;">
                                        <hr />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; ">
                                    <asp:Label ID="Label357" runat="server" style="font-size: medium" 
                                        Text="รถเก่านำมาแลก :"></asp:Label>
                                    <asp:Label ID="Label358" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:CheckBox ID="Cb_CE_Y" runat="server" AutoPostBack="True" style="font-size: medium" 
                                        Text="มี" oncheckedchanged="Cb_CE_Y_CheckedChanged" />
                                    &nbsp;
                                    <asp:CheckBox ID="Cb_CE_N" runat="server" AutoPostBack="True" style="font-size: medium" 
                                        Text="ไม่มี" oncheckedchanged="Cb_CE_N_CheckedChanged" />
                                    <asp:Label ID="Txt_StatusCE" runat="server" style="display:none"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel_CE_Y" runat="server">
                        <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="160px">
                                <asp:Label ID="Label359" runat="server" style="font-size: medium" 
                                    Text="หมายเลขเครื่อง :"></asp:Label>
                            </td>
                            <td width="210px">
                                <asp:TextBox ID="Txt_CEMCNumber" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="100px"></asp:TextBox>
                            </td>
                            <td width="160px" >
                                <asp:Label ID="Label361" runat="server" style="font-size: medium" 
                                    Text="หมายเลขตัวถัง :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_CETruckNumber" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                            <tr>
                                <td style="padding-left:50px;">
                                    <asp:Label ID="Label363" runat="server" style="font-size: medium" 
                                        Text="ยี่ห้อ :"></asp:Label>
                                    <asp:Label ID="Label364" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_CEBrand" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label365" runat="server" style="font-size: medium" Text="รุ่น :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_CEModel" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px;">
                                    <asp:Label ID="Label367" runat="server" style="font-size: medium" Text="สี :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_CEColor" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label369" runat="server" style="font-size: medium" Text="ปี :"></asp:Label>
                                    <asp:Label ID="Label370" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_CEYear" runat="server" CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px;">
                                    <asp:Label ID="Label371" runat="server" style="font-size: medium" Text="หมายเลขทะเบียน :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_CECarPlate" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label377" runat="server" style="font-size: medium" 
                                        Text="ราคารถเก่า :"></asp:Label>
                                    <asp:Label ID="Label378" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_CEPrice" runat="server" CssClass="textbox" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px;" class="style5">
                                    <asp:Label ID="Label379" runat="server" style="font-size: medium" Text="ผู้ประเมินราคา
                                         :"></asp:Label>
                                    <asp:Label ID="Label380" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td colspan="3" class="style5">
                                    <asp:TextBox ID="Txt_CEEmp" runat="server" CssClass="textbox" ForeColor="Blue" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </td>
                    <tr>
                        <td style="padding-left:50px; " class="style1">
                            
                            &nbsp;</td>
                    </tr>
                </tr>
                    <tr>
                            <td class="style1" style="padding-left:50px; ">
                                <asp:Label ID="Label473" runat="server" style="font-size: medium" Text="ประเภทตู้ :"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                                <asp:RadioButton ID="Rb_bodystandard" runat="server" AutoPostBack="True" 
                                    GroupName="Body" oncheckedchanged="Rb_bodystandard_CheckedChanged" 
                                    Text="ตู้มาตราฐาน" CssClass="style7" />
                                &nbsp;
                                <asp:RadioButton ID="Rb_bodyextra" runat="server" AutoPostBack="True" 
                                    GroupName="Body" oncheckedchanged="Rb_bodyextra_CheckedChanged" 
                                    Text="สั่งทำพิเศษ" CssClass="style9" />
                            </td>
                    </tr>
                    <tr>
                        <td class="style1" style="padding-left:50px; ">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>                                    
                                        <asp:Label ID="Label465" runat="server" style="font-size: medium" Text="Body :"></asp:Label>
                                    </td>
                                    <td> 
                                    <asp:Panel ID="Panelbodystandard" runat="server">                            
                                    <asp:DropDownList ID="DD_body" runat="server" AutoPostBack="True" 
                                        BackColor="White" CssClass="textbox" 
                                        onselectedindexchanged="DD_body_SelectedIndexChanged1" Visible="True" 
                                        Width="400px">
                                    </asp:DropDownList>
                                    </asp:Panel>

                                    <asp:Panel ID="Panelbodyextra" runat="server">
                                        <asp:DropDownList ID="ddl_Body_Company" runat="server" CssClass="textbox" 
                                                                        Width="150px">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txt_bodyextra" runat="server" CssClass="textbox" Width="240px" placeholder="รายละเอียด"></asp:TextBox>
                                                                    <asp:TextBox ID="Txt_bodyextraPrice" runat="server" AutoPostBack="True" 
                                                                        CssClass="textbox" Height="25px" 
                                                                        TextMode="Number" Width="100px" 
                                            placeholder="ราคา" ontextchanged="Txt_bodyextraPrice_TextChanged">0.00</asp:TextBox>
                                    </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" style="padding-left:50px; ">
                            <asp:Label ID="Label466" runat="server" style="font-size: medium" Text="อุปกรณ์พิเศษ :"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label467" runat="server" Font-Bold="False" Font-Overline="False" 
                                Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="จัดรวมไฟแนนซ์"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="lblsumfin" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" Width="100px"></asp:TextBox>
                            <%--<asp:Label ID="lblsumfin" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt; ">0</asp:Label>--%>
                            <asp:Label ID="Label468" runat="server" Font-Bold="False" Font-Overline="False" 
                                Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="บาท"></asp:Label>
                            &nbsp;<asp:Label ID="Label469" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="ยอดชำระเอง"></asp:Label>
                            <%--<asp:Label ID="Lb_Budgetpaybody" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt">0</asp:Label>--%>
                                <asp:TextBox ID="Lb_Budgetpaybody" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" Width="100px"></asp:TextBox>
                            &nbsp;<asp:Label ID="Label470" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="บาท"></asp:Label>
                            &nbsp;<asp:Label ID="Label471" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="รวม"></asp:Label>
                            <%--<asp:Label ID="Lb_sumAddfinance" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt">0</asp:Label>--%>
                                <asp:TextBox ID="Lb_sumAddfinance" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" Width="100px"></asp:TextBox>
                            <asp:Label ID="Label472" runat="server" Font-Bold="False" Font-Overline="False" 
                                Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="บาท"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" style="padding-left:50px; ">
                        <asp:Panel ID="Panelgvbodystandard" runat="server">
                            <asp:GridView ID="gv_bodyshow" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" 
                                onrowdatabound="gv_bodyshow_RowDataBound" ShowFooter="True" Width="80%" 
                                DataKeyNames="OptionIDrun">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ลำดับ">
                                        <ItemTemplate>
                                        <asp:Label ID="Label78" runat="server" 
                                                Text='<%# Eval("OptionIDrun") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="lbl_runbody" runat="server" 
                                                Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            <asp:Label ID="lbl_Body_Option_ID" runat="server" 
                                                Text='<%# Eval("Body_Option_ID") %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รายการ">
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddl_bodyoption" runat="server">
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Body_Option_Name" runat="server" 
                                                Text='<%# Eval("Body_Option_Name") %>'></asp:Label>
                                            <asp:Label ID="lbl_Body_Option_price" runat="server" 
                                                Text='<%# Eval("Body_Option_price") %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ไฟแนนซ์">
                                        <FooterTemplate>
                                            <asp:CheckBox ID="chk_finance" runat="server" Text="จัดรวมไฟแนนซ์" />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lbl_finance" runat="server" onclick="return false;" />
                                            <asp:Label ID="Lb_Addfinance" runat="server" Text='<%# Eval("finance") %>' 
                                                Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="จัดการ">
                                        <FooterTemplate>
                                            <asp:ImageButton runat="server" Height="25px" 
                                                ImageUrl="~/Image/add.png" onclick="Img_Addbody_Click" Width="25px" />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Img_Delbody" runat="server" ImageUrl="~/Image/Del.png" 
                                                                            onclick="Img_Delbody_Click" />
                                                                        <asp:ConfirmButtonExtender ID="Img_Delbody_ConfirmButtonExtender" 
                                                                            runat="server" ConfirmText="คุณต้องการลบข้อมูลนี้!" Enabled="True" 
                                                                            TargetControlID="Img_Delbody">
                                                                        </asp:ConfirmButtonExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#99ffcc" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5d7b9d" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="Panelgvbodyextra" runat="server">
                                                            
                                                            <asp:GridView ID="gv_bodyextra" runat="server" AutoGenerateColumns="False" 
                                                                CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" 
                                                                Width="100%" onrowdatabound="gv_bodyextra_RowDataBound" DataKeyNames="ID">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="ลำดับ">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_runbodyextra" runat="server" 
                                                                                Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                                                            <asp:Label ID="runbodyextraID" runat="server" Text='<%# Eval("ID") %>' 
                                                                                Visible="False"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="รายการ">
                                                                        <FooterTemplate>
                                                                            <asp:DropDownList ID="ddl_gvbodyextracom" runat="server" CssClass="textbox" 
                                                                                Width="100px">
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="Txt_gvbodyextraOption" runat="server"  CssClass="textbox" 
                                                                                Width="200px"></asp:TextBox>
                                                                            <asp:TextBox ID="Txt_gvbodyextraPrice" runat="server" 
                                                                                CssClass="textbox" Height="25px" placeholder="ราคา" TextMode="Number" 
                                                                                Width="80px"></asp:TextBox>
                                                                        </FooterTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Body_Company_Name" runat="server" 
                                                                                Text='<%# Eval("Body_Company_Name") %>'></asp:Label>
                                                                            <asp:Label ID="lbl_Option_Name_extra" runat="server" 
                                                                                Text='<%# Eval("Option_Name_extra") %>'></asp:Label>
                                                                                <asp:Label ID="lbl_Option_price_extra" runat="server" 
                                                                                Text='<%# Eval("Option_price_extra") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="ไฟแนนซ์">
                                                                        <FooterTemplate>
                                                                            <asp:CheckBox ID="chk_financeExtra" runat="server" Text="จัดรวมไฟแนนซ์" />
                                                                        </FooterTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="lbl_financeExtra" runat="server" onclick="return false;" />
                                                                            <asp:Label ID="Lb_Option_finance_extra" runat="server" Text='<%# Eval("Option_finance_extra") %>' 
                                                                                Visible="False"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="จัดการ">
                                                                        <FooterTemplate>
                                                                            <asp:ImageButton ID="Img_AddbodyExtra" runat="server" Height="25px" 
                                                                                ImageUrl="~/Image/add.png" onclick="Img_AddbodyExtra_Click" Width="25px" />
                                                                        </FooterTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="Img_Delbodyextra" runat="server" ImageUrl="~/Image/Del.png" 
                                                                                onclick="Img_Delbodyextra_Click"                                                                                />
                                                                            <asp:ConfirmButtonExtender ID="Img_Delbodyextra_ConfirmButtonExtender0" 
                                                                                runat="server" ConfirmText="คุณต้องการลบข้อมูลนี้!" Enabled="True" 
                                                                                TargetControlID="Img_Delbodyextra">
                                                                            </asp:ConfirmButtonExtender>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EditRowStyle BackColor="#2461BF" />
                                                                <FooterStyle BackColor="#99ffcc" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#5d7b9d" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                <RowStyle BackColor="#EFF3FB" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                            </asp:GridView>
                                                            <asp:Label ID="lbl_ErrorExtra" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                        </asp:Panel>
                            <asp:Panel ID="Panelbody" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="50%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image13" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="lblerrorbody" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" style="padding-left:50px; ">
                           
                            
                            </td>
                    </tr>
                </table>
                <div style="width:100%; margin-top:10px; padding-top:10px; padding-top:10px; border-top-style: solid; border-top-width: 1px; border-top-color: #CCCCCC;">
                    <div style="padding-right:50px;" Align="right">
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="ถัดไป >>" 
                            Font-Underline="true" Font-Size="Larger" onclick="LinkButton2_Click"></asp:LinkButton>
                    </div>
                </div>
                </asp:Panel>
                <asp:Panel ID="Panel_Accessories" runat="server">
                <table width="100%">
                <tr>
                    <td style="padding-top:10px;">
                    <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:CheckBox ID="Cb_Insurance1" runat="server" AutoPostBack="True" 
                                    style="font-size: medium" Text="ประกันประเภท 1" />
                            </td>
                            <td width="190px">
                                <asp:DropDownList ID="DD_Insurance" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" Width="180px">
                                </asp:DropDownList>
                            </td>
                            <td width="60px">                             
                                <asp:Label ID="Label389" runat="server" style="font-size: medium" Text="ทุน :"></asp:Label>
                            </td>
                            <td width="150px">
                                <asp:TextBox ID="Txt_InOutlay" runat="server" CssClass="textbox" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px"></asp:TextBox>
                            </td>
                            <td width="60px" >
                                <asp:Label ID="Label393" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
 
                            </td>
                            <td>
                                &nbsp;</td>
                            <td width="110px">
                                <asp:TextBox ID="Txt_InPrice" runat="server" CssClass="textbox" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="Cb_InFree" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="แถม" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:CheckBox ID="Cb_Regis" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="ค่าจดทะเบียน" />
                            </td>
                            <td >
                                <asp:DropDownList ID="DD_Regis" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" Width="100px">
                                    <asp:ListItem Value="Pickup">กระบะ</asp:ListItem>
                                    <asp:ListItem Value="Saloon">เก๋ง</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="60px">
                                <asp:Label ID="Label390" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Txt_RegisPrice" runat="server" CssClass="textbox" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px"></asp:TextBox>
                            </td>
                            <td colspan="4">
                                <asp:CheckBox ID="Cb_RegisFree" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="แถม" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:CheckBox ID="Cb_Act" runat="server" AutoPostBack="True" style="font-size: medium" Text="พรบ." />
                                        </td>
                                        <td align="right" style="padding-right:5px;">
                                        <asp:Label ID="Label42" runat="server" style="font-size: medium" Text="เลขที่ :"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                            <td >
                                <asp:TextBox ID="Txt_ActNo" runat="server" CssClass="textbox" ForeColor="Blue" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    Width="150px"></asp:TextBox>
                            </td>
                            <td width="60px">
                                <asp:Label ID="Label391" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td width="110px">
                                <asp:TextBox ID="Txt_ActPrice" runat="server" CssClass="textbox" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px"></asp:TextBox>
                            </td>
                            <td colspan="4">
                                <asp:CheckBox ID="Cb_ActFree" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="Cb_CE_Y_CheckedChanged" style="font-size: medium" 
                                    Text="แถม" />
                            </td>

                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:CheckBox ID="Cb_Transpot" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="ค่าขนส่ง" />
                            </td>
                            <td >
                                &nbsp;</td>
                            <td width="60px">
                                <asp:Label ID="Label392" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td width="110px">
                                <asp:TextBox ID="Txt_TranspotPrice" runat="server" CssClass="textbox" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px"></asp:TextBox>
                            </td>
                            <td colspan="4">
                                <asp:CheckBox ID="Cb_TranspotFree" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="Cb_CE_Y_CheckedChanged" style="font-size: medium" 
                                    Text="แถม" />
                            </td>

                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                        <div style="width:90%; padding-left:50px;">
                                        <hr />
                        </div>  
                        </td>
                    </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                        <td width="50%" valign="top" align="left" style="border-right-style: double; border-right-width: 2px; border-right-color: #999999; border-bottom-style: double; border-bottom-width: 2px; border-bottom-color: #999999;">
                        <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="150px" style="height:40px; padding-left:20px;" align="left">
                                <asp:CheckBox ID="Cb_SetAcc" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="ชุดอุปกรณ์ตกแต่ง" />
                            </td>
                            <td align="left" width="50px">
                                <asp:Label ID="Label394" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td align="left" width="110px">
                                
                                &nbsp;<asp:TextBox ID="Txt_SetAccPrice" runat="server" CssClass="textbox" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px"></asp:TextBox>
                            </td>
                            <td >
                                <asp:CheckBox ID="Cb_SetAccFree" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="แถม" />
                            </td>
                        </tr>
                        </table>
                        <div style="padding-top:5px;" align="center">
                            <asp:GridView ID="gv_SetAccessories" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" DataKeyNames="ID" EmptyDataText="ไม่พบข้อมูลรายการ!" 
                                ForeColor="#333333" GridLines="None" PageSize="15" ShowFooter="True">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ลำดับ">
                                        <ItemTemplate>
                                            <asp:Label ID="LBNumRow" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            <asp:Label ID="LBID" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รายการ">
                                        <FooterTemplate>
                                            <asp:TextBox ID="Txt_SetAccName" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;" 
                                                ForeColor="Blue" Width="90%"></asp:TextBox>
                                            <asp:Label ID="Label5" runat="server" ForeColor="Red" style="font-size: small" 
                                                Text="*"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Name" runat="server" 
                                                Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Left" Width="300px" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField >
                                        <FooterTemplate>                                           
                                            <asp:ImageButton ID="Img_AddSetAcc" runat="server" ImageUrl="~/Image/add.png" 
                                                Width="25px" onclick="Img_AddSetAcc_Click" />                                          
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Img_SetAccDel" runat="server" ImageUrl="~/Image/Del.png" onclick="Img_SetAccDel_Click" 
                                                 />
                                            <asp:ConfirmButtonExtender ID="Img_SetAccDel_ConfirmButtonExtender" runat="server" 
                                                ConfirmText="คุณต้องการลบข้อมูลนี้!" Enabled="True" 
                                                TargetControlID="Img_SetAccDel">
                                            </asp:ConfirmButtonExtender>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#99FFCC" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    Height="30" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <asp:Panel ID="Panel_SetAccErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="90%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_SetAccErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                        </div>
                        </td>
                        <td width="50%" valign="top" style="border-bottom-style: double; border-bottom-width: 2px; border-bottom-color: #999999;">
                        <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="190px" style="height:40px; padding-left:20px;" align="left">
                                <asp:CheckBox ID="Cb_AccSTD" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="อุปกรณ์มาตรฐาน STD" />
                            </td>
                            <td align="left" width="50px">
                                <asp:Label ID="Label23" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td align="left" width="110px">
                                
                                &nbsp;<asp:TextBox ID="Txt_AccSTDPrice" runat="server" CssClass="textbox" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px"></asp:TextBox>
                            </td>
                            <td >
                                <asp:CheckBox ID="Cb_AccSTDFree" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="แถม" />
                            </td>
                        </tr>
                        </table>
                        <div style="padding-top:5px;" align="center">
                            <asp:GridView ID="gv_AccSTD" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" DataKeyNames="ID" EmptyDataText="ไม่พบข้อมูลรายการ!" 
                                ForeColor="#333333" GridLines="None" PageSize="15" ShowFooter="True">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ลำดับ">
                                        <ItemTemplate>
                                            <asp:Label ID="LBNumRow" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            <asp:Label ID="LBID" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รายการ">
                                        <FooterTemplate>
                                            <asp:TextBox ID="Txt_SetACCSTDName" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                                ForeColor="Blue" Width="90%"></asp:TextBox>
                                            <asp:Label ID="Label360" runat="server" ForeColor="Red" 
                                                style="font-size: small" Text="*"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Lb_Name" runat="server" 
                                                Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Left" Width="300px" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField >
                                        <FooterTemplate>
                                            
                                            <asp:ImageButton ID="Img_AddAccSTD" runat="server" ImageUrl="~/Image/add.png" 
                                                Width="25px" onclick="Img_AddAccSTD_Click" />
                                            
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Img_AccSTDDel" runat="server" ImageUrl="~/Image/Del.png" onclick="Img_AccSTDDel_Click" 
                                                 />
                                            <asp:ConfirmButtonExtender ID="Img_AccSTDDel_ConfirmButtonExtender" runat="server" 
                                                ConfirmText="คุณต้องการลบข้อมูลนี้!" Enabled="True" 
                                                TargetControlID="Img_AccSTDDel">
                                            </asp:ConfirmButtonExtender>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#99FFCC" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    Height="30" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <asp:Panel ID="Panel_SetAccSTDErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="90%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_SetAccSTDErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>

                        </div>
                        </td>
                    </tr>
                    <tr>
                    <td colspan="2" align="center" style="padding-top:10px; padding-bottom:10px;">
                    <div align="left" style="padding-left:40px; padding-bottom:5px;">

                        <asp:Label ID="Label396" runat="server" style="font-size: medium" Text="อุปกรณ์ตกแต่งเพิ่มเติม :"></asp:Label>

                        &nbsp;&nbsp;
                        <asp:Label ID="Lb_AdAccPrice" runat="server" style="font-size: medium" ForeColor="Blue">0</asp:Label>

                    </div>
                        <asp:GridView ID="gv_AdAccessories" runat="server" 
                            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" 
                            EmptyDataText="ไม่พบข้อมูลรายการ!" ForeColor="#333333" GridLines="None" 
                            PageSize="15" ShowFooter="True" 
                            onrowdatabound="gv_AdAccessories_RowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="ลำดับ">
                                    <ItemTemplate>
                                        <asp:Label ID="LBAdAccNumRow" runat="server" 
                                            Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                        <asp:Label ID="LBAdAccID" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                    <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รายการ">
                                    <FooterTemplate>
                                        <asp:TextBox ID="Txt_AdAccName" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                            ForeColor="Blue" Width="90%"></asp:TextBox>
                                        <asp:Label ID="Label_AdAccName" runat="server" ForeColor="Red" 
                                            style="font-size: small" Text="*"></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lb_AdAccName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="style4" />
                                    <ItemStyle CssClass="style3" HorizontalAlign="Left" Width="300px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ราคา">
                                    <FooterTemplate>
                                        <asp:TextBox ID="Txt_AdAccPrice" runat="server" CssClass="textbox"  onkeypress="return isNumberKey(event)" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                            ForeColor="Blue" Width="85%"></asp:TextBox>
                                        <asp:Label ID="Label395" runat="server" ForeColor="Red" 
                                            style="font-size: small" Text="*"></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lb_AdAccPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="style4" />
                                    <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="110px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="แถม">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Cb_DAdAccFree" runat="server" Enabled="false"/>
                                        <asp:Label ID="Lb_DAdAccFree" runat="server" Text='<%# Eval("Free") %>' 
                                            Visible="False"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:CheckBox ID="Cb_AdAccFree" runat="server" AutoPostBack="True" ForeColor="Black"
                                style="font-size: medium" Text="แถม" />
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="style4" />
                                    <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <FooterTemplate>
                                        <asp:ImageButton ID="Img_AddAdAcc" runat="server" ImageUrl="~/Image/add.png" 
                                            onclick="Img_AddAdAcc_Click" Width="25px" />
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Img_AdAccDel" runat="server" ImageUrl="~/Image/Del.png" 
                                            onclick="Img_AdAccDel_Click" />
                                        <asp:ConfirmButtonExtender ID="Img_AdAccDel_ConfirmButtonExtender" 
                                            runat="server" ConfirmText="คุณต้องการลบข้อมูลนี้!" Enabled="True" 
                                            TargetControlID="Img_AdAccDel">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                    <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#99FFCC" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                Height="30" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:Panel ID="Panel_AdAccErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="50%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_AdAccErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                    </td>
                    </tr>
                    <tr>
                    <td colspan="2" align="center" style="padding-top:10px; border-top-style: double; border-top-width: 2px; border-top-color: #999999;">
                    <div align="left" style="padding-left:40px; padding-bottom:5px;">
                        <asp:Label ID="Label43" runat="server" style="font-size: medium" Text="ส่วนลด :"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Label ID="Lb_PriceDiscount" runat="server" style="font-size: medium" ForeColor="Blue">0</asp:Label>
                    </div>
                    <asp:GridView ID="gv_Discount" runat="server" 
                            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" 
                            EmptyDataText="ไม่พบข้อมูลรายการ!" ForeColor="#333333" GridLines="None" 
                            PageSize="15" ShowFooter="True" onrowdatabound="gv_Discount_RowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="ลำดับ">
                                    <ItemTemplate>
                                        <asp:Label ID="LBDCNumRow" runat="server" 
                                            Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                        <asp:Label ID="LBDCID" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                    <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รายการ">
                                    <FooterTemplate>
                                        <asp:TextBox ID="Txt_DcName" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                            ForeColor="Blue" Width="90%"></asp:TextBox>
                                        <asp:Label ID="Label_DcName" runat="server" ForeColor="Red" 
                                            style="font-size: small" Text="*"></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lb_DcName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="style4" />
                                    <ItemStyle CssClass="style3" HorizontalAlign="Left" Width="300px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ราคา">
                                    <FooterTemplate>
                                        <asp:TextBox ID="Txt_DcPrice" runat="server" CssClass="textbox"  onkeypress="return isNumberKey(event)" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                            ForeColor="Blue" Width="85%"></asp:TextBox>
                                        <asp:Label ID="Label395" runat="server" ForeColor="Red" 
                                            style="font-size: small" Text="*"></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lb_DcPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="style4" />
                                    <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="110px" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField>
                                    <FooterTemplate>
                                        <asp:ImageButton ID="Img_DcAdd" runat="server" ImageUrl="~/Image/add.png" 
                                            Width="25px" onclick="Img_DcAdd_Click" />
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Img_DcDel" runat="server" ImageUrl="~/Image/Del.png" 
                                            onclick="Img_DcDel_Click" />
                                        <asp:ConfirmButtonExtender ID="Img_DcDel_ConfirmButtonExtender" 
                                            runat="server" ConfirmText="คุณต้องการลบข้อมูลนี้!" Enabled="True" 
                                            TargetControlID="Img_DcDel">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                    <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#99FFCC" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                Height="30" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:Panel ID="Panel_DiscountErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="50%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image9" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_DiscountErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                    </td>
                    </tr>
                    </table>
                    </td>
                </tr>
                </table>
                <div style="width:100%; margin-top:10px; padding-top:10px; padding-top:10px; border-top-style: solid; border-top-width: 1px; border-top-color: #CCCCCC;">
                    <div style="padding-right:50px;" Align="right">
                        <asp:LinkButton ID="LinkButton3" runat="server" Text="ถัดไป >>" 
                            Font-Underline="true" Font-Size="Larger" onclick="LinkButton3_Click"></asp:LinkButton>
                    </div>
                </div>
                </asp:Panel>
                <asp:Panel ID="Panel_Finance" runat="server">
                <table>
                <tr>
                    <td style="padding-top:10px;">
                    <table cellpadding="0" cellspacing="3">
                    <tr>
                        <td style="padding-left:50px; " width="140px">
                            <asp:Label ID="Label398" runat="server" style="font-size: medium" 
                                Text="ไฟแนนซ์ :"></asp:Label>
                            <asp:Label ID="Label399" runat="server" ForeColor="Red" 
                                style="font-size: small" Text="*"></asp:Label>
                        </td>
                        <td width="170px">
                            <asp:DropDownList ID="DD_Finance" runat="server" CssClass="textbox" 
                                ForeColor="Blue" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td width="160px">
                            <asp:Label ID="Label400" runat="server" style="font-size: medium" 
                                Text="เจ้าหน้าที่ไฟแนนซ์ :"></asp:Label>
                            <asp:Label ID="Label401" runat="server" ForeColor="Red" 
                                style="font-size: small" Text="*"></asp:Label>
                        </td>
                        <td width="170px">
                            <asp:TextBox ID="Txt_EmpFinance" runat="server" CssClass="textbox" ForeColor="Blue" onfocus="formInUse = true;" onblur="formInUse = false;"
                                Width="150px"></asp:TextBox>
                        </td>
                        <td width="100px">
                        </td>
                        <td width="160px">
                        </td>
                    </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label416" runat="server" style="font-size: medium" 
                                    Text="ราคารถยนต์ :"></asp:Label>
                                <asp:Label ID="Label417" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Txt_CarPrice1" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" Width="100px"></asp:TextBox>
                            </td>
                            <td width="160px">
                                <asp:Label ID="Label448" runat="server" style="font-size: medium" 
                                    Text="ราคารถยนต์เพิ่มเติม :"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Txt_CarPriceAd" runat="server" CssClass="textbox" 
                                    onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="150px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label449" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_CarPriceAd_Price" runat="server" AutoPostBack="True" 
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" 
                                    onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" ontextchanged="Txt_CarPriceDetail_Price_TextChanged" 
                                    Width="100px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px" class="style6">
                                <asp:Label ID="Label450" runat="server" style="font-size: medium" 
                                    Text="เงินดาวน์ :"></asp:Label>
                                <asp:Label ID="Label451" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="Txt_PayDown" runat="server" AutoPostBack="True" 
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" ontextchanged="Txt_PayDown_TextChanged" 
                                    Width="100px"></asp:TextBox>
                            </td>
                            <td width="160px" class="style6">
                                <asp:Label ID="Label457" runat="server" style="font-size: medium" 
                                    Text="ยอดจัด(1) :"></asp:Label>
                                <asp:Label ID="Label458" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="Txt_DPeak" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" 
                                    onkeyup="this.value=Comma(this.value);" Width="100px"></asp:TextBox>
                            </td>
                            <td class="style6">
                                </td>
                            <td class="style6">
                                </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="150px">
                                <asp:Label ID="Label456" runat="server" style="font-size:16px;" 
                                    Text="ประกันภัยสินเชื่อ(2) :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_LoanProtection" runat="server" AutoPostBack="True" 
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" 
                                    ontextchanged="Txt_LoanProtection_TextChanged" Width="100px"></asp:TextBox>
                            </td>
                            <td width="160px">
                                <asp:Label ID="Label460" runat="server" style="font-size: medium" 
                                    Text="ยอดเช่าซื้อ((1)+(2)) :"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="Txt_hpcost" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" 
                                    onkeyup="this.value=Comma(this.value);" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label461" runat="server" style="font-size: medium" 
                                    Text="ดอกเบี้ย :"></asp:Label>
                                <asp:Label ID="Label462" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_Interest" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" onfocus="formInUse = true;" onblur="formInUse = false;" 
                                    onkeypress="return isNumberKey(event)" onkeyup="this.value=Comma(this.value);" 
                                    Width="100px"></asp:TextBox>
                                <asp:Label ID="Label463" runat="server" style="font-size: medium" Text="%"></asp:Label>
                            </td>
                            <td width="160px">
                                <asp:Label ID="Label464" runat="server" style="font-size: medium" 
                                    Text="เงื่อนไขดอกเบี้ย :"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="Txt_RemarkInterest" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" onfocus="formInUse = true;" onblur="formInUse = false;" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label404" runat="server" style="font-size: medium" 
                                    Text="จำนวนงวด :"></asp:Label>
                                <asp:Label ID="Label414" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DD_Total_Payment" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" Width="130px" AutoPostBack="True">
                                    <asp:ListItem Value="12">12 งวด (1ปี)</asp:ListItem>
                                    <asp:ListItem Value="24">24 งวด (2ปี)</asp:ListItem>
                                    <asp:ListItem Value="36">36 งวด (3ปี)</asp:ListItem>
                                    <asp:ListItem Value="48">48 งวด (4ปี)</asp:ListItem>
                                    <asp:ListItem Value="60">60 งวด (5ปี)</asp:ListItem>
                                    <asp:ListItem Value="72">72 งวด (6ปี)</asp:ListItem>
                                    <asp:ListItem Value="84">84 งวด (7ปี)</asp:ListItem>
                                    <asp:ListItem Value="96">96 งวด (8ปี)</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="160px">
                            <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                            <td align="left" >
                                <asp:Label ID="Label406" runat="server" style="font-size: medium" 
                                    Text="งวดละ :"></asp:Label>
                                <asp:Label ID="Label413" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td align="right" style="padding-right:5px;">
                                <asp:ImageButton ID="Img_Cal" runat="server" ImageUrl="~/Image/calculator.png" 
                                    Width="25px" onclick="Img_Cal_Click" />
                            </td>
                            </tr>
                            </table>  
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_Price_Payment" runat="server" CssClass="textbox" onkeypress="return isNumberKey(event)" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue"  Width="100px"></asp:TextBox>
                                <asp:Label ID="Label410" runat="server" style="font-size: medium" Text="บาท"></asp:Label>
                            </td>
                            <td colspan="2">
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="middle">
                                    <asp:CheckBox ID="Cb_Begin" runat="server" style="font-size: medium" 
                                    Text="ชำระค่างวดล่วงหน้า" />
                                </td>
                                <td style="padding-left:5px;">
                                    <asp:TextBox ID="Txt_Pay_Begin" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" Width="30px" Text="1"></asp:TextBox>
                                </td>
                                <td style="padding-left:5px;" valign="middle">
                                    <asp:Label ID="Label442" runat="server" style="font-size: medium" Text="งวด"></asp:Label>
                                </td>
                            </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label415" runat="server" style="font-size: medium" 
                                    Text="แคมเพนจ์งาน :"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="Txt_CampaignName" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                        <div style="width:90%; padding-left:50px;">
                                        <hr />
                        </div>  
                        </td>
                    </tr>
                    </table>
                    <table cellpadding="0" cellspacing="3">
                    <tr>
                        <td style="padding-left:50px; height:30px; " width="160px" >
                            <asp:Label ID="Label439" runat="server" Font-Underline="true" 
                                style="font-size: medium" Text="รายการชำระเงิน"></asp:Label>
                        </td>
                        <td colspan="6">
                            &nbsp;</td>
                    </tr>
                        <tr>
                            <td style="padding-left:15px; " width="190px">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label39" runat="server" style="font-size: medium" Text="มัดจำรถ"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label40" runat="server" style="font-size: medium" 
                                                Text="เลขที่ใบเสร็จ :"></asp:Label>
                                            <asp:Label ID="Label431" runat="server" ForeColor="Red" 
                                                style="font-size: small" Text="*"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="6">
                            <table>
                            <tr>
                                <td width="160px">
                                    <asp:TextBox ID="Txt_DepositNo" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="140px"></asp:TextBox>
                                </td>
                                <td width="60px">
                                    <asp:Label ID="Label430" runat="server" style="font-size: medium" Text="วันที่ : "></asp:Label>
                                    <asp:Label ID="Label432" runat="server" ForeColor="Red" style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td width="130px">
                                    <asp:TextBox ID="Txt_DepositDate" runat="server" AutoPostBack="True" 
                                    CssClass="textbox" ForeColor="Blue" ontextchanged="Txt_DepositDate_TextChanged" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    Width="100px"></asp:TextBox>
                                <asp:ImageButton ID="Img_DepositDate" runat="server" ImageAlign="Bottom" 
                                    ImageUrl="~/Image/Calendar.png" width="20px" />
                                <asp:CalendarExtender ID="CalendarExtender_DepositDate" runat="server" 
                                    Format="dd MMM yy" PopupButtonID="Img_DepositDate" 
                                    TargetControlID="Txt_DepositDate">
                                </asp:CalendarExtender>
                                </td>
                                <td width="100px">
                                    <asp:Label ID="Label41" runat="server" style="font-size: medium" Text="จำนวนเงิน : "></asp:Label>
                                    <asp:Label ID="Label433" runat="server" ForeColor="Red" style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td width="110px">
                                    <asp:TextBox ID="Txt_DepositPrice" runat="server" 
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" 
                                    Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:15px; " width="190px">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label73" runat="server" style="font-size: medium" Text="มัดจำเพิ่มเติม"></asp:Label>
                                        </td>
                                        <td align="left" style="padding-left:5px;">
                                            <asp:Label ID="Label74" runat="server" style="font-size: medium" 
                                                Text="เลขที่ใบเสร็จ :"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="6">
                            <table>
                            <tr>
                                <td width="160px">
                                    <asp:TextBox ID="Txt_DepositAdNo" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="140px"></asp:TextBox>
                                </td>
                                <td width="60px">
                                    <asp:Label ID="Label75" runat="server" style="font-size: medium" Text="วันที่ : "></asp:Label>
                                </td>
                                <td width="130px">
                                    <asp:TextBox ID="Txt_DepositAdDate" runat="server" AutoPostBack="True" 
                                    CssClass="textbox" ForeColor="Blue" ontextchanged="Txt_DepositAdDate_TextChanged" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    Width="100px"></asp:TextBox>
                                <asp:ImageButton ID="Img_DepositAdDate" runat="server" ImageAlign="Bottom" 
                                    ImageUrl="~/Image/Calendar.png" width="20px" />
                                <asp:CalendarExtender ID="CalendarExtender_DepositAdDate" runat="server" 
                                    Format="dd MMM yy" PopupButtonID="Img_DepositAdDate" 
                                    TargetControlID="Txt_DepositAdDate">
                                </asp:CalendarExtender>
                                </td>
                                <td width="100px">
                                    <asp:Label ID="Label77" runat="server" style="font-size: medium" Text="จำนวนเงิน : "></asp:Label>
                                </td>
                                <td width="110px">
                                    <asp:TextBox ID="Txt_DepositAdPrice" runat="server" 
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" 
                                    Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:15px; " width="190px">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label44" runat="server" style="font-size: medium" Text="มัดจำป้ายแดง"></asp:Label>
                                        </td>
                                        <td align="left" style="padding-left:5px;">
                                            <asp:Label ID="Label45" runat="server" style="font-size: medium" 
                                                Text="เลขที่ใบเสร็จ :"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="6">
                            <table>
                            <tr>
                                <td width="160px">
                                    <asp:TextBox ID="Txt_RedCarPlate_No" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="140px"></asp:TextBox>
                                </td>
                                <td width="60px">
                                    <asp:Label ID="Label69" runat="server" style="font-size: medium" Text="วันที่ : "></asp:Label>
                                </td>
                                <td width="130px">
                                    <asp:TextBox ID="Txt_RedCarPlate_Date" runat="server" AutoPostBack="True" 
                                    CssClass="textbox" ForeColor="Blue" ontextchanged="Txt_RedCarPlate_Date_TextChanged" onfocus="formInUse = true;" onblur="formInUse = false;" 
                                    Width="100px"></asp:TextBox>
                                <asp:ImageButton ID="Img_RedCarPlate_Date" runat="server" ImageAlign="Bottom" 
                                    ImageUrl="~/Image/Calendar.png" width="20px" />
                                <asp:CalendarExtender ID="CalendarExtender_RedCarPlate_Date" runat="server" 
                                    Format="dd MMM yy" PopupButtonID="Img_RedCarPlate_Date" 
                                    TargetControlID="Txt_RedCarPlate_Date">
                                </asp:CalendarExtender>
                                </td>
                                <td width="90px">
                                    <asp:Label ID="Label71" runat="server" style="font-size: medium" Text="จำนวนเงิน : "></asp:Label>
                                </td>
                                <td width="110px">
                                    <asp:TextBox ID="Txt_RedCarPlate_Price" runat="server" 
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" 
                                    Width="100px"></asp:TextBox>
                                </td>
                                <td width="70px" >
                                    <asp:Label ID="Label68" runat="server" style="font-size: medium" 
                                    Text="เลขที่ :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_RedCarPlate_Num" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="90px"></asp:TextBox>
                                </td>
                            </tr>
                            </table>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="padding-left:50px; " width="160px">
                            </td>
                            <td width="160px">
                            </td>
                            <td width="60px">
                            </td>
                            <td width="135px">
                            </td>
                            <td width="95px">
                            </td>
                            <td width="110px">
                            </td>
                            <td style="width: 170px" width="70px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left:100px; width: 330px; height:60px;" >
                                <asp:Label ID="Label440" runat="server" Font-Underline="true" Font-Bold="true"
                                    style="font-size: medium" Text="รวมยอดเงินค่ารถ"></asp:Label>
                            </td>
                            <td colspan="5">
                                <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-left:40px;">
                                        &nbsp;</td>
                                    <td style="padding-left:10px;">
                                        <asp:TextBox ID="Txt_PriceSumCar" runat="server" AutoPostBack="True" Font-Bold="true"
                                            CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                            onkeyup="this.value=Comma(this.value);" Width="100px" Disabled></asp:TextBox>
                                    </td>
                                    <td style="padding-left:5px;">
                                        <asp:Label ID="Label441" runat="server" style="font-size: medium;" Font-Bold="true"  Text="บาท"></asp:Label>
                                    </td>
                                </tr>
                                </table>
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left:100px; width: 330px; " >
                                <asp:Label ID="Label70" runat="server" Font-Underline="true" Font-Bold="true"
                                    style="font-size: medium" Text="รวมยอดเงินที่ลูกค้าจะต้องชำระ"></asp:Label>
                            </td>
                            <td colspan="5">
                                <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-left:20px;">
                                        <asp:ImageButton ID="Img_CalSum" runat="server" 
                                        ImageUrl="~/Image/calculator.png" onclick="Img_CalSum_Click" Width="25px" />
                                    </td>
                                    <td style="padding-left:10px;">
                                        <asp:TextBox ID="Txt_PriceSum" runat="server" AutoPostBack="True" Font-Bold="true"
                                            CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                            onkeyup="this.value=Comma(this.value);" Width="100px" Disabled></asp:TextBox>
                                    </td>
                                    <td style="padding-left:5px;">
                                        <asp:Label ID="Label72" runat="server" style="font-size: medium;" Font-Bold="true"  Text="บาท"></asp:Label>
                                    </td>
                                </tr>
                                </table>
                                
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                        <div style="width:90%; padding-left:50px;">
                                        <hr />
                        </div>  
                        </td>
                    </tr>
                    </table>
                    <table cellpadding="0" cellspacing="3">
                    <tr>
                        <td style="padding-left:50px; " width="140px" valign="top">
                            <asp:Label ID="Label46" runat="server" style="font-size: medium" Text="หมายเหตุเพิ่มเติม :" ></asp:Label>
                        <td>
                            <asp:TextBox ID="Txt_Remark" runat="server" CssClass="textbox" 
                                Height="50px" onfocus="formInUse = true;" onblur="formInUse = false;" 
                                TextMode="MultiLine" Width="700px"></asp:TextBox>
                        </td>
                        
                    </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                        <div style="width:90%; padding-left:50px;">
                                        <hr />
                        </div>  
                        </td>
                    </tr>
                    </table>
                    <table cellpadding="0" cellspacing="3">
                    <tr>
                        <td style="padding-left:50px; " width="140px" >
                            <asp:Label ID="Label434" runat="server" style="font-size: medium" Text="เอกสารเพิ่มเติม" Font-Underline="true"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="Cb_C_IDCard" runat="server" 
                                style="font-size: medium" Text="บัตรประจำตัวประชาชน" />
                        </td>
                        <td style="padding-left:20px;">
                            <asp:CheckBox ID="Cb_C_HouseRegistration" runat="server" 
                                style="font-size: medium" Text="สำเนาทะเบียนบ้าน" />
                        </td>
                        <td style="padding-left:20px;">
                            <asp:CheckBox ID="Cb_C_Scrape" runat="server" style="font-size: medium" 
                                Text="ขูดลาย" />
                        </td>
                    </tr>
                        <tr>
                            <td style="padding-left:50px; ">
                                &nbsp;</td>
                            <td>
                                <asp:CheckBox ID="Cb_C_ActInsurance" runat="server" style="font-size: medium" 
                                    Text="พ.ร.บ. + ประกันภัย" />
                            </td>
                            <td style="padding-left:20px;">
                                <asp:CheckBox ID="Cb_C_Finance" runat="server" style="font-size: medium" 
                                    Text="ใบอนุมัติไฟแนนซ์" />
                        </td>
                        <td style="padding-left:20px;">
                            <asp:CheckBox ID="Cb_C_CVIP" runat="server" style="font-size: medium" 
                                Text="CVIP" />
                            </td>
                        </tr>
                    </table>
                    <div style="width:100%; margin-top:10px; padding-top:10px; padding-top:10px; border-top-style: solid; border-top-width: 1px; border-top-color: #CCCCCC;">
                    <div style="padding-right:50px;" Align="center">
                        <asp:CheckBox ID="Cb_Confirm" runat="server"  ForeColor="Blue"  style="font-size: medium; " 
                            Text="ยืนยันตรวจสอบความถูกต้องของข้อมูลเรียบร้อยแล้ว" /><br /><br />
                        <asp:Button ID="Btn_Save" runat="server" CssClass="css_button"   
                            Text="บันทึกข้อมูล" onclick="Btn_Save_Click" /> 
                            <asp:ConfirmButtonExtender ID="Btn_SavePO_ConfirmButtonExtender" runat="server" 
                                             DisplayModalPopupID="mdpopupBooking" Enabled="True" TargetControlID="Btn_Save">
                                        </asp:ConfirmButtonExtender>
                                        <asp:ModalPopupExtender ID="mdpopupBooking" runat="server" PopupControlID="pnlPopup_PO" TargetControlID="Btn_Save" OkControlID = "btnYes_PO"
                    CancelControlID="btnNo_PO" BackgroundCssClass="modalBackground" >
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup_PO" runat="server"  style="display:none">
                <div class="confirm">
  <h1>Confirm your action</h1>
  <p>Are you sure <strong>Confirm</strong>?</p>
  <button id="btnYes_PO" runat="server">Confirm</button>
  <button id="btnNo_PO" runat="server">Cancel</button>
</div>
            
           </asp:Panel>   
                    </div>
                </div>
                <asp:Panel ID="Panel_ConfirmErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                    </td>
                </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
        </table>
          

        </div>
        </asp:Panel>
        <asp:Button ID="btn_Address" runat="server" style="display:none" Text="Button" />
            <asp:ModalPopupExtender ID="ModalPopupExtender_Address" runat="server" 
                BackgroundCssClass="modalBackground" PopupControlID="Panel_PopupAddress" 
                     TargetControlID="btn_Address" >
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel_PopupAddress" runat="server" Width="800px" style="display:none">
            <div align="center" class="modalPopupDetail" style="padding-bottom:10px; ">                   
                <table cellpadding="0" cellspacing="0" width="100%" style="padding-top:5px; padding-left:5px; padding-right:5px;  ">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%" style="height:40px; background:#6189df; ">
                                <tr>
                                    <td style="width:30px; padding-left:10px; padding-right:10px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/LOGO ISUZU1.png" Width="20px" />
                                    </td>
                                    <td align="left" >
                                        <asp:Label ID="Lb_AddName" runat="server" Font-Bold="True" Font-Size="Medium" 
                                            ForeColor="White"></asp:Label>
                                        </td>
                                        <td style="width:30px;">
                                            <asp:ImageButton ID="Img_Close" runat="server" Height="20px" 
                                                ImageUrl="~/Image/close.png" Width="20px" onclick="Img_Close_Click" />
                                    </td>
                                </tr>
                            </table>
                            <div align="left" style="width:100%; padding-top:10px; padding-bottom:10px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;">
        <div style="padding-left:50px;">
            <asp:Label ID="Label13" runat="server" Text="* ข้อมูลที่จำเป็นต้องกรอก" ForeColor="Red" Font-Size="Small"></asp:Label>
        </div>
        </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >
                            <table cellpadding="0" cellspacing="4" style="padding-top:10px; padding-bottom:10px; border-style: solid; border-width: 1px; border-color: #CCCCCC; border-bottom-style: solid; border-bottom-width: 2px; border-bottom-color: #CCCCCC;">
                            <tr>
                                <td style="padding-left:30px; width:110px;">
                                    <asp:Label ID="Label324" runat="server" style="font-size: medium" 
                                        Text="เลขที่ :"></asp:Label>
                                    <asp:Label ID="Label327" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td style="width:150px;">
                                    <asp:TextBox ID="Txt_Add_Address" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue"  Width="70px"></asp:TextBox>
                                </td>
                                <td style="width:100px;">
                                    <asp:Label ID="Label325" runat="server" style="font-size: medium" 
                                        Text="หมู่ที่ :"></asp:Label>   
                                </td>
                                <td style="width:150px;">
                                    <asp:TextBox ID="Txt_Add_Moo" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="70px"></asp:TextBox>
                                </td>
                                <td style="width:100px;">
                                    <asp:Label ID="Label326" runat="server" style="font-size: medium" 
                                        Text="หมู่บ้าน :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_Add_HomeName" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="120px"></asp:TextBox>
                                </td>
                            </tr>
                                <tr>
                                    <td style="padding-left:30px; width:110px;">
                                        <asp:Label ID="Label328" runat="server" style="font-size: medium" 
                                            Text="ถนน :"></asp:Label>
                                    </td>
                                    <td style="width:150px;">
                                        <asp:TextBox ID="Txt_Add_Road" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                            ForeColor="Blue" Width="140px"></asp:TextBox>
                                    </td>
                                    <td style="width:100px;">
                                        <asp:Label ID="Label329" runat="server" style="font-size: medium" Text="ซอย :"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="Txt_Add_Soi" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                            ForeColor="Blue" Width="140px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left:30px; width:110px;">
                                        <asp:Label ID="Label330" runat="server" style="font-size: medium" Text="จังหวัด :"></asp:Label>
                                        <asp:Label ID="Label331" runat="server" ForeColor="Red" 
                                            style="font-size: small" Text="*"></asp:Label>
                                    </td>
                                    <td style="width:150px;">
                                        <asp:DropDownList ID="DD_Add_Province" runat="server" CssClass="textbox" 
                                            ForeColor="Blue" Width="140px" AutoPostBack="True" 
                                            onselectedindexchanged="DD_Add_Province_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:100px;">
                                        <asp:Label ID="Label332" runat="server" style="font-size: medium" 
                                            Text="อำเเภอ :"></asp:Label>
                                        <asp:Label ID="Label333" runat="server" ForeColor="Red" 
                                            style="font-size: small" Text="*"></asp:Label>
                                    </td>
                                    <td style="width:150px;">
                                        <asp:DropDownList ID="DD_Add_Amphur" runat="server" CssClass="textbox" 
                                            ForeColor="Blue" Width="140px" AutoPostBack="True" 
                                            onselectedindexchanged="DD_Add_Amphur_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:100px;">
                                        <asp:Label ID="Label334" runat="server" style="font-size: medium" 
                                            Text="ตำบล :"></asp:Label>
                                        <asp:Label ID="Label335" runat="server" ForeColor="Red" 
                                            style="font-size: small" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DD_Add_District" runat="server" CssClass="textbox" 
                                            ForeColor="Blue" Width="140px" AutoPostBack="True" 
                                            onselectedindexchanged="DD_Add_District_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left:30px; width:110px;">
                                        <asp:Label ID="Label336" runat="server" style="font-size: medium" 
                                            Text="รหัสไปรษณีย์ :"></asp:Label>
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="Txt_Add_Postel" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                            ForeColor="Blue" onkeypress="return enforcechar(this,5,event)" Width="70px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel1_AddAddress_Err" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="400px" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px;">
                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_AddAddress_Err" runat="server" ForeColor="Red" Font-Bold="true" ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                            <div Align="center" style="padding-top:10px;">
                            <asp:Button ID="Btn_SaveAddAddress" runat="server" CssClass="css_button" 
                                            Text="บันทึก" onclick="Btn_SaveAddAddress_Click" />
                                        &nbsp;
                                        <asp:Button ID="Btn_CancelAddAddress" runat="server" CssClass="css_button" 
                                            Text="ยกเลิก" onclick="Btn_CancelAddAddress_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
                   
            </div>
            </asp:Panel>  

        <asp:Button ID="Button_PopupRefreshCus" runat="server" style="display:none" Text="Button" />
            <asp:ModalPopupExtender ID="ModalPopupExtender_RefreshCus" runat="server" 
                BackgroundCssClass="modalBackground" PopupControlID="Panel_PopupRefreshCus" 
                     TargetControlID="Button_PopupRefreshCus" >
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel_PopupRefreshCus" runat="server" Width="400px" style="display:none">
            <div align="center" class="modalPopupDetail" style="padding-bottom:10px; ">                   
                <table cellpadding="0" cellspacing="0" width="100%" style="padding-top:5px; padding-left:5px; padding-right:5px;  ">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%" style="height:40px; background:#6189df; ">
                                <tr>
                                    <td style="width:30px; padding-left:10px; padding-right:10px;">
                                        <asp:Image ID="Image11" runat="server" ImageUrl="~/Image/LOGO ISUZU1.png" Width="20px" />
                                    </td>
                                    <td align="left" >
                                        <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="Medium" 
                                            ForeColor="White" Text="เปลี่ยนชื่อลูกค้า"></asp:Label>
                                        </td>
                                        <td style="width:30px;">
                                            <asp:ImageButton ID="Img_RF_Close" runat="server" Height="20px" 
                                                ImageUrl="~/Image/close.png" Width="20px" onclick="Img_RF_Close_Click" />
                                    </td>
                                </tr>
                            </table>
                            <div align="left" style="width:100%; padding-top:10px; padding-bottom:10px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;">
        <div style="padding-left:50px;">
            <asp:Label ID="Label48" runat="server" Text="* ข้อมูลที่จำเป็นต้องกรอก" ForeColor="Red" Font-Size="Small"></asp:Label>
        </div>
        </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >
                        <table cellpadding="0" cellspacing="0" width="100%" style="padding-top:10px; border-style: solid; border-width: 1px; border-color: #CCCCCC; border-bottom-style: solid; border-bottom-width: 2px; border-bottom-color: #CCCCCC;">
                        <tr>
                            <td>
                            <table cellpadding="0" cellspacing="4">
                            <tr>
                                <td style="padding-left:20px;" valign="middle">
                                    <asp:Label ID="Label445" runat="server" style="font-size: medium" 
                                        Text="ประเภทลูกค้า :"></asp:Label>
                                </td>
                                <td style="padding-left:5px;"  valign="middle">
                                    <asp:DropDownList ID="DD_RF_CusType" runat="server" AutoPostBack="True" 
                                        ForeColor="Blue" 
                                        style="font-size: medium" 
                                        onselectedindexchanged="DD_RF_CusType_SelectedIndexChanged">
                                        <asp:ListItem>บุคคล</asp:ListItem>
                                        <asp:ListItem>บริษัท</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Panel ID="Panel_RF_Person" runat="server" Visible="false">
                            <table cellpadding="0" cellspacing="4">
                            <tr>
                                <td style="padding-left:20px;" valign="middle">
                                    <asp:Label ID="Label446" runat="server" style="font-size: medium" 
                                        Text="เลขบัตรประชาชน :"></asp:Label>
                                    <asp:Label ID="Label447" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_RF_IDCard" runat="server" 
                                    CssClass="textbox" ForeColor="Blue" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeypress="return enforcechar(this,13,event)"  Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel_RF_Company" runat="server" Visible="false">
                            <table cellpadding="0" cellspacing="4">
                            <tr>
                                <td style="padding-left:20px;" valign="middle">
                                    <asp:Label ID="Label66" runat="server" style="font-size: medium" 
                                        Text="เลขนิติบุคคล :"></asp:Label>
                                    <asp:Label ID="Label67" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td style="padding-left:5px;">
                                    <asp:TextBox ID="Txt_RF_Company" runat="server" 
                                    CssClass="textbox" ForeColor="Blue" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeypress="return enforcechar(this,13,event)"   Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            </table>
                            </asp:Panel>
                            </td>
                        </tr>
                        </table>
                            <asp:Panel ID="Panel_RF_Err" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table  style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px;">
                                            <asp:Image ID="Image12" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left" style="padding-left:5px; padding-right:10px;">
                                            <asp:Label ID="Lb_RF_Err" runat="server" ForeColor="Red" Font-Bold="true" ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                            <div Align="center" style="padding-top:10px;">
                            <asp:Button ID="Btn_RF_Save" runat="server" CssClass="css_button" 
                                            Text="บันทึก" onclick="Btn_RF_Save_Click"  />
                                        &nbsp;
                                        <asp:Button ID="Btn_RF_Cancel" runat="server" CssClass="css_button" 
                                            Text="ยกเลิก" onclick="Btn_RF_Cancel_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
                   
            </div>
            </asp:Panel>  
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
