<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="ZobShop.Web.Product.ProductsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="ProductList" AutoGenerateColumns="False"
        ItemType="ZobShop.ModelViewPresenter.Product.Details.ProductDetailsViewModel"
        DataKeyNames="Id"
        cssClass="productsGrid" BorderColor="White" BorderStyle="None">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Product Name" />
            <asp:BoundField DataField="Maker" HeaderText="Maker" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Volume" HeaderText="Volume" />
            <asp:TemplateField HeaderText="Photo" HeaderStyle-CssClass="">
                <ItemTemplate>
                    <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ImageBuffer")) %>' Height="200" Width="200" ImageAlign="Middle" CssClass="productImage" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>


