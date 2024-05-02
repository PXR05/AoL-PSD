<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="AoL.Views.Order" %>
<%@ Import Namespace="AoL.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function addToCart(id) {
            var qty = document.getElementById("qty-" + id).value
            window.location.href = "?action=add&?id=" + id + "&q=" + (qty === "" ? "0" : qty);
        }
    </script>
    <h1>
        Order
    </h1>
    <hr />
    <main>
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Brand</th>
                    <th>Type</th>
                    <th>Weight</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var m in Makeups) { %>
                    <tr>
                        <td><%= m.name %></td>
                        <td><%= m.MakeupBrand.name%></td>
                        <td><%= m.MakeupType.name%></td>
                        <td><%= m.weight%></td>
                        <td><%= m.price.ToString("C") %></td>
                        <td>
                            <input type="number" name="quantity" id="qty-<%= m.id %>" />
                        </td>
                        <td>
                            <button type="button" onclick="addToCart(<%= m.id %>)">
                                Add to Cart
                            </button>
                        </td>
                    </tr>
                <% } %>
            </tbody>
        </table>
        <br />  
        <asp:Label ID="Error" runat="server" Text=""></asp:Label>
    </main>
</asp:Content>
