<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCalc_EC.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <h1>Welcome to The Calculator</h1>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtLCD" runat="server"></asp:TextBox>
            
            <asp:Label ID="lblmem" runat="server" Text="|"></asp:Label>
            &nbsp;<asp:Label ID="lblsymbol" runat="server" Text="|"></asp:Label>
            
            <br /> 
            <asp:Label ID="memory" runat="server" Text="Memory:"></asp:Label>

            <br />
            <asp:Button ID="btn1" runat="server" Text="1" OnClick="btn1_Click" width =" 30px"/>
            &nbsp;<asp:Button ID="btn2" runat="server" Text="2" OnClick="btn2_Click" width =" 30px"/>
            &nbsp;<asp:Button ID="btn3" runat="server" Text="3" OnClick="btn3_Click" width =" 30px"/>
            &nbsp;<asp:Button ID="btnDivis" runat="server" Text="/"  OnClick ="btnOperand_Click" width =" 30px"/>
            
            <br />

            <asp:Button ID="btn4" runat="server" Text="4" OnClick="btnNumber_Click" width =" 30px" />
            &nbsp;<asp:Button ID="btn5" runat="server" Text="5" OnClick="btnNumber_Click" width =" 30px"/>
            &nbsp;<asp:Button ID="btn6" runat="server" Text="6" OnClick="btnNumber_Click" width =" 30px"/>
            &nbsp;<asp:Button ID="btnMulti" runat="server" Text="*" OnClick="btnOperand_Click" width =" 30px" />

            <br />

            <asp:Button ID="btn7" runat="server" Text="7" OnClick="btnNumber_Click" width =" 30px"/>
            &nbsp;<asp:Button ID="btn8" runat="server" Text="8" OnClick="btnNumber_Click" width =" 30px"/>
            &nbsp;<asp:Button ID="btn9" runat="server" Text="9" OnClick="btnNumber_Click" width =" 30px"/>
            &nbsp;<asp:Button ID="btnSub" runat="server" Text="-"  OnClick="btnOperand_Click" width =" 30px"/>
            
            
            <br />

            <asp:Button ID="btn0" runat="server" Text="0" OnClick="btnNumber_Click" width =" 30px"/>
            &nbsp;<asp:Button ID="btnDeci" runat="server" Text="." OnClick="btnNumber_Click"  width =" 30px"/>
            &nbsp;<asp:Button ID="btnEquals" runat="server" Text="=" OnClick="btnEquals_Click"  width =" 30px"/>
            &nbsp;<asp:Button ID="btnPlus" runat="server" Text="+" OnClick="btnOperand_Click"  width =" 30px"/>

            &nbsp;<asp:Button ID="btnClr" runat="server" Text="Clr" onClick="btnClr_Click" width =" 30px"/>

            <br />

            
           
            
            
            
        </div>
        
    </form>
</body>
</html>
