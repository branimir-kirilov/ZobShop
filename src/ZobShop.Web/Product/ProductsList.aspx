<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="ZobShop.Web.Product.ProductsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="CategoriesDropDownList" runat="server"
        OnSelectedIndexChanged="CategoriesDropDownList_OnSelectedIndexChanged"
        AutoPostBack="True"
        EnableViewState="True"
        SelectMethod="SelectCategories"
        CssClass="category-dropdown">
    </asp:DropDownList>
    <asp:UpdatePanel runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="CategoriesDropDownList" runat="server" />
        </Triggers>
        <ContentTemplate>
            <asp:GridView runat="server" ID="ProductList" AutoGenerateColumns="False"
                ItemType="ZobShop.ModelViewPresenter.Product.Details.ProductDetailsViewModel"
                DataKeyNames="Id"
                CssClass="productsGrid" BorderColor="White" BorderStyle="None"
                SelectMethod="Select">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Product Name" />
                    <asp:BoundField DataField="Maker" HeaderText="Maker" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Volume" HeaderText="Volume" />
                    <asp:TemplateField HeaderText="Photo" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ImageBuffer")) %>' Height="200" ImageAlign="Middle" CssClass="productImage" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>