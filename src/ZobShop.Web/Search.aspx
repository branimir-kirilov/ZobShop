<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ZobShop.Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <h1><%: Title %>
            <asp:Literal runat="server" ID="LiteralSearchQuery" Mode="Encode"></asp:Literal></h1>
    </div>

    <asp:Repeater runat="server" ID="Reapeater"
         ItemType="ZobShop.ModelViewPresenter.Product.Details.ProductDetailsViewModel">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href="<%# string.Format("Product/ProductDetails?id={0}",Item.Id) %>"><%# $"{Item.Maker} {Item.Name}" %></a>

                (Category: <%#: Item.Category %>)                 
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

    <div class="back-link">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
