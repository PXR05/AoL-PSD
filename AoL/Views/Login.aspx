<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AoL.Views.Login" %>
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
        Login
    </h1>
    <hr />

    <main>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <span>
                <asp:CheckBox ID="Remember" runat="server" />
                <asp:Label ID="Label3" runat="server" Text="Remember Me" AssociatedControlID="Remember"></asp:Label>
            </span>
        </div>
        <div style="width: 100%">
            <asp:Label ID="Error" runat="server" Text="&nbsp;"></asp:Label>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
        </div>
        <div></div>
        <div>
            <a href="Register.aspx">Register</a>
        </div>
    </main>
</asp:Content>
