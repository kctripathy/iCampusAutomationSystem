<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="CommonKeys.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.CommonKeys" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <style type="text/css">
       .GridViewUL
       {
           display: block;
            width: 100%;
            margin: 0;
            padding: 0;
            list-style-type: none;
            background-color: floralwhite;
       }
        
        
         /*  Define the background color for all the ODD background rows  */
        .GridView div > table > tbody > tr:nth-child(odd)
        {
            background-color: floralwhite;
        }
        /*  Define the background color for all the EVEN background rows  */
        .GridView div > table > tbody > tr:nth-child(even)
        {
            background-color: ghostwhite;
        }

        .GridView div > table > tbody > tr:nth-child(even)
        {
            background-color: ghostwhite;
        }

        .GridView
        {
            display: block;
            width: 100%;
            margin: 0;
            padding: 0;
        }

            .GridView div
            {
                display: block;
                width: 101%;
                margin: 0 0 0 -26px;
                padding: 0;
            }


            div.OptionsStyle > table
                {
                    width: 100%;
                    border: solid 1px red;
                }

                div.OptionsStyle > table > tbody > tr {
                    border: 2px solid #A3C0E8;
                    background-color: #A3C0E8;
                }

                    div.OptionsStyle > table > tbody > tr > td {
                        /*background-image: url(../Images/gvHeaderBackground.gif);*/
                        color: navy;
                        display: block;
                        float: left;
                        width: 11%;
                        min-height: 50px;
                        border-left: 1px solid #A3C0E8;
                        background-image: url(../Images/H1PageTitleBg.gif);
                        background-position: top;
                        background-repeat: repeat-x;
                        background-color: #E2F0FF;
                        padding: 0px 5px;
                        text-align: center;
                    }

                        div.OptionsStyle > table > tbody > tr > td input {
                            display: block;
                            float: left;
                            width: 100%;
                            text-align: center;
                        }

                        div.OptionsStyle > table > tbody > tr > td label {
                            font-weight: normal;
                            font-family: Lato, sans-serif;
                            font-size: 10pt;
                            text-align: center;
                            font-weight: normal;
                            word-wrap: break-word;
                            margin-top: 5px;
                        }


                .HeaderStyle {
                    background-image: url(../Images/gvHeaderBackground.gif);
                    background-color: #E2F0FF;
                    padding: 5px 0px;
                    height: 20px;
                    width: 100%;
                }

                    .HeaderStyle th {
                        padding-left: 4px;
                        text-align: left;
                        border: solid 1px #A3C0E8;
                        color: Navy;
                    }

                .GridView table {
                    clear: left;
                    margin-top: 3px;
                    border: Solid 1px #A3C0E8;
                    width: 100%;
                }


                    .GridView table td {
                        padding: 4px 0px 2px 4px;
                        color: Navy;
                        border: dotted 1px #E2F0FF;
                        border-bottom: Solid 1px #A3C0E8;
                        border-right: Solid 1px #A3C0E8;
                        height: auto;
                    }

                .ViewLinkItem input {
                    margin-left: 5px;
                    width: 20px;
                }

                #DialogBoxUL > li {
                    display: block;
                    float: left;
                }

                    #DialogBoxUL > li:nth-child(odd) {
                        border-bottom: solid 1px skyblue;
                        width: 99%;
                        margin-bottom: 2px;
                        padding: 2px 0px;
                    }

                    #DialogBoxUL > li:nth-child(even) {
                        background-color: lightblue;
                        width: 98%;
                        margin-bottom: 2px;
                        padding: 2px 0px;
                    }
    </style>
    <asp:UpdatePanel runat="server" ID="updatePanelUserCommonKeys">
        <ContentTemplate>
            <div class="innercontent">
                <h1 class="PageTitle">
                    <asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Your CommonKeys :-" />
                </h1>
                <h1 class="PageSubTitle">
                    <asp:Literal runat="server" ID="Literal1" />
                </h1>
                <li class="FormButton_Top">
                    <div id="Top">
                        <asp:Button runat="server" ID="btn_AddNew" Text=" Save " OnClick="btn_AddNew_Clicked" />
                        <asp:Button runat="server" ID="btn_Reset" Text="Reset" OnClick="btn_Reset_Click" CausesValidation="false" />
                    </div>
                </li>

                <ul class="GridViewUL" style="display: table;">
                    <li>
                        <ul id="CommonKeys">
                            <li id="Label">
                                <asp:Literal runat="server" ID="lit_AddNew" Text="Add New Common Key of Type:" />
                            </li>
                            <li id="KeyType">
                                <asp:DropDownList runat="server" ID="ddl_CommonKeyName" AutoPostBack="True" OnSelectedIndexChanged="ddl_CommonKeyName_SelectedIndexChanged" />
                            </li>
                            <li id="KeyValue">
                                <asp:TextBox runat="server" ID="txt_AddNew" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AddNew" ControlToValidate="txt_AddNew" Text="*" SetFocusOnError="true" ForeColor="Red" />
                            </li>
                        </ul>
                    </li>
                    <li class="CommonKeyLI">
                        <asp:GridView ID="gview_CommonKeys"
                                                    runat="server" AutoGenerateColumns="False" 
                                                    PageSize="55" AllowPaging="true" 
                                                    OnPageIndexChanging="gview_CommonKeys_PageIndexChanging" 
                                                    OnRowCommand="gview_CommonKeys_RowCommand" 
                                                    OnRowDataBound="gview_CommonKeys_RowDataBound" 
                                                    OnRowDeleting="gview_CommonKeys_RowDeleting" 
                                                    OnRowEditing="gview_CommonKeys_RowEditing"
                                                    Width="100%"
                            >
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EditRowStyle CssClass="EditRowStyle" />
                            <Columns>
                                <asp:BoundField ShowHeader="false" DataField="FieldForceID" Visible="false" />
                                <asp:TemplateField Visible="true" ItemStyle-CssClass="FFCheck">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbl_CommonKeyID" Text='<%# Eval("CommonKeyID") %>' Visible="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CommonKeyValue" HeaderText="Key Value " ItemStyle-CssClass="Value" ItemStyle-Width="80%" />
                                <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem" />
                                <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem" />
                            </Columns>
                            <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                            <PagerStyle CssClass="MicroPagerStyle" />
                        </asp:GridView>
                        <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
                            <ItemTemplate>
                                <ul id="CustomerDialog">
                                    <li>
                                        <asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
                                    </li>
                                </ul>
                            </ItemTemplate>
                        </IAControl:DialogBox>
                    </li>
                </ul>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
