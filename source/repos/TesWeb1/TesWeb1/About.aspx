<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TesWeb1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div class="container">
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
                        <div class="column" style="padding-top : 20px;padding : 20px; font-family :'Kanit-Black';">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table"
                                BorderWidth="0" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" />
                                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                                    <asp:BoundField DataField="ProductPrice" HeaderText="ProductPrice" />
                                    <asp:BoundField DataField="ProductDatail" HeaderText="ProductDetail" />


                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit"
                                                CssClass="btn btn-warning" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ลบ">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                                CssClass="btn btn-danger" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>