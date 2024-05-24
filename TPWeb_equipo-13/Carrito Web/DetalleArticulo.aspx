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

                        <div class="card-body border-top text-center justify-content-center">
                            <h5 class="card-title text-center justify-content-center">
                                <asp:Label ID="lblNombre" CssClass="display-5 fw-bolder" runat="server"></asp:Label>
                            </h5>
                            <span></span>
                            <asp:Label ID="lblDesc" CssClass="lead" runat="server"></asp:Label>
                            <asp:Label ID="lblPrecio" CssClass="lead" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
