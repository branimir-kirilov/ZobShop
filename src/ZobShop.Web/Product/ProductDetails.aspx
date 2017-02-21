<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ZobShop.Web.Product.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" ID="ErrorLabel"></asp:Label>

    <asp:FormView runat="server" ID="DetailsView">
        <ItemTemplate>
            <div>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <div id="add-to-cart-controls" class="col-md-offset-2 navbar-right">
        <asp:RangeValidator runat="server"
            Type="Integer"
            ControlToValidate="AddToCartQuantity"
            MinimumValue="1"
            MaximumValue="15"
            ErrorMessage="Please provide positive quantity"></asp:RangeValidator>
        <asp:Label runat="server" Text="Choose quantity: "></asp:Label>
        <asp:TextBox runat="server" ID="AddToCartQuantity" Text="1" TextMode="Number"
            Width="35" Height="35"></asp:TextBox>
        <asp:Button runat="server" ID="AddToCartButton" Text="Add to cart" OnClick="AddToCartButton_OnClick" CssClass="btn btn-success" />
    </div>

    <div class="product-details col-md-6">
        <asp:Label Text='<%# $"{Model.Name}" %>' runat="server" CssClass="product-name" />
        <hr />
        <asp:Label Text='<%# $"{Model.Price:C}" %>' runat="server" CssClass="product-price" />
        <hr />
        <asp:Label Text='<%# $"Category: {Model.Category}" %>' runat="server" CssClass="product-category" />
        <hr />
    </div>
    <div class="col-md-5">
        <asp:Image runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Model.ImageBuffer) %>' Height="200" ImageAlign="Middle" CssClass="productImage" />
    </div>

    <br />

    <div class="reviews col-md-9">
        <asp:UpdatePanel runat="server" ID="UpdatePanelResults">
            <ContentTemplate>
                <asp:SqlDataSource ID="SqlDataSourceComments" runat="server"
                    ConnectionString="<%$ ConnectionStrings:ZobShopDb %>"></asp:SqlDataSource>
                <asp:Label runat="server" ID="PanelResults"></asp:Label>

                <asp:GridView runat="server"
                    DataSourceID="SqlDataSourceComments"
                    AutoGenerateColumns="False"
                    CssClass="reviews-grid"
                    BorderStyle="None"
                    BorderWidth="0"
                    CellPadding="15"
                    CellSpacing="10"
                    PagerSettings-Visible="true"
                    HeaderStyle-BorderColor="Transparent"
                    RowStyle-BorderStyle="None"
                    RowStyle-BorderColor="Transparent"
                    RowStyle-BackColor="Transparent">
                    <Columns>
                        <asp:BoundField DataField="Rating" HeaderText="Ratings" />
                        <asp:BoundField DataField="Content" HeaderText="Comments" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
            <div class="add-review col-md-9">
                <asp:Label runat="server" Text="Give Rating" />
                <asp:UpdatePanel ID="UpdatePanelComment" runat="server" class="panel"
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label runat="server" Text="Comment" />
                        <asp:TextBox runat="server" Type="Integer" ID="RatingBox" TextMode="Multiline" Width="400" Height="100" CssClass="comment-box"></asp:TextBox>
                        <asp:Label runat="server" Text="Rating" />
                        <asp:TextBox runat="server" ID="ContentRatingBox" TextMode="Number" min="1" max="6" step="1" Width="50" Height="50" MaxLength="1"></asp:TextBox>
                        <asp:Button runat="server" ID="Rate" Text="Add Review" OnClick="Rate_OnClick" CssClass="btn btn-success btn-lg"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
