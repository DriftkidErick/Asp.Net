﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SE256_Activity_ErickC._Default" %>

<%--Content is where wew code the HTML/FORM info for this specific page and will be placed in "MainContent" Placeholder --%>
<%--Notice that there is no HTML nor Form open/close tages here... that is all in the master and we are pasting this info in Content(metaphor) --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- I COMMENTED THIS OUT BUT LEFT IT IN FOR FUTURE REFERENCE
    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>

        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>

        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>

    </div>
        --%>

    <div>
        <p>Dont forget to wash your hands</p>
    </div>
</asp:Content>
<%--Close This Content --%>

    <%--Placeholder for breakinng new content. If there is no breaking news, clear the centent between the DIV tags --%>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
    <div>
        <h1>Breaking News:</h1>
        <p>After sharing this aweful brand of humor for decades, finds out that his jokes are not funny. Teacher shocked and amazed. His family and students request his face be the image next to Dad-Jokes if it is added to the dictionary.
        </p>
    </div>
<%--Close This Content --%>
</asp:Content>