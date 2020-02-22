<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CustomisedMenu.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.UC_CustomisedMenu" %>

<script type="text/javascript">
    function LoadSearch() {
        alert(' !!...');
        
        window.location = 'WebSearch.aspx';
        
        return;
    }
</script>
<asp:Literal runat="server" ID="lit_CustomisedMenu" Text=".." />
<div id="WebSearchButtonId">    
    <%--<asp:Button runat="server" ID="btnSearch" Text=" " CssClass="WebSearchButton" OnClick="btnSearch_Click"  />   --%> 
    <a href="http://www.tsdcollege.in/websearchform.aspx" title="Click here to search"><img src="../Images/Search.png" class="WebButtonFacebook" /></a>
</div>
<div id="WebFacebookButtonId">
    <a href="https://www.facebook.com/tsdcollege" title="Click here to view the Facebook page of the college" target="_blank"><img src="../Images/social-profiles/facebook.png" class="WebButtonFacebook" /></a>
</div>
 