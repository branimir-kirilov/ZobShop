<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="ZobShop.Web.Administration.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="Products"
        AutoGenerateColumns="False"
        ItemType="ZobShop.ModelViewPresenter.Product.Details.ProductDetailsViewModel" CssClass="table"
        DeleteMethod="Delete"
        SelectMethod="Select"
        UpdateMethod="Update"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Product Name" />
            <asp:BoundField DataField="Maker" HeaderText="Maker" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Volume" HeaderText="Volume" />
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
