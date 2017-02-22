<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="ZobShop.Web.Administration.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="Users"
        AutoGenerateColumns="False"
        ItemType="ZobShop.ModelViewPresenter.Administration.UsersList.UserDetailsViewModel" CssClass="table"
        DeleteMethod="Delete"
        SelectMethod="Select"
        DataKeyNames="UserId">
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="Username" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
