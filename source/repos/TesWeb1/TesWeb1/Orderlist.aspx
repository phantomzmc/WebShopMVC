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
                            OnRowEditing="GridView_Order_RowEditing" OnRowUpdating="GridView_Order_RowUpdating" OnSelectedIndexChanged="GridView_Order_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="OrderID" HeaderText="OrderID" />
                                <asp:TemplateField HeaderText="ProductName">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="orderProductName_TextBox" runat="server" Text='<%# Bind("ProductName") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ProductPrice">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="orderProductPrice_TextBox" runat="server" Text='<%# Bind("ProductPrice") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProductPrice") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FirstName">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="orderFirstName_TextBox" runat="server" Text='<%# Bind("FirstName") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="LastName">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="orderLastName_TextBox" runat="server" Text='<%# Bind("LastName") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OrderQty">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="orderQty_TextBox" runat="server" Text='<%# Bind("OrderQty") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("OrderQty") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OrderPrice">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="orderPrice_TextBox" runat="server" Text='<%# Bind("OrderPrice") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("OrderPrice") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OrderTime">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="orderTime_TextBox" runat="server" Text='<%# Bind("OrderTime") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("OrderTime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

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