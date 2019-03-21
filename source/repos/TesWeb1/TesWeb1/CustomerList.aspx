<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="TesWeb1.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-xs-12">
                            <asp:GridView ID="GridViewCustomer" runat="server" AutoGenerateColumns="False"
                                BorderWidth="0px" GridLines="None" CssClass="table table-hover">
                                <Columns>
                                    <asp:BoundField DataField="UserID" HeaderText="UserID" />
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                                    <asp:BoundField DataField="LastName" HeaderText="LastName" />
                                    <asp:BoundField DataField="Username" HeaderText="Username" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
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
                                            <asp:Button CssClass="btn btn-warning" ID="btnEdit" Text="Edit"
                                                runat="server" />
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
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>