<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ZobShop.Web.Product.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" ID="ErrorLabel"></asp:Label>

    <asp:FormView runat="server" ID="DetailsView">
        <ItemTemplate>
            <div>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <div id="add-to-cart-controls" class="col-md-offset-2">
        <asp:RangeValidator runat="server"
            Type="Integer"
            ControlToValidate="AddToCartQuantity"
            MinimumValue="1"
            MaximumValue="15"
            ErrorMessage="Please provide positive quantity"></asp:RangeValidator>
        <asp:TextBox runat="server" ID="AddToCartQuantity" Text="1" TextMode="Number"></asp:TextBox>
        <asp:Button runat="server" ID="AddToCartButton" Text="Add to cart" OnClick="AddToCartButton_OnClick" />
    </div>

    <div class="round-corners col-md-6">
        <asp:Label Text='<%# $"{Model.Name}" %>' runat="server" CssClass="product-name" />
        <hr />
        <asp:Label Text='<%# $"{Model.Price:C}" %>' runat="server" CssClass="product-price" />
        <hr />
        <asp:Label Text='<%# $"Category: {Model.Category}" %>' runat="server" CssClass="product-category" />
        <hr />
    </div>
    <div class="col-md-5">
         <asp:Image  runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Model.ImageBuffer) %>' Height="200" ImageAlign="Middle" CssClass="productImage" />
    </div>

    <br />
    <asp:UpdatePanel runat="server" ID="UpdatePanelResults">
        <ContentTemplate>
            <asp:SqlDataSource ID="SqlDataSourceComments" runat="server"
                ConnectionString="<%$ ConnectionStrings:ZobShopDb %>"></asp:SqlDataSource>
            <asp:Label runat="server" ID="PanelResults"></asp:Label>

            <asp:GridView runat="server" DataSourceID="SqlDataSourceComments" AutoGenerateColumns="True"></asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanelComment" runat="server" class="panel"
        UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TextBox runat="server" ID="ContentRatingBox"></asp:TextBox>
            <asp:TextBox runat="server" Type="Integer" ID="RatingBox"></asp:TextBox>
            <asp:Button runat="server" ID="Rate" Text="Add Review" OnClick="Rate_OnClick" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
