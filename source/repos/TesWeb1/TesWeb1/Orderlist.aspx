<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orderlist.aspx.cs" Inherits="TesWeb1.Orderlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">

                <div class="row">
                    <div class="column" style="padding-top : 20px;padding : 20px; font-family :'Kanit-Black';">
                        <asp:GridView ID="GridView_Order" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-hover" BorderWidth="0px" GridLines="None" DataKeyNames="OrderID"
                            OnRowCancelingEdit="GridView_Order_RowCancelingEdit"
                            OnRowEditing="GridView_Order_RowEditing" OnRowUpdating="GridView_Order_RowUpdating">
                            <Columns>
                                <asp:BoundField DataField="OrderID" HeaderText="OrderID" />
                                <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                                <asp:BoundField DataField="ProductPrice" HeaderText="ProductPrice" />
                                <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                                <asp:BoundField DataField="LastName" HeaderText="LastName" />
                                <asp:BoundField DataField="OrderQty" HeaderText="OrderQty" />
                                <asp:BoundField DataField="OrderPrice" HeaderText="OrderPrice" />
                                <asp:BoundField DataField="OrderTime" HeaderText="OrderTime" />

                                <asp:TemplateField HeaderText="Edit">
                                    <EditItemTemplate>
                                        <asp:Button ID="btnSave" runat="server" CommandName="UPDATE" Text="submit"
                                            CssClass="btn btn-success" />
                                        <asp:Button ID="btnCancel" runat="server" CommandName="CANCEL" Text="Cancel"
                                            CssClass="btn btn-danger" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning"
                                            OnClick="btnEdit_Click" CommandName="Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ลบ">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                            CssClass="btn btn-danger" OnClick="btnDelete_Click" />
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
                                    <asp:Label ID="laProductName" runat="server" Text='<%# Eval("ProductName") %>'>
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
</asp:Content>