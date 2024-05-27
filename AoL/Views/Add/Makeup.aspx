<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Makeup.aspx.cs" Inherits="AoL.Views.Add.Makeup" %>
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
        Add Makeup
    </h1>
    <hr />
    <main class="form">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="Price" TextMode="Number" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Weight"></asp:Label>
            <asp:TextBox ID="Weight" TextMode="Number" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Type"></asp:Label>
            <asp:DropDownList ID="TypeList" runat="server">
                <asp:ListItem Text="Select a Type" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Brand"></asp:Label>
            <asp:DropDownList ID="BrandList" runat="server">
                <asp:ListItem Text="Select a Brand" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <br />
            <asp:Label ID="Error" runat="server" Text="&nbsp;"></asp:Label>
            <br />
            <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_OnClick" />
        </div>
    </main>
</asp:Content>
