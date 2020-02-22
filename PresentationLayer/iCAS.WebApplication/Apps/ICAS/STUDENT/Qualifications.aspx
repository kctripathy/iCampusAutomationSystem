<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Qualifications.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT.Qualifications" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="New Qualification Details:-" />
    </h1>
   <asp:UpdatePanel runat="server" ID="updatepanel_Qualification">
        <ContentTemplate>
            <div>            
                <asp:MultiView ID="multiview_Qualification" runat="server">
                    <asp:View ID="InputControls" runat="server">
                        <ul>                
                        <li class="FormButton_Top">
                            <asp:Button ID="btn_Submit" runat="server" Text=" Save " 
                            CausesValidation="true" onclick="btn_Submit_Click"/>
                            <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false" 
                            onclick="btn_View_Click"/>
                            <asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false" 
                            onclick="btn_reset_Click"/>
                        </li>
                        </ul>
                        <ul>                   
                             <%--QualificationCode--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_QualificationCode" Text="QualificationCode"></asp:Label>
                             
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_QualificationCode" AutoPostBack="true" />
                            </li>
                             <%--QualificationType--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_QualifiationType" Text="QualificationType" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_QualificationType" AutoPostBack="true" />
                            </li>
                              <%-- QualificationName--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_QualificationName" Text=" QualificationName" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_QualificationName" AutoPostBack="true" />
                            </li>
                             </ul> 
                             <ul>                
                                <li class="FormButton_Top">
                                    <asp:Button ID="btn_Submit1" runat="server" Text=" Save " 
                                    CausesValidation="true" onclick="btn_Submit_Click"/>
                                    <asp:Button ID="btn_View1" runat="server" Text="View" CausesValidation="false" 
                                    onclick="btn_View_Click"/>
                                    <asp:Button ID="btn_reset1" runat="server" Text="Reset" CausesValidation="false" 
                                    onclick="btn_reset_Click"/>
                                </li>
                            </ul>
                    </asp:View>
                    <asp:View ID="view_Grid" runat="server">
                        <ul>
                            <li>
                                <asp:Button ID="btn_AddNew" runat="server" Text="Add New" 
                                    onclick="btn_AddNew_Click" />
                            </li>
                            <li class="Gview_Qualifications">
                                <asp:GridView ID="gridview_Qualification" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" Width="98%"
                                    OnRowCommand="Qualification_RowCommand" OnRowDeleting="Qualification_RowDeleting"
                                    OnRowEditing="Qualification_RowEditing" OnRowDataBound="Qualification_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="QualsID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_QualificationID" Text='<%# Eval("QualID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:BoundField DataField="QualCode" HeaderText="QualificationCode" Visible="true" />
                                        <asp:BoundField DataField="QualType" HeaderText="QualificationType" Visible="true" />
                                        <asp:BoundField DataField="QualName" HeaderText=" QualificationName" />
                                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico"
                                            ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem">
                                            <ControlStyle CssClass="EditLink" />
                                            <ItemStyle CssClass="EditLinkItem" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico"
                                            ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
                                            <ControlStyle CssClass="DeleteLink" />
                                            <ItemStyle CssClass="DeleteLinkItem" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico"
                                            ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem">
                                            <ControlStyle CssClass="ViewLink" />
                                            <ItemStyle CssClass="ViewLinkItem" />
                                        </asp:CommandField>
                                    </Columns>
                                    <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                                        Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="MicroPagerStyle" />
                                </asp:GridView>
                                </li>
                               </ul>
                                </asp:view>
                            </asp:multiview>
            </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>
   
   <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <div id="UpdateProgress">
                <div class="UpdateProgressArea">
                </div>
            </div>
        </ProgressTemplate>
          </asp:UpdateProgress>
</asp:Content>
