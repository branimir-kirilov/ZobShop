<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="ZobShop.Web.ShoppingCart.Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server"
        ItemType="ZobShop.ModelViewPresenter.ShoppingCart.Summary.CartLineViewModel"
        SelectMethod="Select"
        AutoGenerateColumns="True">
    </asp:GridView>
</asp:Content>
