<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="Feedbacks.aspx.cs" Inherits="LTPL.ICAS.WebApplication.Feedbacks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:UpdatePanel ID="updatepanel_ManageFeedbacks" runat="server">
<ContentTemplate>
<div>
<asp:MultiView ID="multiview_ManageFeedbacks" runat="server">
<asp:View ID="view_EnterQuestions" runat="server">
<h1 class="PageTitle">
		<ul>
			<li style="display: block; float: left; width: 30%;">
				<asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Feedback Details for :-" />
			</li>
			<li><span class="notBold">
				<asp:RadioButtonList runat="server" ID="radio_UserType" RepeatDirection="Horizontal" AutoPostBack="True" >
					<asp:ListItem>Student</asp:ListItem>
					<asp:ListItem>Staff</asp:ListItem>
                    <asp:ListItem>Alumni</asp:ListItem>
                    <asp:ListItem>Guest</asp:ListItem>
				</asp:RadioButtonList>
			</span>
            </li>
		</ul>
        </h1>
        <ul>
        <li class="PageSubTitle">
        <asp:Label ID="lbl_UserDetails" runat="server" Text="Enter your details below :- " />
        </li>
        <asp:Panel ID="penal_UserDetails" runat="server">
        <li class="FormLabel">
        <asp:Label ID="lbl_UserID" runat="server" Text="User ID" />
        </li>
        <li class="FormValue">
        <asp:TextBox ID="txt_UserID" runat="server"/>
        </li>
        <li class="FormLabel">
        <asp:Label ID="lbl_Name" runat="server" Text="Name" />
        </li>
        <li class="FormValue">
        <asp:TextBox ID="txt_Name" runat="server"/>
        </li>
        <li class="FormLabel">
        <asp:Label ID="lbl_EmailID" runat="server" Text="Email ID" />
        </li>
        <li class="FormValue">
        <asp:TextBox ID="txt_EmailID" runat="server"/>
        </li>
        
        </asp:Panel>
        </ul>
          </asp:View>
     </asp:MultiView>
        </div>
            </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
