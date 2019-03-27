<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PromotionList.aspx.cs" Inherits="TesWeb1.Promotion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="col-sm-2 col-md-2"></div>
                            <div class="col-sm-8 col-md-8 col-xs-12">
                                <div class="panel panel-info">
                                    <div class="panel-heading">Add Promotion</div>
                                    <div class="panel-body">
                                        <div class="form-group" style="padding :20px;">
                                            <asp:Label ID="Label1" runat="server" Text="PromotionName : "
                                                CssClass="col-sm-4 col-md-4"></asp:Label>
                                            <div class="col-sm-8 col-md-8">
                                                <asp:TextBox ID="promotionname_TextBox" runat="server"
                                                    CssClass="form-control">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="padding :20px;">
                                            <asp:Label ID="Label2" runat="server" Text="PromotionName : "
                                                CssClass="col-sm-4 col-md-4"></asp:Label>
                                            <div class="col-sm-8 col-md-8">
                                                <asp:DropDownList ID="DropDownList1" runat="server"
                                                    CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group" style="padding :20px;">
                                            <asp:Label ID="Label3" runat="server" Text="PromotionDiscount : "
                                                CssClass="col-sm-4 col-md-4"></asp:Label>
                                            <div class="col-sm-8 col-md-8">
                                                <asp:TextBox ID="promotiondiscount_TextBox" runat="server"
                                                    CssClass="form-control">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row" style="padding : 20px;">
                                            <div class="col-sm-6 col-md-6 col-xs-6">
                                                <asp:Button ID="submit_Button" runat="server" Text="Submit"
                                                    CssClass="btn btn-success btn-block"
                                                    onclick="submit_Button_Click" />
                                            </div>
                                            <div class="col-sm-6 col-md-6 col-xs-6">
                                                <asp:Button ID="cancel_Button" runat="server" Text="Cancel"
                                                    CssClass="btn btn-danger btn-block" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2 col-md-2"></div>
                        </div>
                    </div>

                </div>
                <div class="container">
                   <div class="row">
                        <div class="form-group">
                        <div class="col-sm-2 col-md-2 col-xs-2">
                            <asp:Label ID="Label5" runat="server" Text="Search Promotion :"></asp:Label>
                        </div>
                        <div class="col-sm-8 col-md-8 col-xs-8">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-2 col-md-2 col-xs-2">
                            <asp:Button  ID="btnProSearch" runat="server" Text="Search" CssClass="btn btn-info btn-block" onclick="btnProSearch_Click1" />
                        </div>
                        </div>
                    </div>
                </div>
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
                                            <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label>
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
            <asp:Panel ID="Panel2" runat="server">
                <div class="container">
                    <div class="row" style="margin-top : 20px;">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table" BorderWidth="0px" GridLines="None"
                            AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting"
                            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="PromotionID">
                            <Columns>
                                <asp:TemplateField HeaderText="PromotionID">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editid_TextBox" runat="server"
                                            Text='<%# Bind("PromotionID") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("PromotionID") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PromotionName">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editname_TextBox" runat="server"
                                            Text='<%# Bind("PromotionName") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("PromotionName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PromotionDiscount">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editdiscount_TextBox" runat="server"
                                            Text='<%# Bind("PromotionDiscount") %>' CssClass="form-control">
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PromotionDiscount") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PromotionType">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="edittype_TextBox" runat="server"
                                            Text='<%# Bind("PromotionType") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PromotionType") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <EditItemTemplate>
                                        <asp:Button ID="btneditSubmit" runat="server" Text="Submit"
                                            CssClass="btn btn-success" CommandName="UPDATE" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning"
                                            CommandName="Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                            CssClass="btn btn-danger" CommandName="DELETE" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>