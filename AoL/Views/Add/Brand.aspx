<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Brand.aspx.cs" Inherits="AoL.Views.Add.Brand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        main {
            display: flex;
            flex-direction: column;
            align-items: flex-start;
            gap: 1rem;
        }
        main > div {
            display: flex;
            flex-direction: column;
            gap: 0.5rem;
            width: 100%;
        }
    </style>
    <h1>
        Add Brand
    </h1>
    <hr />
    <main class="form">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Rating"></asp:Label>
            <asp:TextBox ID="Rating" TextMode="Number" runat="server"></asp:TextBox>
        </div>
        <div>
            <br />
            <asp:Label ID="Error" runat="server" Text="&nbsp;"></asp:Label>
            <br />
            <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_OnClick" />
        </div>
    </main>
</asp:Content>
