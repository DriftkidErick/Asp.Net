﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="SE256_Activity_ErickC.Backend.ControlPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
    <div>

    </div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Control Panel</h2>
        <table>
            <tr>
                <td><a href="EBookMgr.aspx" runat="server">Add an Ebook</a></td>
            </tr>

            <tr>
                <td><asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogOut_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
