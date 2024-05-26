<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="AoL.Views.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function viewDetails(id) {
            window.location.href = "?id=" + id;
        }
    </script>
    <style>
        main a {
            padding-inline: 0;
        }
    </style>
    <h1>
        History
    </h1>
    <hr />
    <main>
        <% if (SelectedHeader == null) { %>
        <table>
            <thead>
            <tr>
                <th>Id</th>
                <% if (isAdmin) { %>
                    <th>
                        User Id
                    </th>
                <% } %>
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
                        <% if (isAdmin) { %>
                            <td><%= t.userId %></td>
                        <% } %>
                        <td><%= t.transactionDate%></td>
                        <td><%= t.status%></td>
                        <td>
                            <button type="button" onclick="viewDetails(<%= t.id %>)">
                                View Details
                            </button>
                        </td>
                    </tr>
                <% } %>
            <% } %>
            </tbody>
        </table>
        <% }
           else if (SelectedHeader != null && SelectedDetail != null)
           { %>
            <div>
                <p>
                    <b>
                        Transaction ID:
                    </b>
                    <%= SelectedHeader.id%>
                </p>
                <% if (isAdmin) { %>
                    <p>
                        <b>
                            User ID:
                        </b>
                        <%= SelectedHeader.userId %>
                    </p>
                <% } %>
                <p>
                    <b>
                        Item: 
                    </b>
                    <%= SelectedDetail.Makeup.name %>
                </p>
                <p>
                    <b>
                        Quantity: 
                    </b>
                    <%= SelectedDetail.quantity %>
                </p>
                <p>
                    <b>
                        Date: 
                    </b>
                    <%= SelectedHeader.transactionDate %>
                </p>
                <p>
                    <b>
                        Status: 
                    </b>
                    <%= SelectedHeader.status %>
                </p>
                <br />
                <a href="History.aspx">
                    <button type="button">
                        Close
                    </button>
                </a>
            </div>
            <% } %>
        <br />  
        <asp:Label ID="Error" runat="server" Text=""></asp:Label>
    </main>
</asp:Content>
