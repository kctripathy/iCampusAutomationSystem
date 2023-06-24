<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffPhotoUpload.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS.StaffPhotoUpload" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanel_EmployeeProfiles">
        <ContentTemplate>
            <ul>
                <li>
                    <h1 class="PageTitle">
		                STAFF PHOTO MANAGEMENT:
	                </h1>
                </li>
                <li>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <ul style="margin: 10px; padding: 10px;">
                                <li>
                                    <asp:Label runat="server" ID="lblName" Text="Please select a Staff:" />
							        <asp:DropDownList runat="server" ID="ddl_Employees" Width="100%" Height="30px" Font-Size="Medium" />

                                </li>
                                <li style="padding: 10px 0px;">
                                    <asp:FileUpload runat="server" ID="fileUploadEmployee" CssClass="btn btn-outline-primary" Width="100%" />
                                </li>
                                <li style="padding: 10px 0px;">
                                    <asp:Button runat="server" ID="btnUpload" OnClick="btnUpload_Click" Text="Upload" CssClass="btn btn-primary" Width="100%" />
                                </li>
                            </ul>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnUpload" />
                        </Triggers>
                    </asp:UpdatePanel>
                </li>
                <li class="GridView">
                    <asp:GridView runat="server"
                        ID="gview_Employee"
                        AutoGenerateColumns="false"
                        CssClass="GridView"
                        GridLines="Both"
                        OnInit="gview_Employee_Init"
                        OnRowCommand="gview_EmployeeProfiles_RowCommand"
                        OnRowDataBound="gview_EmployeeProfiles_RowDataBound"
                        OnRowDeleting="gview_EmployeeProfiles_RowDeleting"
                        OnRowEditing="gview_EmployeeProfiles_RowEditing"
                        Width="98%">
                        <PagerStyle CssClass="PagerStyle" VerticalAlign="Middle" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="CheckBox" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbl_EmpName" Text='<%# Eval("EmployeeName") %>' Visible="false" />
                                    <asp:Label runat="server" ID="lbl_EmployeeID" Text='<%# Eval("EmployeeID") %>' Visible="false" />
                                    <asp:Image runat="server" ID="lbl_EmployeeImage" Width="100px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EmployeeCode" HeaderText=" Code " />
                            <asp:BoundField DataField="EmployeeName" HeaderText=" Name " />
                            <asp:CommandField ShowEditButton="True" HeaderText="Upload" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_ADD.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" Visible="false" />
                            <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
                        </Columns>
                    </asp:GridView>
                </li>
            </ul>
            <IAControl:DialogBox ID="dialogUpload"
                runat="server"
                Title="Upload:"
                BackgroundCssClass="modalBackground"
                Style="display: none"
                CssClass="modalPopup"
                EnableViewState="true">
                <ItemTemplate>
                    <ul>
                        <li>
                            <asp:Literal runat="server" ID="lit_Message" />
                        </li>
                    </ul>
                </ItemTemplate>
            </IAControl:DialogBox>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
