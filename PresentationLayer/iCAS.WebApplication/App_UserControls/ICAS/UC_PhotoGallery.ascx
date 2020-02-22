<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_PhotoGallery.ascx.cs" Inherits="LTPL.ICAS.WebApplication.App_UserControls.ICAS.UC_PhotoGallery" %>

<asp:Literal runat="server" ID="lit_ThumbnailDivContent" Text="~" />
<style type="text/css">
    .photoThumbnailLink
    {
        width: 150px;
        height: 126px;
        padding: 5px;
        margin: 5px;
        display: block;
        float: left;
    }

    img.photoThumbnailImg
    {
        height: 112px;
        width: 150px;
        /*border:groove 2px #808080;
        width: auto;
        height: 150px;*/
    }

    ul.clearfix li
    {
        width: 179px;
        border: solid 1px skyblue;
        margin: 5px;
        padding: 2px;
        display: block;
        float: left;
    }
</style>
