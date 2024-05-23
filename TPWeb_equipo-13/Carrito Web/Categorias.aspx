<%@ Page Title="Productos por Categoría" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Carrito_Web.Productos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Section-->
        <section class="py-5">
            <div class="container px-4 px-lg-5 mt-5">
                <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center">
                    <%
                        foreach (dominio.Articulo art in Session["listaProdCategoria"] as IEnumerable<dominio.Articulo>)
                        {
                            string defaultImageUrl = "https://www.shutterstock.com/image-vector/image-icon-600nw-211642900.jpg";
                            string imagen = art.imagenes != null && art.imagenes.Count > 0 ? art.imagenes[0] : defaultImageUrl;
                    %>
                    <div class="card" style="width: 18rem;">
                        <img src="<%= imagen %>" class="card-img-top" alt="..." onerror="this.onerror=null;this.src='<%= defaultImageUrl %>';" />
                        <div class="card-body">
                            <h5 class="card-title">
                                <a href="DetalleArticulo.aspx?id= <%: art.Id %>"><%: art.Nombre %></a>
                            </h5>
                            <p class="card-text"><%: art.Precio %></p>

                        </div>
                    </div>
                    <%
                        }
                    %>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
