<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="MasterPayComponents.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS.MasterPayComponents" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" 
            Text="Employee PayRoll component Entry:-" />
    </h1>
   <asp:UpdatePanel runat="server" ID="updatepanel_EmployeePayrollComponents">
        <ContentTemplate>
            <div>            
                <asp:MultiView ID="multiview_EmployeePayrollComponents" runat="server">
                    <asp:View ID="InputControls" runat="server">
                        <ul>                
                        <li class="FormButton_Top">
                            <asp:Button ID="btn_Submit" runat="server" Text=" Save " 
                            CausesValidation="true" onclick="btn_Submit_Click" Visible="False"/>
                            <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false" 
                            onclick="btn_View_Click"/>
                            <asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false" 
                            onclick="btn_reset_Click"/>
                        </li>
                        </ul>
                        <ul>  
                             <li class="PageSubTitle">
                                    <asp:Label ID="lbl_Employee" runat="server" Font-Bold="True"  Text="Payroll Component Setting of Employee:-" />
                                    <asp:Label ID="lbl_message" runat="server"></asp:Label>
                             </li>                 
                             <%--Pay Component ID--%>
                             <li class="StaffFullWidth">
                                 <asp:Panel ID="Panel1" runat="server" Visible="False">
                                 <ul>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="ame" Text="Component Name" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PayComponentName" AutoPostBack="false" />
                            </li>
                              <%-- PayComponent Type--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PayComponentType" Text="PayComponent Type" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="DropDown_PayComponentType" 
                                    AutoPostBack="false" Enabled="False" >
                                    <asp:ListItem Value="0">[--Select--]</asp:ListItem>
                                    <asp:ListItem Value="Save">Saving</asp:ListItem>
                                    <asp:ListItem Value="Sub">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Add">Addition</asp:ListItem>
                                    <asp:ListItem Value="Per">Perchantage</asp:ListItem>
                                </asp:DropDownList>
                                
                            </li>
                            <li class="FormLabel">
                            Has Parent ?
                            </li>
                            <li class="FormValue">
                                <asp:RadioButtonList ID="RadioSelectComponent" runat="server" 
                                    RepeatDirection="Horizontal" AutoPostBack="True" 
                                    onselectedindexchanged="RadioSelectComponent_SelectedIndexChanged">
                                    <asp:ListItem>Yes </asp:ListItem>
                                    <asp:ListItem Selected="True">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </li>
                            <li class="StaffFullWidth">                            
                                <asp:Panel ID="pnlParentStaffDetail" runat="server" Visible="False">
                                <ul>
                                <li class="FormLabel">
                                    Parent Component ID
                                </li>
                                <li class="FormValue">                                
                                 <asp:DropDownList runat="server" ID="DropDown_ParentComponent" 
                                    AutoPostBack="False"/>
                                </li>
                                <li class="FormLabel">
                                Relation
                                </li>
                                <li class="FormValue">                                
                                 <asp:DropDownList runat="server" ID="DropDown_Relation" 
                                    AutoPostBack="True" 
                                        onselectedindexchanged="DropDown_Relation_SelectedIndexChanged">
                                     <asp:ListItem Selected="True">--Select--</asp:ListItem>
                                     <asp:ListItem>Plus(+)</asp:ListItem>
                                     <asp:ListItem>Minus(-)</asp:ListItem>
                                     <asp:ListItem>Perchantage(%)</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtPerchantage" runat="server" Visible="False" Width="50px"></asp:TextBox>
                                </li>
                                </ul>
                                </asp:Panel>
                            </li>
                                 </ul>
                                 </asp:Panel>
                             </li>
                           
                             </ul> 
                             <ul>                
                                <li class="FormButton_Top">
                                    <asp:Button ID="btn_Submit1" runat="server" Text=" Save " 
                                    CausesValidation="true" onclick="btn_Submit_Click" Visible="False"/>
                                    <asp:Button ID="btn_View1" runat="server" Text="View" CausesValidation="false" 
                                    onclick="btn_View_Click"/>
                                    <asp:Button ID="btn_reset1" runat="server" Text="Reset" CausesValidation="false" 
                                    onclick="btn_reset_Click"/>
                                </li>
                            </ul>
                    </asp:View>
                    <asp:View ID="view_Grid" runat="server">
                        <ul>
                        <li class="FormButton_Top">
                        <asp:Button ID="btn_AddNew" runat="server" Text="Add New" onclick="btn_AddNew_Click" />
                        </li>
                            <li class="Gridview">                                
                                <asp:GridView ID="GridBindEmpPayComponents0" runat="server" 
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="White" 
                                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" 
                                    CssClass="GridView" DataKeyNames="RecordNo" GridLines="None" 
                                    onrowcancelingedit="GridBindEmpPayComponents_RowCancelingEdit" 
                                    onrowcommand="GridBindEmpPayComponents_RowCommand" 
                                    onrowdatabound="GridBindEmpPayComponents_RowDataBound" 
                                    onrowdeleting="GridBindEmpPayComponents_RowDeleting" 
                                    onrowediting="GridBindEmpPayComponents_RowEditing" 
                                    onrowupdating="GridBindEmpPayComponents_RowUpdating" ShowFooter="True" 
                                    Width="98%">
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="RecordID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecordNumber0" runat="server" Text='<%# Eval("RecordNo")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lbleid0" runat="server" Text='<%#Eval("RecordNo") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:LinkButton ID="lnkinsert0" runat="server" CommandName="Insert" 
                                                    Text="Insert"></asp:LinkButton>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PayComponent Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaycomponentbind0" runat="server" 
                                                    Text='<%#Eval("PayComponentName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblPaycomponent0" runat="server" 
                                                    Text='<%# Eval("PayComponentDesc")%>' Visible="false"></asp:Label>
                                                <asp:DropDownList ID="ddlPayComponent0" runat="server" AutoPostBack="True" 
                                                    onselectedindexchanged="ddlPayComponent_SelectedIndexChanged" width="150px">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddladdPayComponent0" runat="server" AutoPostBack="True" 
                                                    onselectedindexchanged="ddladdPayComponent_SelectedIndexChanged" Width="150px">
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PayComponent Type">
                                            <ItemTemplate>
                                                <%#Eval("PayComponentType")%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblPaycomponentType0" runat="server" 
                                                    Text='<%# Eval("PayComponentType")%>' Visible="false"></asp:Label>
                                                <asp:DropDownList ID="ddlPayComponentType0" runat="server" Enabled="false" 
                                                    width="150px">
                                                    <asp:ListItem Value="0">[--Select--]</asp:ListItem>
                                                    <asp:ListItem Value="Save">Saving</asp:ListItem>
                                                    <asp:ListItem Value="Sub">Deduction</asp:ListItem>
                                                    <asp:ListItem Value="Add">Addition</asp:ListItem>
                                                    <asp:ListItem Value="Per">Perchantage</asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddladdPayComponentType0" runat="server" Enabled="false" 
                                                    Width="150px">
                                                    <asp:ListItem Value="0">[--Select--]</asp:ListItem>
                                                    <asp:ListItem Value="Save">Saving</asp:ListItem>
                                                    <asp:ListItem Value="Sub">Deduction</asp:ListItem>
                                                    <asp:ListItem Value="Add">Addition</asp:ListItem>
                                                    <asp:ListItem Value="Per">Perchantage</asp:ListItem>
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PayComponent Value">
                                            <ItemTemplate>
                                                <%#Eval("PayComponentAmount")%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPCValue0" runat="server" 
                                                    Text='<%#Eval("PayComponentAmount") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtPCaddValue0" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ControlStyle-ForeColor="Blue " ShowEditButton="true">
                                        <ControlStyle ForeColor="Blue" />
                                        </asp:CommandField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkdelete0" runat="server" 
                                                    CommandArgument='<%#Eval("RecordNo") %>' CommandName="Delete" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                                </asp:GridView>
                            </li>
                               </ul>
                                </asp:view>
                            </asp:multiview>
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
