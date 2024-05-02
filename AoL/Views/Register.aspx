<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AoL.Views.Register" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        }
    </style>
    <h1>
        Register
    </h1>
    <hr />

    <main>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="ConfPassword" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label7" runat="server" Text="Gender"></asp:Label>
            <asp:TextBox ID="Gender" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="DoB" TextMode="Date" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Error" runat="server" Text="&nbsp;"></asp:Label>
            <asp:Button ID="RegButton" runat="server" Text="Register" OnClick="RegButton_OnClick" />
        </div>
        <div></div>
        <div>
            <a href="Login.aspx">Login</a>
        </div>
    </main>
</asp:Content>
