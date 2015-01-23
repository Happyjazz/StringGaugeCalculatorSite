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
            <div id="bassTension">
                <asp:Label CssClass="leftLabels" ID="labelTension" Text="Tension" runat="server" />
                <asp:DropDownList ID="ddTension" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddTension_SelectedIndexChanged">
                    <asp:ListItem Text="Custom" Value="0"/>
                    <asp:ListItem Text="Hard" Value="45"/>
                    <asp:ListItem Text="Medium" Value="40"/>
                    <asp:ListItem Text="Soft" Value="35"/>
                </asp:DropDownList>
                <asp:TextBox ID="txtTension" runat="server">Tension in pounds</asp:TextBox>
            </div>
            
            <div id="bassScale">
                <asp:Label CssClass="leftLabels" ID="labelScale" Text="Scale" runat="server"></asp:Label>
                <asp:RadioButton AutoPostBack="True" ID="radioStandardScale" Text="Standard" runat="server" GroupName="scaleType" Checked="True" OnCheckedChanged="radioStandardScale_CheckedChanged"/>
                <asp:RadioButton AutoPostBack="True" ID="radioFannedFret" Text="Fanned frets" runat="server" GroupName="scaleType" OnCheckedChanged="radioFannedFret_CheckedChanged"/>
                <br/>
                <asp:TextBox ID="txtScale" runat="server">34</asp:TextBox>
                <asp:TextBox ID="TxtScaleMax" runat="server" Visible="False">34</asp:TextBox>
            </div>
            <hr/>

            <div id="bassStrings">
                <div class="stringDiv">
                    <asp:Label CssClass="leftLabels" ID="labelString6" runat="server">String 6</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString6" runat="server" OnSelectedIndexChanged="ddString6_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq6" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight6" runat="server">Unit Weight</asp:TextBox>
                </div>
                <div class="stringDiv">
                    <asp:Label CssClass="leftLabels" ID="labelString5" runat="server">String 5</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString5" runat="server" OnSelectedIndexChanged="ddString5_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq5" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight5" runat="server">Unit Weight</asp:TextBox>
                </div>
                <div class="stringDiv">
                    <asp:Label CssClass="leftLabels" ID="labelString4" runat="server">String 4</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString4" runat="server" OnSelectedIndexChanged="ddString4_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq4" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight4" runat="server">Unit Weight</asp:TextBox>
                </div>
                <div class="stringDiv">
                    <asp:Label CssClass="leftLabels" ID="labelString3" runat="server">String 3</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString3" runat="server" OnSelectedIndexChanged="ddString3_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq3" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight3" runat="server">Unit Weight</asp:TextBox>
                </div>
                <div class="stringDiv">
                    <asp:Label CssClass="leftLabels" ID="labelString2" runat="server">String 2</asp:Label>
                    <asp:DropDownList CssClass="ddStringFreq" AutoPostBack="True" ID="ddString2" runat="server" OnSelectedIndexChanged="ddString2_SelectedIndexChanged" />
                    <asp:TextBox CssClass="txtStringFreq" ID="txtStringFreq2" runat="server">Frequenzy in Mhz</asp:TextBox>
                    <asp:TextBox CssClass="txtStringFreq" ID="txtUnitWeight2" runat="server">Unit Weight</asp:TextBox>
                </div>
                <div class="stringDiv">
                    <asp:Label CssClass="leftLabels" ID="labelString1" runat="server">String 1</asp:Label>
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
