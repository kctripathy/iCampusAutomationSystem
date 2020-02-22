<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Item.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.Common.UC_Item" %>

            <ul>
				<!--Item Type-->
				<li>
					<asp:Label ID="lbl_ItemType" runat="server" Text="Item Type" />
                    <asp:Label ID="lbl_ItemTypeValidation" runat="server" Text="*" ForeColor="Red" />
				</li>
				<li>
					<asp:DropDownList ID="ddl_ItemType" runat="server"  />
					<asp:RequiredFieldValidator ID="requiredFieldValidator_ItemType" runat="server" ControlToValidate="ddl_ItemType" Display="Dynamic" SetFocusOnError="true"   />
				</li>
                <li>
                    <asp:Label ID="lbl_ItemCode" runat="server" Text="Item Code" />
                </li>
                <li>
                    <asp:TextBox ID="txt_ItemCode" runat="server" />
                </li>
                <!--Description Level-->
				<li>
					<asp:Label ID="lbl_Description" runat="server" Text="Description Level" />
                    <asp:Label ID="lbl_DescriptionValidation" runat="server" Text="*" ForeColor="Red" />
				</li>
				<li>
					<asp:TextBox ID="txt_Description" runat="server" />
					<asp:RequiredFieldValidator ID="requiredFieldValidator_Description" runat="server" ControlToValidate="txt_Description" Display="Dynamic" SetFocusOnError="true"   />
				</li>
				<!--Unit Of Measurement-->
				<li>
					<asp:Label ID="lbl_ItemMeasurement" runat="server" Text="Measurement" />
                    <asp:Label ID="lbl_ItemMeasurementVaidation" runat="server" Text="*" ForeColor="Red" />
				</li>
				<li>
					<asp:DropDownList ID="ddl_ItemMeasurement" runat="server" />
					<asp:RequiredFieldValidator ID="requiredFieldValidator_Measurement" runat="server" ControlToValidate="ddl_ItemMeasurement" Display="Dynamic" SetFocusOnError="true"   />
				</li>
				<!--Rate Per Unit-->
				<li>
					<asp:Label ID="lbl_ItemPrice" runat="server" Text="Item Price" />
				</li>
				<li>
					<asp:TextBox ID="txt_ItemPrice" runat="server" />
				</li>
				<!--Stock In Hand-->
				<li>
					<asp:Label ID="lbl_StockInHand" runat="server" Text="Stock InHand" />
				</li>
				<li>
					<asp:TextBox ID="txt_StockInHand" runat="server" />
					
				</li>
            </ul>