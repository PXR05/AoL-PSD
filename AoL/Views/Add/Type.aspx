<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Type.aspx.cs" Inherits="AoL.Views.Add.Type" %>
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
        Add Type
    </h1>
    <hr />
    <main class="form">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        </div>
        <div>
            <br />
            <asp:Label ID="Error" runat="server" Text="&nbsp;"></asp:Label>
            <br />
            <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_OnClick" />
        </div>
    </main>
</asp:Content>
