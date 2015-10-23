<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" ValidateRequest="false"
    CodeBehind="Cargo.aspx.cs" EnableEventValidation="false" Inherits="DigDes.DSchool.SUPS.WebUI.Guides" %>

<asp:Content ContentPlaceHolderID="Main" ID="CargoGuide" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="nav-sub-menu">
        <ul class="sub-menu-guides">
            <li><a class="active" href="#">Грузы</a> </li>
            <li><a href="#">Дорога</a> </li>
            <li><a href="#">Станции</a> </li>
            <li><a href="#">Арендаторы</a> </li>
        </ul>
    </div>

    <asp:UpdatePanel ID="CargoGVPanel" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <asp:GridView
                ID="CargoGridView"
                runat="server"
                OnRowDataBound="OnRowDataBound"
                OnPageIndexChanged="CargoGridView_PageIndexChanged"
                OnSelectedIndexChanged="OnSelectedIndexChanged"
                AllowPaging="True"
                PageSize="8"
                AutoGenerateColumns="False"
                DataKeyNames="Cargo_ID"
                DataSourceID="CargoODS"
                EmptyDataText=" "
                GridLines="Horizontal"
                HeaderStyle-CssClass="grid-header"
                PagerStyle-CssClass="grid-pager"
                CssClass="grid-rows"
                SelectedRowStyle-CssClass="grid-selected-rows"
                >

                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="ArrowImage" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Cargo_ID" HeaderText="Cargo_ID" SortExpression="Cargo_ID" Visible="false"></asp:BoundField>

                    <asp:TemplateField HeaderText="Изображение">
                        <ItemTemplate>
                            <asp:HyperLink ID="imageLink" runat="server" NavigateUrl='<%# "../ShowImages.ashx?Cargo_ID=" + Eval("Cargo_ID")%>'>
                                <asp:Image ID="imageCargo" runat="server" CssClass="cargo-image" AlternateText="Изображение груза" ImageUrl='<%# "../ShowImages.ashx?Cargo_ID=" + Eval("Cargo_ID")%>' />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField ControlStyle-CssClass="columns" DataField="Name" HeaderText="Груз" SortExpression="Name">
                        <ControlStyle CssClass="columns" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-CssClass="columns" DataField="Description" HeaderText="Описание груза" SortExpression="Description">
                        <ControlStyle CssClass="columns" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-CssClass="columns" DataField="ShortCode" HeaderText="Код по ETSNG" SortExpression="ShortCode">
                        <ControlStyle CssClass="columns" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-CssClass="columns" DataField="Code" HeaderText="Код груза" SortExpression="Code">
                        <ControlStyle CssClass="columns" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-CssClass="columns" DataField="CodeGNG" HeaderText="Код по GNG" SortExpression="CodeGNG">
                        <ControlStyle CssClass="columns" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-CssClass="columns" DataField="Mnemocode" HeaderText="Мнемокод" SortExpression="Mnemocode">
                        <ControlStyle CssClass="columns" />
                    </asp:BoundField>
                    <asp:CheckBoxField ControlStyle-CssClass="columns" DataField="IsUsed" HeaderText="Используется" SortExpression="IsUsed">
                        <ControlStyle CssClass="columns"></ControlStyle>
                    </asp:CheckBoxField>
                    <asp:CheckBoxField ControlStyle-CssClass="columns" DataField="IsEmpty" HeaderText="Порожний" SortExpression="IsEmpty">
                        <ControlStyle CssClass="columns" />
                    </asp:CheckBoxField>
                </Columns>
                <HeaderStyle CssClass="grid-header" />

                <PagerStyle CssClass="grid-pager"></PagerStyle>

                <SelectedRowStyle CssClass="grid-selected-rows" />
            </asp:GridView>

            <asp:ObjectDataSource 
                ID="CargoODS" 
                runat="server" 
                EnablePaging="True"
                DeleteMethod="DeleteOneRowCargoGuide" 
                SelectMethod="GetCargoGuide" 
                TypeName="DigDes.DSchool.SUPS.DataAccess.PresentData.CargoGuidePresent"
                MaximumRowsParameterName="pageSize"
                StartRowIndexParameterName="startIndex"
                SelectCountMethod="GetTotalNumberOfCargo"
                >
                
                <DeleteParameters>
                    <asp:Parameter Name="Cargo_ID" Type="String" />
                </DeleteParameters>
            </asp:ObjectDataSource>

            <asp:Button ID="AddButton" runat="server" CssClass="edit-buttons" OnClick="AddButton_Click" Text="Добавить" />
            <asp:Button ID="EditButton" runat="server" CssClass="edit-buttons" OnClick="EditButton_Click" Text="Редактировать" />
            <asp:Button ID="DeleteButton" runat="server" CssClass="edit-buttons" OnClick="DeleteButton_Click" Text="Удалить" />

            <br />
            <br />
            <asp:Label ID="lblState" runat="server" CssClass="label-state" Text="" />
            <br />

            </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="AddButton" />
            <asp:PostBackTrigger ControlID="EditButton" />
            <asp:PostBackTrigger ControlID="DeleteButton" />
        </Triggers>

    </asp:UpdatePanel>
        

    <asp:FormView
        ID="CargoFV"
        runat="server"
        CssClass="detailsview"
        DataSourceID="CargoDetailsODS"
        Height="50px"
        Width="57px">

        <ItemTemplate>
            <asp:TextBox ID="Cargo_ID" Text='<%# Bind("Cargo_ID") %>' runat="server" Visible="false" />

            <asp:Label ID="elblName" runat="server" CssClass="labels-detailsview" Text="Груз" />
            <br />
            <asp:TextBox ID="etbName" runat="server" Text='<%# Bind("Name") %>' />
            <br />

            <asp:Label ID="elblDescription" runat="server" CssClass="labels-detailsview" Text="Описание груза" />
            <br />
            <asp:TextBox ID="etbDescription" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" />
            <br />

            <asp:Label ID="elblShortCode" runat="server" CssClass="labels-detailsview" Text="Код по ETSNG" />
            <br />
            <asp:TextBox ID="etbShortCode" runat="server" Text='<%# Bind("ShortCode") %>' />
            <br />

            <asp:Label ID="elblCode" runat="server" CssClass="labels-detailsview" Text="Код груза" />
            <br />
            <asp:TextBox ID="etbCode" runat="server" Text='<%# Bind("Code") %>' />
            <br />

            <asp:Label ID="elblCodeGNG" runat="server" CssClass="labels-detailsview" Text="Код по GNG" />
            <br />
            <asp:TextBox ID="etbCodeGNG" runat="server" Text='<%# Bind("CodeGNG") %>' />
            <br />

            <asp:Label ID="elblMnemocode" runat="server" CssClass="labels-detailsview" Text="Мнемокод" />
            <br />
            <asp:TextBox ID="etbMnemocode" runat="server" Text='<%# Bind("Mnemocode") %>' />
            <br />

            <asp:Label ID="elblIsUsed" runat="server" CssClass="labels-detailsview" Text="Используется" />
            <br />
            <asp:CheckBox ID="echbIsUsed" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsUsed"))%>' />
            <br />

            <asp:Label ID="elblIsEmpty" runat="server" CssClass="labels-detailsview" Text="Порожний" />
            <br />
            <asp:CheckBox ID="echbIsEmpty" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsEmpty"))%>' />
            <br />

            <asp:Label ID="lblImage" runat="server" CssClass="labels-detailsview" Text="Изображение"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" filebytes='<%# Bind("Image") %>' runat="server" />
            <br />

        </ItemTemplate>
        <EditItemTemplate>
            <asp:Label ID="Label1" Text='<%# Bind("Cargo_ID") %>' runat="server" Visible="false" />

            <asp:Label ID="elblName" runat="server" CssClass="labels-detailsview" Text="Груз" />
            <br />
            <asp:TextBox ID="etbName" runat="server" Text='<%# Bind("Name") %>' />
            <br />

            <asp:Label ID="elblDescription" runat="server" CssClass="labels-detailsview" Text="Описание груза" />
            <br />
            <asp:TextBox ID="etbDescription" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" />
            <br />

            <asp:Label ID="elblShortCode" runat="server" CssClass="labels-detailsview" Text="Код по ETSNG" />
            <br />
            <asp:TextBox ID="etbShortCode" runat="server" Text='<%# Bind("ShortCode") %>' />
            <br />

            <asp:Label ID="elblCode" runat="server" CssClass="labels-detailsview" Text="Код груза" />
            <br />
            <asp:TextBox ID="etbCode" runat="server" Text='<%# Bind("Code") %>' />
            <br />

            <asp:Label ID="elblCodeGNG" runat="server" CssClass="labels-detailsview" Text="Код по GNG" />
            <br />
            <asp:TextBox ID="etbCodeGNG" runat="server" Text='<%# Bind("CodeGNG") %>' />
            <br />

            <asp:Label ID="elblMnemocode" runat="server" CssClass="labels-detailsview" Text="Мнемокод" />
            <br />
            <asp:TextBox ID="etbMnemocode" runat="server" Text='<%# Bind("Mnemocode") %>' />
            <br />

            <asp:Label ID="elblIsUsed" runat="server" CssClass="labels-detailsview" Text="Используется" />
            <br />
            <asp:CheckBox ID="echbIsUsed" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsUsed"))%>' />
            <br />

            <asp:Label ID="elblIsEmpty" runat="server" CssClass="labels-detailsview" Text="Порожний" />
            <br />
            <asp:CheckBox ID="echbIsEmpty" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsEmpty"))%>' />
            <br />

            <asp:Label ID="lblImage" runat="server" CssClass="labels-detailsview" Text="Изображение"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" filebytes='<%# Bind("Image") %>' runat="server" />
            <br />

        </EditItemTemplate>

        <InsertItemTemplate>

            <asp:Label ID="elblName" runat="server" CssClass="labels-detailsview" Text="Груз" />
            <br />
            <asp:TextBox ID="etbName" runat="server" Text='<%# Bind("Name") %>' />
            <br />

            <asp:Label ID="elblDescription" runat="server" CssClass="labels-detailsview" Text="Описание груза" />
            <br />
            <asp:TextBox ID="etbDescription" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" />
            <br />

            <asp:Label ID="elblShortCode" runat="server" CssClass="labels-detailsview" Text="Код по ETSNG" />
            <br />
            <asp:TextBox ID="etbShortCode" runat="server" Text='<%# Bind("ShortCode") %>' />
            <br />

            <asp:Label ID="elblCode" runat="server" CssClass="labels-detailsview" Text="Код груза" />
            <br />
            <asp:TextBox ID="etbCode" runat="server" Text='<%# Bind("Code") %>' />
            <br />

            <asp:Label ID="elblCodeGNG" runat="server" CssClass="labels-detailsview" Text="Код по GNG" />
            <br />
            <asp:TextBox ID="etbCodeGNG" runat="server" Text='<%# Bind("CodeGNG") %>' />
            <br />

            <asp:Label ID="elblMnemocode" runat="server" CssClass="labels-detailsview" Text="Мнемокод" />
            <br />
            <asp:TextBox ID="etbMnemocode" runat="server" Text='<%# Bind("Mnemocode") %>' />
            <br />

            <asp:Label ID="elblIsUsed" runat="server" CssClass="labels-detailsview" Text="Используется" />
            <br />
            <asp:CheckBox ID="echbIsUsed" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsUsed"))%>' />
            <br />

            <asp:Label ID="elblIsEmpty" runat="server" CssClass="labels-detailsview" Text="Порожний" />
            <br />
            <asp:CheckBox ID="echbIsEmpty" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsEmpty"))%>' />
            <br />

            <asp:Label ID="lblImage" runat="server" CssClass="labels-detailsview" Text="Изображение"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" filebytes='<%# Bind("Image") %>' runat="server" />
            <br />

        </InsertItemTemplate>
    </asp:FormView>

    <br />

    <asp:ObjectDataSource
        ID="CargoDetailsODS"
        runat="server"
        InsertMethod="InsertOneRowCargoGuide"
        SelectMethod="GetCargoByCode"
        TypeName="DigDes.DSchool.SUPS.DataAccess.PresentData.CargoGuidePresent"
        UpdateMethod="UpdateOneRowCargoGuide">

        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="ShortCode" Type="String" />
            <asp:Parameter Name="Code" Type="String" />
            <asp:Parameter Name="CodeGNG" Type="String" />
            <asp:Parameter Name="Mnemocode" Type="String" />
            <asp:Parameter Name="IsUsed" Type="Boolean" />
            <asp:Parameter Name="IsEmpty" Type="Boolean" />
            <asp:Parameter Name="Image" Type="Object"/>
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter 
                ControlID="CargoGridView" 
                Name="Cargo_ID" 
                PropertyName="SelectedValue" 
                Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Cargo_ID" Type="String" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Image" Type="Object"/>
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="ShortCode" Type="String" />
            <asp:Parameter Name="Code" Type="String" />
            <asp:Parameter Name="CodeGNG" Type="String" />
            <asp:Parameter Name="Mnemocode" Type="String" />
            <asp:Parameter Name="IsUsed" Type="Boolean" />
            <asp:Parameter Name="IsEmpty" Type="Boolean" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:Button ID="SaveButton" runat="server" CssClass="edit-buttons" OnClick="SaveButton_Click" Text="Сохранить" />
    <asp:Button ID="CancelButton" runat="server" CssClass="edit-buttons" OnClick="CancelButton_Click" Text="Отмена" />


</asp:Content>




