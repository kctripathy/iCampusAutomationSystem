<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form4.aspx.cs" Inherits="TCon.iCAS.WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<asp:LinkButton runat="server" ID="lnk_test" Text="XLS" OnClick="lnk_test_Click" />

			<asp:Button runat="server" ID="btnXls" Text="Excel" OnClick="btnXls_Click" />
			<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" />

			<br />
			<asp:TextBox runat="server" ID="txt_Phone" MaxLength="255" Text="917504721428,971556462466" Width="50%" />
			<asp:Button ID="Button_SendSMS" runat="server" Text="SMS" OnClick="Button_SendSMS_Click" />
			<br />
			<asp:TextBox ID="txt_Response" runat="server" TextMode="MultiLine" Rows="2" Width="50%"></asp:TextBox>
		</div>
		<hr />
		<hr />
		<div>
			Text 2 Encrypt: 
			<asp:TextBox runat="server" ID="txt_Text2Encrypt" Width="100%" />
			<asp:Button runat="server" ID="ButtonEncrypt" Text="Encrypt" OnClick="ButtonEncrypt_Click" />
			<asp:TextBox runat="server" ID="txt_ResultEncrypt" Width="100%" />
		</div>
		<hr />
		<hr />
		<div>
			Text 2 Decrypt: 
			<asp:TextBox runat="server" ID="txt_Text2Decrypt" Width="100%" />
			<asp:Button runat="server" ID="ButtonDecrypt" Text="Decrypt" OnClick="ButtonDecrypt_Click" />
			<asp:TextBox runat="server" ID="txt_ResultDecrypt" Width="100%" />
		</div>
	</form>

</body>
</html>
