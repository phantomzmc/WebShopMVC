﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TesWeb1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div class="container" style="font-family : 'Kanit';">
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-8">
                            <div class="panel panel-default">
                                <div class="panel-heading">Movie Form</div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="form-group" style="padding-top : 20px;">
                                            <asp:Label runat="server" Text="Product Name" Font-Bold="true"
                                                CssClass="control-label col-sm-3">
                                            </asp:Label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="productname_textbox" CssClass="form-control"
                                                    runat="server" placeholder="Productname">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="padding-top : 20px;">
                                            <asp:Label runat="server" Text="Product Price" Font-Bold="true"
                                                CssClass="control-label col-sm-3">
                                            </asp:Label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="productprice_textbox" CssClass="form-control"
                                                    runat="server" placeholder="Productprice">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="form-group" style="padding-top : 20px;">
                                            <asp:Label runat="server" Text="Product Detail" Font-Bold="true"
                                                CssClass="control-label col-sm-3">
                                            </asp:Label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="productdetail_textbox" CssClass="form-control"
                                                    runat="server" placeholder="Productdetail">
                                                </asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="padding-top : 20px;">
                                            <asp:Label runat="server" Text="Type Product" Font-Bold="true"
                                                CssClass="control-label col-sm-3">
                                            </asp:Label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="DropDownList_TypeProduct" runat="server"
                                                    CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="padding-top : 20px; padding-bottom:20px;">
                                        <asp:Button ID="Button1" runat="server" Text="Submit"
                                            CssClass="btn btn-success btn-block" OnClick="submit_Click" />
                                        <asp:Button ID="Button2" runat="server" Text="Cancel"
                                            CssClass="btn btn-danger btn-block" OnClick="cancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-sm-2 col-md-2 col-xs-2">
                                <asp:Label ID="Label1" runat="server" Text="Search Product : "></asp:Label>
                            </div>
                            <div class="col-sm-8 col-md-8 col-xs-8">
                                <asp:TextBox ID="keySearch_TextBox" runat="server" CssClass="form-control" placeholder="Productname"></asp:TextBox>
                            </div>
                            <div class="col-sm-2 col-md-2 col-xs-2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info btn-block" OnClick="btnSearch_Click"/>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="column" style="padding-top : 20px;padding : 20px; font-family :'Kanit';">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table"
                                BorderWidth="0px" GridLines="None" 
                                OnRowEditing="GridView1_RowEditing"
                                OnRowUpdating="GridView1_RowUpdating"
                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="ProductID"
                                OnRowDeleting="GridView1_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="ProductID">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="editProductID_TextBox" runat="server"
                                                Text='<%# Bind("ProductID") %>' CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProductID") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ProductName">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="editProductName_TextBox" runat="server"
                                                Text='<%# Bind("ProductName") %>' CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProductName") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ProductPrice">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="editProductPrice_TextBox" runat="server"
                                                Text='<%# Bind("ProductPrice") %>' CssClass="form-control">
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("ProductPrice") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ProductDetail">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="editProductDetail_TextBox" runat="server"
                                                Text='<%# Bind("ProductDatail") %>' CssClass="form-control">
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("ProductDatail") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Edit">
                                        <%--<EditItemTemplate>
                                            <asp:Button ID="btn_editSubmit" runat="server" CommandName="UPDATE" Text="Submit" />
                                        </EditItemTemplate>--%>
                                        <EditItemTemplate>
                                            <asp:Button ID="btn_editProduct" runat="server" CommandName="UPDATE"
                                                Text="Submit" CssClass="btn btn-success" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit"
                                                CssClass="btn btn-warning" CommandName="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ลบ">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                                CssClass="btn btn-danger" CommandName="DELETE" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <!-- Bootstrap Modal Dialog -->
                <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false"
                            UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content">
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