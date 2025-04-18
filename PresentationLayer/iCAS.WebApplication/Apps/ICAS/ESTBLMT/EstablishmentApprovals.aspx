﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="EstablishmentApprovals.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.ESTBLMT.EstablishmentApprovals" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <style type="text/css">
        .divider-line {
            margin: 0px;
            padding: 0px;
            color: #424242;
        }

        .apply-message {
            font-weight: bold;
            font-size: small;
            color: darkred;
        }

        .estb-dropdown-view {
            height: 30px;
            width: 87%;
            padding: 5px;
            font-size: inherit;
            font-weight: bold;
        }

        .btn-view {
            padding-left: 20px !important;
            padding-right: 20px !important;
        }
        .tbl-id {
            width: 10px;
            margin: 0px !important;
            padding: 0px !important;
            
        }
        .tbl-author,
        .tbl-status {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function onEstbTypeClick(data) {
            alert(data);
        }
    </script>
    <asp:UpdatePanel runat="server" ID="updatePanel_Approval">
        <ContentTemplate>
            <ul id="EstablishmentApprovalsUL">
                <h1 class="PageTitle">
                    <asp:Literal runat="server" ID="lit_pageTitle"></asp:Literal>
                </h1>
                <li class="FormLabel" style="text-align: right; padding: 10px;">
                    <asp:Label ID="lbl_MessageType" runat="server" Text="Establishment Type:" />
                </li>
                <li class="FormValue">
                        <asp:DropDownList runat="server" ID="ddl_EstablishmentTypeCode" CssClass="estb-dropdown-view">
                        </asp:DropDownList>
                        <asp:Button runat="server" ID="btn_View" CssClass="btn btn-primary m-1 p-2 btn-view" Text="View" OnClick="btn_View_Click" />
                </li>

                <li class="FormLabel" style="text-align: right; padding: 10px;">
                    &nbsp;Action:
                </li>
                <li class="FormValue">
                    <asp:Button ID="btn_Approve" runat="server" OnClick="btn_Approve_Click" CommandArgument="A" Text="APPROVE" CssClass="btn btn-success m-1 p-2 btn-view" CausesValidation="true" />
                    <asp:Button ID="btn_Pending" runat="server" OnClick="btn_Approve_Click" CommandArgument="P" Text="MAKE PENDING" CssClass="btn btn-danger m-1 p-2 btn-view" CausesValidation="true" />
                    <div style="float: right; padding-top: 20px">
                        <asp:CheckBox runat="server" ID="chk_ShowApproved" Text="&nbsp;Show Approved" AutoPostBack="true" OnCheckedChanged="chk_ShowApproved_CheckedChanged" />
                    </div>
                </li>

                <li class="message-text">
                    <asp:Literal ID="lit_Message" runat="server" Text="" />
                </li>

                <li class="GridView">
                    <asp:GridView ID="gview_EstablishmentApprovals" runat="server" AutoGenerateColumns="false"
                        CssClass="GridView">
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Center" CssClass="tbl-id" /> 
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk_EstablishmentID" Visible="true" AutoPostBack="false"   />
                                    <asp:Label runat="server" ID="lbl_EstablishmentID" Text='<%# Eval("EstbID") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EstbID" HeaderText="EstablishmentId" Visible="False" />
                            <asp:BoundField DataField="EstbDate" HeaderText="Date" DataFormatString="{0:dd-MM-yy}" ItemStyle-Width="70px"/>
                            <asp:BoundField DataField="EstbTypeCodeDesc" HeaderText="Type" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbl_Title" Text='<%# Eval("EstbTitle") %>' Font-Bold="true" />
                                    <hr class="divider-line" />
                                    <asp:Label runat="server" ID="lbl_Desc" Text='<%# Eval("EstbDescription") %>' />
                                    <hr class="divider-line" />
                                    <asp:Label runat="server" ID="Label2" Text='<%# Eval("EstbDescription1") %>' />
                                    <hr class="divider-line" />
                                    <asp:Label runat="server" ID="Label3" Text='<%# Eval("EstbDescription2") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AuthorOrContributorName" HeaderText="Author" ItemStyle-CssClass="tbl-author" />
                            <asp:BoundField DataField="EstbStatusFlagDesc" HeaderText="Status" ItemStyle-CssClass="tbl-status" />
                        </Columns>
                    </asp:GridView>
                </li>

            </ul>
            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                <ProgressTemplate>
                    <div id="UpdateProgress">
                        <div class="UpdateProgressAreaLogin">
                            <span class="UpdateProgressAreaTextLogin">Processing...</span>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
    <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground"
        Style="display: none" CssClass="modalPopup" EnableViewState="true">
        <ItemTemplate>
            <ul>
                <li>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </li>
            </ul>
        </ItemTemplate>
    </IAControl:DialogBox>
</asp:Content>
