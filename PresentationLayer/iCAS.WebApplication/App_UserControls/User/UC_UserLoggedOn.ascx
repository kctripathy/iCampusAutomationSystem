<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UserLoggedOn.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.UC_UserLoggedOn" %>

<script>
    function startTime() {
        var today = new Date();
        var h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();
        m = checkTime(m);
        s = checkTime(s);

        document.getElementById('txt_today').innerHTML = today;

        //document.getElementById('txt').innerHTML =
        //h + ":" + m + ":" + s;
        var t = setTimeout(startTime, 500);
    }
    function checkTime(i) {
        if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
        return i;
    }
</script>
<style type="text/css">
    #CurrentUser
    {
        display: block;
        float: left;
        width: 99%;
        text-align: right;
        padding-right: 1%;
    }

    .WelcomeText, dateDiv
    {
        font-family: Lato, sans-serif;
        font-size: 13px;
        color: #fff;
        text-transform: capitalize;
        text-align: right;
        width: 99%;
    }
    #ctrl_LoggedOnUser_lbl_DesignationValue
    {
        text-transform:uppercase;
        text-decoration:underline;
    }
</style>
<ul id="CurrentUser">
    <li class="WelcomeText">
         <asp:Literal runat="server" ID="lit_today" Text="Today:" />
    </li>
    <li class="WelcomeText">
        <asp:Label runat="server" ID="Label1" Text="WEL-COME" />
        <asp:Label runat="server" ID="lbl_UserNameValue" Text="Guest User" CssClass="WelcomeText" />
        </li>
    <li class="WelcomeText">
        <asp:Label runat="server" ID="lbl_FullNameValue" />
        <asp:Label runat="server" ID="lbl_DesignationValue" Text="" />
        <asp:Label runat="server" ID="lbl_OfficeValue" Text="Branch Location, Dist" Visible="false" />
    </li>
</ul>

