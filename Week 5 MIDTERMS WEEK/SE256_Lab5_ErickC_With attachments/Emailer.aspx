<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Emailer.aspx.cs" Inherits="SE256_Activity_ErickC.Emailer" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    
     <div style="text-align:center;">
        <table id="emailer">


            <tr>
                <th>To:</th>
                <td><asp:TextBox ID="txtTo" runat="server" Columns="35" /></td>
            </tr>

            <tr>
                <th>From:</th>

                <td><asp:TextBox ID="txtFrom" runat="server" Columns="35" /> 

                    <asp:RequiredFieldValidator ID="rfvFrom" Display="Dynamic" runat="server" ControlToValidate="txtFrom" Text="*"  />
                    <asp:RegularExpressionValidator ID="revFrom" Display="Dynamic" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtFrom" ErrorMessage="Input valid email address!"  />
                </td>

            </tr>

            <tr>
                <th>Subject:</th>
                <td><asp:TextBox ID="txtSubject" runat="server" Columns="60" /> </td>
            </tr>

            <tr>
                <th>Your Message:</th>
                <td><asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Columns="75" Rows="6"></asp:TextBox></td>
            </tr>

            <tr>
                <th>Image Attachment</th>
               
                <td>
                    <asp:FileUpload ID="fuImgFile" runat="server" />
                    &nbsp;&nbsp;
                    

                    <br />

                    <asp:RegularExpressionValidator ID="regexValidator" runat="server" 
                        ControlToValidate="fuImgFile" 
                        ErrorMessage="Only Images and PDF's are allowed! Please choose the correct File type!!"
                        ValidationExpression="^.*\.(jpg|jpeg|png|gif|tif|pdf)$" ></asp:RegularExpressionValidator>
                        
                    <asp:Label ID="lblUploadFeedback" runat="server" />
                    <br />
                    <asp:Label ID="lblFileName" runat="server" Visible="false" />
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="Send Email" OnClick="btnSubmit_Click" /></td>
            </tr>
        </table>

        <asp:Label ID="lblSent" runat="server"></asp:Label>


    </div>
</asp:Content>
