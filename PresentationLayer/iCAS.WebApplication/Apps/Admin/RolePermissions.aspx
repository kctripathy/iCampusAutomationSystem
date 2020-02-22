<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="RolePermissions.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.RolePermissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <script type="text/javascript">
        var TREEVIEW_ID = "ContentPlaceHolderMicroERP_tview_RolePermissions"; //the ID of the TreeView control
        //the constants used by GetNodeIndex()
        var LINK = 0;
        var CHECKBOX = 1;

        //this function is executed whenever user clicks on the node text
        function ToggleCheckBox(senderId) {
            var nodeIndex = GetNodeIndex(senderId, LINK);
            var checkBoxId = TREEVIEW_ID + "n" + nodeIndex + "CheckBox";
            var checkBox = document.getElementById(checkBoxId);
            checkBox.checked = !checkBox.checked;
            //alert(checkBoxId);
            ToggleChildCheckBoxes(checkBox);
            ToggleParentCheckBox(checkBox);
        }

        //checkbox click event handler
        function checkBox_Click(eventElement) {
            //alert('b-');
            ToggleChildCheckBoxes(eventElement.target);
            ToggleParentCheckBox(eventElement.target);
        }

        //returns the index of the clicked link or the checkbox
        function GetNodeIndex(elementId, elementType) {
            var nodeIndex;
            if (elementType == LINK) {
                nodeIndex = elementId.substring((TREEVIEW_ID + "t").length);
            }
            else if (elementType == CHECKBOX) {
                nodeIndex = elementId.substring((TREEVIEW_ID + "n").length, elementId.indexOf("CheckBox"));
            }
            //alert(nodeIndex);
            return nodeIndex;
        }

        //checks or unchecks the nested checkboxes
        function ToggleChildCheckBoxes(checkBox) {

            var postfix = "n";
            var childContainerId = TREEVIEW_ID + postfix + GetNodeIndex(checkBox.id, CHECKBOX) + "Nodes";
            var childContainer = document.getElementById(childContainerId);
            //alert(childContainerId);
            //alert(childContainer);
            if (childContainer) {
                var childCheckBoxes = childContainer.getElementsByTagName("input");
                for (var i = 0; i < childCheckBoxes.length; i++) {
                    //alert(childCheckBoxes[i]);
                    childCheckBoxes[i].checked = checkBox.checked;
                }
            }
        }

        //unchecks the parent checkboxes if the current one is unchecked
        function ToggleParentCheckBox(checkBox) {
            if (checkBox.checked == true) {
                var parentContainer = GetParentNodeById(checkBox, TREEVIEW_ID);
                if (parentContainer) {
                    var parentCheckBoxId = parentContainer.id.substring(0, parentContainer.id.search("Nodes")) + "CheckBox";
                    if ($get(parentCheckBoxId) && $get(parentCheckBoxId).type == "checkbox") {
                        $get(parentCheckBoxId).checked = false;
                        ToggleParentCheckBox($get(parentCheckBoxId));
                    }
                }
            }
        }

        //returns the ID of the parent container if the current checkbox is unchecked
        function GetParentNodeById(element, id) {
            var parent = element.parentNode;
            if (parent == null) {
                return false;
            }
            if (parent.id.search(id) == -1) {
                return GetParentNodeById(parent, id);
            }
            else {
                return parent;
            }
        }
    </script>
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_MenuOrForm" Text="-- Permission To Role (--) :" />
    </h1>
    <ul>
        <li class="PageSubTitle"></li>
        <li class="FiftyFifty">
            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="chk_MenuOrForm" AutoPostBack="true" OnSelectedIndexChanged="chk_MenuOrForm_SelectedIndexChanged">
                <asp:ListItem Text="Menu Permissions &nbsp;&nbsp;&nbsp; " Value="M" Selected="True" />
                <asp:ListItem Text="Form Permissions " Value="F" />
            </asp:RadioButtonList>
        </li>
        <li class="FormButton_Top">
            <asp:Button runat="server" ID="btn_Add" Text=" UPDATE ROLE PERMISSION " OnClick="btn_Submit_Click" />
        </li>

    </ul>
    <div id="RolePermissions">
        <ul id="RolePerm">
            <li id="li_Roles" runat="server">
                <asp:Label runat="server" ID="lblSelect" Text="<b>Select Role:-</b>" />
                <asp:RadioButtonList runat="server" ID="chkList_Roles" OnSelectedIndexChanged="chkListRoles_SelectedIndexChanged" AutoPostBack="true" RepeatLayout="UnorderedList" />
            </li>
            <li id="li_Menus" runat="server">
                <asp:TreeView ID="tview_RolePermissions" runat="server" ShowCheckBoxes="All" ShowLines="true" />
            </li>
            <li id="li_Forms" runat="server">
                <asp:GridView runat="server" ID="gview_FormPermissions" AllowPaging="false" PageSize="20" AutoGenerateColumns="false" OnRowDataBound="gview_FormPermissions_RowDataBound">
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbl_WebMenuId" Text='<%# Eval("WebMenuID") %>' Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MenuDisplayText" HeaderText="Name of the Form:" ItemStyle-CssClass="FormName" ItemStyle-Wrap="false" HeaderStyle-CssClass="LeftAlignHeader" />
                        <asp:BoundField DataField="NavigationURL" HeaderText="Navigation URL" ItemStyle-CssClass="FormName" ItemStyle-Wrap="false" HeaderStyle-CssClass="LeftAlignHeader" />
                        <asp:TemplateField HeaderText="Check All">
                            <HeaderTemplate>
                                <asp:Literal runat="server" ID="lit_Add" Text="Add" /><br />
                                <asp:CheckBox ID="chkSelectAll_Add" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_Add_CheckedChanged" ToolTip="Select All ADD Permissions" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_Add" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Check All">
                            <HeaderTemplate>
                                <asp:Literal runat="server" ID="lit_Edit" Text="Edit" />
                                <br />
                                <asp:CheckBox ID="chkSelectAll_Edit" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_Edit_CheckedChanged" ToolTip="Select/Deselect all EDIT Permissions" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_Edit" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Check All">
                            <HeaderTemplate>
                                <asp:Literal runat="server" ID="lit_Del" Text="Del." />
                                <br />
                                <asp:CheckBox ID="chkSelectAll_Del" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_Del_CheckedChanged" ToolTip="Select/Deselect all DELETE Permissions" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_Del" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Check All">
                            <HeaderTemplate>
                                <asp:Literal runat="server" ID="lit_View" Text="View" /><br />
                                <asp:CheckBox ID="chkSelectAll_View" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_View_CheckedChanged" ToolTip="Select/Deselect all VIEW Permissions" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_View" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </li>
        </ul>
    </div>
    <div class="FormButton_Top">
        <asp:Label runat="server" ID="lbl_Msg" CssClass="FormMessage" Text="." />
        <asp:Button runat="server" ID="btn_Submit" Text=" UPDATE ROLE PERMISSION " OnClick="btn_Submit_Click" />
    </div>
    <script type="text/javascript">
        var links = document.getElementsByTagName("a");
        for (var i = 0; i < links.length; i++) {
            if (links[i].className == TREEVIEW_ID + "_0") {
                links[i].href = "javascript:ToggleCheckBox(\"" + links[i].id + "\");";
            }
        }

        var checkBoxes = document.getElementsByTagName("input");
        for (var i = 0; i < checkBoxes.length; i++) {
            if (checkBoxes[i].type == "checkbox") {
                $addHandler(checkBoxes[i], "click", checkBox_Click);
            }
        }
    </script>
</asp:Content>
