<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LibraryBookAdd.ascx.cs" Inherits="TCon.iCAS.WebApplication.App_UserControls.Library.UC_LibraryBookAdd" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>

<style type="text/css">
    ul#LibraryBook
    {
        display: block;
        float: left;
        width: 100%;
        margin: 0;
        padding: 0;
        list-style-type: none;
    }

        ul#LibraryBook li
        {
            display: block;
            float: left;
            width: 25%;
            margin: 0;
            padding: 0;
        }

            ul#LibraryBook li.PageSubTitle
            {
                width: 100%;
                font-weight: bold;
                background-color: lightyellow;
            }

            ul#LibraryBook li:nth-child(even)
            {
                background-color: lightgoldenrodyellow;
            }

            ul#LibraryBook li:nth-child(odd)
            {
                background-color: floralwhite;
            }

    #UploadSectionUL
    {
        display: none;
    }

    .RequiredField
    {
        color: red;
    }
</style>
<ul id="LibraryBook">
    <li class="PageSubTitle">
        <asp:Label runat="server" ID="lbl_PersonalDetails" Text="Book Details:" />
    </li>
    <li class="FormLabel">
        <asp:Label runat="server" ID="lblAdmissionYear" Text="Segment:" />
    </li>
    <li class="FormValue">
        <asp:DropDownList ID="ddl_Segemnts" runat="server" Width="70%" />
    </li>
    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="lbl_LibraryBookName" Text="Accession No.:" />

    </li>
    <li class="FormValue">
        <asp:TextBox runat="server" ID="txt_AccessionNo" />
        <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AccessionNo" ControlToValidate="txt_AccessionNo" Display="Dynamic" SetFocusOnError="true" />
        <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_AccessionNo" ControlToValidate="txt_AccessionNo" Display="Dynamic" SetFocusOnError="true" />
    </li>
    <li class="FormLabel">
        <asp:Label runat="server" ID="Label1" Text="-" />
    </li>
    <li class="FormValue">
        <asp:RadioButtonList ID="rblst_Books" RepeatDirection="Horizontal" runat="server">
            <asp:ListItem Text="General" Value="GEN" Selected="True"></asp:ListItem>
            <asp:ListItem Text="UGC" Value="UGC" Selected="False"></asp:ListItem>
        </asp:RadioButtonList>
    </li>
    <%--Date of Accession--%>
    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="lbl_DateOfAccession" Text="Accession Date: " />
    </li>
    <li class="FormValue">
        <asp:TextBox runat="server" ID="txt_DateOfAccession" Width="40%" AutoPostBack="false" />
        <asp:ImageButton runat="server" ID="imgbtn_DateOfBirth" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
        <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DateOfBirth" ControlToValidate="txt_DateOfAccession" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Date of Accession" SetFocusOnError="true" />
        <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DateOfBirth" ControlToValidate="txt_DateOfAccession" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Invalid Date" />
    </li>

    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label3" Text="Author:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="txt_Author" runat="server" />
        <asp:DropDownList ID="ddl_Author" runat="server" />
    </li>

    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label2" Text="Title:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBoxTitle" runat="server" />
    </li>

    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label4" Text="Edition:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBoxEdition" runat="server" />
    </li>
    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label5" Text="Year:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBoxYear" runat="server" />
    </li>
    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label6" Text="Volume No:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBoxVolume" runat="server" />
    </li>

    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label7" Text="Pages:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBoxPages" runat="server" />
    </li>


    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label8" Text="Publisher:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBoxPublisher" runat="server" />
        <asp:DropDownList ID="DropDownListPublisher" runat="server" />
    </li>


    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label9" Text="Supplier:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBoxSupplier" runat="server" />
        <asp:DropDownList ID="DropDownList2" runat="server" />
    </li>

    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label10" Text="Price:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBox1" runat="server" />
    </li>

    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label11" Text="Bill No:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBox2" runat="server" />
    </li>


    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label15" Text="Bill Date: " />
    </li>
    <li class="FormValue">
        <asp:TextBox runat="server" ID="TextBox6" Width="40%" AutoPostBack="false" />
        <asp:ImageButton runat="server" ID="ImageButton1" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
        <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator1" ControlToValidate="txt_DateOfAccession" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Date of Accession" SetFocusOnError="true" />
        <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator1" ControlToValidate="txt_DateOfAccession" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Invalid Date" />
    </li>
    <li class="FormLabel">
        <asp:Label runat="server" ID="Label18" Text="Category:" />
    </li>
    <li class="FormValue">
        <asp:DropDownList ID="DropDownListCategory" runat="server" />
    </li>
    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label12" Text="Class No:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBox3" runat="server" />
    </li>
    <li class="FormLabel">
        <span class="RequiredField">*</span>
        <asp:Label runat="server" ID="Label13" Text="IBN No:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBox4" runat="server" />
    </li>
    <li class="FormLabel">
        <asp:Label runat="server" ID="Label14" Text="Remarks:" />
    </li>
    <li class="FormValue">
        <asp:TextBox ID="TextBox5" runat="server" />
    </li>
</ul>
<ul id="UploadSectionUL">
    <li class="FormLabel inVisible">
        <asp:Label runat="server" ID="Label16" Text="Cover Page Photo:" />
    </li>
    <li class="FormValue inVisible">
        <asp:FileUpload runat="server" ID="FileUpload_CoverPage" />
    </li>
    <li class="FormLabel inVisible">
        <asp:Label runat="server" ID="Label17" Text="Soft Copy / Pdf file:" />
    </li>
    <li class="FormValue inVisible">
        <asp:FileUpload runat="server" ID="FileUpload__SoftCopy" />
    </li>
</ul>
<IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
    <ItemTemplate>
        <ul>
            <li>
                <asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
            </li>
        </ul>
    </ItemTemplate>
</IAControl:DialogBox>
