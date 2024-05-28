<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Queue.aspx.cs" Inherits="AoL.Views.Queue1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
    function handleTransaction(id) {
        window.location.href = "?id=" + id;
    }
</script>
    <style>
    main a {
        padding-inline: 0;
    }
</style>
    <h1>
        Queue
    </h1>
    <hr />
    <main>
        <table>
            <thead>
            <tr>
                <th>Id</th>
                <th>User Id</th>
                <th>Date</th>
                <th>Status</th>
                <th></th>
            </tr>
            </thead>
            <tbody>
            <% if (Transactions.Count > 0) { %>
                <% foreach (var t in Transactions) { %>
                    <tr>
                        <td><%= t.id %></td>
                        <td><%= t.userId %></td>
                        <td><%= t.transactionDate%></td>
                        <td><%= t.status%></td>
                        <td>
                            <% if (t.status == "unhandled") { %>
                                <button type="button" onclick="handleTransaction(<%= t.id %>)">
                                    Handle
                                </button>
                            <% } %>
                        </td>
                    </tr>
                <% } %>
            <% } %>
            </tbody>
        </table>
        <br />  
        <asp:Label ID="Error" runat="server" Text=""></asp:Label>
    </main>
</asp:Content>
