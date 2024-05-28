<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Brand.aspx.cs" Inherits="AoL.Views.Update.Brand" %>
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
        Update Brand
    </h1>
    <p>
        Brand ID: <%= Request.QueryString["id"] %>
    </p>
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
            <asp:Label ID="ErrorLabel" runat="server" Text="&nbsp;"></asp:Label>
            <br />
            <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_OnClick" />
        </div>
        <div>
            <a href="/Views/Manage.aspx" style="padding: 0;">
                <button type="button" style="width: 100%; padding-inline: 0;">
                    Cancel
                </button>
            </a>
        </div>
    </main>
</asp:Content>
