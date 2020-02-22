<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="GoverningBody.aspx.cs" Inherits="Micro.WebApplication.GoverningBody" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:UpdatePanel ID="UpdatePanel_Establishment" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<h1 class="PageTitle">
				<asp:Literal runat="server" ID="lit_PageTitle" Text="Members of Governing Body:-" />
			</h1>
			<div class="innercontent">

				<ul>
					<li>
						<p>
							 

						</p>
					</li>
					<li>
					</li>
				</ul>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
