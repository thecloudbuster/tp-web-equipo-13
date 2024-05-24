<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main style="margin-left: 20rem; margin-right: 10rem;">
            <div class="container-fluid d-flex flex-wrap justify-content-start">
                <asp:Repeater runat="server" ID="repCard">
                    <ItemTemplate>
                        <div class="card" style="width: 18rem; margin: 3.5rem;">
                            <img src="<%#Eval("imagenes[0]") %>" class="card-img-top" alt="..." onerror="this.onerror=null;this.src='https://www.shutterstock.com/image-vector/image-icon-600nw-211642900.jpg';" />
                            <div class="card-body border-top">
                                <h5 class="card-title text-center">
                                    <a style="text-decoration: none" href="DetalleArticulo.aspx?id= <%#Eval("Id")%>"><%#Eval("Nombre")%></a>
                                </h5>
                                <p class="card-text text-center"><%#Eval("Precio")%></p>
                                <div class="text-center">
                                    <asp:Button ID="btnAgregar" class="btn btn-primary" OnClick="btnAgregar_Click" runat="server" Text="Agregar al carrito" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId"/>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
    </main>
</asp:Content>

