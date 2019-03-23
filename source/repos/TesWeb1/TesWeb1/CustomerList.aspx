<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="TesWeb1.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-xs-12">
                        <asp:GridView ID="GridViewCustomer" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                            GridLines="None" CssClass="table table-hover" DataKeyNames="UserID"
                            OnRowEditing="GridViewCustomer_RowEditing" style="font-family : 'Kanit';">
                            <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="UserID" />
                                <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                                <asp:BoundField DataField="LastName" HeaderText="LastName" />
                                <asp:BoundField DataField="Username" HeaderText="Username" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="BrithDay" HeaderText="BrithDay" />
                                <asp:BoundField DataField="Tel" HeaderText="Tel" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                <asp:BoundField DataField="NumAddress" HeaderText="NumAddress" />
                                <asp:BoundField DataField="Tambon" HeaderText="Tumbon" />
                                <asp:BoundField DataField="Amphoe" HeaderText="Amphoe" />
                                <asp:BoundField DataField="City" HeaderText="City" />
                                <asp:BoundField DataField="Country" HeaderText="Country" />
                                <asp:BoundField DataField="PostNumber" HeaderText="PostNumber" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button CssClass="btn btn-warning" ID="btnEdit" Text="Edit" runat="server"
                                            onclick="btnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ลบ">
                                    <ItemTemplate>
                                        <asp:Button CssClass="btn btn-danger" Text="Delete" ID="btnDelete"
                                            runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>


            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <div class="container" style="font-family : 'Kanit';">
                    <div class="col-sm-1 col-md-1"></div>
                    <div class="col-sm-10 col-md-10 col-xs-12">
                        <div class="row">
                            <!-- <button type="button" class="close" data-dismiss="modal"
                                            aria-hidden="true">&times;</button> -->
                            <h2 style="padding-top : 40px; padding-bottom:40px;">
                                <asp:Label ID="lblModalTitle" runat="server" Text="EditUser"></asp:Label>
                            </h2>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
                                    <asp:TextBox ID="firstname_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Lastname"></asp:Label>
                                    <asp:TextBox ID="lastname_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                                    <asp:TextBox ID="email_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Username"></asp:Label>
                                    <asp:TextBox ID="username_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text="UserID"></asp:Label>
                                    <asp:TextBox ID="userid_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" Text="Tel"></asp:Label>
                                    <asp:TextBox ID="tel_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" Text="Gender"></asp:Label>
                                    <asp:TextBox ID="gender_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Label ID="Label8" runat="server" Text="BirthDay"></asp:Label>
                                    <asp:TextBox ID="birthday_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="Label9" runat="server" Text="NumAddress"></asp:Label>
                                    <asp:TextBox ID="numaddress_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="Tambon"></asp:Label>
                                    <asp:TextBox ID="tambon_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="Label11" runat="server" Text="Amphoe"></asp:Label>
                                    <asp:TextBox ID="amphoe_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="Label12" runat="server" Text="City"></asp:Label>
                                    <asp:TextBox ID="city_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="Label13" runat="server" Text="Country"></asp:Label>
                                    <asp:TextBox ID="country_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="Label14" runat="server" Text="PostNumber"></asp:Label>
                                    <asp:TextBox ID="postnumber_TextBox" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-xs-12">
                                <div class="col-sm-6 col-md-6"></div>
                                <div class="col-sm-3 col-md-3 col-xs-12">
                                    <asp:Button CssClass="btn btn-success btn-block" ID="btnEditSub" Text="Submit" runat="server"
                                        OnClick="btnEditSub_Click" />
                                </div>
                                <div class="col-sm-3 col-md-3 col-xs-12">
                                    <asp:Button CssClass="btn btn-info btn-block" ID="btnEditClose" Text="Close" runat="server"
                                        OnClick="btnEditSub_Click" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-1 col-md-1"></div>
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
                                            <asp:Label ID="Label15" runat="server" Text=""></asp:Label>
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