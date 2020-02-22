<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentFeedBack.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.ADMIN.StudentFeedBack" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <asp:UpdatePanel ID="updatepanel_ManageFeedbacks" runat="server">
        <ContentTemplate>
            <h1 class="PageTitle">
                <asp:Literal runat="server" ID="lit_PageTitle" Text="Please provide your feedback:" />
            </h1>
            <div>
                <ul>
                    <li class="FormButton_Top">
                        <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />
                        <asp:Button ID="btn_Reset" runat="server" Text="Reset" OnClick="btn_Reset_Click" />
                    </li>
                    <li class="GridView">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowPaging="true" AllowSorting="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="QuestionID">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbl_QuestionID" Text='<%# Eval("QuestionID") %>' Visible="true" />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="QuestionID" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="QuestionID" HeaderText="Question ID" Visible="false" />
                                <asp:BoundField DataField="QuestionDesc" HeaderText="Qusetion" ItemStyle-CssClass="Questions"/>
                                <asp:TemplateField HeaderText="Options" ItemStyle-CssClass="QuestionOptions">
                                    <ItemTemplate>
                                        <ul>
                                            <li>
                                                <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton4_CheckedChanged" />
                                            </li>
                                            <li>
                                                <asp:RadioButton ID="RadioButton5" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton5_CheckedChanged" />
                                            </li>
                                            <li>
                                                <asp:RadioButton ID="RadioButton6" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton6_CheckedChanged" />
                                            </li>
                                            <li>
                                                <asp:RadioButton ID="RadioButton7" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton7_CheckedChanged" />
                                            </li>
                                        </ul>
                                        
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                        </asp:GridView>
                    </li>
                </ul>
            </div>

            <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
