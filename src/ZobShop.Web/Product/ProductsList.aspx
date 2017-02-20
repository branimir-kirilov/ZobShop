<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="ZobShop.Web.Product.ProductsList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:Label Text="Choose category: " runat="server" CssClass="main-label" />
        <asp:DropDownList ID="CategoriesDropDownList" runat="server"
            OnSelectedIndexChanged="CategoriesDropDownList_OnSelectedIndexChanged"
            AutoPostBack="True"
            EnableViewState="True"
            SelectMethod="SelectCategories"
            CssClass="category-dropdown">
        </asp:DropDownList>
        <hr />
        <asp:UpdatePanel runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="CategoriesDropDownList" runat="server" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView runat="server" ID="ProductList" AutoGenerateColumns="False"
                    ItemType="ZobShop.ModelViewPresenter.Product.Details.ProductDetailsViewModel"
                    DataKeyNames="Id"
                    CssClass="productsGrid" BorderColor="White" BorderStyle="None"
                    SelectMethod="Select"
                    BorderWidth="0"
                    CellPadding="30"
                    GridLines="Horizontal">
                    <RowStyle CssClass="grid-row" VerticalAlign="Top" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                    <div class="round-corners" onclick="location.href='<%# $"/Product/ProductDetails?id={Eval("Id")}" %>'">
                                        <asp:Label Text='<%# Eval("Name") %>' runat="server" CssClass="product-name" />
                                        <hr />
                                        <asp:Label Text='<%# $"{Eval("Price"):C}" %>' runat="server" CssClass="product-price" />
                                        <hr />
                                        <asp:Label Text='<%# $"Category: {Eval("Category")}" %>' runat="server" CssClass="product-category" />
                                        <hr />
                                        <asp:HyperLink Text="See more" NavigateUrl='<%# $"~/Product/ProductDetails?id={Eval("Id")}" %>' runat="server" />
                                    </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ImageBuffer")) %>' Height="200" ImageAlign="Middle" CssClass="productImage" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
