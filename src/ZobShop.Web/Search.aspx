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
                    <li>
                        <a href="<%# $"Product/ProductDetails?id={Item.Id}" %>"><%# $"{Item.Maker} {Item.Name}" %></a>

                        (Category: <%#: Item.Category %>)                 
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
