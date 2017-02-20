<%@ Page Title="Create Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="ZobShop.Web.Product.CreateProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Category" CssClass="col-md-2 control-label">Category</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Category" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Category"
                    CssClass="text-danger" ErrorMessage="The Category field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Quantity" CssClass="col-md-2 control-label">Quantity</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Quantity" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Quantity"
                    CssClass="text-danger" ErrorMessage="The Quantity field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Price" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Price"
                    CssClass="text-danger" ErrorMessage="The Price field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Volume" CssClass="col-md-2 control-label">Volume</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Volume" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Volume"
                    CssClass="text-danger" ErrorMessage="The Volume field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Maker" CssClass="col-md-2 control-label">Maker</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Maker" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Maker"
                    CssClass="text-danger" ErrorMessage="The Maker field is required." />
            </div>
            
             <asp:Label runat="server" AssociatedControlID="Maker" CssClass="col-md-2 control-label">Upload image (Max: 3mb) </asp:Label>
            <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload"
                ThrobberID="myThrobber"
                AllowedFileTypes="jpg,jpeg,png"
                MaximumNumberOfFiles="1"
                OnUploadComplete="AjaxFileUpload_UploadCompleted"
                MaxFileSize="3000"
                autoStartUpload="false"
                ChunkSize="100"
                runat="server" />
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateProduct_Click" Text="Create" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
