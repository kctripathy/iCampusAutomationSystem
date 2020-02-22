<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_MenuDynamic.ascx.cs" Inherits="UC_MenuDynamic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
<script type="text/javascript">

	$(document).ready(
    function initMenus() {
    	$('ul.Menu ul').hide();
    	$.each($('ul.Menu'), function () {
    		$('#' + this.id + '.expandfirst ul:first').show();
    	});
    	$('ul.Menu li a').click(
                function () {
                	var checkElement = $(this).next();
                	var parent = this.parentNode.parentNode.id;
                	if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
                		$('#' + parent + ' ul:visible').slideUp('normal');
                		checkElement.slideDown('normal');
                		return false;
                	}
                	else { checkElement.slideUp('normal'); }

                }
        );
    });
 

</script>
<script type="text/javascript">
	var cssmenuids = ["DropDownMenu"] //Enter id(s) of CSS Horizontal UL menus, separated by commas
	var csssubmenuoffset = -1 //Offset of submenus from main menu. Default is 0 pixels.

	function createcssmenu2() {
		for (var i = 0; i < cssmenuids.length; i++) {
			var ultags = document.getElementById(cssmenuids[i]).getElementsByTagName("ul")
			for (var t = 0; t < ultags.length; t++) {
				ultags[t].style.top = ultags[t].parentNode.offsetHeight + csssubmenuoffset + "px"
				var spanref = document.createElement("span")
				spanref.className = "arrowdiv"
				spanref.innerHTML = "&nbsp;&nbsp;&nbsp;&nbsp;"
				ultags[t].parentNode.getElementsByTagName("a")[0].appendChild(spanref)
				ultags[t].parentNode.onmouseover = function () {
					this.style.zIndex = 100
					this.getElementsByTagName("ul")[0].style.visibility = "visible"
					this.getElementsByTagName("ul")[0].style.zIndex = 0
					this.getElementsByTagName("ul")[0].style.width = "200px";
				}
				ultags[t].parentNode.onmouseout = function () {
					this.style.zIndex = 0
					this.getElementsByTagName("ul")[0].style.visibility = "hidden"
					this.getElementsByTagName("ul")[0].style.zIndex = 100
				}
			}
		}
	}

	if (window.addEventListener)
		window.addEventListener("load", createcssmenu2, false)
	else if (window.attachEvent)
		window.attachEvent("onload", createcssmenu2)
</script>
<style type="text/css">
	ul.Menu, ul.Menu ul
	{
		list-style-type: none;
		margin: 0;
		padding: 0;
		width: 15em;
		float: right;
		width: 100%;
		-webkit-box-shadow: 3px 2px 3px rgba(0,0,0,0.7);
		-moz-box-shadow: 3px 2px 3px rgba(0,0,0,0.7);
	}
	
	ul.Menu a
	{
		display: block;
		text-decoration: none;
	}
	
	ul.Menu li
	{
		margin-top: 1px;
	}
	
	ul.Menu li a
	{
		background: #003366;
		color: #fff;
		padding: 0.5em;
	}
	
	ul.Menu li a:hover
	{
		background: #B7C7E1;
		color: #fff;
	}
	
	ul.Menu li ul li a
	{
		display: block;
		background: #E7EFFA;
		color: Black;
		border-bottom: 1px dotted #fff;
	}
	
	ul.Menu li ul li a:hover
	{
		background: #B7C7E1;
		color: #6C0023;
		text-decoration: underline;
	}
</style>
<style type="text/css">
	div.HorizontalCssMenu
	{
		width: 100%;
		height: auto;
	}
	
	
	.HorizontalCssMenu ul, .HorizontalCssMenu ul#DropDownMenu
	{
		margin: 0;
		padding: 0;
		list-style-type: none;
		-webkit-box-shadow: 3px 2px 3px rgba(0,0,0,0.7);
		-moz-box-shadow: 3px 2px 3px rgba(0,0,0,0.7);
		width: 100%;
		
	}
	
	/*Top level list items*/
	.HorizontalCssMenu ul li
	{
		position: relative;
		display: inline;
		float: left;
		
	}
	
	/*Top level menu link items style*/
	.HorizontalCssMenu ul li a
	{
		display: block;
		width: auto;
		height: 15px; /*Width of top level menu link items*/
		padding: 2px 8px;
		border: 1px solid #202020;
		border-left-width: 0;
		text-decoration: none;
		display: block;
		color: White;
		background-color: Navy;
		-webkit-box-shadow: 3px 2px 3px rgba(0,0,0,0.7);
		-moz-box-shadow: 3px 2px 3px rgba(0,0,0,0.7);
	}
	
	/*Sub level menu*/
	.HorizontalCssMenu ul li ul
	{
		left: 0;
		top: 0;
		border-top: 1px solid #202020;
		position: absolute;
		display: block;
		visibility: hidden;
		z-index: 100;
	}
	
	/*Sub level menu list items*/
	.HorizontalCssMenu ul li ul li
	{
		display: block;
		float: none;
	}
	
	
	/* Sub level menu links style */
	.HorizontalCssMenu ul li ul li a
	{
		/*width of sub menu levels*/
		font-weight: normal;
		display: block; /*padding: 2px 5px;*/
		background: #e3f1bd;
		height: auto;
		width: auto;
		color: Black;
		border-width: 0 1px 1px 1px;
	}
	
	.HorizontalCssMenu ul li a:hover
	{
		background: LightBlue;
	}
	
	.HorizontalCssMenu ul li ul li a:hover
	{
		background: LightBlue;
		text-decoration: underline;
		color: Maroon;
	}
	
	.HorizontalCssMenu .arrowdiv
	{
		/*position: absolute;*/
		right: 0;
		background: transparent url('/Themes/Default/Images/devxArrowDown.gif') no-repeat center left;
		/*margin-left: 2px;*/
	}
	
	* html p#iepara
	{
		/*For a paragraph (if any) that immediately follows menu, add 1em top spacing between the two in IE*/
		padding-top: 1em;
	}
</style>
<%--<ul id="menu1"  class="Menu">
<asp:Literal ID="lit_Menu" runat="server" />
</ul>--%>
<div class="HorizontalCssMenu">
	<asp:Literal ID="lit_Menu" runat="server" />
</div>
<%--<ajaxToolkit:Accordion ID="ajaxAcco_Menu" runat="server" SelectedIndex="1" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="Fill" RequireOpenedPane="false" SuppressHeaderPostbacks="true" Height="590px">
	<Panes>
		<ajaxToolkit:AccordionPane ID="AccordionPane_Transaction" runat="server">
			<Header>
				<a href="" class="accordionLink">MICRO TRANSACTIONS</a></Header>
			<Content>
				<asp:Literal runat="server" ID="lit_Transaction" Text="lit_Transaction" />
                </Content>
		</ajaxToolkit:AccordionPane>
        <ajaxToolkit:AccordionPane ID="AccordionPane_Customer" runat="server">
        <Header>
        <a href="" class="accordionLink">CUSTOMER & FIELDFORCE</a></Header>
        <Content>
        <asp:Literal runat="server" ID="lit_Customer" Text="" /> 
        </Content>
        
        </ajaxToolkit:AccordionPane>
     
        <ajaxToolkit:AccordionPane ID="AccordionPane_Finance" runat="server">
        <Header>
        <a href="" class="accordionLink">FINANCE SECTION</a></Header>
        <Content>
        <asp:Literal runat="server" ID="lit_Finance" Text="" /> 
        
        </Content>
        
        </ajaxToolkit:AccordionPane>

        <ajaxToolkit:AccordionPane ID="AccordionPane_HRMS" runat="server">
        <Header>
        <a href="" class="accordionLink">HUMAN RESOURCE</a></Header>
        <Content>
        <asp:Literal runat="server" ID="lit_Human" Text="" /> 
        
        </Content>
        
        </ajaxToolkit:AccordionPane>

         <ajaxToolkit:AccordionPane ID="AccordionPane_User" runat="server">
        <Header>
        <a href="" class="accordionLink">USER SECTION</a></Header>
        <Content>
        <asp:Literal runat="server" ID="lit_User" Text="" /> 
        </Content>
        
        </ajaxToolkit:AccordionPane>

         <ajaxToolkit:AccordionPane ID="AccordionPane_Administration" runat="server">
        <Header>
        <a href="" class="accordionLink">ADMINISTRATION SECTION</a></Header>
        <Content>
        <asp:Literal runat="server" ID="lit_Administration" Text="" /> 
        </Content>
        </ajaxToolkit:AccordionPane>
        </Panes>
        </ajaxToolkit:Accordion>
<div id="DynamicMenu">
	<asp:Literal runat="server" ID="lit_Menu" Text="."></asp:Literal>
</div>
--%>
