<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SE256_Activity_ErickC.JokeBookUpdates" %>


<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
    <div>
        <h1>Lastest Ck Wheels and Deals News:</h1>
        <p>
            *Make Sure to check in daily for any updates on new and used parts*
        </p>
    </div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background-image:url(images/nsxtest.jpg);background-repeat:no-repeat; background-size:cover; color:white;"">
        <h1>CK's Wheels and Deals</h1>
        <p class="lead">Welome to our products page. Make sure to check in daily for new / used items.</p>
    </div>

    <hr />

    <div class="row">
        <div class="col-md-4">
            <div style="text-align:center;">
                <h2>Blitz 03</h2>
                <img src="images/blitz03.jpg" style="width:70%;" />
                <p>
                    Here we have the legendary Blitz 03 wheel.
                </p>
                <p>Sets starting at $4,500</p>
                <p>
                    <a class="btn btn-default" href="...">Learn more &raquo;</a>
                </p>
            </div>
        </div>

       <div class="col-md-4">
            <div style="text-align:center;">
                <h2>Desmond Regamaster</h2>
                <img src="images/regas.jpg" style="width:70%;" />
                <p>
                    Here we have the highperfomance Desmond Regamaster wheel.
                </p>
                <p>Sets starting at $3,000</p>
                <p>
                    <a class="btn btn-default" href="...">Learn more &raquo;</a>
                </p>
            </div>
        </div>

        <div class="col-md-4">
            <div style="text-align:center;">
                <h2>TE37-Sl</h2>
                <img src="images/te37hehe.jpg" style="width:47%;" />
                <p>
                    Here we have the legendary forged Volk TE37 wheel in the Volk Mag Blue color.
                </p>
                <p>Sets starting at $3,500</p>
                <p>
                    <a class="btn btn-default" href="...">Learn more &raquo;</a>
                </p>
            </div>
        </div>

    </div>
</asp:Content>
