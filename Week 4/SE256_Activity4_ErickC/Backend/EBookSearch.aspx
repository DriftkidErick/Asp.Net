<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EBookSearch.aspx.cs" Inherits="SE256_Activity_ErickC.Backend.EBookSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1> EBook Search</h1>

    <p>Optional Search Criteria to narrow search results</p>

    <p>
        Book Title: <asp:TextBox ID="txtTitle" runat="server" Columns="30" />
        &nbsp;&nbsp;&nbsp;&nbsp;

        Author's Last Name: <asp:TextBox ID="txtAuthorLast" runat="server" Columns="30" />
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
            <asp:BoundColumn DataField="Title" HeaderText="Book Title" />
            <asp:BoundColumn DataField="AuthorFirst" HeaderText="Author's First Name" />
            <asp:BoundColumn DataField="AuthorLast" HeaderText="Author's Last Name" />
            <asp:BoundColumn DataField="DatePublished" HeaderText="Date Published" />

            <asp:HyperLinkColumn Text="Edit" DataNavigateUrlFormatString="~/Backend/EBookMgr.aspx?EBookID={0}" DataNavigateUrlField="EBookID" />

        </Columns>

    </asp:DataGrid>

    <br /><br />
    <br /><br />

    <h1>Another output option: Creating our own output while looping through records using a repeater and itemTemplate</h1>
    <asp:Repeater ID="rptSearch" runat="server" >

        <HeaderTemplate>
            <asp:Label ID="lblHeader" runat="server" Text="Your results..." />
        </HeaderTemplate>

        <ItemTemplate>
            <br />
            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'/>
            <asp:Label ID="lblAuthorFirst" runat="server" Text='<%# Eval("AuthorFirst") %>'/>
            <asp:Label ID="lblAuthorLast" runat="server" Text='<%# Eval("AuthorLast") %>'/>
            <asp:Label ID="lblDatePublished" runat="server" Text='<%# Eval("DatePublished") %>'/>

            <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit" NavigateUrl='<%# Eval("EBookID", "EBookMgr.aspx?EBookID={0}") %>' />
                <br />
        </ItemTemplate>

    </asp:Repeater>

    <br /><br />
    <br /><br />

    <h1>Another Output option: Creating our own output via a method that loops through each record and developing ALL the HTML</h1>

    <asp:Literal ID="litResults" runat="server" Text="" />

</asp:Content>
