<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SE256_Activity_ErickC._Default" %>

<%--Content is where wew code the HTML/FORM info for this specific page and will be placed in "MainContent" Placeholder --%>
<%--Notice that there is no HTML nor Form open/close tages here... that is all in the master and we are pasting this info in Content(metaphor) --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="jumbotron" style="background-image:url(images/tester2.jpg);background-repeat:no-repeat; background-size:cover; color:white;">
        <h1>CK's Wheels and Deals</h1>
        <p class="lead">Welcome to Ck's Wheels and Deals. Home for all your aftermarket needs.</p>
        <p><a href="..." class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <hr />

    <div class="row">
        <div class="col-md-4">
            <h2>About Us</h2>
            <p>
                Learn more about us and why we started!
            </p>
            <p>
                <a class="btn btn-default" href="https://localhost:44384/About">Learn more &raquo;</a>
            </p>
        </div>


        <div class="col-md-4">
            <h2>Products</h2>
            <p>
                Check out our products page. Here we upload new items daily from wheels, tires and suspension to perfomace parts.
            </p>
            <p>
                <a class="btn btn-default" href="https://localhost:44384/Products">Learn more &raquo;</a>
            </p>
        </div>

        <div class="col-md-4">
            <h2>Contact</h2>
            <p>
                Contact us over and questions comments or concerns.
            </p>
            <p>
                <a class="btn btn-default" href="https://localhost:44384/Contact">Learn more &raquo;</a>
            </p>
        </div>

    </div>

       
</asp:Content>
<%--Close This Content --%>

