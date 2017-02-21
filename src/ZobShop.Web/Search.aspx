<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ZobShop.Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="search-controls">
                <asp:TextBox runat="server" ID="SearchParam" TextMode="Search"></asp:TextBox>
                <asp:Button runat="server" ID="SearchButton" OnClick="SearchButton_OnClick" Text="Search" CssClass="btn btn-submit" />
                <asp:Label runat="server" Text="Search found no results" Visible="False" ID="NoResultsLabel"></asp:Label>
            </div>
            <asp:Repeater runat="server" ID="Reapeater"
                ItemType="ZobShop.ModelViewPresenter.Product.Details.ProductDetailsViewModel">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li class="product-result col-md-6" id="div-search-results">
                        <div class="round-corners" onclick="location.href='<%# $"/Product/ProductDetails?id={Item.Id}" %>'">
                            <asp:Label Text='<%# $"{Item.Name}" %>' runat="server" CssClass="product-name" />
                            <hr />
                            <asp:Label Text='<%# $"{Item.Price:C}" %>' runat="server" CssClass="product-price" />
                            <hr />
                            <asp:Label Text='<%# $"Category: {Item.Category}" %>' runat="server" CssClass="product-category" />
                            <hr />
                            <asp:HyperLink Text="See more" NavigateUrl='<%# $"~/Product/ProductDetails?id={Eval("Id")}" %>' runat="server" />
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
