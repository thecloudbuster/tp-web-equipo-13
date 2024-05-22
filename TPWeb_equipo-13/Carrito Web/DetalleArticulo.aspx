<%@ Page Title="COMPRAR" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Carrito_Web.DetalleArticulo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Product section-->
        <section class="py-5">
            <div class="container px-4 px-lg-5 my-5">
                <div class="row gx-4 gx-lg-5 align-items-center">
                    <div class="col-md-6">
                        <div id="carouselExampleIndicators" class="carousel slide">
                            <!--Imagen del carousel -->
                            <div class="carousel-inner">
                                <%
                                    foreach (string img in Session["listaImagenes"] as IEnumerable<string>)
                                    {
                                %>

                                <div class="carousel-item active">
                                    <img src="<%= img %>" class="d-block w-100" alt="...">
                                </div>

                                <%
                                    }
                                %>
                            </div>
                            <!--Botones del carousel -->
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                        <!--Bloque con info y boton -->
                        <div class="col-md-6">
                            <asp:Label ID="lblNombre" CssClass="display-5 fw-bolder" runat="server"></asp:Label>
                            <!--Info -->
                            <div class="fs-5 mb-5">
                                <span></span>
                                <asp:Label ID="lblDesc" CssClass="lead" runat="server"></asp:Label>
                                <asp:Label ID="lblMarca" CssClass="lead" runat="server"></asp:Label>
                                <asp:Label ID="lblCategoria" CssClass="lead" runat="server"></asp:Label>
                                <asp:Label ID="lblPrecio" CssClass="lead" runat="server"></asp:Label>
                            </div>
                            <!--Stock y boton de Agregar al Carrito -->
                            <div class="d-flex">
                                <input class="form-control text-center me-3" id="inputQuantity" type="num" value="1" style="max-width: 3rem" />
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar al carrito" OnClick="btnAgregar_Click" CssClass="btn btn-outline-dark flex-shrink-0" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </section>
    </main>
</asp:Content>
