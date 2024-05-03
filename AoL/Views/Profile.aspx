<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AoL.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        main {
            display: flex;
            gap: 6rem;
        }
        main > span {
            inset: 0;
            left: 45%;
            height: 100%;
            width: 1px;
            background-color: black;
        }
       .form {
            display: flex;
            flex-direction: column;
            align-items: flex-start;
            gap: 1rem;
       }
       .form > div {
            display: flex;
            flex-direction: column;
            gap: 0.5rem;
       }
    </style>
    <main>
        <div>
            <h1>
                Profile
            </h1>
            <hr />
            <div class="form">

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
            </div>
        </div>
        <div>
            <h1>
                Change Password
            </h1>
            <hr />
            <div class="form">
                <asp:TextBox ID="TextBox1" Visible="False" runat="server"></asp:TextBox>
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Old Password"></asp:Label>
                    <asp:TextBox ID="OldPass" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Label3" runat="server" Text="New Password"></asp:Label>
                    <asp:TextBox ID="NewPass" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="PassError" runat="server" Text="&nbsp;"></asp:Label>
                    <asp:Button ID="Change" runat="server" Text="Update" OnClick="Change_OnClick" />
                </div>
            </div>
        </div>
    </main>
</asp:Content>
