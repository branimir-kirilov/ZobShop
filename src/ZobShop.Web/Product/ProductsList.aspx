<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="ZobShop.Web.Product.ProductsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="ProductList" AutoGenerateColumns="True"></asp:GridView>
</asp:Content>
