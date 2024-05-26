<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AoL.Views.Home" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        tr, td, th {
            padding: 0.5rem;
        }
        main {
            display: flex;
            flex-direction: column;
            gap: 0.5rem;
        }
    </style>
    <h1>
        Home
    </h1>
    <hr />
    <main>
        <h2 ID="CurrUser" runat="server"></h2>
        <asp:GridView ID="UserList" runat="server"></asp:GridView>
    </main>
</asp:Content>
