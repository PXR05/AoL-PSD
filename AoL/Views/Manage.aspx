<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Nav.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="AoL.Views.Manage" %>
<%@ Import Namespace="System.Web.Util" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function _delete(item, id) {
            window.location.href = "?action=delete&item=" + item + "&id=" + id;
        }
    </script>
    <style>
        main {
            display: flex;
            flex-direction: column;
            gap: 1rem;
        }
        main a {
            padding-inline: 0;
        }
        .table-container > div {
            display: flex;
            justify-content: space-between;
            align-items: center;
            border-bottom: 1px solid rgba(0,0,0,0.5);
            margin-bottom: 1rem;
        }
    </style>
    <h1>
        Manage
    </h1>
    <hr />
    <main>
        <div class="table-container">
            <div>
                <h2>Makeup</h2>
                <a href="Add/Makeup.aspx">
                    <button type="button">
                        Add
                    </button>
                </a>
            </div>
            <table>
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Weight</th>
                    <th>Brand</th>
                    <th>Type</th>
                    <th></th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                <% if (Makeups.Count > 0) { %>
                    <% foreach (var m in Makeups) { %>
                        <tr>
                            <td><%= m.id %></td>
                            <td><%= m.name%></td>

                            <td><%= m.price%></td>
                            <td><%= m.weight%></td>
                            <td><%= m.MakeupBrand.name%></td>
                            <td><%= m.MakeupType.name%></td>
                            <td>
                                <a href="Update/Makeup.aspx?id=<%= m.id %>">
                                    <button type="button">
                                        Update
                                    </button>
                                </a>
                            </td>
                            <td>
                                <button type="button" onclick="_delete('makeup', <%= m.id %>)">
                                    Delete
                                </button>
                            </td>
                        </tr>
                    <% } %>
                <% } %>
                </tbody>
            </table>
            <br />
            <asp:Label ID="MakeupError" runat="server" Text="&nbsp;"></asp:Label>
            <br />
        </div>
        <div class="table-container">
            <div>
                <h2>Type</h2>
                <a href="Add/Type.aspx">
                    <button type="button">
                        Add
                    </button>
                </a>
            </div>
            <table>
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th></th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                <% if (Types.Count > 0) { %>
                    <% foreach (var t in Types) { %>
                        <tr>
                            <td><%= t.id %></td>
                            <td><%= t.name%></td>
                            <td>
                                <a href="Update/Type.aspx?id=<%= t.id %>">
                                    <button type="button">
                                        Update
                                    </button>
                                </a>
                            </td>
                            <td>
                                <button type="button" onclick="_delete('type', <%= t.id %>)">
                                    Delete
                                </button>
                            </td>
                        </tr>
                    <% } %>
                <% } %>
                </tbody>
            </table>
            <br />
            <asp:Label ID="TypeError" runat="server" Text="&nbsp;"></asp:Label>
            <br />
        </div>
        <div class="table-container">
            <div>
                <h2>Brand</h2>
                <a href="Add/Brand.aspx">
                    <button type="button">
                        Add
                    </button>
                </a>
            </div>
            <table>
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Rating</th>
                    <th></th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                <% if (Brands.Count > 0) { %>
                    <% foreach (var b in Brands) { %>
                        <tr>
                            <td><%= b.id %></td>
                            <td><%= b.name%></td>
                            <td><%= b.rating%></td>
                            <td>
                                <a href="Update/Brand.aspx?id=<%= b.id %>">
                                    <button type="button">
                                        Update
                                    </button>
                                </a>
                            </td>
                            <td>
                                <button type="button" onclick="_delete('brand', <%= b.id %>)">
                                    Delete
                                </button>
                            </td>
                        </tr>
                    <% } %>
                <% } %>
                </tbody>
            </table>
            <br />
            <asp:Label ID="BrandError" runat="server" Text="&nbsp;"></asp:Label>
            <br />
        </div>
    </main>
</asp:Content>
