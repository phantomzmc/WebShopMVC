<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TesWeb1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
          <div class="column" style="padding-top : 20px;padding : 20px; font-family :'Kanit-Black';">
            <div class="form-group">
                <asp:Label runat="server" Text="Product Name" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-10">
                   <asp:TextBox ID="productname_textbox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Product Price" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="productprice_textbox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Product Detail" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="productdetail_textbox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Type Product" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-10">
                   <asp:TextBox ID="typeproduct_textbox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

            </div>
            <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
            <asp:Label ID="text1" runat="server">TEstText</asp:Label>

                <asp:GridView ID="GridView1" runat="server" CssClass="table" BorderWidth="0" GridLines="None">
                <Columns>
                    <%--<asp:BoundField DataField="ProductID" HeaderText="ProductID"/>
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName"/>
                    <asp:BoundField DataField="ProductPrice" HeaderText="ProductPrice"/>
                    <asp:BoundField DataField="ProductDatail" HeaderText="ProductDetail"/>
                    <asp:BoundField DataField="TypeID" HeaderText="TypeProduct"/>--%>
                    <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button 
                                    CssClass="btn btn-danger"
                                    
                                    ID="btnDelete"
                                    Text="Delete"
                                    runat="server"
                                    />
                            </ItemTemplate>
                        </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:Button 
                                    CssClass="btn btn-warning"
                                    OnClick="btnSubmit_Click"
                                    onClientClick="return confirm('You're whan Edit Item ??')"
                                    ID="btnEdit"
                                    Text="Edit"
                                    runat="server"
                                    />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
           </div>
        </div>
    </div>
           

</asp:Content>

