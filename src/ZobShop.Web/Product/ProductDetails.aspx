<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ZobShop.Web.Product.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" ID="ErrorLabel"></asp:Label>

    <asp:FormView runat="server" ID="DetailsView">
        <ItemTemplate>
            <div>
            </div>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>
