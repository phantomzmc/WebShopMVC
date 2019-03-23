<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TypeProduct.aspx.cs" Inherits="TesWeb1.TypeProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div class="container" style="font-family : 'Kanit';">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-xs-12">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading">Add TypeProduct</div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="form-group" style="padding-top : 20px; padding-left : 20px;">
                                                <asp:Label ID="Label1" runat="server" Text="Type Name : "
                                                    CssClass="control-label col-sm-3">
                                                </asp:Label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="typename_TextBox" runat="server"
                                                        CssClass="form-control">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="padding-top : 20px; padding-left : 20px;">
                                                <asp:Label ID="Label2" runat="server" Text="Type Detail : "
                                                    CssClass="control-label col-sm-3">
                                                </asp:Label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="typedetail_TextBox" runat="server"
                                                        CssClass="form-control">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="padding : 20px;">
                                            <asp:Button ID="submitType" runat="server" Text="Submit"
                                                CssClass="btn btn-info btn-block" onClick="submitType_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="column" style="padding-top : 20px;padding : 20px; font-family :'Kanit';">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table"
                                BorderWidth="0px" GridLines="None" OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" DataKeyNames="TypeID"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="TypeID">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="typeidText" runat="server" Text='<%# Bind("TypeID") %>' CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("TypeID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TypeName">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="typename_TextBox" runat="server" Text='<%# Bind("TypeName") %>' CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TypeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TypeDetail">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="typedetail_TextBox" runat="server" Text='<%# Bind("TypeDetail") %>' CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TypeDetail") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <EditItemTemplate>
                                            <asp:Button 
                                                ID="editSumit_btn" 
                                                runat="server" 
                                                Text="Submit" 
                                                CssClass="btn btn-success btn-block" 
                                                CommandName="UPDATE"
                                                />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Button 
                                                CssClass="btn btn-warning btn-block"
                                                ID="btnEdit"
                                                Text="Edit" 
                                                runat="server" CommandName="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ลบ">
                                        <ItemTemplate>
                                            <asp:Button 
                                                CssClass="btn btn-danger btn-block"
                                                Text="Delete" 
                                                ID="btnDelete" 
                                                runat="server" 
                                                CommandName="DELETE"
                                                />
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