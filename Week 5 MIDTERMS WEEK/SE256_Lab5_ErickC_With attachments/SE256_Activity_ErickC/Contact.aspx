<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SE256_Activity_ErickC.Contact" %>

<%-- PlaceHolder for the breaking new content. If there is no breaking news, clear the content between the div tags--%>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
    <div>

    </div>
<%--Close This Content --%>
</asp:Content>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center;">
        <h2><%: Title %>.</h2>
        <h4>For inquiries, price quotes, order placement, and any questions, please email info@ckswheels.com</h4>
        <address>
            One Auto Street<br />
            Radiator Springs, AZ 98052-6399<br />
            <abbr title="Phone">Phone:</abbr>
            (401) 111-1313
        </address>

        <address>
            <strong>Support:</strong>   <a href="...">info@ckswheels.com</a><br />
            <strong>Marketing:</strong> <a href="...">marketing@ckswheels.com</a>
        </address>
    </div>
</asp:Content>
