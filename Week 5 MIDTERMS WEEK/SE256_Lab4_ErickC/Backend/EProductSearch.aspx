<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EProductSearch.aspx.cs" Inherits="SE256_Activity_ErickC.Backend.EProductSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Product Search</h1>

    <p>Optional Search Criteria to narrow search results</p>

    <p>

        Brand Name: <asp:TextBox ID="txtBrand" runat="server" Columns="30" />

        &nbsp; &nbsp; &nbsp; &nbsp;

        Model: <asp:TextBox ID="txtModel" runat="server" Columns="30" />

    </p>

    <br />

    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />

    <br />
    <br />

    <!-- Datagrid is a built in tool that allows us to connect a DataSet's copy of a table to the DataGrid, and display results in something that looks like an Excel spreadsheet. The HyperLinlk will pass the ID of Ebook to the Ebook Manager in order to enable that page to pull up all the data on the one book chosen via the link-->

    <!--In VS2019, they changed BoundField to BoundColumn and HyperLinkField to HyperLinkColumn (Field -> Column)-->
    <!--Also, DataNavigateURLField became singular, with the removal of the 's' at the end-->

    <asp:DataGrid ID="dgResults" runat="server" AutoGenerateColumns="false" >

        <Columns>

            <asp:BoundColumn DataField="Brand" HeaderText="Brand" />
            <asp:BoundColumn DataField="Model" HeaderText="Model" />
            <asp:BoundColumn DataField="Price" HeaderText="Price" />
            <asp:BoundColumn DataField="Quantity" HeaderText="Quantity" />
            <asp:HyperLinkColumn Text="Edit" DataNavigateUrlFormatString ="~/Backend/ProductMgr.aspx?ProductID={0}" DataNavigateUrlField="ProductID" />

        </Columns>

    </asp:DataGrid>

</asp:Content>
