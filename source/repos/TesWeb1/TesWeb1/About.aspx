<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TesWeb1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName"/>
                </Columns>
            </asp:GridView>
</asp:Content>
