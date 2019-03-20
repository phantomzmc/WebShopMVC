<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="TesWeb1.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="panel panel-default">
                    <div class="panel-heading">Edit Product Form</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="form-group" style="padding-top : 20px;">
                                <asp:Label runat="server" Text="ProductID" Font-Bold="true"
                                    CssClass="control-label col-sm-3"></asp:Label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"
                                        placeholder="ProductID">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group" style="padding-top : 20px;">
                                <asp:Label runat="server" Text="Product Name" Font-Bold="true"
                                    CssClass="control-label col-sm-3">
                                </asp:Label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="productname_textbox" CssClass="form-control" runat="server"
                                        placeholder="Productname">
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
                                    <asp:TextBox ID="productprice_textbox" CssClass="form-control" runat="server"
                                        placeholder="Productprice">
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
                                    <asp:TextBox ID="productdetail_textbox" CssClass="form-control" runat="server"
                                        placeholder="Productdetail">
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
                            <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-success btn-block"
                                OnClick="submit_Click" />
                            <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-block"
                                OnClick="cancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>
</asp:Content>