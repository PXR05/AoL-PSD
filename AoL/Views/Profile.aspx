<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AoL.Views.Profile" %>
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
       }
    </style>
    <h1>
        Profile
    </h1>
    <hr />
    <main>
        <asp:TextBox ID="UserId" Visible="False" runat="server"></asp:TextBox>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
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
            <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_OnClick" />
        </div>
    </main>
</asp:Content>
