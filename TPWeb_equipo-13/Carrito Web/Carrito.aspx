<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Carrito_Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2>pagina del carrito</h2>
        <asp:GridView Id="dgvArticulos" runat="server" CssClass="table"></asp:GridView>
    </main>
</asp:Content>
