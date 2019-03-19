<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orderlist.aspx.cs" Inherits="TesWeb1.Orderlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="column" style="padding-top : 20px;padding : 20px; font-family :'Kanit-Black';">
            <asp:GridView ID="GridView_Order" runat="server" AutoGenerateColumns="false" CssClass="table" BorderWidth="0" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="OrderID" HeaderText="OrderID"/>
                        <asp:BoundField DataField="ProductName" HeaderText="ProductName"/>
                        <asp:BoundField DataField="ProductPrice" HeaderText="ProductPrice"/>
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName"/>
                        <asp:BoundField DataField="LastName" HeaderText="LastName"/>
                        <asp:BoundField DataField="OrderQty" HeaderText="OrderQty"/>
                        <asp:BoundField DataField="OrderPrice" HeaderText="OrderPrice"/>
                        <asp:BoundField DataField="OrderTime" HeaderText="OrderTime"/>
                       
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning" OnClick="btnEdit_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลบ">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>
                            </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
