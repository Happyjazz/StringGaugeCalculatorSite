<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StringCalc.aspx.cs" Inherits="StringCalc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Styles/StyleSheet.css" />
</head>
<body>
    <form id="stringCalc" runat="server">
        <div id="wrapper">
            <div id="header">
            </div>
            <div id="bassSettings">
                <asp:TextBox ID="txtScale" runat="server">Scale in inches</asp:TextBox>
                <asp:TextBox ID="txtTension" runat="server">Tension in pounds</asp:TextBox>
            </div>

            <div id="bassStrings">
                <div class="stringDiv">
                    <asp:Label ID="labelString6" runat="server">String 6</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString6" runat="server" OnSelectedIndexChanged="ddString6_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq6" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight6" runat="server">Unit Weight</asp:TextBox>
                </div>
                <div class="stringDiv">
                    <asp:Label ID="labelString5" runat="server">String 5</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString5" runat="server" OnSelectedIndexChanged="ddString5_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq5" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight5" runat="server">Unit Weight</asp:TextBox>
                </div>
                <div class="stringDiv">
                    <asp:Label ID="labelString4" runat="server">String 4</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString4" runat="server" OnSelectedIndexChanged="ddString4_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq4" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight4" runat="server">Unit Weight</asp:TextBox>
                </div>
                <div class="stringDiv">
                    <asp:Label ID="labelString3" runat="server">String 3</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString3" runat="server" OnSelectedIndexChanged="ddString3_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq3" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight3" runat="server">Unit Weight</asp:TextBox>
                </div>
                <div class="stringDiv">
                    <asp:Label ID="labelString2" runat="server">String 2</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString2" runat="server" OnSelectedIndexChanged="ddString2_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq2" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight2" runat="server">Unit Weight</asp:TextBox>
                </div>
                <div class="stringDiv">
                    <asp:Label ID="labelString1" runat="server">String 1</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString1" runat="server" OnSelectedIndexChanged="ddString1_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq1" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight1" runat="server">Unit Weight</asp:TextBox>
                </div>
            </div>
            <div id="buttons">
                <asp:Button ID="buttonCalculate" runat="server" OnClick="buttonCalculate_Click" Text="Calculate" />
                <asp:Button ID="buttonReset" runat="server" Text="Reset" OnClick="buttonReset_Click" />
            </div>


        </div>
    </form>
</body>
</html>
