<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffPayComponents.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS.StaffPayComponents" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Employee PayRoll Component Entry:-" />
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
                             <li class="StaffFullWidth">
            <asp:ListView ID="ListView1" runat="server" onitemcommand="ListView1_ItemCommand">                                         
            <LayoutTemplate>            
                <table border="1" cellpadding="0">
                    <tr style="background-color:#E5E5FE">
                        <th align="left"><asp:LinkButton ID="lnkId" runat="server" CommandName="Sort" CommandArgument="ID">EmployeeId</asp:LinkButton></th>
                        <th align="left"><asp:LinkButton ID="lnkName" runat="server" CommandName="Sort" CommandArgument="FirstName">Employee Name</asp:LinkButton></th>
                        <th align="left"><asp:LinkButton ID="lnkType" runat="server" CommandName="Sort" CommandArgument="ContactType">Employee Type</asp:LinkButton></th>
                        <th></th>
                    </tr>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
                <asp:DataPager ID="ItemDataPager" runat="server" PageSize="25">
                    <Fields>
                        <asp:NumericPagerField ButtonCount="2" />
                    </Fields>
                </asp:DataPager>    
            </LayoutTemplate>
            <ItemTemplate>
                    <tr>
                        <td><asp:Label runat="server" Text='<%#Eval("EmployeeID") %>' ID="lblId"></asp:Label></td>
                        <td><asp:Label runat="server" ID="lblName"><%#Eval("EmployeeName")%></asp:Label></td>
                        <td><asp:Label runat="server" ID="lblType"><%#Eval("DesignationID")%></asp:Label></td>
                        <td><asp:LinkButton ID="lnkEdit" runat="server" CommandName="GO"><img src="../../../Themes/Common/Images/Forward_32x32.png" /></asp:LinkButton></td>
                    </tr>
            </ItemTemplate>                                                
        </asp:ListView>
        
        
                             
                              </li>
                             <li class="PageSubTitle">
                                    <asp:Label ID="lbl_Employee" runat="server" Font-Bold="True"  Text="Payroll Component Setting of Employee:-" />
                                    <asp:Label ID="lblemployeeBind" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lbl_message" runat="server"></asp:Label>
                             </li>                 
                             <%--Pay Component ID--%>
                             <li class="StaffFullWidth">
                                 <asp:Panel ID="Panel1" runat="server" Visible="False">
                                 <ul>
                                  <li class="FormLabel">
                                <asp:Label ID="Paycomponentid" runat="server" Text="Pay Component ID"></asp:Label>
                             
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="Dropdown_PayComponentID" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="Dropdown_PayComponentID_SelectedIndexChanged" />
                            </li>
                             <%--Amount Of PayComponent--%>
                                     <asp:Label ID="lbl_PaycomponentID" runat="server" Visible="False"></asp:Label>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PayAmount" Text="Pay Amount" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PayAmount" AutoPostBack="false" />
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
                                
                                <asp:ImageButton ID="ImageButton2" runat="server" Height="20px" 
                                    ImageUrl="~/Themes/Default/Images/BtnAdd.jpg" onclick="ImageButton1_Click" 
                                    Width="40px" />
                                
                            </li>
                                 </ul>
                                 </asp:Panel>
                             </li>
                           
                            <li class="GridView">
                            <asp:GridView runat="server" ID="gview_Component" AutoGenerateColumns="True" AllowPaging="true"
                                    AllowSorting="true" PageSize="15" Width="98%" CssClass="GridView" GridLines="Both"
                                    CellPadding="2" Visible="False">
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="CheckBox">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk_SubjectID" Visible="true" Checked="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="HeaderStyle" />
                                </asp:GridView>
                                 <%--<asp:GridView runat="server" ID="GridView_BindComponent" 
                                    AutoGenerateColumns="False" AllowPaging="True"
                                    AllowSorting="True" PageSize="15" Width="98%" CssClass="GridView"
                                    CellPadding="2" HorizontalAlign="Left">
                                    <HeaderStyle CssClass="HeaderStyle" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="CheckBox">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk_SubjectID" Visible="true" Checked="true" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="CheckBox" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EmpPayComponent Record" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecordNumberS" runat="server" 
                                                    Text='<%# Eval("RecordNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PayComponentID" HeaderText="Pay Component" 
                                            SortExpression="PayComponentID" />
                                        <asp:BoundField DataField="PayComponentAmount" HeaderText="PayAmount" 
                                            SortExpression="PayAmount" />
                                        <asp:BoundField DataField="SessionID" HeaderText="SessionID" 
                                            SortExpression="SessionID" />
                                    </Columns>
                                    <HeaderStyle CssClass="HeaderStyle" />
                                     <RowStyle HorizontalAlign="Left" />
                                </asp:GridView>--%>    
                                <asp:GridView ID="GridBindEmpPayComponents" runat="server" 
                                    AutoGenerateColumns ="False" Width="98%" CssClass="GridView"
            onrowdatabound="GridBindEmpPayComponents_RowDataBound" onrowdeleting="GridBindEmpPayComponents_RowDeleting"
            onrowediting="GridBindEmpPayComponents_RowEditing" DataKeyNames="RecordNo" ShowFooter="True"
            onrowcommand="GridBindEmpPayComponents_RowCommand" onrowupdating="GridBindEmpPayComponents_RowUpdating"
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"
            CellPadding="3" GridLines="None" CellSpacing="1"
            onrowcancelingedit="GridBindEmpPayComponents_RowCancelingEdit" EmptyDataText="NoRecordFound" 
                                    ShowHeaderWhenEmpty="True" >
            <HeaderStyle CssClass="HeaderStyle" />
        <Columns >
        <asp:TemplateField HeaderText="RecordID">
 
            <FooterTemplate>
                New &gt;&gt;
            </FooterTemplate>
 
        <ItemTemplate>
            <asp:Label ID="lblRecordNumber" runat="server" Text='<%# Eval("RecordNo")%>'></asp:Label> 
        </ItemTemplate>
        <EditItemTemplate >
            <asp:Label ID="lbleid" runat="server" Text='<%#Eval("RecordNo") %>'></asp:Label>
            </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PayComponent Name">
            <ItemTemplate>
            <asp:Label ID="lblPaycomponentbind" runat="server" Text='<%#Eval("PayComponentName")%>'></asp:Label> 
            </ItemTemplate>
            <EditItemTemplate >
                <asp:Label ID="lblPaycomponent" runat="server" Visible="false" Text='<%# Eval("PayComponentDesc")%>'></asp:Label>
                <asp:DropDownList ID="ddlPayComponent" runat="server" width ="150px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlPayComponent_SelectedIndexChanged">
                 
                </asp:DropDownList>
            </EditItemTemplate>
            <FooterTemplate >
                <asp:DropDownList ID="ddladdPayComponent" runat="server" Width="150px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddladdPayComponent_SelectedIndexChanged">
                 
                </asp:DropDownList>
            </FooterTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="PayComponent Type">
            <ItemTemplate>
                <asp:Label ID="lblbindPtype" runat="server" Text='<%#Eval("PayComponentType")%>'></asp:Label>            
            </ItemTemplate>
            <EditItemTemplate >
                <asp:Label ID="lblPaycomponentType" runat="server" Visible="false" Text='<%# Eval("PayComponentType")%>'></asp:Label>
                <asp:DropDownList ID="ddlPayComponentType" runat="server" width ="150px" Enabled="false">
                <asp:ListItem Value="0">[--Select--]</asp:ListItem>
                                    <asp:ListItem Value="Save">Saving</asp:ListItem>
                                    <asp:ListItem Value="Sub">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Add">Addition</asp:ListItem>
                                    <asp:ListItem Value="Per">Perchantage</asp:ListItem>
                </asp:DropDownList>
            </EditItemTemplate>
            <FooterTemplate >
                <asp:DropDownList ID="ddladdPayComponentType" runat="server" Width="150px" Enabled="false">
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
            <EditItemTemplate >
                <asp:TextBox ID="txtPCValue" runat="server" Text='<%#Eval("PayComponentAmount") %>'></asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate >
                <asp:TextBox ID="txtPCaddValue" runat="server"></asp:TextBox>
            </FooterTemplate>
            </asp:TemplateField>
          
            <asp:CommandField ShowEditButton ="true" ControlStyle-ForeColor ="Blue " ButtonType="Image"  EditImageUrl="~/Themes/Common/Images/edit.gif" UpdateImageUrl ="~/Themes/Common/Images/update.png" CancelImageUrl="~/Themes/Common/Images/cancel.png"
                HeaderText="Edit/Update" >
            <ControlStyle ForeColor="Blue"></ControlStyle>
            </asp:CommandField>
            <asp:TemplateField HeaderText="Delete">
                <FooterTemplate>
                    <asp:ImageButton ID="lnkinsert" runat="server" CommandName="Insert" 
                        ImageUrl ="~/Themes/Common/Images/save-32x32.png" Height="32px" Width="32px" />
                </FooterTemplate>
            <ItemTemplate>
                <asp:ImageButton CommandName ="Delete" CommandArgument ='<%#Eval("RecordNo") %>' ID="lnkdelete" runat="server" ImageUrl="~/Themes/Default/Images/delete.gif" />
            <%--<asp:LinkButton  runat="server" ID ="lnkdelete" Text="Delete" ></asp:LinkButton>--%>
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
                            <li>
                                <asp:Button ID="btn_AddNew" runat="server" Text="Add New" onclick="btn_AddNew_Click" />
                            </li>
                            <li class="Gview_EmployeePayrollComponents">
                                <asp:GridView ID="gridview_EmployeePayrollComponents" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" Width="98%"
                                    OnRowCommand="EmployeePayrollComponents_RowCommand" OnRowDeleting="EmployeePayrollComponents_RowDeleting"
                                    OnRowEditing="EmployeePayrollComponents_RowEditing" OnRowDataBound="EmployeePayrollComponents_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="QualsID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_EmployeeID" Text='<%# Eval("EmployeeID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" Visible="true" />
                                        <asp:BoundField DataField="EmployeeType" HeaderText="Employee Type" Visible="true" />                                        
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
