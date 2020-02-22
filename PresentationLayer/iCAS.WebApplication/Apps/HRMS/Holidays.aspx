<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Holidays.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.Holidays" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanel_HolidayList">
        <ContentTemplate>
            <ul class="GridView">
                <li>
                    <asp:GridView runat="server" ID="gview_HolidayDetails"
                        AutoGenerateColumns="False" Width="700px">
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbl_HolidayId" Text='<%# Eval("HolidayID") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="HolidayID" HeaderText="HolidayID" Visible="false" />
                            <asp:BoundField DataField="Occasion" HeaderText="Occasion " />
                            <asp:BoundField DataField="DateOfOccasion" HeaderText="Date " DataFormatString="{0:dd/MM/yyyy}" />
                        </Columns>
                    </asp:GridView>
                </li>

            </ul>
        </ContentTemplate>

    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <div id="UpdateProgress">
                <div class="UpdateProgressArea" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
