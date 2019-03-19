<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TesWeb1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>--%>
    <div class="container">
        <div class="row">
            <div class="col-sm-12 col-md-12 col-xs-12" style="padding : 20px;">
                <div class="panel panel-primary">
                    <div class="panel-heading">Add Product</div>
                    <div class="panel-body">
                        <div class="col-sm-7 col-md-7 col-xs-12">
                            <div class="form-group" style="padding : 20px;">
                                <asp:Label runat="server" Text="Customer Name : " CssClass="control-label col-sm-2">
                                </asp:Label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div style="padding : 20px;">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Product Name : " CssClass="control-label col-sm-2">
                                    </asp:Label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div style="padding : 20px;">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Order QTY : " CssClass="control-label col-sm-2">
                                    </asp:Label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2 col-md-2" style="display: flex; align-items: center; margin-top:20px;">
                            <div class="container">
                                <div class="row">
                                    <asp:Button runat="server" CssClass="btn btn-danger btn-block" Text="Cancel" OnClick="Unnamed4_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3" style="margin-top:20px;">
                            <div class="container">
                                <div class="row">
                                    <asp:Label ID="Label1" runat="server" Text="Label"
                                        CssClass="control-label col-sm-2">
                                        Name : </asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text="Label"
                                        CssClass="control-label col-sm-1">
                                    </asp:Label>
                                </div>
                                <div class="row">
                                    <asp:Label ID="Label3" runat="server" Text="Label"
                                        CssClass="control-label col-sm-2">Qty
                                        : </asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text="Label"
                                        CssClass="control-label col-sm-1">
                                    </asp:Label>
                                </div>
                                <div class="row">
                                    <asp:Label ID="Label5" runat="server" Text="Label"
                                        CssClass="control-label col-sm-2">
                                        Price : </asp:Label>
                                    <asp:Label ID="Label6" runat="server" Text="Label"
                                        CssClass="control-label col-sm-1">
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
                    <asp:Button runat="server" CssClass="btn btn-success btn-block" Text="Submit" />
                </div>
                <div class="col-sm-5">
                    <asp:Button runat="server" CssClass="btn btn-danger btn-block" Text="Cancel" />
                </div>
                <div class="col-sm-1"></div>

            </div>

        </div>
    </div>
</asp:Content>