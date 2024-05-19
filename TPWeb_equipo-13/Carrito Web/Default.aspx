<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Shop Homepage - Start Bootstrap Template</title>
        <!-- Favicon-->
        <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
        <!-- Bootstrap icons-->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css" rel="stylesheet" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="css/styles.css" rel="stylesheet" />
    </head>
    <body>

        <!-- Header-->
        <header class="bg-info text-white">
            <div class="container px-4 px-lg-2 my-2">
                <div class="text-center text-white">
                    <h1 class="display-8 fw-bolder">Trece tu tienda... siempte</h1>
                </div>
            </div>
        </header>
        <!-- Section-->
        <section class="py-5">
            <div class="container px-4 px-lg-5 mt-5">
                <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center">
                    <%
                        foreach (dominio.Articulo art in Session["listaArticulo"] as IEnumerable<dominio.Articulo>)
                        {
                            string defaultImageUrl = "https://www.shutterstock.com/image-vector/image-icon-600nw-211642900.jpg";
                            string imagen = art.imagenes != null && art.imagenes.Count > 0 ? art.imagenes[0] : defaultImageUrl;%>
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
        <!-- Bootstrap core JS-->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
        <!-- Core theme JS-->
        <script src="js/scripts.js"></script>
    </body>
    </html>



</asp:Content>

