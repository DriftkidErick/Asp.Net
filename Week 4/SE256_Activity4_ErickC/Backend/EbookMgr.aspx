<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EbookMgr.aspx.cs" Inherits="SE256_Activity_ErickC.Backend.EbookMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
    <a href="~/Backend/ControlPanel.aspx" runat="server">Return to Control Panel</a>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <!--This is for later use-->
        
        <tr>
            <td>EBook Id</td>
            <td><asp:Label ID="lblEBook_ID" runat="server" /></td>
        </tr>

        <!--Book Title -->
        <tr>
            <td>Book Title</td>
            <td><asp:TextBox ID="txtTitle" runat="server" MaxLength="255" /> </td>
        </tr>

        <!--Author Info-->
        <tr>
            <td>Author's First Name</td>
            <td><asp:TextBox ID="txtAuthorFirst" runat="server" MaxLength="20" /></td>
        </tr>

        <tr>
            <td>Author's Last Name</td>
            <td><asp:TextBox ID="txtAuthorLast" runat="server" MaxLength= "40" /></td>
        </tr>

        <tr>
            <td>Author's Email</td>
            <td><asp:TextBox ID="txtAuthorEmail" runat="server" MaxLength="20" /></td>
        </tr>

        <!-- Date Published-->
        <tr>
            <td>Date Published</td>
            <td><asp:Calendar ID="calDatePublished" runat="server" /></td>
        </tr>

        <!-- # of pages -->
        <tr>
            <td>Number of Pages</td>
            <td><asp:TextBox ID="txtPages" runat="server" MaxLength="5"/></td>
        </tr>

        <!--Price-->
        <tr>
            <td>Price Per Copy</td>
            <td><asp:TextBox ID="txtPrice" runat="server" MaxLength="10" /></td>
        </tr>

        <!-- Bookmark Page-->
        <tr>
            <td>Bookmark Page</td>
            <td><asp:TextBox ID="txtBookmarkPage" runat="server" MaxLength="5" /></td>
        </tr>

        <!--Date Rental Expires-->
        <tr>
            <td>Date Rental Expires</td>
            <td><asp:Calendar ID="calRentalExpires" runat="server" /></td>
        </tr>

    </table>

    <!--Button to add a book to the DB.. but right now, we just want to see if we have it-->
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add" onClick="btnAdd_Click"/>
    
    &nbsp;&nbsp;&nbsp;
    <!--Update Button-->
    <asp:Button ID="btnUpdate" runat="server" Text="Update" onClick="btnUpdate_Click"/>
    &nbsp;&nbsp;&nbsp;

    <!--Delete Button-->
    <asp:Button ID="btnDelete" runat="server" Text="Delete" onClick="btnDelete_Click"/>

    &nbsp;&nbsp;&nbsp;
    <!--Cancel Button-->
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" onClick="btnCancel_Click"/>


    <!-- Feedback lable is intended to help us see information, such as errors or confirmation of something -->
    <br />
    <asp:Label ID="lblFeeback" runat="server" />

</asp:Content>
