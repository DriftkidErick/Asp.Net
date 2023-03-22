<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SE256_Activity_ErickC.About" %>


<%--PlaceHolder for breaking news content. If theres no breaking news, clear the content between the DIV tags --%>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
    <div>

    </div>
<%--Close This Content --%>
</asp:Content>








<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center;">
        <h2>About Us</h2>
        <h3>Welcome to our About Us page!</h3>
        <p>We are a team of car enthusiasts who are passionate about providing high-quality car parts to fellow enthusiasts. We understand the importance of having the right parts for your vehicle, and we are dedicated to sourcing the best products at the most affordable prices.</p>
        <p>Our team has a wealth of experience in the automotive industry, and we have built relationships with some of the top manufacturers and suppliers in the business. This allows us to offer a wide range of products at competitive prices, so you can keep your car running at its best without breaking the bank.</p>
        <p>We understand that finding the right parts for your vehicle can be a daunting task, which is why we have made it our mission to make the process as easy and hassle-free as possible. Our website is designed to be user-friendly and intuitive, so you can quickly find the parts you need.</p>
        <p>In addition to our great selection of parts and competitive prices, we also pride ourselves on our excellent customer service. Our team is always on hand to answer any questions you may have, and we are committed to providing the best possible service to our customers.</p>
        <p>Thank you for choosing CK's Wheels and Deals as your go-to source for car parts. We look forward to serving your automotive needs and helping you get the most out of your vehicle.</p>
    </div>
</asp:Content>
