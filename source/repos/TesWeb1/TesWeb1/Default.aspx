<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TesWeb1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div class="container" style="font-family : 'Kanit';">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-xs-12" style="padding : 20px;">
                            <div class="panel panel-primary">
                                <div class="panel-heading">Add Product</div>
                                <div class="panel-body">
                                    <div class="col-sm-8 col-md-8 col-xs-12">
                                        <div class="form-group" style="padding : 20px;">
                                            <asp:Label runat="server" Text="Customer Name : "
                                                CssClass="control-label col-sm-2">
                                            </asp:Label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="DropDownList3" runat="server"
                                                    CssClass="form-control" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div style="padding : 20px;">
                                            <div class="form-group">
                                                <asp:Label runat="server" Text="Order QTY : "
                                                    CssClass="control-label col-sm-2">
                                                </asp:Label>
                                                <div class="col-sm-8">
                                                    <asp:TextBox ID="qty_TextBox" runat="server" TextMode="Number"
                                                        CssClass="form-control" placeholder="QTY"></asp:TextBox>
                                                    <%--                                                    <asp:DropDownList ID="DropDownList2" runat="server"
                                                        CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                    </asp:DropDownList>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="padding : 20px;">
                                            <div class="form-group">
                                                <asp:Label runat="server" Text="Select BY : "
                                                    CssClass="control-label col-sm-2">
                                                </asp:Label>
                                                <div class="col-sm-8">
                                                    <asp:DropDownList ID="DropDownList2" runat="server"
                                                        CssClass="form-control" AutoPostBack="true"
                                                        OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Panel ID="Panel4" runat="server">
                                            <div style="padding : 20px;">
                                                <div class="form-group">
                                                    <asp:Label runat="server" Text="Product Name1 : "
                                                        CssClass="control-label col-sm-2">
                                                    </asp:Label>
                                                    <div class="col-sm-8">
                                                        <asp:DropDownList ID="DropDownList1" runat="server"
                                                            CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                         <asp:Panel ID="Panel5" runat="server">
                                            <div style="padding : 20px;">
                                                <div class="form-group">
                                                    <div class="col-sm-8">
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>


                                    </div>
                                    <div class="col-sm-4 col-md-4" style="margin-top:20px;">
                                        <div class="container" style="font-family : 'Kanit';">
                                            <div class="row">
                                                <asp:Label ID="Label1" runat="server" Text="Name : "
                                                    CssClass="control-label col-sm-1">
                                                </asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text=""
                                                    CssClass="control-label col-sm-3">
                                                </asp:Label>
                                            </div>
                                            <div class="row">
                                                <asp:Label ID="Label3" runat="server" Text="Qty
                                        : " CssClass="control-label col-sm-1"></asp:Label>
                                                <asp:Label ID="Label4" runat="server" Text=""
                                                    CssClass="control-label col-sm-3">
                                                </asp:Label>
                                            </div>
                                            <div class="row">
                                                <asp:Label ID="Label8" runat="server" Text="Discount : "
                                                    CssClass="control-label col-sm-1">
                                                </asp:Label>
                                                <asp:Label ID="Label9" runat="server" Text=""
                                                    CssClass="control-label col-sm-3">
                                                </asp:Label>
                                            </div>
                                            <div class="row">
                                                <asp:Label ID="Label5" runat="server" Text="Price : "
                                                    CssClass="control-label col-sm-1">
                                                </asp:Label>
                                                <asp:Label ID="Label6" runat="server" Text=""
                                                    CssClass="control-label col-sm-3">
                                                </asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div style="padding : 20px; text-align : center;">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-5">
                                <asp:Button ID="addOrder" runat="server" CssClass="btn btn-success btn-block"
                                    Text="Submit" onClick="addOrder_Click" />
                            </div>
                            <div class="col-sm-5">
                                <asp:Button ID="cancelOrder" runat="server" CssClass="btn btn-danger btn-block"
                                    Text="Cancel" />
                            </div>
                            <div class="col-sm-1"></div>

                        </div>

                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel2" runat="server">
                                <div class="row">
                                    <div class="column"
                                        style="padding-top : 20px;padding : 20px; font-family :'Kanit';">
                                        <asp:GridView ID="GridView_Order" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-hover" BorderWidth="0px" GridLines="None">
                                            <Columns>
                                                <asp:BoundField DataField="OrderID" HeaderText="OrderID" />
                                                <asp:TemplateField HeaderText="ProductName">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="orderProductName_TextBox" runat="server"
                                                            Text='<%# Bind("ProductName") %>' CssClass="form-control">
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server"
                                                            Text='<%# Bind("ProductName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ProductPrice">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="orderProductPrice_TextBox" runat="server"
                                                            Text='<%# Bind("ProductPrice") %>' CssClass="form-control">
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server"
                                                            Text='<%# Bind("ProductPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="FirstName">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="orderFirstName_TextBox" runat="server"
                                                            Text='<%# Bind("FirstName") %>' CssClass="form-control">
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server"
                                                            Text='<%# Bind("FirstName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LastName">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="orderLastName_TextBox" runat="server"
                                                            Text='<%# Bind("LastName") %>' CssClass="form-control">
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server"
                                                            Text='<%# Bind("LastName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="OrderQty">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="orderQty_TextBox" runat="server"
                                                            Text='<%# Bind("OrderQty") %>' CssClass="form-control">
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server"
                                                            Text='<%# Bind("OrderQty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="OrderPrice">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="orderPrice_TextBox" runat="server"
                                                            Text='<%# Bind("OrderPrice") %>' CssClass="form-control">
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server"
                                                            Text='<%# Bind("OrderPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="OrderTime">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="orderTime_TextBox" runat="server"
                                                            Text='<%# Bind("OrderTime") %>' CssClass="form-control">
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label7" runat="server"
                                                            Text='<%# Bind("OrderTime") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="ProductName2">
                                    <EditItemTemplate>
                                        <asp:TextBox 
                                            ID="TextBox_EditName" 
                                            runat="server"
                                            CssClass="form-control"
                                            Text='<%# Eval("ProductName") %>'>

                                                </asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="laProductName" runat="server"
                                                        Text='<%# Eval("ProductName") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- Bootstrap Modal Dialog -->
                <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false"
                            UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content" style="font-family : 'Kanit';">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal"
                                            aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="modal-footer">
                                        <button class="btn btn-info" data-dismiss="modal"
                                            aria-hidden="true">Close</button>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>