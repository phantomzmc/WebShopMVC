<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="_SPurchaseForm.aspx.cs" Inherits="Purchase._Form._SPurchaseForm" MaintainScrollPositionOnPostback="true"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ajax__combobox_itemlist
        {เลขบัตรประชาชน
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
        </style>
    <script LANGUAGE="JavaScript">
//        var postbackControl = null; 
//        var parm = Sys.WebForms.PageRequestManager.getInstance(); 
//        parm.add_beginRequest(BeginRequestHandler); 
//        parm.add_endRequest(EndRequestHandler); 

//        function BeginRequestHandler(sender, args) 
//        { 
//         postbackControl = args.get_postBackElement(); 
//         postbackControl.disabled = true; 
//        }
//        function EndRequestHandler(sender, args) {
//            postbackControl.disabled = false;
//            postbackControl = null;
//        }


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
            <asp:Label ID="Label1" runat="server" Text="ค้นหาใบสั่งซื้อ" ForeColor="Black" Font-Bold="true" Font-Underline="true" ></asp:Label>
        </div>
        <asp:Panel ID="Panel_SMCNumber" runat="server" style="margin-bottom:10px; border-bottom-style: dotted; border-bottom-width: 3px; border-bottom-color: #CCCCCC;">
                <div Align="center" style="margin:10px; border-style:solid; border-width:1px; border-color: #CCCCCC;">
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
                                            <asp:Label ID="Lb_Search_Err" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                        <table Align="left" cellpadding="0" cellspacing="4">
                        <tr>
                            <td align="left">
                                <table  cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-left:50px; " width="130px">
                                <asp:Label ID="Label2" runat="server" style="font-size: medium" Font-Bold="true"
                                    Text="สาขา :"></asp:Label>
                            </td>
                            <td width="270px">
                                <asp:DropDownList ID="DD_SBranch" runat="server" AutoPostBack="True"  
                                    CssClass="textbox" onselectedindexchanged="DD_SBranch_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </td>
                            <td width="150px">
                                <asp:Label ID="Label3" runat="server" style="font-size: medium" Font-Bold="true"
                                    Text="ชื่อSale :"></asp:Label>
                            </td>
                            <td>                          
                                <asp:DropDownList ID="DD_SaleName" runat="server" Width="200px" CssClass="textbox">
                                </asp:DropDownList>       
                            </td>
                            <td >
                                &nbsp;</td>
                                </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-left:50px; " width="130px">                                       
                                        <asp:Label ID="Label4" runat="server" Font-Bold="true" 
                                            style="font-size: medium" Text="ชื่อลูกค้า :"></asp:Label>
                                    </td>
                                    <td width="270px">
                                        <asp:TextBox ID="Txt_SCusName" runat="server" CssClass="textbox" Font-Bold="true" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="150px"></asp:TextBox>
                                    </td>
                                    <td width="150px">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="true" 
                                        style="font-size: medium" Text="หมายเลขเครื่อง :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txt_SMCNumber" runat="server" CssClass="textbox" Font-Bold="true" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table  cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-left:50px; " width="130px">
                                        <asp:Label ID="Label6" runat="server" Font-Bold="true" 
                                        style="font-size: medium" Text="วันที่เปิด :"></asp:Label>
                                    </td>
                                    <td width="270px">
                                        <asp:TextBox ID="Txt_Date1" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                                                            <asp:ImageButton ID="Img_Date1" runat="server" ImageAlign="Bottom" Width="20px" onfocus="formInUse = true;" onblur="formInUse = false;" 
                                                                    ImageUrl="~/Image/Calendar.png" />
                                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Img_Date1"
                                                                     TargetControlID="Txt_Date1" Format="dd MMM yy" Enabled="True">
                                                                    </asp:CalendarExtender>
                                                            &nbsp;<asp:Label ID="Label7" runat="server" style="font-size: medium;" 
                                                                Text="ถึง"></asp:Label>
                                                            &nbsp;<asp:TextBox ID="Txt_Date2" runat="server" CssClass="textbox" Width="80px" onfocus="formInUse = true;" onblur="formInUse = false;"></asp:TextBox>
                                                            <asp:ImageButton ID="Img_Date2" runat="server" ImageAlign="Bottom" Width="20px"
                                                                    ImageUrl="~/Image/Calendar.png" />
                                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Img_Date2"
                                                                     TargetControlID="Txt_Date2" Format="dd MMM yy" Enabled="True">
                                                                    </asp:CalendarExtender>
                                    </td>
                                    <td width="150px">
                                        <asp:Label ID="Label8" runat="server" Font-Bold="true" 
                                            style="font-size: medium" Text="วันที่ออกรถ :"></asp:Label>
                                    </td>
                                    <td>
                                    <asp:TextBox ID="Txt_OutDate1" runat="server" CssClass="textbox" Width="80px" onfocus="formInUse = true;" onblur="formInUse = false;"></asp:TextBox>
                                                            <asp:ImageButton ID="Img_OutDate1" runat="server" ImageAlign="Bottom" Width="20px" 
                                                                    ImageUrl="~/Image/Calendar.png" />
                                                                    <asp:CalendarExtender ID="CalendarExtender_OutDate1" runat="server" PopupButtonID="Img_OutDate1"
                                                                     TargetControlID="Txt_OutDate1" Format="dd MMM yy" Enabled="True">
                                                                    </asp:CalendarExtender>
                                                            &nbsp;<asp:Label ID="Label9" runat="server" style="font-size: medium;" 
                                                                Text="ถึง"></asp:Label>
                                                            &nbsp;<asp:TextBox ID="Txt_OutDate2" runat="server" CssClass="textbox" Width="80px" onfocus="formInUse = true;" onblur="formInUse = false;"></asp:TextBox>
                                                            <asp:ImageButton ID="Img_OutDate2" runat="server" ImageAlign="Bottom" Width="20px"
                                                                    ImageUrl="~/Image/Calendar.png" />
                                                                    <asp:CalendarExtender ID="CalendarExtender_OutDate2" runat="server" PopupButtonID="Img_OutDate2"
                                                                     TargetControlID="Txt_OutDate2" Format="dd MMM yy" Enabled="True">
                                                                    </asp:CalendarExtender>
                                    </td>
                                </tr>                                  
                                </table>
                                <asp:Panel ID="Panel_SRegis_Date" runat="server">
                                <div style="padding-top:4px;">
                                <table cellpadding="0" cellspacing="0" >
                                <tr>
                                    <td style="padding-left:50px; " width="130px">
                                        <asp:Label ID="Label52" runat="server" Font-Bold="true" 
                                            style="font-size: medium" Text="วันที่จดทะเบียน :"></asp:Label>
                                    </td>
                                    <td width="270px">
                                        <asp:TextBox ID="Txt_SRegisDate1" runat="server" CssClass="textbox" Width="80px" onfocus="formInUse = true;" onblur="formInUse = false;"></asp:TextBox>
                                        <asp:ImageButton ID="Img_SRegisDate1" runat="server" ImageAlign="Bottom" Width="20px"  
                                                                    ImageUrl="~/Image/Calendar.png" />
                                                                    <asp:CalendarExtender ID="CalendarExtender_SRegisDate1" runat="server" PopupButtonID="Img_SRegisDate1"
                                                                     TargetControlID="Txt_SRegisDate1" Format="dd MMM yy" Enabled="True">
                                                                    </asp:CalendarExtender>
                                        &nbsp;<asp:Label ID="Label473" runat="server" style="font-size: medium;" Text="ถึง"></asp:Label>
                                        &nbsp;<asp:TextBox ID="Txt_SRegisDate2" runat="server" CssClass="textbox" 
                                            onblur="formInUse = false;" onfocus="formInUse = true;" Width="80px"></asp:TextBox>
                                            <asp:ImageButton ID="Img_SRegisDate2" runat="server" ImageAlign="Bottom" 
                                            ImageUrl="~/Image/Calendar.png" Width="20px" />
                                        <asp:CalendarExtender ID="CalendarExtender_SRegisDate2" runat="server" 
                                            Enabled="True" Format="dd MMM yy" PopupButtonID="Img_SRegisDate2" 
                                            TargetControlID="Txt_SRegisDate2">
                                        </asp:CalendarExtender>
                                        
                                    </td>
                                </tr>
                                </table>
                                </div>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-left:50px; " width="130px">
                                        <asp:Label ID="Label467" runat="server" Font-Bold="true" 
                                                style="font-size: medium" Text="รุ่นรถ :"></asp:Label>
                                    </td>
                                    <td width="270px">
                                            <asp:DropDownList ID="DD_SModel" runat="server" CssClass="textbox" Width="250px">
                                            </asp:DropDownList>
                                    </td>
                                    <td width="150px">
                                        <asp:Label ID="Label465" runat="server" Font-Bold="True" 
                                                style="font-size: medium" Text="รถสาขา :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DD_SCarBranch" runat="server" CssClass="textbox">
                                            </asp:DropDownList>
                                    </td>
                                </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="padding-top:5px; padding-bottom:5px;" >
                            <div >
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                <td>
                                    <asp:Button ID="Btn_Search" runat="server" CssClass="css_button" Text="ค้นหา" Width="100px"
                                    onclick="Btn_Search_Click" />
                                </td>
                                <td style="padding-left:20px;">
                                    <asp:ImageButton ID="Img_ExportExcel" runat="server" ImageUrl="~/Image/excel.png" 
                                    Width="30px" onclick="Img_ExportExcel_Click" />
                                </td>
                                </tr>
                            </table>
                            </div>
                            </td>
                        </tr>
                        </table>
                    </td>
                </tr>
                </table>
                </div>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                <div Align="left" style="papadding-left:50px;">
                    <asp:Label ID="Label32" runat="server" Font-Bold="True" style="font-size: small" Text="< พบข้อมูล "></asp:Label>
                    <asp:Label ID="Lb_CountData" runat="server" Font-Bold="True" style="font-size: small"></asp:Label>
                    <asp:Label ID="Label33" runat="server" Font-Bold="True" style="font-size: small" Text=" รายการ >"></asp:Label>
                </div>
                        <div Align="center">
                    <asp:GridView ID="gv_PO" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" EmptyDataText="ไม่พบข้อมูลรายการ!" GridLines="Horizontal" 
                                ShowHeaderWhenEmpty="True" onrowdatabound="gv_PO_RowDataBound" 
                                AllowPaging="True" onpageindexchanging="gv_PO_PageIndexChanging">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <asp:Label ID="LBNumRow" runat="server" Text="<%# Container.DataItemIndex+1 %>" ></asp:Label>
                                    
                                    <asp:Label ID="LBID" runat="server" Text='<%# Eval("_Purchase.ID") %>' 
                                        Visible="False"></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="style4" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เลขที่PO">
                                <ItemTemplate>
                                    <asp:Label ID="Label53" runat="server" Text='<%# Eval("_Purchase.PurchaseNo") %>' ></asp:Label>
                                    <%--<asp:Label ID="Lb_Purchase_Date" runat="server" 
                                        Text='<%# Eval("_Purchase.Purchase_Date","{0:dd MMM yy}") %>'></asp:Label>--%>
                                </ItemTemplate>
                                <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ลำดับPO">
                                <ItemTemplate>
                                    <asp:Label ID="Lb_PoNum" runat="server" Text='<%# Eval("_Purchase.PoNum") %>' ></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่ออกรถ">
                                <ItemTemplate>
                                    <asp:Label ID="Lb_OutCar_Date" runat="server" 
                                        Text='<%# Eval("_Purchase.OutCar_Date","{0:dd MMM yy}") %>'></asp:Label>
                                        <asp:Label ID="Lb_ToCustomerByDate" runat="server" 
                                        Text='<%# Eval("_Purchase.ToCustomerByDate","{0:dd/mm/yyyy}") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อลูกค้า">
                                <ItemTemplate>
                                    <asp:Label ID="Lb_Name" runat="server" Text='<%# Eval("_Customer.Name") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Left" Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="รุ่นรถ">
                                <ItemTemplate>
                                    <asp:Label ID="Lb_MName" runat="server" Text='<%# Eval("_Purchase.MName") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Left" Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สี">
                                <ItemTemplate>
                                    <asp:Label ID="Lb_CName" runat="server" Text='<%# Eval("_Purchase.CName") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Left" Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เลขเครื่อง">
                                <ItemTemplate>
                                    <asp:Label ID="Lb_MCNumber" runat="server" Text='<%# Eval("_Purchase.MCNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="style3" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="รถสาขา">
                                <ItemTemplate>
                                    <asp:Label ID="Lb_CarBranch" runat="server" Text='<%# Eval("CarBranch") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อSale">
                                <ItemTemplate>
                                    <asp:Label ID="Lb_SaleName" runat="server" Text='<%# Eval("Tb_User.NickName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="แก้ไข">
                                <ItemTemplate>
                                    <asp:ImageButton ID="Img_Edit" runat="server" ImageUrl="~/Image/edit.png" 
                                         Width="30px" onclick="Img_Edit_Click" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="style4" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="50px"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="พิมพ์">
                                <ItemTemplate>
                                    <asp:ImageButton ID="Img_Print" runat="server" ImageUrl="~/Image/print.png" 
                                         Width="30px" onclick="Img_Print_Click" />
                                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_Print" 
                                    runat="server" DisplayModalPopupID="mdpopup_Print" Enabled="True" 
                                    TargetControlID="Img_Print">
                                </asp:ConfirmButtonExtender>
                                <asp:ModalPopupExtender ID="mdpopup_Print" runat="server" 
                                    BackgroundCssClass="modalBackground" CancelControlID="btnNo_Print" 
                                    OkControlID="btnYes_Print" PopupControlID="pnlPopup_Print" 
                                    TargetControlID="Img_Print">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup_Print" runat="server" style="display:none">
                                    <div class="confirm">
                                        <h1>
                                            Confirm your action</h1>
                                        <p>
                                            Are you sure <strong>Confirm</strong>?</p>
                                        <button ID="btnYes_Print" runat="server">
                                            Confirm
                                        </button>
                                        <button ID="btnNo_Print" runat="server">
                                            Cancel
                                        </button>
                                    </div>
                                </asp:Panel>
                                </ItemTemplate>
                                <HeaderStyle CssClass="style4" />
                                <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="50px"/>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" 
                            Height="30px" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>
                        </div>
                </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                <ContentTemplate>
            <asp:Panel ID="Panel_PopupEditPO" runat="server"  >
                
                
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
                                        <table cellpadding="0" cellspacing="0">
                                        <tr>
                                        <td>
                                        <asp:Label ID="Lb_AddName" runat="server" Font-Bold="True" Font-Size="Medium" 
                                            ForeColor="White" Text="แก้ไขข้อมูลใบสั่งซื้อ เลขที่ "></asp:Label>
                                            <asp:Label ID="Lb_PurchaseNo" runat="server" Font-Bold="True" Font-Size="Medium" 
                                            ForeColor="White" ></asp:Label>
                                        <asp:Label ID="Lb_EPOID" runat="server" Font-Bold="True" Font-Size="Medium" 
                                            ForeColor="White" style="display:none"></asp:Label>
                                            &nbsp;
                                            <asp:Label ID="Label54" runat="server" Font-Bold="True" Font-Size="Medium" 
                                            ForeColor="White" Text="ลำดับ "></asp:Label>
                                            &nbsp;
                                            <asp:TextBox ID="Txt_PoNum" runat="server" CssClass="textbox" Enabled="false"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="70px"></asp:TextBox>
                                        </td>
                                        <td style="padding-left:5px;">
                                        <asp:Panel ID="Panel_EditPoNum" runat="server" >    
                <asp:ImageButton ID="Img_EditPoNum" runat="server" Height="25px" 
                    ImageUrl="~/Image/edit.png" onclick="Img_EditPoNum_Click" />
                </asp:Panel>
                <asp:Panel ID="Panel_SavePoNum" runat="server" Visible="false">    
                <asp:ImageButton ID="Img_SavePoNum" runat="server" Height="30px" 
                    ImageUrl="~/Image/save.png" onclick="Img_SavePoNum_Click" />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SavePoNum" runat="server" 
                                             DisplayModalPopupID="mdpopup_SavePoNum" Enabled="True" TargetControlID="Img_SavePoNum">
                                        </asp:ConfirmButtonExtender>
                                        <asp:ModalPopupExtender ID="mdpopup_SavePoNum" runat="server" PopupControlID="pnlPopup_SavePoNum" TargetControlID="Img_SavePoNum" OkControlID = "btnYes_SavePoNum"
                    CancelControlID="btnNo_SavePoNum" BackgroundCssClass="modalBackground" >
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup_SavePoNum" runat="server"  style="display:none">
                <div class="confirm">
  <h1>Confirm your action</h1>
  <p>Are you sure <strong>Confirm</strong>?</p>
  <button id="btnYes_SavePoNum" runat="server">Confirm</button>
  <button id="btnNo_SavePoNum" runat="server">Cancel</button>
</div>
            
           </asp:Panel>  
                    &nbsp;<asp:ImageButton ID="Img_CancelPoNum" runat="server" Height="30px" 
                        ImageUrl="~/Image/cancel.png" onclick="Img_CancelPoNum_Click" />
                </asp:Panel>
                                        </td>
                                        </tr>
                                        </table>
                                        
                                        </td>
                                        <td style="width:30px;">
                                            <asp:ImageButton ID="Img_Close" runat="server" Height="20px" 
                                                ImageUrl="~/Image/close.png" Width="20px" onclick="Img_Close_Click" />
                                    </td>
                                </tr>
                            </table>
                    <asp:Panel ID="Panel2" runat="server" >        
        <div style="background-color: white;  text-align: left; margin-bottom: 10px; border-left-color:#CCCCCC; border-left-style:solid; border-left-width:1px;
        border-right-color:#CCCCCC; border-right-style:solid; border-right-width:1px;
        border-bottom-color:#CCCCCC; border-bottom-style:solid; border-bottom-width:1px; ">
        <div style="width:100%; padding-bottom:10px;" Align="left">
        <table cellpadding="0" cellspacing="3">
        <tr>
            <td style="padding-left:50px;" width="100px"  valign="top">
                <asp:Image ID="Image10" runat="server" ImageUrl="~/Image/LOGO ISUZU1.png" 
                    Width="50px" />
            </td>
            <td valign="middle" style="width:500px;">
                <asp:RadioButtonList ID="Rb_ECompany" runat="server" style="font-size: large;" Font-Bold="true" Enabled="false">
                </asp:RadioButtonList>
            </td>
            <td style="padding-left:10px; width:80px;">
                <asp:Panel ID="Panel_EditCompany" runat="server" >    
                <asp:ImageButton ID="Img_EditCompany" runat="server" Height="25px" 
                    ImageUrl="~/Image/edit.png" onclick="Img_EditCompany_Click" />
                </asp:Panel>
                <asp:Panel ID="Panel_SaveCompany" runat="server" Visible="false">    
                <asp:ImageButton ID="Img_SaveCompany" runat="server" Height="30px" 
                    ImageUrl="~/Image/save.png" onclick="Img_SaveCompany_Click" />
                    <asp:ConfirmButtonExtender ID="Btn_SaveCompany_ConfirmButtonExtender" runat="server" 
                                             DisplayModalPopupID="mdpopup_SaveCompany" Enabled="True" TargetControlID="Img_SaveCompany">
                                        </asp:ConfirmButtonExtender>
                                        <asp:ModalPopupExtender ID="mdpopup_SaveCompany" runat="server" PopupControlID="pnlPopup_SaveCompany" TargetControlID="Img_SaveCompany" OkControlID = "btnYes_SaveCompany"
                    CancelControlID="btnNo_SaveCompany" BackgroundCssClass="modalBackground" >
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup_SaveCompany" runat="server"  style="display:none">
                <div class="confirm">
  <h1>Confirm your action</h1>
  <p>Are you sure <strong>Confirm</strong>?</p>
  <button id="btnYes_SaveCompany" runat="server">Confirm</button>
  <button id="btnNo_SaveCompany" runat="server">Cancel</button>
</div>
            
           </asp:Panel>  
                    &nbsp;<asp:ImageButton ID="Img_CancelCompany" runat="server" Height="30px" 
                        ImageUrl="~/Image/cancel.png" onclick="Img_CancelCompany_Click" />
                </asp:Panel>
            </td>
            <td Align="right" style="padding-right:5px; width:300px;">
                <asp:LinkButton ID="Lbtn_CVIP" runat="server" Text="CVIP >" 
                    ForeColor="Blue" style="padding-left:5px; padding-right:5px;" onclick="Lbtn_CVIP_Click"
                        ></asp:LinkButton>
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
        <div align="left" style="padding-left:50px;">
            <asp:Label ID="Label10" runat="server" Text="* ข้อมูลที่จำเป็นต้องกรอก" ForeColor="Red" Font-Size="Small"></asp:Label><br />
            <asp:Label ID="Label19" runat="server" Text="* รูปแบบการกรอกวันที่ 01/01/2559 หรือ 01 ม.ค. 59" ForeColor="#999999" Font-Size="Small"></asp:Label>
        </div>
        </div>
        <table width="100%"> 
        <tr>
            <td align="left" style="padding-top:10px;">
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
        <ContentTemplate>               
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
                    <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                        <asp:TextBox ID="Txt_EDate" runat="server" CssClass="textbox" Disabled 
                            ForeColor="Blue"  Width="100px" 
                            ToolTip="*รูปแบบการกรอก 01/01/2559 หรือ 01 ม.ค. 59" Enabled="False"></asp:TextBox>
                            <asp:ImageButton ID="Img_EDate" runat="server" ImageAlign="Bottom" width="20px" ImageUrl="~/Image/Calendar.png" />
                            <asp:CalendarExtender ID="CalendarExtender_EDate" runat="server" PopupButtonID="Img_EDate"
                            TargetControlID="Txt_EDate" Format="dd MMM yy">
                            </asp:CalendarExtender>
                        <asp:Label ID="Txt_ECusID" runat="server" style="display:none"></asp:Label>
                        </td>
                        <td style="padding-left:10px;">
                        <asp:Panel ID="Panel_EditOutCar_Date" runat="server" >    
                <asp:ImageButton ID="Img_EditOutCar_Date" runat="server" Height="25px" 
                    ImageUrl="~/Image/edit.png" onclick="Img_EditOutCar_Date_Click" />
                </asp:Panel>
                <asp:Panel ID="Panel_SaveOutCar_Date" runat="server" Visible="false">    
                <asp:ImageButton ID="Img_SaveOutCar_Date" runat="server" Height="30px" 
                    ImageUrl="~/Image/save.png" onclick="Img_SaveOutCar_Date_Click" />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveOutCar_Date" runat="server" 
                                             DisplayModalPopupID="mdpopup_SaveOutCar_Date" Enabled="True" TargetControlID="Img_SaveOutCar_Date">
                                        </asp:ConfirmButtonExtender>
                                        <asp:ModalPopupExtender ID="mdpopup_SaveOutCar_Date" runat="server" PopupControlID="pnlPopup_SaveOutCar_Date" TargetControlID="Img_SaveOutCar_Date" OkControlID = "btnYes_SaveOutCar_Date"
                    CancelControlID="btnNo_SaveOutCar_Date" BackgroundCssClass="modalBackground" >
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup_SaveOutCar_Date" runat="server"  style="display:none">
                <div class="confirm">
  <h1>Confirm your action</h1>
  <p>Are you sure <strong>Confirm</strong>?</p>
  <button id="btnYes_SaveOutCar_Date" runat="server">Confirm</button>
  <button id="btnNo_SaveOutCar_Date" runat="server">Cancel</button>
</div>
            
           </asp:Panel>  
                    &nbsp;<asp:ImageButton ID="Img_CancelOutCar_Date" runat="server" Height="30px" 
                        ImageUrl="~/Image/cancel.png" onclick="Img_CancelOutCar_Date_Click" />
                </asp:Panel>
                        </td>
                    </tr>
                    </table>
                    </td>
                    <td>
                        <asp:Label ID="Label428" runat="server" style="font-size: medium" 
                            Text="รหัสลูกค้า :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Txt_ECusNo" runat="server" CssClass="textbox" Disabled="" 
                            ForeColor="Blue" Width="100px" Enabled="False" ></asp:TextBox>
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
                            <asp:DropDownList ID="DD_ECusType" runat="server" style="font-size: medium" 
                                ForeColor="Blue" AutoPostBack="True" Enabled="False"
                                onselectedindexchanged="DD_ECusType_SelectedIndexChanged">
                                <asp:ListItem>บุคคล</asp:ListItem>
                                <asp:ListItem>บริษัท</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="130px" >
                            <asp:Label ID="Label436" runat="server" style="font-size: medium" Text="ที่ปรึกษาการขาย :"></asp:Label>
                            </td>
                        <td width="170px" >
                            <asp:TextBox ID="Txt_ESaleName" runat="server" CssClass="textbox" Disabled="" 
                                Enabled="false" ForeColor="Blue" Width="170px"></asp:TextBox>
                            </td>
                        <td width="130px" >
                            </td>
                        <td width="150px" >
                            </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        <asp:Panel ID="Panel_EPerson" runat="server">
                        <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label151" runat="server" style="font-size: medium" 
                                    Text="เลขบัตรประชาชน :"></asp:Label>
                                <asp:Label ID="Label339" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td width="180px">
                                <asp:TextBox ID="Txt_EIDCard" runat="server" AutoPostBack="True" 
                                    CssClass="textbox" ForeColor="Blue" Enabled="false"
                                    onkeypress="return enforcechar(this,13,event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ontextchanged="Txt_EIDCard_TextChanged" Width="140px"></asp:TextBox>
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
                                    <asp:Label ID="Label11" runat="server" style="font-size: medium" 
                                        Text="คำนำหน้า / ยศ :"></asp:Label>
                                    <asp:Label ID="Label12" runat="server" ForeColor="Red" style="font-size: small" 
                                        Text="*"></asp:Label>
                                </td>
                                <td width="180px">
                                    <asp:TextBox ID="Txt_EPrefix" runat="server" CssClass="textbox" Enabled="false"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Text="คุณ" Width="70px"></asp:TextBox>
                                </td>
                                <td width="130px">
                                    <asp:Label ID="Label13" runat="server" style="font-size: medium" Text="ชื่อ :"></asp:Label>
                                    <asp:Label ID="Label14" runat="server" ForeColor="Red" style="font-size: small" 
                                        Text="*"></asp:Label>
                                </td>
                                <td width="170px">
                                    <asp:TextBox ID="Txt_EName" runat="server" CssClass="textbox" ForeColor="Blue"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        Width="100px" Enabled="false"></asp:TextBox>
                                </td>
                                <td width="130px">
                                    <asp:Label ID="Label15" runat="server" style="font-size: medium" 
                                        Text="นามสกุล :"></asp:Label>
                                    <asp:Label ID="Label16" runat="server" ForeColor="Red" style="font-size: small" 
                                        Text="*"></asp:Label>
                                </td>
                                <td width="150px">
                                    <asp:TextBox ID="Txt_ESurname" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;" Enabled="false"
                                        ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; " >
                                    <asp:Label ID="Label17" runat="server" Text="ชื่อเล่น :" style="font-size: medium"></asp:Label> 
                                </td>
                                <td >
                                    <asp:TextBox ID="Txt_ENickname" runat="server" CssClass="textbox" Width="100px" ForeColor="Blue"  onfocus="formInUse = true;" onblur="formInUse = false;" Enabled="false"></asp:TextBox>
                                </td>
                                <td >
                                    <asp:Label ID="Label18" runat="server" Text="วันเกิด :" style="font-size: medium"></asp:Label> 
                                    <asp:Label ID="Label20" runat="server" Text="*" style="font-size: small" ForeColor="Red"></asp:Label> 
                                </td>
                                <td >
                                    <asp:TextBox ID="Txt_EBirthday" runat="server" CssClass="textbox" Width="100px" ForeColor="Blue" Enabled="false"
                                AutoPostBack="True" ontextchanged="Txt_EBirthday_TextChanged" onfocus="formInUse = true;" onblur="formInUse = false;"
                                ToolTip="*รูปแบบการกรอก 01/01/2559 หรือ 01 ม.ค. 59" ></asp:TextBox>
                            <asp:ImageButton ID="Img_EBirthday" runat="server" ImageAlign="Bottom" width="20px" 
                                        ImageUrl="~/Image/Calendar.png" Visible="False" />
                            <asp:CalendarExtender ID="CalendarExtender_EBirthday" runat="server" PopupButtonID="Img_EBirthday"
                            TargetControlID="Txt_EBirthday" Format="dd MMM yy">
                            </asp:CalendarExtender>
                                </td>
                                <td >
                                    <asp:Label ID="Label21" runat="server" style="font-size: medium" Text="เพศ :"></asp:Label>
                                </td>
                                <td >
                                    <asp:DropDownList ID="DD_EPerson_Sex" runat="server" CssClass="textbox" Width="100px" ForeColor="Blue" Enabled="false">
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
                                    <asp:DropDownList ID="DD_EEducation" runat="server" CssClass="textbox" Enabled="false"
                                        ForeColor="Blue" Width="140px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label444" runat="server" style="font-size: medium" 
                                        Text="จำนวนสมาชิก :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_ETotal_Member" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="50px" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table> 
                        <div Align="center">
                        <asp:Panel ID="Panel_ConfirmNameErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmNameErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                        <asp:Panel ID="Panel_EditName" runat="server" >    
                <asp:ImageButton ID="Img_EditName" runat="server" Height="25px" 
                    ImageUrl="~/Image/edit.png" onclick="Img_EditName_Click" />
                </asp:Panel>
                <asp:Panel ID="Panel_SaveName" runat="server" Visible="false">    
                <asp:ImageButton ID="Img_SaveName" runat="server" Height="30px" 
                    ImageUrl="~/Image/save.png" onclick="Img_SaveName_Click" />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveName" runat="server" 
                                             DisplayModalPopupID="mdpopup_SaveName" Enabled="True" TargetControlID="Img_SaveName">
                                        </asp:ConfirmButtonExtender>
                                        <asp:ModalPopupExtender ID="mdpopup_SaveName" runat="server" PopupControlID="pnlPopup_SaveName" TargetControlID="Img_SaveName" OkControlID = "btnYes_SaveName"
                    CancelControlID="btnNo_SaveName" BackgroundCssClass="modalBackground" >
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup_SaveName" runat="server"  style="display:none">
                <div class="confirm">
                  <h1>Confirm your action</h1>
                  <p>Are you sure <strong>Confirm</strong>?</p>
                  <button id="btnYes_SaveName" runat="server">Confirm</button>
                  <button id="btnNo_SaveName" runat="server">Cancel</button>
                </div>
            
                </asp:Panel>  
                    &nbsp;<asp:ImageButton ID="Img_CancelName" runat="server" Height="30px" 
                        ImageUrl="~/Image/cancel.png" onclick="Img_CancelName_Click" />
                </asp:Panel>
                
                        </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel_ECompany" runat="server">
                        <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:Label ID="Label424" runat="server" style="font-size: medium" 
                                    Text="เลขนิติบุคคล :"></asp:Label>
                                <asp:Label ID="Label425" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_ECorporationCode" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" onkeypress="return enforcechar(this,13,event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    Width="140px" AutoPostBack="True"  Enabled="false"
                                    ontextchanged="Txt_ECorporationCode_TextChanged"></asp:TextBox>
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
                                <asp:TextBox ID="Txt_ECompanyName" runat="server" CssClass="textbox" ForeColor="Blue"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                    Width="250px" Enabled="false"></asp:TextBox>                                                
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <%----------------%>
                        <div align="center"  >
                        <asp:Panel ID="Panel_EditCompanyName" runat="server" >    
                        <asp:ImageButton ID="Img_EditCompanyName" runat="server" Height="25px" 
                            ImageUrl="~/Image/edit.png" onclick="Img_EditCompanyName_Click" />
                        </asp:Panel>
                         <asp:Panel ID="Panel_SaveCompanyName" runat="server" Visible="false">    
                    <asp:ImageButton ID="Img_SaveCompanyName" runat="server" Height="30px" 
                    ImageUrl="~/Image/save.png" onclick="Img_SaveCompanyName_Click" />
                        <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveCompanyName" runat="server" 
                                             DisplayModalPopupID="mdpopup_SaveCompanyName" Enabled="True" TargetControlID="Img_SaveCompanyName">
                                        </asp:ConfirmButtonExtender>
                       <asp:ModalPopupExtender ID="mdpopup_SaveCompanyName" runat="server" PopupControlID="pnlPopup_SaveCompanyName" TargetControlID="Img_SaveCompanyName" OkControlID = "btnYes_SaveCompanyName"
                    CancelControlID="btnNo_SaveCompanyName" BackgroundCssClass="modalBackground" >
                </asp:ModalPopupExtender>
                 <asp:Panel ID="pnlPopup_SaveCompanyName" runat="server"  style="display:none">
                <div class="confirm">
                  <h1>Confirm your action</h1>
                  <p>Are you sure <strong>Confirm</strong>?</p>
                  <button id="btnYes_SaveCompanyName" runat="server">Confirm</button>
                  <button id="btnNo_SaveCompanyName" runat="server">Cancel</button>
                </div>
            
                </asp:Panel>
                       &nbsp;<asp:ImageButton ID="Img_CancelCompanyName" runat="server" Height="30px" 
                        ImageUrl="~/Image/cancel.png" onclick="Img_CancelCompanyName_Click" /> 
                </asp:Panel>  
                </div>
                       <%-- --------------%>
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
                            <asp:Label ID="Label22" runat="server" Font-Size="Small" ForeColor="#999999" 
                                Text="* กรุณากรอกเบอร์ มือถือ/บ้าน อย่างน้อย 1 เบอร์"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px; height:30px;">
                            <asp:Label ID="Label23" runat="server" style="font-size: medium" 
                                Text="เบอร์มือถือ 1 :"></asp:Label>
                        </td>
                        <td width="150px" colspan="2" style="width: 280px">
                            <asp:TextBox ID="Txt_ETelMobile1" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;" 
                                ForeColor="Blue" onkeypress="return enforcechar(this,10,event)" Width="100px" Enabled="false"></asp:TextBox>
                        </td>
                        <td width="150px">
                            <asp:Label ID="Label251" runat="server" style="font-size: medium" 
                                Text="เบอร์มือถือ 2 :"></asp:Label>
                        </td>
                        <td width="130px" colspan="2" style="width: 280px">
                            <asp:TextBox ID="Txt_ETelMobile2" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                ForeColor="Blue" onkeypress="return enforcechar(this,10,event)" Width="100px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px; height:30px;" >
                            <asp:Label ID="Label24" runat="server" style="font-size: medium" 
                                Text="เบอร์บ้าน/ที่ทำงาน :"></asp:Label>
                        </td>
                        <td width="150px" colspan="2" style="width: 280px">
                            <asp:TextBox ID="Txt_ETelHome_Work" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                ForeColor="Blue"  Width="130px" Enabled="false"></asp:TextBox>
                        </td>
                        <td width="150px">
                            <asp:Label ID="Label26_fax" runat="server" style="font-size: medium" 
                                Text="เบอร์แฟกซ์ :"></asp:Label>
                        </td>
                        <td width="130px" colspan="2" style="width: 280px">
                            <asp:TextBox ID="Txt_EFax" runat="server" CssClass="textbox" ForeColor="Blue"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                Width="130px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px; height:30px;" >
                            <asp:Label ID="Label76" runat="server" style="font-size: medium" 
                                Text="LINE ID :"></asp:Label>
                        </td>
                        <td width="150px" colspan="2" style="width: 280px">
                            <asp:TextBox ID="Txt_ElineID" runat="server" CssClass="textbox"  
                                onfocus="formInUse = true;" onblur="formInUse = false;"
                                ForeColor="Blue"  Width="250px"  Enabled="false"></asp:TextBox>
                        </td>
                        <td width="150px">
                            &nbsp;</td>
                        <td width="130px" colspan="2" style="width: 280px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        <div Align="center">
                        <asp:Panel ID="Panel_ConfirmTelErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmTelErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                        <asp:Panel ID="Panel_EditTel" runat="server" >    
                <asp:ImageButton ID="Img_EditTel" runat="server" Height="25px" 
                    ImageUrl="~/Image/edit.png" onclick="Img_EditTel_Click" />
                </asp:Panel>
                <asp:Panel ID="Panel_SaveTel" runat="server" Visible="false">    
                <asp:ImageButton ID="Img_SaveTel" runat="server" Height="30px" 
                    ImageUrl="~/Image/save.png" onclick="Img_SaveTel_Click" />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveTel" runat="server" 
                                             DisplayModalPopupID="mdpopup_SaveTel" Enabled="True" TargetControlID="Img_SaveTel">
                                        </asp:ConfirmButtonExtender>
                                        <asp:ModalPopupExtender ID="mdpopup_SaveTel" runat="server" PopupControlID="pnlPopup_SaveTel" TargetControlID="Img_SaveTel" OkControlID = "btnYes_SaveTel"
                    CancelControlID="btnNo_SaveTel" BackgroundCssClass="modalBackground" >
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup_SaveTel" runat="server"  style="display:none">
                <div class="confirm">
                  <h1>Confirm your action</h1>
                  <p>Are you sure <strong>Confirm</strong>?</p>
                  <button id="btnYes_SaveTel" runat="server">Confirm</button>
                  <button id="btnNo_SaveTel" runat="server">Cancel</button>
                </div>
            
                </asp:Panel>  
                    &nbsp;<asp:ImageButton ID="Img_CancelTel" runat="server" Height="30px" 
                        ImageUrl="~/Image/cancel.png" onclick="Img_CancelTel_Click" />
                </asp:Panel>
                        </div>
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
                        <td style="padding-left:50px; " valign="top">
                            <asp:Label ID="Label25" runat="server" style="font-size: medium" 
                                Text="อาชีพ :"></asp:Label>
                            <asp:Label ID="Label26" runat="server" ForeColor="Red" 
                                style="font-size: small" Text="*"></asp:Label>
                        </td>
                        <td width="150px" colspan="2" style="width: 280px" >
                            <asp:DropDownList ID="DD_ECareer" runat="server" CssClass="textbox" 
                                ForeColor="Blue" Width="250px" AutoPostBack="True" Enabled="false"
                                onselectedindexchanged="DD_ECareer_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Panel ID="Panel_ECareer_Other" runat="server" Visible="false">
                                                                <table cellpadding="0" cellspacing="3">
                                                                <tr>
                                                                    <td style="padding-top:5px;">
                                                                    <asp:TextBox ID="Txt_ECareer_Other" runat="server" CssClass="textbox" Height="40px"  Width="300px" placeholder="โปรดระบุ.."
                                                                    onfocus="formInUse = true;" onblur="formInUse = false;" TextMode="MultiLine" Enabled="false" ></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                </table>
                            </asp:Panel>
                        </td>
                        <td width="150px" valign="top">
                            <asp:Label ID="Label27" runat="server" style="font-size: medium" 
                                Text="หมายเหตุอาชีพ :"></asp:Label>
                            </td>
                        <td width="130px" colspan="2" style="width: 280px" valign="top">
                            <asp:TextBox ID="Txt_ECareer_Remark" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                ForeColor="Blue" Width="250px" Enabled="false"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="style1" style="padding-left:50px; ">
                            <asp:Label ID="Label342" runat="server" style="font-size: medium" 
                                Text="รายได้ :"></asp:Label>
                        </td>
                        <td colspan="5">
                            <asp:DropDownList ID="DD_EInCome" runat="server" CssClass="textbox" 
                                ForeColor="Blue" Width="200px" Enabled="false">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        <asp:Panel ID="Panel_ConfirmCareerErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmCareerErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                        <div Align="center">
                        <asp:Panel ID="Panel_EditCareer" runat="server" >    
                <asp:ImageButton ID="Img_EditCareer" runat="server" Height="25px" 
                    ImageUrl="~/Image/edit.png" onclick="Img_EditCareer_Click" />
                </asp:Panel>
                <asp:Panel ID="Panel_SaveCareer" runat="server" Visible="false">    
                <asp:ImageButton ID="Img_SaveCareer" runat="server" Height="30px" 
                    ImageUrl="~/Image/save.png" onclick="Img_SaveCareer_Click" />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveCareer" runat="server" 
                                             DisplayModalPopupID="mdpopup_SaveCareer" Enabled="True" TargetControlID="Img_SaveCareer">
                                        </asp:ConfirmButtonExtender>
                                        <asp:ModalPopupExtender ID="mdpopup_SaveCareer" runat="server" PopupControlID="pnlPopup_SaveCareer" TargetControlID="Img_SaveCareer" OkControlID = "btnYes_SaveCareer"
                    CancelControlID="btnNo_SaveCareer" BackgroundCssClass="modalBackground" >
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPopup_SaveCareer" runat="server"  style="display:none">
                <div class="confirm">
                  <h1>Confirm your action</h1>
                  <p>Are you sure <strong>Confirm</strong>?</p>
                  <button id="btnYes_SaveCareer" runat="server">Confirm</button>
                  <button id="btnNo_SaveCareer" runat="server">Cancel</button>
                </div>
            
                </asp:Panel>  
                    &nbsp;<asp:ImageButton ID="Img_CancelCareer" runat="server" Height="30px" 
                        ImageUrl="~/Image/cancel.png" onclick="Img_CancelCareer_Click" />
                </asp:Panel>
                        </div>
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
                            <asp:Label ID="Label28" runat="server" style="font-size: medium" 
                                Text="ที่อยู่ :"></asp:Label>
                            <asp:Label ID="Label29" runat="server" ForeColor="Red" style="font-size: small" 
                                Text="*"></asp:Label>
                        </td>
                        <td colspan="5">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6" style="padding-left:60px; padding-top:5px; padding-bottom:5px; ">

                            <asp:GridView ID="gv_EAddress" runat="server" AutoGenerateColumns="False" 
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
                                            <asp:Button ID="Btn_EditAddress" runat="server" 
                                                Text="แก้ไข" Width="50px" onclick="Btn_EditAddress_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="style4" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="style3" HorizontalAlign="Center" Width="50px" />
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
                            <asp:CheckBox ID="Cb_ESendAddress" runat="server" AutoPostBack="True" 
                                Checked="True" 
                                style="font-size: medium" Text="ตามที่อยู่" 
                                oncheckedchanged="Cb_ESendAddress_CheckedChanged" />
                            &nbsp;
                            <asp:CheckBox ID="Cb_ESendAddress_New" runat="server" AutoPostBack="True" style="font-size: medium" 
                                Text="ที่อยู่ใหม่" oncheckedchanged="Cb_ESendAddress_New_CheckedChanged" />
                        </td>
                        <td>
                            <asp:Button ID="Btn_EAddSendAddress" runat="server" CssClass="css_button" 
                                Text="เพิ่มที่อยู่" onclick="Btn_EAddSendAddress_Click" />
                        </td>
                        <td>
                            <asp:Panel ID="Panel_EditSendAdd" runat="server">
                                <asp:ImageButton ID="Img_EditSendAdd" runat="server" Height="25px" 
                                    ImageUrl="~/Image/edit.png" onclick="Img_EditSendAdd_Click" />
                            </asp:Panel>
                            <asp:Panel ID="Panel_SaveSendAdd" runat="server" Visible="false">
                                <asp:ImageButton ID="Img_SaveSendAdd" runat="server" Height="30px" 
                                    ImageUrl="~/Image/save.png" onclick="Img_SaveSendAdd_Click" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveSendAdd" 
                                    runat="server" DisplayModalPopupID="mdpopup_SaveSendAdd" Enabled="True" 
                                    TargetControlID="Img_SaveSendAdd">
                                </asp:ConfirmButtonExtender>
                                <asp:ModalPopupExtender ID="mdpopup_SaveSendAdd" runat="server" 
                                    BackgroundCssClass="modalBackground" CancelControlID="btnNo_SaveSendAdd" 
                                    OkControlID="btnYes_SaveSendAdd" PopupControlID="pnlPopup_SaveSendAdd" 
                                    TargetControlID="Img_SaveSendAdd">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup_SaveSendAdd" runat="server" style="display:none">
                                    <div class="confirm">
                                        <h1>
                                            Confirm your action</h1>
                                        <p>
                                            Are you sure <strong>Confirm</strong>?</p>
                                        <button ID="btnYes_SaveSendAdd" runat="server">
                                            Confirm
                                        </button>
                                        <button ID="btnNo_SaveSendAdd" runat="server">
                                            Cancel
                                        </button>
                                    </div>
                                </asp:Panel>
                                &nbsp;<asp:ImageButton ID="Img_CancelSendAdd" runat="server" Height="30px" 
                                    ImageUrl="~/Image/cancel.png" onclick="Img_CancelSendAdd_Click" />
                            </asp:Panel>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="6" style="padding-left:60px; padding-top:5px; padding-bottom:5px; ">
                        <asp:Panel ID="Panel_ConfirmSendAddErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image9" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmSendAddErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                            <asp:GridView ID="gv_ESentAddress" runat="server" AutoGenerateColumns="False" 
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
                                            <asp:Button ID="Btn_EditSendAddress" runat="server" Text="แก้ไข" Width="50px" 
                                                onclick="Btn_EditSendAddress_Click" />
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
                <asp:Panel ID="Panel_CarData" runat="server">
                <table>
                <tr>
                    <td style="padding-top:10px;">
                        <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="160px" valign="top" >
                                <asp:Label ID="Label381" runat="server" style="font-size: medium" 
                                    Text="สั่งซื้อรถยนต์ :"></asp:Label>
                                <asp:Label ID="Label382" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td width="310px" valign="top" >
                                <asp:TextBox ID="Txt_ECarName" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" Width="100px">ISUZU</asp:TextBox>
                            </td>
                            <td valign="top" >
                                <asp:Label ID="Label397" runat="server" style="font-size: medium" 
                                    Text="ประเภทการซื้อ :"></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:DropDownList ID="DD_EBuyType" runat="server" CssClass="textbox" 
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
                                    <asp:TextBox ID="Txt_EMCNumber" runat="server" CssClass="textbox" Disabled="" 
                                        ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                                <td width="160px">
                                    <asp:Label ID="Label346" runat="server" style="font-size: medium" 
                                        Text="หมายเลขตัวถัง :"></asp:Label>
                                    <asp:Label ID="Label347" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_ETruckNumber" runat="server" CssClass="textbox" Disabled="" 
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
                                    <asp:TextBox ID="Txt_EMName" runat="server" CssClass="textbox" Disabled="" 
                                        ForeColor="Blue" Width="300px"></asp:TextBox>
                                </td>
                                <td  >
                                    <asp:Label ID="Label385" runat="server" style="font-size: medium" Text="แบบ :"></asp:Label>
                                    <asp:Label ID="Label386" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td  >
                                    <asp:Label ID="Txt_EMCode" runat="server" style="display:none"></asp:Label>
                                    <asp:TextBox ID="Txt_EMSaleCode" runat="server" CssClass="textbox" Disabled="" 
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
                                        <asp:TextBox ID="Txt_ECName" runat="server" CssClass="textbox" Disabled="" 
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
                                    <asp:Label ID="Txt_ECCode" runat="server" style="display:none"></asp:Label>
                                    <asp:TextBox ID="Txt_ECarPrice" runat="server" CssClass="textbox" Disabled="" 
                                        ForeColor="Blue" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label354" runat="server" style="font-size: medium" 
                                        Text="หมายเลขทะเบียน :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_ECarPlate" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; ">
                                    <asp:Label ID="Label472" runat="server" style="font-size: medium" Text="ภาษีรถ :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_CarTax" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label471" runat="server" style="font-size: medium" 
                                        Text="วันที่จดทะเบียน :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_RegisDate" runat="server" AutoPostBack="True" 
                                        CssClass="textbox" Enabled="false" ForeColor="Blue" onblur="formInUse = false;" 
                                        onfocus="formInUse = true;" ontextchanged="Txt_RegisDate_TextChanged" 
                                        ToolTip="*รูปแบบการกรอก 01/01/2559 หรือ 01 ม.ค. 59" Width="100px"></asp:TextBox>
                                    <asp:CalendarExtender ID="Txt_RegisDate_CalendarExtender" runat="server" 
                                        Format="dd MMM yy" PopupButtonID="Img_RegisDate" 
                                        TargetControlID="Txt_RegisDate">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="Img_RegisDate" runat="server" ImageAlign="Bottom" 
                                        ImageUrl="~/Image/Calendar.png" Visible="False" width="20px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; ">
                                    <asp:Label ID="Label474" runat="server" style="font-size: medium" 
                                        Text="ประเภทรถ :" ></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DD_ECarType" runat="server" CssClass="textbox" 
                                        ForeColor="Blue" Width="120px" >
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td Align="center" colspan="4">
                                    <asp:Panel ID="Panel_EditBuyType" runat="server">
                                <asp:ImageButton ID="Img_EdiBuyType" runat="server" Height="25px" 
                                    ImageUrl="~/Image/edit.png" onclick="Img_EdiBuyType_Click" />
                            </asp:Panel>
                            <asp:Panel ID="Panel_SaveBuyType" runat="server" Visible="false">
                                <asp:ImageButton ID="Img_SaveBuyType" runat="server" Height="30px" 
                                    ImageUrl="~/Image/save.png" onclick="Img_SaveBuyType_Click" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveBuyType" 
                                    runat="server" DisplayModalPopupID="mdpopup_SaveBuyType" Enabled="True" 
                                    TargetControlID="Img_SaveBuyType">
                                </asp:ConfirmButtonExtender>
                                <asp:ModalPopupExtender ID="mdpopup_SaveBuyType" runat="server" 
                                    BackgroundCssClass="modalBackground" CancelControlID="btnNo_SaveBuyType" 
                                    OkControlID="btnYes_SaveBuyType" PopupControlID="pnlPopup_SaveBuyType" 
                                    TargetControlID="Img_SaveBuyType">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup_SaveBuyType" runat="server" style="display:none">
                                    <div class="confirm">
                                        <h1>
                                            Confirm your action</h1>
                                        <p>
                                            Are you sure <strong>Confirm</strong>?</p>
                                        <button ID="btnYes_SaveBuyType" runat="server">
                                            Confirm
                                        </button>
                                        <button ID="btnNo_SaveBuyType" runat="server">
                                            Cancel
                                        </button>
                                    </div>
                                </asp:Panel>
                                &nbsp;<asp:ImageButton ID="Img_CancelBuyType" runat="server" Height="30px" 
                                    ImageUrl="~/Image/cancel.png" onclick="Img_CancelBuyType_Click" />
                            </asp:Panel>
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
                                <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                    <asp:CheckBox ID="Cb_ECE_Y" runat="server" AutoPostBack="True" style="font-size: medium" 
                                        Text="มี" oncheckedchanged="Cb_ECE_Y_CheckedChanged" />
                                    &nbsp;
                                    <asp:CheckBox ID="Cb_ECE_N" runat="server" AutoPostBack="True" style="font-size: medium" 
                                        Text="ไม่มี" oncheckedchanged="Cb_ECE_N_CheckedChanged" />
                                    <asp:Label ID="Txt_StatusCE" runat="server" style="display:none"></asp:Label>
                                    </td>
                                    <td style="padding-left:10px;">
                                        <asp:Panel ID="Panel_EditCE" runat="server">
                                            <asp:ImageButton ID="Img_EditCE" runat="server" Height="25px" 
                                                ImageUrl="~/Image/edit.png" onclick="Img_EditCE_Click" />
                                        </asp:Panel>
                                        <asp:Panel ID="Panel_SaveCE" runat="server" Visible="false">
                                            <asp:ImageButton ID="Img_SaveCE" runat="server" Height="30px" 
                                                ImageUrl="~/Image/save.png" onclick="Img_SaveCE_Click" />
                                            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveCE" 
                                                runat="server" DisplayModalPopupID="mdpopup_SaveCE" Enabled="True" 
                                                TargetControlID="Img_SaveCE">
                                            </asp:ConfirmButtonExtender>
                                            <asp:ModalPopupExtender ID="mdpopup_SaveCE" runat="server" 
                                                BackgroundCssClass="modalBackground" CancelControlID="btnNo_SaveCE" 
                                                OkControlID="btnYes_SaveCE" PopupControlID="pnlPopup_SaveCE" 
                                                TargetControlID="Img_SaveCE">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel ID="pnlPopup_SaveCE" runat="server" style="display:none">
                                                <div class="confirm">
                                                    <h1>
                                                        Confirm your action</h1>
                                                    <p>
                                                        Are you sure <strong>Confirm</strong>?</p>
                                                    <button ID="btnYes_SaveCE" runat="server">
                                                        Confirm
                                                    </button>
                                                    <button ID="btnNo_SaveCE" runat="server">
                                                        Cancel
                                                    </button>
                                                </div>
                                            </asp:Panel>
                                            &nbsp;<asp:ImageButton ID="Img_CancelCE" runat="server" Height="30px" 
                                                ImageUrl="~/Image/cancel.png" onclick="Img_CancelCE_Click" />
                                        </asp:Panel>
                                    </td>
                                    <td style="padding-left:10px;">
                                        <asp:Panel ID="Panel_ConfirmCEErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image11" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmCEErr" runat="server" ForeColor="Red" 
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
                            <tr>
                                <td colspan="4" >
                                    <div style="width:90%; padding-left:50px;">
                                        <hr />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="padding-left:50px; ">
                                    <asp:Label ID="Label63" runat="server" style="font-size: medium" Text="ประเภทตู้ :"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                                    <asp:RadioButton ID="Rb_bodystandard" runat="server" AutoPostBack="True" 
                                    GroupName="Body" oncheckedchanged="Rb_bodystandard_CheckedChanged" 
                                    Text="ตู้มาตราฐาน" Font-Size="Large" Enabled="False" />
                                    &nbsp;
                                    <asp:RadioButton ID="Rb_bodyextra" runat="server" AutoPostBack="True" 
                                        GroupName="Body" oncheckedchanged="Rb_bodyextra_CheckedChanged" 
                                        Text="สั่งทำพิเศษ" Font-Size="Large" Enabled="False" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px; " colspan="4">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td><asp:Label ID="Label55" runat="server" style="font-size: medium" Text="Body :"></asp:Label></td>
                                            <td>
                                                    <asp:Panel ID="Panelbodystandard" runat="server">
                                                    <asp:DropDownList ID="DD_body" runat="server" AutoPostBack="True" onselectedindexchanged="DD_body_SelectedIndexChanged"
                                                        BackColor="White" CssClass="textbox" Visible="True" Width="400px" Enabled="False" ForeColor="Blue">
                                                    </asp:DropDownList>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Panelbodyextra" runat="server">
                                                        <asp:DropDownList ID="ddl_Body_Company" runat="server" CssClass="textbox" Width="150px" Enabled="False"></asp:DropDownList>
                                                        <asp:TextBox ID="txt_bodyextra" runat="server" CssClass="textbox" Width="240px" placeholder="รายละเอียด" Enabled="False"></asp:TextBox>
                                                        <asp:TextBox ID="Txt_bodyextraPrice" runat="server" AutoPostBack="True" CssClass="textbox" Height="25px" Width="100px" placeholder="ราคา" ontextchanged="Txt_bodyextraPrice_TextChanged" Enabled="False">0.00</asp:TextBox>
                                                    </asp:Panel>
                                                
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </td>
                            </tr>
                         <tr>
                        <td style="padding-left:50px;" colspan="4">
                            <asp:Label ID="Label56" runat="server" style="font-size: medium" Text="อุปกรณ์พิเศษ :"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label57" runat="server" Font-Bold="False" Font-Overline="False" 
                                Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="จัดรวมไฟแนนซ์"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="lblsumfin" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" Width="100px"></asp:TextBox>
                            <%--<asp:Label ID="lblsumfin" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt; ">0</asp:Label>--%>
                            <asp:Label ID="Label58" runat="server" Font-Bold="False" Font-Overline="False" 
                                Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="บาท"></asp:Label>
                            &nbsp;<asp:Label ID="Label59" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="ยอดชำระเอง"></asp:Label>
                            <%--<asp:Label ID="Lb_Budgetpaybody" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt">0</asp:Label>--%>
                                <asp:TextBox ID="Lb_Budgetpaybody" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" Width="100px"></asp:TextBox>
                            &nbsp;<asp:Label ID="Label60" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="บาท"></asp:Label>
                            &nbsp;<asp:Label ID="Label61" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="รวม"></asp:Label>
                            <%--<asp:Label ID="Lb_sumAddfinance" runat="server" Font-Bold="False" 
                                Font-Overline="False" Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt">0</asp:Label>--%>
                                <asp:TextBox ID="Lb_sumAddfinance" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" Width="100px"></asp:TextBox>
                            <asp:Label ID="Label62" runat="server" Font-Bold="False" Font-Overline="False" 
                                Font-Size="12pt" Font-Underline="False" ForeColor="Black" 
                                style="font-weight: 700; font-size: 11pt" Text="บาท"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:50px;" colspan="4" align="center">
                            <asp:Panel ID="Panelgvbodystandard" runat="server">

                            <asp:GridView ID="gv_bodyshow" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" onrowdatabound="gv_bodyshow_RowDataBound"
                               ShowFooter="True" Width="80%" DataKeyNames="Body_Option_ID">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ลำดับ">
                                        <ItemTemplate>
                                        <%--<asp:Label ID="Label78" runat="server" 
                                                Text='<%# Eval("OptionIDrun") %>' Visible="False"></asp:Label>--%>
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
                                                Text='<%# Eval("Body_Option_price") %>'></asp:Label>
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
                                            <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" 
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
                                                                                ></asp:Label>
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

                            <asp:ImageButton ID="Image_editbody" runat="server" Height="30px" 
                                    ImageUrl="~/Image/edit.png" onclick="Image_editbody_Click" />
                            <asp:Panel ID="Panelbody" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="50%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image21" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
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
                        </table>
                        <asp:Panel ID="Panel_ECE_Y" runat="server">
                        <table cellpadding="0" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px; " width="160px">
                                <asp:Label ID="Label359" runat="server" style="font-size: medium" 
                                    Text="หมายเลขเครื่อง :"></asp:Label>
                            </td>
                            <td width="210px">
                                <asp:TextBox ID="Txt_ECEMCNumber" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="100px"></asp:TextBox>
                            </td>
                            <td width="160px" >
                                <asp:Label ID="Label361" runat="server" style="font-size: medium" 
                                    Text="หมายเลขตัวถัง :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_ECETruckNumber" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
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
                                    <asp:TextBox ID="Txt_ECEBrand" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label365" runat="server" style="font-size: medium" Text="รุ่น :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_ECEModel" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px;">
                                    <asp:Label ID="Label367" runat="server" style="font-size: medium" Text="สี :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_ECEColor" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label369" runat="server" style="font-size: medium" Text="ปี :"></asp:Label>
                                    <asp:Label ID="Label466" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_ECEYear" runat="server" CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px;">
                                    <asp:Label ID="Label371" runat="server" style="font-size: medium" Text="หมายเลขทะเบียน :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_ECECarPlate" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label377" runat="server" style="font-size: medium" 
                                        Text="ราคารถเก่า :"></asp:Label>
                                    <asp:Label ID="Label378" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_ECEPrice" runat="server" CssClass="textbox" onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:50px;" >
                                    <asp:Label ID="Label379" runat="server" style="font-size: medium" Text="ผู้ประเมินราคา
                                         :"></asp:Label>
                                    <asp:Label ID="Label380" runat="server" ForeColor="Red" 
                                        style="font-size: small" Text="*"></asp:Label>
                                </td>
                                <td colspan="3" >
                                    <asp:TextBox ID="Txt_ECEEmp" runat="server" CssClass="textbox" ForeColor="Blue" onfocus="formInUse = true;" onblur="formInUse = false;"
                                        Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
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
                                    style="font-size: medium" Text="ประกันประเภท 1" 
                                    oncheckedchanged="Cb_Insurance1_CheckedChanged" />
                            </td>
                            <td width="190px">
                                <asp:DropDownList ID="DD_Insurance" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" Width="180px" AutoPostBack="True" 
                                    onselectedindexchanged="DD_Insurance_SelectedIndexChanged">
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
                                <asp:TextBox ID="Txt_InPrice" runat="server" CssClass="textbox" 
                                    onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px" 
                                    AutoPostBack="True" ontextchanged="Txt_InPrice_TextChanged"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="Cb_InFree" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="แถม" oncheckedchanged="Cb_InFree_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:CheckBox ID="Cb_Regis" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="ค่าจดทะเบียน" oncheckedchanged="Cb_Regis_CheckedChanged" />
                            </td>
                            <td >
                                <asp:DropDownList ID="DD_Regis" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" Width="100px" AutoPostBack="True" 
                                    onselectedindexchanged="DD_Regis_SelectedIndexChanged">
                                    <asp:ListItem Value="Pickup">กระบะ</asp:ListItem>
                                    <asp:ListItem Value="Saloon">เก๋ง</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="60px">
                                <asp:Label ID="Label390" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Txt_RegisPrice" runat="server" CssClass="textbox" 
                                    onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px" 
                                    AutoPostBack="True" ontextchanged="Txt_RegisPrice_TextChanged"></asp:TextBox>
                            </td>
                            <td colspan="4">
                                <asp:CheckBox ID="Cb_RegisFree" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="แถม" oncheckedchanged="Cb_RegisFree_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:CheckBox ID="Cb_Act" runat="server" AutoPostBack="True" 
                                                style="font-size: medium" Text="พรบ." 
                                                oncheckedchanged="Cb_Act_CheckedChanged" />
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
                                <asp:TextBox ID="Txt_ActPrice" runat="server" CssClass="textbox" 
                                    onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px" 
                                    AutoPostBack="True" ontextchanged="Txt_ActPrice_TextChanged"></asp:TextBox>
                            </td>
                            <td colspan="4">
                                <asp:CheckBox ID="Cb_ActFree" runat="server" AutoPostBack="True" 
                                     style="font-size: medium" 
                                    Text="แถม" oncheckedchanged="Cb_ActFree_CheckedChanged" />
                            </td>

                        </tr>
                        <tr>
                            <td style="padding-left:50px; " width="140px">
                                <asp:CheckBox ID="Cb_Transpot" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="ค่าขนส่ง" oncheckedchanged="Cb_Transpot_CheckedChanged" />
                            </td>
                            <td >
                                &nbsp;</td>
                            <td width="60px">
                                <asp:Label ID="Label392" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td width="110px">
                                <asp:TextBox ID="Txt_TranspotPrice" runat="server" CssClass="textbox" 
                                    onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px" 
                                    AutoPostBack="True" ontextchanged="Txt_TranspotPrice_TextChanged"></asp:TextBox>
                            </td>
                            <td colspan="4">
                                <asp:CheckBox ID="Cb_TranspotFree" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="แถม" oncheckedchanged="Cb_TranspotFree_CheckedChanged" />
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
                                <asp:CheckBox ID="Cb_SetAcc" runat="server" AutoPostBack="True" 
                                     style="font-size: medium" 
                                    Text="ชุดอุปกรณ์ตกแต่ง" oncheckedchanged="Cb_SetAcc_CheckedChanged" />
                            </td>
                            <td align="left" width="50px">
                                <asp:Label ID="Label394" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td align="left" width="110px">
                                
                                &nbsp;<asp:TextBox ID="Txt_SetAccPrice" runat="server" CssClass="textbox" 
                                    onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px" 
                                    AutoPostBack="True" ontextchanged="Txt_SetAccPrice_TextChanged"></asp:TextBox>
                            </td>
                            <td >
                                <asp:CheckBox ID="Cb_SetAccFree" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="แถม" oncheckedchanged="Cb_SetAccFree_CheckedChanged" />
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
                                            <asp:Image ID="Image12" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
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
                                    Text="อุปกรณ์มาตรฐาน STD" oncheckedchanged="Cb_AccSTD_CheckedChanged" />
                            </td>
                            <td align="left" width="50px">
                                <asp:Label ID="Label30" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td align="left" width="110px">
                                
                                &nbsp;<asp:TextBox ID="Txt_AccSTDPrice" runat="server" CssClass="textbox" 
                                    onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="100px" 
                                    AutoPostBack="True" ontextchanged="Txt_AccSTDPrice_TextChanged"></asp:TextBox>
                            </td>
                            <td >
                                <asp:CheckBox ID="Cb_AccSTDFree" runat="server" AutoPostBack="True" style="font-size: medium" 
                                    Text="แถม" oncheckedchanged="Cb_AccSTDFree_CheckedChanged" />
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
                                            <asp:Image ID="Image13" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
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
                                        <asp:TextBox ID="Txt_AdAccName" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;"
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
                                            <asp:Image ID="Image14" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
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
                            PageSize="15" ShowFooter="True" 
                            onrowdatabound="gv_Discount_RowDataBound">
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
                                            onclick="Img_DcAdd_Click" Width="25px" />
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
                                            <asp:Image ID="Image15" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
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
                    <div style="width:90%; padding-left:50px; padding-top:5px;">
                                        <hr />
                        </div>
                    <div Align="center" style="padding:10px;">
                    <asp:Panel ID="Panel_EditAccPsumPrice" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                    <table>
                    <tr>
                        <td align="left" style="width: 270px; height:60px;">
                            <asp:Label ID="Label440" runat="server" Font-Underline="true" Font-Bold="true"
                                    style="font-size: medium" Text="รวมยอดเงินค่ารถ"></asp:Label>
                            <asp:Label ID="Lb_OldPriceSumCar" runat="server" Font-Bold="true" Font-Underline="true" 
                                style="font-size: medium; display:none" ></asp:Label>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-left:20px;">
                                        &nbsp;</td>
                                    <td style="padding-left:10px;">
                                        <asp:TextBox ID="Txt_EditAcc_PriceSumCar" runat="server" AutoPostBack="True" Font-Bold="true"
                                            CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                            onkeyup="this.value=Comma(this.value);" Width="100px" Disabled></asp:TextBox>
                                    </td>
                                    <td style="padding-left:5px;">
                                        <asp:Label ID="Label441" runat="server" style="font-size: medium;" Font-Bold="true"  Text="บาท"></asp:Label>
                                    </td>
                                </tr>
                                </table>
                        </td>
                        <tr>
                        <td align="left">
                            <asp:Label ID="Label70" runat="server" Font-Bold="true" Font-Underline="true" 
                                style="font-size: medium" Text="รวมยอดเงินที่ลูกค้าจะต้องชำระ"></asp:Label>
                        </td>
                        <td>
                                <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="Img_EditAcc_CalSum" runat="server" 
                                        ImageUrl="~/Image/calculator.png"  Width="25px" 
                                            onclick="Img_EditAcc_CalSum_Click" />
                                    </td>
                                    <td style="padding-left:10px;">
                                        <asp:TextBox ID="Txt_EditAcc_PriceSum" runat="server" AutoPostBack="True" Font-Bold="true"
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
                    </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel_ConfirmAccErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image16" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmAccErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                    <asp:Panel ID="Panel_EditAcc" runat="server">
                                <asp:ImageButton ID="Img_EditAcc" runat="server" Height="40px" 
                                    ImageUrl="~/Image/edit.png" onclick="Img_EditAcc_Click" />
                            </asp:Panel>
                            <asp:Panel ID="Panel_SaveAcc" runat="server" Visible="false">
                                <asp:ImageButton ID="Img_SaveAcc" runat="server" Height="40px" 
                                    ImageUrl="~/Image/save.png" onclick="Img_SaveAcc_Click" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveAcc" 
                                    runat="server" DisplayModalPopupID="mdpopup_SaveAcc" Enabled="True" 
                                    TargetControlID="Img_SaveAcc">
                                </asp:ConfirmButtonExtender>
                                <asp:ModalPopupExtender ID="mdpopup_SaveAcc" runat="server" 
                                    BackgroundCssClass="modalBackground" CancelControlID="btnNo_SaveAcc" 
                                    OkControlID="btnYes_SaveAcc" PopupControlID="pnlPopup_SaveAcc" 
                                    TargetControlID="Img_SaveAcc">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup_SaveAcc" runat="server" style="display:none">
                                    <div class="confirm">
                                        <h1>
                                            Confirm your action</h1>
                                        <p>
                                            Are you sure <strong>Confirm</strong>?</p>
                                        <button ID="btnYes_SaveAcc" runat="server">
                                            Confirm
                                        </button>
                                        <button ID="btnNo_SaveAcc" runat="server">
                                            Cancel
                                        </button>
                                    </div>
                                </asp:Panel>
                                &nbsp;<asp:ImageButton ID="Img_CancelAcc" runat="server" Height="40px" 
                                    ImageUrl="~/Image/cancel.png" onclick="Img_CancelAcc_Click" />
                            </asp:Panel>
                    </div>
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
                                ForeColor="Blue" Width="100px" AutoPostBack="True" 
                                onselectedindexchanged="DD_Finance_SelectedIndexChanged">
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
                                <asp:TextBox ID="Txt_CarPriceAd" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ForeColor="Blue" Width="150px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label449" runat="server" style="font-size: medium" Text="ราคา :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_CarPriceAd_Price" runat="server" AutoPostBack="True" 
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" ontextchanged="Txt_CarPriceDetail_Price_TextChanged" 
                                    Width="100px"></asp:TextBox>
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
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" 
                                    onkeyup="this.value=Comma(this.value);" 
                                    ontextchanged="Txt_PayDown_TextChanged" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    Width="100px" ></asp:TextBox>
                            </td>
                            <td width="160px" class="style6">
                                <asp:Label ID="Label457" runat="server" style="font-size: medium" 
                                    Text="ยอดจัด(1) :"></asp:Label>
                                <asp:Label ID="Label458" runat="server" ForeColor="Red" 
                                    style="font-size: small" Text="*"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="Txt_DPeak" runat="server" CssClass="textbox" Disabled="" 
                                    ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
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
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" 
                                    onkeyup="this.value=Comma(this.value);" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    ontextchanged="Txt_LoanProtection_TextChanged" Width="100px" ></asp:TextBox>
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
                                    Width="100px" AutoPostBack="True" ontextchanged="Txt_Interest_TextChanged"></asp:TextBox>
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
                                    ForeColor="Blue" Width="130px" AutoPostBack="True" 
                                    onselectedindexchanged="DD_Total_Payment_SelectedIndexChanged">
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
                                    Text="ชำระค่างวดล่วงหน้า" AutoPostBack="True" 
                                        oncheckedchanged="Cb_Begin_CheckedChanged" />
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
                                    <asp:TextBox ID="Txt_DepositDate" runat="server" AutoPostBack="True" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    CssClass="textbox" ForeColor="Blue" ontextchanged="Txt_DepositDate_TextChanged" 
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
                                    Width="100px" AutoPostBack="True" ontextchanged="Txt_DepositPrice_TextChanged"></asp:TextBox>
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
                                    <asp:TextBox ID="Txt_DepositAdPrice" runat="server" AutoPostBack="True"
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" ontextchanged="Txt_DepositAdPrice_TextChanged"
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
                                    <asp:TextBox ID="Txt_RedCarPlate_Date" runat="server" AutoPostBack="True" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    CssClass="textbox" ForeColor="Blue" ontextchanged="Txt_RedCarPlate_Date_TextChanged" 
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
                                    Width="100px" AutoPostBack="True" 
                                        ontextchanged="Txt_RedCarPlate_Price_TextChanged"></asp:TextBox>
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
                            <td  width="160px">
                                
                            </td>
                            <td  width="60px">
                                
                            </td>
                            <td  width="135px">
                                
                            </td>
                            <td  width="95px">
                                
                            </td>
                            <td width="110px">
                                
                            </td>
                            <td width="70px" style="width: 170px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left:100px; width: 330px; height:60px;" >
                                <asp:Label ID="Label44_p" runat="server" Font-Underline="true" Font-Bold="true"
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
                                            onkeyup="this.value=Comma(this.value);" Width="100px" ></asp:TextBox>
                                    </td>
                                    <td style="padding-left:5px;">
                                        <asp:Label ID="Label441_b" runat="server" style="font-size: medium;" Font-Bold="true"  Text="บาท"></asp:Label>
                                    </td>
                                </tr>
                                </table>
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left:100px; width: 330px; " >
                                <asp:Label ID="Label70_calsum" runat="server" Font-Underline="true" Font-Bold="true"
                                    style="font-size: medium" Text="รวมยอดเงินที่ลูกค้าจะต้องชำระ"></asp:Label>
                            </td>
                            <td colspan="5">
                                <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" style=" width:45px;">
                                        <asp:ImageButton ID="Img_CalSum" runat="server" 
                                        ImageUrl="~/Image/calculator.png" onclick="Img_CalSum_Click" Width="25px" />
                                    </td>
                                    <td style="padding-left:10px;">
                                        <asp:TextBox ID="Txt_PriceSum" runat="server" AutoPostBack="True" Font-Bold="true"
                                            CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                            onkeyup="this.value=Comma(this.value);" Width="100px" Disabled></asp:TextBox>
                                    </td>
                                    <td style="padding-left:5px;">
                                        <asp:Label ID="Label72_pri" runat="server" style="font-size: medium;" Font-Bold="true"  Text="บาท"></asp:Label>
                                    </td>
                                </tr>
                                </table>
                                
                            </td>
                        </tr>
                    </table>
                    <div Align="center" style="padding:10px;">
                    <asp:Panel ID="Panel_ConfirmFinanceErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image17" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmFinanceErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                    <asp:Panel ID="Panel_EditFinance" runat="server">
                                <asp:ImageButton ID="Img_EditFinance" runat="server" Height="30px" 
                                    ImageUrl="~/Image/edit.png" onclick="Img_EditFinance_Click" />
                            </asp:Panel>
                            <asp:Panel ID="Panel_SaveFinance" runat="server" Visible="false">
                                <asp:ImageButton ID="Img_SaveFinance" runat="server" Height="30px" 
                                    ImageUrl="~/Image/save.png" onclick="Img_SaveFinance_Click" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveFinance" 
                                    runat="server" DisplayModalPopupID="mdpopup_SaveFinance" Enabled="True" 
                                    TargetControlID="Img_SaveFinance">
                                </asp:ConfirmButtonExtender>
                                <asp:ModalPopupExtender ID="mdpopup_SaveFinance" runat="server" 
                                    BackgroundCssClass="modalBackground" CancelControlID="btnNo_SaveFinance" 
                                    OkControlID="btnYes_SaveFinance" PopupControlID="pnlPopup_SaveFinance" 
                                    TargetControlID="Img_SaveFinance">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup_SaveFinance" runat="server" style="display:none">
                                    <div class="confirm">
                                        <h1>
                                            Confirm your action</h1>
                                        <p>
                                            Are you sure <strong>Confirm</strong>?</p>
                                        <button ID="btnYes_SaveFinance" runat="server">
                                            Confirm
                                        </button>
                                        <button ID="btnNo_SaveFinance" runat="server">
                                            Cancel
                                        </button>
                                    </div>
                                </asp:Panel>
                                &nbsp;<asp:ImageButton ID="Img_CancelFinance" runat="server" Height="30px" 
                                    ImageUrl="~/Image/cancel.png" onclick="Img_CancelFinance_Click" />
                            </asp:Panel>
                    </div>
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
                        <td style="padding-left:50px; height:30px; " Align="left" colspan="8">
                            <asp:Label ID="Label34" runat="server" Font-Underline="true" 
                                style="font-size: medium" Text="รายการลูกค้าชำระเงิน"></asp:Label>
                        </td>
                    </tr>
                        <tr>
                            <td style="padding-left:70px; height:30px;" width="80px">
                                <asp:Label ID="Label35" runat="server" style="font-size: medium" Text="เงินสด"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td style="padding-left:5px">
                                <asp:Label ID="Label468" runat="server" style="font-size: medium" 
                                    Text="เลขที่ใบเสร็จ :"></asp:Label>
                            </td>
                            <td style="padding-left:5px">
                                <asp:TextBox ID="Txt_PayCash_No" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" onblur="formInUse = false;" onfocus="formInUse = true;" 
                                    Width="140px"></asp:TextBox>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:Label ID="Label38" runat="server" style="font-size: medium" Text="วันที่ :"></asp:Label>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:TextBox ID="Txt_PayCash_Date" runat="server" AutoPostBack="True" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    CssClass="textbox" ForeColor="Blue" ontextchanged="Txt_PayCash_Date_TextChanged" 
                                    Width="100px"></asp:TextBox>
                                <asp:ImageButton ID="Img_PayCash_Date" runat="server" ImageAlign="Bottom" 
                                    ImageUrl="~/Image/Calendar.png" width="20px" />
                                <asp:CalendarExtender ID="CalendarExtender_PayCash_Date" runat="server" 
                                    Format="dd MMM yy" PopupButtonID="Img_PayCash_Date" 
                                    TargetControlID="Txt_PayCash_Date">
                                </asp:CalendarExtender>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:Label ID="Label49" runat="server" style="font-size: medium" Text="จำนวนเงิน : "></asp:Label>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:TextBox ID="Txt_PayCash_Price" runat="server" 
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" 
                                    Width="100px" AutoPostBack="True" ontextchanged="Txt_PayCash_Price_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:70px; height:30px;" >
                                <asp:Label ID="Label36" runat="server" style="font-size: medium" Text="เงินโอนธนาคาร"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DD_PayTM_Bank" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" Width="120px">
                                </asp:DropDownList>
                            </td>
                            <td style="padding-left:5px">
                                <asp:Label ID="Label469" runat="server" style="font-size: medium" 
                                    Text="เลขที่ใบเสร็จ :"></asp:Label>
                            </td>
                            <td style="padding-left:5px">
                                <asp:TextBox ID="Txt_PayTM_No" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" onblur="formInUse = false;" onfocus="formInUse = true;" 
                                    Width="140px"></asp:TextBox>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:Label ID="Label47" runat="server" style="font-size: medium" Text="วันที่ :"></asp:Label>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:TextBox ID="Txt_PayTM_Date" runat="server" AutoPostBack="True" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    CssClass="textbox" ForeColor="Blue" ontextchanged="Txt_PayTM_Date_TextChanged" 
                                    Width="100px"></asp:TextBox>
                                <asp:ImageButton ID="Img_PayTM_Date" runat="server" ImageAlign="Bottom" 
                                    ImageUrl="~/Image/Calendar.png" width="20px" />
                                <asp:CalendarExtender ID="CalendarExtender_PayTM_Date" runat="server" 
                                    Format="dd MMM yy" PopupButtonID="Img_PayTM_Date" 
                                    TargetControlID="Txt_PayTM_Date">
                                </asp:CalendarExtender>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:Label ID="Label50" runat="server" style="font-size: medium" Text="จำนวนเงิน : "></asp:Label>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:TextBox ID="Txt_PayTM_Price" runat="server" 
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" 
                                    Width="100px" AutoPostBack="True" ontextchanged="Txt_PayTM_Price_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:70px; height:30px;">
                                <asp:Label ID="Label37" runat="server" style="font-size: medium" Text="เช็คธนาคาร"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DD_PayCheque_Bank" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" Width="120px">
                                </asp:DropDownList>
                            </td>
                            <td style="padding-left:5px">
                                <asp:Label ID="Label470" runat="server" style="font-size: medium" 
                                    Text="เลขที่ใบเสร็จ :"></asp:Label>
                            </td>
                            <td style="padding-left:5px">
                                <asp:TextBox ID="Txt_PayCheque_No" runat="server" CssClass="textbox" 
                                    ForeColor="Blue" onblur="formInUse = false;" onfocus="formInUse = true;" 
                                    Width="140px"></asp:TextBox>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:Label ID="Label48" runat="server" style="font-size: medium" Text="วันที่ :"></asp:Label>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:TextBox ID="Txt_PayCheque_Date" runat="server" AutoPostBack="True" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    CssClass="textbox" ForeColor="Blue" ontextchanged="Txt_PayCheque_Date_TextChanged" 
                                    Width="100px"></asp:TextBox>
                                <asp:ImageButton ID="Img_PayCheque_Date" runat="server" ImageAlign="Bottom" 
                                    ImageUrl="~/Image/Calendar.png" width="20px" />
                                <asp:CalendarExtender ID="CalendarExtender_PayCheque_Date" runat="server" 
                                    Format="dd MMM yy" PopupButtonID="Img_PayCheque_Date" 
                                    TargetControlID="Txt_PayCheque_Date">
                                </asp:CalendarExtender>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:Label ID="Label51" runat="server" style="font-size: medium" Text="จำนวนเงิน : "></asp:Label>
                            </td>
                            <td style="padding-left:5px;">
                                <asp:TextBox ID="Txt_PayCheque_Price" runat="server" 
                                    CssClass="textbox" ForeColor="Blue" onkeypress="return isNumberKey(event)" onfocus="formInUse = true;" onblur="formInUse = false;"
                                    onkeyup="this.value=Comma(this.value);" 
                                    Width="100px" AutoPostBack="True" ontextchanged="Txt_PayCheque_Price_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="padding-left:170px; height:60px;">
                                <asp:Label ID="Label44_p0" runat="server" Font-Bold="true" 
                                    Font-Underline="true" style="font-size: medium" Text="ยอดเงินที่ต้องชำระคืนลูกค้า"></asp:Label>
                            </td>
                            <td style="padding-left:5px" colspan="5">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-left:40px;">
                                            &nbsp;</td>
                                        <td style="padding-left:10px;">
                                            <asp:TextBox ID="Txt_RepayToCus" runat="server" AutoPostBack="True" 
                                                CssClass="textbox" Disabled="" Font-Bold="true" ForeColor="Blue" 
                                                onblur="formInUse = false;" onfocus="formInUse = true;" 
                                                onkeypress="return isNumberKey(event)" onkeyup="this.value=Comma(this.value);" 
                                                Width="100px"></asp:TextBox>
                                        </td>
                                        <td style="padding-left:5px;">
                                            <asp:Label ID="Label441_b0" runat="server" Font-Bold="true" 
                                                style="font-size: medium;" Text="บาท"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div Align="center" style="padding:10px;">
                    <asp:Panel ID="Panel_confirmPayCusErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image20" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmPayCusErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                    <asp:Panel ID="Panel_EditPayCus" runat="server">
                                <asp:ImageButton ID="Img_EditPayCus" runat="server" Height="30px" 
                                    ImageUrl="~/Image/edit.png" onclick="Img_EditPayCus_Click" />
                            </asp:Panel>
                            <asp:Panel ID="Panel_SavePayCus" runat="server" Visible="false">
                                <asp:ImageButton ID="Img_SavePayCus" runat="server" Height="30px" 
                                    ImageUrl="~/Image/save.png" onclick="Img_SavePayCus_Click" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SavePayCus" 
                                    runat="server" DisplayModalPopupID="mdpopup_SavePayCus" Enabled="True" 
                                    TargetControlID="Img_SavePayCus">
                                </asp:ConfirmButtonExtender>
                                <asp:ModalPopupExtender ID="mdpopup_SavePayCus" runat="server" 
                                    BackgroundCssClass="modalBackground" CancelControlID="btnNo_SavePayCus" 
                                    OkControlID="btnYes_SavePayCus" PopupControlID="pnlPopup_SavePayCus" 
                                    TargetControlID="Img_SavePayCus">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup_SavePayCus" runat="server" style="display:none">
                                    <div class="confirm">
                                        <h1>
                                            Confirm your action</h1>
                                        <p>
                                            Are you sure <strong>Confirm</strong>?</p>
                                        <button ID="btnYes_SavePayCus" runat="server">
                                            Confirm
                                        </button>
                                        <button ID="btnNo_SavePayCus" runat="server">
                                            Cancel
                                        </button>
                                    </div>
                                </asp:Panel>
                                &nbsp;<asp:ImageButton ID="Img_CancelPayCus" runat="server" Height="30px" 
                                    ImageUrl="~/Image/cancel.png" onclick="Img_CancelPayCus_Click" />
                            </asp:Panel>
                    </div>
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
                    <div Align="center" style="padding:10px;">
                    <asp:Panel ID="Panel_confirmRemarkErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image18" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmRemarkErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                    <asp:Panel ID="Panel_EditRemark" runat="server">
                                <asp:ImageButton ID="Img_EditRemark" runat="server" Height="30px" 
                                    ImageUrl="~/Image/edit.png" onclick="Img_EditRemark_Click" />
                            </asp:Panel>
                            <asp:Panel ID="Panel_SaveRemark" runat="server" Visible="false">
                                <asp:ImageButton ID="Img_SaveRemark" runat="server" Height="30px" 
                                    ImageUrl="~/Image/save.png" onclick="Img_SaveRemark_Click" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveRemark" 
                                    runat="server" DisplayModalPopupID="mdpopup_SaveRemark" Enabled="True" 
                                    TargetControlID="Img_SaveRemark">
                                </asp:ConfirmButtonExtender>
                                <asp:ModalPopupExtender ID="mdpopup_SaveRemark" runat="server" 
                                    BackgroundCssClass="modalBackground" CancelControlID="btnNo_SaveRemark" 
                                    OkControlID="btnYes_SaveRemark" PopupControlID="pnlPopup_SaveRemark" 
                                    TargetControlID="Img_SaveRemark">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup_SaveRemark" runat="server" style="display:none">
                                    <div class="confirm">
                                        <h1>
                                            Confirm your action</h1>
                                        <p>
                                            Are you sure <strong>Confirm</strong>?</p>
                                        <button ID="btnYes_SaveRemark" runat="server">
                                            Confirm
                                        </button>
                                        <button ID="btnNo_SaveRemark" runat="server">
                                            Cancel
                                        </button>
                                    </div>
                                </asp:Panel>
                                &nbsp;<asp:ImageButton ID="Img_CancelRemark" runat="server" Height="30px" 
                                    ImageUrl="~/Image/cancel.png" onclick="Img_CancelRemark_Click" />
                            </asp:Panel>
                    </div>
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
                    <div Align="center" style="padding:10px;">
                    <asp:Panel ID="Panel_ConfirmCErr" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="60%" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px; width:30px;">
                                            <asp:Image ID="Image19" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_ConfirmCErr" runat="server" ForeColor="Red" 
                                                Font-Bold="True"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                    <asp:Panel ID="Panel_EditC" runat="server">
                                <asp:ImageButton ID="Img_EditC" runat="server" Height="30px" 
                                    ImageUrl="~/Image/edit.png" onclick="Img_EditC_Click" />
                            </asp:Panel>
                            <asp:Panel ID="Panel_SaveC" runat="server" Visible="false">
                                <asp:ImageButton ID="Img_SaveC" runat="server" Height="30px" 
                                    ImageUrl="~/Image/save.png" onclick="Img_SaveC_Click" />
                                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender_SaveC" 
                                    runat="server" DisplayModalPopupID="mdpopup_SaveC" Enabled="True" 
                                    TargetControlID="Img_SaveC">
                                </asp:ConfirmButtonExtender>
                                <asp:ModalPopupExtender ID="mdpopup_SaveC" runat="server" 
                                    BackgroundCssClass="modalBackground" CancelControlID="btnNo_SaveC" 
                                    OkControlID="btnYes_SaveC" PopupControlID="pnlPopup_SaveC" 
                                    TargetControlID="Img_SaveC">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup_SaveC" runat="server" style="display:none">
                                    <div class="confirm">
                                        <h1>
                                            Confirm your action</h1>
                                        <p>
                                            Are you sure <strong>Confirm</strong>?</p>
                                        <button ID="btnYes_SaveC" runat="server">
                                            Confirm
                                        </button>
                                        <button ID="btnNo_SaveC" runat="server">
                                            Cancel
                                        </button>
                                    </div>
                                </asp:Panel>
                                &nbsp;<asp:ImageButton ID="Img_CancelC" runat="server" Height="30px" 
                                    ImageUrl="~/Image/cancel.png" onclick="Img_CancelC_Click" />
                            </asp:Panel>
                    </div>
                    </td>
                </tr>
                </table>
                </asp:Panel>
                </ContentTemplate>
                </asp:UpdatePanel>

            </td>
        </tr>
        </table>
        </div>
        </asp:Panel>
                        </td>
                    </tr>
                    
                </table>
                   
            </div>
            </asp:Panel>
            </ContentTemplate>
                </asp:UpdatePanel>
             


            <asp:Button ID="btn_EAddress" runat="server" style="display:none" Text="Button" />
            <asp:ModalPopupExtender ID="ModalPopupExtender_EAddress" runat="server" 
                BackgroundCssClass="modalBackground" PopupControlID="Panel_PopupEAddress" 
                     TargetControlID="btn_EAddress" >
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel_PopupEAddress" runat="server" Width="800px" style="display:none">
            <div align="center" class="modalPopupDetail" style="padding-bottom:10px; ">                   
                <table cellpadding="0" cellspacing="0" width="100%" style="padding-top:5px; padding-left:5px; padding-right:5px;  ">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%" style="height:40px; background:#6189df; ">
                                <tr>
                                    <td style="width:30px; padding-left:10px; padding-right:10px;">
                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/Image/LOGO ISUZU1.png" Width="20px" />
                                    </td>
                                    <td align="left" >
                                        <asp:Label ID="Lb_NameAddress" runat="server" Font-Bold="True" Font-Size="Medium" 
                                            ForeColor="White" Text="แก้ไขที่อยู่"></asp:Label>
                                        </td>
                                        <td style="width:30px;">
                                            <asp:ImageButton ID="Img_CloseEAddress" runat="server" Height="20px" 
                                                ImageUrl="~/Image/close.png" Width="20px" 
                                                onclick="Img_CloseEAddress_Click" />
                                    </td>
                                </tr>
                            </table>
                            <div align="left" style="width:100%; padding-top:10px; padding-bottom:10px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;">
        <div style="padding-left:50px;">
            <asp:Label ID="Label31" runat="server" Text="* ข้อมูลที่จำเป็นต้องกรอก" ForeColor="Red" Font-Size="Small"></asp:Label>
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
                                    <asp:TextBox ID="Txt_EAdd_Address" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;" 
                                        ForeColor="Blue"  Width="70px"></asp:TextBox>
                                </td>
                                <td style="width:100px;">
                                    <asp:Label ID="Label325" runat="server" style="font-size: medium" 
                                        Text="หมู่ที่ :"></asp:Label>   
                                </td>
                                <td style="width:150px;">
                                    <asp:TextBox ID="Txt_EAdd_Moo" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;" 
                                        ForeColor="Blue" onkeypress="return isNumberKey(event)" Width="70px"></asp:TextBox>
                                </td>
                                <td style="width:100px;">
                                    <asp:Label ID="Label326" runat="server" style="font-size: medium" 
                                        Text="หมู่บ้าน :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txt_EAdd_HomeName" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;" 
                                        ForeColor="Blue" Width="120px"></asp:TextBox>
                                </td>
                            </tr>
                                <tr>
                                    <td style="padding-left:30px; width:110px;">
                                        <asp:Label ID="Label328" runat="server" style="font-size: medium" 
                                            Text="ถนน :"></asp:Label>
                                    </td>
                                    <td style="width:150px;">
                                        <asp:TextBox ID="Txt_EAdd_Road" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;" 
                                            ForeColor="Blue" Width="140px"></asp:TextBox>
                                    </td>
                                    <td style="width:100px;">
                                        <asp:Label ID="Label329" runat="server" style="font-size: medium" Text="ซอย :"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="Txt_EAdd_Soi" runat="server" CssClass="textbox"  onfocus="formInUse = true;" onblur="formInUse = false;" 
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
                                        <asp:DropDownList ID="DD_EAdd_Province" runat="server" CssClass="textbox" 
                                            ForeColor="Blue" Width="140px" AutoPostBack="True" 
                                            onselectedindexchanged="DD_EAdd_Province_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:100px;">
                                        <asp:Label ID="Label332" runat="server" style="font-size: medium" 
                                            Text="อำเเภอ :"></asp:Label>
                                        <asp:Label ID="Label333" runat="server" ForeColor="Red" 
                                            style="font-size: small" Text="*"></asp:Label>
                                    </td>
                                    <td style="width:150px;">
                                        <asp:DropDownList ID="DD_EAdd_Amphur" runat="server" CssClass="textbox" 
                                            ForeColor="Blue" Width="140px" AutoPostBack="True" 
                                            onselectedindexchanged="DD_EAdd_Amphur_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:100px;">
                                        <asp:Label ID="Label334" runat="server" style="font-size: medium" 
                                            Text="ตำบล :"></asp:Label>
                                        <asp:Label ID="Label335" runat="server" ForeColor="Red" 
                                            style="font-size: small" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DD_EAdd_District" runat="server" CssClass="textbox" 
                                            ForeColor="Blue" Width="140px" AutoPostBack="True" 
                                            onselectedindexchanged="DD_EAdd_District_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left:30px; width:110px;">
                                        <asp:Label ID="Label336" runat="server" style="font-size: medium" 
                                            Text="รหัสไปรษณีย์ :"></asp:Label>
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="Txt_EAdd_Postel" runat="server" CssClass="textbox" onfocus="formInUse = true;" onblur="formInUse = false;" 
                                            ForeColor="Blue" onkeypress="return enforcechar(this,5,event)" Width="70px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel_EAddAddress_Err" runat="server" Visible="false" style="padding-top:5px; padding-bottom:5px;">
                            <center>
                                <table width="400px" style="height:40px; background-image: url('../Image/bg_Alert.png'); border-style: solid; border-width: 1px; border-color: red; border-radius: 5px;" >
                                    <tr>
                                        <td style="padding-left:20px;">
                                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Image/warning.png" Width="15px" />
                                        </td>
                                        <td Align="left">
                                            <asp:Label ID="Lb_EAddAddress_Err" runat="server" ForeColor="Red" Font-Bold="true" ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </asp:Panel>
                            <div Align="center" style="padding-top:10px;">
                            <asp:Button ID="Btn_SaveEAddAddress" runat="server" CssClass="css_button" 
                                            Text="บันทึก" onclick="Btn_SaveEAddAddress_Click" />
                                        &nbsp;
                                        <asp:Button ID="Btn_CancelAddAddress" runat="server" CssClass="css_button" 
                                            Text="ยกเลิก" />
                            </div>
                        </td>
                    </tr>
                </table>
                   
            </div>
            </asp:Panel>  
            
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
