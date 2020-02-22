<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.ContactUs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">


<h1 class="PageTitle">Contact Us:
</h1>
<div id="CtnctUs">
<asp:Panel ID="panel_Contact" runat="server" Width="500" Height="300">
<h2>Email Us
</h2>
<ul id="ContactUs">

<li class="FormLabel">
<asp:Label ID="lbl_Name" runat="server" Text="Name:" />
</li>
<li class="FormValue">
<asp:TextBox ID="txt_Name" runat="server"  Width="250px" />
<asp:RequiredFieldValidator ID="requiredFieldValidator_Name" runat="server" ControlToValidate="txt_Name" Display="Dynamic" SetFocusOnError="true" />
</li>
<li class="FormLabel">
<asp:Label ID="lbl_Address" runat="server" Text="Address:" />
</li>
<li class="FormValue">
<asp:TextBox ID="txt_Address" runat="server" Width="250px" TextMode="MultiLine"/>
</li>
<li class="FormLabel">
<asp:Label ID="lbl_Phone" runat="server" Text="Phone:" />

</li>
<li class="FormValue">
<asp:TextBox ID="txt_Phone" runat="server" />
<asp:RegularExpressionValidator runat="server" ID="regulalExpressionVlidator_Phone" Display="Dynamic" ControlToValidate="txt_Phone" ValidationExpression="^[0-9\s]+$" SetFocusOnError="true"  />
</li>
<li class="FormLabel">
<asp:Label ID="lbl_Email" runat="server" Text="Email:" />
</li>
<li class="FormValue">
<asp:TextBox ID="txt_FromEmail" runat="server" Width="250px" />
<asp:RequiredFieldValidator ID="requiredFieldValidator_Email" runat="server" ControlToValidate="txt_FromEmail" Display="Dynamic" SetFocusOnError="true" />
<asp:RegularExpressionValidator ID="regularExpressionValidator_Email" runat="server" ControlToValidate="txt_FromEmail" Display="Dynamic" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
</li>
<li class="FormLabel">
<asp:Label runat="server" ID="lbl_Subject" Text="Subject:" />
</li>
<li class="FormValue">
<asp:TextBox runat="server" ID="txt_Subject" Width="250px" />
</li>
<li class="FormLabel">
<asp:Label runat="server" ID="lbl_MessageBody" Text="Message Body:" /> 
</li>
<li class="FormValue">
<asp:TextBox runat="server" ID="txt_MessageBody" Width="250px" Height="80px" TextMode="MultiLine" />
</li>
<li class="FormSpacer20px" />
<li class="FormLabel">
<asp:Label runat="server" ID="lbl_Message" />
</li>
<li class="FormButton_Top">
<asp:Button ID="btn_Submit" runat="server" Text="Submit" onclick="btn_Submit_Click" />
</li>
</ul>
</asp:Panel>
<br/>
<br />

<asp:Panel runat="server" ID="panel_Micro" Width="600" Height="200">
<br />
<h3>MICRO GROUP
</h3>
<ul>
<li class="FormLabel">
<asp:Label ID="lbl_MicroAddress" runat="server" /> 
<br />
</li>
<li class="PageSubTitle">
<asp:Label ID="lbl_PhoneSubhead" runat="server" Text="Phone"  />
<br />
</li>
<li class="FormLabel">
<asp:Label ID="lbl_PhoneDetils" runat="server"  />
</li>
<li class="PageSubTitle">
<asp:Label ID="lbl_EmailSubHead" runat="server" Text="Email" />
<br />
</li>
<li class="FormLabel">
<asp:Label ID="lbl_MicroEmailAddress" runat="server"  />
</li>
</ul>
</asp:Panel>
<li class="FormLabel">.</li>
<li class="FormValue">.</li>

</div>

</asp:Content>
