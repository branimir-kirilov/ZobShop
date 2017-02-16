<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ZobShop.Web.Product.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" ID="ErrorLabel"></asp:Label>

    <asp:FormView runat="server" ID="DetailsView">
        <ItemTemplate>
            <div>
            </div>
        </ItemTemplate>
    </asp:FormView>
    <div>
        <asp:RangeValidator runat="server"
            Type="Integer"
            ControlToValidate="AddToCartQuantity"
            MinimumValue="1"
            MaximumValue="123"
            ErrorMessage="Please provide positive quantity"></asp:RangeValidator>
        <asp:TextBox runat="server" ID="AddToCartQuantity" Text="1" TextMode="Number"></asp:TextBox>
        <asp:Button runat="server" ID="AddToCartButton" OnClick="AddToCartButton_OnClick" />
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
            <asp:TextBox runat="server" ID="RatingBox"></asp:TextBox>
            <asp:Button runat="server" ID="Rate" Text="Add Review" OnClick="Rate_OnClick" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
