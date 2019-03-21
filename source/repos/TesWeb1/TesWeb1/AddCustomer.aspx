<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="TesWeb1.AddCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-xs-12">
                            <div class="form-group col-sm-6 col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
                                <asp:TextBox ID="firstname_TextBox" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="form-group col-sm-6 col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label>
                                <asp:TextBox ID="lastname_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-xs-12">
                            <div class="form-group col-sm-4 col-md-4">
                                <asp:Label ID="Label3" runat="server" Text="Username"></asp:Label>
                                <asp:TextBox ID="username_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4 col-md-4">
                                <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                                <asp:TextBox ID="email_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4 col-md-4">
                                <asp:Label ID="Label5" runat="server" Text="Tel"></asp:Label>
                                <asp:TextBox ID="tel_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-xs-12">
                            <div class="form-group col-sm-6 col-md-6">
                                <asp:Label ID="Label6" runat="server" Text="BirthDay"></asp:Label>
                                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-6 col-md-6">
                                <asp:Label ID="Label7" runat="server" Text="Gender"></asp:Label>
                                <asp:TextBox ID="gender_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-xs-12">
                            <div class="form-group col-sm-4 col-md-4">
                                <asp:Label ID="Label8" runat="server" Text="NumberAddress"></asp:Label>
                                <asp:TextBox ID="numAddress_TextBox" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4 col-md-4">
                                <asp:Label ID="Label9" runat="server" Text="Tambon"></asp:Label>
                                <asp:TextBox ID="tambon_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4 col-md-4">
                                <asp:Label ID="Label10" runat="server" Text="Amphoe"></asp:Label>
                                <asp:TextBox ID="amphoe_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-xs-12">
                            <div class="form-group col-sm-4 col-md-4">
                                <asp:Label ID="Label11" runat="server" Text="City"></asp:Label>
                                <asp:TextBox ID="city_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4 col-md-4">
                                <asp:Label ID="Label12" runat="server" Text="Country"></asp:Label>
                                <asp:TextBox ID="country_TextBox" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4 col-md-4">
                                <asp:Label ID="Label13" runat="server" Text="Postnumber"></asp:Label>
                                <asp:TextBox ID="postnumber_TextBox" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-xs-12">
                            <div class="form-group col-sm-6 col-md-6">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                                    CssClass="btn btn-success btn-block" />
                            </div>
                            <div class="form-group col-sm-6 col-md-6">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                    CssClass="btn btn-danger btn-block" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>