<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="FeedBackMaster.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.ADMIN.FeedBackMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Feedback View Master:-" />
    </h1>
    <asp:UpdatePanel ID="updatepanel_ManageFeedbacks" runat="server">
        <ContentTemplate>
            <div>
                <ul>
                <li class="FormButton_Top">
                <asp:Button runat="server"  ID="btn_AllFeedback" text="All FeedBack" onclick="btn_AllFeedback_Click" />
                </li>
                <li class="PageSubTitle">
					<asp:Label runat="server" ID="Label14" Text="FeedBack Details(Admin) :" />
				</li>
                 <li class="FormLabel">
                        <asp:Label ID="lbl_Question" runat="server" Text="Select a Student" />
                 </li>
                 <li class="FormValue">
                   <asp:DropDownList ID="ddl_Username" runat="server" AutoPostBack="True" onselectedindexchanged="ddl_Username_SelectedIndexChanged" />                   
                 </li>                               
                <li class="PageSubTitle">
                    <asp:Label runat="server" Text="View FeedBack Here" ID="Label1" />
                </li>
                <li class="Gview_Question">
                    <asp:GridView ID="gridview_Question" runat="server" AllowPaging="true" AllowSorting="true"
                        AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" PagerSettings-Position="Bottom"
                        Width="100%" PageSize="10" 
                        onpageindexchanging="gridview_Question_PageIndexChanging" 
                        onrowdatabound="gridview_Question_RowDataBound">
                        <HeaderStyle CssClass="HeaderStyle" />
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="OptionID">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbl_OptionID" Text='<%# Eval("QuestionID") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="QuestionID" HeaderText="QuestionID" Visible="false" />
                            <asp:BoundField DataField="UserID" HeaderText="User ID" ItemStyle-CssClass="UserID" />
                            <asp:BoundField DataField="QuestionTitle" HeaderText="Type" ItemStyle-CssClass="UserID" />
                            <asp:BoundField DataField="QuestionDesc" HeaderText="Description" ItemStyle-CssClass="UserID" />
                            <asp:BoundField DataField="OptionValue" HeaderText="Answer" ItemStyle-CssClass="OptionValue" />
                        </Columns>
                        <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                            Mode="NumericFirstLast" />
                        <PagerStyle CssClass="MicroPagerStyle" />
                    </asp:GridView>
                </li>
                </ul> 
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground"
        Style="display: none" CssClass="modalPopup" EnableViewState="true">
        <ItemTemplate>
            <ul>
                <li>
                    <asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
                </li>
            </ul>
        </ItemTemplate>
    </IAControl:DialogBox>
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <div id="UpdateProgress">
                <div class="UpdateProgressArea">
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
