<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="AoL.Views.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function viewDetails(id) {
            window.location.href = "?id=" + id;
        }
    </script>
    <style>
        a {
            padding-inline: 0;
        }
    </style>
    <h1>
        History
    </h1>
    <hr />
    <main>
        <% if (selectedHeader == null) { %>
        <table>
            <thead>
            <tr>
                <th>Id</th>
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
           else
           { %>
            <div>
                <p>
                    <b>
                        Transaction ID:
                    </b>
                    <%= selectedHeader.id%>
                </p>
                <p>
                    <b>
                        Item: 
                    </b>
                    <%= selectedMakeup.name %>
                </p>
                <p>
                    <b>
                        Quantity: 
                    </b>
                    <%= selectedDetail.quantity %>
                </p>
                <p>
                    <b>
                        Date: 
                    </b>
                    <%= selectedHeader.transactionDate %>
                </p>
                <p>
                    <b>
                        Status: 
                    </b>
                    <%= selectedHeader.status %>
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
