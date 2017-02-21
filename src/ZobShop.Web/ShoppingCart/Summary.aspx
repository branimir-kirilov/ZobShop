<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="ZobShop.Web.ShoppingCart.Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView runat="server" ID="Products"
                AutoGenerateColumns="False"
                ItemType="ZobShop.ModelViewPresenter.ShoppingCart.Summary.CartLineViewModel"
                CssClass="table table-striped table-condensed table-bordered"
                SelectMethod="Select"
                DeleteMethod="Delete"
                DataKeyNames="ProductId">
                <Columns>
                    <asp:BoundField DataField="Model.Name" HeaderText="Product" />
                    <asp:BoundField DataField="Model.Category" HeaderText="Category" />
                    <asp:BoundField DataField="Model.Volume" HeaderText="Volume" />
                    <asp:BoundField DataField="Model.Price" HeaderText="Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:CommandField ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
            <asp:Label runat="server" ID="Total"></asp:Label>
            <hr/>
            <a runat="server" class="btn btn-default" href="/ShoppingCart/Checkout">Checkout</a>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
