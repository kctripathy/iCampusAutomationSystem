<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="ShiftTimings.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.ShiftTimings" %>
  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">

<script language="javascript" type="text/javascript">
    function ClearUI() {
        $find("textValidator").hide();
        $get("txt_InTime").value = "";
    }
    function IsValid() {
        var textbox = $get("txt_InTime");
        if (textbox.value == "") {
            return false;
        }
        else
            return true;
    }
    function ClosePopup() {
        if (IsValid()) {
            $find('modalwithinput').hide();
            alert("You have given your name");
            ClearUI();
        }
    }
</script>
    <asp:UpdatePanel ID="updatePanel_ShiftTiming" runat="server">
        <ContentTemplate>
            <ul>
                <asp:GridView runat="server" ID="gview_ShiftTiming" AutoGenerateColumns="false" AllowPaging="true"  
                DataKeyNames="ShiftID"  AllowSorting="true" PageSize="20" Width="98%" CssClass="GridView" GridLines="Both" 
                 OnRowEditing="gview_ShiftTiming_RowEditing"  OnRowCommand="gview_ShiftTiming_RowCommand"  OnPageIndexChanging="gview_ShiftTiming_PageIndexChanging">
                    <PagerStyle HorizontalAlign="Center" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <Columns>
                       <%-- <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbl_ShiftTimingID" Text='<%# Eval("ShiftTimingID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                  <%--      <asp:BoundField DataField="WeeklyOffDay" HeaderText="WeeklyOffDay" ItemStyle-CssClass="OfficeName"  />--%>
									  
                        <asp:TemplateField HeaderText="ShiftID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbl_ShiftID" Text='<%# Eval("ShiftID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ShiftTimingID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbl_ShiftTimingID" />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="ShiftOfficeWiseID"  Visible="true">
							            <ItemTemplate>
								            <asp:Label runat="server" ID="lbl_ShiftOfficeId"  Visible="true" />
							            </ItemTemplate>
						            </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Description"  Visible="true">
							            <ItemTemplate>
								            <asp:Label runat="server" ID="lbl_ShiftDescription"  Visible="true" />
							            </ItemTemplate>
						            </asp:TemplateField> 
                                      <asp:TemplateField HeaderText="Alias"  Visible="true">
							            <ItemTemplate>
								          <asp:Label runat="server" ID="lbl_ShiftAlias"  Visible="true" />
                                        <%--   <asp:TextBox runat="server" ID="txt_ShiftAlias"  Visible="true" />--%>
							            </ItemTemplate>
						            </asp:TemplateField> 
                                    
                                    <asp:TemplateField HeaderText="InTime"   Visible="true">
							            <ItemTemplate>
								            <asp:Label runat="server" ID="lbl_InTime"  Visible="true" />
							            </ItemTemplate>
						            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OutTime"  Visible="true">
							            <ItemTemplate>
								             <asp:Label runat="server" ID="lbl_OutTime" Visible="true"  />
							            </ItemTemplate>
						            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="WeeklyOff"  Visible="true">
							            <ItemTemplate>
								            <asp:Label runat="server" ID="lbl_WeeklyOff" Visible="true"  />
							            </ItemTemplate>
						            </asp:TemplateField>

                   
                      <%--  <asp:TemplateField>
                        
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_WeeklyOff" runat="server" />
                            </EditItemTemplate>
                           
                        </asp:TemplateField>--%>
                       <asp:TemplateField HeaderText="Check All">
							                <HeaderTemplate>
								            <asp:Literal runat="server" ID="lit_Add" Text="Add" /><br />
								            <asp:CheckBox ID="chkSelectAll_Add" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_Add_CheckedChanged" ToolTip="Select All ADD Permissions" />
							                </HeaderTemplate>
							            <ItemTemplate>
								            <asp:CheckBox ID="chk_Add" runat="server" />
							            </ItemTemplate>
						                </asp:TemplateField>
                       
                      <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico"
                        ControlStyle-CssClass="EditLink" />
                    </Columns>
                    <%--<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                        Mode="NumericFirstLast" />
                    <PagerStyle CssClass="MicroPagerStyle" />--%>
                </asp:GridView>
            </ul>

             <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
        PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="269px" Width="400px"
        Style="display: none">
        <table width="100%" style="border: Solid 3px #D55500; width: 100%; height: 100%"
            cellpadding="0" cellspacing="0">
            <tr style="background-color: #D55500">
                <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                    align="center">
                  Shift Details
                </td>
            </tr>
             <tr>
                <td align="right" style="width: 45%">
                    ShiftId:
                </td>
                <td>
                    <asp:Label ID="lbl_ShiftID" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td align="right" style="width: 45%">
                    ShiftTimingId:
                </td>
                <td>
                    <asp:Label ID="lbl_ShiftTimingID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Description:
                </td>
                <td>
                    <asp:Label ID="lbl_Description" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Alias:
                </td>
                <td>
                   <asp:Label ID="lbl_Alias" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    InTime:
                </td>
                <td>
                    <asp:TextBox ID="txt_InTime" runat="server" Columns="7" />
                     <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                AcceptAMPM="true" ErrorTooltipEnabled="true" Mask="99:99" MaskType="Time"
                                MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                TargetControlID="txt_InTime">
                            </ajax:MaskedEditExtender>
                            <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server"
		controltovalidate="txt_InTime" errormessage="InTime Can't be Left Blank"
		setfocusonerror="true" display="None"></asp:requiredfieldvalidator>
        <ajax:validatorcalloutextender id="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" targetcontrolid="RequiredFieldValidator1"	behaviorid="textValidator" enabled="True">
	</ajax:validatorcalloutextender>
     <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_InTime" ControlToValidate="txt_InTime" Display="Dynamic" SetFocusOnError="true" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    OutTime:
                </td>
                <td>
                     <asp:TextBox ID="txt_OutTime" runat="server" Columns="7" />
                           <ajax:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                AcceptAMPM="true" ErrorTooltipEnabled="true" Mask="99:99" MaskType="Time"
                                MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                TargetControlID="txt_OutTime">
                            </ajax:MaskedEditExtender>
                            <asp:requiredfieldvalidator id="requiredFieldValidator_OutTime" runat="server"
		controltovalidate="txt_OutTime" errormessage="InTime Can't be Left Blank"
		setfocusonerror="true" display="None"></asp:requiredfieldvalidator>
        <ajax:validatorcalloutextender id="Validatorcalloutextender_OutTime" runat="server" targetcontrolid="requiredFieldValidator_OutTime"	behaviorid="textValidator" enabled="True">
	</ajax:validatorcalloutextender>
     <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_OutTime" ControlToValidate="txt_OutTime" Display="Dynamic" SetFocusOnError="true" />
                </td>
            </tr>
            <tr>
                <td align="right">
                   Weekly Off :
                </td>
                <td>
                    <asp:DropDownList ID="ddl_WeeklyOff" runat="server" />
                </td>
            </tr>
          
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Update" OnClick="btnUpdate_Click"
                        />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel"  OnClick="btnCancel_Click" CausesValidation="false"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
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
