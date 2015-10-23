<%@ Page Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Road.aspx.cs" Inherits="WebUI.GuidesPages.Road" %>

<asp:Content ContentPlaceHolderID="Main" runat="server">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Справочник дорог</title>
    <script type="text/javascript" src="../Scripts/JQuery-min.js"></script>
    <script type="text/javascript" src="../Scripts/ClickActive.js"></script>
</head>
<body>
    <asp:ObjectDataSource 
        ID="RoadODS" 
        runat="server" 
        SelectMethod="GetRoadGuide" 
        TypeName="DigDes.DSchool.SUPS.DataAccess.PresentData.RoadGuidePresent"
        >

    </asp:ObjectDataSource>
</body>
</html>
    <div class="nav-sub-menu">
        <ul class="sub-menu-guides">
            <li>
                <a href="#" class="active">Грузы</a>
            </li>
            <li>
                <a href="GuidesPages/Road.aspx">Дорога</a>
            </li>
            <li>
                <a href="#">Станции</a>
            </li>
            <li>
                <a href="#">Арендаторы</a>
            </li>
        </ul>
    </div>

    <asp:GridView 
        ID="RoadGridView" 
        runat="server" 
        AutoGenerateColumns="False" 
        DataSourceID="RoadODS"
        DataKeyNames="Road_ID"
        >
        <Columns>
            <asp:BoundField DataField="Road_ID" HeaderText="Road_ID" Visible="false" SortExpression="Road_ID" />
            <asp:BoundField DataField="Name" HeaderText="Дорога" SortExpression="Name" />
            <asp:BoundField DataField="Mnemocode" HeaderText="Мнемокод" SortExpression="Mnemocode" />
            <asp:BoundField DataField="Code" HeaderText="Код" SortExpression="Code" />
        </Columns>
    </asp:GridView>
    </asp:Content>
