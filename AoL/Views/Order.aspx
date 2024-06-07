<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="AoL.Views.Order" %>
<%@ Import Namespace="AoL.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function addToCart(id) {
            var qty = document.getElementById("qty-" + id).value
            window.location.href = "?action=add&id=" + id + "&q=" + (qty === "" ? "0" : qty);
        }
        function clearCart() {
            window.location.href = "?action=clear";
        }
        function checkout() {
            window.location.href = "?action=checkout";
        }
    </script>
    <style>
        .cart {
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            column-gap: 2rem;
        }
    </style>
    <h1>
        Order
    </h1>
    <hr />
    <main>
        <div>
            <h2>Items</h2>
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
                    <% if (Makeups.Count > 0) { %>
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
                    <% } %>
                </tbody>
            </table>
            <br />  
            <asp:Label ID="Error" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <div style="display: flex; justify-content: space-between; align-items: center">
                <h2>Cart</h2>
                <div>
                    <button type="button" onclick="clearCart()">
                        Clear
                    </button>
                    <button type="button" onclick="checkout()">
                        Checkout
                    </button>
                </div>
            </div>
            <div class="cart">
                <% if (Carts.Count > 0) { %>
                    <% foreach (var item in Carts) { %>
                        <% if (item != null) { %>
                        <div>
                            <span>
                                <p>[ <%= item.Makeup.id %> ] <%= item.Makeup.name %></p>
                                <p><%= item.Makeup.MakeupBrand.name %> | <%= item.Makeup.MakeupType.name %></p>
                                <p><%= item.Makeup.weight %> g</p>
                            </span>
                            <p><%= item.quantity %> x <%= item.Makeup.price.ToString("C") %></p>
                            <hr />
                        </div>
                        <% } %>
                    <% } %>
                <% } %>
            </div>
        </div>
    </main>
</asp:Content>
