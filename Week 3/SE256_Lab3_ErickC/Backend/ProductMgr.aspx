<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductMgr.aspx.cs" Inherits="SE256_Activity_ErickC.Backend.ProductMgr" %>


<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>

        <tr> <!--Product ID-->
            <td>Product ID</td>
            <td><asp:Label ID="lblProduct_ID" runat="server" /></td>
        </tr>



        <tr>
            <td>Brand</td>
            <td><asp:TextBox ID="txtBrand" runat="server" MaxLength="300" /></td>
        </tr>

        <tr>
            <td>Model</td>
            <td><asp:TextBox ID="txtModel" runat="server" MaxLength="50" /></td>

        </tr>

        <tr>
            <td>Category</td>
            <td><asp:TextBox ID="txtCategory" runat="server" MaxLength="75" /></td>

        </tr>

        <tr>
            <td>Description</td>
            <td><asp:TextBox ID="txtDescription" mode="multiline" runat="server" MaxLength="1000"/></td>
        </tr>

        <tr>
            <td>Price</td>
            <td>$<asp:TextBox ID="txtPrice" runat="server" MaxLength="10" /></td>
        </tr>

        <tr>
            <td>Quantity In Stock</td>
            <td><asp:TextBox ID="txtQuantity" runat="server" MaxLength="10" /></td>
        </tr>

        <tr>
            <td>Weight</td>
            <td><asp:TextBox ID="txtWeight" runat="server" MaxLength="10" /></td>
        </tr>

        <tr>
            <td>Release Date</td>
            <td><asp:Calendar ID="calReleaseDate" runat="server" /></td>
        </tr>

    </table>
    
    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />

    <br />

    <asp:Label ID="lblFeedback" runat="server" />

</asp:Content>
