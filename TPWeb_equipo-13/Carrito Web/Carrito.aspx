<%@ Page Title="Carrito de compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Carrito_Web.Carrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main style="margin-left: 20rem; margin-right: 10rem;">
        <div class="container-fluid d-flex flex-wrap justify-content-start">
            <asp:Repeater runat="server" ID="repCarrito">
                <ItemTemplate>
                    <div class="card" style="width: 18rem; margin: 3.5rem;">
                        <img src="<%#Eval("imagenes[0]") %>" class="card-img-top" alt="..." onerror="this.onerror=null;this.src='https://www.shutterstock.com/image-vector/image-icon-600nw-211642900.jpg';" />
                        <div class="card-body border-top">
                            <h5 class="card-title text-center">
                                <a style="text-decoration: none" href="DetalleArticulo.aspx?id= <%#Eval("Id")%>"><%#Eval("Nombre")%></a>
                            </h5>
                            <p class="card-text text-center"><%#Eval("Precio")%></p>
                            <p class="card-text text-center">Cantidad: <%#Eval("Cantidad")%></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="text-center">
            <a class="btn btn-primary btn-lg" href="/Default.aspx" role="button">Seguir comprando</a>
            <button class="btn btn-secondary btn-lg">Ir a pagar</button>

        </div>

    </main>
</asp:Content>
