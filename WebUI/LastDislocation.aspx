<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LastDislocation.aspx.cs" 
    Inherits="DigDes.DSchool.SUPS.WebUI.Main" %>


<asp:Content runat="server" ID="MainDislocationsContent" ContentPlaceHolderID="Main">

    <html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Дислокация вагонов</title>
</head>
<body>
    <div class="nav-sub-menu">
        <ul id="sub-menu-disloc">
            <li>
                <a href="#" class="active">Последняя дислокация</a>
            </li>
            <li>
                <a href="#">История дислокации</a>
            </li>
            <li>
                <a href="#">Критические ситуации</a>
            </li>
        </ul>
    </div>

            <asp:ObjectDataSource 
                ID="ObjectDataSource1" 
                runat="server" 
                SelectMethod="GetDislocations" 
                TypeName="DigDes.DSchool.SUPS.DataAccess.PresentData.PresentData">
            </asp:ObjectDataSource>

            <asp:GridView 
                ID="GridView1" 
                runat="server" 
                AutoGenerateColumns="False" 
                DataSourceID="ObjectDataSource1"
                DataKeyNames="carNumber"
                EmptyDataText =" "
                GridLines ="Horizontal"
                CssClass="grid-rows"
                SelectedRowStyle-CssClass="grid-selected-rows"
                HeaderStyle-CssClass="grid-header" AllowPaging="True"
                >
                <Columns>
                    <asp:ButtonField ImageUrl="~/Images/Untitled-1_r7_c4.jpg"></asp:ButtonField>
                    <asp:BoundField DataField="cargoName" HeaderText="Груз" SortExpression="cargoName" />
                    <asp:BoundField DataField="carNumber" HeaderText="Номер вагона" SortExpression="carNumber" />
                    <asp:BoundField DataField="weight" HeaderText="Вес" SortExpression="weight" />
                    <asp:BoundField DataField="receiverCode" HeaderText="Грузополучатель" SortExpression="receiverCode" />
                    <asp:BoundField DataField="carType" HeaderText="Тип вагона" SortExpression="carType" />
                    <asp:BoundField DataField="operationName" HeaderText="Операция" SortExpression="operationName" />
                    <asp:BoundField DataField="arriveStation" HeaderText="Станция назначения" SortExpression="arriveStation" />
                    <asp:BoundField DataField="operationStation" HeaderText="Станция операции" SortExpression="operationStation" />
                    <asp:BoundField DataField="departStation" HeaderText="Станция отправления" SortExpression="departStation" />
                    <asp:BoundField DataField="operationDate" HeaderText="Дата операции" SortExpression="operationDate" />
                    <asp:BoundField DataField="operationYear" HeaderText="Год операции" SortExpression="operationYear" />
                    <asp:BoundField DataField="operationTime" HeaderText="Время операции" SortExpression="operationTime" />
                    <asp:BoundField DataField="deliveryRoad" HeaderText="Дорога сдачи" SortExpression="deliveryRoad" />
                    <asp:BoundField DataField="receiptRoad" HeaderText="Дорога приема" SortExpression="receiptRoad" />
                    <asp:BoundField DataField="trainIndex" HeaderText="Индекс поезда" SortExpression="trainIndex" />
                    <asp:BoundField DataField="trainNumber" HeaderText="Номер поезда" SortExpression="trainNumber" />
                </Columns>

<HeaderStyle CssClass="grid-header"></HeaderStyle>

<RowStyle CssClass="grid-rows"></RowStyle>

<SelectedRowStyle CssClass="grid-selected-rows"></SelectedRowStyle>
            </asp:GridView>
        
</body>
</html>
    </asp:Content>
